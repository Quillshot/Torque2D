// This behavior generated by the Roaming Gamer Behavior Generator
//ACTION ATOM DETAILS
//   Category: 00 - Rapid Prototyping
//Subcategory: Level Management
//Action Name: onKeyUpReloadCurrentLevel

//registerAtom( action | event | full, "Category", "SubCategory", "BehaviorName" );

if (!isObject(onKeyUpReloadCurrentLevel))
{
   %behavior = new BehaviorTemplate(onKeyUpReloadCurrentLevel) 
   { 

      friendlyName = "onKeyUp() -> reloadCurrentLevel";
      behaviorType = "00 - Rapid Prototyping / Level Management";
      description = "When a key is released reload the current level.";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "actionKey",   "Key that is pressed to cause an action.", keybind, "Keyboard space" );
}

function onKeyUpReloadCurrentLevel::onAddToScene(%this, %scenegraph)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onAddToScene()");

   //Action Atom Code:onKeyUp() -> reloadCurrentLevel
   //Event Atom Code:onKeyUp() ->
   moveMap.bindCmd( getWord(%this.actionKey, 0), 
                    getWord(%this.actionKey, 1), 
                    "",
                    "sceneWindow2D.reloadCurrentLevel();" );

}//onAddToScene

