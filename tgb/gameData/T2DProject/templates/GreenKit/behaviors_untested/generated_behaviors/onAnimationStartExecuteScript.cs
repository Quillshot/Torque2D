//EVENT ATOM DETAILS
//   Category: Behavior Callbacks
//Subcategory: Animation
// Event Name: onAnimationStart

//ACTION ATOM DETAILS
//   Category: Roaming Gamer Atoms
//Subcategory: Scripting
//Action Name: ExecuteScript

//registerAtom( action | event | full, "Category", "SubCategory", "BehaviorName" );

if (!isObject(onAnimationStartExecuteScript))
{
   %behavior = new BehaviorTemplate(onAnimationStartExecuteScript) 
   { 

      friendlyName = "onAnimationStart() -> ExecuteScript";
      behaviorType = "Animation Event -> Scripting";
      description = "When this object's image starts animating execute the specified torque script. (Can be any valid Torque Script code.)";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "theScript", "Specify the torque script code to execute here. ", "default", "echo(RoamingGamer);");   
}

function onAnimationStartExecuteScript::onAnimationStart(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onAnimationStart()");

   //Event Atom Code:onAnimationStart() ->
   %this.executeAction();

}//onAnimationStart

function onAnimationStartExecuteScript::executeAction(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::executeAction()");

   //Action Atom Code:ExecuteScript
   %evalScript = %this.theScript;
   //error( %evalScript );
   eval( %evalScript );   

}//executeAction

