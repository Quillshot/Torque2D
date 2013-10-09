
if (!isObject(laserTurret))
{
   %behavior = new BehaviorTemplate(laserTurret)
   {
      friendlyName = "Laser Turret";
      behaviorType = "06 - Weapons";
      description  = "This turret fires (animated or static) lasers.";
   };   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   
   %behavior.addBehaviorField( "beam", "Datablock specifying beam to fire when key is pressed.", "managedDB", "");
   
   %behavior.addBehaviorField( "repeatRate",  "If greater than 0, the turret will fire this many beams per-second while the fire button is depressed.", integer, 0 );
   %behavior.addBehaviorField( "muzzleOffset", "Offset to use for muzzle position", "point2f" , "0.0 -1.0");
   
   %behavior.addBehaviorField( "mountTrackRotation",  "If true, this turret will track the rotation of any object it is mounted to.", bool, false );   
}



function laserTurret::onAddToScene(%this, %scenegraph) 
{
   //echo("laserTurret::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   
   if(!%this.enable) return;
   
   %this.owner.MountTrackRotation = %this.mountTrackRotation;
   
   %this.isFiring = 0;
}

function laserTurret::onFire( %this , %val )
{ 
   if(!%this.enable) return;  
   //error("laserTurret::onFireKey( ", %val , " ) " );

   if(%val > 0)
   {   
      %this.isFiring++;
   }
   else
   {
      %this.isFiring--;
   }
   error(%this.isFiring);
   
   // limit rate (if using repeat) and prevent multiple fire inputs from causing re-entrance
   if( isEventPending(%this.lastSchedule) ) return;

   if(%val) %this.doFire();
}

function laserTurret::doFire( %this )
{ 
   error("laserTurret::doFire( %this.isFiring == ", %this.isFiring , " ) " );
   
   if(!%this.isFiring) return;

   %this.createLaser();

   if(%this.repeatRate > 0 )
   {
      %period = ( (1000 / %this.repeatRate ) >= 1) ? 1000 / %this.repeatRate : 1;
      
      %period = mFloatLength( %period, 0 );
      
      %this.lastSchedule = %this.schedule( %period, doFire );
   }
}

function laserTurret::createLaser( %this )
{ 
   error("laserTurret::createLaser( %this.isFiring == ", %this.isFiring , " ) " );
   
   %owner = %this.owner; 
   
   %position = %owner.getWorldPoint(%this.muzzleOffset);
   %rotation = %owner.getRotation();
   
   error("Rotation 1 == ", %rotation );
   
   if(%this.mountTrackRotation && isObject(%owner.getMountedParent()) )
   {
      %rotation = %owner.getMountedParent().getRotation();
   }
   
   error("Rotation 2 == ", %rotation );

   
   if(%this.beam.animationName $= "")
   {
      %beam = new t2dStaticSprite( )      
      {
         config   = %this.beam;
         //Position = %position;
         //Rotation = %rotation;
         scenegraph = %owner.scenegraph;
         //MountTrackRotation = 0;
      };
      
      //%beam.setRotation( %rotation );   
      %beam.setVisible( 0 );   
      %beam.setPosition( %position );   
   }
   else
   {
      %beam = new t2dAnimatedSprite( )
      {
         config = %this.beam;
         Position      = %position;
         //Rotation      = %rotation;
         scenegraph    = %owner.scenegraph;
         //MountTrackRotation = 0;
      };   
   }
   
   %beam.mount(%owner,
         %this.muzzleOffset, // offset
         0,     // force
         true, //,  // track rotation
         true, // send to mount 
         true, // owned by mount
         false); // inherit Attributes
         
   // EFM - mounting is causing a visual artifact I have not yet resolved.  It seems that the 
   // beam renders at 0-degrees of rotation then adjusts on the next cycle. i.e. Mounting track rotation
   // lags for 1 cycle;
   %beam.schedule( 50, setVisible, 1 );
                 
   error("Rotation 3 == ", %beam.getRotation() );
                 
}
