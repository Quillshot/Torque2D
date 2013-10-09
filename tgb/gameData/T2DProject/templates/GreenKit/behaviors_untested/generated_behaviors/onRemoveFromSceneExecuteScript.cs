//EVENT ATOM DETAILS
//   Category: Behavior Callbacks
//Subcategory: Initialization
// Event Name: onRemoveFromScene

//ACTION ATOM DETAILS
//   Category: Roaming Gamer Atoms
//Subcategory: Scripting
//Action Name: ExecuteScript

//registerAtom( action | event | full, "Category", "SubCategory", "BehaviorName" );

if (!isObject(onRemoveFromSceneExecuteScript))
{
   %behavior = new BehaviorTemplate(onRemoveFromSceneExecuteScript) 
   { 

      friendlyName = "onRemoveFromScene() -> ExecuteScript";
      behaviorType = "Initialization Event -> Scripting";
      description = "When this object is removed from the scene execute the specified torque script. (Can be any valid Torque Script code.)";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "theScript", "Specify the torque script code to execute here. ", "default", "echo(RoamingGamer);");   
}

function onRemoveFromSceneExecuteScript::onRemoveFromScene(%this, %scenegraph)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onRemoveFromScene()");

   //Event Atom Code:onRemoveFromScene() ->
   %this.executeAction();

}//onRemoveFromScene

function onRemoveFromSceneExecuteScript::executeAction(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::executeAction()");

   //Action Atom Code:ExecuteScript
   %evalScript = %this.theScript;
   //error( %evalScript );
   eval( %evalScript );   

}//executeAction

