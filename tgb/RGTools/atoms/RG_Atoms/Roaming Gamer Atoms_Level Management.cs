//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_LevelManagement_reloadCurrentLevel) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Roaming Gamer - Level Management";
      description = "Reloads the current level.";
      details_atomName = "reloadCurrentLevel";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "Level Management";
      friendlyName = "reloadCurrentLevel";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   sceneWindow2D.reloadCurrentLevel();";
      segments = "executeAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_LevelManagement_loadNumberedLevel) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Roaming Gamer - Level Management";
      description = "loads a numbered level matching the prefix of current level. (Ex: Current BigRoom0.t2d; levelNumber 3 loads -> BigRoom3.t2d)";
      details_atomName = "loadNumberedLevel";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "Level Management";
      friendlyName = "loadNumberedLevel";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"levelNumber\", \"Level number to load\", \"int\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   sceneWindow2D.loadNumberedLevel( %this.levelNumber );";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_LevelManagement_loadNextNumberedLevel) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Roaming Gamer - Level Management";
      description = "loads next numbered level matching the prefix of current level. (Ex: Current BigRoom0.t2d; Next loads -> BigRoom1.t2d)";
      details_atomName = "loadNextNumberedLevel";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "Level Management";
      friendlyName = "loadNextNumberedLevel";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   sceneWindow2D.loadNextNumberedLevel( );";
      segments = "executeAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_LevelManagement_loadNamedLevel) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Roaming Gamer - Level Management";
      description = "loads a level with the specified name (found anywhere under the game path)";
      details_atomName = "loadNamedLevel";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "Level Management";
      friendlyName = "loadNamedLevel";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"levelName\", \"Name of level file to load.\", \"default\", \"myLevel\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   sceneWindow2D.loadNamedLevel( %this.levelName );";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_LevelManagement_loadLastNumberedLevel) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Roaming Gamer - Level Management";
      description = "loads last numbered level matching the prefix of current level. (Ex: Current BigRoom5.t2d; Next loads -> BigRoom4.t2d)";
      details_atomName = "loadLastNumberedLevel";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "Level Management";
      friendlyName = "loadLastNumberedLevel";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   sceneWindow2D.loadLastNumberedLevel( );";
      segments = "executeAction";
};
//--- OBJECT WRITE END ---
