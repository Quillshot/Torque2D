//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dStaticSprite_Methods_setImageMap) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dStaticSprite - Methods";
      description = "set an image map to be displayed by this object.";
      details_atomName = "setImageMap";
      details_category = "t2dStaticSprite";
      details_eventAction = "action";
      details_subCategory = "Methods";
      friendlyName = "setImageMap";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"imageMapDB\", \"The image map for this sprite to display.\", \"ImageMapDB\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"frame\", \"The frame number of the image map for this sprite to display.\", \"int\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setImageMap(%this.imageMapDB, %this.frame);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dStaticSprite_Methods_setFrame) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dStaticSprite - Methods";
      description = "set the frame of the image map for this sprite to use.";
      details_atomName = "setFrame";
      details_category = "t2dStaticSprite";
      details_eventAction = "action";
      details_subCategory = "Methods";
      friendlyName = "setFrame";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"frame\", \"The frame to display.\", \"int\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setFrame(%this.frame);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
