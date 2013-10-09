//EVENT ATOM DETAILS
//   Category: Behavior Callbacks
//Subcategory: Trigger
// Event Name: onLeave

//ACTION ATOM DETAILS
//   Category: Roaming Gamer Atoms
//Subcategory: Scripting
//Action Name: ExecuteScript

//registerAtom( action | event | full, "Category", "SubCategory", "BehaviorName" );

if (!isObject(onLeaveExecuteScript))
{
   %behavior = new BehaviorTemplate(onLeaveExecuteScript) 
   { 

      friendlyName = "onLeave() -> ExecuteScript";
      behaviorType = "Animation Event -> Scripting";
      description = "When an object leaves this trigger execute the specified torque script. (Can be any valid Torque Script code.)";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "theScript", "Specify the torque script code to execute here. ", "default", "echo(RoamingGamer);");   
}

function onLeaveExecuteScript::onAddToScene(%this, %scenegraph)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onAddToScene()");

   //Event Atom Code:onLeave() ->
   %this.owner.setLeaveCallback(true);

}//onAddToScene

function onLeaveExecuteScript::onLeave(%this, %object)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onLeave()");

   //Event Atom Code:onLeave() ->
   %this.executeAction();

}//onLeave

function onLeaveExecuteScript::executeAction(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::executeAction()");

   //Action Atom Code:ExecuteScript
   %evalScript = %this.theScript;
   //error( %evalScript );
   eval( %evalScript );   

}//executeAction

