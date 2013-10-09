if (!isObject(onRightMouseClick_Fire))
{
   %behavior = new BehaviorTemplate(onRightMouseClick_Fire)
   {
      friendlyName = "onRightMouseClicked() -> Fire";
      behaviorType = "06 - Weapons";
      description  = "Face the mouse when it is clicked.";
   };
   %behavior.addValidObjectClass("t2dSceneObject");
   %behavior.addBehaviorField( "enable", "Enable behavior.", bool, true );   
}

function onRightMouseClick_Fire::onAddToScene(%this, %scenegraph) 
{
   %this.owner.setUseMouseEvents(true);
   %this.owner.setMouseLocked(true);
   sceneWindow2D.setUseObjectMouseEvents(1);
}

function onRightMouseClick_Fire::onRightMouseDown(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;
   %this.broadcastMethod( onFire, 1 );
}

function onRightMouseClick_Fire::onRightMouseUp(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;
   %this.broadcastMethod( onFire, 0 );
}
