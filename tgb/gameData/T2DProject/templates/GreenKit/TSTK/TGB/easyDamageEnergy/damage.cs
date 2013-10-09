///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

/*
Description: Initialize easy damage settings for this object.
           %max - Maximum damage this object can take. i.e. Hit Points
    %disabledAt - Damage point value at which the object should be considered disable. (-1 means can't be disabled)
   %destroyedAt - Damage point value at which the object should be considered destroyed. (-1 means can't be destroyed)
%autoRepairRate - Damage points per/second that should be repaired when the object is damaged.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::initDamage(%this, %max, %disabledAt, %destroyedAt, %autoRepairRate ) 
{
   // Apply default settings if arguments were not provided
   %disabledAt      = (%disabledAt $= "") ? -1 : %disabledAt;
   %destroyedAt     = (%destroyedAt $= "") ? -1 : %destroyedAt;
   %autoRepairRate  = (%autoRepairRate $= "") ? 0 : %autoRepairRate;
   
   // Track current and maximum damage points; Start with max.
   %this.damage[max] = %max;
   %this.damage[current] = %this.damage[max];

   // Set disabled at status and value
   %this.setIsDisabled( false );
   %this.damage[disabledAt] = %disabledAt;
   
   // Set destroyed at status and value
   %this.setIsDestroyed( false );
   %this.damage[destroyedAt] = %destroyedAt;

   // Set autoRepair status and value
   %this.isRepairingDamage = false;
   %this.damage[autoRepairRate] = %autoRepairRate;
}

/*
Description: Returns the maximum damage points this object should assigned.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::getMaxDamage(%this) 
{
   return %this.damage[max];
}

/*
Description: Sets the maximum damage points this object should assigned.
Unless %skipTest is set to true, , the object is tested for damage to see if it needs to be repaired.  
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::setMaxDamage(%this, %max, %skipTest ) 
{
   %this.damage[max] = %max;
   
   // Don't allow current to be greater than max
   if(%this.damage[current] > %this.damage[max])
   {
      %this.setCurrentDamage( %max, %skipTest );
      return;
   }
   %this.autoRepairDamage();
}

/*
Description: Returns the current damage points for this object.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::getCurrentDamage(%this) 
{
   return %this.damage[current];
}

/*
Description: Returns the current damage as a percentage value (between 0 and 100) for this object.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::getCurrentDamagePercent(%this) 
{
   return ((1 - %this.damage[current]/%this.damage[max]) * 100);
}

/*
Description: Sets the curred damage points for this object.
Unless %skipTest is set to true, , the object is tested for damage to see if it needs to be repaired.  
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::setCurrentDamage(%this, %current, %skipTest ) 
{
   // Don't allow current damage points to be greater than max
   %this.damage[current] = (%current > %this.damage[max]) ? %this.damage[max] : %current;

   // Unless asked to skip this step, test to see if the object is now
   // disabled/destroyed with the change in current damage points
   if( %skipTest == false )
   {
      %this.test_DisabledDamage();
      %this.test_DestroyedDamage();
   }
   
   %this.autoRepairDamage();
}

/*
Description: Returns the disabled at damage points level for this object.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::getDisabledAtDamage(%this) 
{
   return %this.damage[disabledAt];
}
/*
Description: Sets the disabled at damage points level for this object.
If %skipTest is not set to true, this object is also tested to see if it should now be disabled.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::setDisabledAtDamage(%this, %disabledAt, %skipTest ) 
{
   // Track current and maximum damage points; Start with max.
   %this.damage[disabledAt] = %disabledAt;
   
   // Unless asked to skip this step, test to see if the object is now disabled
   if( %skipTest == false )
   {
      %this.test_DisabledDamage();
   }
}

/*
Description: Returns the destroyed at damage points level for this object.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::getDestroyedAtDamage(%this) 
{
   return %this.damage[destroyedAt];
}

/*
Description: Sets the destroyed at damage points level for this object.
If %skipTest is not set to true, this object is also tested to see if it should now be destroyed.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::setDestroyedAtDamage(%this, %destroyedAt, %skipTest ) 
{
   // Track current and maximum damage points; Start with max.
   %this.damage[destroyedAt] = %destroyedAt;
   
   // Unless asked to skip this step, test to see if the object is now destroyed
   if( %skipTest == false )
   {
      %this.test_DestroyedDamage();
   }
}

/*
Description: Returns the auto-repair rate for this object.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::getAutoRepairRate(%this) 
{
   return %this.damage[autoRepairRate];
}

/*
Description: Sets the auto-repair rate for this object.
If %skipTest is not set to true, this object is also tested to see if it should now be auto-repaired.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::setAutoRepairRate(%this, %autoRepairRate, %skipTest ) 
{
   // Track current and maximum damage points; Start with max.
   %this.damage[autoRepairRate] = %autoRepairRate;
   
   // Unless asked to skip this step, test to see if the object is in need of repairing
   if( %skipTest == false )
   {
      %this.autoRepairDamage();
   }
}

//// 
//   WORKER FUNCTIONS - Do or undo damage
////
/*
Description: Attempt to apply the specified amount of damage to this object.
If the amount is negative, do repair instead.
If damage is successfully applied, broadcast the onDamage() method to all behaviors on this object with the actual damage done.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::applyDamage( %this , %amount )
{    
   // Don't allow destroyed objects to be damaged further
   if( %this.getIsDestroyed() ) return;

   // If user mistakenly passes a negative damage value use repairDamage instead
   if( %amount < 0 )
   {
      %this.repairDamage( -%amount );
      return;
   }
   
   // Apply damage   
   %initial = %this.damage[current];
   %this.damage[current] -= %amount;
   %this.damage[current] = (%this.damage[current] < 0) ? 0 : %this.damage[current];
   %this.damage[current] = (%this.damage[current] > %this.damage[max]) ? %this.damage[max] : %this.damage[current];
   
   // Calculate actual damage done  
   %actual  = %initial - %this.damage[current];
   
   // No damage done, just return
   if(%actual == 0) return;

   // Test for destruction and disable and if neither occurs, broadcast an 
   // onDamaged event to any  behaviors attached to this object
   if( !%this.test_DestroyedDamage() )
   {      
      %this.test_DisabledDamage();
      %this.broadcastBehaviorMethod( "onDamaged", %actual );
   }
   
   // Attempt to repair if auto-repairing is set
   if(%this.damage[autoRepairRate] !$= 0 ) %this.autoRepairDamage();
}


/*
Description: Attempt to apply the specified amount of repair to this object.
If the amount is negative, do damage instead.
If repair is successfully applied, broadcast the onRepair() method to all behaviors on this object with the actual repair done.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::repairDamage( %this , %amount )
{ 
   // Don't allow destroyed objects to be repaired
   if( %this.getIsDestroyed() ) return;

   // If user mistakenly passes a negative repair value use applyDamage instead
   if( %amount < 0 )
   {
      %this.applyDamage( -%amount );
      return;
   }

   // Don't repair objects that have no damage
   if( %this.damage[current] == %this.damage[max] ) return;
   
   // Apply repair 
   %initial = %this.damage[current];
   %this.damage[current] += %amount;
   %this.damage[current] = (%this.damage[current] < 0) ? 0 : %this.damage[current];
   %this.damage[current] = (%this.damage[current] > %this.damage[max]) ? %this.damage[max] : %this.damage[current];

   // Calculate actual repair done  
   %actual  = %initial - %this.damage[current];

   // No repair done, just return
   if(%actual == 0) return;

   // Check to see if this object has been renabled
   %this.test_EnabledDamage();

   %this.broadcastBehaviorMethod( "onRepaired", %actual );
}

/*
Description: Apply damage to this object over time, where a portion of the total damage is applied every %period.
The damage done per period is calculated as: %totalDamage / ( %duration / %period )
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::applyDamageOverTime( %this , %period, %duration, %totalDamage )
{ 
   %numApplies = %duration / %period;
   %perApplyDamage = %totalDamage / %numApplies;
   
   for(%count=0;%count<%numApplies;%count++)
   {
      %this.schedule( %count * %period, "applyDamage", %perApplyDamage );
   }
}

/*
Description: Apply repair to this object over time, where a portion of the total repair is applied every %period.
The repair done per period is calculated as: %totalRepair / ( %duration / %period )
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::repairDamageOverTime( %this , %period, %duration, %totalRepair )
{ 
   %numApplies = %duration / %period;
   %perRepairDamage = %totalRepair / %numApplies;
   
   for(%count=0;%count<%numApplies;%count++)
   {
      %this.schedule( %count * %period, "repairDamage", %perRepairDamage );
   }   
}

/*
Description: Internal only.  Called automatically in a number of cases to attempt to auto-repair this object.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::autoRepairDamage( %this )
{
   // Don't allow destroyed objects to be repaired
   if( %this.getIsDestroyed() ) 
   {
      %this.isRepairingDamage = false;   
      return;
   }
   
   // Auto repair enabled?
   if(%this.damage[autoRepairRate] == 0) 
   {
      %this.isRepairingDamage = false;   
      return; 
   }
   
   // Don't allow overlapping auto-repair schedules
   if(isEventPending(%this.lastRepair) ) return; 

   // If not damaged, abort
   if ( %this.damage[current] >= %this.damage[max] ) 
   {
      %this.isRepairingDamage = false;   
      return;
   }

   %this.isRepairingDamage = true;   

   %this.repairDamage( %this.damage[autoRepairRate] / 4 );
   
   if ( %this.damage[current] >= %this.damage[max] ) 
   {
      %this.isRepairingDamage = false;   
      return;
   }

   %this.lastRepair = %this.schedule( 250, autoRepairDamage );   
}


////
//   TEST FUNCTIONS - Test to see what the result of damaging or undoing-damage is
////

/*
Description: Test to see if this object should be destroyed and if so, destroy it.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::test_DestroyedDamage( %this )
{    
   if( !%this.getIsDestroyed() && ( %this.damage[current] <= %this.damage[destroyedAt] ) )
   { 
      %this.destroyObject();
      return true;
   } 
   return false;
}

/*
Description: Test to see if this object should be disabled and if so, disable it.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::test_DisabledDamage( %this )
{ 
   if( !%this.getIsDisabled() && ( %this.damage[current] <= %this.damage[disabledAt] ) )
   { 
      %this.disableObject();
      return true;
   }
   return false;
}

/*
Description: Test to see if this object should be disabled and if so, disable it.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::test_EnabledDamage( %this )
{ 
   if( %this.getIsDisabled() && ( %this.damage[current] > %this.damage[disabledAt] ) )
   { 
      %this.broadcastBehaviorMethod( "onEnabled", %amount );
      %this.enableObject();
      return true;
   }
   return false;
}

/*
Description: Internal only.  Prints the current damage and other metrics for this object repeatedly every period.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::autoReportDMG(%this,%period) 
{
   if(%period < 100) %period = 100;
   echo("O:", %this, 
        " DMG: ", %this.getCurrentDamage() SPC "(" @ %this.getCurrentDamagePercent() @ "%)", 
        " isRepairing: ", %this.isRepairingDamage,
        " isDisabled: ", %this.isDisabled,
        " isDestroyed: ", %this.isDestroyed);
        
   %this.schedule(%period, autoReportDMG, %period );
   
}
