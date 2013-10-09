if (!isObject(onMouseDownWindowExecuteScript))
{
   %behavior = new BehaviorTemplate(onMouseDownWindowExecuteScript) 
   { 

      friendlyName = "onMouseDown() (anywhere in window) -> ExecuteScript";
      behaviorType = "90 - Miscellaneous";
      description = "When mouse is left-clicked in window area execute the specified torque script. (Can be any valid Torque Script code.)";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "theScript", "Specify the torque script code to execute here. ", "default", "echo(RoamingGamer);");   
}

function onMouseDownWindowExecuteScript::onAddToScene(%this, %scenegraph)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onAddToScene()");

   %this.owner.setUseMouseEvents(true);
   %this.owner.setMouseLocked(true);
   //sceneWindow2D.setUseObjectMouseEvents(1);

}//onAddToScene

function onMouseDownWindowExecuteScript::onMouseDown(%this, %modifier, %worldPos)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onMouseDown()");

   %this.executeAction();

}//onMouseDown

function onMouseDownWindowExecuteScript::executeAction(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::executeAction()");

   %evalScript = %this.theScript;
   if(%this.debugMode) echo( %evalScript );
   eval( %evalScript );   

}//executeAction

