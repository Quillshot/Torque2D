if (!isObject(moveFaceRightMouseClickDrag))
{
   %behavior = new BehaviorTemplate(moveFaceRightMouseClickDrag)
   {
      friendlyName = "Face Right Mouse Click and Drag";
      behaviorType = "01 - Movement Mouse";
      description  = "Face the mouse when it is right clicked and dragged.";
   };
   %behavior.addValidObjectClass("t2dSceneObject");
   %behavior.addBehaviorField( "enable", "Enable behavior.", bool, true );   
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);  
}

function moveFaceRightMouseClickDrag::onAddToScene(%this, %scenegraph) 
{
   %this.owner.setUseMouseEvents(true);
   %this.owner.setMouseLocked(true);
   sceneWindow2D.setUseObjectMouseEvents(1);
}

function moveFaceRightMouseClickDrag::onRightMouseDown(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;
   %this.doFace( %worldPos );
}

function moveFaceRightMouseClickDrag::onRightMouseDragged(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;
   %this.doFace( %worldPos );
}

function moveFaceRightMouseClickDrag::doFace(%this, %worldPos)
{
   %position = %this.owner.getPosition();
   %vector = t2dVectorSub( %worldPos, %position );
   %normVec = t2dVectorNormalise( %vector );
   %angle = vectorToAngle( %normVec );
   %this.owner.setRotation( %angle );
}

