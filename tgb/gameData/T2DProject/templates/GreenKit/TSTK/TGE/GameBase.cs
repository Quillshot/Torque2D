//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

/*
Description: Return true if %obj is in in the GameBase object hierarchy.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function isGameBase( %obj ) 
{
	return ( %obj.getType() == $TypeMasks::GameBaseObjectType );
}
