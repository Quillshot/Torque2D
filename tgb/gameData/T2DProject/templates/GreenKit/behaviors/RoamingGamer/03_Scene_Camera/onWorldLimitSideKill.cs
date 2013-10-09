if (!isObject(onWorldLimitSideKill))
{
   %behavior = new BehaviorTemplate(onWorldLimitSideKill)
   {
      friendlyName = "Kill on World Limit Side(s)";
      behaviorType = "03 - Scene and Camera";
      description  = "Kill this object on collision with top, left, bottom, right (each selectable).";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);
   %behavior.addBehaviorField(killTop, "Kill object on collision with top.", bool, true);
   %behavior.addBehaviorField(killBottom, "Kill object on collision with top.", bool, true);
   %behavior.addBehaviorField(killLeft, "Kill object on collision with top.", bool, true);
   %behavior.addBehaviorField(killRight, "Kill object on collision with top.", bool, true);
}

//
// Behavior Methods and Callbacks
//
function onWorldLimitSideKill::onBehaviorAdd(%this)
{
   if(!%this.enable) return;
   //%this.owner.worldLimitMode = "NULL";
   %this.owner.worldLimitCallback = true;
}


function onWorldLimitSideKill::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   //%this.owner.worldLimitMode = "NULL";
   %this.owner.worldLimitCallback = true;
}


// Instance Callbacks

function onWorldLimitSideKill::onAdd( %this ) 
{  
   if(%this.debugMode) echo("onWorldLimitSideKill::onAdd( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}

function onWorldLimitSideKill::onRemove( %this ) 
{   
   if(%this.debugMode) echo("onWorldLimitSideKill::onRemove( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}

function onWorldLimitSideKill::onWorldLimit(%this, %limitMode, %limit)
{
   if(!%this.enable) return;
   switch$ (%limit)
   {
      case "left":
         if (%this.killLeft) 
         {
            %this.owner.safeDelete();
         }
            
      case "right":
         if (%this.killRight) 
         {
            %this.owner.safeDelete();
         }

      case "top":
         if (%this.killTop) 
         {
            %this.owner.safeDelete();
         }

      case "bottom":
         if (%this.killBottom) 
         {
            %this.owner.safeDelete();
         }
   }
}
