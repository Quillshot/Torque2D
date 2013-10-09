
if (!isObject(onRemoveRespawnIfLives))
{
   %behavior = new BehaviorTemplate(onRemoveRespawnIfLives)
   {
      friendlyName = "onRemove() Respawn If Has Lives";
      behaviorType = "40 - Game Logic (Lives)";
      description  = "Respawn this object if there are lives remaining on a lives counter.";
   };   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField("enable", "Enable this behavior.", "bool", true);
   %behavior.addBehaviorField("debugMode", "Enable debugging output for this behavior.", bool, false);
   %behavior.addBehaviorField("respawnDelay", "Time to wait till respawn.", "integer", 1000);
   %behavior.addBehaviorField("counterName", "Name of the GUI containing lives count.", "default", "livesCounter" );
   %behavior.addBehaviorField("builderScriptName", "Name of builder script to call in order to spawn.", "default", "bobBuilder" );
}

function onRemoveRespawnIfLives::onRemove(%this) 
{
   if(!%this.debugMode) echo("onRemoveRespawnIfLives::onRemove( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(!%this.enable) return;
   
   if(isObject(%this.counterName))
   {
      if(%this.counterName.getValue() > 0 )
      {
         %position = %this.owner.getPosition();
         %scenegraph = %this.owner.getScenegraph();
         %this.counterName.decrement( 1 );
         
         if(!%this.debugMode) echo(" scheduling builder script: ", %this.builderScriptName, " @ t+", %this.respawnDelay );
         if(!%this.debugMode) echo( %scenegraph );
         if(!%this.debugMode) echo( %position );
         
         schedule( %this.respawnDelay, %scenegraph, %this.builderScriptName, %scenegraph, %position );

      }
   }
   
}