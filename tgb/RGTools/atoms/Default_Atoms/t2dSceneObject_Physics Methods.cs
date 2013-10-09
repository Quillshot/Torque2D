//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_stopConstantForce) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "zero any current (internal) constant force specified for this object. (Does not affect scene constant forces which is external.)";
      details_atomName = "stopConstantForce";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "stopConstantForce";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.stopConstantForce();";
      segments = "executeAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setRestitution) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "set how bouncy this object is (its restitution).";
      details_atomName = "setRestitution";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setRestitution";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"restitution\", \"Bounciness.\", \"float\", \"0.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setRestitution(%this.restitution);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setPhysicsSuppress) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "toggle the enabled status of all physics calculations on the object.";
      details_atomName = "setPhysicsSuppress";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setPhysicsSuppress";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"status\", \"true - disable physics; false - enable physics.\", \"bool\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setPhysicsSuppress(%this.status);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setMinLinearVelocity) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "set this objects minimum linear velocity as a vector.";
      details_atomName = "setMinLinearVelocity";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setMinLinearVelocity";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"velocity\", \"Minimum speed for this object.\", \"point2f\", \"0.0 0.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setMinLinearVelocity(%this.velocity);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setMinAngularVelocity) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "set the minimum velocity at which the object is allowed to rotate.";
      details_atomName = "setMinAngularVelocity";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setMinAngularVelocity";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"velocity\", \"Minimum rotational velocity.\", \"float\", \"0.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setMinAngularVelocity(%this.velocity);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setMaxLinearVelocity) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "set the maximum velocity at which the object is allowed to move.";
      details_atomName = "setMaxLinearVelocity";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setMaxLinearVelocity";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"velocity\", \"The maximum velocity.\", \"point2f\", \"10000.0 10000.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setMaxLinearVelocity(%this.velocity);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setMaxAngularVelocity) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "set the maximum velocity at which the object is allowed to rotate. (Note that passing in 0 for the velocity will prevent rotation on collisions.)";
      details_atomName = "setMaxAngularVelocity";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setMaxAngularVelocity";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"velocity\", \"The maximum velocity.\", \"float\", \"10000.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setMaxAngularVelocity(%this.velocity);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setMass) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "set this object\'s mass.";
      details_atomName = "setMass";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setMass";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"mass\", \"Objects new mass.\", \"float\", \"1.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setMass(%this.mass);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setLinearVelocityY) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "set the velocity at which the object will move along the Y-axis.";
      details_atomName = "setLinearVelocityY";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setLinearVelocityY";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"velocityY\", \"Velocity along Y-axis\", \"float\", \"0.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setLinearVelocityY(%this.velocityY);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setLinearVelocityX) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "set the velocity at which the object will move along the X-axis.";
      details_atomName = "setLinearVelocityX";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setLinearVelocityX";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"velocityX\", \"Velocity along X-axis\", \"float\", \"0.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setLinearVelocityX(%this.velocityX);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setLinearVelocityPolar) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "set the velocity at which the object will move along a specified angle.";
      details_atomName = "setLinearVelocityPolar";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setLinearVelocityPolar";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"direction\", \"Angle of velocity.\", \"float\", \"0.0\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"speed\", \"Magnitude of velocity.\", \"float\", \"0.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setLinearVelocityPolar(%this.direction, %this.speed);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setLinearVelocity) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "set the velocity at which the object will move along a vector.";
      details_atomName = "setLinearVelocity";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setLinearVelocity";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"velocity\", \"Magnitude and direction of velocity specified as a vector.\", \"point2f\", \"0.0 0.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setLinearVelocity(%this.velocity);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setInertialMoment) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "set the \'inertial moment\' (resistance to rotational change) of the object.";
      details_atomName = "setInertialMoment";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setInertialMoment";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"inertia\", \"The inertial moment. i.e. How much this object resists rotational change as the result of external forces (like collisions).\", \"float\", \"0.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setInertialMoment(%this.inertia);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setImpulseForcePolar) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "apply an impulse to this object specified as a magnitude and angle.";
      details_atomName = "setImpulseForcePolar";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setImpulseForcePolar";
      segmentbehaviorFields = "3";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"angle\", \"Angle of impulse force.\", \"float\", \"0.0\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"force\", \"Magnitude of impulse force.\", \"float\", \"0.0\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"gravitic\", \"Ignore mass of object?\", \"bool\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setImpulseForcePolar(%this.angle, %this.force, %this.gravitic );";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setImpulseForce) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "apply an impulse to this object specified as a vector.";
      details_atomName = "setImpulseForce";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setImpulseForce";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"force\", \"Vector specifying magnitude and direction of force.\", \"point2f\", \"0.0 0.0\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"gravitic\", \"Ignore gravity?\", \"bool\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setImpulseForce(%this.force, %this.gravitic);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setImmovable) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "set whether this object is immovable.";
      details_atomName = "setImmovable";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setImmovable";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"status\", \"true - object cannot move (or be moved); false - it can move.\", \"bool\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setImmovable(%this.status);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setGraviticConstantForce) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "set whether forces applied to this object are treated (by default) as gravitic or not. (Useful with setConstantForceX() and setConstantForceY().)";
      details_atomName = "setGraviticConstantForce";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setGraviticConstantForce";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"gravitic\", \"Should forces applied to this object (by default) ignore the objects mass?\", \"bool\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setGraviticConstantForce(%this.gravitic);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setFriction) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "set this object\'s friction.";
      details_atomName = "setFriction";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setFriction";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"friction\", \"This object\'s new friction.\", \"float\", \"0.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setFriction(%this.friction);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setForwardSpeed) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "apply a linear velocity to the object in the direction of its rotation. i.e. apply a linear velocity in the direction the object is pointed.";
      details_atomName = "setForwardSpeed";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setForwardSpeed";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"speed\", \"Magnitude of velocity.\", \"float\", \"0.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setForwardSpeed(%this.speed);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setForwardMovementOnly) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "set whether or not an object can move only in the direction of its rotation. i.e. Forces applied at other angles are ignored.";
      details_atomName = "setForwardMovementOnly";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setForwardMovementOnly";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"status\", \"Only react to forces in the direction this object is pointed (its rotation).\", \"bool\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setForwardMovementOnly(%this.status);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setForceScale) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "set the scale factor for all forces applied to this object. i.e. Make it more or less reactive to applied forces.";
      details_atomName = "setForceScale";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setForceScale";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"scale\", \"New force multiplier for this object.\", \"float\", \"1.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setForceScale(%this.scale);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setDensity) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "set this object\'s density.";
      details_atomName = "setDensity";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setDensity";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"density\", \"This object\'s new density.\", \"float\", \"1.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setDensity(%this.density);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setDamping) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "set the damping of the object";
      details_atomName = "setDamping";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setDamping";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"damping\", \"New damping value for this object.\", \"float\", \"0.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setDamping(%this.damping);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setConstantForceY) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "set a constant force to be applied to this object along the Y-axis.";
      details_atomName = "setConstantForceY";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setConstantForceY";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"forceY\", \"Force, to be applied along Y-axis.\", \"float\", \"0.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setConstantForceY(%this.forceY);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setConstantForceX) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "set a constant force to be applied to this object along the X-axis.";
      details_atomName = "setConstantForceX";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setConstantForceX";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"forceX\", \"Force, to be applied along X-axis.\", \"float\", \"0.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setConstantForceX(%this.forceX);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setConstantForcePolar) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "apply a constant force to this object along a specified angle.";
      details_atomName = "setConstantForcePolar";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setConstantForcePolar";
      segmentbehaviorFields = "3";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"angle\", \"Angle of force.\", \"float\", \"0.0\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"force\", \"Force, to be applied along above angle.\", \"float\", \"0.0\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"gravitic\", \"Ignore mass?\", \"bool\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setConstantForcePolar(%this.angle, %this.force, %this.gravitic);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setConstantForce) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "set a constant force to be applied to this object along a vector.";
      details_atomName = "setConstantForce";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setConstantForce";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"force\", \"Vector specifying direction and magnitude of force.\", \"point2f\", \"0.0 0.0\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"gravitic\", \"Ignore mass?\", \"bool\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setConstantForce(%this.force, %this.gravitic = false);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setCollisionMaterial) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "configure object collision settings using a t2dCollisionMaterialDatablock.";
      details_atomName = "setCollisionMaterial";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setCollisionMaterial";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   //EFM %behavior.addBehaviorField( \"material\", \"Describe_this_field\", \"bool\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setCollisionMaterial(%this.material);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setAutoMassInertia) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "set whether or not mass and inertia should be automatically calculated based on the size and density of the object.";
      details_atomName = "setAutoMassInertia";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setAutoMassInertia";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"status\", \"Automatically calculate mas and inertia based on size and density?\", \"bool\", \"0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setAutoMassInertia(%this.status);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setAtRest) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "stop this object from moving (including rotation).";
      details_atomName = "setAtRest";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setAtRest";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setAtRest();";
      segments = "executeAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_t2dSceneObject_PhysicsMethods_setAngularVelocity) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "t2dSceneObject - Physics Methods";
      description = "set this object\'s angular velocity";
      details_atomName = "setAngularVelocity";
      details_category = "t2dSceneObject";
      details_eventAction = "action";
      details_subCategory = "Physics Methods";
      friendlyName = "setAngularVelocity";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"velocity\", \"Rotational speed.\", \"float\", \"0.0\");";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.setAngularVelocity(%this.velocity);";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
