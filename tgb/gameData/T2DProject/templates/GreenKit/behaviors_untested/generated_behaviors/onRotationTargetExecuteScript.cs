//EVENT ATOM DETAILS
//   Category: Behavior Callbacks
//Subcategory: Game
// Event Name: onRotationTarget

//ACTION ATOM DETAILS
//   Category: Roaming Gamer Atoms
//Subcategory: Scripting
//Action Name: ExecuteScript

//registerAtom( action | event | full, "Category", "SubCategory", "BehaviorName" );

if (!isObject(onRotationTargetExecuteScript))
{
   %behavior = new BehaviorTemplate(onRotationTargetExecuteScript) 
   { 

      friendlyName = "onRotationTarget() -> ExecuteScript";
      behaviorType = "Game Event -> Scripting";
      description = "When the object completes a rotateTo() (with callback == true) action execute the specified torque script. (Can be any valid Torque Script code.)";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "theScript", "Specify the torque script code to execute here. ", "default", "echo(RoamingGamer);");   
}

function onRotationTargetExecuteScript::onAddToScene(%this, %scenegraph)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onAddToScene()");

   //Event Atom Code:onRotationTarget() ->
   %this.owner.setUseMouseEvents(true);
   sceneWindow2D.setUseObjectMouseEvents(1);

}//onAddToScene

function onRotationTargetExecuteScript::onRotationTarget(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onRotationTarget()");

   //Event Atom Code:onRotationTarget() ->
   %this.executeAction();

}//onRotationTarget

function onRotationTargetExecuteScript::executeAction(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::executeAction()");

   //Action Atom Code:ExecuteScript
   %evalScript = %this.theScript;
   //error( %evalScript );
   eval( %evalScript );   

}//executeAction

