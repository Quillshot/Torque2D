//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_CollisionMethods_setCollisionSuppress) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Collision Methods";
      description = "turn on (or off) all collision detection and response with this object.";
      details_atomName = "setCollisionSuppress";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Collision Methods";
      friendlyName = "setCollisionSuppress";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"status\", \"true - suppress collisions; false - enable them.\", \"bool\", \"1\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setCollisionSuppress(%this.status);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_CollisionMethods_setCollisionResponse) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Collision Methods";
      description = "set objects\'s collision response.";
      details_atomName = "setCollisionResponse";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Collision Methods";
      friendlyName = "setCollisionResponse";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"response\", \"Collision response.\", \"enum\", \"bounce\", \"rigid\"TAB\"bounce\"TAB\"clamp\"TAB\"sticky\"TAB\"kill\"TAB\"custom\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setCollisionResponse(%this.response);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_CollisionMethods_setCollisionPolyScale) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Collision Methods";
      description = "scale this objects collision polygon.";
      details_atomName = "setCollisionPolyScale";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Collision Methods";
      friendlyName = "setCollisionPolyScale";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"widthScale\", \"Scale factor for the collision polygon width.\", \"float\", \"1.0\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"heightScale\", \"Scale factor for the collision polygon height.\", \"float\", \"1.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setCollisionPolyScale(%this.widthScale, %this.heightScale);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_CollisionMethods_setCollisionPhysicsSend) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Collision Methods";
      description = "determine whether this object sends physics onCollision().";
      details_atomName = "setCollisionPhysicsSend";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Collision Methods";
      friendlyName = "setCollisionPhysicsSend";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"send\", \"Does this object send physics on collision?\", \"bool\", \"1\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setCollisionPhysicsSend(%this.send);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_CollisionMethods_setCollisionPhysicsReceive) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Collision Methods";
      description = "determine whether this object receives physics onCollision().";
      details_atomName = "setCollisionPhysicsReceive";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Collision Methods";
      friendlyName = "setCollisionPhysicsReceive";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"receive\", \"Does this object receive physics on collision?\", \"bool\", \"1\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setCollisionPhysicsReceive(%this.receive);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_CollisionMethods_setCollisionPhysics) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Collision Methods";
      description = "determine whether this object sends and/or receives physics onCollision().";
      details_atomName = "setCollisionPhysics";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Collision Methods";
      friendlyName = "setCollisionPhysics";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"send\", \"Does this object send physics on collision?\", \"bool\", \"1\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"receive\", \"Does this object receive physics on collision?\", \"bool\", \"1\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setCollisionPhysics(%this.send, %this.receive);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_CollisionMethods_setCollisionMaxIterations) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Collision Methods";
      description = "set the maximum number of iterations that will be taken through the collision detection and resolution systems in a single frame.";
      details_atomName = "setCollisionMaxIterations";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Collision Methods";
      friendlyName = "setCollisionMaxIterations";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"count\", \"Maximum number of collision iterations per frame.\", \"integer\", \"4\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setCollisionMaxIterations(%this.count);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_CollisionMethods_setCollisionMasks) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Collision Methods";
      description = "Response description.";
      details_atomName = "setCollisionMasks";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Collision Methods";
      friendlyName = "setCollisionMasks";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"groupMask\", \"Graph Group(s) to enable collision with.\", \"bitmask\", \"0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31\");   ";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"layerMask\", \"Rendering Layer(s) to enable collision with.\", \"bitmask\", \"0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31\");   ";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setCollisionMasks(%this.groupMask, %this.layerMask);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_CollisionMethods_setCollisionLayers) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Collision Methods";
      description = "set the Rendering Layer(s) of objects that this object will collide with.";
      details_atomName = "setCollisionLayers";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Collision Methods";
      friendlyName = "setCollisionLayers";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"layers\", \"List of layers this object can collide with other objects on.\", \"default\", \"0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setCollisionLayers(%this.layers);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_CollisionMethods_setCollisionGroups) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Collision Methods";
      description = "set the Graph Group(s) of objects that this object will collide with.";
      details_atomName = "setCollisionGroups";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Collision Methods";
      friendlyName = "setCollisionGroups";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"groups\", \"List of graph groups this object can collide with other objects in.\", \"default\", \"0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setCollisionGroups(%this.groups);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_CollisionMethods_setCollisionDetection) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Collision Methods";
      description = "set collision detection mode for this object.";
      details_atomName = "setCollisionDetection";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Collision Methods";
      friendlyName = "setCollisionDetection";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"mode\", \"Collision mode.\", \"enum\", \"full\", \"full\"TAB\"circle\"TAB\"polygon\"TAB\"custom\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setCollisionDetection(%this.mode);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_CollisionMethods_setCollisionCircleSuperscribed) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Collision Methods";
      description = "specify whether the collision circle should be superscribed or subscribed around/within the object\'s bounding box.";
      details_atomName = "setCollisionCircleSuperscribed";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Collision Methods";
      friendlyName = "setCollisionCircleSuperscribed";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"superScribe\", \"Superscript the collision circle?\", \"bool\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setCollisionCircleSuperscribed(%this.superScribe);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_CollisionMethods_setCollisionCircleScale) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Collision Methods";
      description = "scale the collision circle of the object.";
      details_atomName = "setCollisionCircleScale";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Collision Methods";
      friendlyName = "setCollisionCircleScale";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"scale\", \"Scale of the object\'s collision circle.\", \"float\", \"1.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setCollisionCircleScale(%this.scale);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_CollisionMethods_setCollisionCallback) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Collision Methods";
      description = "enable collision the callback for this object.";
      details_atomName = "setCollisionCallback";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Collision Methods";
      friendlyName = "setCollisionCallback";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"enableCallback\", \"Enable the onCollision() callback.\", \"bool\", \"1\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setCollisionCallback(%this.enableCallback);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_CollisionMethods_setCollisionActiveSend) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Collision Methods";
      description = "set whether this object can collide with other objcts.";
      details_atomName = "setCollisionActiveSend";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Collision Methods";
      friendlyName = "setCollisionActiveSend";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"send\", \"This object can collide with other objects.\", \"bool\", \"1\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setCollisionActiveSend(%this.send);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_CollisionMethods_setCollisionActiveReceive) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Collision Methods";
      description = "set whether this object can be collided with.";
      details_atomName = "setCollisionActiveReceive";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Collision Methods";
      friendlyName = "setCollisionActiveReceive";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"receive\", \"This object be collided with by other objects.\", \"bool\", \"1\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setCollisionActiveReceive(%this.receive);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_CollisionMethods_setCollisionActive) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Collision Methods";
      description = "set the types of collisions this object will be involved in.";
      details_atomName = "setCollisionActive";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Collision Methods";
      friendlyName = "setCollisionActive";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"send\", \"This object can collide with other objects.\", \"bool\", \"1\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"receive\", \"This object be collided with by other objects.\", \"bool\", \"1\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setCollisionActive(%this.send, %this.receive);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
