//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------
if($TSTK::Initialized) return;

$TSTK::Description    = "Torque Script Toolkit";
$TSTK::Version        = 109;
$TSTK::LastUpdate     = "22 JUN 2011";

package TSTK_Package {
   function rgVersions()
   {
      Parent::rgVersions();
      echo( $TSTK::Description @ ":" SPC $TSTK::Version SPC "Last updated:" SPC $TSTK::LastUpdate );      
   }

   function onStart()
   {
     Parent::onStart();
      initTSTK();          
   }   
   
   function initTSTK()
   {  
      ////
      //  Load TSTK Preferences
      ////
      exec("./prefs.cs");


      ////
      //  Contributors
      ////
      exec("./contributors/DigitalFlux.cs");

      ////
      //  Common
      ////
      exec("./common/utilities/actionmap.cs");
      exec("./common/utilities/ArrayObject.cs");
      exec("./common/utilities/Fields.cs");
      exec("./common/utilities/File.cs");
      exec("./common/utilities/GUI.cs");
      exec("./common/utilities/Math.cs");
      exec("./common/utilities/Objects.cs");
      exec("./common/utilities/Records.cs");
      exec("./common/utilities/SimSet.cs");
      exec("./common/utilities/Sound.cs");
      exec("./common/utilities/Strings.cs");
      exec("./common/utilities/Words.cs");
      
      exec("./common/EventRouter/EventRouter.cs");
      exec("./common/EventRouter/EventBind.cs");

      ////
      //  TGB / T2D
      ////
      exec("./TGB/accessMethodGenerators.cs");
      exec("./TGB/behaviors.cs");
      exec("./TGB/effects.cs");
      exec("./TGB/EventManager.cs");
      exec("./TGB/ImageMaps.cs");
      exec("./TGB/levelLoading.cs" ); 
      exec("./TGB/special.cs");
      exec("./TGB/targeting.cs");
      exec("./TGB/t2dSceneObject.cs");
      exec("./TGB/WorldLimit.cs");

      exec("./TGB/quickConfig/main.cs");

      exec("./TGB/editors/fieldTypes.ed.cs" ); 
      exec("./TGB/editors/levelEditor.ed.cs" );

      exec("./TGB/easyDamageEnergy/main.cs" ); 
   
      ////
      //  TGE
      ////
      exec("./TGE/GameBase.cs");
      exec("./TGE/Networking.cs");
      exec("./TGE/SceneObject.cs");   
      
      initializeEventRouterSystem();

      ////
      //  Load TSTK Self-documenation Tools
      ////
      exec("./doco.cs");
      
      $TSTK::Initialized = true;
   }   
};

activatePackage( TSTK_Package );
