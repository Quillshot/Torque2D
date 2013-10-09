//EVENT ATOM DETAILS
//   Category: Behavior Callbacks
//Subcategory: Trigger
// Event Name: onEnter

//ACTION ATOM DETAILS
//   Category: Roaming Gamer Atoms
//Subcategory: Scripting
//Action Name: ExecuteScript

//registerAtom( action | event | full, "Category", "SubCategory", "BehaviorName" );

if (!isObject(onEnterExecuteScript))
{
   %behavior = new BehaviorTemplate(onEnterExecuteScript) 
   { 

      friendlyName = "onEnter() -> ExecuteScript";
      behaviorType = "Trigger Event -> Scripting";
      description = "When an object enters this trigger execute the specified torque script. (Can be any valid Torque Script code.)";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "theScript", "Specify the torque script code to execute here. ", "default", "echo(RoamingGamer);");   
}

function onEnterExecuteScript::onAddToScene(%this, %scenegraph)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onAddToScene()");

   //Event Atom Code:onEnter() ->
   %this.owner.setEnterCallback(true);

}//onAddToScene

function onEnterExecuteScript::onEnter(%this, %object)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onEnter()");

   //Event Atom Code:onEnter() ->
   %this.executeAction();

}//onEnter

function onEnterExecuteScript::executeAction(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::executeAction()");

   //Action Atom Code:ExecuteScript
   %evalScript = %this.theScript;
   //error( %evalScript );
   eval( %evalScript );   

}//executeAction

