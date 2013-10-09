/// ****************************** TARGETING  & SEEKING
/// ****************************** TARGETING  & SEEKING
/// ****************************** TARGETING  & SEEKING

/*
Description: Returns true if a this object and %target are farther than %distance apart.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::inDistance( %this, %target, %distance )
{
   %myPos     = %this.getPosition();
   %targetPos = %target.getPosition();

   %tweenDistance = t2dVectorLength( t2dVectorSub(%myPos, %targetPos) );

   return ( %tweenDistance <= %distance );
}

/*
Description: Returns true if %target is withing %fov angle of this object's 'forward vector' (facing).
*/
function t2dSceneObject::inFOV( %this, %target, %fov )
{
   %myPos = %this.getPosition();
   %myAngleVec = angleToVector( %this.getRotation() );

   %targetPos     = %target.getPosition();     
   %targetVec     = t2dVectorSub( %targetPos , %myPos );
   %targetVec     = t2dVectorNormalise( %targetVec );
         
   %tweenAngle    = mAcos( t2dVectorDot( %myAngleVec, %targetVec ) );
   %tweenAngle    = mRadToDeg( %tweenAngle );   
         
   return (%tweenAngle <= (%fov/2) );
}


/*
Description: Returns true if a vector drawn between this object and %target does not intersect any objects.
Objects are ignored if they don't match the %groupMask. i.e. If they are not in any of the groups specified by that bitmask.
*/
function t2dSceneObject::inLOS( %this, %target, %groupsMask )
{
   %target = %target.getID(); // in case a name is passed in; we need an ID
   
   %myPos      = %this.getPosition();
   %myRotVec   = t2dVectorNormalise( angleToVector( %this.getRotation() ) );

   %targetPos  = %target.getPosition();
   %targetVec  = t2dVectorSub( %targetPos , %myPos );
   %targetDist = t2dVectorLength( %targetVec );
   
   // Calculate the start/end positions of a ray-cast
   %start = %myPos;
   %end   = t2dVectorAdd( %start, t2dVectorScale( %myRotVec, %targetDist ) );
   
   // Do a ray-cast (pickline) and get a list of known targets)
   %targets = %this.getScenegraph().pickline( %start, %end, %groupsMask );
   
   if(%targets $= "") return false;
   
   // Look at each target in the list and be sure  it is NOT nearer than
   // the designated 'current' target
   %nearestDistance = %targetDist;
   %tmpTokens = %targets;      
   while( "" !$= %tmpTokens ) 
   {
      %tmpTokens = nextToken( %tmpTokens , "theToken" , " " );
      
      if( ( %theToken != %this ) && ( %theToken != %target ) )
      {         
         %targetPos     = %theToken.getPosition();     
         %targetVec     = t2dVectorSub( %targetPos , %myPos );
         %targetDist    = t2dVectorLength( %targetVec );
         if(%targetDist < %nearestDistance) return false;
     }
   }
   
   return true;
}


/*
Description:
   Returns a list of target objects, separated by spaces. This
   list will contain all objects within the specified 
   field-of-view (FOV) and distance.  Furthermore, the list will 
   only include objects whose group numbers are included in
   the %groups argument.  
                  
   Arguments and (defaults) if not specified:
   
   %this      ()        - ID (or name) of caller.
   %fov       (360.0)   - Field of view in which to search for targets.
   %distance  (10000.0) - Maximum distance at which to search for targets.
   %groups    ("0..31") - Groups that targets can be in.
*/
function t2dSceneObject::getTargets( %this, %fov, %distance, %groups )
{
   //
   // Be sure %this is a numeric value.
   //
   %this = %this.getId(); 
   
   //
   // Assign defaults if necessary
   //
   if(%fov $= "") %fov = 360.0;
   else if(%fov > 360.0) %fov = 360.0; // greater than 360 not allowed
   else if(%fov <= 0.0) %fov = 360.0;  // 0 or less not allowed
   
   if(%distance $= "") %distance = 10000.0;
   else if(%distance > 10000.0) %distance = 10000.0; // greater than 10000 not allowed
   else if(%distance <= 0.0) %distance = 10000.0; // 0 or less not allowed
   
   if(%groups $= "") 
   {
      %groupsMask = -1;
   }
   else
   {
      %groupsMask = bits(%groups);
   }

   //
   // Find initial set of objects
   //
   %myPos = %this.getPosition();
   %targets = %this.getScenegraph().pickradius( %myPos, %distance, %groupsMask );

   // Always exclude scanning object   
   %targets = removeNamedWord( %targets, %this, true );

   //
   // If FOV is less-than 360 degrees refine results further
   //
   if(%fov < 360.0) 
   {   
      %tmpTokens = %targets;
      
      while( "" !$= %tmpTokens ) 
      {
         %tmpTokens = nextToken( %tmpTokens , "theToken" , " " );
         if( %this.inFOV( %theToken, %fov ) == false)
         {
            %targets = removeNamedWord( %targets, %theToken, true );            
         }
      }
   }
   
   return %targets;
}


/*
Description:
   Returns the nearest target matching the following (default) paramters:  
   %this      ()        - ID (or name) of caller.
   %fov       (360.0)   - Field of view in which to search for targets.
   %distance  (10000.0) - Maximum distance at which to search for targets.
   %groups    ("0..31") - Groups that targets can be in.
*/
function t2dSceneObject::getNearestTarget( %this, %fov, %distance, %groups )
{
   %targets = %this.getTargets( %fov, %distance, %groups );

   if(%targets $= "" ) return 0;
   
   %myPos = %this.getPosition();
   %nearestDistance = 10001.0;
   %target = 0;

   %tmpTokens = %targets;
      
   while( "" !$= %tmpTokens ) 
   {
      %tmpTokens = nextToken( %tmpTokens , "theToken" , " " );
         
      %targetPos     = %theToken.getPosition();     
      %targetVec     = t2dVectorSub( %targetPos , %myPos );
      %targetDist    = t2dVectorLength( %targetVec );
      
      if(%targetDist < %nearestDistance) 
      {
         %target = %theToken;
         %nearestDistance = %targetDist;
      }
   }
   
   return %target;
}

/*
Description:
   Returns the furthest target matching the following (default) paramters:  
   %this      ()        - ID (or name) of caller.
   %fov       (360.0)   - Field of view in which to search for targets.
   %distance  (10000.0) - Maximum distance at which to search for targets.
   %groups    ("0..31") - Groups that targets can be in.
*/
function t2dSceneObject::getFurthestTarget( %this, %fov, %distance, %groups )
{
   %targets = %this.getTargets( %fov, %distance, %groups );
   
   if(%targets $= "" ) return 0;

   %myPos = %this.getPosition();
   %furthestDistance = -1;
   %target = 0;

   %tmpTokens = %targets;
      
   while( "" !$= %tmpTokens ) 
   {
      %tmpTokens = nextToken( %tmpTokens , "theToken" , " " );
         
      %targetPos     = %theToken.getPosition();     
      %targetVec     = t2dVectorSub( %targetPos , %myPos );
      %targetDist    = t2dVectorLength( %targetVec );

      if(%targetDist > %furthestDistance) 
      {
         %target = %theToken;
         %nearestDistance = %targetDist;
      }
   }
   
   return %target;
}

/*
Description:
   Returns a random target matching the following (default) paramters:  
   %this      ()        - ID (or name) of caller.
   %fov       (360.0)   - Field of view in which to search for targets.
   %distance  (10000.0) - Maximum distance at which to search for targets.
   %groups    ("0..31") - Groups that targets can be in.
*/
function t2dSceneObject::getRandomTarget( %this, %fov, %distance, %groups )
{
   %targets = %this.getTargets( %fov, %distance, %groups );
   
   %targets = randomizeWords( %targets, 4 * getWordCount( %targets ) );
   
   %target = getWord( %targets, 0 );
   
   if(isObject(%target))
   {
      return %target;
   }

   return 0;
}

