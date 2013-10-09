if (!isObject(testTarget))
{
   %behavior = new BehaviorTemplate(testTarget)
   {
      friendlyName = "Test Target";
      behaviorType = "06 - Weapons";
      description  = "Configure an easy to use test target for collision and weapon tests.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", "bool", true);
   %behavior.addBehaviorField(debugmsg, "Enable debug messages for this behavior.", "bool", false);

   %behavior.addBehaviorField(enableCOL, "Enable/disable collisions with one click (for debugging).", bool, true);   

   %behavior.addBehaviorField(Group, "Graph group to add this object to.", integer, 0 );
   %behavior.addBehaviorField( "Collision_Groups", "What groups can this object collide with?", "bitmask", "0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31");   
   %behavior.addBehaviorField(AllowKill, "Kill (destroy) this target when it is hit.", "bool", true);
}

function testTarget::onAdd( %this ) 
{  
   if(%this.debugmsg) echo("testTarget::onAdd( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );

   if(!%this.enable) return;

   %this.configureOwner();   
}

function testTarget::onBehaviorAdd(%this)  
{
   if(!%this.enable) return;
   %this.configureOwner();
   %this.refreshEnable = true;
   if($LevelEditorActive) %this.schedule(0, refreshFields);
}

function testTarget::onBehaviorRemove(%this)  
{
   %this.refreshEnable = false;
}

function testTarget::onAddToScene(%this, %scenegraph) 
{
   if(%this.debugmsg) echo("testTarget::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(!%this.enable) return;

   %this.configureOwner();   
}

function testTarget::onRemove( %this ) 
{   
   if(%this.debugmsg) echo("testTarget::onRemove( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}

// Trick - we want the object's fields updated as we modify this behavior's fields so
// that debug mode feedback is correct.
function testTarget::refreshFields(%this)
{
   if(%this.debugmsg) echo("testTarget::refreshFields( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(%this.debugmsg) echo($LevelEditorActive);
   if(%this.debugmsg) echo(%this.refreshEnable);
   
   if( !%this.refreshEnable ) return;
   
   %this.configureOwner();
   
   if($LevelEditorActive) %this.schedule(500, refreshFields);
}

function testTarget::configureOwner(%this)
{
   if(%this.debugmsg) echo("testTarget::configureOwner( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   
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

//   %owner.setImmovable(true); EFM - immovable objects are not KILLED on collision
   
   %owner.setGraphGroup(%this.Group);
   
   if(%this.AllowKill)
      %owner.CollisionResponseMode= "KILL";
   else
      %owner.CollisionResponseMode= "CLAMP";
}
