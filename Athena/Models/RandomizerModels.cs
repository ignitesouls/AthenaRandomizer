// SPDX-License-Identifier: GPL-3.0-only
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athena.Models;

interface INamedItem
{
    int ID { get; }
    string Name { get; }
}

interface IGameItem: INamedItem
{
    byte EquipType { get; }
    int Category { get; }
}

public record GameItemModel(int ID, string Name, byte EquipType, int Category): IGameItem;

public record CustomWeaponModel(int ID,
                                string Name, 
                                byte EquipType, 
                                int Category, 
                                int BaseWeaponID, 
                                int GemID, 
                                byte ReinforceLevel): IGameItem;

public record ShopItemModel(int ID,
                            string Name,
                            int Cost,
                            string Type,
                            string ParamType,
                            byte EquipType,
                            uint? EventFlagID,
                            short SellQuantity): INamedItem;

public record ShopItem(string Name,
                       string Type,
                       int Cost,
                       string ParamType,
                       byte EquipType,
                       int ID,
                       uint? EventFlagID,
                       short SellQuantity);

public record WeaponGroup(string WeaponClass,
                          string Name,
                          bool IsRemembrance,
                          bool IsSomber,
                          int WeaponID);

public record WeaponGroupMN(string WeaponClass,
                            string Name,
                            bool IsRemembrance,
                            bool IsSomber,
                            bool IsCustomWeapon,
                            int WeaponID);

public record ArmorSet(string Name,
                       int? HelmID,
                       int? TorsoID,
                       int? GauntletsID,
                       int? GreavesID);

public record Weapon(string Name, int WeaponID);

public record CustomWeapon(string Name, int WeaponID, int GemID, byte ReinforceLevel);
