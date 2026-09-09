import csv
from collections import defaultdict

INPUT_FILE = "props_to_import.tsv"
OUTPUT_FILE_1 = "out_ModSettingsClasses.txt"
OUTPUT_FILE_2 = "out_ModSettings.txt"

classes = defaultdict(list)

with open(INPUT_FILE, newline="", encoding="utf-8") as f:
    reader = csv.reader(f, delimiter="\t")
    for row in reader:
        if len(row) < 4:
            continue

        if row[0].strip() == "Class":
            continue

        classes[row[0].strip()].append(
            {
                "type": row[1].strip(),
                "prop": row[2].strip(),
                "disabled": row[3].strip().lower() == "true",
            }
        )


def comment_block(text):
    return "\n".join(
        "//" + line if line.strip() else "//" for line in text.splitlines()
    )


valid_props = [
    "bool",
    "double",
    "float",
    "float2",
    "int",
    "int[]",
    "string",
    "string[]",
    "uint",
    "ushort",
    "DisplayMode",
    "CultureInfo",
]
invalid_props = set()


def prop_converter(prop):
    if prop not in valid_props:
        invalid_props.add(prop)
        return "int"
    return prop


output1 = []
output2 = []

output1.append("using Game.Settings;")
output1.append("using System.Globalization;")
output1.append("")
output1.append("namespace SimpleModCheckerPlus.Systems.ModSettingsClasses")
output1.append("{")

output2.append("using SimpleModCheckerPlus.Systems.ModSettingsClasses;")
output2.append("namespace SimpleModCheckerPlus.Systems")
output2.append("{")
output2.append("public class ModSettings")
output2.append("{")
output2.append("public string ModVersion {get; set; }")
output2.append("public string LastUpdated {get; set; }")

attr = '[System.Diagnostics.CodeAnalysis.SuppressMessage("Style","IDE1006:Naming Styles",Justification = "<Pending>")]'

for class_name, props in classes.items():
    lines = []

    all_disabled = all(p["disabled"] for p in props)

    if any(p["prop"] and p["prop"][0].islower() for p in props):
        if all_disabled:
            lines.append("//" + attr)
        else:
            lines.append(attr)

    class_header = f"public class {class_name} : SettingsBackup"

    if all_disabled:
        lines.append("//" + class_header)
        lines.append("//{")
    else:
        output2.append(f"public {class_name} {class_name} {{get; set; }}")
        lines.append(class_header)
        lines.append("{")

    for p in props:
        if p["type"] == "ProxyBinding":
            continue

        is_disabled = p["disabled"]

        gap = ""
        if all_disabled:
            gap = "    "

        pType = prop_converter(p["type"])

        prop_text = [
            f"{gap}public {pType} {p['prop']}",
            f"{gap}{{",
            f"{gap}    get => ({pType})GetValue(nameof({p['prop']}));",
            f"{gap}    set => SetValue(nameof({p['prop']}), value);",
            f"{gap}}}",
        ]

        if all_disabled or is_disabled:
            lines.extend("//" + line for line in prop_text)
        else:
            lines.extend(prop_text)

    if all_disabled:
        lines.append("//}")
    else:
        lines.append("}")

    class_text = "\n".join(lines)

    output1.append(class_text)
output1.append("}")
output2.append("}")
output2.append("}")
with open(OUTPUT_FILE_1, "w", encoding="utf-8") as f:
    f.write("\n".join(output1))
with open(OUTPUT_FILE_2, "w", encoding="utf-8") as f:
    f.write("\n".join(output2))

print(f"Done")
