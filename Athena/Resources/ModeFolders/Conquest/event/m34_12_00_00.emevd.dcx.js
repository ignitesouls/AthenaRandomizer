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
    RegisterBonfire(34120000, 34121950, 0, 0, 0, 5);
    RegisterBonfire(34120001, 34121951, 0, 0, 0, 5);
    RegisterBonfire(34120002, 34121952, 0, 0, 0, 5);
    $InitializeEvent(0, 34122800);
    $InitializeEvent(0, 34122810);
    $InitializeEvent(0, 34122811);
    $InitializeEvent(0, 34122849);
    $InitializeEvent(0, 34122510);
    $InitializeEvent(0, 34122515);
    $InitializeCommonEvent(0, 90005501, 34120510, 34120511, 0, 34121510, 34121511, 34121512, 34120512);
    $InitializeCommonEvent(0, 90005508, 34120515, 34121515, 0, 34121515, 34121516, 34121517, 34120516);
    $InitializeEvent(0, 34122580);
    $InitializeCommonEvent(0, 90005646, 34120800, 34122840, 34122841, 34121840, 34122840, 34, 12, 0, 0);
    $InitializeCommonEvent(0, 900005610, 34121680, 100, 800, 0);
    $InitializeCommonEvent(0, 90005560, 34120650, 34121650, 0);
    $InitializeCommonEvent(0, 90005525, 34120590, 34121590);
    $InitializeCommonEvent(0, 90005525, 34120591, 34121591);
    $InitializeCommonEvent(0, 90005525, 34120592, 34121592);
    $InitializeCommonEvent(0, 90005525, 34120593, 34121593);
    $InitializeCommonEvent(0, 90005525, 34120594, 34121594);
    $InitializeCommonEvent(0, 90005110, 194, 9122, 34121599, 34120500, 8151, 806936, 9083, 60523, 0);
    $InitializeEvent(0, 32012200, 34120301, 30000, 20000, 16572, 0, 0, 0, 0, 0, 34121600, 34121601, 0, 0);
    $InitializeEvent(1, 32012200, 34120302, 30002, 20002, 16574, 0, 0, 0, 0, 0, 34121602, 0, 0, 0);
    $InitializeEvent(2, 32012200, 34120303, 30000, 20000, 16572, 0, 0, 0, 0, 0, 34121603, 34121604, 0, 0);
    $InitializeEvent(3, 32012200, 34120304, 30000, 20000, 16572, 0, 0, 0, 0, 0, 34121610, 0, 0, 0);
    $InitializeEvent(0, 34122400, 34120200, 34122200);
    // New Teleporter to top of Tower
    $InitializeCommonEvent(0, 90005605, 34120959, 34, 12, 0, 0, 34102610, 0, 34121691, 34121692, 34121693, 0, 0, 0, 0);
});

// プリコンストラクタ -- preconstructor
$Event(50, Default, function() {
    $InitializeEvent(0, 34120519);
    $InitializeCommonEvent(0, 90005250, 34120203, 34122201, 0.5, 3020);
    $InitializeCommonEvent(0, 90005251, 34120203, 2, 0, -1);
    $InitializeCommonEvent(0, 90005261, 34120210, 34122210, 8, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34120211, 34122211, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34120212, 34122211, 0, -1);
    $InitializeCommonEvent(0, 90005251, 34120213, 16, 0, 3020);
    $InitializeCommonEvent(0, 90005250, 34120215, 34122210, 0.5, 3020);
    $InitializeCommonEvent(0, 90005261, 34120216, 34122216, 15, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34120250, 34122250, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34120251, 34122250, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34120255, 34122255, 0.2, -1);
    $InitializeCommonEvent(0, 90005250, 34120256, 34122255, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34120257, 34122255, 0.5, -1);
    $InitializeCommonEvent(0, 90005250, 34120258, 34122258, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34120259, 34122258, 1, -1);
    $InitializeCommonEvent(0, 90005250, 34120260, 34122260, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34120261, 34122261, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34120262, 34122263, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34120263, 34122263, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34120264, 34122263, 0, -1);
    $InitializeCommonEvent(0, 90005260, 34120265, 34122265, 5, 0, -1);
    $InitializeCommonEvent(0, 90005260, 34120266, 34122265, 5, 0, -1);
    $InitializeCommonEvent(0, 90005260, 34120267, 34122265, 5, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34120268, 34122268, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34120270, 34122270, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34120271, 34122270, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34120272, 34122270, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34120273, 34122270, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34120300, 34122300, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34120305, 34122305, 0, -1);
    $InitializeCommonEvent(0, 90005250, 34120350, 34122350, 0, -1);
});

// エレベータイベント起動 -- Elevator event activation
$Event(34122510, Default, function() {
    $InitializeCommonEvent(0, 90005500, 34120510, 34120511, 0, 34121510, 34121511, 34123511, 34121512, 34123512, 34122511, 34122512, 34120512, 34120513, 0);
});

// エレベータイベント起動_神の塔 -- Elevator event activation_Tower of God
$Event(34122515, Default, function() {
    $InitializeCommonEvent(0, 90005507, 34120515, 34121515, 0, 34121515, 34121516, 34122518, 34121517, 34122519, 34122516, 34122517, 34120516, 34122517, 0);
});

// エレベータ初期フラグ -- Elevator initial flag
$Event(34120519, Default, function() {
    EndIf(ThisEventSlot());
    SetEventFlagID(34120510, ON);
    SetThisEventSlot(ON);
});

// 梯子登録 -- ladder registration
$Event(34122580, Restart, function() {
    RegisterLadder(34120530, 34120531, 34121530);
});

// 亡者鉱夫_採掘中止_XX -- Dead Miner_Mining Canceled_XX
$Event(32012200, Restart, function(chrEntityId, animationId, animationId2, spEffectId, timeSeconds, value, value2, value3, value4, assetEntityId, assetEntityId2, assetEntityId3, assetEntityId4) {
    EndIf(ThisEventSlot());
    if (value != 0) {
        DisableCharacterGravity(chrEntityId);
        SetCharacterMaphit(chrEntityId, false);
    }
    ForceAnimationPlayback(chrEntityId, animationId, true, false, false);
    chrSp = (CharacterType(10000, TargetType.BlackPhantom) && CharacterHasSpEffect(10000, 3710))
        || CharacterType(10000, TargetType.Alive)
        || CharacterType(10000, TargetType.GrayPhantom)
        || CharacterType(10000, TargetType.WhitePhantom);
    assetChrSp &= (AssetDestroyed(assetEntityId)
        || AssetDestroyed(assetEntityId2)
        || AssetDestroyed(assetEntityId3)
        || AssetDestroyed(assetEntityId4))
        && CharacterBackreadStatus(chrEntityId)
        && (CharacterHasSpEffect(chrEntityId, 5080) || CharacterHasSpEffect(chrEntityId, 5450));
    if (!(value2 == 0 && value3 == 0 && value4 == 0)) {
        if (value2 != 0) {
            chr |= CharacterAIState(chrEntityId, AIStateType.Combat);
        }
        if (value3 != 0) {
            chr |= CharacterAIState(chrEntityId, AIStateType.ActiveAlert);
        }
        if (value4 != 0) {
            chr |= CharacterAIState(chrEntityId, AIStateType.PassiveAlert);
        }
        assetChrSp &= chr;
    }
L9:
    sp = CharacterHasSpEffect(chrEntityId, 481)
        && !CharacterHasSpEffect(chrEntityId, 90100)
        && !CharacterHasSpEffect(chrEntityId, 90110)
        && !CharacterHasSpEffect(chrEntityId, 90160);
    sp2 = CharacterHasSpEffect(chrEntityId, 482)
        && !CharacterHasSpEffect(chrEntityId, 90100)
        && !CharacterHasSpEffect(chrEntityId, 90120)
        && !CharacterHasSpEffect(chrEntityId, 90160)
        && !CharacterHasSpEffect(chrEntityId, 90162);
    sp3 = CharacterHasSpEffect(chrEntityId, 483)
        && !CharacterHasSpEffect(chrEntityId, 90100)
        && !CharacterHasSpEffect(chrEntityId, 90140)
        && !CharacterHasSpEffect(chrEntityId, 90160)
        && !CharacterHasSpEffect(chrEntityId, 90161);
    sp4 = CharacterHasSpEffect(chrEntityId, 484)
        && !CharacterHasSpEffect(chrEntityId, 90100)
        && !CharacterHasSpEffect(chrEntityId, 90130)
        && !CharacterHasSpEffect(chrEntityId, 90161)
        && !CharacterHasSpEffect(chrEntityId, 90162);
    sp5 = CharacterHasSpEffect(chrEntityId, 487)
        && !CharacterHasSpEffect(chrEntityId, 90100)
        && !CharacterHasSpEffect(chrEntityId, 90150)
        && !CharacterHasSpEffect(chrEntityId, 90160);
    assetChrSp &= chrSp;
    WaitFor(
        assetChrSp
            || HasDamageType(chrEntityId, 0, DamageType.Unspecified)
            || CharacterHasStateInfo(chrEntityId, 436)
            || CharacterHasStateInfo(chrEntityId, 2)
            || CharacterHasStateInfo(chrEntityId, 5)
            || CharacterHasStateInfo(chrEntityId, 6)
            || CharacterHasStateInfo(chrEntityId, 260)
            || sp
            || sp2
            || sp3
            || sp4
            || sp5);
    WaitFixedTimeSeconds(0.1);
    if (!(!CharacterHasSpEffect(chrEntityId, 5080) && !CharacterHasSpEffect(chrEntityId, 5450))) {
        SetNetworkconnectedThisEventSlot(ON);
        WaitFixedTimeSeconds(timeSeconds);
        if (value != 0) {
            EnableCharacterGravity(chrEntityId);
            SetCharacterMaphit(chrEntityId, true);
        }
        SetSpEffect(chrEntityId, 16571);
        SetSpEffect(chrEntityId, spEffectId);
        ForceAnimationPlayback(chrEntityId, animationId2, true, false, false);
        EndEvent();
    }
L0:
    if (value != 0) {
        EnableCharacterGravity(chrEntityId);
        SetCharacterMaphit(chrEntityId, true);
    }
    EndEvent();
});

// 感覚弱体化_XX -- Weakened senses_XX
$Event(34122400, Restart, function(chrEntityId, areaEntityId) {
    SetSpEffect(chrEntityId, 8081);
    SetSpEffect(chrEntityId, 8082);
    WaitFor(
        (InArea(10000, areaEntityId)
            && ((CharacterType(10000, TargetType.BlackPhantom) && CharacterHasSpEffect(10000, 3710))
                || CharacterType(10000, TargetType.Alive)
                || CharacterType(10000, TargetType.GrayPhantom)
                || CharacterType(10000, TargetType.WhitePhantom)))
            || HasDamageType(chrEntityId, 0, DamageType.Unspecified)
            || CharacterHasStateInfo(chrEntityId, 436)
            || CharacterHasStateInfo(chrEntityId, 2)
            || CharacterHasStateInfo(chrEntityId, 5)
            || CharacterHasStateInfo(chrEntityId, 6)
            || CharacterHasStateInfo(chrEntityId, 260));
    ClearSpEffect(chrEntityId, 8081);
    ClearSpEffect(chrEntityId, 8082);
    WaitFixedTimeSeconds(0.4);
    RestartEvent();
});

// ボス撃破 -- Defeat the boss
$Event(34122800, Restart, function() {
    EndIf(EventFlag(34120800));
    WaitFor(CharacterHPValue(34120800) <= 0);
    WaitFixedTimeSeconds(4);
    PlaySE(34128500, SoundType.SFX, 888880000);
    WaitFor(CharacterDead(34120800));
    HandleBossDefeatAndDisplayBanner(34120800, TextBannerType.EnemyFelled);
    SetEventFlagID(34120800, ON);
    SetEventFlagID(9264, ON);
    if (PlayerIsInOwnWorld()) {
        SetEventFlagID(61264, ON);
    }
});

// ボス出現 -- Boss appears
$Event(34122810, Restart, function() {
    if (EventFlag(34120800)) {
        DisableCharacter(34120800);
        DisableCharacterCollision(34120800);
        ForceCharacterDeath(34120800, false);
        EndEvent();
    }
L0:
    DisableCharacterAI(34120800);
    if (!EventFlag(34120801)) {
        DisableCharacter(34120800);
        ForceAnimationPlayback(34120800, 30000, true, false, false);
        WaitFor(
            (PlayerIsInOwnWorld() && InArea(10000, 34122801))
                || HasDamageType(34120800, 10000, DamageType.Unspecified));
        SetNetworkconnectedEventFlagID(34120801, ON);
        EnableCharacter(34120800);
        ForceAnimationPlayback(34120800, 20000, false, false, true);
    } else {
L1:
        WaitFor(EventFlag(34122805) && InArea(10000, 34122800));
    }
L2:
    EnableCharacterAI(34120800);
    SetNetworkUpdateRate(34120800, true, CharacterUpdateFrequency.AlwaysUpdate);
    DisplayBossHealthBar(Enabled, 34120800, 0, 903600320);
});

// ボス激昂 -- boss rage
$Event(34122811, Restart, function() {
    EndIf(EventFlag(34120800));
    WaitFor(HPRatio(34120800) <= 0.6);
    SetEventFlagID(34122802, ON);
});

// ボスイベント起動 -- Boss event activation
$Event(34122849, Restart, function() {
    $InitializeCommonEvent(0, 9005800, 34120800, 34121800, 34122800, 34122805, 34125800, 10000, 34120801, 34122801);
    $InitializeCommonEvent(0, 9005801, 34120800, 34121800, 34122800, 34122805, 34122806, 10000);
    $InitializeCommonEvent(0, 9005811, 34120800, 34121800, 3, 34120801);
    $InitializeCommonEvent(0, 9005822, 34120800, 931000, 34122805, 34122806, 0, 34122802, 0, 0);
    $InitializeCommonEvent(0, 9005811, 34120800, 34121801, 3, 34120801);
});


