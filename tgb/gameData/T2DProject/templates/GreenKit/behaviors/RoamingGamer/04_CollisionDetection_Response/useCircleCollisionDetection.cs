if (!isObject(useCircleCollisionDetection))
{
   %behavior = new BehaviorTemplate(useCircleCollisionDetection)
   {
      friendlyName = "Use Circle Collision Detection";
      behaviorType = "04 - Collision Detection and Response";
      description  = "This object uses a circle to test for collisions.";
   };
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   
   %behavior.addBehaviorField(CollisionCircleSuperscribed, "Superscribe circle.", bool, false);
   %behavior.addBehaviorField(CollisionCircleScale, "Scale of circle.", float, 1.0);
}

function useCircleCollisionDetection::onBehaviorAdd(%this)
{
   if(!%this.enable) return;
   %this.owner.setCollisionDetection("CIRCLE");
   if($LevelEditorActive) %this.schedule(0, refreshFields);
}

//EFM
// Trick - we want the object's fields updated as we modify this behavior's fields so
// that debug mode feedback is correct.
function useCircleCollisionDetection::refreshFields(%this)
{
   %this.owner.CollisionCircleSuperscribed = %this.CollisionCircleSuperscribed;
   %this.owner.CollisionCircleScale = %this.CollisionCircleScale;
   %this.schedule(500, refreshFields);
}

function useCircleCollisionDetection::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   %this.owner.setCollisionDetection("CIRCLE");
}