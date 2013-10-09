if (!isObject(enableCollisions))
{
   %behavior = new BehaviorTemplate(enableCollisions)
   {
      friendlyName = "Enable Collision Detection and Response";
      behaviorType = "04 - Collision Detection and Response";
      description  = "Configure this object so that it will collide with objects in specified group(s).";
   };
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);

   %behavior.addBehaviorField(Allow, "Enable/disable collisions with one click.", bool, true);   
   
   %behavior.addBehaviorField( "Collision_Groups", "What groups can this object collide with?", "bitmask", "0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31");   
}

//function enableCollisions::onAdd(%this) 
function enableCollisions::onBehaviorAdd(%this)  //EFM
{
   if(!%this.enable) return;
   
   %owner = %this.owner;
   %owner.setCollisionActiveSend(true);
   %owner.setCollisionActiveReceive(true);
   %owner.setCollisionCallback(true);
   %owner.setCollisionMasks( bits( %this.Collision_Groups ) );
   
   if($LevelEditorActive) %this.schedule(0, refreshFields);
}

//EFM
// Trick - we want the object's fields updated as we modify this behavior's fields so
// that debug mode feedback is correct.
function enableCollisions::refreshFields(%this)
{
   ////   
   //  Allow this object to collide with other objects.
   ////   
   if(%this.Allow) 
   {
      %owner = %this.owner;
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
      %owner = %this.owner;
      %owner.setCollisionActiveSend(false);
      %owner.setCollisionActiveReceive(false);
      %owner.setCollisionCallback(false);
   }   
   %this.schedule(500, refreshFields);
}

function enableCollisions::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   
   ////   
   //  Allow this object to collide with other objects.
   ////   
   if(%this.Allow) 
   {
      %owner = %this.owner;
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
      %owner = %this.owner;
      %owner.setCollisionActiveSend(false);
      %owner.setCollisionActiveReceive(false);
      %owner.setCollisionCallback(false);
   }
}
