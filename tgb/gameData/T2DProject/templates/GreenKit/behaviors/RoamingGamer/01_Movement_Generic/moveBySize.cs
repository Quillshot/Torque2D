//
// Create Behavior Template
//
if (!isObject(moveBySize))
{
   %behavior = new BehaviorTemplate(moveBySize)
   {
      friendlyName = "By Size";
      behaviorType = "01 - Movement Generic (Keyboard, Joysticks, Controllers - only)";
      description  = "Move up/down/left/right by specified multiple of height/width.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);

   %behavior.addBehaviorField(upKey, "Key to bind to upward movement", keybind, "Keyboard W");
   %behavior.addBehaviorField(downKey, "Key to bind to downward movement", keybind, "Keyboard S");
   %behavior.addBehaviorField(leftKey, "Key to bind to leftward movement", keybind, "Keyboard A");
   %behavior.addBehaviorField(rightKey, "Key to bind to rightward movement", keybind, "Keyboard D");
   %behavior.addBehaviorField(bindMulti, "Enable Roaming Gamer multi-binding.", bool, true);   
   
   
   %behavior.addBehaviorField(upScale, "Number of multiples of height to move up (per key press)", float, 1.0);
   %behavior.addBehaviorField(downScale, "Number of multiples of height to move down (per key press)", float, 1.0);
   %behavior.addBehaviorField(leftScale, "Number of multiples of width to move left (per key press)", float, 1.0);
   %behavior.addBehaviorField(rightScale, "Number of multiples of width to move right (per key press)", float, 1.0);
   
   %behavior.addBehaviorField(enableUp, "Allow upward movement", bool, true);
   %behavior.addBehaviorField(enableDown, "Allow downward movement", bool, true);
   %behavior.addBehaviorField(enableLeft, "Allow leftward movement", bool, true);
   %behavior.addBehaviorField(enableRight, "Allow rightward movement", bool, true);
  
   %behavior.addBehaviorField(repeatRate, "While button(s) held repeat at this many moves per-second. (Maximum: 100)", integer, 0);
   
}

function moveBySize::onAddToScene(%this, %scenegraph) 
{
   if(%this.debugMode) echo("moveBySize::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(!%this.enable) return;

   if (!isObject(moveMap))  return;

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

   
   if(%this.enableUp) 
      moveMap.call( %this.bindingMethod, getWord(%this.upKey, 0), getWord(%this.upKey, 1), "moveUp", %this);
   if(%this.enableDown)
      moveMap.call( %this.bindingMethod, getWord(%this.downKey, 0), getWord(%this.downKey, 1), "moveDown", %this);
   if(%this.enableLeft)
      moveMap.call( %this.bindingMethod, getWord(%this.leftKey, 0), getWord(%this.leftKey, 1), "moveLeft", %this);
   if(%this.enableRight)
      moveMap.call( %this.bindingMethod, getWord(%this.rightKey, 0), getWord(%this.rightKey, 1), "moveRight", %this);

   %this.up     = 0;
   %this.down   = 0;
   %this.left   = 0;
   %this.right  = 0;
}

function moveBySize::moveUp(%this, %val)
{
   %this.up = %val;
   %this.doMoveUp();
}

function moveBySize::doMoveUp(%this)
{
   if(%this.up == 0) 
   {
      cancel(%this.lastUpSchedule);
      return;
   }

   %oldPos = %this.owner.getPosition();
   %height = %this.owner.getHeight();     
   %newPos = t2dVectorAdd( %oldPos, 0 SPC -(%this.upScale * %height));
   %this.owner.setPosition(%newPos);

   if( %this.repeatRate > 0) 
   {
      %rate = 1000 / %this.repeatRate;
      if(%rate < 10) %rate = 10;
      %this.lastUpSchedule = %this.schedule(%rate, doMoveUp);
   }
}

function moveBySize::moveDown(%this, %val)
{
   %this.Down = %val;
   %this.doMoveDown();
}

function moveBySize::doMoveDown(%this)
{
   if(%this.Down == 0) 
   {
      cancel(%this.lastDownSchedule);
      return;
   }

   %oldPos = %this.owner.getPosition();
   %height = %this.owner.getHeight();     
   %newPos = t2dVectorAdd( %oldPos, 0 SPC (%this.downScale * %height));
   %this.owner.setPosition(%newPos);

   if( %this.repeatRate > 0)  
   {
      %rate = 1000 / %this.repeatRate;
      if(%rate < 10) %rate = 10;
      %this.lastDownSchedule = %this.schedule(%rate, doMoveDown);
   }
}

function moveBySize::moveLeft(%this, %val)
{
   %this.Left = %val;
   %this.doMoveLeft();
}

function moveBySize::doMoveLeft(%this)
{
   if(%this.Left == 0) 
   {
      cancel(%this.lastLeftSchedule);
      return;
   }

   %oldPos = %this.owner.getPosition();
   %width = %this.owner.getWidth();     
   %newPos = t2dVectorAdd( %oldPos, -(%this.leftScale * %width) SPC 0);
   %this.owner.setPosition(%newPos);

   if( %this.repeatRate > 0)  
   {
      %rate = 1000 / %this.repeatRate;
      if(%rate < 10) %rate = 10;
      %this.lastLeftSchedule = %this.schedule(%rate, doMoveLeft);
   }
}


function moveBySize::moveRight(%this, %val)
{
   %this.Right = %val;
   %this.doMoveRight();
}

function moveBySize::doMoveRight(%this)
{
   if(%this.Right == 0) 
   {
      cancel(%this.lastRightSchedule);
      return;
   }

   %oldPos = %this.owner.getPosition();
   %width = %this.owner.getWidth();     
   %newPos = t2dVectorAdd( %oldPos, (%this.rightScale * %width) SPC 0);
   %this.owner.setPosition(%newPos);

   if( %this.repeatRate > 0)  
   {
      %rate = 1000 / %this.repeatRate;
      if(%rate < 10) %rate = 10;
      %this.lastRightSchedule = %this.schedule(%rate, doMoveRight);
   }
}
