if (!isObject(hasRandomInitialVelocity))
{
   %behavior = new BehaviorTemplate(hasRandomInitialVelocity)
   {
      friendlyName = "Has Random Initial Velocity";
      behaviorType = "04 - Physics (Automatic Movement & Movement Limits)";
      description  = "Give this object an initial linear velocity.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);

   %behavior.addBehaviorField(MinVelocity, "Minimum velocity.", int, 0);
   %behavior.addBehaviorField(MaxVelocity, "Maximum velocity.", int, 100);
   %behavior.addBehaviorField(MinAngle, "Minimum Angle", int, 0);
   %behavior.addBehaviorField(MaxAngle, "Maximum Angle", int, 360);
}

function hasRandomInitialVelocity::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   %this.owner.setLinearVelocityPolar(getRandom(%this.MinAngle,%this.MaxAngle), 
                                      getRandom(%this.MinVelocity,%this.MaxVelocity));
}
