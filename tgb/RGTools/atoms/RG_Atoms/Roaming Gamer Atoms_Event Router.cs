//--- OBJECT WRITE BEGIN ---
new ScriptObject(event_RoamingGamerAtoms_EventRouter_onPostGlobalEvent) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Event Router ->";
      description = "When a named event is posted to the global event router";
      details_atomName = "onPostGlobalEvent";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "event";
      details_subCategory = "Event Router";
      friendlyName = "onPostGlobalEvent() ->";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"EventName\", \"Name of the event to post.\", \"default\", \"myEvent\"); ";
      segmentonAddToScene = "6";
      segmentonAddToScene_0 = "   %eventName = %this.EventName;";
      segmentonAddToScene_1 = "   ";
      segmentonAddToScene_2 = "   if(isObject( GER ) )";
      segmentonAddToScene_3 = "   {";
      segmentonAddToScene_4 = "      GER.registerHandlerMethod( %eventName, executeAction, %this );";
      segmentonAddToScene_5 = "   }";
      segments = "behaviorFields\tonAddToScene";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(event_RoamingGamerAtoms_EventRouter_onPostEvent_NamedRouter) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Event Router ->";
      description = "When a named event is posted to the specified event router";
      details_atomName = "onPostEvent_NamedRouter";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "event";
      details_subCategory = "Event Router";
      friendlyName = "onPostEvent_NamedRouter() ->";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"RouterName\", \"Name of the router to post the event to.\", \"default\", \"GER\"); ";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"EventName\", \"Name of the event to post.\", \"default\", \"myEvent\"); ";
      segmentonAddToScene = "11";
      segmentonAddToScene_0 = "   %eventRouter = %this.RouterName;";
      segmentonAddToScene_1 = "   %eventName = %this.EventName;";
      segmentonAddToScene_10 = "   }";
      segmentonAddToScene_2 = "   if(!isObject( %eventRouter ) )";
      segmentonAddToScene_3 = "   {";
      segmentonAddToScene_4 = "      createEventRouter( %eventRouter );";
      segmentonAddToScene_5 = "   }";
      segmentonAddToScene_6 = "  ";
      segmentonAddToScene_7 = "   if(isObject( %eventRouter ) )";
      segmentonAddToScene_8 = "   {";
      segmentonAddToScene_9 = "      %eventRouter.registerHandlerMethod( %eventName, executeAction, %this );";
      segments = "behaviorFields\tonAddToScene";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_EventRouter_PostNamedRouterEvent) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Events";
      description = "post a specified event to a named event router.";
      details_atomName = "PostNamedRouterEvent";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "Event Router";
      friendlyName = "PostNamedRouterEvent";
      segmentbehaviorFields = "3";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"RouterName\", \"Name of the router to post the event to.\", \"default\", \"GER\"); ";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"EventName\", \"Name of the event to post.\", \"default\", \"myEvent\"); ";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"IncludeID\", \"Post behavior\'s ID as first argument.\", \"bool\", \"true\");   ";
      segmentexecuteAction = "19";
      segmentexecuteAction_0 = "   %eventRouter = %this.RouterName;";
      segmentexecuteAction_1 = "   %eventName = %this.EventName;";
      segmentexecuteAction_10 = "      if( %this.IncludeID )";
      segmentexecuteAction_11 = "      {";
      segmentexecuteAction_12 = "         %eventRouter.postEvent( %eventName, %this.getId() );";
      segmentexecuteAction_13 = "      }";
      segmentexecuteAction_14 = "      else";
      segmentexecuteAction_15 = "      {";
      segmentexecuteAction_16 = "         %eventRouter.postEvent( %eventName );";
      segmentexecuteAction_17 = "      }";
      segmentexecuteAction_18 = "   }";
      segmentexecuteAction_2 = "   ";
      segmentexecuteAction_3 = "   if(!isObject( %eventRouter ) )";
      segmentexecuteAction_4 = "   {";
      segmentexecuteAction_5 = "      createEventRouter( %eventRouter );";
      segmentexecuteAction_6 = "   }";
      segmentexecuteAction_7 = "   ";
      segmentexecuteAction_8 = "   if(isObject( %eventRouter ) )";
      segmentexecuteAction_9 = "   {";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_EventRouter_PostGlobalEvent) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Events";
      description = "post a specified event to the global event router.";
      details_atomName = "PostGlobalEvent";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "Event Router";
      friendlyName = "PostGlobalEvent";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"EventName\", \"Name of the event to post.\", \"default\", \"myEvent\"); ";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"IncludeID\", \"Post behavior\'s ID as first argument.\", \"bool\", \"true\");   ";
      segmentexecuteAction = "12";
      segmentexecuteAction_0 = "   %eventName = %this.EventName;";
      segmentexecuteAction_1 = "   if(isObject( GER ) )";
      segmentexecuteAction_10 = "      }";
      segmentexecuteAction_11 = "   }";
      segmentexecuteAction_2 = "   {";
      segmentexecuteAction_3 = "      if( %this.IncludeID )";
      segmentexecuteAction_4 = "      {";
      segmentexecuteAction_5 = "         postEvent( %eventName, %this.getId() );";
      segmentexecuteAction_6 = "      }";
      segmentexecuteAction_7 = "      else";
      segmentexecuteAction_8 = "      {";
      segmentexecuteAction_9 = "         postEvent( %eventName );";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
