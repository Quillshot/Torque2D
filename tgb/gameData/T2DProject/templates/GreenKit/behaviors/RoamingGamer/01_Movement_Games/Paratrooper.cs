if (!isObject(Paratrooper))
{
   %behavior = new BehaviorTemplate(Paratrooper)
   {
      friendlyName = "Paratrooper";
      behaviorType = "01 - Movement Games (Keyboard, Joysticks, Controllers - only)";
      description  = "Move like player turret in <spush><color:FF0000>Paratroopers<spop>";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);   
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);
   
   %behavior.addBehaviorField( "rotateRate", "Rotation rate in degrees.", float, 90 );   

   %behavior.addBehaviorField( "Left",  "Move Left",  keybind, "Keyboard A" );
   %behavior.addBehaviorField( "Right", "Move Right", keybind, "Keyboard D" );
   %behavior.addBehaviorField(bindMulti, "Enable Roaming Gamer multi-binding.", bool, true);   
   
   %behavior.addBehaviorField( "minAngle", "Minimum counterclockwise rotation angle.", float, -85 );   
   %behavior.addBehaviorField( "maxAngle", "Maximum clockwise rotation angle.", float, 85 );   
   
}

function Paratrooper::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("Paratrooper::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );

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

   if( strstr( getWord( %this.Left , 1 ), "axis" ) == -1 )
   {
      // USING JOYSTICK BUTTONS OR KEYBOARD KEYS
      moveMap.call( %this.bindingMethod,  getWord( %this.Left , 0 ),  getWord( %this.Left , 1 ),  "onMoveLeft", %this );
      moveMap.call( %this.bindingMethod,  getWord( %this.Right , 0 ), getWord( %this.Right , 1 ), "onMoveRight", %this );
   }
   else
   {
      // USING JOYSTICK AXIS
      moveMap.call( %this.bindingMethod,  getWord( %this.Left , 0 ), getWord( %this.Left , 1 ), "onMoveJoystickLeftRight", %this );
   }
  
   %this.inputX = 0;
   %this.left   = 0;
   %this.right  = 0;
}

function Paratrooper::onRemoveFromScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
  
   if(!isObject(moveMap)) return;

   // Note: Do not use a joystick for only one part of a movement pair. 
   // Ex: If you use joystick yaxis for up, use it for down too.

   if( strstr( getWord( %this.Left , 1 ), "axis" ) == -1 )
   {
      // USING JOYSTICK BUTTONS OR KEYBOARD KEYS
      moveMap.call( %this.unbindingMethod,  getWord( %this.Left , 0 ),  getWord( %this.Left , 1 ),  "onMoveLeft", %this );
      moveMap.call( %this.unbindingMethod,  getWord( %this.Right , 0 ), getWord( %this.Right , 1 ), "onMoveRight", %this );
   }
   else
   {
      // USING JOYSTICK AXIS
      moveMap.call( %this.unbindingMethod,  getWord( %this.Left , 0 ), getWord( %this.Left , 1 ), "onMoveJoystickLeftRight", %this );
   }
}

function Paratrooper::onMoveLeft( %this , %val )
{   
   if(%this.debugMode) echo("Paratrooper::onMoveLeft( ", %val , " ) " );
   %this.moveLeft = %val;

   if(!%val && %this.moveRight) %val = 1;
   else %val = -%val; 

   %this.inputX  = %val;

   %this.doMove();
}

function Paratrooper::onMoveRight( %this , %val )
{   
   if(%this.debugMode) echo("Paratrooper::onMoveRight( ", %val , " ) " );
   %this.moveRight = %val;

   if(!%val && %this.moveLeft) %val = -1; 

   %this.inputX  = %val;
   
   %this.doMove();
}

function Paratrooper::onMoveJoystickLeftRight( %this , %val )
{   
   if(%this.debugMode) echo("Paratrooper::onMoveJoystickLeftRight( ", %val , " ) " );
   if( %val < 0 ) %this.inputX = %val;
   else if (%val > 0) %this.inputX = %val;
   else  %this.inputX = 0;

   %this.doMove();
}

function Paratrooper::doMove( %this )
{   
   // if using limited-rotation, rotate to the min or max angle
   if( %this.inputX < 0 ) 
   {
      %this.owner.rotateTo( %this.minAngle , %this.rotateRate, true  ); 
   }
   else if ( %this.inputX > 0 ) 
   {
      %this.owner.rotateTo( %this.maxAngle , %this.rotateRate, true  ); 
   } 
   else
   {
      %this.owner.setAngularVelocity( 0 );
   }
}
