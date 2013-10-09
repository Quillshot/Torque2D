//EVENT ATOM DETAILS
//   Category: Behavior Callbacks
//Subcategory: Animation
// Event Name: onFrameChange

//ACTION ATOM DETAILS
//   Category: Roaming Gamer Atoms
//Subcategory: Scripting
//Action Name: ExecuteScript

//registerAtom( action | event | full, "Category", "SubCategory", "BehaviorName" );

if (!isObject(onFrameChangeExecuteScript))
{
   %behavior = new BehaviorTemplate(onFrameChangeExecuteScript) 
   { 

      friendlyName = "onFrameChange() -> ExecuteScript";
      behaviorType = "Animation Event -> Scripting";
      description = "When this object's image changes frames (during animation) execute the specified torque script. (Can be any valid Torque Script code.)";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "theScript", "Specify the torque script code to execute here. ", "default", "echo(RoamingGamer);");   
}

function onFrameChangeExecuteScript::onFrameChange(%this, %frame)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onFrameChange()");

   //Event Atom Code:onFrameChange() ->
   %this.executeAction();

}//onFrameChange

function onFrameChangeExecuteScript::executeAction(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::executeAction()");

   //Action Atom Code:ExecuteScript
   %evalScript = %this.theScript;
   //error( %evalScript );
   eval( %evalScript );   

}//executeAction

