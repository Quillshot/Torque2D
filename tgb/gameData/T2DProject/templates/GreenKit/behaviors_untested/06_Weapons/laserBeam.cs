if (!isObject(laserBeam))
{
   %behavior = new BehaviorTemplate(laserBeam)
   {
      friendlyName = "Laser Beam";
      behaviorType = "06 - Weapons";
      description  = "Make this object act like a laser beam.)";
   };
   

   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", "bool", true);
   
   %behavior.addBehaviorField("beamWidth", "Width of laser beam.", "float", 1.0);
   %behavior.addBehaviorField("maxBeamLength", "Maximum length of beam (when finally extended).", "float", 50.0);
   
   %behavior.addBehaviorField("extendSteps", "Number of steps to take while extending beam. (0 is immediate)", "integer", 10);
   %behavior.addBehaviorField("extendDuration", "Time it takes beam to extend to maximum length. (Ignored if extendSteps is 0)", "integer", 100);

   %behavior.addBehaviorField("beamLife", "How long beam remains (including extend time). (-1 is infinite)", "integer", -1);
}

function laserBeam::onAddToScene(%this, %scenegraph) 
{
   echo("laserBeam::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(!%this.enable) return;
   
   if(%this.extendSteps <= 0)
   {
      %this.extendSteps = 1;
      %this.stepTime = 0;
   }
   else
   {
      %this.stepTime = mFloatLength( %this.extendDuration / %this.extendSteps, 0);

      // Extremely short extend times are treated as instantaneous
      if(%this.stepTime <= 1)
      {
         %this.extendSteps = 1;
         %this.stepTime = 0;
      }
   }
         
   %this.lengthStep = %this.maxBeamLength / %this.extendSteps;

   %this.owner.setWidth( %this.beamWidth );   
   %this.owner.setHeight( 0 );
   
   if(%this.beamLife > 0 ) %this.owner.schedule( %this.beamLife, safeDelete );
   
   %this.extendBeam(%this.extendSteps, %this.stepTime );

   %this.myRot(10);
}


function laserBeam::extendBeam(%this, %stepsRemaining, %stepTime) 
{
   if(!%this.enable) return;

   %curLength = %this.owner.getHeight();
   
   %this.owner.setHeight(%curLength + %this.lengthStep); 
   
   %stepsRemaining--;
   
   if(%stepsRemaining > 0 )  %this.schedule( %stepTime, extendBeam, %stepsRemaining, %stepTime);
}

//EFM hack!!! why is beam re-aligning?
function laserBeam::myRot(%this, %iter) 
{
   %iter--;
   
   if(%iter <= 0) return;
   %owner = %this.owner;
   error("laserBeam Rotation  == ", %owner.getRotation() );
   %this.schedule( 100, myRot, %iter );     
}

