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

public record ArmorSetModel(string Name,
                            int? HelmID,
                            int? TorsoID,
                            int? GauntletsID,
                            int? GreavesID);
