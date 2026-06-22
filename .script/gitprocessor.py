import csv
import re
import requests
import os

AUTH = os.environ["AUTH_SMC"]
HEADERS = {
    "Authorization": f"Bearer ghp_{AUTH}",
    "Accept": "application/vnd.github+json",
}

PROPERTY_HEADER = re.compile(
    r"""
    public
    \s+
    (?P<type>[A-Za-z_][\w<>,\.\?\[\]]*)
    \s+
    (?P<name>[A-Za-z_]\w*)
    \s*
    \{
    """,
    re.VERBOSE | re.MULTILINE,
)

url_cache = {}


def get_url_data():
    try:
        with open("url_data.tsv", newline="", encoding="utf-8") as file:
            reader = csv.reader(file, delimiter="\t")

            for row in reader:
                if len(row) < 4:
                    continue

                class_type = row[0].strip()
                url = row[1].strip()
                date = row[2].strip()
                sha = row[3].strip()

                url_cache[(class_type, url)] = (date, sha)
    except FileNotFoundError:
        pass


def save_url_data():
    with open("url_data.tsv", "w", newline="", encoding="utf-8") as file:
        writer = csv.writer(file, delimiter="\t")

        for (class_type, url), (date, sha) in url_cache.items():
            writer.writerow([class_type, url, date, sha])


def get_github_last_modified(url):
    m = re.match(r"https://github\.com/([^/]+)/([^/]+)/blob/([^/]+)/(.*)", url)

    if not m:
        return None

    owner, repo, branch, path = m.groups()

    api_url = (
        f"https://api.github.com/repos/{owner}/{repo}"
        f"/commits?path={path}&sha={branch}&per_page=1"
    )

    r = requests.get(api_url, headers=HEADERS, timeout=30)
    r.raise_for_status()

    commits = r.json()

    if not commits:
        return None

    return (
        commits[0]["commit"]["author"]["date"],
        commits[0]["sha"],
    )


def github_to_raw(url):
    if "github.com" in url and "/blob/" in url:
        url = url.replace("github.com", "raw.githubusercontent.com")
        url = url.replace("/blob/", "/")
    return url


def download_source(url):
    response = requests.get(github_to_raw(url), timeout=30)
    response.raise_for_status()
    return response.text


def extract_brace_block(text, start_brace):
    depth = 0

    for i in range(start_brace, len(text)):
        if text[i] == "{":
            depth += 1
        elif text[i] == "}":
            depth -= 1

            if depth == 0:
                return text[start_brace : i + 1]

    return None


def find_public_properties(source):
    properties = []

    for match in PROPERTY_HEADER.finditer(source):
        body_start = source.find("{", match.start())

        body = extract_brace_block(source, body_start)
        if not body:
            continue

        if re.search(r"\bget\b", body) and re.search(r"\bset\b", body):
            properties.append(
                {
                    "type": match.group("type").replace("?", ""),
                    "name": match.group("name"),
                }
            )

    return properties


existings = {}


def get_existing():
    with open("existing.tsv", newline="", encoding="utf-8") as existing:
        reader = csv.reader(existing, delimiter="\t")

        for row in reader:
            if len(row) < 4:
                continue

            class_type = row[0].strip()
            prop_name = row[2].strip()
            disabled = row[3].strip()

            existings[(class_type, prop_name)] = disabled


orders = {}
results = []


def process_tsv(input_tsv, output_tsv):
    get_existing()
    get_url_data()
    with open(input_tsv, newline="", encoding="utf-8") as infile:
        rows = list(csv.reader(infile, delimiter="\t"))

    orders = {}
    results = []

    for row in rows:
        if len(row) < 4:
            continue

        class_type = row[0].strip()
        urls = [url.strip() for url in row[3].split(";") if url.strip()]

        for url in urls:
            try:
                print(f"Processing {class_type}")

                last_data = get_github_last_modified(url)

                if last_data is None:
                    print(f"ERROR getting last_data for {url}")
                    continue

                date, sha = last_data
                cache_key = (class_type, url)

                cached = url_cache.get(cache_key)

                if cached and cached[1] == sha:
                    print(f"Skipping {class_type}, unchanged")
                    continue

                url_cache[cache_key] = (date, sha)
                save_url_data()

                source = download_source(url)

                for prop in find_public_properties(source):
                    key = (class_type, prop["name"])
                    disabled = existings.get(key, "")

                    orders[class_type] = orders.get(class_type, 0) + 1

                    results.append(
                        [
                            class_type,
                            prop["type"],
                            prop["name"],
                            disabled,
                            orders[class_type],
                        ]
                    )

            except Exception as ex:
                print(f"ERROR {class_type}: {ex}")
        results.sort(key=lambda x: (x[0], x[2]))

        with open(output_tsv, "w", newline="", encoding="utf-8") as outfile:
            writer = csv.writer(outfile, delimiter="\t")
            writer.writerows(results)


if __name__ == "__main__":
    process_tsv("input.tsv", "properties.tsv")
