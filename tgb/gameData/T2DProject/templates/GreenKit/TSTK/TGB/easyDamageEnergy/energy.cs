///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

/*
Description: Initialize easy energy settings for this object.
             %max - Maximum damage this object can take. i.e. Hit Points
      %disabledAt - Energy point value at which the object should be considered disable. (-1 means can't be disabled)
     %destroyedAt - Energy point value at which the object should be considered destroyed. (-1 means can't be destroyed)
%autoRechargeRate - Energy points per/second that should be repaired when the object is drained.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::initEnergy(%this, %max, %disabledAt, %destroyedAt, %autoRechargeRate ) 
{
   // Apply default settings if arguments were not provided
   %disabledAt      = (%disabledAt $= "") ? -1 : %disabledAt;
   %destroyedAt     = (%destroyedAt $= "") ? -1 : %destroyedAt;
   %autoRechargeRate  = (%autoRechargeRate $= "") ? 0 : %autoRechargeRate;
   
   // Track current and maximum energy points; Start with max.
   %this.energy[max] = %max;
   %this.energy[current] = %this.energy[max];

   // Set disabled at status and value
   %this.setIsDisabled( false );
   %this.energy[disabledAt] = %disabledAt;
   
   // Set destroyed at status and value
   %this.setIsDestroyed( false );
   %this.energy[destroyedAt] = %destroyedAt;

   // Set autoRecharge status and value
   %this.isRechargingEnergy = false;
   %this.energy[autoRechargeRate] = %autoRechargeRate;
}

/*
Description: Returns the maximum energy points this object should assigned.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::getMaxEnergy(%this) 
{
   return %this.energy[max];
}

/*
Description: Sets the maximum energy points this object should assigned.
Unless %skipTest is set to true, the object is tested for drain to see if it needs to be recharged.  
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::setMaxEnergy(%this, %max, %skipTest ) 
{
   %this.energy[max] = %max;
   
   // Don't allow current to be greater than max
   if(%this.energy[current] > %this.energy[max])
   {
      %this.setCurrentEnergy( %max, %skipTest );
      return;
   }
   %this.autoRechargeEnergy();
}

/*
Description: Returns the current energy points for this object.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::getCurrentEnergy(%this) 
{
   return %this.energy[current];
}

/*
Description: Returns the current energy as a percentage value (between 0 and 100) for this object.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::getCurrentEnergyPercent(%this) 
{
   return ((1 - %this.energy[current]/%this.energy[max]) * 100);
}

/*
Description: Sets the current energy points this object should assigned.
Unless %skipTest is set to true, the object is tested for drain to see if it needs to be recharged.  
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::setCurrentEnergy(%this, %current, %skipTest ) 
{
   // Don't allow current energy points to be greater than max
   %this.energy[current] = (%current > %this.energy[max]) ? %this.energy[max] : %current;

   // Unless asked to skip this step, test to see if the object is now
   // disabled/destroyed with the change in current energy points
   if( %skipTest == false )
   {
      %this.test_DisabledEnergy();
      %this.test_DestroyedEnergy();
   }
   
   %this.autoRechargeEnergy();
}

/*
Description: Returns the disabled at energy points level for this object.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::getDisabledAtEnergy(%this) 
{
   return %this.energy[disabledAt];
}

/*
Description: Sets the maximum energy points this object should assigned.
Unless %skipTest is set to true, , the object is tested for drain to see if it needs to be recharged.  
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::setDisabledAtEnergy(%this, %disabledAt, %skipTest ) 
{
   // Track current and maximum energy points; Start with max.
   %this.energy[disabledAt] = %disabledAt;
   
   // Unless asked to skip this step, test to see if the object is now disabled
   if( %skipTest == false )
   {
      %this.test_DisabledEnergy();
   }
}

/*
Description: Returns the destroyed at energy points level for this object.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::getDestroyedAtEnergy(%this) 
{
   return %this.energy[destroyedAt];
}

/*
Description: Sets the maximum energy points this object should assigned.
Unless %skipTest is set to true, , the object is tested for drain to see if it needs to be recharged.  
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::setDestroyedAtEnergy(%this, %destroyedAt, %skipTest ) 
{
   // Track current and maximum energy points; Start with max.
   %this.energy[destroyedAt] = %destroyedAt;
   
   // Unless asked to skip this step, test to see if the object is now destroyed
   if( %skipTest == false )
   {
      %this.test_DestroyedEnergy();
   }
}

/*
Description: Returns the auto-repair rate for this object.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::getAutoRechargeRate(%this) 
{
   return %this.energy[autoRechargeRate];
}

/*
Description: Sets the auto-repair rate for this object.
If %skipTest is not set to true, this object is also tested to see if it should now be auto-repaired.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::setAutoRechargeRate(%this, %autoRechargeRate, %skipTest ) 
{
   // Track current and maximum energy points; Start with max.
   %this.energy[autoRechargeRate] = %autoRechargeRate;
   
   // Unless asked to skip this step, test to see if the object is in need of rechargeing
   if( %skipTest == false )
   {
      %this.autoRechargeEnergy();
   }
}

//// 
//   WORKER FUNCTIONS - Do or undo energy
////
/*
Description: Attempt to apply the specified amount of energy drain to this object.
If the amount is negative, do recharge instead.
If energy is successfully drained, broadcast the onDrain() method to all behaviors on this object with the actual drain done.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::drainEnergy( %this , %amount )
{    
   // Don't allow destroyed objects to be energyd further
   if( %this.getIsDestroyed() ) return;

   // If user mistakenly passes a negative energy value use rechargeEnergy instead
   if( %amount < 0 )
   {
      %this.rechargeEnergy( -%amount );
      return;
   }
   
   // Apply energy   
   %initial = %this.energy[current];
   %this.energy[current] -= %amount;
   %this.energy[current] = (%this.energy[current] < 0) ? 0 : %this.energy[current];
   %this.energy[current] = (%this.energy[current] > %this.energy[max]) ? %this.energy[max] : %this.energy[current];
   
   // Calculate actual energy done  
   %actual  = %initial - %this.energy[current];
   
   // No energy done, just return
   if(%actual == 0) return;

   // Test for destruction and disable and if neither occurs, broadcast an 
   // onEnergyd event to any  behaviors attached to this object
   if( !%this.test_DestroyedEnergy() )
   {      
      %this.test_DisabledEnergy();
      %this.broadcastBehaviorMethod( "onEnergyd", %actual );
   }
   
   // Attempt to recharge if auto-rechargeing is set
   if(%this.energy[autoRechargeRate] !$= 0 ) %this.autoRechargeEnergy();
}


/*
Description: Attempt to apply the specified amount of repair to this object.
If the amount is negative, do drain instead.
If repair is successfully applied, broadcast the onRepair() method to all behaviors on this object with the actual repair done.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::rechargeEnergy( %this , %amount )
{ 
   // Don't allow destroyed objects to be rechargeed
   if( %this.getIsDestroyed() ) return;

   // If user mistakenly passes a negative recharge value use drainEnergy instead
   if( %amount < 0 )
   {
      %this.drainEnergy( -%amount );
      return;
   }

   // Don't recharge objects that have no energy
   if( %this.energy[current] == %this.energy[max] ) return;
   
   // Apply recharge 
   %initial = %this.energy[current];
   %this.energy[current] += %amount;
   %this.energy[current] = (%this.energy[current] < 0) ? 0 : %this.energy[current];
   %this.energy[current] = (%this.energy[current] > %this.energy[max]) ? %this.energy[max] : %this.energy[current];

   // Calculate actual recharge done  
   %actual  = %initial - %this.energy[current];

   // No recharge done, just return
   if(%actual == 0) return;

   // Check to see if this object has been renabled
   %this.test_EnabledEnergy();

   %this.broadcastBehaviorMethod( "onRechargeed", %actual );
}

/*
Description: Apply energy drain to this object over time, where a portion of the total drain is applied every %period.
The drain done per period is calculated as: %totalEnergy / ( %duration / %period )
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::drainEnergyOverTime( %this , %period, %duration, %totalEnergy )
{ 
   %numApplies = %duration / %period;
   %perDrainEnergy = %totalEnergy / %numApplies;
   
   for(%count=0;%count<%numApplies;%count++)
   {
      %this.schedule( %count * %period, "drainEnergy", %perDrainEnergy );
   }
}

/*
Description: Apply repair to this object over time, where a portion of the total repair is applied every %period.
The repair done per period is calculated as: %totalRepair / ( %duration / %period )
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::rechargeEnergyOverTime( %this , %period, %duration, %totalRecharge )
{ 
   %numApplies = %duration / %period;
   %perRechargeEnergy = %totalRecharge / %numApplies;
   
   for(%count=0;%count<%numApplies;%count++)
   {
      %this.schedule( %count * %period, "rechargeEnergy", %perRechargeEnergy );
   }   
}

/*
Description: Internal only.  Called automatically in a number of cases to attempt to auto-recharge this object.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::autoRechargeEnergy( %this )
{
   // Don't allow destroyed objects to be rechargeed
   if( %this.getIsDestroyed() ) 
   {
      %this.isRechargingEnergy = false;   
      return;
   }
   
   // Auto recharge enabled?
   if(%this.energy[autoRechargeRate] == 0) 
   {
      %this.isRechargingEnergy = false;   
      return; 
   }
   
   // Don't allow overlapping auto-recharge schedules
   if(isEventPending(%this.lastRecharge) ) return; 

   // If not energyd, abort
   if ( %this.energy[current] >= %this.energy[max] ) 
   {
      %this.isRechargingEnergy = false;   
      return;
   }

   %this.isRechargingEnergy = true;   

   %this.rechargeEnergy( %this.energy[autoRechargeRate] / 4 );
   
   if ( %this.energy[current] >= %this.energy[max] ) 
   {
      %this.isRechargingEnergy = false;   
      return;
   }

   %this.lastRecharge = %this.schedule( 250, autoRechargeEnergy );   
}


////
//   TEST FUNCTIONS - Test to see what the result of damaging or undoing-energy is
////

/*
Description: Test to see if this object should be destroyed and if so, destroy it.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::test_DestroyedEnergy( %this )
{    
   if( !%this.getIsDestroyed() && ( %this.energy[current] <= %this.energy[destroyedAt] ) )
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
function t2dSceneObject::test_DisabledEnergy( %this )
{ 
   if( !%this.getIsDisabled() && ( %this.energy[current] <= %this.energy[disabledAt] ) )
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
function t2dSceneObject::test_EnabledEnergy( %this )
{ 
   if( %this.getIsDisabled() && ( %this.energy[current] > %this.energy[disabledAt] ) )
   { 
      %this.broadcastBehaviorMethod( "onEnabled", %amount );
      %this.enableObject();
      return true;
   }
   return false;
}



/*
Description: Internal only.  Prints the current energy and other metrics for this object repeatedly every period.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::autoReportENG(%this,%period) 
{
   if(%period < 100) %period = 100;
   echo("ENG: ", %this.getCurrentEnergy() SPC "(" @ %this.getCurrentEnergyPercent() @ "%)", 
        " isRecharging: ", %this.isRechargingEnergy,
        " isDisabled: ", %this.getIsDisabled(),
        " isDestroyed: ", %this.getIsDestroyed());
   %this.schedule(%period, autoReportDMG, %period );
}
