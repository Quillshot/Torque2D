//EVENT ATOM DETAILS
//   Category: Behavior Callbacks
//Subcategory: Game
// Event Name: onPositionTarget

//ACTION ATOM DETAILS
//   Category: Roaming Gamer Atoms
//Subcategory: Scripting
//Action Name: ExecuteScript

//registerAtom( action | event | full, "Category", "SubCategory", "BehaviorName" );

if (!isObject(onPositionTargetExecuteScript))
{
   %behavior = new BehaviorTemplate(onPositionTargetExecuteScript) 
   { 

      friendlyName = "onPositionTarget() -> ExecuteScript";
      behaviorType = "Game Event -> Scripting";
      description = "When the object completes a moveTo() (with callback == true) action execute the specified torque script. (Can be any valid Torque Script code.)";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "theScript", "Specify the torque script code to execute here. ", "default", "echo(RoamingGamer);");   
}

function onPositionTargetExecuteScript::onAddToScene(%this, %scenegraph)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onAddToScene()");

   //Event Atom Code:onPositionTarget() ->
   %this.owner.setUseMouseEvents(true);
   sceneWindow2D.setUseObjectMouseEvents(1);

}//onAddToScene

function onPositionTargetExecuteScript::onPositionTarget(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onPositionTarget()");

   //Event Atom Code:onPositionTarget() ->
   %this.executeAction();

}//onPositionTarget

function onPositionTargetExecuteScript::executeAction(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::executeAction()");

   //Action Atom Code:ExecuteScript
   %evalScript = %this.theScript;
   //error( %evalScript );
   eval( %evalScript );   

}//executeAction

