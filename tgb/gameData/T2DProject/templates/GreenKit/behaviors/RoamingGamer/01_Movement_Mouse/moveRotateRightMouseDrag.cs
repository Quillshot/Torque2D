if (!isObject(moveRotateRightMouseDrag))
{
   %behavior = new BehaviorTemplate(moveRotateRightMouseDrag)
   {
      friendlyName = "Rotate Right Mouse Drag";
      behaviorType = "01 - Movement Mouse";
      description  = "Rotate when mouse is right dragged left or right.";
   };
   %behavior.addValidObjectClass("t2dSceneObject");
   %behavior.addBehaviorField( "enable", "Enable behavior.", bool, true ); 
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);  
   
   %behavior.addBehaviorField(turnSpeed, "Turn rate (in degrees per pixel moved)", float, 1.0);
}

function moveRotateRightMouseDrag::onAddToScene(%this, %scenegraph) 
{
   %this.owner.setUseMouseEvents(true);
   %this.owner.setMouseLocked(true);
   sceneWindow2D.setUseObjectMouseEvents(1);
}

function moveRotateRightMouseDrag::onRightMouseDown(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;
   %this.lastPos = %worldPos;
}

function moveRotateRightMouseDrag::onRightMouseDragged(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;
   %this.doRotate( %worldPos );
}

function moveRotateRightMouseDrag::doRotate(%this, %worldPos)
{
   %newPos = %worldPos;   
   %oldPos = %this.lastPos;
   %this.lastPos = %newPos;
   
   %vector = t2dVectorSub( %newPos, %oldPos );
   
   %deltaX = getWord( %vector , 0 );
   
   %deltaX = %deltaX * %this.turnSpeed;
   
   %currentAngle = %this.owner.getRotation();
   
   %this.owner.setRotation(%currentAngle + %deltaX);
}

