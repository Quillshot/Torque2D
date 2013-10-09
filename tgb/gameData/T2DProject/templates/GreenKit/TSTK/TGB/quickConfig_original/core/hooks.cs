///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

package RG_quickConfigPackage 
{   
   ////
   //   _initializeProject() - Loads quickConfigRules.cs when game is run.
   ////
   function _initializeProject()
   {
      // Load the quick configuration rules file and set them up before we load any game content   
      if( $TSTK::UseTGBQuickConfig )
      {
         %quickConfigRules = expandFilename("game/gameScripts/quickConfigRules.cs");   
         if(isFile(%quickConfigRules)) exec(%quickConfigRules);
      }
      
      Parent::_initializeProject( );
   }


   ////
   //   LoadProjectData() - Loads quickConfigRules.cs when a project is loaded in the editor
   ////
   function T2DProject::LoadProjectData( %this )
   {
      // Load the quick configuration rules file and set them up before we load any game content   
      if( $TSTK::UseTGBQuickConfig )
      {
         %quickConfigRules = expandFilename("^game/gameScripts/quickConfigRules.cs");   
         if(isFile(%quickConfigRules)) exec(%quickConfigRules);
      }
   
      Parent::LoadProjectData( %this );
   }

};
activatePackage(RG_quickConfigPackage);