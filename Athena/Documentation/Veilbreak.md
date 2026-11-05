# Veilbreak list of Modding Changes
WIP

New Event Ids ought to start with this for no problematic ids being broken in game:

1058500000 - Base Event Item Acquisition Flags

1059500000 - Base Event Flag

1059504000 - Quest Completed

# Event

## common.emevd.dcx
1059500000 - 1059500099


Event Flag - 1059500000
```
// Unlock post-Altus graces (when Altus is reached)
$Event(1059500000, Default, function() {
    EndIf(ThisEventSlot());
    
    WaitFor
    (EventFlag(76301) //Altus Plateau
      || EventFlag(76302) //Erdtree Gazing Hill
      || EventFlag(76300) //Abandoned Coffin
      || EventFlag(76303) //Altus Highway Junction
      || EventFlag(76354) //Seethwater River
      || EventFlag(76320) //Shaded Castle Ramparts
      || EventFlag(76321) //Shaded Castle Inner Gate
      || EventFlag(76309) //Outer Wall Phantom Tree
      || EventFlag(76312) //Outer Wall Battleground
      || EventFlag(76304) //Forest, Spanning Greatbridge
      || EventFlag(76306) //Bower of Bounty
      ); 
    
    const progressiveGracesTier1 = [
        //        Area            - Grace Name
        //        ----              ----------
        76312, // Altus Plateau   - Outer Wall Battleground
        76353, // Mt. Gelmir      - Road of Iniquity
        76356, // Mt. Gelmir      - Craftsman's Shack
        76521, // Mountaintops    - Snow Valley Ruins Overlook
        76551, // Consecrated     - Inner Consecrated Snowfield
        71234, // Deeproot Depths - Nameless Eternal City
        71216, // Lake of Rot     - Lake of Rot Shoreside
    ];
    
    for (let i = 0; i < progressiveGracesTier1.length; i++) {
        SetEventFlagID(progressiveGracesTier1[i], ON);
    }
    
    // Golden Seeds and Sacred Tears
    AwardItemLot(5310); // sets event flag 1058500001
    
    // Some base game graces were unlocked, including underground
    DisplayBlinkingMessage(30068);
    
    SetThisEventSlot(ON);
});
```

## Parameters

### SpEffects
Added New Row `20000121`. This SpEffect is giving to the player to give them +5 Scadu Fragments
while in the Promised Consort Radahn fight.

Incremented `20000120` by 1, which is Scadu Fragment 20 SpEffect for the player

### 