//EVENT ATOM DETAILS
//   Category: Behavior Callbacks
//Subcategory: Game
// Event Name: onCollision

//ACTION ATOM DETAILS
//   Category: Roaming Gamer Atoms
//Subcategory: Scripting
//Action Name: ExecuteScript

//registerAtom( action | event | full, "Category", "SubCategory", "BehaviorName" );

if (!isObject(onCollisionExecuteScript))
{
   %behavior = new BehaviorTemplate(onCollisionExecuteScript) 
   { 

      friendlyName = "onCollision() -> ExecuteScript";
      behaviorType = "Game Event -> Scripting";
      description = "When this object collides with another object execute the specified torque script. (Can be any valid Torque Script code.)";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "theScript", "Specify the torque script code to execute here. ", "default", "echo(RoamingGamer);");   
}

function onCollisionExecuteScript::onAddToScene(%this, %scenegraph)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onAddToScene()");

   //Event Atom Code:onCollision() ->
   %this.owner.setUseMouseEvents(true);
   sceneWindow2D.setUseObjectMouseEvents(1);

}//onAddToScene

function onCollisionExecuteScript::onCollision(%this, %dstObj, %srcRef, %dstRef, %time, %normal, %contacts, %points)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onCollision()");

   //Event Atom Code:onCollision() ->
   //%dstObj - The object that is being collided with.
   //%srcRef - Custom information set by the source object. Only used by t2dTileLayer to pass the logical tile position of the tile that is colliding.
   //%dstRef - Custom information set by the destination object. Only used by t2dTileLayer to pass the logical tile position of the tile that is collided with.
   //%time - The time since the previous tick when the collision happened.
   //%normal - The normal vector of the collision.
   //%contacts - The number of contacts in the collision.
   //%points - The list of contact points.
   %this.executeAction();

}//onCollision

function onCollisionExecuteScript::executeAction(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::executeAction()");

   //Action Atom Code:ExecuteScript
   %evalScript = %this.theScript;
   //error( %evalScript );
   eval( %evalScript );   

}//executeAction

