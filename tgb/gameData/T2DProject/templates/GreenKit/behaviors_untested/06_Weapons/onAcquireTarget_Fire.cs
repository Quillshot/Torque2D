if (!isObject(onAcquireTarget_Fire))
{
   %behavior = new BehaviorTemplate(onAcquireTarget_Fire)
   {
      friendlyName = "onAcquireTarget() -> Fire";
      behaviorType = "06 - Weapons";
      description  = "Automatically seek targets and fire when one is found.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", "bool", true);
   
   %behavior.addBehaviorField( "seekGroups", "Seek objects in these groups.", "bitmask", "0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31");   
   %behavior.addBehaviorField("seekDistance", "Maximum distance at which targets can be detected.", "float", 100.0);   
   %behavior.addBehaviorField("seekFOV", "Maximum Field Of View (FOV) in which targets can be detected. [0,360]", "float", 90.0);
   %behavior.addBehaviorField("seekPeriod", "Time (in milliseconds) between seek scans and course adjustments. (Minimum is 10.)", "integer", 100);      
   
   %behavior.addBehaviorField("continuousSeek", "If true, this object must re-acquire its target every seek cycle.", "bool", true);   
}

function onAcquireTarget_Fire::onAddToScene(%this, %scenegraph) 
{
   //echo("onAcquireTarget_Fire::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(!%this.enable) return;
   
   %this.hadTarget = false;

   if(%this.seekPeriod < 10 ) %this.seekPeriod = 10;   
   
   if(%this.seekFOV > 360) %this.seekFOV = 360;
   if(%this.seekFOV < 0) %this.seekFOV = 0;   
   
   %this.maxSeekAngle = %this.seekFOV / 2;
      
   %this.seekGroupsMask = bits(%this.seekGroups);
   
   %this.seek( );
}

function onAcquireTarget_Fire::seek(%this) 
{
   //echo("onAcquireTarget_Fire::seek( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(!%this.enable) return;
   
   %myPos = %this.owner.getPosition();
   
   if( %this.hadTarget && (%this.continuousSeek || !isObject( %this.target ) ) )
   {
      %this.target = 0;
   }

   ////
   //   1. If we have no target, try to find one.
   ////
   if( !isObject( %this.target )  )
   {
      %this.hadTarget = false;
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
      %this.hadTarget = true;
      %targetPos     = %this.target.getPosition();     
      %targetVec     = t2dVectorSub( %targetPos , %myPos );
      %targetAngle   = vectorToAngle( %targetVec );

      %this.broadcastMethod( onFire, 1 );
      %this.schedule(0,broadcastMethod, onFire, 0 );
   }   
   
   
   %this.schedule( %this.seekPeriod, seek  );
}

function onAcquireTarget_Fire::targetinFOV( %this , %target ) 
{
   %owner         = %this.owner;
   %myPos         = %owner.getPosition();
   %targetPos     = %target.getPosition();     
   %targetVec     = t2dVectorSub( %targetPos , %myPos );
   %myRotVec      = angleToVector( %owner.getRotation() );
   %angleBetween  = t2dAngleBetween( %targetVec , %myRotVec );
         
   //error("         targetID  " , %target );
   //error(" to target vector  " , %targetVec );
   //error(" to target dot  " , t2dVectorDot( %targetVec, %myRotVec ) );   
   //error("     my rot vector " , %myRotVec );
   //error("     angle between " , %angleBetween );
   //error("%this.maxSeekAngle " , %this.maxSeekAngle );

   return( %angleBetween <= %this.maxSeekAngle );
}


