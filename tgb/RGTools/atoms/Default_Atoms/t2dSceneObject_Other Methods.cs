//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_OtherMethods_setUseMouseEvents) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - OtherMethods";
      description = "set whether or not mouse events are monitored by this object.";
      details_atomName = "setUseMouseEvents";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Other Methods";
      friendlyName = "setUseMouseEvents";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"status\", \"Monitor mouse events?\", \"bool\", \"1\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setUseMouseEvents(%this.status);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_OtherMethods_setTimerOn) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - OtherMethods";
      description = "a timer on this object that, when it expires, will cause this object to execute the onTimer() callback.  This timer loops, thus repeating until stoped with setTimerOff()";
      details_atomName = "setTimerOn";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Other Methods";
      friendlyName = "setTimerOn";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"timerPeriod\", \"Timer duration in milliseconds.\", \"int\", \"1000\"); ";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setTimerOn(%this.timerPeriod);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_OtherMethods_setTimerOff) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - OtherMethods";
      description = "turn off this object\'s timer.";
      details_atomName = "setTimerOff";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Other Methods";
      friendlyName = "setTimerOff";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setTimerOff();";
      segments = "executeAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_OtherMethods_setDebugOn) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - OtherMethods";
      description = "enables debug modes specified as (space or comma separated) list. (The debug banner (debug mode 0) has no effect on t2dSceneObjects. It is only relevant to t2dSceneGraphs.)\" @ \"\\n\\nDebug Modes:\" NL \"0 - Scenegraph Statistics Banner\" NL \"1 - Display Bounding Boxes\" NL \"2 - Display Mount Nodes\" NL \"3 - Display Mount Links\" NL \"4 - Display World Limits\" NL \"5 - Display Collision Polygons\" NL \"6 - Display Collision History (EFM?)\" NL \"7 - Display Sort Points";
      details_atomName = "setDebugOn";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Other Methods";
      friendlyName = "setDebugOn";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"modes\", \"List of modes to enable.\", \"default\", \"1,2,3,4,5,6,7\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setDebugOn(%this.modes);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_OtherMethods_setDebugOff) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - OtherMethods";
      description = "disables debug modes specified as (space or comma separated) list. (The debug banner (debug mode 0) has no effect on t2dSceneObjects. It is only relevant to t2dSceneGraphs.)\" @ \"\\n\\nDebug Modes:\" NL \"0 - Scenegraph Statistics Banner\" NL \"1 - Display Bounding Boxes\" NL \"2 - Display Mount Nodes\" NL \"3 - Display Mount Links\" NL \"4 - Display World Limits\" NL \"5 - Display Collision Polygons\" NL \"6 - Display Collision History (EFM?)\" NL \"7 - Display Sort Points";
      details_atomName = "setDebugOff";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Other Methods";
      friendlyName = "setDebugOff";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"modes\", \"List of modes to disable.\", \"default\", \"1,2,3,4,5,6,7\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setDebugOff(%this.modes);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_OtherMethods_setConfigDatablock) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - OtherMethods";
      description = "apply a configuration datablock to this object.";
      details_atomName = "setConfigDatablock";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Other Methods";
      friendlyName = "setConfigDatablock";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"config\", \"Describe_this_field\", \"bool\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setConfigDatablock(%this.config);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_OtherMethods_saveCopy) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - OtherMethods";
      description = "save this object to a file.";
      details_atomName = "saveCopy";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Other Methods";
      friendlyName = "saveCopy";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"filename\", \"File location to store a copy of this object. (NOTE:- The object must be in a scenegraph before it can save the copy to disk.)\", \"default\", \"aStoredCopy.cs\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.loadCopy(expandFilename(%this.filename));";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_OtherMethods_loadCopy) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - OtherMethods";
      description = "load a previously saved object into this one.";
      details_atomName = "loadCopy";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Other Methods";
      friendlyName = "loadCopy";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"filename\", \"Stored object file location. (NOTE:- The object must be in a scenegraph before it can load the copy from disk.)\", \"default\", \"aStoredCopy.cs\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.loadCopy(expandFilename(%this.filename));";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_OtherMethods_copy) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - OtherMethods";
      description = "make owner an exact copy of the specified source object.";
      details_atomName = "copy";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Other Methods";
      friendlyName = "copy";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"srcObj\", \"Source object to copy from.\", \"deafult\", \"name_ID\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"dynamicFields\", \"Copy dynamic fields too?\", \"bool\", \"1\");";
      segmentexecuteAction = "8";
      segmentexecuteAction_0 = "  // NOTE:- The source object must be in a scenegraph before it can be copied. ";
      segmentexecuteAction_1 = "  // This is similar to the “clone()” method but unlike clone, this method ";
      segmentexecuteAction_2 = "  // doesn’t create any objects, it copies one objects configuration to another, ";
      segmentexecuteAction_3 = "  // both of which must exist before the method is called.   ";
      segmentexecuteAction_4 = "  ";
      segmentexecuteAction_5 = "  // Does NOT copy behaviors";
      segmentexecuteAction_6 = "  ";
      segmentexecuteAction_7 = "   %this.owner.copy(%this.owner, %this.copyFields, %this.dynamicFields);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_OtherMethods_cloneWithBehaviors) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - OtherMethods";
      description = "creates a new object of the same type (as the owner) and copies the source configuration to it, including behaviors.";
      details_atomName = "cloneWithBehaviors";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Other Methods";
      friendlyName = "cloneWithBehaviors";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"copyFields\", \"Whether or not the object\'s dynamic fields should be copied to the new object.\", \"bool\", \"1\");";
      segmentexecuteAction = "3";
      segmentexecuteAction_0 = "{   ";
      segmentexecuteAction_1 = "   // NOTE:- The source object must be in a scenegraph before it can be cloned.";
      segmentexecuteAction_2 = "   %this.owner.cloneWithBehaviors(%this.copyFields);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_OtherMethods_clone) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - OtherMethods";
      description = "creates a new object of the same type (as the owner) and copies the source configuration to it.";
      details_atomName = "clone";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Other Methods";
      friendlyName = "clone";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"copyFields\", \"Whether or not the object\'s dynamic fields should be copied to the new object.\", \"bool\", \"1\");";
      segmentexecuteAction = "3";
      segmentexecuteAction_0 = "{   ";
      segmentexecuteAction_1 = "   // NOTE:- The source object must be in a scenegraph before it can be cloned.";
      segmentexecuteAction_2 = "   %this.owner.clone(%this.copyFields);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
