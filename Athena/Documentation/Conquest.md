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
`eventFlag_forStock` stores a quantity counter rather than a single Boolean value. Each shop entry therefore uses a non-overlapping flag base spaced by 10.

Stock flag bases: 1058500100 - 1058500410

ID,Name,Cost,Type,ParamType,EquipType,EventFlagID,SellQuantity
1000,Crimson Amber Medallion,2500,Talisman,Accessory,2,1058500100,1
1010,Cerulean Amber Medallion,2500,Talisman,Accessory,2,1058500110,1
1020,Viridian Amber Medallion,2500,Talisman,Accessory,2,1058500120,1
1030,Arsenal Charm,2500,Talisman,Accessory,2,1058500130,1
1190,Prince of Death's Pustule,2500,Talisman,Accessory,2,1058500140,1
4010,Spelldrake Talisman,2500,Talisman,Accessory,2,1058500150,1
4020,Flamedrake Talisman,2500,Talisman,Accessory,2,1058500160,1
4030,Boltdrake Talisman,2500,Talisman,Accessory,2,1058500170,1
4040,Haligdrake Talisman,2500,Talisman,Accessory,2,1058500180,1
4050,Pearldrake Talisman,2500,Talisman,Accessory,2,1058500190,1
5030,Taker's Cameo,2500,Talisman,Accessory,2,1058500200,1
8030,Shattered Stone Talisman,2500,Talisman,Accessory,2,1058500210,1
8200,Talisman of Lord's Bestowal,2500,Talisman,Accessory,2,1058500220,1
1200,Mottled Necklace,5000,Talisman,Accessory,2,1058500230,1
8050,Crusade Insignia,5000,Talisman,Accessory,2,1058500240,1
8100,Dried Bouquet,5000,Talisman,Accessory,2,1058500250,1
2011000,Viridian Hidden Tear,5000,Consumable,Good,3,1058500260,1
2011020,Crimson-Sapping Cracked Tear,5000,Consumable,Good,3,1058500270,1
2011030,Cerulean-Sapping Cracked Tear,5000,Consumable,Good,3,1058500280,1
8120,Ailment Talisman,5000,Talisman,Accessory,2,1058500290,1
1070,Prosthesis-Wearer Heirloom,5000,Talisman,Accessory,2,1058500300,1
1060,Starscourge Heirloom,5000,Talisman,Accessory,2,1058500310,1
1080,Stargazer Heirloom,5000,Talisman,Accessory,2,1058500320,1
1090,Two Fingers Heirloom,5000,Talisman,Accessory,2,1058500330,1
8020,Outer God Heirloom,5000,Talisman,Accessory,2,1058500340,1
5000,Crimson Seed Talisman,10000,Talisman,Accessory,2,1058500350,1
4000,Dragoncrest Shield Talisman,10000,Talisman,Accessory,2,1058500360,1
4001,Dragoncrest Shield Talisman +1,15000,Talisman,Accessory,2,1058500370,1
8140,Lacerating Crossed-Tree,10000,Talisman,Accessory,2,1058500380,1
8220,Rellana's Cameo,10000,Talisman,Accessory,2,1058500390,1
8110,Smithing Talisman,10000,Talisman,Accessory,2,1058500400,1
2011040,Oil-Soaked Tear,10000,Consumable,Good,3,1058500410,1
