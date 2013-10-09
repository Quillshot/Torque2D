//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------

$RG_TEMPLATE::Description    = "Roaming Gamer - T2DProject Template #1 (Green Kit)";
$RG_TEMPLATE::Version        = 4;
$RG_TEMPLATE::LastUpdate     = "06 JUN 2011";
$RG::EnableSplash   = false; 
$RG::EnableMainMenu = false; 

package RG_TEMPLATE_Package {
   function rgVersions()
   {
      Parent::rgVersions();
      echo( $RG_TEMPLATE::Description @ ":" SPC $RG_TEMPLATE::Version SPC "Last updated:" SPC $RG_TEMPLATE::LastUpdate );      
   }
};

exec("~/TSTK/main.cs");

activatePackage(RG_TEMPLATE_Package);
//---------------------------------------------------------------------------------------------
// initializeProject
// Perform game initialization here.
//---------------------------------------------------------------------------------------------
function initializeProject()
{
   // Load up the in game gui.
   exec("./gui/main.cs");

   // Exec game scripts.
   exec("./gameScripts/game.cs");
   exec("./gameScripts/soundEffects.cs"); // Initial the soundeffects loader
      
   $Game::CurrentScene = expandFilename($Game::DefaultScene);   
   error("$Game::DefaultScene === ", $Game::DefaultScene);
   error("$Game::CurrentScene === ", $Game::CurrentScene);
   
   if( $RG::EnableMainMenu )
   {
      if( $RG::EnableSplash )
      {
         Canvas.setContent(splashScreen);
      }
      else
      {
         Canvas.setContent(mainMenu);
      }      
   }
   else
   {
      if( $RG::EnableSplash )
      {
         Canvas.setContent(splashScreen);
      }
      else
      {
         startGame( expandFilename($Game::DefaultScene) );
      }            
   }
}

//---------------------------------------------------------------------------------------------
// shutdownProject
// Clean up your game objects here.
//---------------------------------------------------------------------------------------------
function shutdownProject()
{
   endGame();
}

//---------------------------------------------------------------------------------------------
// setupKeybinds
// Bind keys to actions here..
//---------------------------------------------------------------------------------------------
function setupKeybinds()
{
   new ActionMap(moveMap);
   //moveMap.bind("keyboard", "a", "doAction", "Action Description");
}
