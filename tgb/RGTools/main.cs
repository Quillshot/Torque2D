//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------
package RGTools_Package {

   function onStart()
   {
      Parent::onStart();
      initRGTools();          
   }   
   
   function initRGTools()
   {  
      ////
      //   Load Editors 
      ////
      // SSK Game Design Questionaire
      exec( "./questionaire/SSKquestionaire.cs" );
      exec( "./questionaire/SSKquestionaire.gui" );


      // onDemand Behavior Generator
      exec( "./editors/onDemandGeneratorDlg.ed.cs" );
      exec( "./editors/onDemandGeneratorDlg.ed.gui" );   
   
      // DB Manager
      exec( "./editors/datablockManagerDlg.cs" );
      exec( "./editors/datablockManagerDlg.ed.gui" );   
   
      exec( "./editors/messageBoxGetStringDlg.ed.gui" ); 

      ////
      //   Load Tools
      ////
      exec( "./tools/analysis.cs" );
      exec( "./tools/atoms.cs" );
      exec( "./tools/BuilderScriptGenerator.cs" );
      exec( "./tools/DBGenerator.cs" );

      ////
      //   Add 'Roaming Gamer' menu to Torque Game Builder toolbar
      ////
      exec( "./editors/RGMenu.ed.cs" );
      addRGMenu();

      exec( "./editors/toolPopup.cs" ); //EFM

      ////
      //   Add reloader button
      ////
      exec("./editors/reloadButton.ed.cs");
      addRLCPButton();

      ////
      //   Load Atoms 
      ////
      %atomFilesSpec = "./atoms" @ "/*.cs";
      for (%file = findFirstFile(%atomFilesSpec); %file !$= ""; %file = findNextFile(%atomFilesSpec))
      {
         exec(%file);
      }
   }   
};

activatePackage( RGTools_Package );
