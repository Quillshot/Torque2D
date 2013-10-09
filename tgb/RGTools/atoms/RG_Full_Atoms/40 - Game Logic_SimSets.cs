//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_40GameLogic_SimSets_onAddToSceneAddtoSimSet) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "40 - Game Logic";
      description = "Automatically add this object to the specified SimSet upon adding it to the scene.";
      details_atomName = "onAddToSceneAddtoSimSet";
      details_category = "40 - Game Logic";
      details_eventAction = "full";
      details_subCategory = "SimSets";
      friendlyName = "onAddToScene() -> Add to SimSet";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField(setName, \"Name of SimSet to add this objec to. (Creates set if not yet present.)\", \"default\", \"theSet\");";
      segmentonAddToScene = "2";
      segmentonAddToScene_0 = "   if(!isObject( %this.setName )) new SimSet( %this.setName );";
      segmentonAddToScene_1 = "   ( %this.setName ).add( %this.owner );";
      segments = "behaviorFields\tonAddToScene";
};
//--- OBJECT WRITE END ---
