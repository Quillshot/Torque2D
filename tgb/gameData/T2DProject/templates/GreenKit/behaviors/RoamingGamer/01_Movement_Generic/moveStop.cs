echo("\n--------- Loading RG Stop Movement Model Behavior ---------");

//
// Create Behavior Template
//
if (!isObject(RG_FullStop))
{
   %behavior = new BehaviorTemplate(RG_FullStop)
   {
      friendlyName = "Stop Moving and/or Rotating";
      behaviorType = "01 - Movement Generic (Keyboard, Joysticks, Controllers - only)";
      description  = "Stop translation and/or rotation.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);

   %behavior.addBehaviorField( "Stop_Translations",  "Stop translations.", bool, true );
   %behavior.addBehaviorField( "Stop_Rotations",  "Stop rotations.", bool, true );
   
   %behavior.addBehaviorField( "Stop",  "Stop key",  keybind, "Keyboard space" );   
   %behavior.addBehaviorField(bindMulti, "Enable Roaming Gamer multi-binding.", bool, true);   
   
}

function RG_FullStop::onAdd( %this ) 
{  
   if(%this.debugMode) echo("RG_FullStop::onAdd( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}

function RG_FullStop::onRemove( %this ) 
{   
   if(%this.debugMode) echo("RG_FullStop::onRemove( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}

function RG_FullStop::onAddToScene(%this, %scenegraph) 
{
   if(%this.debugMode) echo("RG_FullStop::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   
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

   if( strstr( getWord( %this.Stop , 1 ), "axis" ) == -1 )
   {
      // USING JOYSTICK BUTTONS OR KEYBOARD KEYS
      moveMap.call( %this.bindingMethod, getWord( %this.Stop , 0 ),  getWord( %this.Stop , 1 ),  "onStop", %this );
   }
   else
   {
      // USING JOYSTICK AXIS
      moveMap.call( %this.bindingMethod, getWord( %this.Stop , 0 ), getWord( %this.Stop , 1 ), "onJoystickStop", %this );
   }
  
   %this.inputX = 0;
   %this.inputY = 0;
   %this.Stop = 0;
   %this.Clockwise = 0;
}


function RG_FullStop::onStop( %this , %val )
{   
   error("RG_FullStop::onStop( ", %val , " ) " );
   %this.doStop();
}

function RG_FullStop::onJoystickStop( %this , %val )
{   
   error("RG_FullStop::onJoystickStop( ", %val , " ) " );
   // Only downward/leftward strokes stop
   if (%val > 0) %this.doStop();
}


function RG_FullStop::doStop( %this )
{   
   if(%this.Stop_Translations && %this.Stop_Rotations)
   {
      error("Stop Translations and Rotations" );
      %this.owner.setAtRest();
   }   
   else if(%this.Stop_Translations)
   {
      error("Stop Translations" );
      %this.owner.setLinearVelocity(0,0);
      //%this.owner.setConstantForcePolar( 0, 0 );
      %this.owner.stopConstantForce(0,0);
      %this.owner.setPositionTargetOff();
   }
   else if(%this.Stop_Rotations)
   {
      error("Stop Rotations" );
      %this.owner.setRotationTargetOff();
      %this.owner.setAngularVelocity( 0.0 );
   }
}
