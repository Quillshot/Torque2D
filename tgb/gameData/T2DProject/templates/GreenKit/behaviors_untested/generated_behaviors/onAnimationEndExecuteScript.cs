//EVENT ATOM DETAILS
//   Category: Behavior Callbacks
//Subcategory: Animation
// Event Name: onAnimationEnd

//ACTION ATOM DETAILS
//   Category: Roaming Gamer Atoms
//Subcategory: Scripting
//Action Name: ExecuteScript

//registerAtom( action | event | full, "Category", "SubCategory", "BehaviorName" );

if (!isObject(onAnimationEndExecuteScript))
{
   %behavior = new BehaviorTemplate(onAnimationEndExecuteScript) 
   { 

      friendlyName = "onAnimationEnd() -> ExecuteScript";
      behaviorType = "Animation Event -> Scripting";
      description = "When this object's image stops animating execute the specified torque script. (Can be any valid Torque Script code.)";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "theScript", "Specify the torque script code to execute here. ", "default", "echo(RoamingGamer);");   
}

function onAnimationEndExecuteScript::onAnimationEnd(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onAnimationEnd()");

   //Event Atom Code:onAnimationEnd() ->
   %this.executeAction();

}//onAnimationEnd

function onAnimationEndExecuteScript::executeAction(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::executeAction()");

   //Action Atom Code:ExecuteScript
   %evalScript = %this.theScript;
   //error( %evalScript );
   eval( %evalScript );   

}//executeAction

