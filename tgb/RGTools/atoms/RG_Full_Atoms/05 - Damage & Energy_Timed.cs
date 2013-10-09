//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_05DamageEnergy_Timed_onTimer_Destroy) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "05 - Damage & Energy";
      description = "This object self-destructs after a fixed period of time. (Not same as \\\"Safe Delete\\\"!  Starts onDestroyed() response chain.)";
      details_atomName = "onTimer_Destroy";
      details_category = "05 - Damage & Energy";
      details_eventAction = "full";
      details_subCategory = "Timed";
      friendlyName = "Destroy after Delay";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField(delay, \"Wait this many milliseconds and then destroy object.\", integer, 100);";
      segmentonAddToScene = "1";
      segmentonAddToScene_0 = "   %this.owner.setTimerOn( %this.delay );";
      segmentonTimer = "8";
      segmentonTimer_0 = "   %this.owner.setTimerOff();";
      segmentonTimer_1 = "   ";
      segmentonTimer_2 = "   %damageBehavior = %this.owner.getBehavior( \"takesDamage\" ); ";
      segmentonTimer_3 = "    ";
      segmentonTimer_4 = "   if( !isObject(%damageBehavior) ) return; // Not using damage behavior, can\'t destroy object!";
      segmentonTimer_5 = "     ";
      segmentonTimer_6 = "   %damageBehavior.destroyObject();";
      segmentonTimer_7 = "}//onAddToScene";
      segments = "behaviorFields\tonAddToScene\tonTimer";
};
//--- OBJECT WRITE END ---
