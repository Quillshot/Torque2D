//EVENT ATOM DETAILS
//   Category: Behavior Callbacks
//Subcategory: Initialization
// Event Name: onLevelEnded

//ACTION ATOM DETAILS
//   Category: Roaming Gamer Atoms
//Subcategory: Scripting
//Action Name: ExecuteScript

//registerAtom( action | event | full, "Category", "SubCategory", "BehaviorName" );

if (!isObject(onLevelEndedExecuteScript))
{
   %behavior = new BehaviorTemplate(onLevelEndedExecuteScript) 
   { 

      friendlyName = "onLevelEnded() -> ExecuteScript";
      behaviorType = "Initialization Event -> Scripting";
      description = "When a level ends execute the specified torque script. (Can be any valid Torque Script code.)";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "theScript", "Specify the torque script code to execute here. ", "default", "echo(RoamingGamer);");   
}

function onLevelEndedExecuteScript::onLevelEnded(%this, %scenegraph)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onLevelEnded()");

   //Event Atom Code:onLevelEnded() ->
   %this.executeAction();

}//onLevelEnded

function onLevelEndedExecuteScript::executeAction(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::executeAction()");

   //Action Atom Code:ExecuteScript
   %evalScript = %this.theScript;
   //error( %evalScript );
   eval( %evalScript );   

}//executeAction

