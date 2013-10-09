
if (!isObject(firesMissiles))
{
   %behavior = new BehaviorTemplate(firesMissiles)
   {
      friendlyName = "Fires Missiles";
      behaviorType = "06 - Weapons";
      description  = "This object fires a missile(s) when mouse or key press.";
   };   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);
   
   %behavior.addBehaviorField( "projectile", "Datablock specifying projectile to fire when key is pressed.", "managedDB", "");
   
   %behavior.addBehaviorField( "repeatRate",  "If greater than 0, the turret will fire this many Missiles per-second while the fire button is depressed.", integer, 0 );
   %behavior.addBehaviorField( "maxMissiles",  "Maximum number of missiles alive at once. (-1 == no limit)", integer, -1 );
   
   %behavior.addBehaviorField( "muzzleOffset", "Offset to use for muzzle position", "point2f" , "0.0 -1.0");
   
   %behavior.addBehaviorField( "angleOffset",  "Change firing rotation by this number of degrees.", integer, 0 );
   
   %behavior.addBehaviorField( "fireKey", "Rotate left",  keybind, "Keyboard space" );
   %behavior.addBehaviorField(bindMulti, "Enable Roaming Gamer multi-binding.", bool, true);   
}

function firesMissiles::onAddToScene(%this, %scenegraph) 
{
   if(%this.debugMode) echo("firesMissiles::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   
   if(!%this.enable) return;
   
   if(%this.debugMode) echo( getWord( %this.fireKey , 0 ) );
   if(%this.debugMode) echo(%this.fireKey );

   if(%this.bindMulti)
   {
      // Use the advanced Roaming Gamer multi-binding method
      // Allows multiple methods and objects to be bound to the same input
      %this.bindingMethod = "bindMulti";
      %this.unbindingMethod = "unbindMulti";
   }
   else
   {
      // Use the default object binding method 
      // One object + method call per object
      %this.bindingMethod = "bindObj";
      %this.unbindingMethod = "unbindObj";
   }


   if(getWord( %this.fireKey , 0 ) $= "mouse0")
   {
      %this.owner.setUseMouseEvents(true);
      %this.owner.setMouseLocked(true);
      sceneWindow2D.setUseObjectMouseEvents(1);
   }
   else
   {
      moveMap.call( %this.bindingMethod,  getWord( %this.fireKey , 0 ),  getWord( %this.fireKey , 1 ), "doFire", %this );
   }
   
   %this.isFiring = 0;
}

function firesMissiles::onMouseDown(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;
   %this.doFire( 1 );
}

function firesMissiles::onMouseUp(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;
   %this.doFire( 0 );
}


function firesMissiles::doFire( %this , %val )
{ 
   if(!%this.enable) return;  
   if(%this.debugMode) echo("firesMissiles::doFire( ", %val , " ) %this.isFiring == ", %this.isFiring );
   if(%val > 0)
   {   
      %this.isFiring++;
   }
   else
   {
      %this.isFiring--;
   }
   
   %this.fireProjectile();
}

function firesMissiles::fireProjectile( %this  )
{
   
   // limit rate (if using repeat) and prevent multiple fire inputs from causing re-entrance
   if( isEventPending(%this.lastSchedule) ) return;
   
   if(%this.isFiring == 0) return;

   %this.createProjectile();

   if(%this.repeatRate > 0 )
   {
      %period = ( (1000 / %this.repeatRate ) >= 1) ? 1000 / %this.repeatRate : 1;
      
      %period = mFloatLength( %period, 0 );
      
      %this.lastSchedule = %this.schedule( %period, fireProjectile );
   }
}

function firesMissiles::createProjectile( %this )
{ 
   if(%this.debugMode) echo("firesMissiles::createProjectile( %this.isFiring == ", %this.isFiring , " ) " );
   
   %owner = %this.owner; 
   
   %position = %owner.getWorldPoint(%this.muzzleOffset);
   %rotation = %owner.getRotation();
   
   if(%this.projectile.animationName $= "")
   {
      %bullet = new t2dStaticSprite( )      
      {
         config   = %this.projectile;
         Position = %position;
         Rotation = %rotation + %this.angleOffset;
         scenegraph = %owner.scenegraph;
      };   
   }
   else
   {
      %bullet = new t2dAnimatedSprite( )
      {
         config = %this.projectile;
         Position      = %position;
         Rotation      = %rotation + %this.angleOffset;
         scenegraph    = %owner.scenegraph;
      };   
   }
}

