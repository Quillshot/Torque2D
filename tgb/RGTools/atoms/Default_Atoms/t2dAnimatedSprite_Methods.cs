//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dAnimatedSprite_Methods_setFrameChangeCallback) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dAnimatedSprite - Methods";
      description = "enable or disable onFrameChange() callback for this object.";
      details_atomName = "setFrameChangeCallback";
      details_category = "t2dAnimatedSprite";
      details_eventAction = "action";
      details_subCategory = "Methods";
      friendlyName = "setFrameChangeCallback";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"status\", \"Enable or disable the callback status.\", \"bool\", \"1\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setFrameChangeCallback(%this.status);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dAnimatedSprite_Methods_setAnimationFrame) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dAnimatedSprite - Methods";
      description = "change animation to specified frame.";
      details_atomName = "setAnimationFrame";
      details_category = "t2dAnimatedSprite";
      details_eventAction = "action";
      details_subCategory = "Methods";
      friendlyName = "setAnimationFrame";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"frame\", \"Frame number to change to.\", \"int\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setAnimationFrame(%this.frame);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dAnimatedSprite_Methods_setAnimation) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dAnimatedSprite - Methods";
      description = "set and play a specified animation.";
      details_atomName = "setAnimation";
      details_category = "t2dAnimatedSprite";
      details_eventAction = "action";
      details_subCategory = "Methods";
      friendlyName = "setAnimation";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"animation\", \"Set and play this animation.\", \"t2dAnimationDatablock\"); ";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setAnimation(%this.animation);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dAnimatedSprite_Methods_playAnimation) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dAnimatedSprite - Methods";
      description = "set and play a specified animation with optional settings.";
      details_atomName = "playAnimation";
      details_category = "t2dAnimatedSprite";
      details_eventAction = "action";
      details_subCategory = "Methods";
      friendlyName = "playAnimation";
      segmentbehaviorFields = "4";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"animation\", \"Set and play this animation.\", \"t2dAnimationDatablock\"); ";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"autoRestore\", \"Play previous animation when this one finishes.\", \"bool\", \"0\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"startFrame\", \"Start animation at this frame (-1 => start from beginning).\", \"int\", \"-1\");";
      segmentbehaviorFields_3 = "   %behavior.addBehaviorField( \"mergeTime\", \"Merge this animation with the last (50%/50%).\", \"bool\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.playAnimation(%this.animation, %this.autoRestore, %this.startFrame, %this.mergeTime);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
