//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

/*
Description: 
Returns scriptObject containing eight of scriptObjects, each having a 
field named 'position' containing the location of a compass point about the
shape.  Compass points are in a circle about the  shape, where the circle
lies on the outer edges of the shape's world box.  The circle's radius can
be increased by specifying an %offset.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function sceneObject::GetCompassPoints( %obj, %radius, %offset) 
{
	%worldBox       = %obj.getWorldBox();
	%worldBoxCenter = %obj.getWorldBoxCenter();

	echo("World Box Center =>", %worldBoxCenter);
	echo("       World Box =>", %worldBox);

	%x0 = getWord( %worldBox , 0 );
	%y0 = getWord( %worldBox , 1 );
	%z0 = getWord( %worldBox , 2 );
	%x1 = getWord( %worldBox , 3 );
	%y1 = getWord( %worldBox , 4 );
	%z1 = getWord( %worldBox , 5 );

	%xc = getWord( %worldBoxCenter , 0 );
	%yc = getWord( %worldBoxCenter , 1 );
	%zc = getWord( %worldBoxCenter , 2 );

	%radius2 =  mSqrt( 2 * (%radius * %radius) );

	%point0 = %x0 - %radius  SPC %y0 - %radius  SPC %z0;
	%point1 = %x0 - %radius2 SPC %yc            SPC %z0;
	%point2 = %x0 - %radius  SPC %y1 + %radius  SPC %z0;
	%point3 = %xc            SPC %y1 + %radius2 SPC %z0;
	%point4 = %x1 + %radius  SPC %y1 + %radius  SPC %z0;
	%point5 = %x1 + %radius2 SPC %yc            SPC %z0;
	%point6 = %x1 + %radius  SPC %y0 - %radius  SPC %z0;
	%point7 = %xc            SPC %y0 - %radius2 SPC %z0;

	if("" !$= %offset) 
	{
	   %point0 = vectorAdd( %point0, %offset );
	   %point1 = vectorAdd( %point1, %offset );
	   %point2 = vectorAdd( %point2, %offset );
	   %point3 = vectorAdd( %point3, %offset );
	   %point4 = vectorAdd( %point4, %offset );
	   %point5 = vectorAdd( %point5, %offset );
	   %point6 = vectorAdd( %point6, %offset );
	   %point7 = vectorAdd( %point7, %offset );
	}
	
	%theSet = new simSet();


	for(%count = 0; %count < 8; %count++) {
		echo("Point[", %count, "] == ", %point[%count]);
		%tmpSO = new scriptObject();

		%tmpSO.position = %point[%count];
		%theSet.add(%tmpSO);
	}

	return %theSet;
}


/*
Description: Cast a ray from the current position of %object downward, finding a point that intersects any of the following types:
      $TypeMasks::TerrainObjectType
      $TypeMasks::InteriorObjectType
      $TypeMasks::StaticShapeObjectType
      $TypeMasks::PlayerObjectType
      $TypeMasks::ItemObjectType
      $TypeMasks::VehicleObjectType
      $TypeMasks::VehicleBlockerObjectType
      $TypeMasks::StaticTSObjectType
      
At that point, add the %offsetVector and place %object at this new calculated position.
Note: This function will not move TSStatic() objects. Their positions must be set once and only once, on construction.  Use CalculateObjectDropPosition() instead.
*/
function DropObject( %object , %offsetVector ) {
   %mask	= 
      $TypeMasks::TerrainObjectType			|
      $TypeMasks::InteriorObjectType			|
      $TypeMasks::StaticShapeObjectType		|
      $TypeMasks::PlayerObjectType			|
      $TypeMasks::ItemObjectType				|
      $TypeMasks::VehicleObjectType			|
      $TypeMasks::VehicleBlockerObjectType	|
      $TypeMasks::StaticTSObjectType;

   %oldPosition = %object.getPosition();
   %subTerrain  = getWords(%oldPosition, 0, 1) @ " -1";

   %newPosition = containerRayCast( %oldPosition , %subTerrain , %mask , 0 );

   	//echo("Ray hit => " @ %newPosition);

   %newPosition = getWords(%newPosition, 1 , 3);


   // Add user specified offset
   if("" !$= %offsetVector) {
      %newPosition = VectorAdd(%newPosition, %offsetVector);
   }

   //	echo(%object.getName() @ " => oldPostion = " @ %oldPosition);
   //	echo(%object.getName() @ " => newPosition = " @ %newPosition);


   // Update this object's position.
   //
   // Q: Why not just do a %obj.position = "x y z"; ??
   // A: This will move the object, but only setTransform()
   //    will correctly update the location/orientation of
   //    the object's bounding/world box.  
   //

   %transform = %object.getTransform();

   %transform = setWord(%transform, 0, getWord(%newPosition, 0));
   %transform = setWord(%transform, 1, getWord(%newPosition, 1));
   %transform = setWord(%transform, 2, getWord(%newPosition, 2));

   %object.setTransform(%transform);

}

/*
Description: Temporarily set the transform for %object to that of %marker.  Then, call dropObject() on %object with the specified %offsetVector.
*/
function DropObjectFromMarker( %object , %marker , %offsetVector ) {
   %object.setTransform(%marker.getTransform());
   DropObject( %object, %offsetVector ) ;
}

/*
Description: This function is used to calculate a drop postion using the same technique as dropObject(), but simply returning the drop position.
An option %mask (bitmask) can be passed in.  If one is not provided, the automatically calculated %mask will contain all of these types:
      $TypeMasks::TerrainObjectType
      $TypeMasks::InteriorObjectType
      $TypeMasks::StaticShapeObjectType
      $TypeMasks::PlayerObjectType
      $TypeMasks::ItemObjectType
      $TypeMasks::VehicleObjectType
      $TypeMasks::VehicleBlockerObjectType
      $TypeMasks::StaticTSObjectType
*/
function CalculateObjectDropPosition( %oldPosition , %offsetVector , %mask) {
   
   if (!%mask)
   {
      %mask	= 
      $TypeMasks::TerrainObjectType			|
      $TypeMasks::InteriorObjectType			|
      $TypeMasks::StaticShapeObjectType		|
      $TypeMasks::PlayerObjectType			|
      $TypeMasks::ItemObjectType				|
      $TypeMasks::VehicleObjectType			|
      $TypeMasks::VehicleBlockerObjectType	|
      $TypeMasks::StaticTSObjectType;
   }

   %subTerrain  = getWords(%oldPosition, 0, 1) @ " -1";

   %newPosition = containerRayCast( %oldPosition , %subTerrain , %mask , 0 );

   %newPosition = getWords(%newPosition, 1 , 3);

   // Add user specified offset
   if("" !$= %offsetVector) {
      %newPosition = VectorAdd(%newPosition, %offsetVector);
   }

   return %newPosition;
}

/*
Description: Calculate a leftward-facing vector from the object's (%obj) forward vector.
*/
function getObjLeftVector( %obj ) 
{
  return getLeftVector( %obj.getForwardVector() );
}

/*
Description: Calculate a rightward-facing vector from the object's (%obj) forward vector.
*/
function getObjRightVector( %obj ) 
{
  return getRightVector( %obj.getForwardVector() );
}

/*
Description: Calculate a rightward-facing vector from %vec.
*/
function getRightVector( %vec ) 
{
   %cross    = vectorCross( %vec , "0 0 1");
   %rightVec  = vectorNormalize( %cross );

   %rightVec  = setWord( %rightVec, 0 , mfloatlength( getWord( %rightVec , 0 ) , 3 ) );
   %rightVec  = setWord( %rightVec, 1 , mfloatlength( getWord( %rightVec , 1 ) , 3 ) );
   return %rightVec;
}

/*
Description: Calculate a leftward-facing vector from %vec.
*/
function getLeftVector( %vec ) 
{
   %leftVec  = vectorScale( getRightVector(%vec) , -1 );
   return %leftVec;
}

