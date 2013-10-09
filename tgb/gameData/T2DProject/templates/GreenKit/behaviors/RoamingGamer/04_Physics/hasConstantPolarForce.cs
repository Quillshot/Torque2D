if (!isObject(hasConstantPolarForce))
{
   %behavior = new BehaviorTemplate(hasConstantPolarForce)
   {
      friendlyName = "Has A Constant Force";
      behaviorType = "04 - Physics (Automatic Movement & Movement Limits)";
      description  = "Apply a constant force to this object.";
   };
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(Magnitude, "Magnitude of force.", float, "0.0");
   %behavior.addBehaviorField(Angle, "Angle (direction) of force [0.0, 360.0).", float, "0.0");   
   %behavior.addBehaviorField(Gravitic, "Force is gravitic.", bool, true);
}

function hasConstantPolarForce::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   %this.owner.setConstantForcePolar(%this.Angle, %this.Magnitude, %this.Gravitic);
}
