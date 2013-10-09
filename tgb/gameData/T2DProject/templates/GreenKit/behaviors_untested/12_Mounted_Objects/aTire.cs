echo("\n--------- Loading RG Smooth Rotate Movement Model Behavior ---------");

//
// Create Behavior Template
//
if (!isObject(aTire))
{
   %behavior = new BehaviorTemplate(aTire)
   {
      friendlyName = "A Tire";
      behaviorType = "12 - Mounted Objects";
      description  = "This object should behave like a tire and rotate left-right (in response to key inputs).  It can also have a base-rotation not affected by key inputs.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   
   %behavior.addBehaviorField( "baseRotation", "Default rotation rate when no keys are pressed. (Degrees-per-second)", float, 90 );   
   %behavior.addBehaviorField( "keyRotation", "Rotation added (or subtracted as result of pressing key. (Degrees-per-second)", float, 90 );   

   %behavior.addBehaviorField( "leftKey",  "Rotate left",  keybind, "Keyboard A" );
   %behavior.addBehaviorField( "rightKey", "Rotate right", keybind, "Keyboard D" );
}


function aTire::onAddToScene(%this, %scenegraph) 
{
   //echo("aTire::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(!%this.enable) return;
   %this.owner.MountTrackRotation = "0";
   
   %this.owner.setAngularVelocity( %this.baseRotation );
   

   // Note: Do not use a joystick for only one part of a Rotation pair. 
   // Ex: If you use joystick yaxis for up, use it for down too.

   if( strstr( getWord( %this.leftKey , 1 ), "axis" ) == -1 )
   {
      // USING JOYSTICK BUTTONS OR KEYBOARD KEYS
      moveMap.unbindMulti( getWord( %this.leftKey , 0 ),  getWord( %this.leftKey , 1 ),  %this, "onRotateleftKey" );

      moveMap.unbindMulti( getWord( %this.rightKey , 0 ), getWord( %this.rightKey , 1 ), %this, "onRotaterightKey" );
   }
   else
   {
      // USING JOYSTICK AXIS
      moveMap.unbindMulti( getWord( %this.leftKey , 0 ), getWord( %this.leftKey , 1 ), %this, "onRotateJoystickleftKeyClockwise" );
   }
  
   %this.inputX = 0;
   %this.inputY = 0;
   %this.leftKey = 0;
   %this.rightKey = 0;
}


function aTire::onRotateleftKey( %this , %val )
{   
   //error("aTire::onRotateleftKey( ", %val , " ) " );

   %this.leftKey = %val;

   if(!%val && %this.rightKey) 
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

function aTire::onRotaterightKey( %this , %val )
{   
   //error("aTire::onRotaterightKey( ", %val , " ) " );

   %this.rightKey = %val;
   if(!%val && %this.leftKey) %val = -1; 
   %this.inputX  = %val;
   
   %this.doRotate();
}

function aTire::onRotateJoystickleftKeyClockwise( %this , %val )
{   
   //error("aTire::onRotateJoystickleftKeyClockwise( ", %val , " ) " );
   
   // rightKey
   if( %val < 0 )
   {
      %this.inputX = %val;
      %this.inputX = mFloor(%this.inputX);
   }
   // leftKey
   else if (%val > 0)
   {
      %this.inputX = %val;
      %this.inputX = mCeil(%this.inputX);
   }
   // Off
   else
   {
      %this.inputX = 0;
   }

   %this.doRotate();
}


function aTire::doRotate( %this )
{   
   %this.owner.setAngularVelocity( %this.inputX * %this.keyRotation  + %this.baseRotation );
}
