//EVENT ATOM DETAILS
//   Category: Behavior Callbacks
//Subcategory: Initialization
// Event Name: onLevelLoaded

//ACTION ATOM DETAILS
//   Category: Roaming Gamer Atoms
//Subcategory: Scripting
//Action Name: ExecuteScript

//registerAtom( action | event | full, "Category", "SubCategory", "BehaviorName" );

if (!isObject(onLevelLoadedExecuteScript))
{
   %behavior = new BehaviorTemplate(onLevelLoadedExecuteScript) 
   { 

      friendlyName = "onLevelLoaded() -> ExecuteScript";
      behaviorType = "Initialization Event -> Scripting";
      description = "When a level is loaded execute the specified torque script. (Can be any valid Torque Script code.)";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "theScript", "Specify the torque script code to execute here. ", "default", "echo(RoamingGamer);");   
}

function onLevelLoadedExecuteScript::onLevelLoaded(%this, %scenegraph)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onLevelLoaded()");

   //Event Atom Code:onLevelLoaded() ->
   %this.executeAction();

}//onLevelLoaded

function onLevelLoadedExecuteScript::executeAction(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::executeAction()");

   //Action Atom Code:ExecuteScript
   %evalScript = %this.theScript;
   //error( %evalScript );
   eval( %evalScript );   

}//executeAction

