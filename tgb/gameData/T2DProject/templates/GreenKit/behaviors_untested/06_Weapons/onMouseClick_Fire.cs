if (!isObject(onMouseClick_Fire))
{
   %behavior = new BehaviorTemplate(onMouseClick_Fire)
   {
      friendlyName = "onMouseClicked() -> Fire";
      behaviorType = "06 - Weapons";
      description  = "Face the mouse when it is clicked.";
   };
   %behavior.addValidObjectClass("t2dSceneObject");
   %behavior.addBehaviorField( "enable", "Enable behavior.", bool, true );   
}

function onMouseClick_Fire::onAddToScene(%this, %scenegraph) 
{
   %this.owner.setUseMouseEvents(true);
   %this.owner.setMouseLocked(true);
   sceneWindow2D.setUseObjectMouseEvents(1);
}

function onMouseClick_Fire::onMouseDown(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;
   %this.broadcastMethod( onFire, 1 );
}

function onMouseClick_Fire::onMouseUp(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;
   %this.broadcastMethod( onFire, 0 );
}

