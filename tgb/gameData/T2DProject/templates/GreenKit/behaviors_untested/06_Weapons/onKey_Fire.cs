
if (!isObject(onKeyFire))
{
   %behavior = new BehaviorTemplate(onKeyFire)
   {
      friendlyName = "onKeyPress() -> Fire";
      behaviorType = "06 - Weapons";
      description  = "Calls onFire() behavior method for all behaviors attached to this object.";
   };   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField( "fireKey", "Rotate left",  keybind, "Keyboard space" );
}

function onKeyFire::onAddToScene(%this, %scenegraph) 
{
   //echo("onKeyFire::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   
   if(!%this.enable) return;

   moveMap.unbindMulti( getWord( %this.fireKey , 0 ),  getWord( %this.fireKey , 1 ),  %this, "onFireKey" );
}

function onKeyFire::onFireKey( %this , %val )
{ 
   if(!%this.enable) return;  
   //error("onKeyFire::onFireKey( ", %val , " ) " );   
   %this.broadcastMethod(onFire, %val );
}
