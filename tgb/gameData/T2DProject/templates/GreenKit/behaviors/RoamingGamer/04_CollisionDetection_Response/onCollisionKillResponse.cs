if (!isObject(onCollisionKillResponse))
{
   %behavior = new BehaviorTemplate(onCollisionKillResponse)
   {
      friendlyName = "onCollision() -> Kill";
      behaviorType = "04 - Collision Detection and Response";
      description  = "This object kills (safely deletes) itself.";
   };
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
}

function onCollisionKillResponse::onBehaviorAdd(%this) 
{
   if(!%this.enable) return;
   %this.owner.originalResponseMode = %this.owner.CollisionResponseMode;
   %this.owner.CollisionResponseMode= "KILL";
}

function onCollisionKillResponse::onBehaviorRemove(%this)
{
   if(!%this.enable) return;
   %this.owner.CollisionResponseMode = %this.owner.originalResponseMode; 
}

function onCollisionKillResponse::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;   
   
   %this.owner.CollisionResponseMode= "KILL";   
}