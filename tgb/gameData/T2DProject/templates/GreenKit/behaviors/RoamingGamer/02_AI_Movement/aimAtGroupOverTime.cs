if (!isObject(aimAtGroupOverTime))
{
   %behavior = new BehaviorTemplate(aimAtGroupOverTime)
   {
      friendlyName = "Aim At Object(s) Over Time";
      behaviorType = "02 - AI Movement";
      description  = "Automatically rotate to face the nearest object in a specified group. (Rotation takes time.)";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", "bool", true);
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);
   
   %behavior.addBehaviorField( "aimGroups", "Groups to aim at.", "bitmask", "0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31");   

   %behavior.addBehaviorField("maxDistance", "Maximum distance at which a target can be detected.", "float", 25.0);
   %behavior.addBehaviorField("maxAngle", "Maximum angle to seek within.", "float", 360.0);

   %behavior.addBehaviorField("turnRate", "Turn speed in degrees-per-second.", "float", 90.0);
   %behavior.addBehaviorField("updateSpeed", "Time between aim updates (lower values are faster and smoother looking).", "integer", 32);

   %behavior.addBehaviorField(Can_Lose_Target, "Target can be lost if it moves out of the aiming distance or angle.", "bool", false);
}

function aimAtGroupOverTime::onAddToScene(%this, %scenegraph) 
{
   if(%this.debugMode) echo("aimAtGroupOverTime::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(!%this.enable) return;
   
   if( %this.maxAngle > 360 ) %this.maxAngle = 360;

   %this.aimGroupsMask = bits(%this.aimGroups);

   %this.aim( );
}


function aimAtGroupOverTime::aim(%this) 
{
   if(%this.debugMode) echo("aimAtGroupOverTime::aim( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(!%this.enable) return;
   
   %myPos = %this.owner.getPosition();
   %myRot = %this.owner.getRotation();   
   if(%myRot < 0 ) 
   {
      %myRot = %myRot + 360;
      %this.owner.setRotation(%myRot);   
   }
   %myForwardVector = angleToVector( %myRot );
   
   %halfAngle  = %this.maxAngle/2;

   ////
   //   1. See if we have lost our target
   ////
   if(%this.Can_Lose_Target && isObject( %this.target ))
   {
      %target = %this.target;
      %targetPos      = %this.target.getPosition();     
      %targetVec      = t2dVectorSub( %targetPos , %myPos );
      %targetVec      = t2dVectorNormalise( %targetVec );
         
      %targetAngle    = t2dAngleBetween( %targetVec, %myForwardVector );         
      %targetDistance = t2dVectorDistance( %myPos, %targetPos );
         
      if(%this.debugMode) echo("(1) %targetDistance      == ", %targetDistance );
      if(%this.debugMode) echo("(1) maxDistance          == ", %this.maxDistance );
      if(%this.debugMode) echo("(1) %myRot               == ", %myRot );
      if(%this.debugMode) echo("(1) %myForwardVector     == ", %myForwardVector );
      if(%this.debugMode) echo("(1) %targetVec           == ", %targetVec );
      if(%this.debugMode) echo("(1) %targetAngle         == ", %targetAngle );
      if(%this.debugMode) echo("(1) %halfAngle           == ", %halfAngle );
              
      if( %this.maxAngle == 360 )
      {
         if( %targetDistance > %this.maxDistance ) 
         {
            %this.target = "";
         }
      }
      else
      {         
         if( (%targetDistance > %this.maxDistance) || 
             (%targetAngle > %halfAngle) )
         { 
            %this.target = "";
         }
      }
   }

   ////
   //   2. If we have no target, try to find one.
   ////
   if( !isObject( %this.target ) )
   {
      %targets = %this.owner.getScenegraph().pickradius( %this.owner.getPosition(), %this.maxDistance, %this.aimGroupsMask );
      
      // Should not need following code but something is wrong with last two args of pickRadius() in TB 1.7.4
      %targets = strreplace( %targets, %this.owner.getID(), "" );
      %targets = strreplace( %targets, "  ", " " );
      %targets = trim( %targets );
      
      %numTargets = getWordCount( %targets );
      
      for(%count = 0; %count < %numTargets; %count++)
      {
         %tmpTarget = getWord( %targets, %count );
         if( !%tmpTarget.ignoreMe )
         {           
            %targetPos      = %tmpTarget.getPosition();     
            %targetVec      = t2dVectorSub( %targetPos , %myPos );
            %targetVec      = t2dVectorNormalise( %targetVec );
         
            %targetAngle    = t2dAngleBetween( %targetVec, %myForwardVector );         
            %targetDistance = t2dVectorDistance( %myPos, %targetPos );
         
            if(%this.debugMode) echo("(2) %targetDistance      == ", %targetDistance );
            if(%this.debugMode) echo("(2) maxDistance          == ", %this.maxDistance );
            if(%this.debugMode) echo("(2) %myRot               == ", %myRot );
            if(%this.debugMode) echo("(2) %myForwardVector     == ", %myForwardVector );
            if(%this.debugMode) echo("(2) %targetVec           == ", %targetVec );
            if(%this.debugMode) echo("(2) %targetAngle         == ", %targetAngle );
            if(%this.debugMode) echo("(2) %halfAngle           == ", %this.maxAngle/2 );
        
            if( %this.maxAngle == 360 )
            {
               if( %targetDistance <= %this.maxDistance ) 
               {
                  %this.target = %tmpTarget;
                  %count = %numTargets + 1;
               }
            }
            else
            {
               if( (%targetDistance <= %this.maxDistance) && 
                (%targetAngle <= %halfAngle) )
               { 
                  if(%this.debugMode) echo("In range...");
                  %this.target = %tmpTarget;
                  %count = %numTargets + 1;
               }
            }
         }
      }
   }
   
   ////
   //   3. Assuming we have a target, aim at it.   
   ////
   if( isObject( %this.target ) )
   {
      %targetPos     = %this.target.getPosition();     
      %targetVec     = t2dVectorSub( %targetPos , %myPos );
      %targetAngle   = vectorToAngle( %targetVec );

      %this.owner.rotateTo( %targetAngle, %this.turnRate, true );
   }
   
   %this.schedule( %this.updateSpeed, aim  );
}
