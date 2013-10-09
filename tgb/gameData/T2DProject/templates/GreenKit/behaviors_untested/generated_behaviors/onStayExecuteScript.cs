//EVENT ATOM DETAILS
//   Category: Behavior Callbacks
//Subcategory: Trigger
// Event Name: onStay

//ACTION ATOM DETAILS
//   Category: Roaming Gamer Atoms
//Subcategory: Scripting
//Action Name: ExecuteScript

//registerAtom( action | event | full, "Category", "SubCategory", "BehaviorName" );

if (!isObject(onStayExecuteScript))
{
   %behavior = new BehaviorTemplate(onStayExecuteScript) 
   { 

      friendlyName = "onStay() -> ExecuteScript";
      behaviorType = "Animation Event -> Scripting";
      description = "When an object stays in this trigger (every tick) execute the specified torque script. (Can be any valid Torque Script code.)";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "theScript", "Specify the torque script code to execute here. ", "default", "echo(RoamingGamer);");   
}

function onStayExecuteScript::onAddToScene(%this, %scenegraph)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onAddToScene()");

   //Event Atom Code:onStay() ->
   %this.owner.setStayCallback(true);

}//onAddToScene

function onStayExecuteScript::onStay(%this, %object)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onStay()");

   //Event Atom Code:onStay() ->
   %this.executeAction();

}//onStay

function onStayExecuteScript::executeAction(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::executeAction()");

   //Action Atom Code:ExecuteScript
   %evalScript = %this.theScript;
   //error( %evalScript );
   eval( %evalScript );   

}//executeAction

