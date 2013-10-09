if (!isObject(moveStopMouseClick))
{
   %behavior = new BehaviorTemplate(moveStopMouseClick)
   {
      friendlyName = "Mouse Stop";
      behaviorType = "01 - Movement Mouse";
      description  = "Stop translations and/or rotations when mouse buttons is clicked.";
   };
   %behavior.addValidObjectClass("t2dSceneObject");
   %behavior.addBehaviorField( "enable", "Enable behavior.", bool, true ); 
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);
   %behavior.addBehaviorField( "Stop_Translations",  "Stop translations.", bool, true );
   %behavior.addBehaviorField( "Stop_Rotations",  "Stop rotations.", bool, true );}

function moveStopMouseClick::onAddToScene(%this, %scenegraph) 
{
   %this.owner.setUseMouseEvents(true);
   %this.owner.setMouseLocked(true);
   sceneWindow2D.setUseObjectMouseEvents(1);
}

function moveStopMouseClick::onMouseDown(%this,%modifier,%worldPos,%clicks)
{
   if (!%this.enable) return;
   
   if(%this.Stop_Translations && %this.Stop_Rotations)
   {
      error("Stop Translations and Rotations" );
      %this.owner.setAtRest();
   }   
   else if(%this.Stop_Translations)
   {
      error("Stop Translations" );
      %this.owner.setLinearVelocity(0,0);
      //%this.owner.setConstantForcePolar( 0, 0 );
      %this.owner.stopConstantForce(0,0);
      %this.setPositionTargetOff();
   }
   else if(%this.Stop_Rotations)
   {
      error("Stop Rotations" );
      %this.setRotationTargetOff();
      %this.setAngularVelocity( 0.0 );
   }
}
