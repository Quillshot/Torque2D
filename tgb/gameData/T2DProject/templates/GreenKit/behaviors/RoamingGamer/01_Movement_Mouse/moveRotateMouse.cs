if (!isObject(moveRotateMouse))
{
   %behavior = new BehaviorTemplate(moveRotateMouse)
   {
      friendlyName = "Rotate Mouse";
      behaviorType = "01 - Movement Mouse";
      description  = "Rotate when mouse is moved left or right.";
   };
   %behavior.addValidObjectClass("t2dSceneObject");
   %behavior.addBehaviorField( "enable", "Enable behavior.", bool, true );   
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);  
   
   %behavior.addBehaviorField(turnSpeed, "Turn rate (in degrees per pixel moved)", float, 1.0);
}

function moveRotateMouse::onAddToScene(%this, %scenegraph) 
{
   %this.owner.setUseMouseEvents(true);
   %this.owner.setMouseLocked(true);
   sceneWindow2D.setUseObjectMouseEvents(1);
}

function moveRotateMouse::onMouseMove(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;
   %this.doRotate( %worldPos );
}

function moveRotateMouse::onMouseDragged(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;
   %this.doRotate( %worldPos );
}

function moveRotateMouse::onRightMouseDragged(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;
   %this.doRotate( %worldPos );
}

function moveRotateMouse::doRotate(%this, %worldPos)
{
   if(%this.lastPos $= "") 
   {
      %this.lastPos = %worldPos;
   }
   
   %newPos = %worldPos;   
   %oldPos = %this.lastPos;
   %this.lastPos = %newPos;
   
   %vector = t2dVectorSub( %newPos, %oldPos );
   
   %deltaX = getWord( %vector , 0 );
   
   %deltaX = %deltaX * %this.turnSpeed;
   
   %currentAngle = %this.owner.getRotation();
   
   %this.owner.setRotation(%currentAngle + %deltaX);
}

