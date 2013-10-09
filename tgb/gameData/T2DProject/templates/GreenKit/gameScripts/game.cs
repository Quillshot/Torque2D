//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------

//---------------------------------------------------------------------------------------------
// startGame
// All game logic should be set up here. This will be called by the level builder when you
// select "Run Game" or by the startup process of your game to load the first level.
//---------------------------------------------------------------------------------------------
function startGame(%level)
{
   Canvas.setContent(mainScreenGui);
   Canvas.setCursor(DefaultCursor);
   
   new ActionMap(moveMap);   
   moveMap.push();
   
   $enableDirectInput = true;
   activateDirectInput();
   enableJoystick();
   
   // If you are using one of the example frames, you can set the initial counters here:
   //livesCounter.setValue(3);
   //scoreCounter.setValue(0);
   
   sceneWindow2D.loadLevel(%level);
}

//---------------------------------------------------------------------------------------------
// endGame
// Game cleanup should be done here.
//---------------------------------------------------------------------------------------------
function endGame()
{
   sceneWindow2D.endLevel();
   moveMap.pop();
   moveMap.delete();
}
