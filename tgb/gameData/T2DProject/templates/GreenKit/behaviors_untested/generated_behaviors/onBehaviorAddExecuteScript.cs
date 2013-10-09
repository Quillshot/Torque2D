//EVENT ATOM DETAILS
//   Category: Behavior Callbacks
//Subcategory: Initialization
// Event Name: onBehaviorAdd

//ACTION ATOM DETAILS
//   Category: Roaming Gamer Atoms
//Subcategory: Scripting
//Action Name: ExecuteScript

//registerAtom( action | event | full, "Category", "SubCategory", "BehaviorName" );

if (!isObject(onBehaviorAddExecuteScript))
{
   %behavior = new BehaviorTemplate(onBehaviorAddExecuteScript) 
   { 

      friendlyName = "onBehaviorAdd() -> ExecuteScript";
      behaviorType = "Initialization Event -> Scripting";
      description = "When this behavior is added to the owner object execute the specified torque script. (Can be any valid Torque Script code.)";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "theScript", "Specify the torque script code to execute here. ", "default", "echo(RoamingGamer);");   
}

function onBehaviorAddExecuteScript::onBehaviorAdd(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onBehaviorAdd()");

   //Event Atom Code:onBehaviorAdd() ->
   %this.executeAction();

}//onBehaviorAdd

function onBehaviorAddExecuteScript::executeAction(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::executeAction()");

   //Action Atom Code:ExecuteScript
   %evalScript = %this.theScript;
   //error( %evalScript );
   eval( %evalScript );   

}//executeAction

