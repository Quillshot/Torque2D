//EVENT ATOM DETAILS
//   Category: Behavior Callbacks
//Subcategory: Mouse (anywhere in window)
// Event Name: onRightMouseDragged

//ACTION ATOM DETAILS
//   Category: Roaming Gamer Atoms
//Subcategory: Scripting
//Action Name: ExecuteScript

//registerAtom( action | event | full, "Category", "SubCategory", "BehaviorName" );

if (!isObject(onRightMouseDraggedanywhereinwindowExecuteScript))
{
   %behavior = new BehaviorTemplate(onRightMouseDraggedanywhereinwindowExecuteScript) 
   { 

      friendlyName = "onRightMouseDragged() (anywhere in window) -> ExecuteScript";
      behaviorType = "Mouse Event -> Scripting";
      description = "When mouse is left-clicked in window area execute the specified torque script. (Can be any valid Torque Script code.)";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "theScript", "Specify the torque script code to execute here. ", "default", "echo(RoamingGamer);");   
}

function onRightMouseDraggedanywhereinwindowExecuteScript::onAddToScene(%this, %scenegraph)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onAddToScene()");

   //Event Atom Code:onRightMouseDragged() (anywhere in window) ->
   %this.owner.setUseMouseEvents(true);
   %this.owner.setMouseLocked(true);
   //sceneWindow2D.setUseObjectMouseEvents(1);

}//onAddToScene

function onRightMouseDraggedanywhereinwindowExecuteScript::onRightMouseDragged(%this, %modifier, %worldPos)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onRightMouseDragged()");

   //Event Atom Code:onRightMouseDragged() (anywhere in window) ->
   %this.executeAction();

}//onRightMouseDragged

function onRightMouseDraggedanywhereinwindowExecuteScript::executeAction(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::executeAction()");

   //Action Atom Code:ExecuteScript
   %evalScript = %this.theScript;
   //error( %evalScript );
   eval( %evalScript );   

}//executeAction
