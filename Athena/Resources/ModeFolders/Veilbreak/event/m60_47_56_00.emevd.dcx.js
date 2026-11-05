// ==EMEVD==
// @docs    er-common.emedf.json
// @compress    DCX_KRAK
// @game    Sekiro
// @string    "N:\\GR\\data\\Param\\event\\common_func.emevd\u0000N:\\GR\\data\\Param\\event\\common_macro.emevd\u0000\u0000\u0000\u0000\u0000\u0000"
// @linked    [0,82]
// @version    3.5
// ==/EMEVD==

// コンストラクタ -- constructor
$Event(0, Default, function() {
    //$InitializeCommonEvent(0, 90005605, 1047561500, 12, 5, 0, 0, 12052021, 0, 1047562501, 1047562502, 1047562503, 0, 0, 0, 0);
    //$InitializeCommonEvent(0, 90005605, 1047561500, 12, 5, 0, 0, 12052020, 0, 1047562501, 1047562502, 1047562503, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005790, 0, 1047560180, 1047562181, 1047562182, 1047560180, 21, 1047562180, 1047562181, 0, 0, false, 0);
    $InitializeCommonEvent(0, 90005791, 1047560180, 1047562181, 1047562182, 1047560180);
    $InitializeCommonEvent(0, 90005792, 1047560180, 1047562181, 1047562182, 1047560180, 1047560700, 0);
    $InitializeCommonEvent(0, 90005793, 1047560180, 1047562181, 1047562182, 1047560180, 1047562180, 1047562182, 0);

    //Original Spawn Point Set for Warp from '12052021' to '12052020'
    $InitializeEvent(0, 1290300001, 1047561500, 12, 5, 0, 0, 12052020, 0, 1047562501, 1047562502, 1047562503, 0, 0, 0, 0);
});

/* 
This is Based off Common Event '90005605'.
The Only Difference comes from looking for EventFlag(1036290000)
1036290000, is set when the Monument is examined 
*/
$Event(1290300001, Restart, function(assetEntityId, areaId, blockId, regionId, indexId, initialAreaEntityId, subareaNamePopupMessageId, eventFlagId, eventFlagId2, eventFlagId3, eventFlagId4, messageId, timeSeconds, timeSeconds2) {
    EndIf(!PlayerIsInOwnWorld());
    WaitFor(EventFlag(1036290000)); //Wait For Rose Church Monument to be Examined
    SetEventFlagID(eventFlagId2, OFF);
    SetEventFlagID(eventFlagId3, OFF);
    if (!ThisEventSlot()) {
        DeleteAssetfollowingSFX(assetEntityId, true);
        SetEventFlagID(eventFlagId, OFF);
        WaitFixedTimeFrames(1);
    }
    onlineFlag |= HasMultiplayerState(MultiplayerState.Multiplayer)
        || HasMultiplayerState(MultiplayerState.MultiplayerPending);
    if (eventFlagId4 != 0) {
        onlineFlag |= !EventFlag(eventFlagId4);
    }
    if (!onlineFlag) {
        if (!EventFlag(eventFlagId)) {
            CreateAssetfollowingSFX(assetEntityId, 200, 806870);
            SetEventFlagID(eventFlagId, ON);
        }
    }
L1:
    onlineFlagAct &= PlayerIsInOwnWorld()
        && !(HasMultiplayerState(MultiplayerState.Multiplayer)
            || HasMultiplayerState(MultiplayerState.MultiplayerPending));
    if (eventFlagId4 != 0) {
        if (Signed(messageId) == 0) {
            onlineFlagAct &= EventFlag(eventFlagId4) && EventFlag(eventFlagId);
        }
    }
    onlineFlagAct &= ActionButtonInArea(9140, assetEntityId);
    onlineFlag2 |= HasMultiplayerState(MultiplayerState.Multiplayer)
        || HasMultiplayerState(MultiplayerState.MultiplayerPending);
    if (eventFlagId4 != 0) {
        onlineFlag2 |= !EventFlag(eventFlagId4);
    }
    onlineFlag3 = onlineFlag2 && EventFlag(eventFlagId);
    onlineFlag4 |= HasMultiplayerState(MultiplayerState.Multiplayer)
        || HasMultiplayerState(MultiplayerState.MultiplayerPending);
    if (eventFlagId4 != 0) {
        onlineFlag4 |= !EventFlag(eventFlagId4);
    }
    onlineFlag5 = !onlineFlag4 && !EventFlag(eventFlagId);
    flag = EventFlagState(CHANGE, TargetEventFlagType.EventFlag, eventFlagId4);
    onlineFlagAct2 |= onlineFlagAct || onlineFlag3 || onlineFlag5;
    if (eventFlagId4 != 0) {
        onlineFlagAct2 |= flag;
    }
    WaitFor(onlineFlagAct2);
    if (!onlineFlagAct.Passed) {
        if (onlineFlag3.Passed) {
            DeleteAssetfollowingSFX(assetEntityId, true);
            SetEventFlagID(eventFlagId, OFF);
        }
L2:
        WaitFixedTimeSeconds(0.033);
        RestartEvent();
    }
L3:
    if (!(eventFlagId4 == 0 || Signed(messageId) == 0)) {
        if (!EventFlag(eventFlagId4)) {
            DisplayGenericDialog(messageId, PromptType.YESNO, NumberofOptions.NoButtons, assetEntityId, 3);
            WaitFixedTimeSeconds(1);
            RestartEvent();
        }
    }
L4:
    DisplayGenericDialogAndSetEventFlags(4300, PromptType.YESNO, NumberofOptions.TwoButtons, assetEntityId, 3, eventFlagId2, eventFlagId3, eventFlagId3);
    if (!EventFlag(eventFlagId2)) {
        WaitFixedTimeSeconds(1);
        RestartEvent();
    }
L6:
    RestartIf(
        HasMultiplayerState(MultiplayerState.Multiplayer)
            || HasMultiplayerState(MultiplayerState.MultiplayerPending));
    RotateCharacter(10000, assetEntityId, -1, true);
    ForceAnimationPlayback(10000, 60490, false, false, false);
    WaitFixedTimeSeconds(3);
    WarpPlayer(areaId, blockId, regionId, indexId, initialAreaEntityId, subareaNamePopupMessageId);
    RestartEvent();
    WaitFixedTimeSeconds(timeSeconds);
    WaitFixedTimeSeconds(timeSeconds2);
});
