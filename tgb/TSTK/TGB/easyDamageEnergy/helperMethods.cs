///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

////
//   Status Helpers - This are generic safe ways for setting/getting disabled/destroyed metrics
//   These functions have not side-effects.  (see indirect helpers below for side-effects)
////
/*
Description: Returns true if this object has been marked as destroyed.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::getIsDestroyed( %this )
{
   return %this.isDestroyed;
}

/*
Description: Returns true if this object has been marked as disabled.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::getIsDisabled( %this )
{
   return %this.isDisabled;
}

/*
Description: Mark this object as destroyed.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::setIsDestroyed( %this, %status )
{
   %this.isDestroyed = %status;
}

/*
Description: Mark this object as disabled.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::setIsDisabled( %this, %status )
{
   %this.isDisabled = %status;
}

////
//   Indirect Status Helpers - These only go in one direction and test 
//   to insure the action is not taken twice. i.e. Can't disable once disabled.
//   Also, these all broadcast 'events' to the object's behaviors, allowing
//   those behaviors to take special 'response actions'
////
/*
Description: Destroy this object if it is not already destroyed and broadcast the method onDestroyed() to call behaviors on this object.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::destroyObject( %this )
{
   // Only allow a single 'destruction' (in case of accidental multiple calls)
   if( %this.isDestroyed ) return;
   
   %this.setIsDestroyed( true );
   %this.broadcastBehaviorMethod( "onDestroyed" );
}

/*
Description: Disable this object if it is not already disabled and broadcast the method onDisabled() to call behaviors on this object.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::disableObject( %this )
{
   // Don't re-disable if already disabled
   if( %this.isDisabled ) return;
   
   %this.setIsDisabled( true );
   %this.broadcastBehaviorMethod( "onDisabled" );
}

/*
Description: Enable this object if it is disabled and broadcast the method onEnabled() to call behaviors on this object.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::enableObject( %this )
{
   // Don't re-enable if already enabled
   if( %this.isDisabled == false  ) return;
   
   %this.setIsDisabled( false );
   %this.broadcastBehaviorMethod( "onEnabled" );
}
