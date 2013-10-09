if (!isObject(takesDamage))
{
   %behavior = new BehaviorTemplate(takesDamage)
   {
      friendlyName = "Takes Damage";
      behaviorType = "05 - Damage and Energy";
      description  = "This object takes damage.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);

   %behavior.addBehaviorField( "Hit_Points", "Number of hit points this object has.", "float", 0.0);
   %behavior.addBehaviorField( "Destroyed_At", "Destroy this object if its hit points drop to (or below) this value.", "float", -1.0);
   
}

function takesDamage::onAddToScene(%this, %scenegraph) 
{
   //echo("takesDamage::onAddToScene( ", %this , " ) @ ", getSimTime() );
   if(!%this.enable) return;

    // If this is a player, verify game master is present
   %isPlayerBehavior = %this.owner.getBehavior("IsPlayer");
   if( isObject(%isPlayerBehavior) )
   {
      if(!isObject( theGameMaster )) new ScriptGroup( theGameMaster );
   }
  
   %this.initialize();
}

function takesDamage::initialize(%this) 
{
   if(!%this.enable) return;
   //echo("takesDamage::initialize");
   
   %isPlayerBehavior = %this.owner.getBehavior("IsPlayer");
   if( isObject(%isPlayerBehavior) )
   {
      %currentHitPoints = theGameMaster.getHealth();  
   }
   
   %currentHitPoints = (%currentHitPoints $= "") ? 0 : %currentHitPoints;
   %currentHitPoints = (%currentHitPoints < 0) ? 0 : %currentHitPoints;
   
   %this.owner.collisionActiveReceive = true;
   if(%currentHitPoints == 0)
   {
      %this.currentHitPoints = %this.Hit_Points;
   }
   else
   {
      %this.currentHitPoints = %currentHitPoints;
   }

   %this.isDestroyed = false;
   
   //%this.setEnabled(true);
   
   %isPlayerBehavior = %this.owner.getBehavior("IsPlayer");
   if( isObject(%isPlayerBehavior) )
   {
      theGameMaster.setHealth(%this.currentHitPoints);
   }
}

//
// Methods
//
function takesDamage::isDamaged( %this )
{
   return ( %this.currentHitPoints < %this.Hit_Points );
}

function takesDamage::applyDamage( %this , %amount )
{ 
   //echo("takesDamage::applyDamage( ", %this , " , ", %amount , "  ) @ ", getSimTime() );
   if(!%this.enable) return;

   error("%this.currentHitPoints == ", %this.currentHitPoints );

   // Apply damage   
   %this.currentHitPoints -= %amount;
   %this.currentHitPoints = (%this.currentHitPoints < 0) ? 0 : %this.currentHitPoints;
   %this.currentHitPoints = (%this.currentHitPoints > %this.Hit_Points) ? %this.Hit_Points : %this.currentHitPoints;
   
   error("%this.currentHitPoints == ", %this.currentHitPoints );
   %isPlayerBehavior = %this.owner.getBehavior("IsPlayer");
   if( isObject(%isPlayerBehavior) )
   {
      theGameMaster.setHealth(%this.currentHitPoints);
   }

   // Check to see if this object is destroyed    
   if( !%this.isDestroyed && ( %this.currentHitPoints <= %this.Destroyed_At ) )
   { 
      error("Destroying object == ", %this.owner.getname() );
        
      %this.destroyObject();
   } 
   else
   {
      // Broadcast onDamaged() callback to other behaviors in this object
      %this.broadcastMethod( "onDamaged", %amount );
   }
}

function takesDamage::applyRepair( %this , %amount )
{ 
   echo("takesDamage::applyRepair( ", %this , " , ", %amount , "  ) @ ", getSimTime() );
   if(!%this.enable) return;

   // Apply damage   
   %this.currentHitPoints += %amount;
   %this.currentHitPoints = (%this.currentHitPoints < 0) ? 0 : %this.currentHitPoints;
   %this.currentHitPoints = (%this.currentHitPoints > %this.Hit_Points) ? %this.Hit_Points : %this.currentHitPoints;
   
   %isPlayerBehavior = %this.owner.getBehavior("IsPlayer");
   if( isObject(%isPlayerBehavior) )
   {
      theGameMaster.setHealth(%this.currentHitPoints);
   }
   
   // Check to see if this object is destroyed    
   if( !%this.isDestroyed && ( %this.currentHitPoints <= %this.Destroyed_At ) )
   {         
      %this.destroyObject();
   } 
   else
   {
      // Broadcast onDamaged() callback to other behaviors in this object
      %this.broadcastMethod( "onRepaired", %amount );
   }
}

function takesDamage::destroyObject( %this )
{
   if(!%this.enable) return;
   //echo("takesDamage::destroyObject( ", %this , "  ) @ ", getSimTime() );
   %this.isDestroyed = true;

   // Broadcast onDestroyed() callback to other behaviors in this object
   %this.broadcastMethod( "onDestroyed" );

   //%this.owner.collisionActiveReceive = false;
   %this.owner.setEnabled(false);   
}
