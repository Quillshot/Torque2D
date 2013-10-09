//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_04CollisionPhysics_Physics_moveForwardAtFixedSpeed) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "04 - Collision & Physics";
      description = "Move forward";
      details_atomName = "moveForwardAtFixedSpeed";
      details_category = "04 - Collision & Physics";
      details_eventAction = "full";
      details_subCategory = "Physics";
      friendlyName = "Move Forward At Fixed Speed";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField(\"speed\", \"Speed to move at.\", \"float\", 25.0);";
      segmentonAddToScene = "2";
      segmentonAddToScene_0 = "   %this.owner.setForwardMovementOnly(true);";
      segmentonAddToScene_1 = "   %this.owner.setLinearVelocity(0, -%this.speed);";
      segments = "behaviorFields\tonAddToScene";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_04CollisionPhysics_Physics_limitObjectVelocities) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "04 - Collision & Physics";
      description = "Adjust the maximum linear and angular velocities for this object.";
      details_atomName = "limitObjectVelocities";
      details_category = "04 - Collision & Physics";
      details_eventAction = "full";
      details_subCategory = "Physics";
      friendlyName = "Limit Velocities";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField(Linear,  \"Maximum linear velocity.\", float, \"10000.000\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField(Angular, \"Maximum angular velocity.\", float, \"10000.000\");";
      segmentonAddToScene = "2";
      segmentonAddToScene_0 = "   %this.owner.setMaxLinearVelocity(%this.Linear);";
      segmentonAddToScene_1 = "   %this.owner.setMaxAngularVelocity(%this.Angular);";
      segments = "behaviorFields\tonAddToScene";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_04CollisionPhysics_Physics_hasRandomInitialVelocity) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "04 - Collision & Physics";
      description = "Give this object an initial linear velocity.";
      details_atomName = "hasRandomInitialVelocity";
      details_category = "04 - Collision & Physics";
      details_eventAction = "full";
      details_subCategory = "Physics";
      friendlyName = "Has Random Initial Velocity";
      segmentbehaviorFields = "4";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField(MinVelocity, \"Minimum velocity.\", int, 0);";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField(MaxVelocity, \"Maximum velocity.\", int, 100);";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField(MinAngle, \"Minimum Angle\", int, 0);";
      segmentbehaviorFields_3 = "   %behavior.addBehaviorField(MaxAngle, \"Maximum Angle\", int, 360);";
      segmentonAddToScene = "2";
      segmentonAddToScene_0 = "   %this.owner.setLinearVelocityPolar(getRandom(%this.MinAngle,%this.MaxAngle), ";
      segmentonAddToScene_1 = "                                      getRandom(%this.MinVelocity,%this.MaxVelocity));";
      segments = "behaviorFields\tonAddToScene";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_04CollisionPhysics_Physics_hasRandomInitialAngularVelocity) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "04 - Collision & Physics";
      description = "Give this object a random initial angular velocity.";
      details_atomName = "hasRandomInitialAngularVelocity";
      details_category = "04 - Collision & Physics";
      details_eventAction = "full";
      details_subCategory = "Physics";
      friendlyName = "Has Random Initial Angular Velocity";
      segmentbehaviorFields = "3";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField(MinAngleMagnitude, \"Minimum Magnitude of Random Angle\", int, 0);";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField(MaxAngleMagnitude, \"Maximum Magnitude of Random Angle\", int, 360);";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField(randomizeDirection,\"If true, direction may be positive or negative\", bool, false);";
      segmentonAddToScene = "8";
      segmentonAddToScene_0 = "   %rotationRate = getRandom(%this.MinAngleMagnitude,%this.MaxAngleMagnitude);";
      segmentonAddToScene_1 = "   if(%this.randomizeDirection)";
      segmentonAddToScene_2 = "   {";
      segmentonAddToScene_3 = "      %direction = getRandom(-1,1);";
      segmentonAddToScene_4 = "      %direction = (%direction < 0) ? -1 : 1;";
      segmentonAddToScene_5 = "      %rotationRate *= %direction;";
      segmentonAddToScene_6 = "   }";
      segmentonAddToScene_7 = "   %this.owner.setAngularVelocity(%rotationRate);  ";
      segments = "behaviorFields\tonAddToScene";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_04CollisionPhysics_Physics_hasInitialVelocity) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "04 - Collision & Physics";
      description = "Give this object an initial linear velocity.";
      details_atomName = "hasInitialVelocity";
      details_category = "04 - Collision & Physics";
      details_eventAction = "full";
      details_subCategory = "Physics";
      friendlyName = "Has Initial Velocity";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField(Magnitude, \"Magnitude of velocity.\", float, \"0.0\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField(Angle, \"Angle (direction) of velocity [0.0, 360.0).\", float, \"0.0\");   ";
      segmentonAddToScene = "1";
      segmentonAddToScene_0 = "   %this.owner.setLinearVelocityPolar(%this.Angle, %this.Magnitude);";
      segments = "behaviorFields\tonAddToScene";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_04CollisionPhysics_Physics_hasInitialAngularVelocity) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "04 - Collision & Physics";
      description = "Give this object an initial angular velocity.";
      details_atomName = "hasInitialAngularVelocity";
      details_category = "04 - Collision & Physics";
      details_eventAction = "full";
      details_subCategory = "Physics";
      friendlyName = "Has Initial Anglular Velocity";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField(Rotation_Rate, \"Rotation rate in degrees per second.\", float, \"0.0\");";
      segmentonAddToScene = "2";
      segmentonAddToScene_0 = "{   ";
      segmentonAddToScene_1 = "   %this.owner.setAngularVelocity(%this.Rotation_Rate);";
      segments = "behaviorFields\tonAddToScene";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_04CollisionPhysics_Physics_hasConstantPolarForce) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "04 - Collision & Physics";
      description = "Apply a constant force to this object.";
      details_atomName = "hasConstantPolarForce";
      details_category = "04 - Collision & Physics";
      details_eventAction = "full";
      details_subCategory = "Physics";
      friendlyName = "Has A Constant Force";
      segmentbehaviorFields = "3";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField(Magnitude, \"Magnitude of force.\", float, \"0.0\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField(Angle, \"Angle (direction) of force [0.0, 360.0).\", float, \"0.0\");   ";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField(Gravitic, \"Force is gravitic.\", bool, true);";
      segmentonAddToScene = "1";
      segmentonAddToScene_0 = "   %this.owner.setConstantForcePolar(%this.Angle, %this.Magnitude, %this.Gravitic);";
      segments = "behaviorFields\tonAddToScene";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_04CollisionPhysics_Physics_applyInitialImpulse) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "04 - Collision & Physics";
      description = "Apply an impulse (optionally delayed) after adding this object to the scene.";
      details_atomName = "applyInitialImpulse";
      details_category = "04 - Collision & Physics";
      details_eventAction = "full";
      details_subCategory = "Physics";
      friendlyName = "Apply Initial Impulse";
      segmentbehaviorFields = "4";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField(Magnitude, \"Magnitude of impulse.\", float, \"0.0\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField(Angle, \"Angle (direction) of impulse [0.0, 360.0).\", float, \"0.0\");   ";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField(Gravitic, \"Impulse is gravitic.\", bool, true);";
      segmentbehaviorFields_3 = "   %behavior.addBehaviorField(Delay, \"Wait this long to apply impluse (after object is added to scene).\", integer, 0);";
      segmentonAddToScene = "1";
      segmentonAddToScene_0 = "   %this.owner.schedule(%this.Delay, setImpulseForcePolar, %this.Angle, %this.Magnitude, %this.Gravitic);";
      segments = "behaviorFields\tonAddToScene";
};
//--- OBJECT WRITE END ---
