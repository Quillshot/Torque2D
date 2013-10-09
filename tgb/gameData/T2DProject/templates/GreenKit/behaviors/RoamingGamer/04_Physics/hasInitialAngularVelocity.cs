if (!isObject(hasInitialAngularVelocity))
{
   %behavior = new BehaviorTemplate(hasInitialAngularVelocity)
   {
      friendlyName = "Has Initial Anglular Velocity";
      behaviorType = "04 - Physics (Automatic Movement & Movement Limits)";
      description  = "Give this object an initial angular velocity.";
   };
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);

   %behavior.addBehaviorField(Rotation_Rate, "Rotation rate in degrees per second.", float, "0.0");
}

function hasInitialAngularVelocity::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   %this.owner.setAngularVelocity(%this.Rotation_Rate);
}
