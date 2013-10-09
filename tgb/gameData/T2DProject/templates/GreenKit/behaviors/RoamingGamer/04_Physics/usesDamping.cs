if (!isObject(usesDamping))
{
   %behavior = new BehaviorTemplate(usesDamping)
   {
      friendlyName = "Apply Damping";
      behaviorType = "04 - Physics (Automatic Movement & Movement Limits)";
      description  = "Set damping to specified value.  This will stop a moving object over time.";
   };

   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(percentage, "Percent of velocity to damp per second. [0.0, 1.0]", float, 0.5);
}

function usesDamping::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   
   %this.owner.setDamping(%this.percentage);
}