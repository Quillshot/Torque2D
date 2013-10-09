//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_03SceneCamera_Scene_sceneHasConstantForce) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "03 - Scene & Camera";
      description = "Apply a constant force to all objects in the scene.";
      details_atomName = "sceneHasConstantForce";
      details_category = "03 - Scene & Camera";
      details_eventAction = "full";
      details_subCategory = "Scene";
      friendlyName = "Scene Force";
      segmentbehaviorFields = "3";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField(Magnitude, \"Magnitude of scene force.\", float, \"0.0\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField(Angle, \"Angle (direction) of force [0.0, 360.0).\", float, \"0.0\");   ";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField(Gravitic, \"Force is gravitic.\", bool, true);";
      segmentonAddToScene = "1";
      segmentonAddToScene_0 = "   %scenegraph.setConstantForcePolar(%this.Angle, %this.Magnitude, %this.Gravitic);";
      segments = "behaviorFields\tonAddToScene";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_03SceneCamera_Scene_onTimer_safeDelete) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "03 - Scene & Camera";
      description = "Safely delete this object after a fixed period of time.";
      details_atomName = "onTimer_safeDelete";
      details_category = "03 - Scene & Camera";
      details_eventAction = "full";
      details_subCategory = "Scene";
      friendlyName = "Safe Delete after Delay";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField(delay, \"Wait this many milliseconds and then safely delete object.\", integer, 100);";
      segmentonAddToScene = "1";
      segmentonAddToScene_0 = "   %this.owner.setTimerOn( %this.delay );";
      segmentonTimer = "2";
      segmentonTimer_0 = "   %this.owner.setTimerOff();";
      segmentonTimer_1 = "   %this.owner.safeDelete();";
      segments = "behaviorFields\tonAddToScene\tonTimer";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_03SceneCamera_Scene_onAddToScene_unHideMe) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "03 - Scene & Camera";
      description = "Hide this object when it is loaded to the scene.";
      details_atomName = "onAddToScene_unHideMe";
      details_category = "03 - Scene & Camera";
      details_eventAction = "full";
      details_subCategory = "Scene";
      friendlyName = "Un-hide Me";
      segmentonAddToScene = "3";
      segmentonAddToScene_0 = "   //echo(\"onAddToScene_unHideMe::onAddToScene( \", ((%this.getName() $= \"\") ? %this : %this.getName()) , \" ) @ \", getSimTime() );";
      segmentonAddToScene_1 = "   ";
      segmentonAddToScene_2 = "   %this.owner.setVisible(1);";
      segments = "onAddToScene";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_03SceneCamera_Scene_onAddToScene_HideMe) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "03 - Scene & Camera";
      description = "Hide this object when it is loaded to the scene.";
      details_atomName = "onAddToScene_HideMe";
      details_category = "03 - Scene & Camera";
      details_eventAction = "full";
      details_subCategory = "Scene";
      friendlyName = "Hide Me";
      segmentonAddToScene = "3";
      segmentonAddToScene_0 = "   //echo(\"onAddToScene_HideMe::onAddToScene( \", ((%this.getName() $= \"\") ? %this : %this.getName()) , \" ) @ \", getSimTime() );";
      segmentonAddToScene_1 = "   ";
      segmentonAddToScene_2 = "   %this.owner.setVisible(0);";
      segments = "onAddToScene";
};
//--- OBJECT WRITE END ---
