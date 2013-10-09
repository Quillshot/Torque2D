//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

package RG_LevelLoading
{
/*
Description: This method overloads loadLevel() and captures data about the level file that was loaded for future use by various Roaming Gamer level loading scripts.
Arguments:
EFM - EFM 
Returns: EFM 
*/
   function sceneWindow2D::loadLevel( %this, %level )
   {
      $TSTK::CurrentLevel = %level;
      $TSTK::CurrentLevelPath = filePath( %level );
      
      %tmp   = strreplace( %level, "/", " " );
      
      $TSTK::LevelPathRoot = getWord( %tmp, 0 );
      
      %tmp   = strreplace( %tmp, "\\", " " );
      %tmp   = strreplace( %tmp, ".t2d", "" );
      %words = getWordCount( %tmp );
      %tmp   = getWord( %tmp, %words-1 );

      $TSTK::CurrentLevelPrefix = removeNumeric( %tmp );
      $TSTK::CurrentLevelNumber = removeAlpha( %tmp );
      
      error(" $TSTK::CurrentLevel       == ", $TSTK::CurrentLevel);
      error(" $TSTK::CurrentLevelPath   == ", $TSTK::CurrentLevelPath);
      error(" $TSTK::CurrentLevelPrefix == ", $TSTK::CurrentLevelPrefix);
      error(" $TSTK::CurrentLevelNumber == ", $TSTK::CurrentLevelNumber);

      Parent::loadLevel( %this, %level );
   }

/*
Description: This method re-loads the current level.
*/
   function sceneWindow2D::reloadCurrentLevel(%this)
   {
      %level = $TSTK::CurrentLevel;

      if(!isFile(%level))
      {
         error("reloadCurrentLevel() - Level File Not Found! => ", %level );
         return false;
      }
   
      %this.schedule( 100, endlevel ); 
      %this.schedule( 200, loadLevel,  %level ); 
   }
   
/*
Description: This method loads a named level.  
Note: The path need not bee complete as this method will find the level anywhere in the path of the current game.
*/
   function sceneWindow2D::loadNamedLevel(%this,%levelName)
   {
      %levelName = %levelName @ ".t2d";
      %levelName = strreplace( %levelName, ".t2d.t2d", ".t2d" ); // Just in case
   
      %levelPath = $TSTK::LevelPathRoot @ "/*/" @ %levelName;
   
      %level = findFirstFile( %levelPath );

      if(!isFile(%level))
      {
         error("loadNamedLevel() - Level File Not Found! => ", %levelPath );
         return false;
      }
   
      %this.schedule( 100, endlevel );  
      %this.schedule( 200, loadLevel,  %level );  
   }

/*
Description: This method loads a file having the same name pre-fix as the last level, but having a (possibly) different ending number. 
Ex: Level1.t2d, Level.t2d, etc.
Note: The path need not bee complete as this method will find the level anywhere in the path of the current game.
*/
   function sceneWindow2D::loadNumberedLevel(%this,%levelNumber)
   {
      %level = $TSTK::CurrentLevelPath @ "/" @
               $TSTK::CurrentLevelPrefix @ 
               %levelNumber @ 
               ".t2d";

      if(!isFile(%level))
      {
         error("loadNumberedLevel() - Level File Not Found! => ", %level );
         return false;
      }
      
      %this.schedule( 100, endlevel ); 
      %this.schedule( 200, loadLevel,  %level ); 
   }

/*
Description: This method loads a file having the same name pre-fix as the last level, and ending in a number one greater than the last numbered level to be loaded.
Ex: If we last loaded Level1.t2d, means a call to this method will load Level2.t2d.
Note: The path need not bee complete as this method will find the level anywhere in the path of the current game.
Note2: A numbered level must have been previously loaded for this to work.
*/
   function sceneWindow2D::loadNextNumberedLevel(%this)
   {
      %level = $TSTK::CurrentLevelPath @ "/" @
               $TSTK::CurrentLevelPrefix @ 
               $TSTK::CurrentLevelNumber+1 @ 
               ".t2d";

      if(!isFile(%level))
      {
         error("loadNextNumberedLevel() - Level File Not Found! => ", %level );
         return false;
      }
      
      %this.schedule( 100, endlevel );
      %this.schedule( 200, loadLevel,  %level );
   }

/*
Description: This method loads a file having the same name pre-fix as the last level, and ending in a number on less than the last numbered level to be loaded.
Ex: If we last loaded Level2.t2d, means a call to this method will load Level1.t2d.
Note: The path need not bee complete as this method will find the level anywhere in the path of the current game.
Note2: A numbered level must have been previously loaded for this to work.
*/
   function sceneWindow2D::loadLastNumberedLevel(%this)
   {
      %level = $TSTK::CurrentLevelPath @ "/" @
               $TSTK::CurrentLevelPrefix @ 
               $TSTK::CurrentLevelNumber+1 @ 
               ".t2d";

      if(!isFile(%level))
      {
         error("loadNextLevel() - Level File Not Found! => ", %level );
         return false;
      }
   
      %this.schedule( 100, endlevel );
      %this.schedule( 200, loadLevel,  %level );
   }
};
activatePackage(RG_LevelLoading);
