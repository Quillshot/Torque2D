
if (!isObject(onFire_Dismount))
{
   %behavior = new BehaviorTemplate(onFire_Dismount)
   {
      friendlyName = "onFire() -> Dismount";
      behaviorType = "06 - Weapons";
      description  = "Dismount this object when onFire() is received.";
   };   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
}

function onFire_Dismount::onFire( %this, %val )
{ 
   if(%val) %this.owner.dismount();
   
}
