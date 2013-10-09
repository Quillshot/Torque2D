//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_SimObject_delayedDelete) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "03 - Scene & Camera";
      description = "delete this SimObject after N-millliseconds.";
      details_atomName = "delayedDelete";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "SimObject";
      friendlyName = "delayedDelete";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"deletionDelay\", \"Wait this many milliseconds the call delete().\", \"int\", \"100\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.schedule( %this.deletionDelay, delete );";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
