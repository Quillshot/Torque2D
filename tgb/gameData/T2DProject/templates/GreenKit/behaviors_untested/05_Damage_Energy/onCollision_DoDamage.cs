if (!isObject(onCollision_DoDamage))
{
   %behavior = new BehaviorTemplate(onCollision_DoDamage)
   {
      friendlyName = "onCollision() -> Do Damage";
      behaviorType = "05 - Damage and Energy";
      description  = "This object does damage to other objects on collision.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);

   %behavior.addBehaviorField( "Damage", "Deal this much damage to objects on collision.", "float", 0.0);
   
   %behavior.addBehaviorField("Damage_All", "If set to true, ignore damage_groups and try to damage any object that is collided with.", bool, false);
   
   %behavior.addBehaviorField( "Damage_Groups", "Only apply damage to objects in these graph groups. (Damage_All must be set to false.)", "bitmask", "0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31");   
      
}

function onCollision_DoDamage::onAddToScene(%this, %scenegraph) 
{
   //echo("onCollision_DoDamage::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(!%this.enable) return;

   //%this.owner.collisionActiveSend = true;
   //%this.owner.collisionCallback = true;   
}


function onCollision_DoDamage::onCollision( %this, %dstObject, %srcRef, %dstRef, %time, %normal, %contacts, %points )
{
   //echo("onCollision_DoDamage::onCollision( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   
   //EFM obviously, the velocity limits won't work if there isn't a way to retrieve current vel
   if(!%this.enable) return;
   
   %damageBehavior = %dstObject.getBehavior( "takesDamage" );
  
   if( !isObject(%damageBehavior) ) return; // Not using damage behavior
   
   %inDamageGroup = strstr( %this.Damage_Groups, %dstObject.getGraphGroup() );
   
   //error("%dstObject.getGraphGroup(): ", %dstObject.getGraphGroup());
   //error("%this.Damage_Groups: ", %this.Damage_Groups);
   //error("Testing damage group: ", %inDamageGroup);
   
   if( !%this.Damage_All && (%inDamageGroup == -1) ) return; // Not in drain group
   
   %damageBehavior.applyDamage( %this.Damage );   
}