//--- OBJECT WRITE BEGIN ---
new ScriptObject(event_BehaviorCallbacks_Trigger_onStay) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Animation Event ->";
      description = "When an object stays in this trigger (every tick)";
      details_atomName = "onStay";
      details_category = "Behavior Callbacks";
      details_eventAction = "event";
      details_subCategory = "Trigger";
      friendlyName = "onStay() ->";
      segmentonAddToScene = "1";
      segmentonAddToScene_0 = "   %this.owner.setStayCallback(true);";
      segmentonStay = "1";
      segmentonStay_0 = "   %this.executeAction();";
      segments = "onAddToScene\tonStay";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(event_BehaviorCallbacks_Trigger_onLeave) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Animation Event ->";
      description = "When an object leaves this trigger";
      details_atomName = "onLeave";
      details_category = "Behavior Callbacks";
      details_eventAction = "event";
      details_subCategory = "Trigger";
      friendlyName = "onLeave() ->";
      segmentonAddToScene = "1";
      segmentonAddToScene_0 = "   %this.owner.setLeaveCallback(true);";
      segmentonLeave = "1";
      segmentonLeave_0 = "   %this.executeAction();";
      segments = "onAddToScene\tonLeave";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(event_BehaviorCallbacks_Trigger_onEnter) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Trigger Event ->";
      description = "When an object enters this trigger";
      details_atomName = "onEnter";
      details_category = "Behavior Callbacks";
      details_eventAction = "event";
      details_subCategory = "Trigger";
      friendlyName = "onEnter() ->";
      segmentonAddToScene = "1";
      segmentonAddToScene_0 = "   %this.owner.setEnterCallback(true);";
      segmentonEnter = "1";
      segmentonEnter_0 = "   %this.executeAction();";
      segments = "onAddToScene\tonEnter";
};
//--- OBJECT WRITE END ---
