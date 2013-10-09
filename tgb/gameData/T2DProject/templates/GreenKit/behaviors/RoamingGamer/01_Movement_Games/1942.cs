if (!isObject(game1942))
{
   %behavior = new BehaviorTemplate(game1942)
   {
      friendlyName = "1942";
      behaviorType = "01 - Movement Games (Keyboard, Joysticks, Controllers - only)";
      description  = "Move like player plane in <spush><color:FF0000>1942<spop>";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);   
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);
   
   %behavior.addBehaviorField( "Speed", "Movement Speed", float, 50 );   
   %behavior.addBehaviorField( "Up",    "Move Up",    keybind, "Keyboard W" );
   %behavior.addBehaviorField( "Down",  "Move Down",  keybind, "Keyboard S" );
   %behavior.addBehaviorField( "Left",  "Move Left",  keybind, "Keyboard A" );
   %behavior.addBehaviorField( "Right", "Move Right", keybind, "Keyboard D" );
   %behavior.addBehaviorField(bindMulti, "Enable Roaming Gamer multi-binding.", bool, true);   
}

function game1942::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("game1942::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );

   // Note: Do not use a joystick for only one part of a movement pair. 
   // Ex: If you use joystick yaxis for up, use it for down too.
   
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

   if( strstr( getWord( %this.Up , 1 ), "axis" ) == -1 )
   {
      // USING JOYSTICK BUTTONS OR KEYBOARD KEYS
      moveMap.call( %this.bindingMethod,  getWord( %this.Up , 0 ),    getWord( %this.Up , 1 ),   "onMoveUp", %this );
      moveMap.call( %this.bindingMethod,  getWord( %this.Down , 0 ),  getWord( %this.Down , 1 ), "onMoveDown", %this );
   }
   else
   {
      // USING JOYSTICK AXIS
      moveMap.call( %this.bindingMethod,  getWord( %this.Up , 0 ), getWord( %this.Up , 1 ), "onMoveJoystickUpDown", %this );
   }

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
   %this.moveUp     = 0;
   %this.moveDown   = 0;
   %this.moveLeft   = 0;
   %this.moveRight  = 0;
}

function game1942::onRemoveFromScene(%this, %scenegraph) 
{
   echo("game1942::onRemoveFromScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );

   if(!%this.enable) return;
  
   if(!isObject(moveMap)) return;

   // Note: Do not use a joystick for only one part of a movement pair. 
   // Ex: If you use joystick yaxis for up, use it for down too.

   if( strstr( getWord( %this.Up , 1 ), "axis" ) == -1 )
   {
      // USING JOYSTICK BUTTONS OR KEYBOARD KEYS
      moveMap.call( %this.unbindingMethod,  getWord( %this.Up , 0 ),    getWord( %this.Up , 1 ),    "onMoveUp", %this );
      moveMap.call( %this.unbindingMethod, getWord( %this.Down , 0 ),  getWord( %this.Down , 1 ),  "onMoveDown", %this );
   }
   else
   {
      // USING JOYSTICK AXIS
      moveMap.call( %this.unbindingMethod, getWord( %this.Up , 0 ), getWord( %this.Up , 1 ), "onMoveJoystickUpDown", %this );
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



function game1942::onMoveUp( %this , %val )
{   
   if(%this.debugMode) echo("game1942::onMoveUp( ", %val , " ) " );
   %this.moveUp = %val;

   if(!%val && %this.moveDown) %val = -1; 

   %this.inputY  = %val;

   %this.doMove();
}

function game1942::onMoveDown( %this , %val )
{   
   if(%this.debugMode) echo("game1942::onMoveDown( ", %val , " ) " );
   %this.moveDown = %val;

   if(!%val && %this.moveUp) %val = 1;
   else %val = -%val; 

   %this.inputY  = %val;
   
   %this.doMove();
}


function game1942::onMoveJoystickUpDown( %this , %val )
{   
   if(%this.debugMode) echo("game1942::onMoveJoystickUpDown( ", %val , " ) " );
   if( %val < 0 ) %this.inputY = -%val;
   else if (%val > 0) %this.inputY = -%val;
   else %this.inputY = 0;
   
   %this.doMove();
}

function game1942::onMoveLeft( %this , %val )
{   
   if(%this.debugMode) echo("game1942::onMoveLeft( ", %val , " ) " );
   %this.moveLeft = %val;

   if(!%val && %this.moveRight) %val = 1;
   else %val = -%val; 

   %this.inputX  = %val;

   %this.doMove();
}

function game1942::onMoveRight( %this , %val )
{   
   if(%this.debugMode) echo("game1942::onMoveRight( ", %val , " ) " );
   %this.moveRight = %val;

   if(!%val && %this.moveLeft) %val = -1; 

   %this.inputX  = %val;
   
   %this.doMove();
}

function game1942::onMoveJoystickLeftRight( %this , %val )
{   
   if(%this.debugMode) echo("game1942::onMoveJoystickLeftRight( ", %val , " ) " );
   if( %val < 0 ) %this.inputX = %val;
   else if (%val > 0) %this.inputX = %val;
   else  %this.inputX = 0;

   %this.doMove();
}

function game1942::doMove( %this )
{   
   %this.owner.setLinearVelocity( %this.inputX * %this.Speed, 
                                  -%this.inputY * %this.Speed );
}

