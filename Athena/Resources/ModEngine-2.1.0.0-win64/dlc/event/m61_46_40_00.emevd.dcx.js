// ==EMEVD==
// @docs    er-common.emedf.json
// @compress    DCX_KRAK
// @game    Sekiro
// @string    "N:\\GR\\data\\Param\\event\\common_func.emevd\u0000N:\\GR\\data\\Param\\event\\common_macro.emevd\u0000\u0000\u0000\u0000\u0000\u0000"
// @linked    [0,82]
// @version    3.5
// ==/EMEVD==

$Event(0, Default, function() {
    RegisterBonfire(2046400000, 2046401950, 0, 0, 0, 0);
    RegisterBonfire(2046400001, 2046401951, 0, 0, 0, 0); // Gravesite Hollow
    $InitializeCommonEvent(0, 90005511, 2046400066, 2046400022, 2046400044, 464035, 0); // Register Door
    $InitializeCommonEvent(0, 90005512, 2046400066, 2046400033, 2046400055);
    $InitializeCommonEvent(0, 90005870, 2046400800, 905730600, 16);
    $InitializeCommonEvent(0, 90005860, 2046400800, 0, 2046400800, 0, 30845, 0);
    $InitializeCommonEvent(0, 90005201, 2046400300, 30000, 20000, 45, 0, 0, 0, 0, 0);
    $InitializeCommonEvent(0, 90005250, 2046400301, 2046402301, 0, 0);
    $InitializeEvent(0, 2046402200, 2046400200, 2046402200, 2046402201);
    $InitializeEvent(1, 2046402200, 2046400201, 2046402200, 2046402202);
    $InitializeEvent(2, 2046402200, 2046400202, 2046402200, 2046402203);
    $InitializeEvent(0, 2046402550, 580100, 2046401550, 80100);
    $InitializeEvent(0, 2046400700, 4926, 4458);
    $InitializeEvent(0, 2046400600);
});

$Event(50, Default, function() {
    $InitializeEvent(0, 2046402500);
    $InitializeEvent(0, 2046402502);
});

// initialization
$Event(2046400600, Default, function() {
    EndIf(ThisEventSlot());
    
    // The default respawn point is Chapel of Anticipation. This line changes it to Gravesite Hollow.
    SetPlayerRespawnPoint(2046402020);
    
    const initialFlags = [
        // STORY FLAGS
        100, // Story: Start
        //102, // Story: Reached Limgrave
        //104, // Story: Reached Roundtable Hold
        4680, // Allow Leveling Up at Grace
        4681, // Accepted Melina's Request to take her to the Erdtree. Prevents her from appearing at Gatefront area graces
        //11108548, // Roundtable Door is opened
        
        // MAP RELATED
        62000, // Allow Map Display
        82002, // DLC map can be opened
        
        // Initial Graces
        //71190, // Roundtable Hold
        76806, // Gravesite Hollow
        
        // MAPS
        62084, // Abyss
        62083, // Rauh Ruins
        62082, // Southern Shore
        62081, // Scadu Altus
        62080, // Gravesite Plain
        
        // MAP ICONS (DLC only)
        62811, 62806, 62843, 62809, 62815, 62812, 62805, 62810, 62813, 62814, 62807, 62830, 62831, 62842,
        62841, 62808, 62826, 62825, 62855, 62827, 62840, 62844, 62865, 62920, 62921, 62950, 62904, 62905,
        62900, 62901, 62902, 62903, 62907, 62931, 62932, 62909, 62910, 62962, 62960, 62970, 62961, 62906,
        62911, 62908, 62912, 62941, 62942
    ];
    
    for (let i = 0; i < initialFlags.length; i++) {
        SetEventFlagID(initialFlags[i], ON);
    }
    
    // talisman pouches
    SetEventFlagID(60500, ON);
    SetEventFlagID(60510, ON);
    SetEventFlagID(60520, ON);
    RemoveItemFromPlayer(ItemType.Goods, 10040, 3);
    for (let i = 0; i < 3; i++) {
        DirectlyGivePlayerItem(ItemType.Goods, 10040, 6001, 1);
    }
    
    // give cracked pots
    for (let i = 0; i < 20; i++) {
        SetEventFlagID(66000 + (i*10), ON);   
    }
    RemoveItemFromPlayer(ItemType.Goods, 9500, 20);
    for (let i = 0; i < 20; i++) {
        DirectlyGivePlayerItem(ItemType.Goods, 9500, 6001, 1);
    }
    
    // give memory stones
    for (let i = 0; i < 8; i++) {
        SetEventFlagID(60400 + (i*10), ON);   
    }
    RemoveItemFromPlayer(ItemType.Goods, 10030, 8);
    for (let i = 0; i < 8; i++) {
        DirectlyGivePlayerItem(ItemType.Goods, 10030, 6001, 1);
    }
    
    // give perfume bottles
    for (let i = 0; i < 10; i++) {
        SetEventFlagID(66700 + (i*10), ON);   
    }
    RemoveItemFromPlayer(ItemType.Goods, 9510, 10);
    for (let i = 0; i < 10; i++) {
        DirectlyGivePlayerItem(ItemType.Goods, 9510, 6001, 1);
    }
    
    // estus flasks
    SetEventFlagID(60000, ON);
    for (let i = 0; i <= 25; i++) {
        RemoveItemFromPlayer(ItemType.Goods, 1000 + i, 14);
        RemoveItemFromPlayer(ItemType.Goods, 1050 + i, 14);
    }
    for (let i = 0; i < 12; i++) {
        DirectlyGivePlayerItem(ItemType.Goods, 1025, 6001, 1);
    }
    for (let i = 0; i < 2; i++) {
        DirectlyGivePlayerItem(ItemType.Goods, 1075, 6001, 1);
    }
    
    // physick flask
    SetEventFlagID(60020, ON);
    RemoveItemFromPlayer(ItemType.Goods, 250, 1);
    DirectlyGivePlayerItem(ItemType.Goods, 250, 6001, 1);
    
    // steed whistle
    SetEventFlagID(60100, ON);
    RemoveItemFromPlayer(ItemType.Goods, 130, 1);
    DirectlyGivePlayerItem(ItemType.Goods, 130, 6001, 1);
    
    // give crafting kit
    SetEventFlagID(60120, ON);
    DirectlyGivePlayerItem(ItemType.Goods, 8500, 6001, 1);
    
    // give whetstone knife
    SetEventFlagID(60130, ON);
    DirectlyGivePlayerItem(ItemType.Goods, 8590, 6001, 1);
    
    // give lantern
    DirectlyGivePlayerItem(ItemType.Goods, 2070, 6001, 1);
    
    // give starlight shards
    for (let i = 0; i < 10; i++ ) {
        DirectlyGivePlayerItem(ItemType.Goods, 1290, 6001, 1);
    }
    
    SetThisEventSlot(ON);
});

$Event(2046400700, Restart, function(eventFlagId, eventFlagId2) {
    EndIf(!PlayerIsInOwnWorld());
    WaitFixedTimeFrames(1);
    EndIf(EventFlag(eventFlagId));
    SetEventFlagID(eventFlagId, ON);
    SetEventFlagID(eventFlagId2, ON);
});

$Event(2046402500, Restart, function() {
    EndIf(EventFlag(2046400500));
    EndIf(!PlayerInMap(61, 46, 40, 0));
    SetCurrentTime(8, 0, 0, false, false, false, 0, 0, 0);
    FreezeTime(true);
    WaitFor((PlayerIsInOwnWorld() && !InArea(10000, 2046402500)) || !PlayerIsInOwnWorld());
    if (PlayerIsInOwnWorld()) {
        SetNetworkconnectedEventFlagID(2046400500, ON);
    }
L1:
    FreezeTime(false);
});

$Event(2046402502, Restart, function() {
    EndIf(!PlayerIsInOwnWorld());
    EndIf(EventFlag(2046400502));
    EndIf(!PlayerInMap(61, 46, 40, 0));
    DisableAreaWelcomeMessage();
    WaitFor(PlayerIsInOwnWorld() && !InArea(10000, 2046402502));
    EnableAreaWelcomeMessage();
    DisplayAreaWelcomeMessage(68000);
    SetEventFlagID(2046400502, ON);
});

$Event(2046402200, Restart, function(chrEntityId, areaEntityId, entityId) {
    DisableNetworkSync();
    CreateBulletOwner(chrEntityId);
    WaitFor(InArea(10000, areaEntityId));
    WaitRandomTimeSeconds(1, 10);
    if (!EventFlag(70)) {
        if (EventFlag(50)) {
            ShootBullet(chrEntityId, entityId, 900, 804508000, 0, 0, 0);
        }
        if (EventFlag(51)) {
            ShootBullet(chrEntityId, entityId, 900, 804508010, 0, 0, 0);
        }
        if (EventFlag(52)) {
            ShootBullet(chrEntityId, entityId, 900, 804508020, 0, 0, 0);
        }
        if (EventFlag(53)) {
            ShootBullet(chrEntityId, entityId, 900, 804508030, 0, 0, 0);
        }
        if (EventFlag(54)) {
            ShootBullet(chrEntityId, entityId, 900, 804508040, 0, 0, 0);
        }
        if (EventFlag(55)) {
            ShootBullet(chrEntityId, entityId, 900, 804508050, 0, 0, 0);
        }
        if (EventFlag(56)) {
            ShootBullet(chrEntityId, entityId, 900, 804508060, 0, 0, 0);
        }
        if (EventFlag(57)) {
            ShootBullet(chrEntityId, entityId, 900, 804508070, 0, 0, 0);
        }
    } else {
L0:
        if (EventFlag(50)) {
            ShootBullet(chrEntityId, entityId, 900, 804518000, 0, 0, 0);
        }
        if (EventFlag(51)) {
            ShootBullet(chrEntityId, entityId, 900, 804518010, 0, 0, 0);
        }
        if (EventFlag(52)) {
            ShootBullet(chrEntityId, entityId, 900, 804518020, 0, 0, 0);
        }
        if (EventFlag(53)) {
            ShootBullet(chrEntityId, entityId, 900, 804518030, 0, 0, 0);
        }
        if (EventFlag(54)) {
            ShootBullet(chrEntityId, entityId, 900, 804518040, 0, 0, 0);
        }
        if (EventFlag(55)) {
            ShootBullet(chrEntityId, entityId, 900, 804518050, 0, 0, 0);
        }
        if (EventFlag(56)) {
            ShootBullet(chrEntityId, entityId, 900, 804518060, 0, 0, 0);
        }
        if (EventFlag(57)) {
            ShootBullet(chrEntityId, entityId, 900, 804518070, 0, 0, 0);
        }
    }
L1:
    WaitFixedTimeSeconds(1);
    RestartEvent();
});

$Event(2046402550, Restart, function(eventFlagId, assetEntityId, itemLotId) {
    EndIf(EventFlag(eventFlagId));
    EndIf(!PlayerIsInOwnWorld());
    DeleteAssetfollowingSFX(assetEntityId, false);
    CreateAssetfollowingSFX(assetEntityId, 200, 806845);
    WaitFor(PlayerIsInOwnWorld() && ActionButtonInArea(9310, assetEntityId));
    DeleteAssetfollowingSFX(assetEntityId, true);
    PlaySE(assetEntityId, SoundType.SFX, 806841);
    WaitFixedTimeSeconds(0.1);
    AwardItemsIncludingClients(itemLotId);
});
