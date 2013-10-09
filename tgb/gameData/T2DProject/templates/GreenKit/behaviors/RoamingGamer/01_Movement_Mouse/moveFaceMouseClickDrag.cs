if (!isObject(moveFaceMouseClickDrag))
{
   %behavior = new BehaviorTemplate(moveFaceMouseClickDrag)
   {
      friendlyName = "Face Mouse Click and Drag";
      behaviorType = "01 - Movement Mouse";
      description  = "Face the mouse when it is clicked and dragged.";
   };
   %behavior.addValidObjectClass("t2dSceneObject");
   %behavior.addBehaviorField( "enable", "Enable behavior.", bool, true );  
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false); 
}

function moveFaceMouseClickDrag::onAddToScene(%this, %scenegraph) 
{
   %this.owner.setUseMouseEvents(true);
   %this.owner.setMouseLocked(true);
   sceneWindow2D.setUseObjectMouseEvents(1);
}

function moveFaceMouseClickDrag::onMouseDown(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;
   %this.doFace( %worldPos );
}

function moveFaceMouseClickDrag::onMouseDragged(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;
   %this.doFace( %worldPos );
}

function moveFaceMouseClickDrag::doFace(%this, %worldPos)
{
   %position = %this.owner.getPosition();
   %vector = t2dVectorSub( %worldPos, %position );
   %normVec = t2dVectorNormalise( %vector );
   %angle = vectorToAngle( %normVec );
   %this.owner.setRotation( %angle );
}

