//EVENT ATOM DETAILS
//   Category: Behavior Callbacks
//Subcategory: Mouse (over object)
// Event Name: onMouseMove

//ACTION ATOM DETAILS
//   Category: Roaming Gamer Atoms
//Subcategory: Scripting
//Action Name: ExecuteScript

//registerAtom( action | event | full, "Category", "SubCategory", "BehaviorName" );

if (!isObject(onMouseMoveoverobjectExecuteScript))
{
   %behavior = new BehaviorTemplate(onMouseMoveoverobjectExecuteScript) 
   { 

      friendlyName = "onMouseMove() (over object) -> ExecuteScript";
      behaviorType = "Mouse Event -> Scripting";
      description = "When mouse is left-clicked in object area execute the specified torque script. (Can be any valid Torque Script code.)";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "theScript", "Specify the torque script code to execute here. ", "default", "echo(RoamingGamer);");   
}

function onMouseMoveoverobjectExecuteScript::onAddToScene(%this, %scenegraph)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onAddToScene()");

   //Event Atom Code:onMouseMove() (over object) ->
   %this.owner.setUseMouseEvents(true);
   //sceneWindow2D.setUseObjectMouseEvents(1);

}//onAddToScene

function onMouseMoveoverobjectExecuteScript::onMouseMove(%this, %modifier, %worldPos)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onMouseMove()");

   //Event Atom Code:onMouseMove() (over object) ->
   %this.executeAction();

}//onMouseMove

function onMouseMoveoverobjectExecuteScript::executeAction(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::executeAction()");

   //Action Atom Code:ExecuteScript
   %evalScript = %this.theScript;
   //error( %evalScript );
   eval( %evalScript );   

}//executeAction

