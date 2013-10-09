if (!isObject(limitObjectVelocities))
{
   %behavior = new BehaviorTemplate(limitObjectVelocities)
   {
      friendlyName = "Limit Velocities";
      behaviorType = "04 - Physics (Automatic Movement & Movement Limits)";
      description  = "Adjust the maximum linear and angular velocities for this object.";
   };
  
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);

   %behavior.addBehaviorField(Linear,  "Maximum linear velocity.", float, "10000.000");
   %behavior.addBehaviorField(Angular, "Maximum angular velocity.", float, "10000.000");
}

function limitObjectVelocities::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   %this.owner.setMaxLinearVelocity(%this.Linear);
   %this.owner.setMaxAngularVelocity(%this.Angular);
}
