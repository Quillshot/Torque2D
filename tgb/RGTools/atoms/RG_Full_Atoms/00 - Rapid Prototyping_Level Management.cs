//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_00RapidPrototyping_LevelManagement_onKeyUpReloadCurrentLevel) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "00 - Rapid Prototyping / Level Management";
      description = "When a key is pressed reload the current level.";
      details_atomName = "onKeyUpReloadCurrentLevel";
      details_category = "00 - Rapid Prototyping";
      details_eventAction = "full";
      details_subCategory = "Level Management";
      friendlyName = "onKeyUp() -> reloadCurrentLevel";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"actionKey\",   \"Key that is pressed to cause an action.\", keybind, \"Keyboard space\" );";
      segmentonAddToScene = "5";
      segmentonAddToScene_0 = "   //Event Atom Code:onKeyUp() ->";
      segmentonAddToScene_1 = "   moveMap.bindCmd( getWord(%this.actionKey, 0), ";
      segmentonAddToScene_2 = "                    getWord(%this.actionKey, 1), ";
      segmentonAddToScene_3 = "                    \"\",";
      segmentonAddToScene_4 = "                    \"sceneWindow2D.reloadCurrentLevel();\" );";
      segments = "behaviorFields\tonAddToScene";
};
//--- OBJECT WRITE END ---
