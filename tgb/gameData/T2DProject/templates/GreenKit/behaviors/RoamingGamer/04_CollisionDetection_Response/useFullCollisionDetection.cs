//------------------------------------------------------
// Copyright, Roaming Gamer, LLC.
//------------------------------------------------------

//EFM - box may be wrong

if (!isObject(useFullCollisionDetection))
{
   %behavior = new BehaviorTemplate(useFullCollisionDetection)
   {
      friendlyName = "Use Full Collision Detection";
      behaviorType = "04 - Collision Detection and Response";
      description  = "This object uses full collision detection (circle pre-detection followed by polygon detection).";
   };
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
}

function useFullCollisionDetection::onBehaviorAdd(%this) 
{
   if(!%this.enable) return;
   %this.owner.setCollisionDetection("FULL");
}

function useFullCollisionDetection::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   %this.owner.setCollisionDetection("FULL");
}