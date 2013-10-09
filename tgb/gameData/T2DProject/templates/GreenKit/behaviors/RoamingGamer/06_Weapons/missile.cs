if (!isObject(missile))
{
   %behavior = new BehaviorTemplate(missile)
   {
      friendlyName = "Missile";
      behaviorType = "06 - Weapons";
      description  = "A projectile that moves forward at a fixed speed until it hits something.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", "bool", true);
   %behavior.addBehaviorField(debugmsg, "Enable debug messages for this behavior.", "bool", false);
   %behavior.addBehaviorField("speed", "Speed to move at.", "float", 25.0);

   %behavior.addBehaviorField(enableCOL, "Enable/disable collisions with one click (for debugging).", bool, true);   

   %behavior.addBehaviorField(Group, "Graph group to add this object to.", integer, 0 );
   %behavior.addBehaviorField( "Collision_Groups", "What groups can this object collide with?", "bitmask", "0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31");   
   
   %behavior.addBehaviorField("DestroyTarget", "Destroy target when it is hit.", bool, false);
}

function missile::onAdd( %this ) 
{  
   if(%this.debugmsg) echo("missile::onAdd( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );

   if(!%this.enable) return;

   %this.configureOwner();   
}

function missile::onBehaviorAdd(%this)  
{
   if(!%this.enable) return;
   %this.configureOwner();
   %this.refreshEnable = true;
   if($LevelEditorActive) %this.schedule(0, refreshFields);
}

function missile::onBehaviorRemove(%this)  
{
   %this.refreshEnable = false;
}

function missile::onAddToScene(%this, %scenegraph) 
{
   if(%this.debugmsg) echo("missile::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(!%this.enable) return;

   %this.configureOwner();   
   
   %owner = %this.owner;
   %owner.setForwardMovementOnly(true);
   %owner.setLinearVelocity(0, -%this.speed);
   
   if(%this.debugmsg) echo("%this.speed => ", %this.speed);
   if(%this.debugmsg) echo("%this.owner => ", %this.owner);
}

function missile::onRemove( %this ) 
{   
   if(%this.debugmsg) echo("missile::onRemove( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}

// Trick - we want the object's fields updated as we modify this behavior's fields so
// that debug mode feedback is correct.
function missile::refreshFields(%this)
{
   if(%this.debugmsg) echo("missile::refreshFields( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(%this.debugmsg) echo($LevelEditorActive);
   if(%this.debugmsg) echo(%this.refreshEnable);
   
   if( !%this.refreshEnable ) return;
   
   %this.configureOwner();
   
   if($LevelEditorActive) %this.schedule(500, refreshFields);
}

function missile::configureOwner(%this)
{
   if(%this.debugmsg) echo("missile::configureOwner( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   
   %owner = %this.owner;
   
   if( !%this.refreshEnable ) return;
   ////   
   //  Allow this object to collide with other objects.
   ////   
   if(%this.enableCOL) 
   {
      %owner.setCollisionActiveSend(true);
      %owner.setCollisionActiveReceive(true);
      %owner.setCollisionCallback(true);
      %owner.setCollisionMasks( bits( %this.Collision_Groups ) );
   }
   else
   ////   
   //  Do not allow this object to collide with other objects.
   ////   
   {
      %owner.setCollisionActiveSend(true);
      %owner.setCollisionActiveReceive(true);
      %owner.setCollisionCallback(true);
      %owner.setCollisionMasks( bits( %this.Collision_Groups ) );
   }   

   %owner.setGraphGroup(%this.Group);
   %owner.CollisionResponseMode= "KILL";
}


function missile::onCollision( %this, %dstObject, %srcRef, %dstRef, %time, %normal, %contacts, %points )
{
   if(%this.debugMode) echo("missile::onCollision( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   
   if( %this.DestroyTarget ) %dstObject.safeDelete();
}
