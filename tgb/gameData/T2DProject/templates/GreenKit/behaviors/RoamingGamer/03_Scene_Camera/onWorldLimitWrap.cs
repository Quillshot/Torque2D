if (!isObject(onWorldLimitWrap))
{
   %behavior = new BehaviorTemplate(onWorldLimitWrap)
   {
      friendlyName = "Wrap on World Limit";
      behaviorType = "03 - Scene and Camera";
      description  = "Wrap when world limit encountered.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);
}

//
// Behavior Methods and Callbacks
//
function onWorldLimitWrap::onBehaviorAdd(%this)
{
   if(!%this.enable) return;
   %this.owner.worldLimitMode = "NULL";
   %this.owner.worldLimitCallback = true;
}


function onWorldLimitWrap::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   %this.owner.worldLimitMode = "NULL";
   %this.owner.worldLimitCallback = true;
}


// Instance Callbacks

function onWorldLimitWrap::onAdd( %this ) 
{  
   if(%this.debugMode) echo("onWorldLimitWrap::onAdd( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}

function onWorldLimitWrap::onRemove( %this ) 
{   
   if(%this.debugMode) echo("onWorldLimitWrap::onRemove( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}

function onWorldLimitWrap::onWorldLimit(%this, %limitMode, %limit)
{
   if(!%this.enable) return;
   switch$ (%limit)
   {
      case "left":
         if (%this.owner.getLinearVelocityX() < 0)
            %this.owner.setPositionX(getWord(%this.owner.getWorldLimit(), 3) - (%this.owner.getWidth() / 2));
      case "right":
         if (%this.owner.getLinearVelocityX() > 0)
            %this.owner.setPositionX(getWord(%this.owner.getWorldLimit(), 1) + (%this.owner.getWidth() / 2));
      case "top":
         if (%this.owner.getLinearVelocityY() < 0)
            %this.owner.setPositionY(getWord(%this.owner.getWorldLimit(), 4) - (%this.owner.getHeight() / 2));
      case "bottom":
         if (%this.owner.getLinearVelocityY() > 0)
            %this.owner.setPositionY(getWord(%this.owner.getWorldLimit(), 2) + (%this.owner.getHeight() / 2));
   }
}
