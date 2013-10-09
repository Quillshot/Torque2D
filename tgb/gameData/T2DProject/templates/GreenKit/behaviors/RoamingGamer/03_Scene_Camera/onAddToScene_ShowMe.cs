
if (!isObject(onAddToScene_ShowMe))
{
   %behavior = new BehaviorTemplate(onAddToScene_ShowMe)
   {
      friendlyName = "Show Me";
      behaviorType = "03 - Scene and Camera";
      description  = "Show this object when it is loaded to the scene.";
   };   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);
}

function onAddToScene_ShowMe::onAddToScene(%this, %scenegraph) 
{
   if(%this.debugMode) echo("onAddToScene_ShowMe::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   
   if(!%this.enable) return;
   
   %this.owner.setVisible(1);
}