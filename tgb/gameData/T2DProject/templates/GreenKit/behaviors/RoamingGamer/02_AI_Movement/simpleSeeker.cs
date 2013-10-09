if (!isObject(simpleSeeker))
{
   %behavior = new BehaviorTemplate(simpleSeeker)
   {
      friendlyName = "Simple Seeker";
      behaviorType = "02 - AI Movement";
      description  = "Automatically rotate to face the nearest target and go after it.  Target seeking can be limited by group";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", "bool", true);
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);
   
   %behavior.addBehaviorField( "seekGroups", "Seek objects in these groups.", "bitmask", "0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31");   

   %behavior.addBehaviorField("turnSpeed", "Speed to rotate at.", "float", 90.0);
   %behavior.addBehaviorField("moveSpeed", "Speed to move at.", "float", 25.0);
   
   %behavior.addBehaviorField("seekPeriod", "Time (in milliseconds) between seek scans and course adjustments. (Minimum is 10.)", "integer", 100);      

   %behavior.addBehaviorField("waitForTarget", "If true, this object won't start moving till it finds a target", "bool", false);
}

function simpleSeeker::onAddToScene(%this, %scenegraph) 
{
   if(%this.debugMode) echo("simpleSeeker::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(!%this.enable) return;

   if(%this.seekPeriod < 10 ) %this.seekPeriod = 10;
   
   %this.owner.setMaxLinearVelocity( %this.moveSpeed );
   
   %this.seekGroupsMask = bits(%this.seekGroups);
   
   if(!%this.waitForTarget) 
   {
      %this.owner.setConstantForcePolar(%this.owner.getRotation(),10000,true);
   }

   %this.seek( );
}


function simpleSeeker::seek(%this) 
{
   if(%this.debugMode) echo("simpleSeeker::seek( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(!%this.enable) return;
   
   %myPos = %this.owner.getPosition();

   ////
   //   1. If we have no target, try to find one.
   ////
   if( !isObject( %this.target ) )
   {
      %targets = %this.owner.getScenegraph().pickradius( %myPos, 10000.0, %this.seekGroupsMask );
      
      // Should not need following code but something is wrong with last two args of pickRadius() in TB 1.7.4
      %targets = strreplace( %targets, %this.owner.getID(), "" );
      %targets = strreplace( %targets, "  ", " " );
      %targets = trim( %targets );
      
      %numTargets = getWordCount( %targets );
      
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

