//------------------------------------------------------
// Copyright, Roaming Gamer, LLC.
//------------------------------------------------------
if (!isObject(usePolygonCollisionDetection))
{
   %behavior = new BehaviorTemplate(usePolygonCollisionDetection)
   {
      friendlyName = "Use Polygon Collision Detection";
      behaviorType = "04 - Collision Detection and Response";
      description  = "This object uses a (user-defined) polygon to test for collisions.";
   };
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
}

function usePolygonCollisionDetection::onBehaviorAdd(%this) 
{
   if(!%this.enable) return;
   %this.owner.CollisionDetectionMode= "POLYGON";
}

function usePolygonCollisionDetection::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   %this.owner.CollisionDetectionMode= "POLYGON";
}