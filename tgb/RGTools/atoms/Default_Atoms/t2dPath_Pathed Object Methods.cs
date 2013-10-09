//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dPath_PathedObjectMethods_setStartNode) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dPath - Pathed Object Methods";
      description = "set node this object will start at.";
      details_atomName = "setStartNode";
      details_category = "t2dPath";
      details_eventAction = "action";
      details_subCategory = "Pathed Object Methods";
      friendlyName = "setStartNode";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"node\", \"Node the object will start at.\", \"integer\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setStartNode(%this.owner, %this.node);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dPath_PathedObjectMethods_setSpeed) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dPath - Pathed Object Methods";
      description = "set speed this object will move along the path it is attached to.";
      details_atomName = "setSpeed";
      details_category = "t2dPath";
      details_eventAction = "action";
      details_subCategory = "Pathed Object Methods";
      friendlyName = "setSpeed";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"speed\", \"Speed to move at.\", \"float\", \"10.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setSpeed(%this.owner, %this.speed);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dPath_PathedObjectMethods_setOrient) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dPath - Pathed Object Methods";
      description = "set whether this object will orient to the path (it is attached to) as it moves.";
      details_atomName = "setOrient";
      details_category = "t2dPath";
      details_eventAction = "action";
      details_subCategory = "Pathed Object Methods";
      friendlyName = "setOrient";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"orient\", \"Orient to path?\", \"bool\", \"1\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setOrient(%this.owner, %this.orient);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dPath_PathedObjectMethods_setmoveForward) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dPath - Pathed Object Methods";
      description = "set whether this object will move forward (or in reverse) along the path it is attached to.";
      details_atomName = "setmoveForward";
      details_category = "t2dPath";
      details_eventAction = "action";
      details_subCategory = "Pathed Object Methods";
      friendlyName = "setmoveForward";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"moveForward\", \"true - move forward; false - move in reverse\", \"bool\", \"1\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setmoveForward(%this.owner, %this.moveForward);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dPath_PathedObjectMethods_setLoops) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dPath - Pathed Object Methods";
      description = "set the number of times this object will loop around the path it is attached to.";
      details_atomName = "setLoops";
      details_category = "t2dPath";
      details_eventAction = "action";
      details_subCategory = "Pathed Object Methods";
      friendlyName = "setLoops";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"loops\", \"Times to loop around path.\", \"bool\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setLoops(%this.owner, %this.loops);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dPath_PathedObjectMethods_setfollowMode) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dPath - Pathed Object Methods";
      description = "set the mode at which the object will follow the path it is attached to.";
      details_atomName = "setfollowMode";
      details_category = "t2dPath";
      details_eventAction = "action";
      details_subCategory = "Pathed Object Methods";
      friendlyName = "setfollowMode";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"followMode\", \"Mode to use while following path.\", \"enum\", \"wrap\", \"wrap\"TAB\"reverse\"TAB\"restart\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setfollowMode(%this.owner, %this.followMode);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dPath_PathedObjectMethods_setEndNode) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dPath - Pathed Object Methods";
      description = "set the node the object will end at.";
      details_atomName = "setEndNode";
      details_category = "t2dPath";
      details_eventAction = "action";
      details_subCategory = "Pathed Object Methods";
      friendlyName = "setEndNode";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"node\", \"End node\", \"int\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setEndNode(%this.owner, %this.node);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
