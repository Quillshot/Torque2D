//EVENT ATOM DETAILS
//   Category: Behavior Callbacks
//Subcategory: Mouse (over object)
// Event Name: onRightMouseUp

//ACTION ATOM DETAILS
//   Category: Roaming Gamer Atoms
//Subcategory: Scripting
//Action Name: ExecuteScript

//registerAtom( action | event | full, "Category", "SubCategory", "BehaviorName" );

if (!isObject(onRightMouseUpoverobjectExecuteScript))
{
   %behavior = new BehaviorTemplate(onRightMouseUpoverobjectExecuteScript) 
   { 

      friendlyName = "onRightMouseUp() (over object) -> ExecuteScript";
      behaviorType = "Mouse Event -> Scripting";
      description = "When mouse is left-clicked in object area execute the specified torque script. (Can be any valid Torque Script code.)";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "theScript", "Specify the torque script code to execute here. ", "default", "echo(RoamingGamer);");   
}

function onRightMouseUpoverobjectExecuteScript::onAddToScene(%this, %scenegraph)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onAddToScene()");

   //Event Atom Code:onRightMouseUp() (over object) ->
   %this.owner.setUseMouseEvents(true);
   //sceneWindow2D.setUseObjectMouseEvents(1);

}//onAddToScene

function onRightMouseUpoverobjectExecuteScript::onRightMouseUp(%this, %modifier, %worldPos)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onRightMouseUp()");

   //Event Atom Code:onRightMouseUp() (over object) ->
   %this.executeAction();

}//onRightMouseUp

function onRightMouseUpoverobjectExecuteScript::executeAction(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::executeAction()");

   //Action Atom Code:ExecuteScript
   %evalScript = %this.theScript;
   //error( %evalScript );
   eval( %evalScript );   

}//executeAction

