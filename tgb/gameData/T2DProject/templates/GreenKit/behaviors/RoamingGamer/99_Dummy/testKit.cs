if (!isObject(moveGoToMouseClick))
{
   %behavior = new BehaviorTemplate(testGreenKit)
   {
      friendlyName = "Test Green Kit";
      behaviorType = "99 - Dummy";
      description  = "Move to position where mouse click occurs.";
   };
   %behavior.addValidObjectClass("t2dSceneObject");
   %behavior.addBehaviorField( "enable", "Enable behavior.", bool, true );   
}

function testGreenKit::onAddToScene(%this, %scenegraph) 
{
   %this.owner.setUseMouseEvents(true);
   %this.owner.setMouseLocked(true);
   sceneWindow2D.setUseObjectMouseEvents(1);
}

function testGreenKit::onMouseDown(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;

   %this.owner.setPosition(%worldPos.x , %worldPos.y);
   alxPlay( "testSound");
}
