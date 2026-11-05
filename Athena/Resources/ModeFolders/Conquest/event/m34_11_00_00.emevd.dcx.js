// ==EMEVD==
// @docs    er-common.emedf.json
// @compress    DCX_KRAK
// @game    Sekiro
// @string    "N:\\GR\\data\\Param\\event\\common_func.emevd\u0000N:\\GR\\data\\Param\\event\\common_macro.emevd\u0000\u0000\u0000\u0000\u0000\u0000"
// @linked    [0,82]
// @version    3.6.3
// ==/EMEVD==

// コンストラクタ -- constructor
$Event(0, Default, function() {
    RegisterBonfire(34110000, 34111950, 0, 0, 0, 5);
    RegisterBonfire(34110001, 34111951, 0, 0, 0, 5);
    RegisterBonfire(34110002, 34111952, 0, 0, 0, 5);
    $InitializeCommonEvent(0, 90005501, 34110510, 34111510, 1, 34111510, 34111511, 34111512, 34110511);
    $InitializeCommonEvent(0, 90005501, 34110515, 34111515, 0, 34111515, 34111516, 34111517, 34110516);
    $InitializeCommonEvent(0, 90005501, 34110520, 34111520, 0, 34111520, 34111521, 34111522, 34110521);
    $InitializeCommonEvent(0, 90005508, 34110525, 34111525, 0, 34111525, 34111526, 34111527, 34110526);
    $InitializeEvent(0, 34112510);
    $InitializeEvent(0, 34112580);
    $InitializeCommonEvent(0, 900005610, 34111680, 100, 800, 0);
    $InitializeCommonEvent(0, 900005610, 34111681, 100, 800, 0);
    $InitializeCommonEvent(0, 90005300, 34110280, 34110280, 34110400, 0, 0);
    $InitializeEvent(0, 34112400);
    $InitializeEvent(0, 34112410);
    $InitializeEvent(0, 34112420);
    $InitializeEvent(0, 34112430);
    $InitializeEvent(0, 34112440, 34112440, 34112450);
    $InitializeEvent(1, 34112440, 34112441, 34112451);
    $InitializeEvent(2, 34112440, 34112442, 34112452);
    $InitializeEvent(3, 34112440, 34112443, 34112453);
    $InitializeEvent(4, 34112440, 34112444, 34112454);
    $InitializeEvent(5, 34112440, 34112445, 34112455);
    $InitializeEvent(6, 34112440, 34112446, 34112456);
    $InitializeEvent(7, 34112440, 34112447, 34112457);
    $InitializeEvent(0, 34112448);
    $InitializeEvent(0, 34112449);
    $InitializeEvent(0, 34112459);
    $InitializeCommonEvent(0, 90005300, 34110710, 34110710, 34110700, 0, 0);
    $InitializeEvent(0, 34112460);
    $InitializeEvent(0, 34112465);
    $InitializeCommonEvent(0, 90005300, 34110711, 34110711, 34110710, 0, 0);
    $InitializeEvent(0, 34112475, 34112485, 34110710, 34112411);
    $InitializeEvent(1, 34112475, 34112486, 34110710, 34112421);
    $InitializeEvent(2, 34112475, 34112487, 34110710, 34112431);
    $InitializeEvent(3, 34112475, 34112488, 34110711, 34112466);
    $InitializeCommonEvent(0, 90005706, 34110700, 930023, 0);
    // New Teleporter to top of Tower
    $InitializeCommonEvent(0, 90005605, 34101600, 34, 11, 0, 0, 34102610, 0, 34110791, 34110792, 34110793, 0, 0, 0, 0);
});

// プリコンストラクタ -- preconstructor
$Event(50, Default, function() {
    $InitializeEvent(0, 34112150);
    $InitializeEvent(0, 34112151);
    SetCharacterBackreadState(34110700, true);
    $InitializeEvent(0, 34112519);
    $InitializeCommonEvent(0, 90005271, 34110200, 0, -1);
    $InitializeCommonEvent(0, 90005271, 34110201, 0, -1);
    $InitializeCommonEvent(0, 90005271, 34110202, 0, -1);
    $InitializeCommonEvent(0, 90005271, 34110205, 0, -1);
    $InitializeCommonEvent(0, 90005271, 34110206, 0, -1);
    $InitializeCommonEvent(0, 90005271, 34110207, 0, -1);
    $InitializeCommonEvent(0, 90005271, 34110210, 0, -1);
    $InitializeCommonEvent(0, 90005271, 34110211, 0, -1);
    $InitializeCommonEvent(0, 90005271, 34110215, 0, -1);
    $InitializeCommonEvent(0, 90005271, 34110216, 0, -1);
    $InitializeCommonEvent(0, 90005271, 34110217, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34110230, 34112230, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34110231, 34112230, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34110232, 34112230, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34110235, 34112235, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34110236, 34112235, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34110237, 34112235, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34110240, 34112465, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34110241, 34112465, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34110245, 34112245, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34110246, 34112245, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34110247, 34112245, 0, -1);
    $InitializeCommonEvent(0, 90005210, 34110400, 30004, 20004, 34112200, 5, 0, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005210, 34110401, 30004, 20004, 34112200, 5, 1, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005210, 34110402, 30004, 20004, 34112400, 15, 0, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005210, 34110403, 30004, 20004, 34112400, 15, 0.5, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005210, 34110405, 30004, 20004, 34112405, 20, 0, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005210, 34110406, 30004, 20004, 34112405, 20, 0.5, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005210, 34110407, 30004, 20004, 34112405, 20, 0, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005210, 34110408, 30004, 20004, 34112405, 20, 2, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005210, 34110409, 30004, 20004, 34112405, 30, 1, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005210, 34110410, 30004, 20004, 34112409, 20, 0, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005200, 34110411, 30004, 20004, 34112410, 0, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005200, 34110412, 30004, 20004, 34112410, 1.5, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005200, 34110413, 30004, 20004, 34112410, 1, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005210, 34110415, 30004, 20004, 34112441, 15, 0, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005210, 34110416, 30004, 20004, 34112441, 15, 0.5, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005210, 34110417, 30004, 20004, 34112441, 15, 0.5, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005210, 34110418, 30004, 20004, 34112442, 20, 0, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005210, 34110419, 30004, 20004, 34112443, 20, 0, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005210, 34110420, 30004, 20004, 34112443, 20, 1, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005200, 34110421, 30004, 20004, 34112445, 0.5, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005200, 34110422, 30004, 20004, 34112445, 0, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005200, 34110423, 30004, 20004, 34112445, 1, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005200, 34110424, 30004, 20004, 34112445, 1, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005200, 34110425, 30004, 20004, 34112445, 2, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005200, 34110450, 30006, 20006, 34112465, 0, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005200, 34110451, 30006, 20006, 34112475, 1.5, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005200, 34110452, 30006, 20006, 34112475, 0, 0, 0, 0, 0);
});

// 搭反転イベント -- Tower reversal event
$Event(34112150, Restart, function() {
    if (!EventFlag(370)) {
        EnableCharacter(34115150);
        EnableCharacterCollision(34115150);
        DisableCharacter(34115160);
        DisableCharacterCollision(34115160);
        EnableAsset(34116150);
        DisableAsset(34116160);
        EnableHit(34114150);
        EnableHit(34114151);
        EnableHit(34114152);
        EnableHit(34114153);
        onlineAct &= PlayerIsInOwnWorld() && ActionButtonInArea(9720, 34111150);
        WaitFor(onlineAct);
        if (!(PlayerIsInOwnWorld() && PlayerHasItem(ItemType.Goods, 8111))) {
            WaitFixedTimeSeconds(0.1);
            if (PlayerIsInOwnWorld()) {
                DisplayGenericDialog(20040, PromptType.OKCANCEL, NumberofOptions.OneButton, 34111150, 3);
            }
            RestartEvent();
        }
L1:
        SetNetworkconnectedEventFlagID(370, ON);
        SetEventFlagID(9021, ON);
        if (PlayerIsInOwnWorld()) {
            PlayCutsceneToPlayer(34110000, CutscenePlayMode.Skippable, 10000);
        } else {
            PlayCutsceneToPlayerAndWarp(34110000, CutscenePlayMode.Skippable, 34112505, 34110000, 10000, 0, false);
        }
        WaitFixedTimeRealFrames(1);
        ReproduceAssetAnimation(34111505, 1);
        RemoveItemFromPlayer(ItemType.Goods, 8111, 1);
        DisableCharacter(34115150);
        DisableCharacterCollision(34115150);
        EnableCharacter(34115160);
        EnableCharacterCollision(34115160);
        DisableAsset(34116150);
        EnableAsset(34116160);
        DisableHit(34114150);
        DisableHit(34114151);
        DisableHit(34114152);
        DisableHit(34114153);
        if (EventFlag(34110510)) {
            DisableObjAct(34111512, 27002);
        }
        if (EventFlag(34110510)) {
            ForceAnimationPlayback(34111610, 10, false, false, false);
        }
        if (EventFlag(34110515)) {
            ForceAnimationPlayback(34111615, 10, false, false, false);
        }
        WaitFixedTimeFrames(1);
        RestartEvent();
    }
L0:
    DisableCharacter(34115150);
    DisableCharacterCollision(34115150);
    EnableCharacter(34115160);
    EnableCharacterCollision(34115160);
    DisableAsset(34116150);
    EnableAsset(34116160);
    DisableHit(34114150);
    DisableHit(34114151);
    DisableHit(34114152);
    DisableHit(34114153);
    onlineAct &= PlayerIsInOwnWorld() && ActionButtonInArea(9721, 34111150);
    WaitFor(onlineAct);
    SetNetworkconnectedEventFlagID(370, OFF);
    EnableAsset(34116150);
    SetEventFlagID(9021, ON);
    if (PlayerIsInOwnWorld()) {
        PlayCutsceneToPlayer(34110001, CutscenePlayMode.Skippable, 10000);
    } else {
        PlayCutsceneToPlayerAndWarp(34110001, CutscenePlayMode.Skippable, 34112505, 34110000, 10000, 0, false);
    }
    WaitFixedTimeRealFrames(1);
    ReproduceAssetAnimation(34111505, 0);
    SetEventFlagID(34112155, ON);
    DirectlyGivePlayerItem(ItemType.Goods, 8111, 34112155, 1);
    EnableCharacter(34115150);
    EnableCharacterCollision(34115150);
    DisableCharacter(34115160);
    DisableCharacterCollision(34115160);
    EnableAsset(34116150);
    DisableAsset(34116160);
    EnableHit(34114150);
    EnableHit(34114151);
    EnableHit(34114152);
    EnableHit(34114153);
    if (EventFlag(34110510)) {
        EnableObjAct(34111512, 27002);
    }
    WaitFixedTimeFrames(1);
    RestartEvent();
});

// 神の塔への移動 -- Move to the Tower of God
$Event(34112151, Default, function() {
    WaitFor(PlayerIsInOwnWorld() && ActionButtonInArea(9730, 34111160));
    SetEventFlagID(9021, ON);
    if (PlayerIsInOwnWorld()) {
        PlayCutsceneToPlayerAndWarp(34110010, CutscenePlayMode.Skippable, 34112160, 34110000, 10000, 0, false);
    } else {
        PlayCutsceneToPlayerAndWarp(34110010, CutscenePlayMode.Skippable, 34112160, 34110000, 10000, 0, false);
    }
    WaitFixedTimeRealFrames(1);
    SetCameraAngle(-0.24, -104.95);
    SetEventFlagID(34110520, ON);
    RestartEvent();
});

// 反転後大EVの初期設定 -- Initial setting of large EV after reversal
$Event(34112152, Restart, function() {
    WaitFor(!EventFlag(34110520));
    ReproduceAssetAnimation(34111520, 10);
});

// エレベータ起動 -- elevator start
$Event(34112510, Default, function() {
    $InitializeEvent(0, 34112900, 34110510, 34111510, 1, 34111510, 34111511, 34113511, 34111512, 34113512, 34112511, 34112512, 34110511, 34112512, 0);
    $InitializeCommonEvent(0, 90005500, 34110515, 34111515, 0, 34111515, 34111516, 34113516, 34111517, 34113517, 34112516, 34112517, 34110516, 34112517, 0);
    $InitializeEvent(0, 34112910, 34110520, 34111520, 0, 34111520, 0, 0, 0, 0, 34112521, 34112522, 34110521, 0, 0);
    $InitializeCommonEvent(0, 90005507, 34110525, 34111525, 0, 34111525, 34111526, 34112528, 34111527, 34112529, 34112526, 34112527, 34110526, 34112527, 0);
});

// エレベーター初期フラグ設定 -- Elevator initial flag setting
$Event(34112519, Default, function() {
    EndIf(ThisEventSlot());
    EndIf(InArea(10000, 34112152));
    SetEventFlagID(34110520, ON);
    SetThisEventSlot(ON);
});

// 梯子登録 -- ladder registration
$Event(34112580, Restart, function() {
    RegisterLadder(34110530, 34110531, 34111530);
    RegisterLadder(34110532, 34110533, 34111532);
});

// 【専用】2フロア移動エレベータ_m34_11 -- [Exclusive] 2-floor moving elevator_m34_11
$Event(34112900, Default, function(eventFlagId, eventFlagId2, value, assetEntityId, assetEntityId2, objactEventFlag, assetEntityId3, objactEventFlag2, areaEntityId, areaEntityId2, eventFlagId3, eventFlagId4, eventFlagId5) {
    if (!(((EventFlag(eventFlagId) && EventFlag(eventFlagId2))
        || (!EventFlag(eventFlagId) && !EventFlag(eventFlagId2)))
        && EventFlag(eventFlagId3))) {
        if (EventFlag(eventFlagId2)) {
            if (PlayerIsInOwnWorld()) {
                if (EventFlag(370)) {
                    DisableObjAct(assetEntityId3, -1);
                } else {
                    EnableObjAct(assetEntityId3, -1);
                }
                DisableObjAct(assetEntityId2, -1);
            }
            obj = ObjActEventFlag(objactEventFlag2);
            flag = !EventFlag(eventFlagId);
            areaFlag &= InArea(10000, areaEntityId);
            if (eventFlagId5 != 0) {
                areaFlag &= EventFlag(eventFlagId5);
            }
            WaitFor((obj || flag || areaFlag) && !EventFlag(370));
            if (PlayerIsInOwnWorld()) {
                DisableObjAct(assetEntityId3, -1);
            }
            if (PlayerIsInOwnWorld()) {
                SetNetworkconnectedEventFlagID(eventFlagId3, ON);
                SetNetworkconnectedEventFlagID(eventFlagId, OFF);
            }
            SetEventFlagID(eventFlagId2, OFF);
            if (!obj.Passed) {
                GotoIf(L1, EventFlag(eventFlagId4));
                GotoIf(S9, value == 10);
                GotoIf(S8, value == 9);
                GotoIf(S7, value == 8);
                GotoIf(S6, value == 7);
                GotoIf(S5, value == 6);
                GotoIf(S4, value == 5);
                GotoIf(S3, value == 4);
                GotoIf(S2, value == 3);
                GotoIf(S1, value == 2);
                GotoIf(S0, value == 1);
                ForceAnimationPlayback(assetEntityId, 21, false, true, true);
                Goto(L2);
S0:
                ForceAnimationPlayback(assetEntityId, 1000021, false, true, true);
                Goto(L2);
S1:
                ForceAnimationPlayback(assetEntityId, 2000021, false, true, true);
                Goto(L2);
S2:
                ForceAnimationPlayback(assetEntityId, 3000021, false, true, true);
                Goto(L2);
S3:
                ForceAnimationPlayback(assetEntityId, 4000021, false, true, true);
                Goto(L2);
S4:
                ForceAnimationPlayback(assetEntityId, 5000021, false, true, true);
                Goto(L2);
S5:
                ForceAnimationPlayback(assetEntityId, 6000021, false, true, true);
                Goto(L2);
S6:
                ForceAnimationPlayback(assetEntityId, 7000021, false, true, true);
                Goto(L2);
S7:
                ForceAnimationPlayback(assetEntityId, 8000021, false, true, true);
                Goto(L2);
S8:
                ForceAnimationPlayback(assetEntityId, 9000021, false, true, true);
                Goto(L2);
S9:
                ForceAnimationPlayback(assetEntityId, 10000021, false, true, true);
            } else {
L1:
                SetNetworkconnectedEventFlagID(eventFlagId4, ON);
                WaitFixedTimeSeconds(2);
                GotoIf(S19, value == 10);
                GotoIf(S18, value == 9);
                GotoIf(S17, value == 8);
                GotoIf(S16, value == 7);
                GotoIf(S15, value == 6);
                GotoIf(S14, value == 5);
                GotoIf(S13, value == 4);
                GotoIf(S12, value == 3);
                GotoIf(S11, value == 2);
                GotoIf(S10, value == 1);
                ForceAnimationPlayback(assetEntityId, 21, false, true, true);
                Goto(L11);
S10:
                ForceAnimationPlayback(assetEntityId, 1000021, false, true, true);
                Goto(L11);
S11:
                ForceAnimationPlayback(assetEntityId, 2000021, false, true, true);
                Goto(L11);
S12:
                ForceAnimationPlayback(assetEntityId, 3000021, false, true, true);
                Goto(L11);
S13:
                ForceAnimationPlayback(assetEntityId, 4000021, false, true, true);
                Goto(L11);
S14:
                ForceAnimationPlayback(assetEntityId, 5000021, false, true, true);
                Goto(L11);
S15:
                ForceAnimationPlayback(assetEntityId, 6000021, false, true, true);
                Goto(L11);
S16:
                ForceAnimationPlayback(assetEntityId, 7000021, false, true, true);
                Goto(L11);
S17:
                ForceAnimationPlayback(assetEntityId, 8000021, false, true, true);
                Goto(L11);
S18:
                ForceAnimationPlayback(assetEntityId, 9000021, false, true, true);
                Goto(L11);
S19:
                ForceAnimationPlayback(assetEntityId, 10000021, false, true, true);
L11:
                ForceAnimationPlayback(assetEntityId3, 3, false, false, true);
                SetNetworkconnectedEventFlagID(eventFlagId4, OFF);
            }
L2:
            WaitFor(
                AssetBackread(assetEntityId)
                    && (!AllPlayersInArea(areaEntityId2) || EventFlag(eventFlagId)));
            if (PlayerIsInOwnWorld()) {
                SetNetworkconnectedEventFlagID(eventFlagId3, OFF);
                GotoIf(S29, value == 10);
                GotoIf(S28, value == 9);
                GotoIf(S27, value == 8);
                GotoIf(S26, value == 7);
                GotoIf(S25, value == 6);
                GotoIf(S24, value == 5);
                GotoIf(S23, value == 4);
                GotoIf(S22, value == 3);
                GotoIf(S21, value == 2);
                GotoIf(S20, value == 1);
                ForceAnimationPlayback(assetEntityId, 110, false, false, true);
                Goto(L12);
S20:
                ForceAnimationPlayback(assetEntityId, 1000110, false, false, true);
                Goto(L12);
S21:
                ForceAnimationPlayback(assetEntityId, 2000110, false, false, true);
                Goto(L12);
S22:
                ForceAnimationPlayback(assetEntityId, 3000110, false, false, true);
                Goto(L12);
S23:
                ForceAnimationPlayback(assetEntityId, 4000110, false, false, true);
                Goto(L12);
S24:
                ForceAnimationPlayback(assetEntityId, 5000110, false, false, true);
                Goto(L12);
S25:
                ForceAnimationPlayback(assetEntityId, 6000110, false, false, true);
                Goto(L12);
S26:
                ForceAnimationPlayback(assetEntityId, 7000110, false, false, true);
                Goto(L12);
S27:
                ForceAnimationPlayback(assetEntityId, 8000110, false, false, true);
                Goto(L12);
S28:
                ForceAnimationPlayback(assetEntityId, 9000110, false, false, true);
                Goto(L12);
S29:
                ForceAnimationPlayback(assetEntityId, 10000110, false, false, true);
            } else {
L3:
                GotoIf(S39, value == 10);
                GotoIf(S38, value == 9);
                GotoIf(S37, value == 8);
                GotoIf(S36, value == 7);
                GotoIf(S35, value == 6);
                GotoIf(S34, value == 5);
                GotoIf(S33, value == 4);
                GotoIf(S32, value == 3);
                GotoIf(S31, value == 2);
                GotoIf(S30, value == 1);
                ForceAnimationPlayback(assetEntityId, 110, false, true, true);
                Goto(L12);
S30:
                ForceAnimationPlayback(assetEntityId, 1000110, false, true, true);
                Goto(L12);
S31:
                ForceAnimationPlayback(assetEntityId, 2000110, false, true, true);
                Goto(L12);
S32:
                ForceAnimationPlayback(assetEntityId, 3000110, false, true, true);
                Goto(L12);
S33:
                ForceAnimationPlayback(assetEntityId, 4000110, false, true, true);
                Goto(L12);
S34:
                ForceAnimationPlayback(assetEntityId, 5000110, false, false, true);
                Goto(L12);
S35:
                ForceAnimationPlayback(assetEntityId, 6000110, false, false, true);
                Goto(L12);
S36:
                ForceAnimationPlayback(assetEntityId, 7000110, false, false, true);
                Goto(L12);
S37:
                ForceAnimationPlayback(assetEntityId, 8000110, false, false, true);
                Goto(L12);
S38:
                ForceAnimationPlayback(assetEntityId, 9000110, false, false, true);
                Goto(L12);
S39:
                ForceAnimationPlayback(assetEntityId, 10000110, false, false, true);
            }
L12:
            RestartEvent();
        }
L0:
        if (PlayerIsInOwnWorld()) {
            EnableObjAct(assetEntityId2, -1);
            DisableObjAct(assetEntityId3, -1);
        }
        obj2 = ObjActEventFlag(objactEventFlag);
        flag2 = EventFlag(eventFlagId);
        areaSpFlag &= InArea(10000, areaEntityId2) && !CharacterHasSpEffect(10000, 4800);
        if (eventFlagId5 != 0) {
            areaSpFlag &= EventFlag(eventFlagId5);
        }
        WaitFor((obj2 || flag2 || areaSpFlag) && !EventFlag(370));
        if (PlayerIsInOwnWorld()) {
            DisableObjAct(assetEntityId2, -1);
        }
        if (PlayerIsInOwnWorld()) {
            SetNetworkconnectedEventFlagID(eventFlagId3, ON);
            SetNetworkconnectedEventFlagID(eventFlagId, ON);
        }
        SetEventFlagID(eventFlagId2, ON);
        if (!obj2.Passed) {
            GotoIf(L4, EventFlag(eventFlagId4));
            GotoIf(S49, value == 10);
            GotoIf(S48, value == 9);
            GotoIf(S47, value == 8);
            GotoIf(S46, value == 7);
            GotoIf(S45, value == 6);
            GotoIf(S44, value == 5);
            GotoIf(S43, value == 4);
            GotoIf(S42, value == 3);
            GotoIf(S41, value == 2);
            GotoIf(S40, value == 1);
            ForceAnimationPlayback(assetEntityId, 12, false, true, true);
            Goto(L5);
S40:
            ForceAnimationPlayback(assetEntityId, 1000012, false, true, true);
            Goto(L5);
S41:
            ForceAnimationPlayback(assetEntityId, 2000012, false, true, true);
            Goto(L5);
S42:
            ForceAnimationPlayback(assetEntityId, 3000012, false, true, true);
            Goto(L5);
S43:
            ForceAnimationPlayback(assetEntityId, 4000012, false, true, true);
            Goto(L5);
S44:
            ForceAnimationPlayback(assetEntityId, 5000012, false, true, true);
            Goto(L5);
S45:
            ForceAnimationPlayback(assetEntityId, 6000012, false, true, true);
            Goto(L5);
S46:
            ForceAnimationPlayback(assetEntityId, 7000012, false, true, true);
            Goto(L5);
S47:
            ForceAnimationPlayback(assetEntityId, 8000012, false, true, true);
            Goto(L5);
S48:
            ForceAnimationPlayback(assetEntityId, 9000012, false, true, true);
            Goto(L5);
S49:
            ForceAnimationPlayback(assetEntityId, 10000012, false, true, true);
        } else {
L4:
            SetNetworkconnectedEventFlagID(eventFlagId4, ON);
            WaitFixedTimeSeconds(2);
            GotoIf(S59, value == 10);
            GotoIf(S58, value == 9);
            GotoIf(S57, value == 8);
            GotoIf(S56, value == 7);
            GotoIf(S55, value == 6);
            GotoIf(S54, value == 5);
            GotoIf(S53, value == 4);
            GotoIf(S52, value == 3);
            GotoIf(S51, value == 2);
            GotoIf(S50, value == 1);
            ForceAnimationPlayback(assetEntityId, 12, false, true, true);
            Goto(L14);
S50:
            ForceAnimationPlayback(assetEntityId, 1000012, false, true, true);
            Goto(L14);
S51:
            ForceAnimationPlayback(assetEntityId, 2000012, false, true, true);
            Goto(L14);
S52:
            ForceAnimationPlayback(assetEntityId, 3000012, false, true, true);
            Goto(L14);
S53:
            ForceAnimationPlayback(assetEntityId, 4000012, false, true, true);
            Goto(L14);
S54:
            ForceAnimationPlayback(assetEntityId, 5000012, false, true, true);
            Goto(L14);
S55:
            ForceAnimationPlayback(assetEntityId, 6000012, false, true, true);
            Goto(L14);
S56:
            ForceAnimationPlayback(assetEntityId, 7000012, false, true, true);
            Goto(L14);
S57:
            ForceAnimationPlayback(assetEntityId, 8000012, false, true, true);
            Goto(L14);
S58:
            ForceAnimationPlayback(assetEntityId, 9000012, false, true, true);
            Goto(L14);
S59:
            ForceAnimationPlayback(assetEntityId, 10000012, false, true, true);
L14:
            ForceAnimationPlayback(assetEntityId2, 3, false, false, true);
            SetNetworkconnectedEventFlagID(eventFlagId4, OFF);
        }
L5:
        WaitFor(
            AssetBackread(assetEntityId)
                && (!AllPlayersInArea(areaEntityId) || !EventFlag(eventFlagId)));
        if (PlayerIsInOwnWorld()) {
            SetNetworkconnectedEventFlagID(eventFlagId3, OFF);
            GotoIf(S69, value == 10);
            GotoIf(S68, value == 9);
            GotoIf(S67, value == 8);
            GotoIf(S66, value == 7);
            GotoIf(S65, value == 6);
            GotoIf(S64, value == 5);
            GotoIf(S63, value == 4);
            GotoIf(S62, value == 3);
            GotoIf(S61, value == 2);
            GotoIf(S60, value == 1);
            ForceAnimationPlayback(assetEntityId, 120, false, false, true);
            Goto(L15);
S60:
            ForceAnimationPlayback(assetEntityId, 1000120, false, false, true);
            Goto(L15);
S61:
            ForceAnimationPlayback(assetEntityId, 2000120, false, false, true);
            Goto(L15);
S62:
            ForceAnimationPlayback(assetEntityId, 3000120, false, false, true);
            Goto(L15);
S63:
            ForceAnimationPlayback(assetEntityId, 4000120, false, false, true);
            Goto(L15);
S64:
            ForceAnimationPlayback(assetEntityId, 5000120, false, false, true);
            Goto(L15);
S65:
            ForceAnimationPlayback(assetEntityId, 6000120, false, false, true);
            Goto(L15);
S66:
            ForceAnimationPlayback(assetEntityId, 7000120, false, false, true);
            Goto(L15);
S67:
            ForceAnimationPlayback(assetEntityId, 8000120, false, false, true);
            Goto(L15);
S68:
            ForceAnimationPlayback(assetEntityId, 9000120, false, false, true);
            Goto(L15);
S69:
            ForceAnimationPlayback(assetEntityId, 10000120, false, false, true);
        } else {
L6:
            GotoIf(S79, value == 10);
            GotoIf(S78, value == 9);
            GotoIf(S77, value == 8);
            GotoIf(S76, value == 7);
            GotoIf(S75, value == 6);
            GotoIf(S74, value == 5);
            GotoIf(S73, value == 4);
            GotoIf(S72, value == 3);
            GotoIf(S71, value == 2);
            GotoIf(S70, value == 1);
            ForceAnimationPlayback(assetEntityId, 120, false, false, true);
            Goto(L15);
S70:
            ForceAnimationPlayback(assetEntityId, 1000120, false, false, true);
            Goto(L15);
S71:
            ForceAnimationPlayback(assetEntityId, 2000120, false, false, true);
            Goto(L15);
S72:
            ForceAnimationPlayback(assetEntityId, 3000120, false, false, true);
            Goto(L15);
S73:
            ForceAnimationPlayback(assetEntityId, 4000120, false, false, true);
            Goto(L15);
S74:
            ForceAnimationPlayback(assetEntityId, 5000120, false, false, true);
            Goto(L15);
S75:
            ForceAnimationPlayback(assetEntityId, 6000120, false, false, true);
            Goto(L15);
S76:
            ForceAnimationPlayback(assetEntityId, 7000120, false, false, true);
            Goto(L15);
S77:
            ForceAnimationPlayback(assetEntityId, 8000120, false, false, true);
            Goto(L15);
S78:
            ForceAnimationPlayback(assetEntityId, 9000120, false, false, true);
            Goto(L15);
S79:
            ForceAnimationPlayback(assetEntityId, 10000120, false, false, true);
        }
L15:
        RestartEvent();
    }
L9:
    WaitFor(!EventFlag(eventFlagId3));
    RestartEvent();
});

// 【専用】2フロア移動エレベータ_反転後大エレベータ -- [Exclusive] 2-floor moving elevator_Large elevator after reversal
$Event(34112910, Default, function(eventFlagId, eventFlagId2, value, assetEntityId, assetEntityId2, objactEventFlag, assetEntityId3, objactEventFlag2, areaEntityId, areaEntityId2, eventFlagId3, eventFlagId4, eventFlagId5) {
    EndIf(InArea(10000, 34112152));
    if (!(((EventFlag(eventFlagId) && EventFlag(eventFlagId2))
        || (!EventFlag(eventFlagId) && !EventFlag(eventFlagId2)))
        && EventFlag(eventFlagId3))) {
        if (EventFlag(eventFlagId2)) {
            if (MapHasPermissionToUpdate(false, 0, 0, 0, 0)) {
                EnableObjAct(assetEntityId3, -1);
                DisableObjAct(assetEntityId2, -1);
            }
            obj = ObjActEventFlag(objactEventFlag2);
            flag = !EventFlag(eventFlagId);
            areaFlag &= InArea(10000, areaEntityId);
            if (eventFlagId5 != 0) {
                areaFlag &= EventFlag(eventFlagId5);
            }
            WaitFor(obj || flag || areaFlag);
            if (MapHasPermissionToUpdate(false, 0, 0, 0, 0)) {
                DisableObjAct(assetEntityId3, -1);
            }
            if (MapHasPermissionToUpdate(false, 0, 0, 0, 0)) {
                SetNetworkconnectedEventFlagID(eventFlagId3, ON);
                SetNetworkconnectedEventFlagID(eventFlagId, OFF);
            }
            SetEventFlagID(eventFlagId2, OFF);
            if (!obj.Passed) {
                GotoIf(L1, EventFlag(eventFlagId4));
                GotoIf(S9, value == 10);
                GotoIf(S8, value == 9);
                GotoIf(S7, value == 8);
                GotoIf(S6, value == 7);
                GotoIf(S5, value == 6);
                GotoIf(S4, value == 5);
                GotoIf(S3, value == 4);
                GotoIf(S2, value == 3);
                GotoIf(S1, value == 2);
                GotoIf(S0, value == 1);
                ForceAnimationPlayback(assetEntityId, 21, false, true, true);
                Goto(L2);
S0:
                ForceAnimationPlayback(assetEntityId, 1000021, false, true, true);
                Goto(L2);
S1:
                ForceAnimationPlayback(assetEntityId, 2000021, false, true, true);
                Goto(L2);
S2:
                ForceAnimationPlayback(assetEntityId, 3000021, false, true, true);
                Goto(L2);
S3:
                ForceAnimationPlayback(assetEntityId, 4000021, false, true, true);
                Goto(L2);
S4:
                ForceAnimationPlayback(assetEntityId, 5000021, false, true, true);
                Goto(L2);
S5:
                ForceAnimationPlayback(assetEntityId, 6000021, false, true, true);
                Goto(L2);
S6:
                ForceAnimationPlayback(assetEntityId, 7000021, false, true, true);
                Goto(L2);
S7:
                ForceAnimationPlayback(assetEntityId, 8000021, false, true, true);
                Goto(L2);
S8:
                ForceAnimationPlayback(assetEntityId, 9000021, false, true, true);
                Goto(L2);
S9:
                ForceAnimationPlayback(assetEntityId, 10000021, false, true, true);
            } else {
L1:
                if (MapHasPermissionToUpdate(false, 0, 0, 0, 0)) {
                    SetNetworkconnectedEventFlagID(eventFlagId4, ON);
                }
                WaitFixedTimeSeconds(2);
                GotoIf(S19, value == 10);
                GotoIf(S18, value == 9);
                GotoIf(S17, value == 8);
                GotoIf(S16, value == 7);
                GotoIf(S15, value == 6);
                GotoIf(S14, value == 5);
                GotoIf(S13, value == 4);
                GotoIf(S12, value == 3);
                GotoIf(S11, value == 2);
                GotoIf(S10, value == 1);
                ForceAnimationPlayback(assetEntityId, 21, false, true, true);
                Goto(L11);
S10:
                ForceAnimationPlayback(assetEntityId, 1000021, false, true, true);
                Goto(L11);
S11:
                ForceAnimationPlayback(assetEntityId, 2000021, false, true, true);
                Goto(L11);
S12:
                ForceAnimationPlayback(assetEntityId, 3000021, false, true, true);
                Goto(L11);
S13:
                ForceAnimationPlayback(assetEntityId, 4000021, false, true, true);
                Goto(L11);
S14:
                ForceAnimationPlayback(assetEntityId, 5000021, false, true, true);
                Goto(L11);
S15:
                ForceAnimationPlayback(assetEntityId, 6000021, false, true, true);
                Goto(L11);
S16:
                ForceAnimationPlayback(assetEntityId, 7000021, false, true, true);
                Goto(L11);
S17:
                ForceAnimationPlayback(assetEntityId, 8000021, false, true, true);
                Goto(L11);
S18:
                ForceAnimationPlayback(assetEntityId, 9000021, false, true, true);
                Goto(L11);
S19:
                ForceAnimationPlayback(assetEntityId, 10000021, false, true, true);
L11:
                ForceAnimationPlayback(assetEntityId3, 3, false, false, true);
                if (MapHasPermissionToUpdate(false, 0, 0, 0, 0)) {
                    SetNetworkconnectedEventFlagID(eventFlagId4, OFF);
                }
            }
L2:
            WaitFor(
                AssetBackread(assetEntityId)
                    && (!AllPlayersInArea(areaEntityId2) || EventFlag(eventFlagId)));
            if (MapHasPermissionToUpdate(false, 0, 0, 0, 0)) {
                SetNetworkconnectedEventFlagID(eventFlagId3, OFF);
                GotoIf(S29, value == 10);
                GotoIf(S28, value == 9);
                GotoIf(S27, value == 8);
                GotoIf(S26, value == 7);
                GotoIf(S25, value == 6);
                GotoIf(S24, value == 5);
                GotoIf(S23, value == 4);
                GotoIf(S22, value == 3);
                GotoIf(S21, value == 2);
                GotoIf(S20, value == 1);
                ForceAnimationPlayback(assetEntityId, 110, false, false, true);
                Goto(L12);
S20:
                ForceAnimationPlayback(assetEntityId, 1000110, false, false, true);
                Goto(L12);
S21:
                ForceAnimationPlayback(assetEntityId, 2000110, false, false, true);
                Goto(L12);
S22:
                ForceAnimationPlayback(assetEntityId, 3000110, false, false, true);
                Goto(L12);
S23:
                ForceAnimationPlayback(assetEntityId, 4000110, false, false, true);
                Goto(L12);
S24:
                ForceAnimationPlayback(assetEntityId, 5000110, false, false, true);
                Goto(L12);
S25:
                ForceAnimationPlayback(assetEntityId, 6000110, false, false, true);
                Goto(L12);
S26:
                ForceAnimationPlayback(assetEntityId, 7000110, false, false, true);
                Goto(L12);
S27:
                ForceAnimationPlayback(assetEntityId, 8000110, false, false, true);
                Goto(L12);
S28:
                ForceAnimationPlayback(assetEntityId, 9000110, false, false, true);
                Goto(L12);
S29:
                ForceAnimationPlayback(assetEntityId, 10000110, false, false, true);
            } else {
L3:
                GotoIf(S39, value == 10);
                GotoIf(S38, value == 9);
                GotoIf(S37, value == 8);
                GotoIf(S36, value == 7);
                GotoIf(S35, value == 6);
                GotoIf(S34, value == 5);
                GotoIf(S33, value == 4);
                GotoIf(S32, value == 3);
                GotoIf(S31, value == 2);
                GotoIf(S30, value == 1);
                ForceAnimationPlayback(assetEntityId, 110, false, true, true);
                Goto(L12);
S30:
                ForceAnimationPlayback(assetEntityId, 1000110, false, true, true);
                Goto(L12);
S31:
                ForceAnimationPlayback(assetEntityId, 2000110, false, true, true);
                Goto(L12);
S32:
                ForceAnimationPlayback(assetEntityId, 3000110, false, true, true);
                Goto(L12);
S33:
                ForceAnimationPlayback(assetEntityId, 4000110, false, true, true);
                Goto(L12);
S34:
                ForceAnimationPlayback(assetEntityId, 5000110, false, true, true);
                Goto(L12);
S35:
                ForceAnimationPlayback(assetEntityId, 6000110, false, true, true);
                Goto(L12);
S36:
                ForceAnimationPlayback(assetEntityId, 7000110, false, true, true);
                Goto(L12);
S37:
                ForceAnimationPlayback(assetEntityId, 8000110, false, true, true);
                Goto(L12);
S38:
                ForceAnimationPlayback(assetEntityId, 9000110, false, true, true);
                Goto(L12);
S39:
                ForceAnimationPlayback(assetEntityId, 10000110, false, true, true);
            }
L12:
            SaveRequest();
            RestartEvent();
        }
L0:
        if (MapHasPermissionToUpdate(false, 0, 0, 0, 0)) {
            EnableObjAct(assetEntityId2, -1);
            DisableObjAct(assetEntityId3, -1);
        }
        obj2 = ObjActEventFlag(objactEventFlag);
        flag2 = EventFlag(eventFlagId);
        areaSpFlag &= InArea(10000, areaEntityId2) && !CharacterHasSpEffect(10000, 4800);
        if (eventFlagId5 != 0) {
            areaSpFlag &= EventFlag(eventFlagId5);
        }
        WaitFor(obj2 || flag2 || areaSpFlag);
        if (MapHasPermissionToUpdate(false, 0, 0, 0, 0)) {
            DisableObjAct(assetEntityId2, -1);
        }
        if (MapHasPermissionToUpdate(false, 0, 0, 0, 0)) {
            SetNetworkconnectedEventFlagID(eventFlagId3, ON);
            SetNetworkconnectedEventFlagID(eventFlagId, ON);
        }
        SetEventFlagID(eventFlagId2, ON);
        if (!obj2.Passed) {
            GotoIf(L4, EventFlag(eventFlagId4));
            GotoIf(S49, value == 10);
            GotoIf(S48, value == 9);
            GotoIf(S47, value == 8);
            GotoIf(S46, value == 7);
            GotoIf(S45, value == 6);
            GotoIf(S44, value == 5);
            GotoIf(S43, value == 4);
            GotoIf(S42, value == 3);
            GotoIf(S41, value == 2);
            GotoIf(S40, value == 1);
            ForceAnimationPlayback(assetEntityId, 12, false, true, true);
            Goto(L5);
S40:
            ForceAnimationPlayback(assetEntityId, 1000012, false, true, true);
            Goto(L5);
S41:
            ForceAnimationPlayback(assetEntityId, 2000012, false, true, true);
            Goto(L5);
S42:
            ForceAnimationPlayback(assetEntityId, 3000012, false, true, true);
            Goto(L5);
S43:
            ForceAnimationPlayback(assetEntityId, 4000012, false, true, true);
            Goto(L5);
S44:
            ForceAnimationPlayback(assetEntityId, 5000012, false, true, true);
            Goto(L5);
S45:
            ForceAnimationPlayback(assetEntityId, 6000012, false, true, true);
            Goto(L5);
S46:
            ForceAnimationPlayback(assetEntityId, 7000012, false, true, true);
            Goto(L5);
S47:
            ForceAnimationPlayback(assetEntityId, 8000012, false, true, true);
            Goto(L5);
S48:
            ForceAnimationPlayback(assetEntityId, 9000012, false, true, true);
            Goto(L5);
S49:
            ForceAnimationPlayback(assetEntityId, 10000012, false, true, true);
        } else {
L4:
            if (MapHasPermissionToUpdate(false, 0, 0, 0, 0)) {
                SetNetworkconnectedEventFlagID(eventFlagId4, ON);
            }
            WaitFixedTimeSeconds(2);
            GotoIf(S59, value == 10);
            GotoIf(S58, value == 9);
            GotoIf(S57, value == 8);
            GotoIf(S56, value == 7);
            GotoIf(S55, value == 6);
            GotoIf(S54, value == 5);
            GotoIf(S53, value == 4);
            GotoIf(S52, value == 3);
            GotoIf(S51, value == 2);
            GotoIf(S50, value == 1);
            ForceAnimationPlayback(assetEntityId, 12, false, true, true);
            Goto(L14);
S50:
            ForceAnimationPlayback(assetEntityId, 1000012, false, true, true);
            Goto(L14);
S51:
            ForceAnimationPlayback(assetEntityId, 2000012, false, true, true);
            Goto(L14);
S52:
            ForceAnimationPlayback(assetEntityId, 3000012, false, true, true);
            Goto(L14);
S53:
            ForceAnimationPlayback(assetEntityId, 4000012, false, true, true);
            Goto(L14);
S54:
            ForceAnimationPlayback(assetEntityId, 5000012, false, true, true);
            Goto(L14);
S55:
            ForceAnimationPlayback(assetEntityId, 6000012, false, true, true);
            Goto(L14);
S56:
            ForceAnimationPlayback(assetEntityId, 7000012, false, true, true);
            Goto(L14);
S57:
            ForceAnimationPlayback(assetEntityId, 8000012, false, true, true);
            Goto(L14);
S58:
            ForceAnimationPlayback(assetEntityId, 9000012, false, true, true);
            Goto(L14);
S59:
            ForceAnimationPlayback(assetEntityId, 10000012, false, true, true);
L14:
            ForceAnimationPlayback(assetEntityId2, 3, false, false, true);
            if (MapHasPermissionToUpdate(false, 0, 0, 0, 0)) {
                SetNetworkconnectedEventFlagID(eventFlagId4, OFF);
            }
        }
L5:
        WaitFor(
            AssetBackread(assetEntityId)
                && (!AllPlayersInArea(areaEntityId) || !EventFlag(eventFlagId)));
        if (MapHasPermissionToUpdate(false, 0, 0, 0, 0)) {
            SetNetworkconnectedEventFlagID(eventFlagId3, OFF);
            GotoIf(S69, value == 10);
            GotoIf(S68, value == 9);
            GotoIf(S67, value == 8);
            GotoIf(S66, value == 7);
            GotoIf(S65, value == 6);
            GotoIf(S64, value == 5);
            GotoIf(S63, value == 4);
            GotoIf(S62, value == 3);
            GotoIf(S61, value == 2);
            GotoIf(S60, value == 1);
            ForceAnimationPlayback(assetEntityId, 120, false, false, true);
            Goto(L15);
S60:
            ForceAnimationPlayback(assetEntityId, 1000120, false, false, true);
            Goto(L15);
S61:
            ForceAnimationPlayback(assetEntityId, 2000120, false, false, true);
            Goto(L15);
S62:
            ForceAnimationPlayback(assetEntityId, 3000120, false, false, true);
            Goto(L15);
S63:
            ForceAnimationPlayback(assetEntityId, 4000120, false, false, true);
            Goto(L15);
S64:
            ForceAnimationPlayback(assetEntityId, 5000120, false, false, true);
            Goto(L15);
S65:
            ForceAnimationPlayback(assetEntityId, 6000120, false, false, true);
            Goto(L15);
S66:
            ForceAnimationPlayback(assetEntityId, 7000120, false, false, true);
            Goto(L15);
S67:
            ForceAnimationPlayback(assetEntityId, 8000120, false, false, true);
            Goto(L15);
S68:
            ForceAnimationPlayback(assetEntityId, 9000120, false, false, true);
            Goto(L15);
S69:
            ForceAnimationPlayback(assetEntityId, 10000120, false, false, true);
        } else {
L6:
            GotoIf(S79, value == 10);
            GotoIf(S78, value == 9);
            GotoIf(S77, value == 8);
            GotoIf(S76, value == 7);
            GotoIf(S75, value == 6);
            GotoIf(S74, value == 5);
            GotoIf(S73, value == 4);
            GotoIf(S72, value == 3);
            GotoIf(S71, value == 2);
            GotoIf(S70, value == 1);
            ForceAnimationPlayback(assetEntityId, 120, false, true, true);
            Goto(L15);
S70:
            ForceAnimationPlayback(assetEntityId, 1000120, false, true, true);
            Goto(L15);
S71:
            ForceAnimationPlayback(assetEntityId, 2000120, false, true, true);
            Goto(L15);
S72:
            ForceAnimationPlayback(assetEntityId, 3000120, false, true, true);
            Goto(L15);
S73:
            ForceAnimationPlayback(assetEntityId, 4000120, false, true, true);
            Goto(L15);
S74:
            ForceAnimationPlayback(assetEntityId, 5000120, false, true, true);
            Goto(L15);
S75:
            ForceAnimationPlayback(assetEntityId, 6000120, false, true, true);
            Goto(L15);
S76:
            ForceAnimationPlayback(assetEntityId, 7000120, false, true, true);
            Goto(L15);
S77:
            ForceAnimationPlayback(assetEntityId, 8000120, false, true, true);
            Goto(L15);
S78:
            ForceAnimationPlayback(assetEntityId, 9000120, false, true, true);
            Goto(L15);
S79:
            ForceAnimationPlayback(assetEntityId, 10000120, false, true, true);
        }
L15:
        SaveRequest();
        RestartEvent();
    }
L9:
    WaitFor(!EventFlag(eventFlagId3));
    RestartEvent();
});

// 敵対NPC_反転前_出現 -- Hostile NPC_Before reversal_Appearance
$Event(34112400, Restart, function() {
    EndIf(EventFlag(34110710));
    EndIf(ThisEventSlot());
    DisableCharacter(34110710);
    DisableCharacterCollision(34110710);
    EnableCharacterFadeOnEnable(34110710);
    WaitFor(
        ((CharacterType(10000, TargetType.BlackPhantom) && CharacterHasSpEffect(10000, 3710))
            || CharacterType(10000, TargetType.Alive)
            || CharacterType(10000, TargetType.BluePhantom)
            || CharacterType(10000, TargetType.WhitePhantom))
            && InArea(10000, 34112400));
    WaitFixedTimeSeconds(1);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 150, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 151, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 152, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 153, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 154, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 155, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 156, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 157, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 151, 600921);
    WaitFixedTimeSeconds(0.5);
    EnableCharacter(34110710);
    EnableCharacterCollision(34110710);
    SetNetworkconnectedThisEventSlot(ON);
    EndEvent();
});

// 敵対NPC_反転前_一回目ワープ -- Hostile NPC_Before reversal_First warp
$Event(34112410, Restart, function() {
    EndIf(EventFlag(34110710));
    EndIf(ThisEventSlot());
    EnableCharacterFadeOnEnable(34110710);
    WaitFor(
        ((CharacterType(10000, TargetType.BlackPhantom) && CharacterHasSpEffect(10000, 3710))
            || CharacterType(10000, TargetType.Alive)
            || CharacterType(10000, TargetType.BluePhantom)
            || CharacterType(10000, TargetType.WhitePhantom))
            && HPRatio(34110710) <= 0.8
            && !CharacterHasSpEffect(34110710, 19385)
            && CharacterHPValue(34110710) > 0);
    DisableLockOnPoint(34110710, 220);
    WaitFixedTimeSeconds(1);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 150, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 151, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 152, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 153, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 154, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 155, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 156, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 157, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 151, 600921);
    SetSpEffect(34110710, 4240);
    WaitFixedTimeSeconds(0.5);
    if (CharacterHasSpEffect(34110710, 19385)) {
        EnableLockOnPoint(34110710, 220);
        SetNetworkconnectedEventFlagID(34112485, ON);
        EndEvent();
    }
    WarpCharacterAndCopyFloor(34110710, TargetEntityType.Area, 34112411, -1, 34110710);
    SetCharacterHome(34110710, 34112411);
    EnableLockOnPoint(34110710, 220);
    SetNetworkconnectedThisEventSlot(ON);
    SetSpEffect(34110710, 4241);
    EndEvent();
});

// 敵対NPC_反転前_二回目ワープ -- Hostile NPC_Before reversal_Second warp
$Event(34112420, Restart, function() {
    EndIf(EventFlag(34110710));
    EndIf(ThisEventSlot());
    EnableCharacterFadeOnEnable(34110710);
    WaitFor(
        ((CharacterType(10000, TargetType.BlackPhantom) && CharacterHasSpEffect(10000, 3710))
            || CharacterType(10000, TargetType.Alive)
            || CharacterType(10000, TargetType.BluePhantom)
            || CharacterType(10000, TargetType.WhitePhantom))
            && HPRatio(34110710) <= 0.6
            && !CharacterHasSpEffect(34110710, 19385)
            && CharacterHPValue(34110710) > 0
            && EventFlag(34112410));
    DisableLockOnPoint(34110710, 220);
    WaitFixedTimeSeconds(1);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 150, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 151, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 152, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 153, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 154, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 155, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 156, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 157, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 151, 600921);
    SetSpEffect(34110710, 4240);
    WaitFixedTimeSeconds(0.5);
    if (CharacterHasSpEffect(34110710, 19385)) {
        EnableLockOnPoint(34110710, 220);
        SetNetworkconnectedEventFlagID(34112486, ON);
        EndEvent();
    }
    WarpCharacterAndCopyFloor(34110710, TargetEntityType.Area, 34112421, -1, 34110710);
    SetCharacterHome(34110710, 34112421);
    EnableLockOnPoint(34110710, 220);
    SetNetworkconnectedThisEventSlot(ON);
    SetSpEffect(34110710, 4241);
    EndEvent();
});

// 敵対NPC_反転前_三回目ワープ -- Hostile NPC_Before reversal_Third warp
$Event(34112430, Restart, function() {
    EndIf(EventFlag(34110710));
    EndIf(ThisEventSlot());
    EnableCharacterFadeOnEnable(34110710);
    WaitFor(
        ((CharacterType(10000, TargetType.BlackPhantom) && CharacterHasSpEffect(10000, 3710))
            || CharacterType(10000, TargetType.Alive)
            || CharacterType(10000, TargetType.BluePhantom)
            || CharacterType(10000, TargetType.WhitePhantom))
            && HPRatio(34110710) <= 0.4
            && !CharacterHasSpEffect(34110710, 19385)
            && CharacterHPValue(34110710) > 0
            && EventFlag(34112420));
    DisableLockOnPoint(34110710, 220);
    WaitFixedTimeSeconds(1);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 150, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 151, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 152, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 153, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 154, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 155, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 156, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 157, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 151, 600921);
    SetSpEffect(34110710, 4240);
    WaitFixedTimeSeconds(0.5);
    if (CharacterHasSpEffect(34110710, 19385)) {
        EnableLockOnPoint(34110710, 220);
        SetNetworkconnectedEventFlagID(34112487, ON);
        EndEvent();
    }
    WarpCharacterAndCopyFloor(34110710, TargetEntityType.Area, 34112431, -1, 34110710);
    SetCharacterHome(34110710, 34112431);
    WaitFixedTimeSeconds(1);
    RequestCharacterAIReplan(34110710);
    WaitFixedTimeSeconds(0.1);
    DisableCharacterAI(34110710);
    SetNetworkconnectedThisEventSlot(ON);
    EndEvent();
});

// 敵対NPC_反転前_前半終了 -- Hostile NPC_Before reversal_First half ended
$Event(34112439, Restart, function() {
    EndIf(EventFlag(34110710));
    WaitFor(AllBatchEventFlags(34112440, 34112447));
    DisableCharacter(34110710);
});

// 敵対NPC_反転前_回廊追いかけ_XX -- Hostile NPC_Before reversal_Corridor chase_XX
$Event(34112440, Restart, function(areaEntityId, areaEntityId2) {
    EndIf(EventFlag(34110710));
    EndIf(EventFlag(34112448));
    EndIf(EventFlag(34112459));
    EnableCharacterFadeOnEnable(34110710);
    WaitFor(
        ((CharacterType(10000, TargetType.BlackPhantom) && CharacterHasSpEffect(10000, 3710))
            || CharacterType(10000, TargetType.Alive)
            || CharacterType(10000, TargetType.BluePhantom)
            || CharacterType(10000, TargetType.WhitePhantom))
            && InArea(10000, areaEntityId)
            && EventFlag(34112410)
            && EventFlag(34112420)
            && EventFlag(34112430)
            && !EventFlag(34112448)
            && !CharacterHasSpEffect(34110710, 19385));
    WaitFixedTimeSeconds(4);
    EndIf(EventFlag(34112459));
    SetSpEffect(34110710, 4240);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 150, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 151, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 152, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 153, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 154, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 155, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 156, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 157, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110710, 151, 600921);
    WaitFixedTimeSeconds(0.5);
    if (CharacterHasSpEffect(34110710, 19385)) {
        SetSpEffect(34110710, 4241);
        RestartEvent();
    }
    WarpCharacterAndCopyFloor(34110710, TargetEntityType.Area, areaEntityId2, -1, 34110710);
    SetCharacterHome(34110710, areaEntityId2);
    SetSpEffect(34110710, 4241);
    WaitFixedTimeSeconds(4);
    RestartEvent();
});

// 敵対NPC_反転前_梁の上 -- Hostile NPC_Before reversal_On the beam
$Event(34112448, Restart, function() {
    EndIf(EventFlag(34110710));
    EndIf(ThisEventSlot());
    WaitFor(
        ((CharacterType(10000, TargetType.BlackPhantom) && CharacterHasSpEffect(10000, 3710))
            || CharacterType(10000, TargetType.Alive)
            || CharacterType(10000, TargetType.BluePhantom)
            || CharacterType(10000, TargetType.WhitePhantom))
            && InArea(10000, 34112448));
    ClearCharactersAITarget(34110710);
    SetSpEffect(34110710, 8082);
    SetThisEventSlot(ON);
});

// 敵対NPC_反転前_回廊スタート -- Hostile NPC_Before reversal_Corridor start
$Event(34112449, Restart, function() {
    EndIf(EventFlag(34110710));
    EndIf(ThisEventSlot());
    WaitFor(
        ((CharacterType(10000, TargetType.BlackPhantom) && CharacterHasSpEffect(10000, 3710))
            || CharacterType(10000, TargetType.Alive)
            || CharacterType(10000, TargetType.BluePhantom)
            || CharacterType(10000, TargetType.WhitePhantom))
            && InArea(10000, 34112449)
            && EventFlag(34112410)
            && EventFlag(34112420)
            && EventFlag(34112430));
    EnableLockOnPoint(34110710, 220);
    EnableCharacterAI(34110710);
    SetCharacterAIId(34110710, 523520200);
    SetThisEventSlot(ON);
});

// 敵対NPC_反転前_追いかけ終了判定_ダメージ -- Hostile NPC_Before reversal_Chasing end determination_Damage
$Event(34112459, Restart, function() {
    EndIf(EventFlag(34110710));
    WaitFor(
        ((CharacterType(10000, TargetType.BlackPhantom) && CharacterHasSpEffect(10000, 3710))
            || CharacterType(10000, TargetType.Alive)
            || CharacterType(10000, TargetType.BluePhantom)
            || CharacterType(10000, TargetType.WhitePhantom))
            && HasDamageType(34110710, 10000, DamageType.Unspecified)
            && EventFlag(34112410)
            && EventFlag(34112420)
            && EventFlag(34112430));
    SetThisEventSlot(ON);
});

// 敵対NPC_反転後_出現 -- Hostile NPC_After reversal_Appearance
$Event(34112460, Restart, function() {
    EndIf(EventFlag(34110711));
    EndIf(ThisEventSlot());
    DisableCharacter(34110711);
    DisableCharacterCollision(34110711);
    WaitFor(
        ((CharacterType(10000, TargetType.BlackPhantom) && CharacterHasSpEffect(10000, 3710))
            || CharacterType(10000, TargetType.Alive)
            || CharacterType(10000, TargetType.BluePhantom)
            || CharacterType(10000, TargetType.WhitePhantom))
            && InArea(10000, 34112460)
            && EventFlag(370));
    SpawnOneshotSFX(TargetEntityType.Character, 34110711, 150, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110711, 151, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110711, 152, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110711, 153, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110711, 154, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110711, 155, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110711, 156, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110711, 157, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110711, 151, 600921);
    WaitFixedTimeSeconds(0.5);
    EnableCharacter(34110711);
    EnableCharacterCollision(34110711);
    SetThisEventSlot(ON);
});

// 敵対NPC_反転後_一回目ワープ -- Hostile NPC_After reversal_First warp
$Event(34112465, Restart, function() {
    EndIf(EventFlag(34110711));
    EndIf(EventFlag(34112496));
    EndIf(ThisEventSlot());
    WaitFor(
        ((CharacterType(10000, TargetType.BlackPhantom) && CharacterHasSpEffect(10000, 3710))
            || CharacterType(10000, TargetType.Alive)
            || CharacterType(10000, TargetType.BluePhantom)
            || CharacterType(10000, TargetType.WhitePhantom))
            && HPRatio(34110711) <= 0.3
            && !CharacterHasSpEffect(34110710, 19385)
            && CharacterHPValue(34110711) > 0
            && !EventFlag(34112496));
    EndIf(CharacterHPValue(34110711) == 0);
    DisableLockOnPoint(34110711, 220);
    WaitFixedTimeSeconds(1);
    SpawnOneshotSFX(TargetEntityType.Character, 34110711, 150, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110711, 151, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110711, 152, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110711, 153, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110711, 154, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110711, 155, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110711, 156, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110711, 157, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, 34110711, 151, 600921);
    WaitFixedTimeSeconds(0.5);
    SetSpEffect(34110710, 4240);
    if (CharacterHasSpEffect(34110711, 19385)) {
        EnableLockOnPoint(34110711, 220);
        SetNetworkconnectedEventFlagID(34112488, ON);
        EndEvent();
    }
    WarpCharacterAndCopyFloor(34110711, TargetEntityType.Area, 34112466, -1, 34110711);
    SetCharacterHome(34110711, 34112466);
    EnableLockOnPoint(34110711, 220);
    SetThisEventSlot(ON);
    SetSpEffect(34110710, 4241);
});

// 敵対NPC_投げられた後にワープ_XX -- Hostile NPC_Warp after being thrown_XX
$Event(34112475, Restart, function(eventFlagId, eventFlagId2, areaEntityId) {
    EndIf(EventFlag(eventFlagId2));
    WaitFor(EventFlag(eventFlagId) && !CharacterHasSpEffect(eventFlagId2, 19385));
    DisableLockOnPoint(eventFlagId2, 220);
    SetSpEffect(eventFlagId2, 4240);
    SpawnOneshotSFX(TargetEntityType.Character, eventFlagId2, 150, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, eventFlagId2, 151, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, eventFlagId2, 152, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, eventFlagId2, 153, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, eventFlagId2, 154, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, eventFlagId2, 155, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, eventFlagId2, 156, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, eventFlagId2, 157, 600920);
    SpawnOneshotSFX(TargetEntityType.Character, eventFlagId2, 151, 600921);
    WaitFixedTimeSeconds(0.5);
    EndIf(CharacterHPValue(eventFlagId2) == 0);
    WarpCharacterAndCopyFloor(eventFlagId2, TargetEntityType.Area, areaEntityId, -1, eventFlagId2);
    SetCharacterHome(eventFlagId2, areaEntityId);
    EnableLockOnPoint(eventFlagId2, 220);
    SetNetworkconnectedThisEventSlot(ON);
    SetSpEffect(eventFlagId2, 4241);
});

// 敵対NPC_反転後_上層梁へワープ -- Hostile NPC_After reversal_Warp to upper beam
$Event(34112492, Restart, function() {
    flagArea |= EventFlag(34110711) || ThisEventSlot();
    EndIf(flagArea);
    flagArea |= InArea(10000, 34112482) || InArea(10000, 34112483);
    WaitFor(flagArea);
    DisableLockOnPoint(34110711, 220);
    WaitFixedTimeSeconds(1);
    SpawnOneshotSFX(TargetEntityType.Character, 34110711, 220, 806910);
    WarpCharacterAndCopyFloor(34110711, TargetEntityType.Area, 34112492, -1, 34110711);
    EnableLockOnPoint(34110711, 220);
    SetThisEventSlot(ON);
});

// 敵対NPC_反転後_下層梁へワープ -- Hostile NPC_After reversal_Warp to lower beam
$Event(34112493, Restart, function() {
    EndIf(EventFlag(34110711) || ThisEventSlot());
    WaitFor(InArea(10000, 34112490));
    DisableLockOnPoint(34110711, 220);
    WaitFixedTimeSeconds(1);
    SpawnOneshotSFX(TargetEntityType.Character, 34110711, 220, 806910);
    WarpCharacterAndCopyFloor(34110711, TargetEntityType.Area, 34112493, -1, 34110711);
    EnableLockOnPoint(34110711, 220);
    SetThisEventSlot(ON);
});

// 敵対NPC_反転後_大EVへワープ -- Hostile NPC_After reversal_Warp to large EV
$Event(34112496, Restart, function() {
    EndIf(EventFlag(34110711));
    EndIf(ThisEventSlot());
    WaitFor(
        ((CharacterType(10000, TargetType.BlackPhantom) && CharacterHasSpEffect(10000, 3710))
            || CharacterType(10000, TargetType.Alive)
            || CharacterType(10000, TargetType.BluePhantom)
            || CharacterType(10000, TargetType.WhitePhantom))
            && (InArea(10000, 34112482) || InArea(10000, 34112483)));
    DisableLockOnPoint(34110711, 220);
    WaitFixedTimeSeconds(1);
    SpawnOneshotSFX(TargetEntityType.Character, 34110711, 220, 806910);
    WarpCharacterAndCopyFloor(34110711, TargetEntityType.Area, 34112496, -1, 34110711);
    EnableLockOnPoint(34110711, 220);
    SetThisEventSlot(ON);
});

// 敵対NPC_特殊効果 -- Hostile NPC_Special effects
$Event(34112499, Restart, function() {
    SetSpEffect(34110710, 8090);
    SetSpEffect(34110711, 8090);
    SetSpEffect(34110712, 8090);
});

// 天候固定 -- weather fixed
$Event(34112690, Restart, function() {
    DisableNetworkSync();
    GotoIf(L0, InArea(10000, 34112690));
    GotoIf(L1, InArea(10000, 34112691));
    ChangeWeather(Weather.None, -1, false);
    WaitFixedTimeSeconds(1);
    RestartEvent();
L0:
    cond |= WeatherActive(Weather.RainyClouds, 0, 0);
    GotoIf(L2, cond);
    ChangeWeather(Weather.RainyClouds, -1, false);
    Goto(L2);
L1:
    cond |= WeatherActive(Weather.HeavyFog, 0, 0);
    GotoIf(L2, cond);
    ChangeWeather(Weather.HeavyFog, -1, false);
L2:
    RestartEvent();
});

// ボス撃破 -- Defeat the boss
$Event(34112800, Restart, function() {
    EndIf(EventFlag(34110800));
    WaitFor(CharacterHPValue(34110800) <= 0);
    WaitFixedTimeSeconds(4);
    PlaySE(34110800, SoundType.SFX, 888880000);
    WaitFor(CharacterDead(34110800));
    HandleBossDefeatAndDisplayBanner(34110800, TextBannerType.GreatEnemyFelled);
    SetEventFlagID(34110800, ON);
});

// ボス出現 -- Boss appears
$Event(34112810, Restart, function() {
    if (EventFlag(34110800)) {
        DisableCharacter(34110800);
        DisableCharacterCollision(34110800);
        ForceCharacterDeath(34110800, false);
        EndEvent();
    }
L0:
    DisableCharacterAI(34110800);
    DisableCharacterCollision(34110800);
    flagArea = EventFlag(34112805) && InArea(10000, 34112800);
    dmg = HasDamageType(34110800, 10000, DamageType.Unspecified);
    WaitFor(flagArea);
L2:
    EnableCharacterAI(34110800);
    EnableCharacterCollision(34110800);
    SetNetworkUpdateRate(34110800, true, CharacterUpdateFrequency.AlwaysUpdate);
    DisplayBossHealthBar(Enabled, 34110800, 0, 0);
});

// ボスイベント起動 -- Boss event activation
$Event(34112849, Restart, function() {
    $InitializeCommonEvent(0, 9005800, 34110800, 34111800, 34112800, 34112805, 34115800, 10000, 0, 0);
    $InitializeCommonEvent(0, 9005801, 34110800, 34111800, 34112800, 34112805, 34112806, 10000);
    $InitializeCommonEvent(0, 9005811, 34110800, 34111800, 3, 0);
    $InitializeCommonEvent(0, 9005822, 34110800, 930000, 34112805, 34112806, 0, 34112802, 0, 0);
});


