echo("\n--------- Loading RG Smooth Rotate Movement Model Behavior ---------");

//
// Create Behavior Template
//
if (!isObject(moveTankBrigade))
{
   %behavior = new BehaviorTemplate(moveTankBrigade)
   {
      friendlyName = "Tank Brigade";
      behaviorType = "01 - Movement Special (Keyboard, Joysticks, Controllers - only)";
      description  = "Move tank (from Tank Brigade pack) forward and backward, as well as rotate left/right.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);
   
   %behavior.addBehaviorField( "moveForward",  "Move Forward",  keybind, "Keyboard W" );
   %behavior.addBehaviorField( "moveBackward", "Move Backward", keybind, "Keyboard S" );
   %behavior.addBehaviorField( "moveSpeed", "Speed to move at.", "float", 25.0);   

   %behavior.addBehaviorField( "rotateLeft",  "Rotate rotateLeft",  keybind, "Keyboard A" );
   %behavior.addBehaviorField( "rotateRight", "Rotate rotateRight", keybind, "Keyboard D" );
   %behavior.addBehaviorField( "rotateRate", "Rotation rate in degrees.", float, 90 );   
   %behavior.addBehaviorField(bindMulti, "Enable Roaming Gamer multi-binding.", bool, true);   
}

function moveTankBrigade::onAdd( %this ) 
{  
   if(%this.debugMode) echo("moveTankBrigade::onAdd( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}

function moveTankBrigade::onRemove( %this ) 
{   
   if(%this.debugMode) echo("moveTankBrigade::onRemove( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}

function moveTankBrigade::onAddToScene(%this, %scenegraph) 
{
   if(%this.debugMode) echo("moveTankBrigade::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   
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

   if( strstr( getWord( %this.rotateLeft , 1 ), "axis" ) == -1 )
   {
      // USING JOYSTICK BUTTONS OR KEYBOARD KEYS
      moveMap.call( %this.bindingMethod, getWord( %this.moveForward , 0 ),  getWord( %this.moveForward , 1 ),  "onMoveForward", %this );
      moveMap.call( %this.bindingMethod, getWord( %this.moveBackward , 0 ),  getWord( %this.moveBackward , 1 ),  "onMoveBackward", %this );
      moveMap.call( %this.bindingMethod, getWord( %this.rotateLeft , 0 ),  getWord( %this.rotateLeft , 1 ),  "onRotaterotateLeft", %this );
      moveMap.call( %this.bindingMethod, getWord( %this.rotateRight , 0 ), getWord( %this.rotateRight , 1 ), "onRotaterotateRight", %this );
   }
   else
   {
      // USING JOYSTICK AXIS
      moveMap.call( %this.bindingMethod, getWord( %this.rotateLeft , 0 ), getWord( %this.rotateLeft , 1 ), "onRotateJoystickrotateLeftrotateRight", %this );
   }
  
   %this.inputX = 0;
   %this.inputY = 0;
   %this.rotateLeft = 0;
   %this.rotateRight = 0;
}



function moveTankBrigade::onMoveForward(%this, %val) 
{
   if(%this.debugMode) echo("moveTankBrigade::onMoveForward( ", %val , " ) " );
   if(!%this.enable) return;

   %this.inputY  = %val;
   %this.owner.setForwardMovementOnly(true);
   %angle = %this.owner.getRotation();
   %this.owner.setLinearVelocityPolar(%angle, %this.inputY * -%this.moveSpeed);
   %this.doMove();
}


function moveTankBrigade::onMoveBackward( %this , %val )
{   
   if(%this.debugMode) echo("moveTankBrigade::onMoveBackward( ", %val , " ) " );
   if(!%this.enable) return;
   

   %this.owner.setRotation(%this.owner.getRotation()-180);
   %this.owner.setFlipY(%val);
   %this.owner.setFlipX(%val);

   %this.inputY  = -%val;
   %this.owner.setForwardMovementOnly(true);
   %angle = %this.owner.getRotation();
   %this.owner.setLinearVelocityPolar(%angle, %this.inputY * -%this.moveSpeed);
   %this.doMove();
}



function moveTankBrigade::onRotaterotateLeft( %this , %val )
{   
   if(%this.debugMode) echo("moveTankBrigade::onRotaterotateLeft( ", %val , " ) " );

   %this.rotateLeftVal = %val;

   if(!%val && %this.rotateRightVal) 
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

function moveTankBrigade::onRotaterotateRight( %this , %val )
{   
   if(%this.debugMode) echo("moveTankBrigade::onRotaterotateRight( ", %val , " ) " );

   %this.rotateRightVal = %val;
   if(!%val && %this.rotateLeftVal) %val = -1; 
   %this.inputX  = %val;
   
   %this.doRotate();
}

function moveTankBrigade::onRotateJoystickrotateLeftrotateRight( %this , %val )
{   
   if(%this.debugMode) echo("moveTankBrigade::onRotateJoystickrotateLeftrotateRight( ", %val , " ) " );
   
   // rotateRight
   if( %val < 0 )
   {
      %this.inputX = %val;
      %this.inputX = mFloor(%this.inputX);
   }
   // rotateLeft
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


function moveTankBrigade::doRotate( %this )
{   
   // if using limited-rotation, rotate to the min or max angle
   %this.owner.setAngularVelocity( %this.inputX * %this.rotateRate );
}

function moveTankBrigade::doMove( %this )
{   
   if(%this.inputY == 0) return;
   
   %this.frameIncr++;
   
   if(%this.debugMode) echo( %this.frameIncr SPC %this.inputY );
   %frame = %this.owner.getFrame();
   if(%this.debugMode) echo( %frame );
   %frame = %frame + %this.inputY;
   if(%this.debugMode) echo( %frame );
   %maxFrame = %this.owner.getImagemap().getFrameCount()-1;
   if(%this.debugMode) echo( %maxFrame );
   if(%frame > %maxFrame) %frame = 0;
   if(%frame < 0 ) %frame = %maxFrame;
   if(%this.debugMode) echo( %frame SPC "\n");
   %this.owner.setFrame(%frame);
   
   // if using limited-rotation, rotate to the min or max angle
   %this.owner.setForwardMovementOnly(true);
   %angle = %this.owner.getRotation();
   %this.owner.setLinearVelocityPolar(%angle, %this.inputY * -%this.moveSpeed);
   %this.schedule(100, doMove );
}

