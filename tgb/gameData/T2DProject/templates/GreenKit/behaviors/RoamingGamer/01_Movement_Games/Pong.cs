if (!isObject(Pong))
{
   %behavior = new BehaviorTemplate(Pong)
   {
      friendlyName = "Pong";
      behaviorType = "01 - Movement Games (Keyboard, Joysticks, Controllers - only)";
      description  = "Move like player paddle in <spush><color:FF0000>Pong<spop>";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);   
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);
      
   %behavior.addBehaviorField( "Speed", "Movement Speed", float, 50 );   
   %behavior.addBehaviorField( "Up",    "Move Up",    keybind, "Keyboard W" );
   %behavior.addBehaviorField( "Down",  "Move Down",  keybind, "Keyboard S" );
   %behavior.addBehaviorField(bindMulti, "Enable Roaming Gamer multi-binding.", bool, true); 
}

function Pong::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("Pong::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );


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
      moveMap.call( %this.bindingMethod,  getWord( %this.Up , 0 ),    getWord( %this.Up , 1 ), "onMoveUp", %this );
      moveMap.call( %this.bindingMethod,  getWord( %this.Down , 0 ),  getWord( %this.Down , 1 ), "onMoveDown", %this );
   }
   else
   {
      // USING JOYSTICK AXIS
      moveMap.call( %this.bindingMethod,  getWord( %this.Up , 0 ), getWord( %this.Up , 1 ), "onMoveJoystickUpDown", %this );
   }

   %this.inputX = 0;
   %this.inputY = 0;
   %this.up     = 0;
   %this.down   = 0;
}

function Pong::onRemoveFromScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
  
   if(!isObject(moveMap)) return;

   // Note: Do not use a joystick for only one part of a movement pair. 
   // Ex: If you use joystick yaxis for up, use it for down too.

   if( strstr( getWord( %this.Up , 1 ), "axis" ) == -1 )
   {
      // USING JOYSTICK BUTTONS OR KEYBOARD KEYS
      moveMap.call( %this.unbindingMethod,  getWord( %this.Up , 0 ),    getWord( %this.Up , 1 ),   "onMoveUp", %this );
      moveMap.call( %this.unbindingMethod,  getWord( %this.Down , 0 ),  getWord( %this.Down , 1 ), "onMoveDown", %this );
   }
   else
   {
      // USING JOYSTICK AXIS
      moveMap.call( %this.unbindingMethod,  getWord( %this.Up , 0 ), getWord( %this.Up , 1 ), "onMoveJoystickUpDown", %this );
   }
}


function Pong::onMoveUp( %this , %val )
{   
   if(%this.debugMode) echo("Pong::onMoveUp( ", %val , " ) " );
   %this.moveUp = %val;

   if(!%val && %this.moveDown) %val = -1; 

   %this.inputY  = %val;

   %this.doMove();
}

function Pong::onMoveDown( %this , %val )
{   
   if(%this.debugMode) echo("Pong::onMoveDown( ", %val , " ) " );
   %this.moveDown = %val;

   if(!%val && %this.moveUp) %val = 1;
   else %val = -%val; 

   %this.inputY  = %val;
   
   %this.doMove();
}

function Pong::onMoveJoystickUpDown( %this , %val )
{   
   if(%this.debugMode) echo("Pong::onMoveJoystickUpDown( ", %val , " ) " );
   if( %val < 0 ) %this.inputY = -%val;
   else if (%val > 0) %this.inputY = -%val;
   else %this.inputY = 0;
   
   %this.doMove();
}

function Pong::doMove( %this )
{   
   %this.owner.setLinearVelocity( %this.inputX * %this.Speed, 
                                  -%this.inputY * %this.Speed );
}
