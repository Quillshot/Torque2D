//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dPath_PathMethods_setpathType) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dPath - Path Methods";
      description = "set interpolation type for this path.";
      details_atomName = "setpathType";
      details_category = "t2dPath";
      details_eventAction = "action";
      details_subCategory = "Path Methods";
      friendlyName = "setpathType";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"pathType\", \"Path interpolation type.\", \"enum\", \"linear\", \"linear\"TAB\"bezier\"TAB\"catmull\"TAB\"custom\");    ";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setpathType(%this.pathType);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dPath_PathMethods_removeNode) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dPath - Path Methods";
      description = "remove a (numbered) node from the path.";
      details_atomName = "removeNode";
      details_category = "t2dPath";
      details_eventAction = "action";
      details_subCategory = "Path Methods";
      friendlyName = "removeNode";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"index\", \"Index of node to remove.\", \"int\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.removeNode(%this.index);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dPath_PathMethods_detachObject) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dPath - Path Methods";
      description = "remove a specified object from the path.";
      details_atomName = "detachObject";
      details_category = "t2dPath";
      details_eventAction = "action";
      details_subCategory = "Path Methods";
      friendlyName = "detachObject";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"object\", \"Object to remove from the path.\", \"object\", \"t2dSceneObject\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.detachObject(%this.object);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dPath_PathMethods_clear) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dPath - Path Methods";
      description = "clear all nodes from the path and detach all attached objects.";
      details_atomName = "clear";
      details_category = "t2dPath";
      details_eventAction = "action";
      details_subCategory = "Path Methods";
      friendlyName = "clear";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.clear();";
      segments = "executeAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dPath_PathMethods_attachObject) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dPath - Path Methods";
      description = "attach a specified object to this path.";
      details_atomName = "attachObject";
      details_category = "t2dPath";
      details_eventAction = "action";
      details_subCategory = "Path Methods";
      friendlyName = "attachObject";
      segmentbehaviorFields = "8";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"object\", \"Object to attach to the path\", \"object\", \"t2dSceneObject\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"speed\", \"Speed at which the object will move along the path.\", \"float\", \"1.0\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"direction\", \"Direction (-1 - backward, 1 - forward) for object to move on path.\", \"int\", \"1\");";
      segmentbehaviorFields_3 = "   %behavior.addBehaviorField( \"startNode\", \"Node that the object starts at.\", \"int\", \"0\");";
      segmentbehaviorFields_4 = "   %behavior.addBehaviorField( \"endNode\", \"Node that the object ends at.\", \"int\", \"0\");";
      segmentbehaviorFields_5 = "   %behavior.addBehaviorField( \"followMode\", \"Action to take upon reaching the end of the path.\", \"enum\", \"wrap\", \"wrap\"TAB\"reverse\"TAB\"restart\");";
      segmentbehaviorFields_6 = "   %behavior.addBehaviorField( \"loops\", \"Number of loops to take around the path.\", \"int\", \"0\");";
      segmentbehaviorFields_7 = "   %behavior.addBehaviorField( \"sendToStart\", \"If true, send object directly to the start node, else have it move there on its own (over time).\", \"bool\", \"0\");";
      segmentexecuteAction = "2";
      segmentexecuteAction_0 = "   //EFM - Provide code to insure legal values are passed for start/end nodes";
      segmentexecuteAction_1 = "   %this.owner.attachObject(%this.object, %this.speed, %this.direction, %this.startNode, %this.endNode, %this.followMode, %this.loops, %this.sendToStart);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dPath_PathMethods_addNode) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dPath - Path Methods";
      description = "add a node to the path.";
      details_atomName = "addNode";
      details_category = "t2dPath";
      details_eventAction = "action";
      details_subCategory = "Path Methods";
      friendlyName = "addNode";
      segmentbehaviorFields = "4";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"position\", \"Position at which to place the node.\", \"point2f\", \"0.0 0.0\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"index\", \"Index in the path at which the node will be placed. (-1 - place at end of path.)\", \"int\", \"-1\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"weight\", \"Weight of the node for bezier paths.\", \"float\", \"10.0\");";
      segmentbehaviorFields_3 = "   %behavior.addBehaviorField( \"rotation\", \"Rotation of the node for bezier paths.\", \"float\", \"0.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.addNode(%this.position, %this.index, %this.weight, %this.rotation);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
