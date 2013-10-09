if (!isObject(SpaceInvaders))
{
   %behavior = new BehaviorTemplate(SpaceInvaders)
   {
      friendlyName = "Space Invaders";
      behaviorType = "01 - Movement Games (Keyboard, Joysticks, Controllers - only)";
      description  = "Move like player ship in <spush><color:FF0000>Space Invaders<spop>";
   };
  
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);
      
   %behavior.addBehaviorField( "Speed", "Movement Speed", float, 50 );   
   %behavior.addBehaviorField( "Left",  "Move Left",  keybind, "Keyboard A" );
   %behavior.addBehaviorField( "Right", "Move Right", keybind, "Keyboard D" );

   %behavior.addBehaviorField(bindMulti, "Enable Roaming Gamer multi-binding.", bool, true);   
}

function SpaceInvaders::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("SpaceInvaders::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );

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
   // Ex: If you use joystick yaxis for left, use it for right too.

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
   %this.inputY = 0;
   %this.left   = 0;
   %this.right  = 0;
}

function SpaceInvaders::onRemoveFromScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
  
   if(!isObject(moveMap)) return;

   // Note: Do not use a joystick for only one part of a movement pair. 
   // Ex: If you use joystick yaxis for left, use it for right too.

   if( strstr( getWord( %this.Left , 1 ), "axis" ) == -1 )
   {
      // USING JOYSTICK BUTTONS OR KEYBOARD KEYS
      moveMap.call( %this.unbindingMethod,  getWord( %this.Left , 0 ),  getWord( %this.Left , 1 ), "onMoveLeft", %this );
      moveMap.call( %this.unbindingMethod,  getWord( %this.Right , 0 ), getWord( %this.Right , 1 ), "onMoveRight", %this );
   }
   else
   {
      // USING JOYSTICK AXIS
      moveMap.call( %this.unbindingMethod,  getWord( %this.Left , 0 ), getWord( %this.Left , 1 ), "onMoveJoystickLeftRight", %this );
   }
}

function SpaceInvaders::onMoveLeft( %this , %val )
{   
   if(%this.debugMode) echo("SpaceInvaders::onMoveLeft( ", %val , " ) " );
   %this.moveLeft = %val;

   if(!%val && %this.moveRight) %val = 1;
   else %val = -%val; 

   %this.inputX  = %val;

   %this.doMove();
}

function SpaceInvaders::onMoveRight( %this , %val )
{   
   if(%this.debugMode)  echo("SpaceInvaders::onMoveRight( ", %val , " ) " );
   %this.moveRight = %val;

   if(!%val && %this.moveLeft) %val = -1; 

   %this.inputX  = %val;
   
   %this.doMove();
}

function SpaceInvaders::onMoveJoystickLeftRight( %this , %val )
{   
   if(%this.debugMode)  echo("SpaceInvaders::onMoveJoystickLeftRight( ", %val , " ) " );
   if( %val < 0 ) %this.inputX = %val;
   else if (%val > 0) %this.inputX = %val;
   else  %this.inputX = 0;

   %this.doMove();
}

function SpaceInvaders::doMove( %this )
{   
   %this.owner.setLinearVelocity( %this.inputX * %this.Speed, 
                                  -%this.inputY * %this.Speed );
}
