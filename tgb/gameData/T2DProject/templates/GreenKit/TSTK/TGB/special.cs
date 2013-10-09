//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------


/*
Description: Returns a random position somewhere inside of the specified bounding box where an object can be safely placed, such that it does not overlap any of the objects in %container.
This function will try to find a random position that satisfies this requirement up to %maxIter times.  If it doesn't find one, a NULL string ("") is returned.

Note: Objects that do not receive or send collisions are ignored.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function getSafeSpawnPosition( %container , %size , %boundingBox , %maxIter) 
{
   %ulX = getWord( %boundingBox , 0 );
   %ulY = getWord( %boundingBox , 1 );
   %lrX = getWord( %boundingBox , 2 );
   %lrY = getWord( %boundingBox , 3 );
   
   %radius = %size / 2;
   
   %foundPosition = false;
   for( %iter = 0; (%iter < %maxIter) && ( false == %foundPosition); %iter++ )
   {
      // Randomly select a point inside the 'legal' spawn area
      %tmpX = getRandom( %ulX , %lrX );
      %tmpY = getRandom( %ulY , %lrY );

      %overlapDetected = false;
      for( %count = 0 ; (%count < %container.getCount()) && (false == %overlapDetected) ; %count++)
      {
         %obj = %container.getObject( %count );
         
         if( ( true == %obj.getCollisionActiveSend() ) || ( true == %obj.getCollisionActiveReceive() ) ) 
         {
         
            %objRadius = t2dVectorLength( %obj.getSize() ) / 2;
         
            %distanceBetween = t2dVectorLength( t2dVectorSub( %obj.getPosition(), %tmpX SPC %tmpY ) );
         
            if( %distanceBetween < (%objRadius + %radius ) ) %overlapDetected = true;
         }
      }      
      if( false == %overlapDetected ) %foundPosition = true;
   }
   
   if (true == %foundPosition ) return (%tmpX SPC %tmpY );
   return "";   
}

/*
Description: Returns a list of eight link-points evenly distributed in a circle.  
Note: This was written to simplify the creation of shield mounts in a starcastle remake.
*/
function calculateLinkPoints() //EFM specific to starcastle
{
   %vecLen = t2dVectorLength( "0.7 0.7" );
   %LinkPoints      = 0.0      SPC  -%vecLen SPC
                      0.7      SPC  -0.7     SPC
                      %vecLen  SPC   0.0     SPC
                      0.7      SPC   0.7     SPC
                      0.0      SPC  %vecLen  SPC
                      -0.7     SPC   0.7     SPC
                      -%vecLen SPC   0.0     SPC
                      -0.7     SPC  -0.7;
                      
   return %LinkPoints;
}
