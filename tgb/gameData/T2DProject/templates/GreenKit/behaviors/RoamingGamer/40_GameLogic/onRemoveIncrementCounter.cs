
if (!isObject(onRemoveIncrementCounter))
{
   %behavior = new BehaviorTemplate(onRemoveIncrementCounter)
   {
      friendlyName = "onRemove() Give Points";
      behaviorType = "40 - Game Logic (Scoring)";
      description  = "Add points to the score when this object is destroyed.";
   };   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField("enable", "Enable this behavior.", "bool", true);
   %behavior.addBehaviorField("points", "Number of points to add. (Tip: Can be negative.)", "integer", 10);
   %behavior.addBehaviorField("counterName", "Name of the GUI to add points to.", "default", "scoreCounter" );
}

function onRemoveIncrementCounter::onRemove(%this, %scenegraph) 
{
   //echo("onRemoveIncrementCounter::onRemove( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(!%this.enable) return;
   
   if(isObject(%this.counterName))
   {
      %this.counterName.increment( %this.points );
   }
   
}