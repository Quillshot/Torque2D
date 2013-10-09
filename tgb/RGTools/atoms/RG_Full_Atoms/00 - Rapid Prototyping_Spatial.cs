//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_00RapidPrototyping_Spatial_GoHome) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "00 - Rapid Prototyping";
      description = "Make owner object go back to where it was when it was added to the scene.";
      details_atomName = "GoHome";
      details_category = "00 - Rapid Prototyping";
      details_eventAction = "full";
      details_subCategory = "Spatial";
      friendlyName = "GoHome";
      segmentkeepAll = "15";
      segmentkeepAll_0 = "function t2dSceneObject::doGoHome(%this)";
      segmentkeepAll_1 = "{";
      segmentkeepAll_10 = "function GoHome::doGoHome(%this)";
      segmentkeepAll_11 = "{";
      segmentkeepAll_12 = "   %this.owner.dismount(); // Just in case";
      segmentkeepAll_13 = "   %this.owner.setPosition(%this.Home);";
      segmentkeepAll_14 = "}//doGoHome";
      segmentkeepAll_2 = "   %goHomeBehavior = %this.getBehavior( \"GoHome\" );";
      segmentkeepAll_3 = "   if(!isObject( %goHomeBehavior ) ) ";
      segmentkeepAll_4 = "   {";
      segmentkeepAll_5 = "      error(\"behavior not found?\");";
      segmentkeepAll_6 = "      return;";
      segmentkeepAll_7 = "   }";
      segmentkeepAll_8 = "   %goHomeBehavior.doGoHome();";
      segmentkeepAll_9 = "}//t2dSceneObject::doGoHome";
      segmentonAddToScene = "1";
      segmentonAddToScene_0 = "   %this.Home = %this.owner.getPosition();";
      segments = "onAddToScene\tkeepAll";
};
//--- OBJECT WRITE END ---
