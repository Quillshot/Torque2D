if (!isObject(sceneHasConstantForce))
{
   %behavior = new BehaviorTemplate(sceneHasConstantForce)
   {
      friendlyName = "Scene Force";
      behaviorType = "03 - Scene and Camera";
      description  = "Apply a constant force to all objects in the scene.";
   };
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);
   %behavior.addBehaviorField(Magnitude, "Magnitude of scene force.", float, "0.0");
   %behavior.addBehaviorField(Angle, "Angle (direction) of force [0.0, 360.0).", float, "0.0");   
   %behavior.addBehaviorField(Gravitic, "Force is gravitic.", bool, true);
}

function sceneHasConstantForce::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   %scenegraph.setConstantForcePolar(%this.Angle, %this.Magnitude, %this.Gravitic);
}
