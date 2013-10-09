//EVENT ATOM DETAILS
//   Category: Behavior Callbacks
//Subcategory: Game
// Event Name: onTimer

//ACTION ATOM DETAILS
//   Category: Roaming Gamer Atoms
//Subcategory: Scripting
//Action Name: ExecuteScript

//registerAtom( action | event | full, "Category", "SubCategory", "BehaviorName" );

if (!isObject(onTimerExecuteScript))
{
   %behavior = new BehaviorTemplate(onTimerExecuteScript) 
   { 

      friendlyName = "onTimer() -> ExecuteScript";
      behaviorType = "Game Event -> Scripting";
      description = "When this object's timer event occurs execute the specified torque script. (Can be any valid Torque Script code.)";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "theScript", "Specify the torque script code to execute here. ", "default", "echo(RoamingGamer);");   
}

function onTimerExecuteScript::onAddToScene(%this, %scenegraph)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onAddToScene()");

   //Event Atom Code:onTimer() ->
   %this.owner.setUseMouseEvents(true);
   sceneWindow2D.setUseObjectMouseEvents(1);

}//onAddToScene

function onTimerExecuteScript::onTimer(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onTimer()");

   //Event Atom Code:onTimer() ->
   %this.executeAction();

}//onTimer

function onTimerExecuteScript::executeAction(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::executeAction()");

   //Action Atom Code:ExecuteScript
   %evalScript = %this.theScript;
   //error( %evalScript );
   eval( %evalScript );   

}//executeAction

