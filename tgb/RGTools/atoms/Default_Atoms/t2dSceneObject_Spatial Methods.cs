//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_SpatialMethods_setWorldLimit) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Spatial Methods";
      description = "set the world limit dimension and response for this object.";
      details_atomName = "setWorldLimit";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Spatial Methods";
      friendlyName = "setWorldLimit";
      segmentbehaviorFields = "6";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"mode\", \"World limit response mode.\", \"enum\", \"off\" TAB \"null\" TAB \"clamp\" TAB \"bounce\" TAB \"sticky\" TAB \"kill\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"minX\", \"Minimum X dimension of world limit.\", \"float\", \"-50.0\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"minY\", \"Minimum Y dimension of world limit.\", \"float\", \"-37.5\");";
      segmentbehaviorFields_3 = "   %behavior.addBehaviorField( \"maxX\", \"Maximum X dimension of world limit.\", \"float\", \"50.0\");";
      segmentbehaviorFields_4 = "   %behavior.addBehaviorField( \"maxY\", \"Maximum Y dimension of world limit.\", \"float\", \"37.5\");";
      segmentbehaviorFields_5 = "   %behavior.addBehaviorField( \"callback\", \"Call onWorldLimit() callback when owner reaches world limit.\", \"bool\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setWorldLimit(%this.mode, %this.minX, %this.minY, %this.maxX, %this.maxY, %this.callback);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_SpatialMethods_setWidth) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Spatial Methods";
      description = "set the width of this object.";
      details_atomName = "setWidth";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Spatial Methods";
      friendlyName = "setWidth";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"width\", \"New width for this object\", \"float\", \"1.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setWidth(%this.width);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_SpatialMethods_setSizeY) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Spatial Methods";
      description = "set the Y dimension (height) of this object.";
      details_atomName = "setSizeY";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Spatial Methods";
      friendlyName = "setSizeY";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"height\", \"New height for this object.\", \"float\", \"1.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setSizeY(%this.height);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_SpatialMethods_setSizeX) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Spatial Methods";
      description = "set the X dimension (width) of this object.";
      details_atomName = "setSizeX";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Spatial Methods";
      friendlyName = "setSizeX";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"width\", \"New width for this object.\", \"float\", \"1.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setSizeX(%this.width);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_SpatialMethods_setSize) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Spatial Methods";
      description = "set the width and height of this object.";
      details_atomName = "setSize";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Spatial Methods";
      friendlyName = "setSize";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"width\", \"New width for this object.\", \"float\", \"1.0\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"height\", \"New object for this object.\", \"float\", \"1.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setSize(%this.width, %this.height);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_SpatialMethods_setRotationTargetOff) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Spatial Methods";
      description = "cancel a rotation target as set by setRotationTarget().";
      details_atomName = "setRotationTargetOff";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Spatial Methods";
      friendlyName = "setRotationTargetOff";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setRotationTargetOff();";
      segments = "executeAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_SpatialMethods_setRotationTarget) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Spatial Methods";
      description = "set a target rotation for the object.";
      details_atomName = "setRotationTarget";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Spatial Methods";
      friendlyName = "setRotationTarget";
      segmentbehaviorFields = "6";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"rotationTarget\", \"The target rotation (angle in degrees).\", \"float\", \"0\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"speed\", \"Degree\'s per second at which to rotate.\", \"float\", \"1.0\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"autoStop\", \"Stop rotating when target is reached?\", \"bool\", \"1\");";
      segmentbehaviorFields_3 = "   %behavior.addBehaviorField( \"callback\", \"Execute onRotationTarget() when target is reached?\", \"bool\", \"0\");";
      segmentbehaviorFields_4 = "   %behavior.addBehaviorField( \"snap\", \"Snap to target when within margin degrees?\", \"bool\", \"1\");";
      segmentbehaviorFields_5 = "   %behavior.addBehaviorField( \"margin\", \"Rotational distance at which to snap.\", \"float\", \"0.1\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setRotationTarget(%this.rotationTarget, %this.autoStop, %this.callback, %this.snap, %this.margin);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_SpatialMethods_setRotation) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Spatial Methods";
      description = "set this object\'s rotation to a specified angle.";
      details_atomName = "setRotation";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Spatial Methods";
      friendlyName = "setRotation";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"angle\", \"This object\'s new angle.\", \"float\", \"0.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setRotation(%this.angle);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_SpatialMethods_setPositionY) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Spatial Methods";
      description = "set this object\'s Y position.";
      details_atomName = "setPositionY";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Spatial Methods";
      friendlyName = "setPositionY";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"Y\", \"Y position.\", \"float\", \"1.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setPositionY(%this.Y);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_SpatialMethods_setPositionX) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Spatial Methods";
      description = "set this object\'s X position.";
      details_atomName = "setPositionX";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Spatial Methods";
      friendlyName = "setPositionX";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"X\", \"X position.\", \"float\", \"1.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setPositionX(%this.X);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_SpatialMethods_setPositionTargetOff) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Spatial Methods";
      description = "cancel a position target as set by setPositionTarget().";
      details_atomName = "setPositionTargetOff";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Spatial Methods";
      friendlyName = "setPositionTargetOff";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setPositionTargetOff();";
      segments = "executeAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_SpatialMethods_setPositionTarget) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Spatial Methods";
      description = "set a position target for this object.";
      details_atomName = "setPositionTarget";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Spatial Methods";
      friendlyName = "setPositionTarget";
      segmentbehaviorFields = "5";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"target\", \"XY position target for this object.\", \"point2f\", \"0.0 0.0\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"autoStop\", \"true - stop automatically upon reaching target; false - continue moving.\", \"bool\", \"1\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"callback\", \"Call onPositionTarget() upon reaching the target.\", \"bool\", \"0\");";
      segmentbehaviorFields_3 = "   %behavior.addBehaviorField( \"snap\", \"Snap into position when within margin distance.\", \"bool\", \"1\");";
      segmentbehaviorFields_4 = "   %behavior.addBehaviorField( \"margin\", \"Distance within which to snap.\", \"float\", \"0.1\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setPositionTarget(%this.target.X, %this.target.Y, %this.autoStop, %this.callback, %this.snap, %this.margin);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_SpatialMethods_setPosition) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Spatial Methods";
      description = "set this object\'s position (as specified).";
      details_atomName = "setPosition";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Spatial Methods";
      friendlyName = "setPosition";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"Position\", \"Position to set this object to.\", \"point2f\", \"0.0 0.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setPosition(%this.Position.x, %this.Position.y);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_SpatialMethods_setLayer) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Spatial Methods";
      description = "set this object\'s layer.";
      details_atomName = "setLayer";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Spatial Methods";
      friendlyName = "setLayer";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"layer\", \"Layer to render this object in, 0..31 (top to bottom).\", \"int\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setLayer(%this.layer);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_SpatialMethods_setHeight) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Spatial Methods";
      description = "set this object\'s height.";
      details_atomName = "setHeight";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Spatial Methods";
      friendlyName = "setHeight";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"height\", \"New height for this object.\", \"float\", \"1.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setHeight(%this.height);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_SpatialMethods_setGraphGroup) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Spatial Methods";
      description = "set this object\'s graph group.";
      details_atomName = "setGraphGroup";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Spatial Methods";
      friendlyName = "setGraphGroup";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"newGroup\", \"New graph group for this object (0..31).\", \"int\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setGraphGroup(%this.newGroup);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_SpatialMethods_setflipY) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Spatial Methods";
      description = "flip Y-axis while rendering.";
      details_atomName = "setflipY";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Spatial Methods";
      friendlyName = "setflipY";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"flipY\", \"Flip Y-axis?\", \"bool\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setflipY(%this.flipY);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_SpatialMethods_setflipX) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Spatial Methods";
      description = "flip X-axis while rendering.";
      details_atomName = "setflipX";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Spatial Methods";
      friendlyName = "setflipX";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"flipX\", \"Flip X-axis?\", \"bool\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setflipX(%this.flipX);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_SpatialMethods_setFlip) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Spatial Methods";
      description = "flip X-axis and/or Y-axis while rendering.";
      details_atomName = "setFlip";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Spatial Methods";
      friendlyName = "setFlip";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"flipX\", \"Flip X-axis?\", \"bool\", \"0\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"flipY\", \"Flip Y-axis?\", \"bool\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setFlip(%this.flipX, %this.flipY);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_SpatialMethods_setAutoRotation) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Spatial Methods";
      description = "autorotate at specified degrees-per-second rate.";
      details_atomName = "setAutoRotation";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Spatial Methods";
      friendlyName = "setAutoRotation";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"degreesPerSecond\", \"Degrees to rotate per second\", \"float\", \"0.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setAutoRotation(%this.degreesPerSecond);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_SpatialMethods_setArea) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Spatial Methods";
      description = "set this object\'s dimension by specifying its upper-left and lower-right corner positions.";
      details_atomName = "setArea";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Spatial Methods";
      friendlyName = "setArea";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"upperLeft\", \"Describe_this_field\", \"point2f\", \"-1.0 -1.0\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"lowerRight\", \"Describe_this_field\", \"point2f\", \"1.0 1.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setArea(%this.upperLeft.x, %this.upperLeft.y, %this.lowerRight.x, %this.lowerRight.y);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_SpatialMethods_rotateTo) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Spatial Methods";
      description = "set a rotation target and sends the object toward that target.";
      details_atomName = "rotateTo";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Spatial Methods";
      friendlyName = "rotateTo";
      segmentbehaviorFields = "6";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"rotationTarget\", \"The target rotation (angle in degrees).\", \"float\", \"0\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"speed\", \"Degree\'s per second at which to rotate.\", \"float\", \"1.0\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"autoStop\", \"Stop rotating when target is reached?\", \"bool\", \"1\");";
      segmentbehaviorFields_3 = "   %behavior.addBehaviorField( \"callback\", \"Execute onRotationTarget() when target is reached?\", \"bool\", \"0\");";
      segmentbehaviorFields_4 = "   %behavior.addBehaviorField( \"snap\", \"Snap to target when within margin degrees?\", \"bool\", \"1\");";
      segmentbehaviorFields_5 = "   %behavior.addBehaviorField( \"margin\", \"Rotational distance at which to snap.\", \"float\", \"0.1\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.rotateTo(%this.rotationTarget, %this.speed, %this.autoStop, %this.callback, %this.snap, %this.margin);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_SpatialMethods_moveTo) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Spatial Methods";
      description = "set a target position for the object and move it toward that target.";
      details_atomName = "moveTo";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Spatial Methods";
      friendlyName = "moveTo";
      segmentbehaviorFields = "6";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"target\", \"The target position (angle in degrees).\", \"point2f\", \"0.0 0.0\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"speed\", \"Movement rate.\", \"float\", \"1.0\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"autoStop\", \"Stop moving when target is reached?\", \"bool\", \"1\");";
      segmentbehaviorFields_3 = "   %behavior.addBehaviorField( \"callback\", \"Execute onPositionTarget() when target is reached?\", \"bool\", \"0\");";
      segmentbehaviorFields_4 = "   %behavior.addBehaviorField( \"snap\", \"Snap to target when within margin degrees?\", \"bool\", \"1\");";
      segmentbehaviorFields_5 = "   %behavior.addBehaviorField( \"margin\", \"Rotational distance at which to snap.\", \"float\", \"0.1\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.moveTo(%this.target.X, %this.target.Y, %this.speed, %this.autoStop, %this.callback, %this.snap, %this.margin);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
