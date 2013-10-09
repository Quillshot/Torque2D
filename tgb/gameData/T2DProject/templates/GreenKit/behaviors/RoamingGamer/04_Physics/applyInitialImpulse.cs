if (!isObject(applyInitialImpulse))
{
   %behavior = new BehaviorTemplate(applyInitialImpulse)
   {
      friendlyName = "Apply Initial Impulse";
      behaviorType = "04 - Physics (Automatic Movement & Movement Limits)";
      description  = "Apply an impulse (optionally delayed) after adding this object to the scene.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);

   %behavior.addBehaviorField(Magnitude, "Magnitude of impulse.", float, "0.0");
   %behavior.addBehaviorField(Angle, "Angle (direction) of impulse [0.0, 360.0).", float, "0.0");   
   %behavior.addBehaviorField(Gravitic, "Impulse is gravitic.", bool, true);

   %behavior.addBehaviorField(Delay, "Wait this long to apply impluse (after object is added to scene).", integer, 0);
}

function applyInitialImpulse::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   %this.owner.schedule(%this.Delay, setImpulseForcePolar, %this.Angle, %this.Magnitude, %this.Gravitic);
}
