//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_10Weapons_Other_onFire_Dismount) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "10 - Weapons";
      description = "Dismount this object when onFire() is received.";
      details_atomName = "onFire_Dismount";
      details_category = "10 - Weapons";
      details_eventAction = "full";
      details_subCategory = "Other";
      friendlyName = "onFire() -> Dismount";
      segmentkeepAll = "4";
      segmentkeepAll_0 = "function onFire_Dismount::onFire( %this, %val )";
      segmentkeepAll_1 = "{ ";
      segmentkeepAll_2 = "   if(%val) %this.owner.dismount();   ";
      segmentkeepAll_3 = "}";
      segments = "keepAll";
};
//--- OBJECT WRITE END ---
