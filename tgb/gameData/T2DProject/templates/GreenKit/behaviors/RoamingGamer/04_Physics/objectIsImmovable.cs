if (!isObject(objectIsImmovable))
{
   %behavior = new BehaviorTemplate(objectIsImmovable)
   {
      friendlyName = "Object Is Immovable";
      behaviorType = "04 - Physics (Automatic Movement & Movement Limits)";
      description  = "Make this object immovable.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
}

function objectIsImmovable::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   %this.owner.setImmovable(true);
}
