if (!isObject(limitedSeeker))
{
   %behavior = new BehaviorTemplate(limitedSeeker)
   {
      friendlyName = "Limited Seeker";
      behaviorType = "02 - AI Movement";
      description  = "Automatically rotate to face the nearest target and go after it." SPC
                     "Target seeking can be limited by group, distance, and angle.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", "bool", true);
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);
   
   %behavior.addBehaviorField( "seekGroups", "Seek objects in these groups.", "bitmask", "0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31");   
   %behavior.addBehaviorField("seekDistance", "Maximum distance at which targets can be detected.", "float", 100.0);   
   %behavior.addBehaviorField("seekFOV", "Maximum Field Of View (FOV) in which targets can be detected. [0,360]", "float", 90.0);

   %behavior.addBehaviorField("turnSpeed", "Speed to rotate at.", "float", 90.0);
   %behavior.addBehaviorField("moveSpeed", "Speed to move at.", "float", 25.0);      
   
   %behavior.addBehaviorField("seekPeriod", "Time (in milliseconds) between seek scans and course adjustments. (Minimum is 10.)", "integer", 100);      
   
   %behavior.addBehaviorField("waitForTarget", "If true, this object won't start moving till it finds a target", "bool", false);

   
}

function limitedSeeker::onAddToScene(%this, %scenegraph) 
{
   if(%this.debugMode) echo("limitedSeeker::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(!%this.enable) return;

   if(%this.seekPeriod < 10 ) %this.seekPeriod = 10;   
   
   if(%this.seekFOV > 360) %this.seekFOV = 360;
   if(%this.seekFOV < 0) %this.seekFOV = 0;   
   
   %this.maxSeekAngle = %this.seekFOV / 2;
   
   %this.owner.setMaxLinearVelocity( %this.moveSpeed );
   
   %this.seekGroupsMask = bits(%this.seekGroups);
   
   if(!%this.waitForTarget) 
   {
      %this.owner.setConstantForcePolar(%this.owner.getRotation(),10000,true);
   }

   %this.seek( );
}


function limitedSeeker::seek(%this) 
{
   if(%this.debugMode) echo("limitedSeeker::seek( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(!%this.enable) return;
   
   %myPos = %this.owner.getPosition();

   ////
   //   1. If we have no target, try to find one.
   ////
   if( !isObject( %this.target ) )
   {
      %targets = %this.owner.getScenegraph().pickradius( %myPos, %this.seekDistance, %this.seekGroupsMask );
      
      //EFM - Should not need following code but something is wrong with last two args of pickRadius() in TB 1.7.4
      %targets = strreplace( %targets, %this.owner.getID(), "" );
      %targets = strreplace( %targets, "  ", " " );
      %targets = trim( %targets );
    
      ////
      //   2. Remove any 'found' targets if they are outside of our field of vie
      ////   
      %targetCount = getWordCount( %targets );
      
      for(%count=0; %count < %targetCount; %count++)
      {
         %word = getWord( %targets, %count );
         
         if(%this.targetinFOV( %word ))
         {
            %tmpTargets = %tmpTargets SPC %word;
         }
      }
      
      %targets = trim( %tmptargets );
      
      // Now randomly select a target if any are left      
      %targets = randomizeWords( %targets );
      %this.target = getWord( %targets, 0 );
   }
      
   ////
   //   2. Assuming we have a target, aim at it.   
   ////
   if( isObject( %this.target ) )
   {
      %targetPos     = %this.target.getPosition();     
      %targetVec     = t2dVectorSub( %targetPos , %myPos );
      %targetAngle   = vectorToAngle( %targetVec );

      //%this.owner.setRotation(%targetAngle);
      %this.owner.rotateTo( %targetAngle, %this.turnSpeed, true );
      %this.owner.setConstantForcePolar(%this.owner.getRotation(),10000,true);      
   }   
   %this.schedule( %this.seekPeriod, seek  );
}

function limitedSeeker::targetinFOV( %this , %target ) 
{
   %owner         = %this.owner;
   %myPos         = %owner.getPosition();
   %targetPos     = %target.getPosition();     
   %targetVec     = t2dVectorSub( %targetPos , %myPos );
   %myRotVec      = angleToVector( %owner.getRotation() );
   %angleBetween  = t2dAngleBetween( %targetVec , %myRotVec );
         
   if(%this.debugMode) echo("         targetID  " , %target );
   if(%this.debugMode) echo(" to target vector  " , %targetVec );
   if(%this.debugMode) echo(" to target dot  " , t2dVectorDot( %targetVec, %myRotVec ) );   
   if(%this.debugMode) echo("     my rot vector " , %myRotVec );
   if(%this.debugMode) echo("     angle between " , %angleBetween );
   if(%this.debugMode) echo("%this.maxSeekAngle " , %this.maxSeekAngle );

   return( %angleBetween <= %this.maxSeekAngle );
}


