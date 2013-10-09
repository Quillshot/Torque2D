//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_Rendering_Xflate) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Rendering";
      description = "increases or decreases this object\'s size over time. (Warning: Treats object as square.)";
      details_atomName = "Xflate";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "Rendering";
      friendlyName = "Xflate";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"Size_Multiple\", \"Scale to this size multiple over time. (Size_Multiple > 1.0 inflate; Size_Multiple < 1.0 deflate.)\", \"float\", \"1.0\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"Duration\", \"Take this many milliseconds to Xflate object.\", \"int\", \"1000\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.schedule( 0, doFlate, %this.steps );";
      segmentkeepAll = "9";
      segmentkeepAll_0 = "function Xflate::doFlate(%this, %steps)";
      segmentkeepAll_1 = "{";
      segmentkeepAll_2 = "   %size = getWord( %this.owner.getSize(), 0) + %this.sizeStep;";
      segmentkeepAll_3 = "   ";
      segmentkeepAll_4 = "   %this.owner.setSize( %size );";
      segmentkeepAll_5 = "   ";
      segmentkeepAll_6 = "   %steps--;   ";
      segmentkeepAll_7 = "   if( %steps > 0 ) %this.schedule( 30, doFlate, %steps );   ";
      segmentkeepAll_8 = "}";
      segmentonAddToScene = "13";
      segmentonAddToScene_0 = "   if(%this.Size_Multiple < 0) %this.Size_Multiple = 0;";
      segmentonAddToScene_1 = "   if(%this.Duration < 30) %this.Duration = 30;";
      segmentonAddToScene_10 = "   %this.actualDuration  = %timeSteps * 30;";
      segmentonAddToScene_11 = "   ";
      segmentonAddToScene_12 = "   %this.sizeStep = (%this.targetSize - %size) / %timeSteps;";
      segmentonAddToScene_2 = "   ";
      segmentonAddToScene_3 = "   %size = getWord( %this.owner.getSize(), 0);";
      segmentonAddToScene_4 = "   %this.targetSize = %size * %this.Size_Multiple;";
      segmentonAddToScene_5 = "   ";
      segmentonAddToScene_6 = "   %timeSteps = mFloatLength(%this.Duration / 30, 0); //  Calculate total steps as alotted time / 30 ms";
      segmentonAddToScene_7 = "   %this.steps = %timeSteps;";
      segmentonAddToScene_8 = "   ";
      segmentonAddToScene_9 = "   // Set the actual duration (may be slightly shorter than user-specified time";
      segments = "behaviorFields\tonAddToScene\texecuteAction\tkeepAll";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_Rendering_resetImageMap) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Rendering";
      description = "change object imagemap to initial image map (the one it had when loaded into the scene).";
      details_atomName = "resetImageMap";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "Rendering";
      friendlyName = "resetImageMap";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setImageMap(%this.initialImageMap);";
      segmentonAddToScene = "1";
      segmentonAddToScene_0 = "   %this.initialImageMap = %this.owner.getImageMap();";
      segments = "onAddToScene\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_Rendering_reflate) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Rendering";
      description = "revert this object\'s size over time. (Un-does prior *inflate or *deflate.) (Warning: Treats object as square.)";
      details_atomName = "reflate";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "Rendering";
      friendlyName = "reflate";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"Duration\", \"Take this many milliseconds to reflate object.\", \"int\", \"1000\");";
      segmentexecuteAction = "11";
      segmentexecuteAction_0 = "   %size = getWord( %this.owner.getSize(), 0);";
      segmentexecuteAction_1 = "   ";
      segmentexecuteAction_10 = "   %this.schedule( 0, doFlate, %this.steps );";
      segmentexecuteAction_2 = "   %timeSteps = mFloatLength(%this.Duration / 30, 0); //  Calculate total steps as alotted time / 30 ms";
      segmentexecuteAction_3 = "   %this.steps = %timeSteps;";
      segmentexecuteAction_4 = "   ";
      segmentexecuteAction_5 = "   // Set the actual duration (may be slightly shorter than user-specified time";
      segmentexecuteAction_6 = "   %this.actualDuration  = %timeSteps * 30;";
      segmentexecuteAction_7 = "   ";
      segmentexecuteAction_8 = "   %this.sizeStep = (%this.targetSize - %size) / %timeSteps;";
      segmentexecuteAction_9 = "   ";
      segmentkeepAll = "8";
      segmentkeepAll_0 = "function reflate::doFlate(%this, %steps)";
      segmentkeepAll_1 = "{";
      segmentkeepAll_2 = "   %size = getWord( %this.owner.getSize(), 0) + %this.sizeStep;";
      segmentkeepAll_3 = "   ";
      segmentkeepAll_4 = "   %this.owner.setSize( %size );";
      segmentkeepAll_5 = "   %steps--;   ";
      segmentkeepAll_6 = "   if( %steps > 0 ) %this.schedule( 30, doFlate, %steps );   ";
      segmentkeepAll_7 = "}";
      segmentonAddToScene = "3";
      segmentonAddToScene_0 = "   if(%this.Duration < 30) %this.Duration = 30;";
      segmentonAddToScene_1 = "   ";
      segmentonAddToScene_2 = "   %this.targetSize = getWord( %this.owner.getSize(), 0);";
      segments = "behaviorFields\tonAddToScene\texecuteAction\tkeepAll";
};
//--- OBJECT WRITE END ---