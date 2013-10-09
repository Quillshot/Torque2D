//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_MountingMethods_setMountTrackRotation) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Mounting Methods";
      description = "set whether this object tracks the rotation of any object is may be mounted to.";
      details_atomName = "setMountTrackRotation";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Mounting Methods";
      friendlyName = "setMountTrackRotation";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"trackrotation\", \"Whether or not to track the rotation of the object this is being mounted to.\", \"bool\", \"1\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setMountTrackRotation(%this.trackRotation);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_MountingMethods_setMountRotation) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Mounting Methods";
      description = "set the (fixed) angle at which this object is mounted to another object.";
      details_atomName = "setMountRotation";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Mounting Methods";
      friendlyName = "setMountRotation";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"angle\", \"Angle of rotation on mount point.\", \"float\", \"0.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setMountRotation(%this.angle);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_MountingMethods_setMountOwned) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Mounting Methods";
      description = "set whether this object is owned by the object it is mounted to (this gets deleted if its owner is deleted).";
      details_atomName = "setMountOwned";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Mounting Methods";
      friendlyName = "setMountOwned";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"ownedByMount\", \"Describe_this_field\", \"bool\", \"1\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setMountOwned(%this.ownedByMount);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_MountingMethods_setMountinheritAttributes) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Mounting Methods";
      description = "set whether this object inherits the attributes (enabled, visible, paused, and flip) of the object it is mounted to.";
      details_atomName = "setMountinheritAttributes";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Mounting Methods";
      friendlyName = "setMountinheritAttributes";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"inheritAttributes\", \"Inherit the attributes: enabled, visible, paused, and flip from the mount parent.\", \"bool\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setMountinheritAttributes(%this.inheritAttributes);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_MountingMethods_setMountForce) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Mounting Methods";
      description = "set the magnitude of the force constantly applied to the object to keep it at the mount point. A value of 0 makes the mount rigid, and thus stuck to the object it is mounted to.";
      details_atomName = "setMountForce";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Mounting Methods";
      friendlyName = "setMountForce";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"force\", \"Strength of mount adherence (0 is strongest, larger values are weaker).\", \"integer\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setMountForce(%this.force);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_MountingMethods_setLinkPoint) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Mounting Methods";
      description = "move a link point.";
      details_atomName = "setLinkPoint";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Mounting Methods";
      friendlyName = "setLinkPoint";
      segmentbehaviorFields = "3";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"id\", \"ID of link point to move.\", \"integer\", \"0\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"offsetx\", \"New x offset for the link point in object space.\", \"integer\", \"0\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"offsety\", \"New y offset for the link point in object space.\", \"integer\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setLinkPoint(%this.id, %this.offsetX, %this.offsetY);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_MountingMethods_setAutoMountRotation) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Mounting Methods";
      description = "set the speed at which this object\'s mount point(s) rotate (about the objects center)?";
      details_atomName = "setAutoMountRotation";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Mounting Methods";
      friendlyName = "setAutoMountRotation";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"angle\", \"Describe_this_field\", \"bool\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setAutoMountRotation(%this.angle);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_MountingMethods_removeLinkPoint) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Mounting Methods";
      description = "remvoe a specified link point from this object.";
      details_atomName = "removeLinkPoint";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Mounting Methods";
      friendlyName = "removeLinkPoint";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"id\", \"Link point to remove.\", \"int\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.removeLinkPoint(%this.id);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_MountingMethods_removeAllLinkPoints) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Mounting Methods";
      description = "remove all link points from this object.";
      details_atomName = "removeAllLinkPoints";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Mounting Methods";
      friendlyName = "removeAllLinkPoints";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.removeAllLinkPoints();";
      segments = "executeAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_MountingMethods_mount) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Mounting Methods";
      description = "mount this object to another specified object with additional attributes.";
      details_atomName = "mount";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Mounting Methods";
      friendlyName = "mount";
      segmentbehaviorFields = "7";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"object\", \"Object to mount to.\", \"object\", \"t2dSceneObject\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"offset\", \"Offset of mount.\", \"point2f\", \"0.0 0.0\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"force\", \"Magnitude of the force constantly applied to the object to keep it at the mount point. A value of 0 makes the mount rigid, and thus stuck to the object it is mounted to.\", \"float\", \"0\");";
      segmentbehaviorFields_3 = "   %behavior.addBehaviorField( \"trackRotation\", \"Track the rotation of the mount-to object?\", \"bool\", \"0\");";
      segmentbehaviorFields_4 = "   %behavior.addBehaviorField( \"sendToMount\", \"Send object directly to mount point?\", \"bool\", \"0\");";
      segmentbehaviorFields_5 = "   %behavior.addBehaviorField( \"ownedByMount\", \"Owned by mount-to object?\", \"bool\", \"0\");";
      segmentbehaviorFields_6 = "   %behavior.addBehaviorField( \"inheritAttributes\", \"Inherit enabled, visible, paused, and flip attributes from mount-to object?\", \"bool\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.mount(%this.object, %this.offset, %this.force, %this.trackRotation, %this.sendToMount, %this.ownedByMount, %this.inheritAttributes);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_MountingMethods_dismount) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Mounting Methods";
      description = "Dismount (unmount from) whatever object this is mounted to.";
      details_atomName = "dismount";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Mounting Methods";
      friendlyName = "dismount";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.dismount();";
      segments = "executeAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_MountingMethods_detachGui) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Mounting Methods";
      description = "detach all attached GuiControls from this object.";
      details_atomName = "detachGui";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Mounting Methods";
      friendlyName = "detachGui";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.detachGui();";
      segments = "executeAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_MountingMethods_attachGui) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Mounting Methods";
      description = "attach a GuiControl to the object";
      details_atomName = "attachGui";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Mounting Methods";
      friendlyName = "attachGui";
      segmentbehaviorFields = "3";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"guiControlName\", \"Name of the GUI to attach to this object.\", \"default\", \"myGUI\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"sceneWindow\", \"Name of the t2dSceneWindow to bind the GuiControl to.\", \"default\", \"mySceneWindow\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"sizeControl\", \"true - Size the GuiControl to the size of this object; false - Display as is.\", \"bool\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.attachGui(%this.guiControlName.getID(), %this.sceneWindow.getID(), %this.sizeControl);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_MountingMethods_addLinkPoint) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Mounting Methods";
      description = "add a link point to this object.";
      details_atomName = "addLinkPoint";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Mounting Methods";
      friendlyName = "addLinkPoint";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"offset\", \"Offset of new point.\", \"point2f\", \"1.0 -1.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.addLinkPoint(%this.offset);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
