if (!isObject(hasRandomInitialAngularVelocity))
{
   %behavior = new BehaviorTemplate(hasRandomInitialAngularVelocity)
   {
      friendlyName = "Has Random Initial Angular Velocity";
      behaviorType = "04 - Physics (Automatic Movement & Movement Limits)";
      description  = "Give this object a random initial angular velocity.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);

   %behavior.addBehaviorField(MinAngleMagnitude, "Minimum Magnitude of Random Angle", int, 0);
   %behavior.addBehaviorField(MaxAngleMagnitude, "Maximum Magnitude of Random Angle", int, 360);
   %behavior.addBehaviorField(randomizeDirection,"If true, direction may be positive or negative", bool, false);
}

function hasRandomInitialAngularVelocity::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   
   %rotationRate = getRandom(%this.MinAngleMagnitude,%this.MaxAngleMagnitude);

   if(%this.randomizeDirection)
   {
      %direction = getRandom(-1,1);
      %direction = (%direction < 0) ? -1 : 1;
      %rotationRate *= %direction;
   }
   %this.owner.setAngularVelocity(%rotationRate);  
}
