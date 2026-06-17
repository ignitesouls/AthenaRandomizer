// ==EMEVD==
// @docs    er-common.emedf.json
// @compress    DCX_KRAK
// @game    Sekiro
// @string    "N:\\GR\\data\\Param\\event\\common_func.emevd\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000"
// @linked    [0]
// @version    3.5
// ==/EMEVD==

// コンストラクタ -- constructor
$Event(0, Default, function() {
    RegisterBonfire(11050002, 11051952, 0, 0, 0, 8);
    RegisterBonfire(11050003, 11051953, 0, 0, 0, 8);
    RegisterBonfire(11050004, 11051954, 0, 0, 0, 8);
    RegisterBonfire(11050005, 11051955, 0, 0, 0, 8);
    $InitializeCommonEvent(0, 9005810, 11050800, 11050000, 11050950, 11051950, 8);
    $InitializeCommonEvent(0, 9005810, 11050850, 11050001, 11050951, 11051951, 8);
    $InitializeEvent(0, 11052800);
    $InitializeEvent(0, 11052810);
    $InitializeEvent(0, 11052811);
    $InitializeEvent(0, 11052830);
    $InitializeEvent(0, 11052849);
    $InitializeEvent(0, 11052850);
    $InitializeEvent(0, 11052860);
    $InitializeEvent(0, 11052861);
    $InitializeEvent(0, 11052859);
    $InitializeCommonEvent(0, 90005780, 11050800, 11052160, 11052161, 11050740, SummonSignType.NPCWhiteSign, 11052160, 11059350, true, 0);
    $InitializeCommonEvent(0, 90005781, 11050800, 11052160, 11052161, 11050740);
    $InitializeCommonEvent(0, 90005784, 11052160, 11052805, 11050740, 11052800, 11052805, 0);
    $InitializeCommonEvent(0, 90005780, 11050800, 11052164, 11052165, 11050750, SummonSignType.NPCWhiteSign, 11052164, 10009719, true, 0);
    $InitializeCommonEvent(0, 90005781, 11050800, 11052164, 11052165, 11050750);
    $InitializeCommonEvent(0, 90005784, 11052164, 11052805, 11050750, 11052800, 11052805, 0);
    $InitializeCommonEvent(0, 90005501, 11050525, 11051525, 0, 11051525, 11051526, 11051527, 11050526);
    $InitializeCommonEvent(0, 90005501, 11050530, 11051530, 0, 11051530, 11051531, 11051532, 11050531);
    $InitializeCommonEvent(0, 90005501, 11050535, 11051535, 1, 11051535, 11051536, 11051537, 11050536);
    $InitializeCommonEvent(0, 90005501, 11050610, 11051610, 2, 11051610, 11051611, 11051612, 11050611);
    $InitializeEvent(0, 11052510);
    $InitializeCommonEvent(0, 90005511, 11050560, 11051560, 11053560, 227010, 0);
    $InitializeCommonEvent(0, 90005512, 11050560, 11052560, 11052561);
    $InitializeEvent(0, 11052580);
    $InitializeCommonEvent(0, 90005520, 11050578, 11051578, 11052578, 11052579);
    $InitializeEvent(0, 11052691);
    $InitializeEvent(0, 11052692);
    $InitializeCommonEvent(0, 90005605, 11051680, 34, 15, 0, 0, 34152692, 11050000, 11052680, 11052681, 11052682, 0, 0, 0, 0);
    $InitializeEvent(0, 11052698);
    $InitializeEvent(0, 11052697);
    $InitializeEvent(0, 11052699);
    $InitializeEvent(0, 11053700, 11050801, 11050800, 11050800, 11052805, 90);
    $InitializeEvent(0, 11053705, 11050710);
    $InitializeCommonEvent(0, 90005704, 11050710, 4201, 4200, 1040529251, 3);
    $InitializeCommonEvent(0, 90005703, 11050710, 4201, 4202, 1040529251, 4201, 4200, 4203, -1);
    $InitializeCommonEvent(0, 90005702, 11050710, 4203, 4200, 4204);
    $InitializeEvent(0, 11053706, 11050705);
    $InitializeCommonEvent(0, 90005750, 11051700, 6450, 4900, 9500, 9500, 11059206, 806780);
    $InitializeEvent(0, 11053707);
    $InitializeCommonEvent(0, 90005750, 11051700, 4110, 105000, 400500, 400500, 11059305, 0);
    $InitializeCommonEvent(0, 11053708, 11051740, 4110, 103700, 400370, 400370, 4208, 0, 4203);
    $InitializeCommonEvent(0, 90005706, 11050721, 930025, 0);
    $InitializeCommonEvent(0, 90005706, 11050720, 930010, 0);
    $InitializeEvent(0, 11053710, 11050850);
    $InitializeEvent(0, 11053720);
    $InitializeCommonEvent(0, 90005703, 11050730, 3941, 3942, 1039409251, 3941, 3940, 3943, 0);
    $InitializeCommonEvent(0, 90005704, 11050730, 3941, 3940, 1039409251, 3);
    $InitializeCommonEvent(0, 90005702, 11050730, 3943, 3940, 3944);
    $InitializeEvent(0, 11053730, 11050730);
    $InitializeEvent(0, 11053731, 11050730);
    
    $InitializeEvent(0, 11053732, 11051802, 19000800);
    $InitializeEvent(0, 11053733, 11052849, 11051849);
});

// プリコンストラクタ -- preconstructor
$Event(50, Default, function() {
    SetCharacterBackreadState(11050705, true);
    SetCharacterBackreadState(11050710, true);
    SetCharacterBackreadState(11050715, true);
    SetCharacterBackreadState(11050720, true);
    SetCharacterBackreadState(11050721, true);
    $InitializeEvent(0, 11052500);
    $InitializeCommonEvent(0, 90005251, 11050202, 3, 0, 0);
    $InitializeCommonEvent(0, 90005251, 11050203, 3.5, 0, 0);
    $InitializeCommonEvent(0, 90005221, 11050205, 30000, 20000, 0, 0);
    $InitializeCommonEvent(0, 90005221, 11050206, 30000, 20000, 0, 0);
    $InitializeCommonEvent(0, 90005221, 11050207, 30000, 20000, 0, 0);
    $InitializeCommonEvent(0, 90005221, 11050208, 30000, 20000, 0, 0);
    $InitializeCommonEvent(0, 90005261, 11050240, 11052240, 3, 0, 0);
    $InitializeCommonEvent(0, 90005261, 11050250, 11052240, 1, 0.5, 0);
    $InitializeCommonEvent(0, 90005261, 11050250, 11052240, 1, 0.2, 0);
    $InitializeCommonEvent(0, 90005211, 11050300, 30002, 20002, 11052300, 5, 0, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005211, 11050301, 30002, 20002, 11052301, 5, 0, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005211, 11050302, 30002, 20002, 11052302, 5, 0, 0, 0, 0, 0);
});

// 灰に包まれた王都 -- The royal capital shrouded in ashes
$Event(11052500, Default, function() {
    EndIf(!PlayerIsInOwnWorld());
    EndIf(EventFlag(11050500));
    WaitFor(PlayerIsInOwnWorld() && EventFlag(9116) && PlayerInMap(11, 5, 0, 0));
    //PlayCutsceneToPlayer(13000060, CutscenePlayMode.Skippable, 10000);
    WaitFixedTimeRealFrames(1);
    SetEventFlagID(11050500, ON);
    //ForceAnimationPlayback(10000, 0, false, false, false);
    WaitFixedTimeSeconds(1);
    DisplayAreaWelcomeMessage(11050);
});

// エレベータイベント起動 -- Elevator event activation
$Event(11052510, Default, function() {
    $InitializeCommonEvent(0, 90005500, 11050525, 11051525, 0, 11051525, 11051526, 11053526, 11051527, 11053527, 11052526, 11052527, 11050526, 11052527, 0);
    $InitializeCommonEvent(0, 90005505, 11050530, 11051530, 0, 11051530, 11051531, 11053531, 11051532, 11053532, 11050531, 11052532, 0);
    $InitializeCommonEvent(0, 90005500, 11050610, 11051610, 2, 11051610, 11051611, 11053611, 11051612, 11053612, 11052611, 11052612, 11050611, 11052612, 0);
});

// 梯子登録 -- ladder registration
$Event(11052580, Restart, function() {
    RegisterLadder(11050580, 11050581, 11051580);
    RegisterLadder(11050582, 11050583, 11051582);
    RegisterLadder(11050584, 11050585, 11051584);
    RegisterLadder(11050586, 11050587, 11051586);
    RegisterLadder(11050588, 11050589, 11051588);
    RegisterLadder(11050590, 11050591, 11051590);
    RegisterLadder(11050592, 11050593, 11051592);
    RegisterLadder(11050594, 11050595, 11051594);
    RegisterLadder(11050596, 11050597, 11051596);
});

// アセット破壊禁止 -- Prohibition of asset destruction
$Event(11052691, Restart, function() {
    EnableAssetInvunerability(11051691);
});

// 神門稼働禁止 -- Shin gate operation prohibited
$Event(11052692, Restart, function() {
    DisableObjAct(11051535, -1);
    DisableObjAct(11051536, -1);
    DisableObjAct(11051537, -1);
});

// チュートリアルメッセージ_円卓のマリカ像 -- Tutorial message_Marika statue at the round table
$Event(11052697, Restart, function() {
    DisableNetworkSync();
    EndIf(!PlayerIsInOwnWorld());
    WaitFor(
        EventFlag(710880)
            && !EventFlag(69480)
            && !EventFlag(2051)
            && !EventFlag(2052)
            && PlayerIsInOwnWorld()
            && !(HasMultiplayerState(MultiplayerState.Multiplayer)
                || HasMultiplayerState(MultiplayerState.MultiplayerPending))
            && !CharacterHasSpEffect(10000, 9640));
    ShowTutorialPopup(1880, true, true);
    if (!EventFlag(69480)) {
        DirectlyGivePlayerItem(ItemType.Goods, 9153, 710880, 1);
    }
    SetEventFlagID(69480, ON);
});

// 闘技場の扉解放 -- Opening the arena door
$Event(11052696, Restart, function() {
    WaitFor(EventFlag(11058556));
    SetEventFlagID(11008556, ON);
});

// チュートリアルメッセージ_王都闘技場 -- Tutorial message_Royal Capital Arena
$Event(11052698, Restart, function() {
    DisableNetworkSync();
    EndIf(!PlayerIsInOwnWorld());
    WaitFor(
        !EventFlag(710850)
            && InArea(10000, 11052698)
            && PlayerIsInOwnWorld()
            && !(HasMultiplayerState(MultiplayerState.Multiplayer)
                || HasMultiplayerState(MultiplayerState.MultiplayerPending))
            && !CharacterHasSpEffect(10000, 9640));
    SetEventFlagID(710850, ON);
    SetEventFlagID(60350, ON);
    if (!EventFlag(6080)) {
        SetEventFlagID(6080, ON);
        StartPS5Activity(7);
    }
    WaitFixedTimeFrames(1);
    ShowTutorialPopup(1850, true, true);
    if (!EventFlag(69450)) {
        DirectlyGivePlayerItem(ItemType.Goods, 9150, 710850, 1);
    }
    WaitFixedTimeFrames(1);
    SetEventFlagID(69450, ON);
});

// 闘技場入り口_マルチ中は稼働しない -- Arena entrance_does not operate during multiplayer
$Event(11052699, Default, function() {
    EndIf(EventFlag(11008556));
    if (!HasMultiplayerState(MultiplayerState.Multiplayer)) {
        if (!HasMultiplayerState(MultiplayerState.MultiplayerPending)) {
            EnableObjAct(11051699, 227030);
            online |= HasMultiplayerState(MultiplayerState.Multiplayer)
                || HasMultiplayerState(MultiplayerState.MultiplayerPending);
            WaitFor(online);
            DisableObjAct(11051699, 227030);
            RestartEvent();
        }
    }
L0:
    DisableObjAct(11051699, 227030);
    online |= HasMultiplayerState(MultiplayerState.Multiplayer)
        || HasMultiplayerState(MultiplayerState.MultiplayerPending);
    WaitFor(!online);
    EnableObjAct(11051699, 227030);
    RestartEvent();
});

// ゴッドフレイ撃破 -- Defeat Godfrey
$Event(11052800, Default, function() {
    EndIf(EventFlag(11050800));
    WaitFor(CharacterHPValue(11050800) <= 0);
    WaitFixedTimeSeconds(4);
    PlaySE(11058000, SoundType.SFX, 888880000);
    WaitFor(
        (PlayerIsInOwnWorld() && CharacterDead(11050800) && !CharacterHasSpEffect(10000, 9646))
            || EventFlag(11050800));
    HandleBossDefeatAndDisplayBanner(11050800, TextBannerType.LegendFelled);
    SetEventFlagID(11050800, ON);
    SetNetworkconnectedEventFlagID(11050800, ON);
    SetEventFlagID(9107, ON);
    if (PlayerIsInOwnWorld()) {
        SetEventFlagID(61107, ON);
    }
    ChangeCamera(-1, -1);
    WaitFor(InArea(10000, 11052840));
    SuppressSE(SoundType.BGM, 0, false);
});

// ゴッドフレイ出現 -- Godfrey appears
$Event(11052810, Restart, function() {
    if (EventFlag(11050800)) {
        DisableCharacter(11055800);
        DisableCharacterCollision(11055800);
        ForceCharacterDeath(11055800, false);
        DisableAsset(11051820);
        EndEvent();
    }
L0:
    DisableCharacterAI(11055800);
    DisableCharacterGravity(11050800);
    DisableCharacterCollision(11050800);
    EnableCharacterImmortality(11050801);
    DisableCharacterCollision(11050801);
    EndIf(
        CharacterType(10000, TargetType.BlackPhantom)
            || CharacterType(10000, TargetType.Invader)
            || CharacterType(10000, TargetType.Invader2)
            || CharacterType(10000, TargetType.Invader3)
            || CharacterType(10000, TargetType.BluePhantom));
    if (!EventFlag(11050801)) {
        DisableCharacterCollision(11050801);
        ForceAnimationPlayback(11050801, 30010, false, false, false);
        WaitFor(EventFlag(11052805) && InArea(10000, 11052801));
        SendInvadingPhantomsHome(0);
        WaitFixedTimeFrames(1);
        SetEventFlagID(9021, ON);
        if (PlayerIsInOwnWorld()) {
            PlayCutsceneToPlayerAndWarp(11050010, CutscenePlayMode.Skippable, 11052811, 11050000, 10000, 0, false);
        } else {
            PlayCutsceneToPlayer(11050010, CutscenePlayMode.Skippable, 10000);
        }
        WaitFixedTimeRealFrames(1);
        SetNetworkconnectedEventFlagID(11050801, ON);
        if (!PlayerIsInOwnWorld()) {
            SetBossBGM(472000, BossBGMState.Stop2);
        }
        if (PlayerIsInOwnWorld()) {
            SetCameraAngle(7.5, -37.16);
        }
        DisableAsset(11051820);
        EnableCharacter(11050801);
        EnableCharacterCollision(11050801);
        WarpCharacterAndCopyFloor(11050801, TargetEntityType.Area, 11052815, -1, 11050801);
        ForceAnimationPlayback(11050801, 20020, false, false, false);
    } else {
L1:
        DisableAsset(11051820);
        WaitFor(EventFlag(11052805) && InArea(10000, 11052800));
    }
L2:
    EnableCharacterCollision(11050801);
    EnableCharacterAI(11050801);
    SetNetworkUpdateRate(11050801, true, CharacterUpdateFrequency.AlwaysUpdate);
    CreateReferredDamagePair(11050801, 11050800);
    DisableCharacterHPBarDisplay(11050801);
    DisplayBossHealthBar(Enabled, 11050800, 0, 904720000);
});

// ゴッドフレイ激昂 -- godfrey rage
$Event(11052811, Restart, function() {
    EndIf(EventFlag(11050800));
    WaitFor(CharacterHPValue(11050801) <= 1);
    DisableCharacterCollision(11050801);
    if (PlayerIsInOwnWorld()) {
        PlayCutsceneToPlayerAndWarp(11050020, CutscenePlayMode.Skippable, 11052816, 11050000, 10000, 0, false);
    } else {
        PlayCutsceneToPlayer(11050020, CutscenePlayMode.Skippable, 10000);
    }
    WaitFixedTimeRealFrames(1);
    SetEventFlagID(11052802, ON);
    DisableCharacter(11050801);
    if (PlayerIsInOwnWorld()) {
        SetCameraAngle(8.09, -37.16);
    }
    EnableCharacter(11050800);
    WaitFixedTimeFrames(1);
    EnableCharacterGravity(11050800);
    WarpCharacterAndCopyFloor(11050800, TargetEntityType.Area, 11052815, -1, 11050800);
    WaitFixedTimeFrames(1);
    EnableCharacterCollision(11050800);
    ForceAnimationPlayback(11050800, 20020, false, false, false);
    EnableCharacterAI(11050800);
    DisplayBossHealthBar(Enabled, 11050800, 0, 904720001);
});

// ゴッドフレイカメラ -- godfrey camera
$Event(11052830, Restart, function() {
    DisableNetworkSync();
    EndIf(EventFlag(11050800));
    WaitFor(
        (PlayerIsInOwnWorld() && EventFlag(11052805) && !EventFlag(11050800))
            || (!PlayerIsInOwnWorld() && EventFlag(11052806) && !EventFlag(11050800)));
    ChangeCamera(4721, 4721);
    WaitFor(CharacterHasSpEffect(11050800, 12298) && !EventFlag(11050800));
    ChangeCamera(4725, 4725);
    WaitFor(!(CharacterHasSpEffect(11050800, 12298) && !EventFlag(11050800)));
    RestartEvent();
});

// ゴッドフレイ戦イベント起動 -- Godfrey battle event starts
$Event(11052849, Restart, function() {
    $InitializeCommonEvent(0, 9005800, 11050800, 11051800, 11052800, 11052805, 11055800, 10000, 0, 0);
    $InitializeCommonEvent(0, 9005801, 11050800, 11051800, 11052800, 11052805, 11052806, 10000);
    $InitializeCommonEvent(0, 9005811, 11050800, 11051800, 17, 0);
    $InitializeCommonEvent(0, 9005813, 11050800, 11051801, 18, 11050801, 18);
    $InitializeCommonEvent(0, 9005822, 11050800, 472000, 11052805, 11052806, 11050801, 11052802, 1, 1);
});

// 百智卿撃破 -- Defeat Lord Hyakuchi
$Event(11052850, Restart, function() {
    EndIf(EventFlag(11050850));
    WaitFor(CharacterHPValue(11050850) <= 0);
    WaitFixedTimeSeconds(4);
    PlaySE(11058050, SoundType.SFX, 888880000);
    SetSpEffect(20000, 1899);
    WaitFor(
        (PlayerIsInOwnWorld() && CharacterDead(11050850) && !CharacterHasSpEffect(10000, 9646))
            || EventFlag(11050850));
    HandleBossDefeatAndDisplayBanner(11050850, TextBannerType.GreatEnemyFelled);
    DisableCharacterDefaultBackread(11050850);
    SetNetworkconnectedEventFlagID(11050850, ON);
    SetEventFlagID(9106, ON);
    if (PlayerIsInOwnWorld()) {
        SetEventFlagID(61106, ON);
    }
});

// 百智卿出現 -- Lord Baekchi appears
$Event(11052860, Restart, function() {
    if (EventFlag(11050850)) {
        DisableCharacter(11055850);
        DisableCharacterCollision(11055850);
        ForceCharacterDeath(11055850, false);
        EndEvent();
    }
L0:
    DisableCharacter(11055851);
    DisableCharacterCollision(11055851);
    DisableCharacterAI(11055850);
    EnableCharacterDefaultBackread(11050850);
    GotoIf(L8, EventFlag(9120) && EventFlag(9122) && EventFlag(9112));
    GotoIf(L7, !EventFlag(9120) && EventFlag(9122) && EventFlag(9112));
    GotoIf(L6, EventFlag(9120) && !EventFlag(9122) && EventFlag(9112));
    GotoIf(L5, EventFlag(9120) && EventFlag(9122) && !EventFlag(9112));
    GotoIf(L4, !EventFlag(9120) && !EventFlag(9122) && EventFlag(9112));
    GotoIf(L3, EventFlag(9120) && !EventFlag(9122) && !EventFlag(9112));
    GotoIf(L2, !EventFlag(9120) && EventFlag(9122) && !EventFlag(9112));
    Goto(L1);
L2:
    CopyPlayerCharacterData(11050851, 11050850);
    Goto(L1);
L3:
    CopyPlayerCharacterData(11050852, 11050850);
    Goto(L1);
L4:
    CopyPlayerCharacterData(11050853, 11050850);
    Goto(L1);
L5:
    CopyPlayerCharacterData(11050854, 11050850);
    Goto(L1);
L6:
    CopyPlayerCharacterData(11050855, 11050850);
    Goto(L1);
L7:
    CopyPlayerCharacterData(11050856, 11050850);
    Goto(L1);
L8:
    CopyPlayerCharacterData(11050857, 11050850);
    Goto(L1);
L1:
    if (!EventFlag(11050851)) {
        ForceAnimationPlayback(11050850, 90102, true, false, false);
        if (PlayerIsInOwnWorld()) {
            SetEventFlagID(11050854, OFF);
        }
        WaitFor(
            (PlayerIsInOwnWorld() && CharacterHasSpEffect(11050850, 9770))
                || HasDamageType(11050850, 0, DamageType.Unspecified));
        SetNetworkconnectedEventFlagID(11050851, ON);
        SetSpEffect(11050850, 9644);
    } else {
L1_:
        cond = EventFlag(11052855);
        WaitFor(InArea(10000, 11052850) || InArea(10000, 11052855));
        WaitFor(cond);
    }
L10:
    SetCharacterTeamType(11050850, TeamType.Enemy);
    EnableCharacterAI(11050850);
    SetNetworkUpdateRate(11055850, true, CharacterUpdateFrequency.AlwaysUpdate);
    DisplayBossHealthBar(Enabled, 11050850, 0, 132400);
});

// 百智卿激昂 -- Lord Baichi enraged
$Event(11052861, Restart, function() {
    EndIf(EventFlag(11050850));
    WaitFor(HPRatio(11050850) <= 0.6);
    SetEventFlagID(11052852, ON);
});

// 百智卿イベント起動 -- Lord Hyakuchi event started
$Event(11052859, Restart, function() {
    $InitializeCommonEvent(0, 9005800, 11050850, 11051850, 11052850, 11052855, 11055850, 10000, 11050851, 0);
    if (!EventFlag(11050851)) {
        $InitializeCommonEvent(0, 9005800, 11050850, 11051851, 11052855, 11052855, 11055850, 10000, 6000, 0);
    } else {
        $InitializeCommonEvent(0, 9005800, 11050850, 11051851, 11052855, 11052855, 11055850, 10000, 11050851, 0);
    }
    $InitializeCommonEvent(0, 9005801, 11050850, 11051850, 11052850, 11052855, 11052856, 10000);
    $InitializeCommonEvent(0, 9005801, 11050850, 11051851, 11052855, 11052855, 11052856, 10000);
    $InitializeCommonEvent(0, 9005811, 11050850, 11051850, 5, 11050854);
    $InitializeCommonEvent(0, 9005811, 11050850, 11051851, 4, 11050854);
    $InitializeCommonEvent(0, 9005811, 11050850, 11051852, 4, 11050854);
    $InitializeCommonEvent(0, 9005811, 11050850, 11051853, 8, 11050854);
    $InitializeCommonEvent(0, 9005811, 11050850, 11051854, 4, 11050854);
    $InitializeCommonEvent(0, 9005811, 11050850, 11051855, 5, 11050854);
    $InitializeCommonEvent(0, 9005811, 11050850, 11051856, 5, 11050854);
    $InitializeCommonEvent(0, 9005822, 11050850, 921100, 11052855, 11052856, 0, 11052852, 0, 0);
});

// NPC206ゴッドフレイ_会話処理限界の距離変更 -- NPC206 Godfrey_Distance change for conversation processing limit
$Event(11053700, Restart, function(chrEntityId, chrEntityId2, eventFlagId, eventFlagId2, range) {
    EndIf(!PlayerIsInOwnWorld());
    SetCharacterTalkRange(chrEntityId, 17);
    if (0 != chrEntityId2) {
        SetCharacterTalkRange(chrEntityId2, 17);
    }
    EndIf(EventFlag(eventFlagId));
    GotoIf(L1, !EventFlag(eventFlagId2));
    Goto(L2);
L1:
    WaitFor(EventFlag(eventFlagId2));
    Goto(L2);
L2:
    SetCharacterTalkRange(chrEntityId, range);
    if (0 != chrEntityId2) {
        SetCharacterTalkRange(chrEntityId2, range);
    }
    EndEvent();
});

// NPC351金仮面の従者_NPC初期化イベント -- NPC351 Gold Masked Squire_NPC initialization event
$Event(11053705, Restart, function(chrEntityId) {
    WaitFixedTimeFrames(1);
    SetEventFlagID(11059200, OFF);
    if (PlayerIsInOwnWorld()) {
    }
L10:
    DisableCharacter(chrEntityId);
    SetCharacterBackreadState(chrEntityId, true);
    GotoIf(L20, !EventFlag(4210));
    GotoIf(L1, EventFlag(4200));
    GotoIf(L2, EventFlag(4201));
    GotoIf(L4, EventFlag(4203));
L1:
    SetCharacterBackreadState(chrEntityId, false);
    EnableCharacter(chrEntityId);
    ForceAnimationPlayback(chrEntityId, 90102, false, false, false);
    GotoIf(L20, mainGroupAbuse);
L2:
    SetCharacterBackreadState(chrEntityId, false);
    EnableCharacter(chrEntityId);
    SetCharacterTeamType(chrEntityId, TeamType.HostileNPC);
    Goto(L20);
L4:
    ForceCharacterTreasure(chrEntityId);
    DisableCharacter(chrEntityId);
    SetCharacterBackreadState(chrEntityId, true);
    Goto(L20);
L20:
    WaitFor(EventFlag(11059200));
    RestartEvent();
});

// NPC112金仮面の探究者_NPC初期化イベント -- NPC112 Gold Masked Seeker_NPC initialization event
$Event(11053706, Restart, function(chrEntityId) {
    WaitFixedTimeFrames(1);
    SetEventFlagID(11059200, OFF);
    if (PlayerIsInOwnWorld()) {
    }
L10:
    DisableCharacter(chrEntityId);
    SetCharacterBackreadState(chrEntityId, true);
    if (!((!EventFlag(4203) && (EventFlag(4210) || EventFlag(4211)))
        || (EventFlag(4203) && !EventFlag(4217) && EventFlag(118) && EventFlag(11009555)))) {
        SetNetworkconnectedEventFlagID(1040549254, OFF);
        SetNetworkconnectedEventFlagID(11009554, OFF);
        SetNetworkconnectedEventFlagID(1051569454, OFF);
        SetNetworkconnectedEventFlagID(11059304, OFF);
    } else {
        SetCharacterBackreadState(chrEntityId, false);
        EnableCharacter(chrEntityId);
        SetCharacterTeamType(chrEntityId, TeamType.Disabled);
        ForceAnimationPlayback(chrEntityId, 930002, false, false, false);
        SetNetworkconnectedEventFlagID(1040549254, OFF);
        SetNetworkconnectedEventFlagID(11009554, OFF);
        SetNetworkconnectedEventFlagID(1051569454, OFF);
        SetNetworkconnectedEventFlagID(11059304, ON);
        SetNetworkconnectedEventFlagID(11059206, ON);
        GotoIf(L20, mainGroupAbuse);
    }
L20:
    WaitFor(EventFlag(11059200));
    RestartEvent();
});

// NPC112金仮面の探究者_アイテム光_再訪 -- NPC112 Golden Masked Seeker_Item Light_Revisited
$Event(11053707, Restart, function() {
    EndIf(!PlayerIsInOwnWorld());
    EndIf(EventFlag(400500));
    EndIf(!EventFlag(9500));
    SetNetworkconnectedEventFlagID(11059305, ON);
    EndEvent();
});

// NPC351金仮面の従者_王都_灰_アイテム光 -- NPC351 Gold Masked Servant_Royal Capital_Ash_Item Light
$Event(11053708, Default, function(assetEntityId, actionButtonParameterId, itemLotId, eventFlagId, eventFlagId2, eventFlagId3, sfxId, eventFlagId4) {
    DisableNetworkSync();
    EndIf(!PlayerIsInOwnWorld());
    WaitFor(
        EventFlag(eventFlagId3)
            && EventFlag(eventFlagId4)
            && !AllBatchEventFlags(eventFlagId, eventFlagId2));
    if (Signed(sfxId) != 0) {
        CreateAssetfollowingSFX(assetEntityId, 90, sfxId);
    } else {
        CreateAssetfollowingSFX(assetEntityId, 90, 6101);
    }
    flag = !EventFlag(eventFlagId3) || AllBatchEventFlags(eventFlagId, eventFlagId2);
    WaitFor(ActionButtonInArea(actionButtonParameterId, assetEntityId) || flag);
    if (!flag.Passed) {
        DeleteAssetfollowingSFX(assetEntityId, true);
        AwardItemsIncludingClients(itemLotId);
        EzstateInstructionRequest(10000, 60070, 0);
        EndEvent();
    }
L0:
    DeleteAssetfollowingSFX(assetEntityId, true);
    RestartEvent();
});

// NPC324_百智卿_ボス戦開始会話 -- NPC324_Lord Hyakuchi_Boss battle start conversation
$Event(11053710, Restart, function(chrEntityId) {
    if (PlayerIsInOwnWorld()) {
        SetNetworkconnectedThisEventSlot(OFF);
    }
    WaitFor(ThisEventSlot());
    if (PlayerIsInOwnWorld()) {
        SetNetworkconnectedThisEventSlot(ON);
        SetNetworkconnectedEventFlagID(11050854, ON);
    }
L0:
    SetCharacterTeamType(chrEntityId, TeamType.Enemy);
});

// NPC318_混沌の宿主_白霊共闘許可フラグ立て -- NPC318_Host of Chaos_White Spirit Collaboration Permission Flag Set
$Event(11053720, Restart, function() {
    SetEventFlagID(11059350, OFF);
    WaitFixedTimeFrames(1);
    EndIf(!EventFlag(3631));
    EndIf(EventFlag(11050800));
    EndIf(!EventFlag(35000500));
    EndIf(EventFlag(3621));
    EndIf(EventFlag(1049539212));
    EndIf(EventFlag(116));
    SetEventFlagID(11059350, ON);
    EndEvent();
});

// NPC223亜人針子_NPC初期化イベント_入り口すぐの篝火近く_灰都 -- NPC223 Demi-Shipper_NPC initialization event_Near the bonfire right at the entrance_Haito
$Event(11053730, Restart, function(chrEntityId) {
    DisableNetworkSync();
    WaitFixedTimeFrames(1);
    if (PlayerIsInOwnWorld()) {
        if (EventFlag(3940)) {
            SetEventFlagID(1043379353, OFF);
        }
    }
L0:
    DisableCharacter(chrEntityId);
    SetCharacterBackreadState(chrEntityId, true);
    if (!EventFlag(3947)) {
        WaitFor(EventFlag(3947));
        RestartEvent();
    }
L5:
    GotoIf(L1, EventFlag(3940));
    GotoIf(L2, EventFlag(3941));
    GotoIf(L3, EventFlag(3942));
    GotoIf(L4, EventFlag(3943));
L1:
    if (!EventFlag(3957)) {
        if (!EventFlag(11109819)) {
            WaitFor(EventFlag(71122) && EventFlag(9000));
        }
    }
    SetCharacterBackreadState(chrEntityId, false);
    EnableCharacter(chrEntityId);
    ForceAnimationPlayback(chrEntityId, 930010, false, false, false);
    SetNetworkconnectedEventFlagID(11109819, ON);
    SetNetworkconnectedEventFlagID(3957, ON);
    Goto(L20);
L2:
    SetCharacterBackreadState(chrEntityId, false);
    EnableCharacter(chrEntityId);
    SetCharacterTeamType(chrEntityId, TeamType.HostileNPC);
    Goto(L20);
L3:
    SetCharacterBackreadState(chrEntityId, false);
    EnableCharacter(chrEntityId);
    SetCharacterTeamType(chrEntityId, TeamType.HostileNPC);
    Goto(L20);
L4:
    ForceCharacterTreasure(chrEntityId);
    DisableCharacter(chrEntityId);
    SetCharacterBackreadState(chrEntityId, true);
    Goto(L20);
L20:
    WaitFor(!EventFlag(3947));
    RestartEvent();
});

// NPC223亜人針子_母の声イベント -- NPC223 Demi-human seamstress_Mother's voice event
$Event(11053731, Restart, function(entityId) {
    EndIf(!PlayerIsInOwnWorld());
    EndIf(EventFlag(3943) || !EventFlag(3947) || EventFlag(1039409259));
    WaitFor(EntityInRadiusOfEntity(entityId, 20000, 4, 1) && CharacterHasSpEffect(20000, 9690));
    SetNetworkconnectedEventFlagID(1039402710, ON);
    EndEvent();
});

// Fake Radabeast Door
$Event(11053732, Restart, function(fogWallEntityId, radabeastId) {
    CreateAssetfollowingSFX(fogWallEntityId, 101, 1530);
    EndIf(EventFlag(radabeastId));
    WaitFor(ActionButtonInArea(9501, fogWallEntityId));
    ForceAnimationPlayback(10000, 67080, false, false, false);
    WaitFixedTimeSeconds(5.0);
    PlayCutsceneToPlayerAndWarp(19000040, CutscenePlayMode.SkippableWithWhiteFadeOut, 19002810, 19000000, 10000, 19000, false); 
});

$Event(11053733, Restart, function(regionId, warpDestinationId) {
    WaitFor(InArea(10000, regionId));
    IssueShortWarpRequest(10000, TargetEntityType.Asset, warpDestinationId, 100);
    SetCameraAngle(0, -70);
    RestartEvent();
});



