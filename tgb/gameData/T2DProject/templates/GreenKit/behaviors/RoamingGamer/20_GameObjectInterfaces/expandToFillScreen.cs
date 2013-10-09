if (!isObject(expandToFillScreen))
{
   %behavior = new BehaviorTemplate(expandToFillScreen)
   {
      friendlyName = "Fill Screen";
      behaviorType = "20 - Interfaces";
      description  = "Force this object to fill the screen when displayed.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debuging for this behavior.", bool, false);
}

//
// Behavior Methods and Callbacks
//
function expandToFillScreen::onAddToScene(%this, %scenegraph) 
//function expandToFillScreen::onAdd(%this) 
{
   if($LevelEditorActive) return;
   if(!%this.enable) return;
   if(%this.debugMode) echo("expandToFillScreen::onAddToScene()");
   
   %area = sceneWindow2D.getCurrentCameraArea();
   %position = sceneWindow2D.getCurrentCameraPosition();

   %this.owner.setArea( %area );
}
