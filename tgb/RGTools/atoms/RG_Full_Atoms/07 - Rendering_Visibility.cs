//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_07Rendering_Visibility_Blink) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "07 - Rendering / Visiblity";
      description = "Hide and unhide (blink) with set period.";
      details_atomName = "Blink";
      details_category = "07 - Rendering";
      details_eventAction = "full";
      details_subCategory = "Visibility";
      friendlyName = "Blink";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField(blinkPeriod, \"Time between on/off cycles (in milliseconds.)\", int, 250);";
      segmentkeepAll = "6";
      segmentkeepAll_0 = "function Blink::doBlink(%this)";
      segmentkeepAll_1 = "{";
      segmentkeepAll_2 = "   %this.blinkVis = !%this.blinkVis;";
      segmentkeepAll_3 = "   %this.owner.setVisible(%this.blinkVis);";
      segmentkeepAll_4 = "   %this.schedule( %this.blinkPeriod, doBlink );";
      segmentkeepAll_5 = "}//doBlink";
      segmentonAddToScene = "3";
      segmentonAddToScene_0 = "   %this.blinkVis = true;";
      segmentonAddToScene_1 = "   %this.owner.setVisible(%this.blinkVis);";
      segmentonAddToScene_2 = "   %this.schedule( %this.blinkPeriod, doBlink );";
      segments = "behaviorFields\tonAddToScene\tkeepAll";
};
//--- OBJECT WRITE END ---
