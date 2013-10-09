if (!isObject(moveFaceRightMouseClick))
{
   %behavior = new BehaviorTemplate(moveFaceRightMouseClick)
   {
      friendlyName = "Face Right Mouse Click";
      behaviorType = "01 - Movement Mouse";
      description  = "Face the mouse when it is right clicked.";
   };
   %behavior.addValidObjectClass("t2dSceneObject");
   %behavior.addBehaviorField( "enable", "Enable behavior.", bool, true );   
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);
}

function moveFaceRightMouseClick::onAddToScene(%this, %scenegraph) 
{
   %this.owner.setUseMouseEvents(true);
   %this.owner.setMouseLocked(true);
   sceneWindow2D.setUseObjectMouseEvents(1);
}

function moveFaceRightMouseClick::onRightMouseDown(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;
   %this.doFace( %worldPos );
}

function moveFaceRightMouseClick::doFace(%this, %worldPos)
{
   %position = %this.owner.getPosition();
   %vector = t2dVectorSub( %worldPos, %position );
   %normVec = t2dVectorNormalise( %vector );
   %angle = vectorToAngle( %normVec );
   %this.owner.setRotation( %angle );
}

