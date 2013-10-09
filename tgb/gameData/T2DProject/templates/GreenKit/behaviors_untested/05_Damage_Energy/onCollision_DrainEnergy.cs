if (!isObject(onCollision_DrainEnergy))
{
   %behavior = new BehaviorTemplate(onCollision_DrainEnergy)
   {
      friendlyName = "onCollision() -> Drain Energy";
      behaviorType = "05 - Damage and Energy";
      description  = "This object attempts to drain energy from another object upon collision.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);

   %behavior.addBehaviorField( "Drain", "Deal this much drain to objects on collision.", "float", 0.0);
   
   %behavior.addBehaviorField("Drain_All", "If set to true, ignore drain_groups and try to drain any object that is collided with.", bool, false);
   
   %behavior.addBehaviorField( "Drain_Groups", "Only apply drain to objects in these graph groups. (Drain_All must be set to false.)", "bitmask", "0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31");   
}

function onCollision_DrainEnergy::onAddToScene(%this, %scenegraph) 
{
   //echo("onCollision_DrainEnergy::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(!%this.enable) return;

   //%this.owner.collisionActiveSend = true;
   //%this.owner.collisionCallback = true;    
}

function onCollision_DrainEnergy::onCollision( %this, %dstObject, %srcRef, %dstRef, %time, %normal, %contacts, %points )
{
   //echo("onCollision_DrainEnergy::onCollision( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(!%this.enable) return;
   
   %drainBehavior = %dstObject.getBehavior( "usesEnergy" );
  
   if( !isObject(%drainBehavior) ) return; // Not using drain behavior
   
   %inDrainGroup = strstr( %this.Drain_Groups, %dstObject.getGraphGroup() );
   
   //error("%dstObject.getGraphGroup(): ", %dstObject.getGraphGroup());
   //error("%this.Drain_Groups: ", %this.Drain_Groups);
   //error("Testing drain group: ", %inDrainGroup);
   
   if( !%this.Drain_All && (%inDrainGroup == -1) ) return; // Not in drain group
   
   %drainBehavior.applyDrain( %this.Drain );   
}