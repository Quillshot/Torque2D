///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

/*
Description: Use this method to enable Triggering of %srcType by one or more %dstType types.
Note: Same as collision setup, so allow collidesWith to do the work.
Note2: %dstType accepts a comma separated list of type names.
*/
function RGQC::triggeredBy( %this, %srcType, %dstType )
{
   %this.collidesWith(%srcType, %dstType );
}
