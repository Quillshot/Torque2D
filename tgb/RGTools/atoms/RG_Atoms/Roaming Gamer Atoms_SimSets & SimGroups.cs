//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_SimSetsSimGroups_RemoveFromSet) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "SimSets & SimGroups";
      description = "adds the behavior\'s owner object to a named SimSet.";
      details_atomName = "RemoveFromSet";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "SimSets & SimGroups";
      friendlyName = "RemoveFromSet";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"SetName\", \"Name of SimSet to add owner object to.\", \"default\", \"aSimSet\");   ";
      segmentexecuteAction = "4";
      segmentexecuteAction_0 = "   // If the set doesn\'t exist, there is no work to do";
      segmentexecuteAction_1 = "   if(!isObject(%this.SetName)) return;";
      segmentexecuteAction_2 = "   ";
      segmentexecuteAction_3 = "   (%this.SetName).remove( %this.owner );";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_SimSetsSimGroups_DeleteSet) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "SimSets & SimGroups";
      description = "adds the behavior\'s owner object to a named SimSet.";
      details_atomName = "DeleteSet";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "SimSets & SimGroups";
      friendlyName = "DeleteSet";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"SetName\", \"Name of SimSet to add owner object to.\", \"default\", \"aSimSet\");   ";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"DeleteObjects\", \"If true, delete all the objects in the set before deleting the set.\", \"bool\", \"false\");   ";
      segmentexecuteAction = "14";
      segmentexecuteAction_0 = "   // If the set doesn\'t exist, there is no work to do";
      segmentexecuteAction_1 = "   if(!isObject(%this.SetName)) return;";
      segmentexecuteAction_10 = "      }      ";
      segmentexecuteAction_11 = "   }";
      segmentexecuteAction_12 = "   ";
      segmentexecuteAction_13 = "   (%this.SetName).schedule(0,delete); // Safer delete";
      segmentexecuteAction_2 = "   ";
      segmentexecuteAction_3 = "   if(%this.DeleteObjects)";
      segmentexecuteAction_4 = "   {";
      segmentexecuteAction_5 = "      while( (%this.SetName).getCount() != 0 )";
      segmentexecuteAction_6 = "      {";
      segmentexecuteAction_7 = "         %object = (%this.SetName).getObject( 0 );";
      segmentexecuteAction_8 = "         ( %object ).schedule(0,delete); // Safer delete";
      segmentexecuteAction_9 = "         (%this.SetName).remove( %object );";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_SimSetsSimGroups_ClearSet) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "SimSets & SimGroups";
      description = "removes all objects from a set.";
      details_atomName = "ClearSet";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "SimSets & SimGroups";
      friendlyName = "ClearSet";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"SetName\", \"Name of SimSet to add owner object to.\", \"default\", \"aSimSet\");   ";
      segmentexecuteAction = "8";
      segmentexecuteAction_0 = "   // If the set doesn\'t exist, there is no work to do";
      segmentexecuteAction_1 = "   if(!isObject(%this.SetName)) return;";
      segmentexecuteAction_2 = "   ";
      segmentexecuteAction_3 = "   while( (%this.SetName).getCount() != 0 )";
      segmentexecuteAction_4 = "   {";
      segmentexecuteAction_5 = "      %object = (%this.SetName).getObject( 0 );";
      segmentexecuteAction_6 = "      (%this.SetName).remove( %object );";
      segmentexecuteAction_7 = "   }";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_SimSetsSimGroups_AddToSet) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "SimSets & SimGroups";
      description = "adds the behavior\'s owner object to a named SimSet.";
      details_atomName = "AddToSet";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "SimSets & SimGroups";
      friendlyName = "AddToSet";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"SetName\", \"Name of SimSet to add owner object to.\", \"default\", \"aSimSet\");   ";
      segmentexecuteAction = "4";
      segmentexecuteAction_0 = "   // Create SimSet if it does not yet exist.";
      segmentexecuteAction_1 = "   if(!isObject(%this.SetName)) new SimSet(%this.SetName);";
      segmentexecuteAction_2 = "   ";
      segmentexecuteAction_3 = "   (%this.SetName).add( %this.owner );";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
