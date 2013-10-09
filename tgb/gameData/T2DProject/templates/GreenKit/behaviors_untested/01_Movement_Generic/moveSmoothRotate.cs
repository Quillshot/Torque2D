echo("\n--------- Loading RG Smooth Rotate Movement Model Behavior ---------");

//
// Create Behavior Template
//
if (!isObject(RG_SmoothRotate))
{
   %behavior = new BehaviorTemplate(RG_SmoothRotate)
   {
      friendlyName = "Smooth Rotate";
      behaviorType = "01 - Movement Generic (Keyboard, Joysticks, Controllers - only)";
      description  = "Rotate smoothly (over time) left/right. (Individual directions may be disabled.)";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   
   %behavior.addBehaviorField( "rotateRate", "Rotation rate in degrees.", float, 90 );   

   %behavior.addBehaviorField( "Counterclockwise",  "Rotate Counterclockwise",  keybind, "Keyboard A" );
   %behavior.addBehaviorField( "Clockwise", "Rotate Clockwise", keybind, "Keyboard D" );
   
   %behavior.addBehaviorField( "limitAngle",  "Limit rotations to a specified range.", bool, false );
   %behavior.addBehaviorField( "minAngle", "Minimum counterclockwise rotation angle.", float, -85 );   
   %behavior.addBehaviorField( "maxAngle", "Maximum clockwise rotation angle.", float, 85 );   

   %behavior.addBehaviorField( "Enable_Counterclockwise",  "Enable Rotate Counterclockwise", bool, true );
   %behavior.addBehaviorField( "Enable_Clockwise",  "Enable Rotate Clockwise", bool, true );
}

function RG_SmoothRotate::onAdd( %this ) 
{  
   //echo("RG_SmoothRotate::onAdd( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}

function RG_SmoothRotate::onRemove( %this ) 
{   
   //echo("RG_SmoothRotate::onRemove( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}

function RG_SmoothRotate::onAddToScene(%this, %scenegraph) 
{
   //echo("RG_SmoothRotate::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   
   if(!%this.enable) return;

   // Note: Do not use a joystick for only one part of a Rotation pair. 
   // Ex: If you use joystick yaxis for up, use it for down too.

   if( strstr( getWord( %this.Counterclockwise , 1 ), "axis" ) == -1 )
   {
      // USING JOYSTICK BUTTONS OR KEYBOARD KEYS
   if(%this.Enable_Counterclockwise)
      moveMap.bindMulti( getWord( %this.Counterclockwise , 0 ),  getWord( %this.Counterclockwise , 1 ),  %this, "onRotateCounterclockwise" );

   if(%this.Enable_Clockwise)
      moveMap.bindMulti( getWord( %this.Clockwise , 0 ), getWord( %this.Clockwise , 1 ), %this, "onRotateClockwise" );
   }
   else
   {
      // USING JOYSTICK AXIS
      moveMap.bindMulti( getWord( %this.Counterclockwise , 0 ), getWord( %this.Counterclockwise , 1 ), %this, "onRotateJoystickCounterclockwiseClockwise" );
   }
  
   %this.inputX = 0;
   %this.inputY = 0;
   %this.Counterclockwise = 0;
   %this.Clockwise = 0;
}


function RG_SmoothRotate::onRotateCounterclockwise( %this , %val )
{   
   //error("RG_SmoothRotate::onRotateCounterclockwise( ", %val , " ) " );

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

   %this.doRotate();
}

function RG_SmoothRotate::onRotateClockwise( %this , %val )
{   
   //error("RG_SmoothRotate::onRotateClockwise( ", %val , " ) " );

   %this.Clockwise = %val;
   if(!%val && %this.Counterclockwise) %val = -1; 
   %this.inputX  = %val;
   
   %this.doRotate();
}

function RG_SmoothRotate::onRotateJoystickCounterclockwiseClockwise( %this , %val )
{   
   //error("RG_SmoothRotate::onRotateJoystickCounterclockwiseClockwise( ", %val , " ) " );
   
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

      %this.inputX = mFloor(%this.inputX);
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

      %this.inputX = mCeil(%this.inputX);
   }
   // Off
   else
   {
      %this.inputX = 0;
   }

   %this.doRotate();
}


function RG_SmoothRotate::doRotate( %this )
{   
   // if using limited-rotation, rotate to the min or max angle
   if( %this.limitAngle && ( %this.inputX < 0 )  )
   {
      %this.owner.rotateTo( %this.minAngle , %this.rotateRate, true  ); 
   }
   else if( %this.limitAngle && ( %this.inputX > 0 ) )
   {
      %this.owner.rotateTo( %this.maxAngle , %this.rotateRate, true  ); 
   } 
   else
   {
      %this.owner.setAngularVelocity( %this.inputX * %this.rotateRate );
   }
}
