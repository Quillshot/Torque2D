//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_t2dSceneObject_safeDelete) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "03 - Scene & Camera";
      description = "safely delete this t2dSceneObject.";
      details_atomName = "safeDelete";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "t2dSceneObject";
      friendlyName = "safeDelete";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.safeDelete();";
      segments = "executeAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_t2dSceneObject_delayedSafeDelete) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "03 - Scene & Camera";
      description = "safely delete this t2dSceneObject.";
      details_atomName = "delayedSafeDelete";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "t2dSceneObject";
      friendlyName = "delayedSafeDelete";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"deletionDelay\", \"Wait this many milliseconds the call safeDelete().\", \"int\", \"100\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.schedule( %this.deletionDelay, safeDelete );";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
