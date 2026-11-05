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
    RegisterBonfire(34130001, 34131951, 0, 0, 0, 5);
    RegisterBonfire(34130002, 34131952, 0, 0, 0, 5);
    $InitializeEvent(0, 34132800);
    $InitializeEvent(0, 34132810);
    $InitializeEvent(0, 34132849);
    $InitializeCommonEvent(0, 90005110, 192, 9130, 34131599, 34130050, 8149, 806930, 9081, 60520, 0);
    $InitializeCommonEvent(0, 90005920, 34130600, 34131600, 34133600);
    $InitializeCommonEvent(0, 90005646, 34130800, 34132840, 34132841, 34131840, 1049410300, 60, 49, 41, 0);
    $InitializeCommonEvent(0, 90005508, 34130510, 34131510, 0, 34131510, 34131511, 34131512, 34130511);
    $InitializeCommonEvent(0, 90005508, 34130515, 34131515, 0, 34131515, 34131516, 34131517, 34130516);
    $InitializeCommonEvent(0, 90005508, 34130520, 34131520, 1, 34131520, 34131521, 34131522, 34130521);
    $InitializeEvent(0, 34132510);
    $InitializeEvent(0, 34132515);
    $InitializeEvent(0, 34132520);
    $InitializeEvent(0, 34132580);
    $InitializeCommonEvent(0, 90005511, 34130560, 34131560, 34133560, 227010, 0);
    $InitializeCommonEvent(0, 90005512, 34130560, 34132560, 34132561);
    $InitializeEvent(0, 34132590, 34131590, 34132590, 1, 34131592);
    $InitializeEvent(1, 34132590, 34131591, 34132591, 1000001, 34131593);
    $InitializeCommonEvent(0, 90005690, 34132592);
    $InitializeCommonEvent(0, 90005691, 34132592);
    $InitializeCommonEvent(0, 90005690, 34132593);
    $InitializeCommonEvent(0, 90005691, 34132593);
    $InitializeCommonEvent(0, 90005250, 34130299, 34132299, 0, -1);
    $InitializeCommonEvent(0, 90005251, 34130298, 10, 0, -1);
    // New Teleporter to top of Tower
    $InitializeCommonEvent(0, 90005605, 34101600, 34, 13, 0, 0, 34102610, 0, 34131591, 34131592, 34131593, 0, 0, 0, 0);
});

// プリコンストラクタ -- preconstructor
$Event(50, Default, function() {
    $InitializeEvent(0, 34130519);
});

// エレベータイベント起動 -- Elevator event activation
$Event(34132510, Default, function() {
    $InitializeCommonEvent(0, 90005507, 34130510, 34131510, 0, 34131510, 34131511, 34132513, 34131512, 34132514, 34132511, 34132512, 34130511, 34132512, 0);
});

// エレベータイベント起動下層１ -- Elevator event activation lower layer 1
$Event(34132515, Default, function() {
    $InitializeCommonEvent(0, 90005507, 34130515, 34131515, 0, 34131515, 34131516, 34132518, 34131517, 34132519, 34132516, 34132517, 34130516, 34132517, 0);
});

// エレベータイベント起動下層２ -- Elevator event activation lower layer 2
$Event(34132520, Default, function() {
    $InitializeCommonEvent(0, 90005507, 34130520, 34131520, 1, 34131520, 34131521, 34132523, 34131522, 34132524, 34132521, 34132522, 34130521, 34132522, 0);
});

// m34_13_00_00用初期フラグ設定 -- Initial flag setting for m34_13_00_00
$Event(34130519, Restart, function() {
    EndIf(ThisEventSlot());
    SetEventFlagID(34130520, ON);
});

// 梯子登録 -- ladder registration
$Event(34132580, Default, function() {
    RegisterLadder(34130580, 34130581, 34131580);
});

// 床落下 -- floor fall
$Event(34132590, Restart, function(entityId, areaEntityId, animationId, assetEntityId) {
    ForceAnimationPlayback(entityId, 0, false, false, false);
    if (AssetDestroyed(assetEntityId)) {
        RequestAssetRestoration(assetEntityId);
    }
    WaitFor(InArea(10000, areaEntityId));
    RequestAssetDestruction(assetEntityId, 0);
    ForceAnimationPlayback(entityId, animationId, false, false, false);
});

// ボス撃破 -- Defeat the boss
$Event(34132800, Restart, function() {
    EndIf(EventFlag(34130800));
    WaitFor(CharacterHPValue(34130800) <= 0);
    WaitFixedTimeSeconds(4);
    PlaySE(34130800, SoundType.SFX, 888880000);
    WaitFor(CharacterDead(34130800));
    HandleBossDefeatAndDisplayBanner(34130800, TextBannerType.GreatEnemyFelled);
    SetEventFlagID(34130800, ON);
    SetEventFlagID(9173, ON);
    if (PlayerIsInOwnWorld()) {
        SetEventFlagID(61173, ON);
    }
});

// ボス出現 -- Boss appears
$Event(34132810, Restart, function() {
    if (EventFlag(34130800)) {
        DisableCharacter(34130800);
        DisableCharacterCollision(34130800);
        ForceCharacterDeath(34130800, false);
        EndEvent();
    }
L0:
    DisableCharacterAI(34130800);
    DisableCharacterCollision(34130800);
    flagArea = EventFlag(34132805) && InArea(10000, 34132800);
    dmg = HasDamageType(34130800, 10000, DamageType.Unspecified);
    WaitFor(flagArea);
    EnableCharacterAI(34130800);
    EnableCharacterCollision(34130800);
    SetNetworkUpdateRate(34130800, true, CharacterUpdateFrequency.AlwaysUpdate);
    DisplayBossHealthBar(Enabled, 34130800, 0, 903560000);
});

// 神肌_イベント起動 -- Divine skin_event activation
$Event(34132849, Restart, function() {
    $InitializeCommonEvent(0, 9005800, 34130800, 34131800, 34132800, 34132805, 34135800, 10000, 0, 0);
    $InitializeCommonEvent(0, 9005801, 34130800, 34131800, 34132800, 34132805, 34132806, 10000);
    $InitializeCommonEvent(0, 9005811, 34130800, 34131800, 3, 0);
    $InitializeCommonEvent(0, 9005822, 34130800, 930000, 34132805, 34132806, 0, 34132802, 0, 0);
    $InitializeCommonEvent(0, 9005800, 34130800, 31121800, 34132800, 34132805, 31125800, 10000, 0, 0);
    $InitializeCommonEvent(0, 9005801, 34130800, 31121800, 34132800, 34132805, 31122806, 10000);
    $InitializeCommonEvent(0, 9005811, 34130800, 34131800, 3, 0);
    $InitializeCommonEvent(0, 9005812, 34130800, 34131801, 3, 0, 0);
    $InitializeCommonEvent(0, 9005822, 34130800, 356000, 34132805, 34132806, 0, 0, 0, 0);
});
