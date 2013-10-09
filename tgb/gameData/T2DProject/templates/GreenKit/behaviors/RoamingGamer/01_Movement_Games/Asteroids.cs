if (!isObject(Asteroids))
{
   %behavior = new BehaviorTemplate(Asteroids)
   {
      friendlyName = "Asteroids";
      behaviorType = "01 - Movement Games (Keyboard, Joysticks, Controllers - only)";
      description  = "Move like player ship in <spush><color:FF0000>Asteroids<spop>";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);   
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);

   %behavior.addBehaviorField( "Thrust", "Thrusting power.", float, 100 );  
   %behavior.addBehaviorField( "RotationRate", "Rotation speed.", float, 135 );   
    
   %behavior.addBehaviorField( "MaxSpeed", "Maximum speed.", float, 35 );   
   %behavior.addBehaviorField( "Damping", "Reduce speed by this percentage each second.", float, 0.3 );   
   
   %behavior.addBehaviorField( "Up",    "Move Up",    keybind, "Keyboard W" );
   %behavior.addBehaviorField( "Left",  "Move Left",  keybind, "Keyboard A" );
   %behavior.addBehaviorField( "Right", "Move Right", keybind, "Keyboard D" );
   
   %behavior.addBehaviorField( "EnableStop", "Allow instant stops.", bool, false);
   %behavior.addBehaviorField( "Stop",  "Stop moving.",  keybind, "Keyboard S" );
   
   %behavior.addBehaviorField(bindMulti, "Enable Roaming Gamer multi-binding.", bool, true);   
   
}

function Asteroids::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("Asteroids::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );

   %this.owner.setMaxLinearVelocity(%this.MaxSpeed);
   %this.owner.setDamping(%this.Damping);

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

   // Note: Do not use a joystick for only one part of a movement pair. 
   // Ex: If you use joystick yaxis for up, use it for down too.

   if( strstr( getWord( %this.Up , 1 ), "axis" ) == -1 )
   {
      // USING JOYSTICK BUTTONS OR KEYBOARD KEYS
      moveMap.call( %this.bindingMethod, getWord( %this.Up , 0 ),    getWord( %this.Up , 1 ), "onThrust", %this );
   }
   else
   {
      // USING JOYSTICK AXIS
      moveMap.call( %this.bindingMethod, getWord( %this.Up , 0 ), getWord( %this.Up , 1 ), "onJoystickThrust", %this );
   }

   if(%this.EnableStop)
   {
      if( strstr( getWord( %this.Stop , 1 ), "axis" ) == -1 )
      {
         // USING JOYSTICK BUTTONS OR KEYBOARD KEYS
         moveMap.call( %this.bindingMethod, getWord( %this.Stop , 0 ),  getWord( %this.Stop , 1 ), "onStop", %this );
      }
      else
      {
         // USING JOYSTICK AXIS
         moveMap.call( %this.bindingMethod, getWord( %this.Stop , 0 ), getWord( %this.Stop , 1 ), "onJoystickStop", %this );
      }
   }

   if( strstr( getWord( %this.Left , 1 ), "axis" ) == -1 )
   {
      // USING JOYSTICK BUTTONS OR KEYBOARD KEYS
      moveMap.call( %this.bindingMethod, getWord( %this.Left , 0 ),  getWord( %this.Left , 1 ),  "onMoveLeft", %this );
      moveMap.call( %this.bindingMethod, getWord( %this.Right , 0 ), getWord( %this.Right , 1 ), "onMoveRight", %this );
   }
   else
   {
      // USING JOYSTICK AXIS
      moveMap.call( %this.bindingMethod, getWord( %this.Left , 0 ), getWord( %this.Left , 1 ), "onMoveJoystickLeftRight", %this );
   }
   
   %this.inputX   = 0;
   %this.inputY   = 0;
   %this.left     = 0;
   %this.right    = 0;
   %this.stopAll  = 0;
}

function Asteroids::onRemoveFromScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
  
   if(!isObject(moveMap)) return;
   
   // Note: Do not use a joystick for only one part of a movement pair. 
   // Ex: If you use joystick yaxis for up, use it for down too.

   if( strstr( getWord( %this.Up , 1 ), "axis" ) == -1 )
   {
      // USING JOYSTICK BUTTONS OR KEYBOARD KEYS
      moveMap.call( %this.unbindingMethod, getWord( %this.Up , 0 ),    getWord( %this.Up , 1 ), "onThrust", %this );
   }
   else
   {
      // USING JOYSTICK AXIS
      moveMap.call( %this.unbindingMethod, getWord( %this.Up , 0 ), getWord( %this.Up , 1 ), "onJoystickThrust", %this );
   }

   if(%this.EnableStop)
   {
      if( strstr( getWord( %this.Stop , 1 ), "axis" ) == -1 )
      {
         // USING JOYSTICK BUTTONS OR KEYBOARD KEYS
         moveMap.call( %this.unbindingMethod, getWord( %this.Stop , 0 ),  getWord( %this.Stop , 1 ), "onStop", %this );
      }
      else
      {
         // USING JOYSTICK AXIS
         moveMap.call( %this.unbindingMethod, getWord( %this.Stop , 0 ), getWord( %this.Stop , 1 ), "onJoystickStop", %this );
      }
   }

   if( strstr( getWord( %this.Left , 1 ), "axis" ) == -1 )
   {
      // USING JOYSTICK BUTTONS OR KEYBOARD KEYS
      moveMap.call( %this.unbindingMethod, getWord( %this.Left , 0 ),  getWord( %this.Left , 1 ),  "onMoveLeft", %this );
      moveMap.call( %this.unbindingMethod, getWord( %this.Right , 0 ), getWord( %this.Right , 1 ), "onMoveRight", %this );
   }
   else
   {
      // USING JOYSTICK AXIS
      moveMap.call( %this.unbindingMethod, getWord( %this.Left , 0 ), getWord( %this.Left , 1 ), "onMoveJoystickLeftRight", %this );
   }
}

function Asteroids::onThrust( %this , %val )
{   
   echo("ForwardThrust::onThrust( ", %val , " ) " );
   %this.inputY  = %val;
   %this.doMove();
}

function Asteroids::onStop( %this , %val )
{   
   echo("ForwardThrust::onThrust( ", %val , " ) " );
   %this.stopAll  = %val;
   %this.doMove();
}


function Asteroids::onJoystickThrust( %this , %val )
{   
   echo("Asteroids::onJoystickThrust( ", %val , " ) " );
   if( %val < 0 ) %this.inputY = -%val; 
   else %this.inputY = 0;
   
   %this.doMove();
}

function Asteroids::onJoystickStop( %this , %val )
{   
   echo("Asteroids::onJoystickStop( ", %val , " ) " );
   if( %val > 0 ) %this.stopAll = 1; 
   else %this.stopAll = 0;
   
   %this.doMove();
}

function Asteroids::onMoveLeft( %this , %val )
{   
   echo("Asteroids::onMoveLeft( ", %val , " ) " );
   %this.moveLeft = %val;

   if(!%val && %this.moveRight) %val = 1;
   else %val = -%val; 

   %this.inputX  = %val;

   %this.doMove();
}

function Asteroids::onMoveRight( %this , %val )
{   
   echo("Asteroids::onMoveRight( ", %val , " ) " );
   %this.moveRight = %val;

   if(!%val && %this.moveLeft) %val = -1; 

   %this.inputX  = %val;
   
   %this.doMove();
}

function Asteroids::onMoveJoystickLeftRight( %this , %val )
{   
   echo("Asteroids::onMoveJoystickLeftRight( ", %val , " ) " );
   if( %val < 0 ) %this.inputX = %val;
   else if (%val > 0) %this.inputX = %val;
   else  %this.inputX = 0;

   %this.doMove();
}

function Asteroids::doMove( %this )
{   
   if(%this.debugMode) echo("Asteroids::doMove( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(%this.stopAll)
   {
      %this.owner.setAtRest();
   }
   else
   {
      %thrustMagnitude = %this.inputY * %this.Thrust;
      %this.owner.setAngularVelocity( %this.inputX * %this.RotationRate );
      %this.owner.setConstantForcePolar( %this.owner.getRotation(), %thrustMagnitude , true );      
   } 
   
    
   if( %this.inputX  || 
       %this.inputY  ||
       %this.left    ||
       %this.right   ||
       %this.stopAll) 
       {
          %this.schedule(100, doMove);
       }
}
