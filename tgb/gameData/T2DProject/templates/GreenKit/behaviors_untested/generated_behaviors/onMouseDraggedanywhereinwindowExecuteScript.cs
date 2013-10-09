//EVENT ATOM DETAILS
//   Category: Behavior Callbacks
//Subcategory: Mouse (anywhere in window)
// Event Name: onMouseDragged

//ACTION ATOM DETAILS
//   Category: Roaming Gamer Atoms
//Subcategory: Scripting
//Action Name: ExecuteScript

//registerAtom( action | event | full, "Category", "SubCategory", "BehaviorName" );

if (!isObject(onMouseDraggedanywhereinwindowExecuteScript))
{
   %behavior = new BehaviorTemplate(onMouseDraggedanywhereinwindowExecuteScript) 
   { 

      friendlyName = "onMouseDragged() (anywhere in window) -> ExecuteScript";
      behaviorType = "Mouse Event -> Scripting";
      description = "When mouse is left-clicked in window area execute the specified torque script. (Can be any valid Torque Script code.)";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "theScript", "Specify the torque script code to execute here. ", "default", "echo(RoamingGamer);");   
}

function onMouseDraggedanywhereinwindowExecuteScript::onAddToScene(%this, %scenegraph)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onAddToScene()");

   //Event Atom Code:onMouseDragged() (anywhere in window) ->
   %this.owner.setUseMouseEvents(true);
   %this.owner.setMouseLocked(true);
   //sceneWindow2D.setUseObjectMouseEvents(1);

}//onAddToScene

function onMouseDraggedanywhereinwindowExecuteScript::onMouseDragged(%this, %modifier, %worldPos)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onMouseDragged()");

   //Event Atom Code:onMouseDragged() (anywhere in window) ->
   %this.executeAction();

}//onMouseDragged

function onMouseDraggedanywhereinwindowExecuteScript::executeAction(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::executeAction()");

   //Action Atom Code:ExecuteScript
   %evalScript = %this.theScript;
   //error( %evalScript );
   eval( %evalScript );   

}//executeAction

