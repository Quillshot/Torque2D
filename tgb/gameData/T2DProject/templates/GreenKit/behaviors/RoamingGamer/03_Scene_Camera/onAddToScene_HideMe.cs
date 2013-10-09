
if (!isObject(onAddToScene_HideMe))
{
   %behavior = new BehaviorTemplate(onAddToScene_HideMe)
   {
      friendlyName = "Hide Me";
      behaviorType = "03 - Scene and Camera";
      description  = "Hide this object when it is loaded to the scene.";
   };   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);
}

function onAddToScene_HideMe::onAddToScene(%this, %scenegraph) 
{
   if(%this.debugMode) echo("onAddToScene_HideMe::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   
   if(!%this.enable) return;
   
   %this.owner.setVisible(0);
}