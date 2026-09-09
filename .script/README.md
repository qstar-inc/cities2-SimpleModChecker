

# gitprocessor.py
## Inputs
- input.tsv (copy from sheet) -> ClassType	Backupable	Reason	URL
- existing.tsv (copy from sheet) -> Class	Type	Prop	Disabled
- url_data.tsv (copy from sheet) -> ClassType	URL	Date	Sha

## Outputs
- error.log (check for errors)
- properties.tsv (copy to sheet and to existing.tsv)
- url_data.tsv (copy to sheet)

# props_to_cs.py
## Inputs
- props_to-import.tsv (copy from sheet) -> Class	Type	Prop	Disabled	Order

## Outputs
- out_ModSettings.txt
- out_ModSettingsClasses.txt


# Steps
1. Refresh sheet external data
2. Copy new IDs to "Data" sheet and fill up by checking repo
3. run gitprocessor.py with input and process outputs
4. run props_to_cs.py with input and process outputs
5. Copy 4 columns from SMC to places