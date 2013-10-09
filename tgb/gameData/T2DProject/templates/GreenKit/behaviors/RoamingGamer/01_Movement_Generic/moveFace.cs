echo("\n--------- Loading RG Instant Face Movement Model Behavior ---------");

//
// Create Behavior Template
//
if (!isObject(RG_InstantFace))
{
   %behavior = new BehaviorTemplate(RG_InstantFace)
   {
      friendlyName = "Instant Face";
      behaviorType = "01 - Movement Generic (Keyboard, Joysticks, Controllers - only)";
      description  = "Instantly face up/down/left/right. (Individual directions may be disabled.)";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);
   
   %behavior.addBehaviorField( "Up",    "Move Up",    keybind, "Keyboard W" );
   %behavior.addBehaviorField( "Down",  "Move Down",  keybind, "Keyboard S" );
   %behavior.addBehaviorField( "Left",  "Move Left",  keybind, "Keyboard A" );
   %behavior.addBehaviorField( "Right", "Move Right", keybind, "Keyboard D" );
   %behavior.addBehaviorField(bindMulti, "Enable Roaming Gamer multi-binding.", bool, true);   
   
   %behavior.addBehaviorField( "Enable_Up",  "Enable Move Up", bool, true );
   %behavior.addBehaviorField( "Enable_Down",  "Enable Move Down", bool, true );
   %behavior.addBehaviorField( "Enable_Left",  "Enable Move Left", bool, true );
   %behavior.addBehaviorField( "Enable_Right",  "Enable Move Right", bool, true );
   
   %behavior.addBehaviorField( "Force_Digital_Input",  "Force joystick inputs to be on/off.", bool, false );
}

function RG_InstantFace::onAdd( %this ) 
{  
   if(%this.debugMode) echo("RG_InstantFace::onAdd( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}

function RG_InstantFace::onRemove( %this ) 
{   
   if(%this.debugMode) echo("RG_InstantFace::onRemove( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}

function RG_InstantFace::onAddToScene(%this, %scenegraph) 
{
   if(%this.debugMode) echo("RG_InstantFace::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   
   if(!%this.enable) return;

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
      if(%this.Enable_Up)
         moveMap.call( %this.bindingMethod, getWord( %this.Up , 0 ),    getWord( %this.Up , 1 ), "onMoveUp", %this );

      if(%this.Enable_Down)
         moveMap.call( %this.bindingMethod, getWord( %this.Down , 0 ),  getWord( %this.Down , 1 ), "onMoveDown", %this );
   }
   else
   {
      // USING JOYSTICK AXIS
      moveMap.call( %this.bindingMethod, getWord( %this.Up , 0 ), getWord( %this.Up , 1 ), "onMoveJoystickUpDown", %this );
   }

   if( strstr( getWord( %this.Left , 1 ), "axis" ) == -1 )
   {
      // USING JOYSTICK BUTTONS OR KEYBOARD KEYS
   if(%this.Enable_Left)
      moveMap.call( %this.bindingMethod, getWord( %this.Left , 0 ),  getWord( %this.Left , 1 ), "onMoveLeft", %this );

   if(%this.Enable_Right)
      moveMap.call( %this.bindingMethod, getWord( %this.Right , 0 ), getWord( %this.Right , 1 ), "onMoveRight", %this );
   }
   else
   {
      // USING JOYSTICK AXIS
      moveMap.call( %this.bindingMethod, getWord( %this.Left , 0 ), getWord( %this.Left , 1 ), "onMoveJoystickLeftRight", %this );
   }
  
   %this.inputX = 0;
   %this.inputY = 0;
   %this.up     = 0;
   %this.down   = 0;
   %this.left   = 0;
   %this.right  = 0;
}

function RG_InstantFace::onMoveUp( %this , %val )
{   
   if(%this.debugMode) echo("RG_InstantFace::onMoveUp( ", %val , " ) " );

   %this.up = %val;
   if(!%val && %this.down) %val = -1; 
   %this.inputY  = %val;
   
   %this.doMove();
}

function RG_InstantFace::onMoveDown( %this , %val )
{   
   if(%this.debugMode) echo("RG_InstantFace::onMoveDown( ", %val , " ) " );

   %this.down = %val;

   if(!%val && %this.up) 
   {
      %val = 1;
   }
   else
   {
      %val = -%val; // Flip to get proper direction
   }

   %this.inputY  = %val;

   %this.doMove();
}


function RG_InstantFace::onMoveJoystickUpDown( %this , %val )
{   
   if(%this.debugMode) echo("RG_InstantFace::onMoveJoystickUpDown( ", %val , " ) " );
   
   // Up
   if( %val < 0 )
   {
      if(%this.Enable_Up)
      {
         %this.inputY = -%val;
      }
      else
      {
         %this.inputY = 0;
      }

      if(%this.Force_Digital_Input)
      {
         %this.inputY = mCeil(%this.inputY);
         if(%this.debugMode) echo("Force_Digital_Input => ", %this.inputY);
      }
   }
   // Down
   else if (%val > 0)
   {
      if(%this.Enable_Down)
      {
         %this.inputY = -%val;
      }
      else
      {
         %this.inputY = 0;
      }

      if(%this.Force_Digital_Input)
      {
         %this.inputY = mFloor(%this.inputY);
         if(%this.debugMode) echo("Force_Digital_Input => ", %this.inputY);
      }
   }
   // Off
   else
   {
      %this.inputY = 0;
   }
   %this.doMove();
}

function RG_InstantFace::onMoveLeft( %this , %val )
{   
   if(%this.debugMode) echo("RG_InstantFace::onMoveLeft( ", %val , " ) " );

   %this.left = %val;

   if(!%val && %this.right) 
   {
      %val = 1;
   }
   else
   {
      %val = -%val; // Flip to get proper direction
   }

   %this.inputX  = %val;

   %this.doMove();
}

function RG_InstantFace::onMoveRight( %this , %val )
{   
   if(%this.debugMode) echo("RG_InstantFace::onMoveRight( ", %val , " ) " );

   %this.right = %val;
   if(!%val && %this.left) %val = -1; 
   %this.inputX  = %val;
   
   %this.doMove();
}

function RG_InstantFace::onMoveJoystickLeftRight( %this , %val )
{   
   if(%this.debugMode) echo("RG_InstantFace::onMoveJoystickLeftRight( ", %val , " ) " );
   
   // Right
   if( %val < 0 )
   {
      if(%this.Enable_Right)
      {
         %this.inputX = %val;
      }
      else
      {
         %this.inputX = 0;
      }

      if(%this.Force_Digital_Input)
      {
         %this.inputX = mFloor(%this.inputX);
         if(%this.debugMode) echo("Force_Digital_Input => ", %this.inputX);
      }
   }
   // Left
   else if (%val > 0)
   {
      if(%this.Enable_Left)
      {
         %this.inputX = %val;
      }
      else
      {
         %this.inputX = 0;
      }

      if(%this.Force_Digital_Input)
      {
         %this.inputX = mCeil(%this.inputX);
         if(%this.debugMode) echo("Force_Digital_Input => ", %this.inputX);
      }
   }
   // Off
   else
   {
      %this.inputX = 0;
   }
   %this.doMove();
}

function RG_InstantFace::doMove( %this )
{   
   if(!%this.inputX && !%this.inputY) return;
   %facingAngle = vectorToAngle( %this.inputX SPC -%this.inputY );
   %this.owner.setRotation(%facingAngle);
}
