if (!isObject(moveFollowMouse))
{
   %behavior = new BehaviorTemplate(moveFollowMouse)
   {
      friendlyName = "Follow Mouse";
      behaviorType = "01 - Movement Mouse";
      description  = "Follow the mouse position.";
   };
   %behavior.addValidObjectClass("t2dSceneObject");
   %behavior.addBehaviorField( "enable", "Enable behavior.", bool, true );   
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);  
}

function moveFollowMouse::onAddToScene(%this, %scenegraph) 
{
   %this.owner.setUseMouseEvents(true);
   %this.owner.setMouseLocked(true);
   sceneWindow2D.setUseObjectMouseEvents(1);
}

function moveFollowMouse::onMouseMove(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;

   %this.owner.setPosition(%worldPos.x , %worldPos.y);
}

function moveFollowMouse::onMouseDragged(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;

   %this.owner.setPosition(%worldPos.x , %worldPos.y);
}

function moveFollowMouse::onRightMouseDragged(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;

   %this.owner.setPosition(%worldPos.x , %worldPos.y);
}
