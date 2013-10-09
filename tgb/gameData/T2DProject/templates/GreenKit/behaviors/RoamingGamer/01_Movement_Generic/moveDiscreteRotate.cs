echo("\n--------- Loading RG Discrete Rotate Movement Model Behavior ---------");

//
// Create Behavior Template
//
if (!isObject(RG_DiscreteRotate))
{
   %behavior = new BehaviorTemplate(RG_DiscreteRotate)
   {
      friendlyName = "Discrete Rotate";
      behaviorType = "01 - Movement Generic (Keyboard, Joysticks, Controllers - only)";
      description  = "Rotate left/right in discrete increments. (Individual directions may be disabled.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);
   
   %behavior.addBehaviorField( "stepSize", "Step size in degrees.", float, 5 );   

   %behavior.addBehaviorField( "continuousStepping", "Step while key is held.", bool, true );   
   %behavior.addBehaviorField( "stepTime", "Step time in milliseconds.", integer, 100 );   
   
   %behavior.addBehaviorField( "Counterclockwise",  "Rotate Counterclockwise",  keybind, "Keyboard A" );
   %behavior.addBehaviorField( "Clockwise", "Rotate Clockwise", keybind, "Keyboard D" );
   %behavior.addBehaviorField(bindMulti, "Enable Roaming Gamer multi-binding.", bool, true);   
   
   %behavior.addBehaviorField( "limitAngle",  "Limit rotations to a specified range.", bool, false );
   %behavior.addBehaviorField( "minAngle", "Minimum counterclockwise rotation angle.", float, -85 );   
   %behavior.addBehaviorField( "maxAngle", "Maximum clockwise rotation angle.", float, 85 );   

   %behavior.addBehaviorField( "Enable_Counterclockwise",  "Enable Rotate Counterclockwise", bool, true );
   %behavior.addBehaviorField( "Enable_Clockwise",  "Enable Rotate Clockwise", bool, true );
   
   %behavior.addBehaviorField( "Opposites_Cancel",  "Rotations in opposite directions cancel out.", bool, false );
   %behavior.addBehaviorField( "Force_Digital_Input",  "Force joystick inputs to be on/off.", bool, false );
}

function RG_DiscreteRotate::onAdd( %this ) 
{  
   if(%this.debugMode) echo("RG_DiscreteRotate::onAdd( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}

function RG_DiscreteRotate::onRemove( %this ) 
{   
   if(%this.debugMode) echo("RG_DiscreteRotate::onRemove( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}

function RG_DiscreteRotate::onAddToScene(%this, %scenegraph) 
{
   if(%this.debugMode) echo("RG_DiscreteRotate::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   
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

   // Note: Do not use a joystick for only one part of a Rotation pair. 
   // Ex: If you use joystick yaxis for up, use it for down too.

   if( strstr( getWord( %this.Counterclockwise , 1 ), "axis" ) == -1 )
   {
      // USING JOYSTICK BUTTONS OR KEYBOARD KEYS
   if(%this.Enable_Counterclockwise)
      moveMap.call( %this.bindingMethod, getWord( %this.Counterclockwise , 0 ),  getWord( %this.Counterclockwise , 1 ), "onRotateCounterclockwise", %this );

   if(%this.Enable_Clockwise)
      moveMap.call( %this.bindingMethod, getWord( %this.Clockwise , 0 ), getWord( %this.Clockwise , 1 ), "onRotateClockwise", %this );
   }
   else
   {
      // USING JOYSTICK AXIS
      moveMap.call( %this.bindingMethod, getWord( %this.Counterclockwise , 0 ), getWord( %this.Counterclockwise , 1 ), "onRotateJoystickCounterclockwiseClockwise", %this );
   }
  
   %this.inputX = 0;
   %this.inputY = 0;
   %this.Counterclockwise = 0;
   %this.Clockwise = 0;
}


function RG_DiscreteRotate::onRotateCounterclockwise( %this , %val )
{   
   //error("RG_DiscreteRotate::onRotateCounterclockwise( ", %val , " ) " );

   %this.Counterclockwise = %val;

   if(!%val && %this.Clockwise) 
   {
      %val = 1;
   }
   else
   {
      %val = -%val; // Flip to get proper direction
   }

   %this.inputX  = %val;

   if(%this.Opposites_Cancel && %this.Counterclockwise && %this.Clockwise)
   {
      %this.inputX = 0;
   }

   cancel(%this.lastSchedule);
   %this.doRotate();
}

function RG_DiscreteRotate::onRotateClockwise( %this , %val )
{   
   //error("RG_DiscreteRotate::onRotateClockwise( ", %val , " ) " );

   %this.Clockwise = %val;
   if(!%val && %this.Counterclockwise) %val = -1; 
   %this.inputX  = %val;
   
   if(%this.Opposites_Cancel && %this.Counterclockwise && %this.Clockwise)
   {
      %this.inputX = 0;
   }
   
   cancel(%this.lastSchedule);
   %this.doRotate();
}

function RG_DiscreteRotate::onRotateJoystickCounterclockwiseClockwise( %this , %val )
{   
   //error("RG_DiscreteRotate::onRotateJoystickCounterclockwiseClockwise( ", %val , " ) " );
   
   // Clockwise
   if( %val < 0 )
   {
      if(%this.Enable_Clockwise)
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
         //error("Force_Digital_Input => ", %this.inputX);
      }
   }
   // Counterclockwise
   else if (%val > 0)
   {
      if(%this.Enable_Counterclockwise)
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
         //error("Force_Digital_Input => ", %this.inputX);
      }
   }
   // Off
   else
   {
      %this.inputX = 0;
   }

   cancel(%this.lastSchedule);   
   %this.doRotate();
}


function RG_DiscreteRotate::doRotate( %this )
{   
   //
   // Calculate angular 'thrust'
   //
   %angleDelta = %this.inputX * %this.stepSize;
   
   %currentRotation = %this.owner.getRotation(); 
   %currentRotation = (%currentRotation > 180) ? %currentRotation - 360 : %currentRotation; // Work with half-rotations                         

   //error(" RG_DiscreteRotate %       rotation " SPC %currentRotation );
   //error(" RG_DiscreteRotate %angleDelta " SPC %angleDelta, "\n" );
         
   // if limited-rotation, and rotated past or to min, snap to min
   if( %this.limitAngle && ( %this.inputX < 0 ) && ( %currentRotation <= %this.minAngle ) )
   {
      %this.owner.setRotation( %this.minAngle );
      %this.owner.setAngularVelocity( 0 );
   }
   // if limited-rotation, and rotated past or to max, snap to max
   else if( %this.limitAngle && ( %this.inputX > 0 ) && ( %currentRotation >= %this.maxAngle ) )
   {
      %this.owner.setRotation( %this.maxAngle );
      %this.owner.setAngularVelocity( 0 );
   } 
   else
   {
      //
      // Apply 'thrust' values
      //      
      if(%this.debugMode) echo("rotating...");
      %this.owner.setRotation( %currentRotation + %angleDelta );
   }
   
   if(%angleDelta && %this.continuousStepping) 
   {  
      %this.lastSchedule = %this.schedule(%this.stepTime, doRotate);
   }
}
