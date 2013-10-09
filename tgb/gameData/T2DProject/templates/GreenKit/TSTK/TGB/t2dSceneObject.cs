//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

/*
Description: Return the distance between this object and %dstObject.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::distanceBetween( %this, %dstObject )
{
   %toVec = %this.vectorTo( %dstObject );
   return t2dVectorLength( %toVec );
}

/*
Description: Return a vector between this object and %dstObject.
*/
function t2dSceneObject::vectorTo( %this, %dstObject )
{
   %myPos = %this.getPosition();
   %dstPos = %dstObject.getPosition();
   return(t2dVectorSub( %myPos, %dstObject ));
}

/*
Description: Return true if %distObject is in-front of this object.
To be in-front, %dstObject must be within a 180-degree field of view.
*/
function t2dSceneObject::inFrontOfMe( %this, %dstObject )
{
   return( %this.inFOV( %dstObject, 180.0 ) );
}

/*
Description: Return true if %distObject is behind of this object.
To be in-front, %dstObject must be outside a 180-degree field of view.
*/
function t2dSceneObject::behindMe( %this, %dstObject )
{
   return ( %this.inFrontOfMe(%dstObject) == false );
}