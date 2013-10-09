if (!isObject(onCollisionBounceResponse))
{
   %behavior = new BehaviorTemplate(onCollisionBounceResponse)
   {
      friendlyName = "onCollision() -> Bounce";
      behaviorType = "04 - Collision Detection and Response";
      description  = "This object bounces on collision with other objects.";
   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
}


function onCollisionBounceResponse::onBehaviorAdd(%this)
{
   if(!%this.enable) return;
   %this.owner.originalResponseMode = %this.owner.CollisionResponseMode;  
   %this.owner.CollisionResponseMode= "BOUNCE";
}

function onCollisionBounceResponse::onBehaviorRemove(%this)
{
   if(!%this.enable) return;
   %this.owner.CollisionResponseMode = %this.owner.originalResponseMode; 
}

function onCollisionBounceResponse::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;   
   
   %this.owner.CollisionResponseMode= "BOUNCE";
}