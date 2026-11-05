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
    $InitializeCommonEvent(0, 9005810, 19000800, 19000000, 19000950, 19001950, 8);
    $InitializeEvent(0, 19000100);
    $InitializeEvent(0, 19000110);
    $InitializeEvent(0, 19000120);
    $InitializeEvent(0, 19002500);
    $InitializeEvent(0, 19002502);
    $InitializeEvent(0, 19002682);
    $InitializeEvent(0, 19002800);
    $InitializeEvent(0, 19002810);
    $InitializeEvent(0, 19002811);
    $InitializeEvent(0, 19002812);
    $InitializeEvent(0, 19002830);
    $InitializeEvent(0, 19002849);
    $InitializeEvent(0, 19002900);
    
    $InitializeEvent(0, 19002910); //Initialized Event for Fake-Door Handoff
    $InitializeEvent(0, 19002911); // Custom BGM
    $InitializeEvent(0, 19002913); // Custom completion cleanup
    $InitializeEvent(0, 19002914); // Maintain battle flags
    
});

// プリコンストラクタ -- preconstructor
$Event(50, Default, function() {
    $InitializeEvent(0, 19000050);
});

// エンディング_メリナ -- Ending_Melina
$Event(19000100, Default, function() {
    if (!PlayerIsInOwnWorld()) {
        DisableAsset(19001100);
        DisableAsset(19001101);
        EndEvent();
    }
L0:
    EndIf(EventFlag(120));
    if (!(EventFlag(9400) || EventFlag(9401) || EventFlag(9402) || EventFlag(9403))) {
        DisableAsset(19001100);
        DisableAsset(19001101);
        WaitFor(EventFlag(19001100));
        //EnableAsset(19001100);
        //EnableAsset(19001101);
        DisableCharacter(19000810);
        DisableCharacterCollision(19000810);
        DisableAsset(19001810);
        EndIf(EventFlag(19000804));
        WaitFor(
            (!EventFlag(108) || (EventFlag(108) && EventFlag(116)))
                && (EventFlag(9400) || EventFlag(9401) || EventFlag(9402) || EventFlag(9403)));
        if (!((PlayerGender(Gender.Female) && !CharacterHasSpEffect(10000, 361000))
            || (PlayerGender(Gender.Male) && CharacterHasSpEffect(10000, 361000)))) {
            SetEventFlagID(780020, OFF);
            SetEventFlagID(780021, ON);
        } else {
            SetEventFlagID(780020, ON);
            SetEventFlagID(780021, OFF);
        }
    }
L15:
    SetEventFlagID(19000100, ON);
    SetEventFlagID(19002100, ON);
    GotoIf(L13, EventFlag(9403));
    GotoIf(L12, EventFlag(9402));
    GotoIf(L11, EventFlag(9401));
    PlayCutsceneToPlayerAndWarpWithStablePositionUpdate(19000010, CutscenePlayMode.SkippableWithWhiteFadeOut2, 11712500, 11710000, 10000, 19000, false, false);
    TriggerMultiplayerEvent(10);
    WaitFixedTimeRealFrames(1);
    Goto(L15);
L11:
    PlayCutsceneToPlayerAndWarpWithStablePositionUpdate(19000060, CutscenePlayMode.SkippableWithWhiteFadeOut2, 11712500, 11710000, 10000, 19000, false, false);
    TriggerMultiplayerEvent(20);
    WaitFixedTimeRealFrames(1);
    Goto(L15);
L12:
    PlayCutsceneToPlayerAndWarpWithStablePositionUpdate(19000070, CutscenePlayMode.SkippableWithWhiteFadeOut2, 11712500, 11710000, 10000, 19000, false, false);
    TriggerMultiplayerEvent(30);
    WaitFixedTimeRealFrames(1);
    Goto(L15);
L13:
    PlayCutsceneToPlayerAndWarpWithStablePositionUpdate(19000080, CutscenePlayMode.SkippableWithWhiteFadeOut2, 11712500, 11710000, 10000, 19000, false, false);
    TriggerMultiplayerEvent(40);
    WaitFixedTimeRealFrames(1);
    Goto(L15);
L15:
    NoOp();
});

// エンディング_ラニ -- Ending_Rani
$Event(19000110, Default, function() {
    EndIf(!PlayerIsInOwnWorld());
    EndIf(EventFlag(120));
    if (!(EventFlag(9404) || EventFlag(9405))) {
        WaitFor(
            EventFlag(19001100)
                && EventFlag(1034509406)
                && (!EventFlag(108) || (EventFlag(108) && EventFlag(116))));
        CreateAssetfollowingSFX(19001110, 100, 30070);
        WaitFor(ActionButtonInArea(9610, 19001110) && PlayerIsInOwnWorld());
    }
L15:
    if (!EventFlag(1034509407)) {
        PlayCutsceneToPlayer(19000020, CutscenePlayMode.Skippable, 10000);
        SetEventFlagID(9404, ON);
        TriggerMultiplayerEvent(50);
    } else {
        PlayCutsceneToPlayer(19000021, CutscenePlayMode.Skippable, 10000);
        SetEventFlagID(9405, ON);
        TriggerMultiplayerEvent(60);
    }
    WaitFixedTimeRealFrames(1);
    SetEventFlagID(120, ON);
    SetEventFlagID(6010, ON);
    AwardAchievement(2);
    SetPlayerRespawnPoint(11102020);
    SaveRequest();
    SetEventFlagID(21, ON);
});

// エンディング_狂い火 -- Ending_crazy fire
$Event(19000120, Default, function() {
    EndIf(!PlayerIsInOwnWorld());
    EndIf(EventFlag(120));
    if (!(EventFlag(9406) || EventFlag(9407))) {
        WaitFor(EventFlag(19001100));
        WaitFixedTimeFrames(1);
        WaitFor(EventFlag(108) && !EventFlag(116) && ActionButtonInArea(9620, 19001120));
        ForceAnimationPlayback(10000, 67070, false, false, false);
        WaitFixedTimeSeconds(10);
    }
L15:
    if (!EventFlag(109)) {
        PlayCutsceneToPlayer(19000030, CutscenePlayMode.Skippable, 10000);
        SetEventFlagID(9406, ON);
        TriggerMultiplayerEvent(70);
    } else {
        PlayCutsceneToPlayer(19000031, CutscenePlayMode.Skippable, 10000);
        SetEventFlagID(9407, ON);
        TriggerMultiplayerEvent(80);
    }
    WaitFixedTimeRealFrames(1);
    SetEventFlagID(120, ON);
    SetEventFlagID(6010, ON);
    AwardAchievement(3);
    SetPlayerRespawnPoint(11102020);
    SaveRequest();
    SetEventFlagID(22, ON);
});

// m19_00_00_00用初期フラグ設定 -- Initial flag setting for m19_00_00_00
$Event(19000050, Default, function() {
    EndIf(ThisEventSlot());
});

// 黄金樹の封印 -- Seal of the Golden Tree
$Event(19002500, Default, function() {
    if (EventFlag(19000800)) {
        CreateAssetfollowingSFX(19001500, 101, 1530);
        EndEvent();
    }
L0:
    if (!PlayerIsInOwnWorld()) {
        if (EventFlag(19002801)) {
            WarpCharacterAndCopyFloorWithFadeout(20000, TargetEntityType.Area, 19002811, -1, 20000, false, true);
            EndEvent();
        }
    }
L1:
    CreateAssetfollowingSFX(19001500, 101, 1530);
    GotoIf(S0, PlayerIsInOwnWorld());
    GotoIf(L2, EventFlag(19002500));
S0:
    WaitFor(PlayerIsInOwnWorld() && !EventFlag(19000800) && ActionButtonInArea(9501, 19001500));
    if (PlayerIsInOwnWorld()) {
        SendInvadingPhantomsHome(0);
    }
    EndIf(
        CharacterInvadeType(20000, 2)
            || CharacterInvadeType(20000, 3)
            || CharacterInvadeType(20000, 4)
            || CharacterInvadeType(20000, 5)
            || CharacterInvadeType(20000, 7));
    ForceAnimationPlayback(10000, 67080, false, false, false);
    GotoIf(S1, PlayerIsInOwnWorld());
    GotoIf(L2, EventFlag(19002500));
S1:
    WaitFixedTimeSeconds(2.4);
    CreateAssetfollowingSFX(19001501, 101, 1531);
    GotoIf(S2, PlayerIsInOwnWorld());
    GotoIf(L2, EventFlag(19002500));
S2:
    WaitFixedTimeSeconds(3.6);
    SetNetworkconnectedEventFlagID(19002500, ON);
L2:
    SetEventFlagID(9021, ON);
    if (PlayerIsInOwnWorld()) {
        PlayCutsceneToPlayerAndWarp(19000040, CutscenePlayMode.SkippableWithWhiteFadeOut, 19002810, 19000000, 10000, 19000, false);
    } else {
        PlayCutsceneToPlayerAndWarp(19000040, CutscenePlayMode.SkippableWithWhiteFadeOut, 19002811, 19000000, 10000, 19000, false);
    }
    WaitFixedTimeRealFrames(1);
    if (!EventFlag(119)) {
        SetEventFlagID(119, ON);
    }
    DeleteAssetfollowingSFX(19001501, false);
    if (PlayerIsInOwnWorld()) {
        SetCameraAngle(13.06, -63.07);
    }
});

// 黄金樹の篝火 -- golden tree bonfire
$Event(19002502, Restart, function() {
    EndIf(!PlayerIsInOwnWorld());
    EndIf(EventFlag(71900));
    EndIf(EventFlag(121));
    WaitFor(PlayerInMap(19, 0, 0, 0) && EventFlag(9123) && !EventFlag(71900) && !EventFlag(121));
    SetSpEffect(10000, 4280);
    SetSpEffect(10000, 4282);
    WaitFor(EventFlag(71900));
    SetSpEffect(10000, 4281);
    SetSpEffect(10000, 4283);
});

// 血痕救済_クリア後 -- Bloodstain Relief_After Clearing
$Event(19002682, Restart, function() {
    EndIf(!PlayerIsInOwnWorld());
    EndIf(!EventFlag(121));
    MoveBloodstainAndDroppedItems(19002682, 19002683);
});


// ラスボス撃破 -- Defeat the final boss
$Event(19002800, Restart, function() {
    if (!(PlayerIsInOwnWorld() && InArea(10000, 19002815) && EventFlag(19000804))) {
        EndIf(EventFlag(19000804));
        if (!EventFlag(19000800)) {
            WaitFor(CharacterHPValue(19000800) <= 0);
            WaitFixedTimeSeconds(4);
            PlaySE(19008000, SoundType.SFX, 888880000);
            ChangeCamera(-1, -1);
            WaitFor(CharacterDead(19000800));
            WaitFixedTimeSeconds(4.5);
            HandleBossDefeatAndDisplayBanner(19000800, TextBannerType.GodSlain);
            SetEventFlagID(19000800, ON);
            SetEventFlagID(19001100, ON);
            SetEventFlagID(9123, ON);
            EndIf(!PlayerIsInOwnWorld());
            SetEventFlagID(61123, ON);
            SetPlayerRespawnPoint(19002814);
            SaveRequest();
            WaitFixedTimeSeconds(7.5);
            EndIf(HPRatio(10000) == 0);
            WaitFor(
                !CharacterHasSpEffect(10000, 19997)
                    && !CharacterHasSpEffect(10000, 19998)
                    && !CharacterHasSpEffect(10000, 19999));
        }
    }
L0:
    SetEventFlagID(9021, ON);
    PlayCutsceneToPlayerAndWarp(19000050, CutscenePlayMode.Skippable, 19002814, 19000000, 10000, 19000, false);
    WaitFixedTimeRealFrames(1);
    SetCameraAngle(20.9, -51.56);
    SetPlayerPositionDisplay(Enabled, true, 19, 0, 0, 0, 181.1, 102.35, -607.06);
    SetPlayerRespawnPoint(19002814);
    SaveRequest();
    MoveBloodstainAndDroppedItems(19002680, 19002681);
    SetEventFlagID(19000804, ON);
    SetSpEffect(10000, 191);
    DisableCharacterDefaultBackread(35000);
    SetNetworkUpdateRate(35000, true, CharacterUpdateFrequency.AtLeastEvery5Frames);
});

// ラスボス出現 -- Last boss appears
$Event(19002810, Restart, function() {
    if (EventFlag(19000800)) {
        DisableCharacter(19005800);
        DisableCharacterCollision(19005800);
        ForceCharacterDeath(19005800, false);
        DisableCharacter(19000811);
        DisableCharacterCollision(19000811);
        DisableAsset(19001810);
        EndEvent();
    }
L0:
    DisableCharacterAI(19005800);
    DisableCharacter(19000810);
    DisableCharacterCollision(19000810);
    DisableCharacterFadeOnEnable(19000810);
    DisableAsset(19001810);
    WaitFor(PlayerIsInOwnWorld() && EntityInRadiusOfEntity(10000, 19000810, 20, 1));
    if (PlayerIsInOwnWorld()) {
        SetCameraAngle(14.6, -72.33);
    }
    SetNetworkconnectedEventFlagID(19000801, ON);
    SetNetworkconnectedEventFlagID(19002801, ON);
    SetNetworkconnectedEventFlagID(19002806, ON);
    DisableAsset(19001810);
    Goto(L2);
L1:
L2:
    EnableCharacter(19000810);
    EnableCharacterCollision(19000810);
    ForceAnimationPlayback(19000810, 20010, false, false, false);
    EnableCharacterAI(19000810);
    SetNetworkUpdateRate(19000810, true, CharacterUpdateFrequency.AlwaysUpdate);
    DisplayBossHealthBar(Enabled, 19000810, 0, 902190000);
});

// ラスボス激昂 -- Last boss rage
$Event(19002811, Restart, function() {
    EndIf(EventFlag(19000800));
    WaitFor(CharacterDead(19000810));
    WaitFixedTimeSeconds(3);
    SetEventFlagID(19002802, ON);
    SetEventFlagID(19000802, ON);
});

// ラスボス覚醒 -- Last boss awakening
$Event(19002812, Restart, function() {
    EndIf(EventFlag(19000800));
    if (!ThisEventSlot()) {
        DisableCharacterHPBarDisplay(19000800);
        WaitFor(
            (PlayerIsInOwnWorld() && EventFlag(19002802))
                || HasDamageType(19000800, 10000, DamageType.Unspecified));
        SetPlayerPositionDisplay(Disabled, true, 19, 0, 0, 0, 181.1, 102.35, -607.06);
        if (PlayerIsInOwnWorld()) {
            PlayCutsceneToPlayerAndWarp(19000000, CutscenePlayMode.Skippable, 19002812, 19000000, 10000, 0, false);
        } else {
            PlayCutsceneToPlayerAndWarp(19000000, CutscenePlayMode.Skippable, 19002813, 19000000, 10000, 0, false);
        }
        WaitFixedTimeRealFrames(1);
        if (PlayerIsInOwnWorld()) {
            SetCameraAngle(-11.33, -25.83);
        }
        if (PlayerIsInOwnWorld()) {
            SetNetworkconnectedEventFlagID(19002803, ON);
        }
        if (PlayerIsInOwnWorld()) {
            SetNetworkconnectedThisEventSlot(ON);
        }
    }
L0:
    EnableCharacterDefaultBackread(35000);
    SetNetworkUpdateRate(35000, true, CharacterUpdateFrequency.AtLeastEvery5Frames);
    WarpCharacterAndCopyFloor(35000, TargetEntityType.Area, 19002813, -1, 19000800);
    WarpCharacterAndCopyFloor(19000130, TargetEntityType.Area, 19002813, -1, 19000800);
    SetCharacterTalkRange(19000130, 200);
    EnableCharacter(19000800);
    EnableCharacterCollision(19000800);
    EnableCharacterAI(19005800);
    ForceAnimationPlayback(19000800, 20000, false, false, false);
    DisplayBossHealthBar(Enabled, 19000800, 0, 902200000);
    ChangeCamera(2200, 2200);
    WaitFixedTimeRealFrames(1);
    AttachAssetToCharacter(19000130, 10, 19001130);
});

// ラスボス星雲ワープ設定 -- Last boss nebula warp setting
$Event(19002820, Restart, function() {
    EndIf(!PlayerIsInOwnWorld());
    EndIf(EventFlag(19000800));
    WaitFor(!AnyBatchEventFlags(19002830, 19002834) && CharacterHasSpEffect(19000800, 18600));
    RandomlySetEventFlagInRange(19002830, 19002834, ON);
    WaitFixedTimeSeconds(3);
    RestartEvent();
});

// ラスボス星雲ワープ実行 -- Last boss nebula warp execution
$Event(19002821, Restart, function() {
    EndIf(EventFlag(19000800));
    $InitializeEvent(0, 19002822, 19002830, 110, 111, 112, 113);
    $InitializeEvent(1, 19002822, 19002831, 111, 112, 113, 114);
    $InitializeEvent(2, 19002822, 19002832, 112, 113, 114, 115);
    $InitializeEvent(3, 19002822, 19002833, 113, 114, 115, 116);
    $InitializeEvent(4, 19002822, 19002834, 114, 115, 116, 117);
});

// ラスボス星雲ワープ実行_XX -- Last boss nebula warp execution_XX
$Event(19002822, Restart, function(eventFlagId, dummypolyId, dummypolyId2, dummypolyId3, dummypolyId4) {
    EndIf(EventFlag(19000800));
    WaitFor(PlayerIsInOwnWorld() && EventFlag(eventFlagId));
    IssueShortWarpRequest(19000801, TargetEntityType.Character, 19000800, dummypolyId);
    IssueShortWarpRequest(19000802, TargetEntityType.Character, 19000800, dummypolyId2);
    IssueShortWarpRequest(19000803, TargetEntityType.Character, 19000800, dummypolyId3);
    IssueShortWarpRequest(19000804, TargetEntityType.Character, 19000800, dummypolyId4);
    ForceAnimationPlayback(19000800, 3023, false, false, true);
    ForceAnimationPlayback(19000801, 3000, false, false, true);
    ForceAnimationPlayback(19000802, 3000, false, false, true);
    ForceAnimationPlayback(19000803, 3000, false, false, true);
    ForceAnimationPlayback(19000804, 3000, false, false, true);
    WaitFixedTimeSeconds(2);
    SetEventFlagID(eventFlagId, OFF);
    RestartEvent();
});

// ラスボス天の輪カメラ変更 -- Last boss sky ring camera change
$Event(19002830, Restart, function() {
    DisableNetworkSync();
    EndIf(EventFlag(19000800));
    WaitFor(CharacterHasSpEffect(19000800, 18606));
    ChangeCamera(2201, 2201);
    WaitFor(!CharacterHasSpEffect(19000800, 18606));
    ChangeCamera(2200, 2200);
    RestartEvent();
});

// ラスボス_イベント起動 -- Last boss_event activation
//$Event(19002849, Restart, function() {
//    $InitializeCommonEvent(0, 9005800, 19000800, 19001800, 19002800, 19002805, 19005800, 10000, 19002801, 0);
//    $InitializeCommonEvent(0, 9005801, 19000800, 19001800, 19002800, 19002805, 19002806, 10000);
//    $InitializeCommonEvent(0, 9005811, 19000800, 19001800, 5, 19002801);
//    $InitializeCommonEvent(0, 9005822, 19000800, 219000, 19002805, 19002806, 0, 19002803, 0, 1);
//});

// Final boss common-event setup
$Event(19002849, Restart, function() {
    if (EventFlag(11053735)) {
        // The custom entrance uses custom battle/BGM events.
        EndEvent();
    }

    // Original Erdtree entrance.
    $InitializeCommonEvent(
        0,
        9005800,
        19000800,
        19001800,
        19002800,
        19002805,
        19005800,
        10000,
        19002801,
        0
    );

    $InitializeCommonEvent(
        0,
        9005801,
        19000800,
        19001800,
        19002800,
        19002805,
        19002806,
        10000
    );

    $InitializeCommonEvent(
        0,
        9005811,
        19000800,
        19001800,
        5,
        19002801
    );

    $InitializeCommonEvent(
        0,
        9005822,
        19000800,
        219000,
        19002805,
        19002806,
        0,
        19002803,
        0,
        1
    );
});



// 供犠台ワープ -- sacrificial stand warp
$Event(19002900, Restart, function() {
    CreateAssetfollowingSFX(19001900, 100, 1300);
    WaitFor(ActionButtonInArea(9000, 19001900));
    WarpCharacterAndCopyFloorWithFadeout(10000, TargetEntityType.Area, 19002900, -1, 10000, false, false);
});

// Fake Radabeast entrance handoff
$Event(19002910, Restart, function() {
    EndIf(EventFlag(19000800));

    WaitFor(
        PlayerIsInOwnWorld()
            && PlayerInMap(19, 0, 0, 0)
            && EventFlag(11053734)
            && EventFlag(11053735)
    );

    // Keep battle mode active through both phases.
    SetNetworkconnectedEventFlagID(19002805, ON);

    // Only clear the one-time handoff.
    SetNetworkconnectedEventFlagID(11053734, OFF);

    // Do not clear 11053735 or 19002805 here.
});

// Custom Radagon and Elden Beast BGM
$Event(19002911, Restart, function() {
    DisableNetworkSync();

    EndIf(EventFlag(19000800));

    WaitFor(
        PlayerIsInOwnWorld()
            && EventFlag(11053735)
            && EventFlag(19002805)
            && EventFlag(19002806)
            && !EventFlag(19000800)
    );

    // Begin Radagon BGM.
    SetBossBGM(219000, BossBGMState.Start);

    // Wait for the Elden Beast phase or fight completion.
    WaitFor(
        EventFlag(19002803)
            || EventFlag(19000800)
            || !EventFlag(11053735)
    );

    if (EventFlag(19000800) || !EventFlag(11053735)) {
        SetBossBGM(219000, BossBGMState.Stop1);
        EndEvent();
    }

    // Reassert the BGM after the phase-transition cutscene.
    WaitFixedTimeRealFrames(1);
    SetBossBGM(219000, BossBGMState.HeatUp);
    
    WaitFor(
        EventFlag(19000800)
            || !EventFlag(11053735)
    );

    SetBossBGM(219000, BossBGMState.Stop1);
});

// Clear custom Radabeast mode after completion
$Event(19002913, Restart, function() {
    EndIf(!EventFlag(11053735));

    WaitFor(EventFlag(19000800));

    SetBossBGM(219000, BossBGMState.Stop1);

    SetNetworkconnectedEventFlagID(19002805, OFF);
    SetNetworkconnectedEventFlagID(19002806, OFF);

    SetNetworkconnectedEventFlagID(11053734, OFF);
    SetNetworkconnectedEventFlagID(11053735, OFF);
});

// Maintain custom Radabeast battle state
$Event(19002914, Restart, function() {
    EndIf(EventFlag(19000800));

    WaitFor(
        PlayerIsInOwnWorld()
            && EventFlag(11053735)
            && !EventFlag(19000800)
    );

    SetNetworkconnectedEventFlagID(19002805, ON);
    SetNetworkconnectedEventFlagID(19002806, ON);

    WaitFixedTimeSeconds(0.5);

    RestartEvent();
});
