if (!isObject(moveThrustMouseDepressed))
{
   %behavior = new BehaviorTemplate(moveThrustMouseDepressed)
   {
      friendlyName = "Mouse Thrust";
      behaviorType = "01 - Movement Mouse";
      description  = "Accelerate forward while mouse button is depressed.";
   };
   %behavior.addValidObjectClass("t2dSceneObject");
   %behavior.addBehaviorField( "enable", "Enable behavior.", bool, true ); 
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);
   %behavior.addBehaviorField( "Thrust", "Thrusting power.", float, 100 );       
}

function moveThrustMouseDepressed::onAddToScene(%this, %scenegraph) 
{
   %this.owner.setUseMouseEvents(true);
   %this.owner.setMouseLocked(true);
   sceneWindow2D.setUseObjectMouseEvents(1);
}

function moveThrustMouseDepressed::onMouseDown(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;
   %this.doThrust( 1 );
}

function moveThrustMouseDepressed::onMouseUp(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;
   %this.doThrust( 0 );
}

function moveThrustMouseDepressed::doThrust(%this, %val)
{
   error("doThrust => ", %val);
   %this.owner.setConstantForcePolar( %this.owner.getRotation(), %val * %this.Thrust  , true ); 
}

