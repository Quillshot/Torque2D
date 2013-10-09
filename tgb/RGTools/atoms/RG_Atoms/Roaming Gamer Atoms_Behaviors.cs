//--- OBJECT WRITE BEGIN ---
new ScriptObject(event_RoamingGamerAtoms_Behaviors_GenericBehaviorCallback) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Generic Behavior Callback ->";
      description = "When the named behavior callback occurs";
      details_atomName = "GenericBehaviorCallback";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "event";
      details_subCategory = "Behaviors";
      friendlyName = "*() ->";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"CallbackName\", \"Name of the callback to attach (generate) to this behavior.\", \"default\", \"aNewCallbackName\" );";
      segmentonAddToScene = "10";
      segmentonAddToScene_0 = "   // If a callback by the specified name is already attached to this behavior";
      segmentonAddToScene_1 = "   // do nothing.";
      segmentonAddToScene_2 = "   if(%this.isMethod(%this.CallbackName)) return;";
      segmentonAddToScene_3 = "   ";
      segmentonAddToScene_4 = "   %evalScript = \"GenericBehaviorCallback::\" @ %this.CallbackName @ \"(%this)\" NL";
      segmentonAddToScene_5 = "   \"{\" NL";
      segmentonAddToScene_6 = "   \"   %this.executeAction();\" NL";
      segmentonAddToScene_7 = "   \"}\";";
      segmentonAddToScene_8 = "   //error( %evalScript );";
      segmentonAddToScene_9 = "   eval( %evalScript );      ";
      segments = "behaviorFields\tonAddToScene";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_Behaviors_BroadcastBehaviorMethod) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Events";
      description = "broadcast the specified behavior method to all other behaviors attached to this behavior\'s owner.";
      details_atomName = "BroadcastBehaviorMethod";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "Behaviors";
      friendlyName = "BroadcastBehaviorMethod";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"behaviorMethod\", \"Unadorned method name to broadcast to owner\'s other behaviors.\", \"default\", \"aMethodName\");   ";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.broadcastMethod( %this.behaviorMethod );";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
