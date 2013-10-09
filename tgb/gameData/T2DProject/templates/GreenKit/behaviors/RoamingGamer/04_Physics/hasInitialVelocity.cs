if (!isObject(hasInitialVelocity))
{
   %behavior = new BehaviorTemplate(hasInitialVelocity)
   {
      friendlyName = "Has Initial Velocity";
      behaviorType = "04 - Physics (Automatic Movement & Movement Limits)";
      description  = "Give this object an initial linear velocity.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);

   %behavior.addBehaviorField(Magnitude, "Magnitude of velocity.", float, "0.0");
   %behavior.addBehaviorField(Angle, "Angle (direction) of velocity [0.0, 360.0).", float, "0.0");   
}

function hasInitialVelocity::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   %this.owner.setLinearVelocityPolar(%this.Angle, %this.Magnitude);
}
