//EVENT ATOM DETAILS
//   Category: Behavior Callbacks
//Subcategory: Mouse (over object)
// Event Name: onMouseDown

//ACTION ATOM DETAILS
//   Category: Roaming Gamer Atoms
//Subcategory: Scripting
//Action Name: ExecuteScript

//registerAtom( action | event | full, "Category", "SubCategory", "BehaviorName" );

if (!isObject(onMouseDownoverobjectExecuteScript))
{
   %behavior = new BehaviorTemplate(onMouseDownoverobjectExecuteScript) 
   { 

      friendlyName = "onMouseDown() (over object) -> ExecuteScript";
      behaviorType = "Mouse Event -> Scripting";
      description = "When mouse is left-clicked in object area execute the specified torque script. (Can be any valid Torque Script code.)";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "theScript", "Specify the torque script code to execute here. ", "default", "echo(RoamingGamer);");   
}

function onMouseDownoverobjectExecuteScript::onAddToScene(%this, %scenegraph)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onAddToScene()");

   //Event Atom Code:onMouseDown() (over object) ->
   %this.owner.setUseMouseEvents(true);
   //sceneWindow2D.setUseObjectMouseEvents(1);

}//onAddToScene

function onMouseDownoverobjectExecuteScript::onMouseDown(%this, %modifier, %worldPos)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onMouseDown()");

   //Event Atom Code:onMouseDown() (over object) ->
   %this.executeAction();

}//onMouseDown

function onMouseDownoverobjectExecuteScript::executeAction(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::executeAction()");

   //Action Atom Code:ExecuteScript
   %evalScript = %this.theScript;
   //error( %evalScript );
   eval( %evalScript );   

}//executeAction

