if (!isObject(onTimer_Destroy))
{
   %behavior = new BehaviorTemplate(onTimer_Destroy) 
   { 
      friendlyName = "Destroy after Delay";
      behaviorType = "05 - Damage and Energy";
      description  = "This object self-destructs after a fixed period of time. (Not same as \"Safe Delete\"!  Starts onDestroyed() response chain.)";
   };
   %behavior.addValidObjectClass("t2dSceneObject");
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debuging for this behavior.", bool, false);
   
   %behavior.addBehaviorField(delay, "Wait this many milliseconds and then destroy object.", integer, 100);
   
}

function onTimer_Destroy::onAddToScene(%this, %scenegraph)
{
   if(!%this.enable) return;

   %this.owner.setTimerOn( %this.delay );
}

function onTimer_Destroy::onTimer(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("onTimer_Destroy::onTimer()");

   %this.owner.setTimerOff();
   
   %damageBehavior = %this.owner.getBehavior( "takesDamage" ); 
    
   if( !isObject(%damageBehavior) ) return; // Not using damage behavior, can't destroy object!
     
   %damageBehavior.destroyObject();
}

