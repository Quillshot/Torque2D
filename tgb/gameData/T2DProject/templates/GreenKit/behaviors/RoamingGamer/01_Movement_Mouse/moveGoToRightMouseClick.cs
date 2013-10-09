if (!isObject(moveGoToRightMouseClick))
{
   %behavior = new BehaviorTemplate(moveGoToRightMouseClick)
   {
      friendlyName = "Go to right mouse click";
      behaviorType = "01 - Movement Mouse";
      description  = "Move to position where right mouse click occurs.";
   };
   %behavior.addValidObjectClass("t2dSceneObject");
   %behavior.addBehaviorField( "enable", "Enable behavior.", bool, true );  
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);   
}

function moveGoToRightMouseClick::onAddToScene(%this, %scenegraph) 
{
   %this.owner.setUseMouseEvents(true);
   %this.owner.setMouseLocked(true);
   sceneWindow2D.setUseObjectMouseEvents(1);
}

function moveGoToRightMouseClick::onRightMouseDown(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;

   %this.owner.setPosition(%worldPos.x , %worldPos.y);
}
