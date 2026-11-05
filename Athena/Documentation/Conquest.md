# Conquest list of Modding Changes
WIP

New Event Ids ought to start with this for no problematic ids being broken in game:

1058500000 - Base Event Item Acquisition Flags

1059500000 - Base Event Flag

1059504000 - Quest Completed

# Events

## common.emevd.dcx
1059500000 - 1059500099

# Parameters

## ItemlotParam_map
==***Item Acquisition Flags for Itemlots: 1058500000-1058500099***==
### Created
ID   | Item								| Amount | ItemAcquisitionFlag | Notes
5310 | Sacred Tear (10020)				| 1      | 1058500000          | Given upon reaching Altus
5320 | Sacred Tear (10020)				| 1      | 1058500001          | Given upon defeating a Dragonkin Soldier
5330 | Sacred Tear (10020)				| 1      | 1058500002          | Given upon Restoring a Great Rune
5340 | Carian Inverted Statue (8111)	| 1      | 1058500003          | Given upon Defeating Rennala
5350 | Rold Medallion (8107)			| 1      | 1058500004          | Given upon defeating a Dragonkin Soldier
5360 | Pure Blood Knight's Medal (2160) | 1      | 1058500005          | Given upon touching the Sword Monument at Rose Church if the player has the Lord of Blood's Favor

### Additions
ID     | Item						  | Amount | ItemAcquisitionFlag | Notes                       |
105102 | Lord of Blood's Favor (8155) | 1      | 400510              | Given upon Defeating Magnus |


## NpcParam
- Made every enemy that could have golden eyes no longer be able to

# Shop Talismans
ItemAcquisitionFlag: 1058500100 - 1058500199
ID,Name,Cost,Type,ParamType,EquipType,EventFlagID,SellQuantity
1000,Crimson Amber Medallion,2500,Talisman,Accessory,2,1058500100,1
1010,Cerulean Amber Medallion,2500,Talisman,Accessory,2,1058500101,1
1020,Viridian Amber Medallion,2500,Talisman,Accessory,2,1058500102,1
1030,Arsenal Charm,2500,Talisman,Accessory,2,1058500103,1
1190,Prince of Death's Pustule,2500,Talisman,Accessory,2,1058500104,1
4010,Spelldrake Talisman,2500,Talisman,Accessory,2,1058500105,1
4020,Flamedrake Talisman,2500,Talisman,Accessory,2,1058500106,1
4030,Boltdrake Talisman,2500,Talisman,Accessory,2,1058500107,1
4040,Haligdrake Talisman,2500,Talisman,Accessory,2,1058500108,1
4050,Pearldrake Talisman,2500,Talisman,Accessory,2,1058500109,1
5030,Taker's Cameo,2500,Talisman,Accessory,2,1058500110,1
8030,Shattered Stone Talisman,2500,Talisman,Accessory,2,1058500111,1
8200,Talisman of Lord's Bestowal,2500,Talisman,Accessory,2,1058500112,1
1200,Mottled Necklace,5000,Talisman,Accessory,2,1058500113,1
8050,Crusade Insignia,5000,Talisman,Accessory,2,1058500114,1
8100,Dried Bouquet,5000,Talisman,Accessory,2,1058500115,1
2011000,Viridian Hidden Tear,5000,Consumable,Good,3,1058500116,1
2011020,Crimson-Sapping Cracked Tear,5000,Consumable,Good,3,1058500117,1
2011030,Cerulean-Sapping Cracked Tear,5000,Consumable,Good,3,1058500118,1
8120,Ailment Talisman,5000,Talisman,Accessory,2,1058500119,1
1070,Prosthesis-Wearer Heirloom,5000,Talisman,Accessory,2,1058500120,1
1060,Starscourge Heirloom,5000,Talisman,Accessory,2,1058500121,1
1080,Stargazer Heirloom,5000,Talisman,Accessory,2,1058500122,1
1090,Two Fingers Heirloom,5000,Talisman,Accessory,2,1058500122,1
8020,Outer God Heirloom,5000,Talisman,Accessory,2,1058500123,1
5000,Crimson Seed Talisman,10000,Talisman,Accessory,2,1058500124,1
4000,Dragoncrest Shield Talisman,10000,Talisman,Accessory,2,1058500125,1
8140,Lacerating Crossed-Tree,10000,Talisman,Accessory,2,1058500126,1
8220,Rellana's Cameo,10000,Talisman,Accessory,2,1058500127,1
8110,Smithing Talisman,10000,Talisman,Accessory,2,1058500128,1
8180,Enraged Divine Beast,10000,Talisman,Accessory,2,1058500129,1
2011040,Oil-Soaked Tear,10000,Consumable,Good,3,1058500130,1