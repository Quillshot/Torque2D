if (!isObject(isShrinkNGrowButton))
{
   %behavior = new BehaviorTemplate(isShrinkNGrowButton) 
   { 
      friendlyName = "Is Shrink-n-Grow Button";
      behaviorType = "20 - Interfaces";
      description = "This object should behave like a animated button.  This button provides a number of responses to clicks, including: quit(), load named level, load next numbered level, ... ";
   };
   %behavior.addValidObjectClass("t2dSceneObject");
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debuging for this behavior.", bool, false);
   %behavior.addBehaviorField( "Action", "Action to take when button is pressed.", "enum","quit", 
                               "quit" TAB // quit()
                               "load named level" TAB // Load a named level file
                               "load next numbered level" TAB // Load next numbered level
                               "load last numbered level" TAB // Load last numbered level
                               "reload current level" TAB // Reload the current level
                               "execute script" TAB // Call the function specified in userData
                               "execute owner method" TAB // Call the function specified in userData as an owner method.
                               "broadcast behavior method" TAB  // Call 'broadcastMethod' with arguments
                               "broadcast global event" TAB // Broadcast event to the global EventManager
                               "broadcast named queue event"); // Allow broadcast to named EventManager
                               
   %behavior.addBehaviorField( "userData", "Name of level file to load.", "default", "myLevel");
}

function isShrinkNGrowButton::onAddToScene(%this, %scenegraph)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("isShrinkNGrowButton::onAddToScene()");
   
   %this.owner.setUseMouseEvents(true);
   sceneWindow2D.setUseObjectMouseEvents(1);
}

function isShrinkNGrowButton::onMouseEnter(%this, %modifier, %worldPos)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("isShrinkNGrowButton::onMouseEnter()");
   %this.owner.setFrame(1);
}

function isShrinkNGrowButton::onMouseLeave(%this, %modifier, %worldPos)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("isShrinkNGrowButton::onMouseLeave()");
   %this.owner.setFrame(0);
}

function isShrinkNGrowButton::onMouseDown(%this, %modifier, %worldPos)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("isShrinkNGrowButton::onMouseDown()");
   %this.owner.setFrame(2);
}

function isShrinkNGrowButton::onMouseUp(%this, %modifier, %worldPos)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("isShrinkNGrowButton::onMouseUp()");

   %this.owner.setFrame(1);
      
   switch$( %this.Action )
   {
   case "quit": // quit()
      schedule(0,0, quit);
         
   case "load named level": // Load a named level file
      %this.loadNamedLevel();         
      
   case "load next numbered level": // Load next numbered level
   //EFM not done yet
   
   case "load last numbered level": // Load last numbered level
   //EFM not done yet
 
   case "reload current level": // Reload the current level
   //EFM not done yet
   
   case "execute script": // Call the function specified in userData
   %evalScript = %this.userData;
   error( %evalScript );
   eval( %evalScript );   
   
   case "execute owner method": // Call the function specified in userData as a method.
   %owner = %this.owner;
   %evalScript = %owner.getID() @ "." @ %this.userData;
   error( %evalScript );
   eval( %evalScript );
   //EFM not done yet
   
   case "broadcast behavior method":  // Call 'broadcastMethod' with arguments
   //EFM not done yet
   %this.broadcastMethod( %this.userData );
   
   case "broadcast global event": // Broadcast event to the global EventManager
   //EFM not done yet
   
   case "broadcast named queue event": // Allow broadcast to named EventManager  
   //EFM not done yet
   }
   
}

function isShrinkNGrowButton::loadNamedLevel(%this)
{
   if(%this.debugMode) echo("isShrinkNGrowButton::loadNamedLevel()");

   %level = $TSTK::CurrentLevelPath @ "/" @
            %this.userData @ ".t2d";

   %level = strreplace( %level, ".t2d.t2d", ".t2d" ); // Just in case

   if(!isFile(%level))
   {
      error("loadNamedLevel() - Level File Not Found! => ", %level );
      return false;
   }

   sceneWindow2D.schedule( 100, endlevel );  //EFM times OK?
   sceneWindow2D.schedule( 200, loadLevel,  %level );  //EFM times OK?
}
