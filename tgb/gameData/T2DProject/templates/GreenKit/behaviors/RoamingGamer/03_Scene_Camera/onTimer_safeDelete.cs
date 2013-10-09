if (!isObject(onTimer_safeDelete))
{
   %behavior = new BehaviorTemplate(onTimer_safeDelete) 
   { 
      friendlyName = "Safe Delete after Delay";
      behaviorType = "03 - Scene and Camera";
      description  = "Safely delete this object after a fixed period of time.";
   };
   %behavior.addValidObjectClass("t2dSceneObject");
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);
   %behavior.addBehaviorField(debugMode, "Enable debuging for this behavior.", bool, false);
   
   %behavior.addBehaviorField(delay, "Wait this many milliseconds and then safely delete object.", integer, 100);
   
}

function onTimer_safeDelete::onAddToScene(%this, %scenegraph)
{
   if(!%this.enable) return;

   %this.owner.setTimerOn( %this.delay );


}

function onTimer_safeDelete::onTimer(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("onTimer_safeDelete::onTimer()");

   %this.owner.setTimerOff();
   %this.owner.safeDelete();
}

