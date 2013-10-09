if (!isObject(moveFaceMouse))
{
   %behavior = new BehaviorTemplate(moveFaceMouse)
   {
      friendlyName = "Face Mouse";
      behaviorType = "01 - Movement Mouse";
      description  = "Follow the mouse position.";
   };
   %behavior.addValidObjectClass("t2dSceneObject");
   %behavior.addBehaviorField( "enable", "Enable behavior.", bool, true );   
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);
}

function moveFaceMouse::onAddToScene(%this, %scenegraph) 
{
   %this.owner.setUseMouseEvents(true);
   %this.owner.setMouseLocked(true);
   sceneWindow2D.setUseObjectMouseEvents(1);
}

function moveFaceMouse::onMouseMove(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;
   %this.doFace( %worldPos );
}

function moveFaceMouse::onMouseDragged(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;
   %this.doFace( %worldPos );
}

function moveFaceMouse::onRightMouseDragged(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;
   %this.doFace( %worldPos );
}

function moveFaceMouse::doFace(%this, %worldPos)
{
   %position = %this.owner.getPosition();
   %vector = t2dVectorSub( %worldPos, %position );
   %normVec = t2dVectorNormalise( %vector );
   %angle = vectorToAngle( %normVec );
   %this.owner.setRotation( %angle );
}

