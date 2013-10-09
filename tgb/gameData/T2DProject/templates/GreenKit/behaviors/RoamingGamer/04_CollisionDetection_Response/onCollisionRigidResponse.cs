if (!isObject(onCollisionRigidResponse))
{
   %behavior = new BehaviorTemplate(onCollisionRigidResponse)
   {
      friendlyName = "onCollision() -> Apply Rigid Response";
      behaviorType = "04 - Collision Detection and Response";
      description  = "This object uses rigid physics for collisions and other interactions.";
   };
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   
   %behavior.addBehaviorField(Density, "Density", float, 0.010);
   %behavior.addBehaviorField(Friction, "Friction", float, 0.300);
   %behavior.addBehaviorField(Restitution, "Restitution (bounciness)", float, 1.000 );
}


function onCollisionRigidResponse::onBehaviorAdd(%this) 
{
   if(!%this.enable) return;
   %this.owner.originalResponseMode = %this.owner.CollisionResponseMode;
   %this.owner.CollisionResponseMode= "RIGID";
}

function onCollisionRigidResponse::onBehaviorRemove(%this)
{
   if(!%this.enable) return;
   %this.owner.CollisionResponseMode = %this.owner.originalResponseMode; 
}

function onCollisionRigidResponse::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;   

   %this.owner.setAutoMassInertia( true );
   %this.owner.setPhysicsSuppress(false);
   %this.owner.CollisionPhysicsSend    = true;
   %this.owner.CollisionPhysicsReceive = true;
   %this.owner.CollisionResponseMode   = "RIGID";
   %this.owner.setDensity(%this.Density);
   %this.owner.setFriction(%this.Friction);
   %this.owner.setRestitution(%this.Restitution);      
   
}