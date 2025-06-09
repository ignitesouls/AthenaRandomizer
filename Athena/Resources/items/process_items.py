import json

def jsonify_files(files_to_jsonify, outfile):
  rows = []
  for ftj in files_to_jsonify:
    with open(ftj, 'r') as f:
      rows += f.readlines()
  for i, row in enumerate(rows):
    rows[i] = row.strip()
    for j in range(len(row)):
      if row[j] == ':':
        rows[i] = [int(row[:j]), row[j+1:].strip()]
        break

    # rows[i][0] = int(rows[i][0])
  with open(outfile, 'w+') as f:
    json.dump(rows, f, indent=2)
  return len(rows)

def main():
  sp = jsonify_files(['sorceries.txt', 'incantations.txt'], 'spells.json')
  wp = jsonify_files(['weapon_ids.txt'], 'weapons.json')
  am = jsonify_files(['ammunition_ids.txt'], 'ammo.json')
  ac = jsonify_files(['talisman_ids.txt'], 'accessories.json')
  pr = jsonify_files(['armor_id.txt'], 'protectors.json')
  wa = jsonify_files(['ashes_of_war_ids.txt'], 'ashes_of_war.json')
  print(f"Total number of rows: {sp + wp + am + ac + pr + wa}")

if __name__ == '__main__':
  main()
