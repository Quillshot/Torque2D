
if (!isObject(projectileTurret))
{
   %behavior = new BehaviorTemplate(projectileTurret)
   {
      friendlyName = "Projectile Turret";
      behaviorType = "06 - Weapons";
      description  = "This turret fires (animated or static) projectiles.";
   };   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   
   %behavior.addBehaviorField( "projectile", "Datablock specifying projectile to fire when key is pressed.", "managedDB", "");
   
   %behavior.addBehaviorField( "repeatRate",  "If greater than 0, the turret will fire this many projectiles per-second while the fire button is depressed.", integer, 0 );
   %behavior.addBehaviorField( "muzzleOffset", "Offset to use for muzzle position", "point2f" , "0.0 -1.0");
   
   %behavior.addBehaviorField( "mountTrackRotation",  "If true, this turret will track the rotation of any object it is mounted to.", bool, false );   
}

function projectileTurret::onAddToScene(%this, %scenegraph) 
{
   //echo("projectileTurret::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   
   if(!%this.enable) return;
   
   %this.owner.MountTrackRotation = %this.mountTrackRotation;
   
   %this.isFiring = 0;
}

function projectileTurret::onFire( %this , %val )
{ 
   if(!%this.enable) return;  
   //error("projectileTurret::onFireKey( ", %val , " ) " );

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

function projectileTurret::doFire( %this )
{ 
   error("projectileTurret::doFire( %this.isFiring == ", %this.isFiring , " ) " );
   
   if(!%this.isFiring) return;

   %this.createProjectile();

   if(%this.repeatRate > 0 )
   {
      %period = ( (1000 / %this.repeatRate ) >= 1) ? 1000 / %this.repeatRate : 1;
      
      %period = mFloatLength( %period, 0 );
      
      %this.lastSchedule = %this.schedule( %period, doFire );
   }
}

function projectileTurret::createProjectile( %this )
{ 
   error("projectileTurret::createProjectile( %this.isFiring == ", %this.isFiring , " ) " );
   
   %owner = %this.owner; 
   
   %position = %owner.getWorldPoint(%this.muzzleOffset);
   %rotation = %owner.getRotation();
   
   if(%this.projectile.animationName $= "")
   {
      %bullet = new t2dStaticSprite( )      
      {
         config   = %this.projectile;
         Position = %position;
         Rotation = %rotation;
         scenegraph = %owner.scenegraph;
      };   
   }
   else
   {
      %bullet = new t2dAnimatedSprite( )
      {
         config = %this.projectile;
         Position      = %position;
         Rotation      = %rotation;
         scenegraph    = %owner.scenegraph;
      };   
   }
}
