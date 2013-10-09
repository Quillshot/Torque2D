//EVENT ATOM DETAILS
//   Category: Behavior Callbacks
//Subcategory: Game
// Event Name: onWorldLimit

//ACTION ATOM DETAILS
//   Category: Roaming Gamer Atoms
//Subcategory: Scripting
//Action Name: ExecuteScript

//registerAtom( action | event | full, "Category", "SubCategory", "BehaviorName" );

if (!isObject(onWorldLimitExecuteScript))
{
   %behavior = new BehaviorTemplate(onWorldLimitExecuteScript) 
   { 

      friendlyName = "onWorldLimit() -> ExecuteScript";
      behaviorType = "Game Event -> Scripting";
      description = "When this object hits/crosses it's world limit execute the specified torque script. (Can be any valid Torque Script code.)";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "theScript", "Specify the torque script code to execute here. ", "default", "echo(RoamingGamer);");   
}

function onWorldLimitExecuteScript::onAddToScene(%this, %scenegraph)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onAddToScene()");

   //Event Atom Code:onWorldLimit() ->
   %this.owner.setUseMouseEvents(true);
   sceneWindow2D.setUseObjectMouseEvents(1);

}//onAddToScene

function onWorldLimitExecuteScript::onWorldLimit(%this, %limitMode, %limit)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onWorldLimit()");

   //Event Atom Code:onWorldLimit() ->
   //%limitMode - The world limit response mode set on the object.
   //%limit - This is either "Left", "Right", "Top", or "Bottom", depending on the side of the world limit that was hit.   %this.owner.last[onWorldLimit,dstObj]   = %dstObj;
   %this.owner.last[onWorldLimit,limitMode]  = %limitMode;
   %this.owner.last[onWorldLimit,limit]      = %limit;
   %this.executeAction();

}//onWorldLimit

function onWorldLimitExecuteScript::executeAction(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::executeAction()");

   //Action Atom Code:ExecuteScript
   %evalScript = %this.theScript;
   //error( %evalScript );
   eval( %evalScript );   

}//executeAction

