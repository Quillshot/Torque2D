if (!isObject(usesEnergy))
{
   %behavior = new BehaviorTemplate(usesEnergy)
   {
      friendlyName = "Uses Energy";
      behaviorType = "05 - Damage and Energy";
      description  = "This object uses energy.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);

   %behavior.addBehaviorField( "Energy_Points", "Number of energy points this object has.", "float", 0.0);
   %behavior.addBehaviorField( "Destroyed_At", "Destroy this object if its energy points drop to (or below) this value. (requires takesDamage)", "float", -1.0);
}

function usesEnergy::onAddToScene(%this, %scenegraph) 
{
   //echo("usesEnergy::onAddToScene( ", %this , " ) @ ", getSimTime() );
   if(!%this.enable) return;

    // If this is a player, verify game master is present
   %isPlayerBehavior = %this.owner.getBehavior("IsPlayer");
   if( isObject(%isPlayerBehavior) )
   {
      if(!isObject( theGameMaster )) new ScriptGroup( theGameMaster );
   }

   %this.initialize();
}

//function usesEnergy::initialize(%this) 
//{
   //if(!%this.enable) return;
   ////echo("usesEnergy::initialize");
   //%this.owner.collisionActiveReceive = true;
   //%this.currentEnergyPoints = %this.Energy_Points;
   //
   ////%this.setEnabled(true);
//
   //// If this is a player, verify game master is present
   //%isPlayerBehavior = %this.owner.getBehavior("IsPlayer");
   //if( isObject(%isPlayerBehavior) )
   //{
      //theGameMaster.setEnergy(%this.currentEnergyPoints);
   //}
//}

function takesEnergy::initialize(%this) 
{
   if(!%this.enable) return;
   //echo("takesEnergy::initialize");
   
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
function usesEnergy::isDrained( %this )
{
   return ( %this.currentEnergyPoints < %this.Energy_Points );
}

function usesEnergy::applyDrain( %this , %amount )
{ 
   //echo("usesEnergy::applyDrain( ", %this , " , ", %amount , "  ) @ ", getSimTime() );
   if(!%this.enable) return;

   // Apply Drain   
   %this.currentEnergyPoints -= %amount;
   %this.currentEnergyPoints = (%this.currentEnergyPoints < 0) ? 0 : %this.currentEnergyPoints;
   %this.currentEnergyPoints = (%this.currentEnergyPoints > %this.Energy_Points) ? %this.Energy_Points : %this.currentEnergyPoints;
   
   // If this is a player, verify game master is present
   %isPlayerBehavior = %this.owner.getBehavior("IsPlayer");
   if( isObject(%isPlayerBehavior) )
   {
      theGameMaster.setEnergy(%this.currentEnergyPoints);
   }

   %takesDamageBehavior = %this.owner.getBehavior( "takesDamage" );
   // Check to see if this object is destroyed    
   if( isObject(%takesDamageBehavior) && !%this.isDestroyed && ( %this.currentEnergyPoints <= %this.Destroyed_At ) )
   {         
      %takesDamageBehavior.destroyObject();
   } 
   else
   {
      // Broadcast onDrained() callback to other behaviors in this object
      %this.broadcastMethod( onDrained, %amount );
   }
}

function usesEnergy::applyRecharge( %this , %amount )
{ 
   //echo("usesEnergy::applyRecharge( ", %this , " , ", %amount , "  ) @ ", getSimTime() );
   if(!%this.enable) return;

   // Apply Drain   
   %this.currentEnergyPoints += %amount;
   %this.currentEnergyPoints = (%this.currentEnergyPoints < 0) ? 0 : %this.currentEnergyPoints;
   %this.currentEnergyPoints = (%this.currentEnergyPoints > %this.Energy_Points) ? %this.Energy_Points : %this.currentEnergyPoints;
   
   // If this is a player, verify game master is present
   %isPlayerBehavior = %this.owner.getBehavior("IsPlayer");
   if( isObject(%isPlayerBehavior) )
   {
      theGameMaster.setEnergy(%this.currentEnergyPoints);
   }

   %takesDamageBehavior = %this.owner.getBehavior( "takesDamage" );
   // Check to see if this object is destroyed    
   if( isObject(%takesDamageBehavior) && !%this.isDestroyed && ( %this.currentEnergyPoints <= %this.Destroyed_At ) )
   {         
      %takesDamageBehavior.destroyObject();
   } 
   else
   {
      // Broadcast onDrained() callback to other behaviors in this object
      %this.broadcastMethod( onRecharged, %amount );
   }
}
