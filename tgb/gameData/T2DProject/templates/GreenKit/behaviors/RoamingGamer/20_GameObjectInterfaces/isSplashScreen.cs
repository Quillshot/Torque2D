if (!isObject(isSplashScreen))
{
   %behavior = new BehaviorTemplate(isSplashScreen) 
   { 

      friendlyName = "Is Splash Screen";
      behaviorType = "20 - Interfaces";
      description = "This object should be treated like a splash screen.";
   };
   %behavior.addValidObjectClass("t2dSceneObject");
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debuging for this behavior.", bool, false);

   %behavior.addBehaviorField( "levelName", "Name of level file to load.", "default", "myLevel");

   %behavior.addBehaviorField( "timerPeriod", "Wait this long then load next screen (level file). (0 disables timer.)", "int", "1000"); //EFM docs said float?
   
   %behavior.addBehaviorField("useKeystroke", "Allow a (specified) keystroke to cause the splash screen load next screen (level file).", bool, true);
   %behavior.addBehaviorField( "actionKey",   "Load next screen when this key is pressed.", keybind, "Keyboard space" );

   %behavior.addBehaviorField("useMouseClick", "Allow a left mouse click to cause the splash screen load next screen (level file).", bool, true);   
}

function isSplashScreen::onAddToScene(%this, %scenegraph)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("isSplashScreen::onAddToScene()");

   if(%this.timerPeriod > 0)
   {
      %this.owner.setTimerOn(%this.timerPeriod);
   }

   if(%this.useKeystroke)
   {
      moveMap.bindCmd( getWord(%this.actionKey, 0), 
                     getWord(%this.actionKey, 1), 
                     "",
                     %this.getId()@".loadNamedLevel();" );
   }

   if(%this.useMouseClick)
   {
      %this.owner.setUseMouseEvents(true);
      sceneWindow2D.setUseObjectMouseEvents(1); //EFM assumes scenewindow name
   }
}
function isSplashScreen::onTimer(%this, %dstObj, %srcRef, %dstRef, 
                                  %time, %normal, %contacts, %points )
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("isSplashScreen::onTimer()");
   %this.owner.setTimerOff();
   %this.loadNamedLevel();
}

function isSplashScreen::onMouseUp(%this, %modifier, %worldPos)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("isSplashScreen::onMouseUp()");

   %this.loadNamedLevel();
}

function isSplashScreen::loadNamedLevel(%this)
{
   if(%this.debugMode) echo("isSplashScreen::loadNamedLevel()");

   %level = $TSTK::CurrentLevelPath @ "/" @
            %this.levelName @ ".t2d";

   %level = strreplace( %level, ".t2d.t2d", ".t2d" ); // Just in case

   if(!isFile(%level))
   {
      error("loadNamedLevel() - Level File Not Found! => ", %level );
      return false;
   }

   sceneWindow2D.schedule( 100, endlevel );  //EFM times OK?
   sceneWindow2D.schedule( 200, loadLevel,  %level );  //EFM times OK?
}
