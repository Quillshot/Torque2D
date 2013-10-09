if (!isObject(moveForwardAtFixedSpeed))
{
   %behavior = new BehaviorTemplate(moveForwardAtFixedSpeed)
   {
      friendlyName = "Move Forward At Fixed Speed";
      behaviorType = "04 - Physics (Automatic Movement & Movement Limits)";
      description  = "Move forward";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", "bool", true);
   %behavior.addBehaviorField("speed", "Speed to move at.", "float", 25.0);
}

function moveForwardAtFixedSpeed::onAdd( %this ) 
{  
   echo("moveForwardAtFixedSpeed::onAdd( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}

function moveForwardAtFixedSpeed::onRemove( %this ) 
{   
   echo("moveForwardAtFixedSpeed::onRemove( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}

function moveForwardAtFixedSpeed::onAddToScene(%this, %scenegraph) 
{
   echo("moveForwardAtFixedSpeed::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(!%this.enable) return;
   
   %this.owner.setForwardMovementOnly(true);
   %this.owner.setLinearVelocity(0, -%this.speed);
   
   error("%this.speed => ", %this.speed);
   error("%this.owner => ", %this.owner);
}