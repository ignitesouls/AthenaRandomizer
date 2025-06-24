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
    $InitializeEvent(0, 10012682);
    $InitializeEvent(0, 10012800);
    $InitializeEvent(0, 10012810);
    $InitializeEvent(0, 10012811);
    $InitializeEvent(0, 10012849);
    $InitializeEvent(0, 10012500);
    $InitializeEvent(0, 10010790);
    $InitializeEvent(0, 10010791);
    $InitializeEvent(0, 10010792);
    $InitializeEvent(0, 10014242);
});

// プリコンストラクタ -- preconstructor
$Event(50, Default, function() {
    SetCharacterBackreadState(10011700, true);
    $InitializeEvent(0, 10010020);
    $InitializeEvent(0, 10010030);
    $InitializeEvent(0, 10010031);
    $InitializeEvent(0, 10012502);
    $InitializeEvent(0, 10012560);
    EndIf(!PlayerIsInOwnWorld());
    EndIf(!EventFlag(100));
    EndIf(EventFlag(102));
    EndIf(!PlayerInMap(10, 1, 0, 0));
    SetCurrentTime(23, 45, 0, false, false, false, 0, 0, 0);
});

// initialization
$Event(10014242, Default, function() {
    EndIf(ThisEventSlot());
    
    const initialFlags = [
        62000, // Allow Map Display
        82001, // Show underground
        62010, // Limgrave, West
        62011, // Weeping Peninsula
        62012, // Limgrave, East
        62022, // Liurnia, West
        62021, // Liurnia, North
        62020, // Liurnia, East
        62031, // Leyndell, Royal Capital
        62030, // Altus Plateur
        62032, // Mt. Gelmir
        62041, // Dragonbarrow
        62040, // Caelid
        62052, // Mountaintops of the Giants, North
        62051, // Mountaintops of the Giants, East
        62050, // Mountaintops of the Giants, West
        62063, // Siofra River
        62062, // Mohgwyn Palace
        62061, // Lake of Rot
        62060, // Ainsel River
        62064, // Deeprooth Depths
        62103, // Stormfoot Catacombs
        62102, // Fringefolk Hero's Cave
    ];
    
    for (let i = 0; i < initialFlags.length; i++) {
        SetEventFlagID(initialFlags[i], ON);   
    }
    
    // give lantern
    DirectlyGivePlayerItem(ItemType.Goods, 2070, 6001, 1);
    
    SetThisEventSlot(ON);
});

// ゲーム開始 -- game start
$Event(10010020, Restart, function() {
    EndIf(ThisEventSlot());
    EndIf(!PlayerInMap(10, 1, 0, 0));
    DisableAreaWelcomeMessage();
    ForceAnimationPlayback(10000, 0, false, false, false);
    SetWindSFX(-1);
    SetCharacterFaceParamOverride(10000, 0, -1);
    SetCharacterFaceParamOverride(10000, 1, -1);
    PlayCutsceneToPlayerWithWeatherAndTime(10000040, CutscenePlayMode.Skippable, 10000, false, Weather.Default, 0, true, 23, 45, 0);
    WaitFixedTimeRealFrames(1);
L0:
    SetPlayerRespawnPoint(10012020);
    SaveRequest();
    SetThisEventSlot(ON);
    SetEventFlagID(100, ON);
});

// ゲーム開始_海中転落 -- Game start_Falling into the sea
$Event(10010030, Default, function() {
    EndIf(ThisEventSlot() && EventFlag(101));
    EndIf(!PlayerInMap(10, 1, 0, 0));
    hp = CharacterHPValue(10010800) > 0 && CharacterHPValue(10000) == 1;
    chr = CharacterDead(10000);
    WaitFor(PlayerIsInOwnWorld() && EventFlag(10010801) && (hp || chr));
    SetPlayerRespawnPoint(18002020);
    SaveRequest();
    DisableTextOnLoadingScreen();
    EndIf(chr.Passed);
    if (!ThisEventSlot()) {
        WaitFixedTimeSeconds(1);
    }
    SetSpEffect(10000, 4790);
    SetEventFlagID(9021, ON);
    SetBossBGM(920900, BossBGMState.Stop2);
    PlayCutsceneToPlayerAndWarpWithWeatherAndTime(10010000, CutscenePlayMode.Skippable, 18002020, 18000000, 10000, 10010, false, true, Weather.Default, -1, true, 10, 30, 0);
    WaitFixedTimeRealFrames(1);
});

// ゲーム開始_不死設定 -- Game start_immortality settings
$Event(10010031, Default, function() {
    EndIf(!PlayerInMap(10, 1, 0, 0));
    EndIf(EventFlag(101));
    WaitFor(PlayerIsInOwnWorld() && EventFlag(10012805));
    EnableCharacterImmortality(10000);
    WaitFor(!InArea(10000, 10012031) || CharacterDead(10010800));
    DisableCharacterImmortality(10000);
});

// 落ちる床 -- falling floor
$Event(10012500, Restart, function() {
    if (EventFlag(10010500)) {
        DisableAsset(10011500);
        DisableAsset(10011501);
        EndEvent();
    }
L0:
    WaitFor(InArea(10000, 10012500));
    RequestAssetDestruction(10011500, 1);
    SetEventFlagID(10010500, ON);
});

// 黄金樹の歓迎 -- Golden Tree Welcome
$Event(10012501, Restart, function() {
    EndIf(!PlayerIsInOwnWorld());
    EndIf(!EventFlag(100));
    EndIf(EventFlag(102));
    EndIf(!PlayerInMap(10, 1, 0, 0));
    SetWindSFX(808004);
    SetSpEffect(10000, 4200);
});

// 地名表示 -- Place name display
$Event(10012502, Restart, function() {
    EndIf(!PlayerIsInOwnWorld());
    EndIf(EventFlag(10010502));
    EndIf(!PlayerInMap(10, 1, 0, 0));
    DisableAreaWelcomeMessage();
    WaitFor(PlayerIsInOwnWorld() && !InArea(10000, 10012502));
    EnableAreaWelcomeMessage();
    DisplayAreaWelcomeMessage(10010);
    SetEventFlagID(10010502, ON);
});

// 閉じた扉 -- closed door
$Event(10012504, Restart, function() {
    EndIf(EventFlag(10018540));
    EndIf(EventFlag(60210));
    DisableObjAct(10011540, -1);
    WaitFor(EventFlag(60210));
    EnableObjAct(10011540, -1);
});

// 来訪時扉開放 -- Door open when visiting
$Event(10012560, Restart, function() {
    if (!EventFlag(10018560)) {
        WaitFor(PlayerIsInOwnWorld() && EventFlag(102));
        SetEventFlagID(10018560, ON);
    }
L0:
    DisableObjActAssignIdx(10011560, 2219000, 0);
    DisableObjActAssignIdx(10011560, 2219000, 1);
    DisableObjActAssignIdx(10011560, 2219000, 2);
    DisableObjActAssignIdx(10011560, 2219000, 3);
});

// チュートリアル_移動 -- Tutorial_Move
$Event(10012680, Restart, function() {
    DisableNetworkSync();
    EndIf(EventFlag(18000020));
    WaitFor(PlayerIsInOwnWorld() && EventFlag(10010020) && InArea(10000, 10012680));
    SetEventFlagID(710000, ON);
    ShowTutorialPopup(1000, true, true);
    WaitFor(!InArea(10000, 10012680));
    ShowTutorialPopup(1000, false, true);
});

// チュートリアル_カメラ -- Tutorial_Camera
$Event(10012682, Restart, function() {
    DisableNetworkSync();
    EndIf(EventFlag(18000020));
    WaitFor(PlayerIsInOwnWorld() && InArea(10000, 10012682));
    SetEventFlagID(710000, ON);
    ShowTutorialPopup(1000, true, true);
});

// チュートリアルボス撃破 -- Defeat the tutorial boss
$Event(10012800, Restart, function() {
    EndIf(EventFlag(10010800));
    WaitFor(CharacterHPValue(10010800) <= 0);
    WaitFixedTimeSeconds(4);
    PlaySE(10018000, SoundType.SFX, 888880000);
    WaitFor(CharacterDead(10010800));
    HandleBossDefeatAndDisplayBanner(10010800, TextBannerType.EnemyFelled);
    SetEventFlagID(10010800, ON);
    SetEventFlagID(9103, ON);
    if (PlayerIsInOwnWorld()) {
        SetEventFlagID(61103, ON);
    }
});

// チュートリアルボス出現 -- Tutorial boss appears
$Event(10012810, Restart, function() {
    if (EventFlag(10010800)) {
        DisableCharacter(10010800);
        DisableCharacterCollision(10010800);
        ForceCharacterDeath(10010800, false);
        EndEvent();
    }
L0:
    DisableCharacterAI(10010800);
    if (!EventFlag(10010801)) {
        ForceAnimationPlayback(10010800, 30003, false, false, false);
        DisableCharacterHPBarDisplay(10010800);
        WaitFor(
            (PlayerIsInOwnWorld() && InArea(10000, 10012801))
                || HasDamageType(10010800, 10000, DamageType.Unspecified));
        SetNetworkconnectedEventFlagID(10010801, ON);
        SetNetworkUpdateRate(10010800, true, CharacterUpdateFrequency.AlwaysUpdate);
        ForceAnimationPlayback(10010800, 20003, false, false, false);
        WaitFixedTimeSeconds(4);
    } else {
L1:
        DisableCharacterCollision(10010800);
        IssueShortWarpRequest(10010800, TargetEntityType.Area, 10012810, -1);
        WaitFor(EventFlag(10012805) && InArea(10000, 10012800));
        EnableCharacterCollision(10010800);
    }
L2:
    SetNetworkUpdateRate(10010800, true, CharacterUpdateFrequency.AlwaysUpdate);
    EnableCharacterAI(10010800);
    DisplayBossHealthBar(Enabled, 10010800, 0, 904690000);
    EndIf(EventFlag(10010030));
    SetSpEffect(10000, 4290);
});

// チュートリアルボス激昂 -- Tutorial boss rage
$Event(10012811, Restart, function() {
    EndIf(EventFlag(10010800));
    WaitFor(CharacterHasSpEffect(10010800, 16265));
    SetEventFlagID(10012802, ON);
});

// チュートリアルボスイベント起動 -- Tutorial boss event starts
$Event(10012849, Restart, function() {
    if (!EventFlag(101)) {
        $InitializeCommonEvent(0, 9005800, 10010800, 10011800, 10012800, 10012805, 10015800, 10000, 10010801, 10012801);
    } else {
        $InitializeCommonEvent(0, 9005800, 10010800, 10011801, 10012800, 10012805, 10015800, 10000, 10010801, 10012801);
    }
    $InitializeCommonEvent(0, 9005801, 10010800, 10011801, 10012800, 10012805, 10012806, 10000);
    $InitializeCommonEvent(0, 9005811, 10010800, 10011800, 16, 10010801);
    $InitializeCommonEvent(0, 9005811, 10010800, 10011801, 16, 0);
    $InitializeCommonEvent(0, 9005822, 10010800, 920900, 10012805, 10012806, 0, 10012802, 0, 0);
});

// NPC338_力尽き倒れている巫女_倒れと当たり無効 -- NPC338_The shrine maiden who has exhausted her strength and has fallen down_Isn't possible to hit and fall down
$Event(10010790, Restart, function() {
    SetCharacterBackreadState(10011700, false);
    EnableCharacter(10011700);
    ForceAnimationPlayback(10011700, 90100, false, false, false);
    DisableCharacterCollision(10011700);
});

// NPC338_力尽き倒れている巫女_布を血で染める -- NPC338_The shrine maiden is exhausted and has fallen down_Dyeing the cloth with blood
$Event(10010791, Restart, function() {
    EndIf(!PlayerIsInOwnWorld());
    EndIf(EventFlag(400033));
    EndIf(!EventFlag(400031));
    WaitFor(ActionButtonInArea(6471, 10011700));
    RemoveItemFromPlayer(ItemType.Goods, 8154, 1);
    AwardItemLot(100330);
    EndEvent();
});

// ショップラインナップ_空壺先食い -- Shop lineup_Empty pot first eating
$Event(10010792, Restart, function() {
    EndIf(!PlayerIsInOwnWorld());
    EndIf(!EventFlag(50));
    EndIf(EventFlag(10019200));
    WaitFor(PlayerHasItem(ItemType.Goods, 9500) || ElapsedSeconds(5));
    WaitFixedTimeFrames(1);
    if (PlayerHasItem(ItemType.Goods, 9500)) {
        SetEventFlagID(66150, ON);
        SetEventFlagID(66170, ON);
        SetEventFlagID(66180, ON);
    }
    SetEventFlagID(10019200, ON);
    EndEvent();
});

// フレームカウント -- frame count
$Event(10012900, Default, function() {
    WaitFor(EventFlag(10010900));
    IncrementEventValue(10010910, 32, 999999999);
    RestartEvent();
});


