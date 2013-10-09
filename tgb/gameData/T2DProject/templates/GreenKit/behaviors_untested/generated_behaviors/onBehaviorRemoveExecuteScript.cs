//EVENT ATOM DETAILS
//   Category: Behavior Callbacks
//Subcategory: Initialization
// Event Name: onBehaviorRemove

//ACTION ATOM DETAILS
//   Category: Roaming Gamer Atoms
//Subcategory: Scripting
//Action Name: ExecuteScript

//registerAtom( action | event | full, "Category", "SubCategory", "BehaviorName" );

if (!isObject(onBehaviorRemoveExecuteScript))
{
   %behavior = new BehaviorTemplate(onBehaviorRemoveExecuteScript) 
   { 

      friendlyName = "onBehaviorRemove() -> ExecuteScript";
      behaviorType = "Initialization Event -> Scripting";
      description = "When this behavior is removed from the owner object execute the specified torque script. (Can be any valid Torque Script code.)";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "theScript", "Specify the torque script code to execute here. ", "default", "echo(RoamingGamer);");   
}

function onBehaviorRemoveExecuteScript::onBehaviorRemove(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onBehaviorRemove()");

   //Event Atom Code:onBehaviorRemove() ->
   %this.executeAction();

}//onBehaviorRemove

function onBehaviorRemoveExecuteScript::executeAction(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::executeAction()");

   //Action Atom Code:ExecuteScript
   %evalScript = %this.theScript;
   //error( %evalScript );
   eval( %evalScript );   

}//executeAction

