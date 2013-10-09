if (!isObject(inGroup))
{
   %behavior = new BehaviorTemplate(inGroup)
   {
      friendlyName = "In Group";
      behaviorType = "04 - Collision Detection and Response";
      description  = "Add this object to a specified graph group (for collisions, physics, damage, and other interactions).";
   };
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(Group, "Graph group to add this object to.", integer, 0 );
}

function inGroup::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   
   %this.owner.setGraphGroup(%this.Group);
}