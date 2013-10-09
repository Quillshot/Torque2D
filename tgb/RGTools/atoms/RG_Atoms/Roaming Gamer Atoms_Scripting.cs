//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_Scripting_ExecuteScript) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Scripting";
      description = "execute the specified torque script. (Can be any valid Torque Script code.)";
      details_atomName = "ExecuteScript";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "Scripting";
      friendlyName = "ExecuteScript";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"theScript\", \"Specify the torque script code to execute here. \", \"default\", \"echo(RoamingGamer);\");   ";
      segmentexecuteAction = "3";
      segmentexecuteAction_0 = "   %evalScript = %this.theScript;";
      segmentexecuteAction_1 = "   //error( %evalScript );";
      segmentexecuteAction_2 = "   eval( %evalScript );   ";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_Scripting_ExecuteOwnerMethod) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Scripting";
      description = "execute the specified owner object method.";
      details_atomName = "ExecuteOwnerMethod";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "Scripting";
      friendlyName = "ExecuteOwnerMethod";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"theScript\", \"Specify the torque script code to execute here. \", \"default\", \"dump();\");   ";
      segmentexecuteAction = "4";
      segmentexecuteAction_0 = "   %owner = %this.owner;";
      segmentexecuteAction_1 = "   %evalScript = %owner.getID() @ \".\" @ %this.theScript;";
      segmentexecuteAction_2 = "   //error( %evalScript );";
      segmentexecuteAction_3 = "   eval( %evalScript );   ";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
