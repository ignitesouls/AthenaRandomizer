# -*- coding: utf-8 -*-
def t469006100_1():
    """State 0,1"""
    t469006100_x2()
    Quit()

def t469006100_x0():
    """State 0"""
    while True:
        """State 2"""
        # actionbutton:6300:"Talk"
        assert (t469006100_x14(actionbutton1=6300, flag1=6001, flag2=6000, flag3=6000, flag4=6000, flag5=6000,
                flag6=6000))
        """State 3"""
        def WhilePaused():
            GiveSpEffectToPlayer(9640)
        assert t469006100_x3() or GetDistanceToPlayer() > 3
        """State 1"""
        assert t469006100_x15()
    """Unused"""
    """State 4"""
    return 0

def t469006100_x1():
    """State 0"""
    Quit()
    """Unused"""
    """State 1"""
    return 0

def t469006100_x2():
    """State 0"""
    if not IsClientPlayer():
        """State 1"""
        Label('L0')
        call = t469006100_x0()
        assert IsClientPlayer()
    else:
        pass
    """State 2"""
    call = t469006100_x1()
    assert not IsClientPlayer()
    Goto('L0')
    """Unused"""
    """State 3"""
    return 0

def t469006100_x3():
    """State 0,8"""
    ClearPreviousMenuSelection()
    while True:
        """State 1"""
        ClearTalkListData()
        """State 2"""
        # action:26000010:"Purchase"
        AddTalkListData(1, 26000010, -1)
        # action:22240000:"Strengthen armaments"
        AddTalkListData(2, 22240000, -1)
        # action:22130003:"Ashes of War"
        AddTalkListData(3, 22130003, -1)
        AddTalkListData(4, 30000000, -1)
        # action:20000011:"Sell"
        AddTalkListData(5, 20000011, -1)
        # action:20000009:"Leave"
        AddTalkListData(99, 20000009, -1)
        ShowShopMessage(1)
        assert not (CheckSpecificPersonMenuIsOpen(1, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
        """State 3"""
        if GetTalkListEntryResult() == 1:
            """State 4"""
            OpenRegularShop(9001100, 9002100)
            assert not (CheckSpecificPersonMenuIsOpen(5, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
        elif GetTalkListEntryResult() == 2:
            """State 5"""
            CombineMenuFlagAndEventFlag(6001, 232)
            CombineMenuFlagAndEventFlag(6001, 233)
            CombineMenuFlagAndEventFlag(6001, 234)
            CombineMenuFlagAndEventFlag(6001, 235)
            RecordPlayLog(9)
            OpenEnhanceShop(0)
            assert not (CheckSpecificPersonMenuIsOpen(9, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
        elif GetTalkListEntryResult() == 3:
            """State 6"""
            OpenEquipmentChangeOfPurposeShop()
            RecordPlayLog(7)
            assert not (CheckSpecificPersonMenuIsOpen(7, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
        elif GetTalkListEntryResult() == 4:
            """State 7"""
            OpenPuppetShop(101864, 101864)
            assert not (CheckSpecificPersonMenuIsOpen(28, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
        elif GetTalkListEntryResult() == 5:
            """State 9"""
            OpenSellShop(-1, -1)
            assert not (CheckSpecificPersonMenuIsOpen(6, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
        else:
            """State 10"""
            return 0

def t469006100_x4():
    """State 0,1"""
    ClearTalkListData()
    """State 7"""
    call = t469006100_x6()
    if call.Get() == 0:
        """State 2"""
        # action:26000001:"Cancel"
        AddTalkListDataAlt(99, 26000001, -1, 99999999, False)
        """State 3"""
        ShowShopMessageAlt(0, True)
        assert not (CheckSpecificPersonMenuIsOpen(1, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
        """State 4"""
        if GetTalkListEntryResult() == 0 or GetTalkListEntryResult() == 99:
            """State 5"""
            pass
        elif (GetTalkListEntryResult() == 60 or GetTalkListEntryResult() == 61 or GetTalkListEntryResult() == 62
              or GetTalkListEntryResult() == 63 or GetTalkListEntryResult() == 64 or GetTalkListEntryResult() ==
              65 or GetTalkListEntryResult() == 66 or GetTalkListEntryResult() == 67 or GetTalkListEntryResult()
              == 68 or GetTalkListEntryResult() == 69):
            """State 9"""
            assert (t469006100_x12(val1=2008900, z1=6000, z2=6000, z3=6000, z4=6000, z5=26002210 + GetTalkListEntryResult()
                    - 60))
        else:
            """State 6"""
            assert t469006100_x5(val2=8910, z6=6000, z7=6000, z8=6000, z9=6000, z10=26001109 + GetTalkListEntryResult())
    elif call.Done():
        """State 8"""
        # action:26001001:"No bell bearing to offer"
        assert t469006100_x16(action1=26001001)
    """State 10"""
    return 0

def t469006100_x5(val2=8910, z6=6000, z7=6000, z8=6000, z9=6000, z10=_):
    """State 0,2"""
    PlayerEquipmentQuantityChange(3, val2 + GetTalkListEntryResult() - 1, -1)
    """State 3"""
    SetEventFlag(11109709 + GetTalkListEntryResult(), 1)
    """State 1,4"""
    assert t469006100_x16(action1=z10)
    """State 5"""
    return 0

def t469006100_x6():
    """State 0,2"""
    SetWorkValue(0, 0)
    SetWorkValue(1, 0)
    while True:
        """State 1"""
        AddTalkListDataAltIf(ComparePlayerInventoryNumber(3, 8910 + GetWorkValue(0), 4, 1, False) == 1 and GetEventFlag(11109710 + GetWorkValue(0)) == 0,
                             1 + GetWorkValue(0), 26000110 + GetWorkValue(0), -1, GetEquipmentSortID(3, 8910 + GetWorkValue(0)),
                             False)
        SetWorkValueIf(ComparePlayerInventoryNumber(3, 8910 + GetWorkValue(0), 4, 1, False) == 1 and GetEventFlag(11109710 + GetWorkValue(0)) == 0,
                       1, GetWorkValue(1) + 1)
        def ExitPause():
            SetWorkValue(0, GetWorkValue(0) + 1)
        if GetWorkValue(0) > 55:
            break
        else:
            pass
    """State 3"""
    if GetWorkValue(1) > 1:
        """State 4"""
        SetWorkValue(0, 0)
        SetWorkValue(1, 0)
        """State 6"""
        while True:
            """State 7"""
            AddTalkListDataAltIf(ComparePlayerInventoryNumber(3, 2008900 + GetWorkValue(0), 4, 1, False) == 1 and GetEventFlag(11109790 + GetWorkValue(0)) == 0,
                                 60 + GetWorkValue(0), 26002110 + GetWorkValue(0), -1, GetEquipmentSortID(3, 2008900 + GetWorkValue(0)),
                                 False)
            SetWorkValueIf(ComparePlayerInventoryNumber(3, 2008900 + GetWorkValue(0), 4, 1, False) == 1 and GetEventFlag(11109790 + GetWorkValue(0)) == 0,
                           1, GetWorkValue(1) + 1)
            def ExitPause():
                SetWorkValue(0, GetWorkValue(0) + 1)
            if GetWorkValue(0) > 10:
                break
            else:
                pass
    else:
        """State 5"""
        SetWorkValue(0, 0)
        SetWorkValue(1, 0)
        """State 8"""
        while True:
            """State 9"""
            AddTalkListDataAltIf(ComparePlayerInventoryNumber(3, 2008900 + GetWorkValue(0), 4, 1, False) == 1 and GetEventFlag(11109790 + GetWorkValue(0)) == 0,
                                 60 + GetWorkValue(0), 26002110 + GetWorkValue(0), -1, GetEquipmentSortID(3, 2008900 + GetWorkValue(0)),
                                 False)
            SetWorkValueIf(ComparePlayerInventoryNumber(3, 2008900 + GetWorkValue(0), 4, 1, False) == 1 and GetEventFlag(11109790 + GetWorkValue(0)) == 0,
                           1, GetWorkValue(1) + 1)
            def ExitPause():
                SetWorkValue(0, GetWorkValue(0) + 1)
            if GetWorkValue(0) > 10:
                break
            else:
                pass
        """State 10"""
        if GetWorkValue(1) > 1:
            """State 11"""
            SetWorkValue(0, 0)
            SetWorkValue(1, 0)
        else:
            """State 12"""
            SetWorkValue(0, 0)
            SetWorkValue(1, 0)
            """State 14"""
            return 1
    """State 13"""
    return 0

def t469006100_x7():
    """State 0,5"""
    ClearPreviousMenuSelection()
    while True:
        """State 1"""
        ClearTalkListData()
        """State 2"""
        # action:26000020:"Sellen's Bell Bearing"
        AddTalkListDataIf(GetEventFlag(11109713) == 1, 1, 26000020, -1)
        # action:26000022:"Seluvis's Bell Bearing"
        AddTalkListDataIf(GetEventFlag(11109711) == 1, 3, 26000022, -1)
        # action:26000023:"Thops's Bell Bearing"
        AddTalkListDataIf(GetEventFlag(11109719) == 1, 4, 26000023, -1)
        # action:26000024:"Corhyn's Bell Bearing"
        AddTalkListDataIf(GetEventFlag(11109743) == 1, 5, 26000024, -1)
        # action:26000025:"Miriel's Bell Bearing (Sorcery)"
        AddTalkListDataIf(GetEventFlag(11109717) == 1, 6, 26000025, -1)
        # action:26000031:"Miriel's Bell Bearing (Incantations)"
        AddTalkListDataIf(GetEventFlag(11109717) == 1, 12, 26000031, -1)
        # action:26000026:"D's Bell Bearing"
        AddTalkListDataIf(GetEventFlag(11109715) == 1, 7, 26000026, -1)
        # action:26000027:"Gowry's Bell Bearing (Sorcery)"
        AddTalkListDataIf(GetEventFlag(11109744) == 1, 8, 26000027, -1)
        # action:26000032:"Gowry's Bell Bearing (Incantations)"
        AddTalkListDataIf(GetEventFlag(11109744) == 1 and GetEventFlag(1038519257) == 1, 13, 26000032, -1)
        # action:26000028:"Rogier's Bell Bearing"
        AddTalkListDataIf(GetEventFlag(11109741) == 1, 9, 26000028, -1)
        # action:26000029:"Bernahl's Bell Bearing"
        AddTalkListDataIf(GetEventFlag(11109716) == 1, 10, 26000029, -1)
        # action:26000030:"Iji's Bell Bearing"
        AddTalkListDataIf(GetEventFlag(11109740) == 1, 11, 26000030, -1)
        # action:26000004:"Go back"
        AddTalkListData(99, 26000004, -1)
        """State 3"""
        ShowShopMessage(1)
        assert not (CheckSpecificPersonMenuIsOpen(1, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
        """State 4"""
        if GetTalkListEntryResult() == 1:
            """State 6,11"""
            OpenRegularShop(100050, 100074)
        elif GetTalkListEntryResult() == 3:
            """State 8,13"""
            OpenRegularShop(100275, 100299)
        elif GetTalkListEntryResult() == 4:
            """State 9,14"""
            OpenRegularShop(100250, 100274)
        elif GetTalkListEntryResult() == 5:
            """State 16,17"""
            OpenRegularShop(100350, 100399)
        elif GetTalkListEntryResult() == 6:
            """State 18,19"""
            OpenRegularShop(100400, 100424)
        elif GetTalkListEntryResult() == 12:
            """State 30,31"""
            OpenRegularShop(100425, 100474)
        elif GetTalkListEntryResult() == 7:
            """State 20,21"""
            OpenRegularShop(100125, 100149)
        elif GetTalkListEntryResult() == 8:
            """State 22,23"""
            OpenRegularShop(100175, 100184)
        elif GetTalkListEntryResult() == 13:
            """State 33,32"""
            OpenRegularShop(100185, 100199)
        elif GetTalkListEntryResult() == 9:
            """State 24,25"""
            OpenRegularShop(100200, 100224)
        elif GetTalkListEntryResult() == 10:
            """State 26,27"""
            OpenRegularShop(100075, 100099)
        elif GetTalkListEntryResult() == 11:
            """State 28,29"""
            OpenRegularShop(100225, 100249)
        else:
            """State 10,34"""
            return 0
        """State 15"""
        Label('L0')
        assert not (CheckSpecificPersonMenuIsOpen(5, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
    """Unused"""
    """State 7,12"""
    OpenRegularShop(100300, 100324)
    Goto('L0')

def t469006100_x8():
    """State 0,5"""
    ClearPreviousMenuSelection()
    while True:
        """State 1"""
        ClearTalkListData()
        """State 2"""
        # action:26000040:"Gostoc's Bell Bearing"
        AddTalkListDataIf(GetEventFlag(11109718) == 1, 1, 26000040, -1)
        # action:26000041:"Pidia's Bell Bearing"
        AddTalkListDataIf(GetEventFlag(11109710) == 1, 2, 26000041, -1)
        # action:26000042:"Patches' Bell Bearing"
        AddTalkListDataIf(GetEventFlag(11109712) == 1, 3, 26000042, -1)
        # action:26000043:"Blackguard's Bell Bearing"
        AddTalkListDataIf(GetEventFlag(11109742) == 1, 4, 26000043, -1)
        # action:26000004:"Go back"
        AddTalkListData(99, 26000004, -1)
        """State 3"""
        ShowShopMessage(1)
        assert not (CheckSpecificPersonMenuIsOpen(1, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
        """State 4"""
        if GetTalkListEntryResult() == 1:
            """State 6,11"""
            OpenRegularShop(100000, 100024)
        elif GetTalkListEntryResult() == 2:
            """State 7,12"""
            OpenRegularShop(100325, 100349)
        elif GetTalkListEntryResult() == 3:
            """State 8,13"""
            OpenRegularShop(100100, 100124)
        elif GetTalkListEntryResult() == 4:
            """State 9,14"""
            OpenRegularShop(100150, 100174)
        else:
            """State 10,16"""
            return 0
        """State 15"""
        assert not (CheckSpecificPersonMenuIsOpen(5, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))

def t469006100_x9():
    """State 0,5"""
    ClearPreviousMenuSelection()
    while True:
        """State 1"""
        ClearTalkListData()
        """State 2"""
        # action:26000050:"Nomadic Merchant's Bell Bearing [1]"
        AddTalkListDataAltIf(GetEventFlag(11109721) == 1, 1, 26000050, -1, GetEquipmentSortID(3, 8921), False)
        # action:26000051:"Nomadic Merchant's Bell Bearing [2]"
        AddTalkListDataAltIf(GetEventFlag(11109722) == 1, 2, 26000051, -1, GetEquipmentSortID(3, 8922), False)
        # action:26000052:"Nomadic Merchant's Bell Bearing [3]"
        AddTalkListDataAltIf(GetEventFlag(11109723) == 1, 3, 26000052, -1, GetEquipmentSortID(3, 8923), False)
        # action:26000053:"Nomadic Merchant's Bell Bearing [4]"
        AddTalkListDataAltIf(GetEventFlag(11109724) == 1, 4, 26000053, -1, GetEquipmentSortID(3, 8924), False)
        # action:26000054:"Nomadic Merchant's Bell Bearing [5]"
        AddTalkListDataAltIf(GetEventFlag(11109725) == 1, 5, 26000054, -1, GetEquipmentSortID(3, 8925), False)
        # action:26000055:"Nomadic Merchant's Bell Bearing [6]"
        AddTalkListDataAltIf(GetEventFlag(11109728) == 1, 6, 26000055, -1, GetEquipmentSortID(3, 8928), False)
        # action:26000056:"Nomadic Merchant's Bell Bearing [7]"
        AddTalkListDataAltIf(GetEventFlag(11109730) == 1, 7, 26000056, -1, GetEquipmentSortID(3, 8930), False)
        # action:26000057:"Nomadic Merchant's Bell Bearing [8]"
        AddTalkListDataAltIf(GetEventFlag(11109731) == 1, 8, 26000057, -1, GetEquipmentSortID(3, 8931), False)
        # action:26000058:"Nomadic Merchant's Bell Bearing [9]"
        AddTalkListDataAltIf(GetEventFlag(11109732) == 1, 9, 26000058, -1, GetEquipmentSortID(3, 8932), False)
        # action:26000059:"Nomadic Merchant's Bell Bearing [10]"
        AddTalkListDataAltIf(GetEventFlag(11109733) == 1, 10, 26000059, -1, GetEquipmentSortID(3, 8933), False)
        # action:26000060:"Nomadic Merchant's Bell Bearing [11]"
        AddTalkListDataAltIf(GetEventFlag(11109734) == 1, 11, 26000060, -1, GetEquipmentSortID(3, 8934), False)
        # action:26000004:"Go back"
        AddTalkListDataAlt(99, 26000004, -1, 9999999, False)
        """State 3"""
        ShowShopMessageAlt(1, True)
        assert not (CheckSpecificPersonMenuIsOpen(1, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
        """State 4"""
        if GetTalkListEntryResult() == 1:
            """State 6,11"""
            OpenRegularShop(100525, 100549)
        elif GetTalkListEntryResult() == 2:
            """State 7,12"""
            OpenRegularShop(100550, 100574)
        elif GetTalkListEntryResult() == 3:
            """State 8,13"""
            OpenRegularShop(100575, 100599)
        elif GetTalkListEntryResult() == 4:
            """State 9,14"""
            OpenRegularShop(100600, 100624)
        elif GetTalkListEntryResult() == 5:
            """State 16,17"""
            OpenRegularShop(100625, 100649)
        elif GetTalkListEntryResult() == 6:
            """State 18,19"""
            OpenRegularShop(100700, 100724)
        elif GetTalkListEntryResult() == 7:
            """State 20,21"""
            OpenRegularShop(100750, 100774)
        elif GetTalkListEntryResult() == 8:
            """State 22,23"""
            OpenRegularShop(100775, 100799)
        elif GetTalkListEntryResult() == 9:
            """State 24,25"""
            OpenRegularShop(100800, 100824)
        elif GetTalkListEntryResult() == 10:
            """State 26,27"""
            OpenRegularShop(100825, 100849)
        elif GetTalkListEntryResult() == 11:
            """State 28,29"""
            OpenRegularShop(100850, 100874)
        else:
            """State 10,30"""
            return 0
        """State 15"""
        assert not (CheckSpecificPersonMenuIsOpen(5, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))

def t469006100_x10():
    """State 0,5"""
    ClearPreviousMenuSelection()
    while True:
        """State 1"""
        ClearTalkListData()
        """State 2"""
        # action:26000070:"Kalé's Bell Bearing"
        AddTalkListDataAltIf(GetEventFlag(11109720) == 1, 1, 26000070, -1, GetEquipmentSortID(3, 8920), False)
        # action:26000071:"Isolated Merchant's Bell Bearing [1]"
        AddTalkListDataAltIf(GetEventFlag(11109726) == 1, 2, 26000071, -1, GetEquipmentSortID(3, 8926), False)
        # action:26000072:"Isolated Merchant's Bell Bearing [2]"
        AddTalkListDataAltIf(GetEventFlag(11109727) == 1, 3, 26000072, -1, GetEquipmentSortID(3, 8927), False)
        # action:26000073:"Hermit Merchant's Bell Bearing [1]"
        AddTalkListDataAltIf(GetEventFlag(11109729) == 1, 4, 26000073, -1, GetEquipmentSortID(3, 8929), False)
        # action:26000074:"Isolated Merchant's Bell Bearing [3]"
        AddTalkListDataAltIf(GetEventFlag(11109735) == 1, 5, 26000074, -1, GetEquipmentSortID(3, 8935), False)
        # action:26000075:"Hermit Merchant's Bell Bearing [2]"
        AddTalkListDataAltIf(GetEventFlag(11109736) == 1, 6, 26000075, -1, GetEquipmentSortID(3, 8936), False)
        # action:26000076:"Abandoned Merchant's Bell Bearing"
        AddTalkListDataAltIf(GetEventFlag(11109737) == 1, 7, 26000076, -1, GetEquipmentSortID(3, 8937), False)
        # action:26000077:"Hermit Merchant's Bell Bearing [3]"
        AddTalkListDataAltIf(GetEventFlag(11109738) == 1, 8, 26000077, -1, GetEquipmentSortID(3, 8938), False)
        # action:26000078:"Imprisoned Merchant's Bell Bearing"
        AddTalkListDataAltIf(GetEventFlag(11109739) == 1, 9, 26000078, -1, GetEquipmentSortID(3, 8939), False)
        # action:26000004:"Go back"
        AddTalkListDataAlt(99, 26000004, -1, 9999999, False)
        """State 3"""
        ShowShopMessageAlt(1, True)
        assert not (CheckSpecificPersonMenuIsOpen(1, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
        """State 4"""
        if GetTalkListEntryResult() == 1:
            """State 6,11"""
            OpenRegularShop(100500, 100524)
        elif GetTalkListEntryResult() == 2:
            """State 7,12"""
            OpenRegularShop(100650, 100674)
        elif GetTalkListEntryResult() == 3:
            """State 8,13"""
            OpenRegularShop(100675, 100699)
        elif GetTalkListEntryResult() == 4:
            """State 9,14"""
            OpenRegularShop(100725, 100749)
        elif GetTalkListEntryResult() == 5:
            """State 16,17"""
            OpenRegularShop(100875, 100899)
        elif GetTalkListEntryResult() == 6:
            """State 18,19"""
            OpenRegularShop(100900, 100924)
        elif GetTalkListEntryResult() == 7:
            """State 20,21"""
            OpenRegularShop(100925, 100949)
        elif GetTalkListEntryResult() == 8:
            """State 22,23"""
            OpenRegularShop(100950, 100974)
        elif GetTalkListEntryResult() == 9:
            """State 24,25"""
            OpenRegularShop(100975, 100999)
        else:
            """State 10,26"""
            return 0
        """State 15"""
        assert not (CheckSpecificPersonMenuIsOpen(5, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))

def t469006100_x11():
    """State 0"""
    if (GetEventFlag(11109721) or GetEventFlag(11109722) or GetEventFlag(11109723) or GetEventFlag(11109724) or
        GetEventFlag(11109725) or GetEventFlag(11109728) or GetEventFlag(11109730) or GetEventFlag(11109731) or
        GetEventFlag(11109732) or GetEventFlag(11109733)):
        """State 2,1"""
        Label('L0')
        # action:26000013:"Bell Bearing Shop 3"
        AddTalkListData(4, 26000013, -1)
    elif GetEventFlag(11109734):
        """State 3"""
        Goto('L0')
    else:
        """State 4"""
        pass
    """State 5"""
    return 0

def t469006100_x12(val1=2008900, z1=6000, z2=6000, z3=6000, z4=6000, z5=_):
    """State 0,2"""
    PlayerEquipmentQuantityChange(3, val1 + GetTalkListEntryResult() - 60, -1)
    """State 3"""
    SetEventFlag(11109790 + GetTalkListEntryResult() - 60, 1)
    """State 1,4"""
    assert t469006100_x16(action1=z5)
    """State 5"""
    return 0

def t469006100_x13():
    """State 0,5"""
    ClearPreviousMenuSelection()
    while True:
        """State 1"""
        ClearTalkListData()
        """State 2"""
        # action:26002010:"Moore's Bell Bearing"
        AddTalkListDataIf(GetEventFlag(11109790) == 1, 5, 26002010, -1)
        # action:26002011:"Ymir's Bell Bearing"
        AddTalkListDataIf(GetEventFlag(11109791) == 1, 6, 26002011, -1)
        # action:26000004:"Go back"
        AddTalkListData(99, 26000004, -1)
        """State 3"""
        ShowShopMessage(1)
        assert not (CheckSpecificPersonMenuIsOpen(1, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))
        """State 4"""
        if GetTalkListEntryResult() == 5:
            """State 8,12"""
            if not GetEventFlag(4465):
                """State 13,14"""
                SetEventFlag(2045429330, 1)
                SetEventFlagIf(GetEventFlag(2048439217) == 1, 2045429331, 1)
            else:
                """State 15,16"""
                SetEventFlag(2045429330, 0)
                SetEventFlag(2045429331, 0)
            """State 10"""
            OpenRegularShop(102250, 102289)
        elif GetTalkListEntryResult() == 6:
            """State 9,11"""
            OpenRegularShop(102300, 102310)
        else:
            """State 6,17"""
            return 0
        """State 7"""
        assert not (CheckSpecificPersonMenuIsOpen(5, 0) and not CheckSpecificPersonGenericDialogIsOpen(0))

def t469006100_x14(actionbutton1=6300, flag1=6001, flag2=6000, flag3=6000, flag4=6000, flag5=6000, flag6=6000):
    """State 0"""
    while True:
        """State 1"""
        assert not GetOneLineHelpStatus() and not IsClientPlayer() and not IsPlayerDead() and not IsCharacterDisabled()
        """State 3"""
        assert GetEventFlag(flag1) or GetEventFlag(flag2) or GetEventFlag(flag3) or GetEventFlag(flag4) or GetEventFlag(flag5)
        """State 4"""
        assert not GetEventFlag(flag6)
        """State 2"""
        if (GetEventFlag(flag6) or not (not GetOneLineHelpStatus() and not IsClientPlayer() and not IsPlayerDead()
            and not IsCharacterDisabled()) or (not GetEventFlag(flag1) and not GetEventFlag(flag2) and not GetEventFlag(flag3)
            and not GetEventFlag(flag4) and not GetEventFlag(flag5))):
            pass
        # actionbutton:6300:"Talk"
        elif CheckActionButtonArea(actionbutton1):
            break
    """State 5"""
    return 0

def t469006100_x15():
    """State 0,1"""
    ClearTalkProgressData()
    StopEventAnimWithoutForcingConversationEnd(0)
    ForceCloseGenericDialog()
    ForceCloseMenu()
    ReportConversationEndToHavokBehavior()
    """State 2"""
    return 0

def t469006100_x16(action1=26001001):
    """State 0,1"""
    # action:26001001:"No bell bearing to offer"
    OpenGenericDialog(7, action1, 1, 0, 1)
    assert not CheckSpecificPersonGenericDialogIsOpen(0)
    """State 2"""
    return 0

