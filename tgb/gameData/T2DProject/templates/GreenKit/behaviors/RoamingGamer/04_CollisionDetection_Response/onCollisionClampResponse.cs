if (!isObject(onCollisionClampResponse))
{
   %behavior = new BehaviorTemplate(onCollisionClampResponse)
   {
      friendlyName = "onCollision() -> Clamp";
      behaviorType = "04 - Collision Detection and Response";
      description  = "This object clamps (stops moving) on collision with other objects.";
   };
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
}

function onCollisionClampResponse::onBehaviorAdd(%this) 
{
   if(!%this.enable) return;
   %this.owner.originalResponseMode = %this.owner.CollisionResponseMode;
   %this.owner.CollisionResponseMode= "CLAMP";
}

function onCollisionClampResponse::onBehaviorRemove(%this)
{
   if(!%this.enable) return;
   %this.owner.CollisionResponseMode = %this.owner.originalResponseMode; 
}

function onCollisionClampResponse::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;   
   
   %this.owner.CollisionResponseMode= "CLAMP";   
}