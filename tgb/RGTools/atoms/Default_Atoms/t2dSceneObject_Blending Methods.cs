//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_BlendingMethods_setSrcBlendFactor) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - BlendingMethods";
      description = "set this object\'s source blending factor.";
      details_atomName = "setSrcBlendFactor";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Blending Methods";
      friendlyName = "setSrcBlendFactor";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"srcFactor\", \"Source blending factor.\", \"enum\", \"one_minus_src_alpha\", \"zero\\tone\\tsrc_color\\tone_minus_src_color\\tsrc_alpha\\tone_minus_src_alpha\\tdst_alpha\\tone_minus_dst_alpha\" );";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setSrcBlendFactor(%this.srcFactor);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_BlendingMethods_setDstBlendFactor) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - BlendingMethods";
      description = "set this object\'s destination blending factor.";
      details_atomName = "setDstBlendFactor";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Blending Methods";
      friendlyName = "setDstBlendFactor";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"dstFactor\", \"Destination blending factor.\", \"enum\", \"src_alpha\", \"zero\\tone\\tdst_color\\tone_minus_dst_color\\tsrc_alpha\\tone_minus_src_alpha\\tdst_alpha\\tone_minus_dst_alpha\\tsrc_alpha_saturate\" );";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setDstBlendFactor(%this.dstFactor);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_BlendingMethods_setBlendingStatus) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - BlendingMethods";
      description = "enable/disable blending.";
      details_atomName = "setBlendingStatus";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Blending Methods";
      friendlyName = "setBlendingStatus";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"status\", \"Blending enabled?\", \"bool\", \"1\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setBlendingStatus(%this.status);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_BlendingMethods_setBlending) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - BlendingMethods";
      description = "configure object\'s blending settings.";
      details_atomName = "setBlending";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Blending Methods";
      friendlyName = "setBlending";
      segmentbehaviorFields = "3";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"status\", \"Blending enabled?\", \"bool\", \"1\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"srcFactor\", \"Source blending factor.\", \"enum\", \"one_minus_src_alpha\", \"zero\\tone\\tsrc_color\\tone_minus_src_color\\tsrc_alpha\\tone_minus_src_alpha\\tdst_alpha\\tone_minus_dst_alpha\" );";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"dstFactor\", \"Destination blending factor.\", \"enum\", \"src_alpha\", \"zero\\tone\\tdst_color\\tone_minus_dst_color\\tsrc_alpha\\tone_minus_src_alpha\\tdst_alpha\\tone_minus_dst_alpha\\tsrc_alpha_saturate\" );";
      segmentexecuteAction = "3";
      segmentexecuteAction_0 = "   %this.owner.setBlendingStatus(%this.status);";
      segmentexecuteAction_1 = "   %this.owner.setSrcBlendFactor(%this.srcFactor);";
      segmentexecuteAction_2 = "   %this.owner.setDstBlendFactor(%this.dstFactor);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_BlendingMethods_setBlendColour) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - BlendingMethods";
      description = "set the blending properties for this object.";
      details_atomName = "setBlendColour";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Blending Methods";
      friendlyName = "setBlendColour";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"color\", \"Blending color as 3 floats.\", \"point3f\", \"1.0 1.0 1.0\"); //EFM TEST ME";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"alpha\", \"Blending alpha.\", \"float\", \"1.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setBlendColour(%this.color, %this.alpha);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_BlendingMethods_setBlendColor) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - BlendingMethods";
      description = "set the blending properties for this object.";
      details_atomName = "setBlendColor";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Blending Methods";
      friendlyName = "setBlendColor";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"color\", \"Blending color as 3 floats.\", \"point3f\", \"1.0 1.0 1.0\"); //EFM TEST ME";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"alpha\", \"Blending alpha.\", \"float\", \"1.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setBlendColor(%this.color, %this.alpha);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_BlendingMethods_setBlendAlpha) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - BlendingMethods";
      description = "set blending alpha for this object.";
      details_atomName = "setBlendAlpha";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Blending Methods";
      friendlyName = "setBlendAlpha";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"alpha\", \"Blending alpha.\", \"float\", \"1.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setBlendAlpha(%this.alpha);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
