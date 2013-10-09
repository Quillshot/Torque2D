return;
///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

// ================ 8(  ===  8 <  >  === 8?| === 8 ) ===
//
//             NOT WORKING?  Keep Reading!
//
// ================ 8(  ===  8 <  >  === 8?| === 8 ) ===
//
//  This REQUIRES the "Torque Script ToolKit" (TSTK)
//  to function properly.
//  
//  Visit: http://roaminggamer.com/ for additional help.
//
// ================ 8(  ===  8 <  >  === 8?| === 8 ) ===
$RG_SK001_TGB_SSK::Description    = "Roamging Gamer Starter Kit 001 - TGB Super Starter Kit";
$RG_SK001_TGB_SSK::Version        = 1;
$RG_SK001_TGB_SSK::LastUpdate     = "31 AUG 2009";

package RG_SK001_TGB_SSK_Package {
   function rgVersions()
   {
      Parent::rgVersions();
      echo( $RG_SK001_TGB_SSK::Description SPC ":" SPC $RG_SK001_TGB_SSK::Version SPC "Last updated:" SPC $RG_SK001_TGB_SSK::LastUpdate );      
   }
};
activatePackage( RG_SK001_TGB_SSK_Package );

$instantResource = new ScriptObject()
{
	Class          = "RG_SK001_TGB_SSK";
	Name           = "RG_SK001_TGB_SSK";
	User           = "TGB";
	LoadFunction   = "RG_SK001_TGB_SSK::LoadResource";
	UnloadFunction = "RG_SK001_TGB_SSK::UnloadResource";
};

$instantResource.Data = new SimGroup() 
{
	canSaveDynamicFields = "1";
};

function RG_SK001_TGB_SSK::LoadResource( %this )
{     
   %this.FindAndLoadBehaviors();
   
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

function RG_SK001_TGB_SSK::FindAndLoadBehaviors( %this )
{  
   // Load 'static' behaviors

   %behaviors = createArrayObject();

   // Load 'static' behaviors
   for(%file = findFirstFile("./behaviors/*.cs"); %file !$= ""; %file = findNextFile("./behaviors/*.cs"))
   {
      %behaviors.addEntry( %file );
   }
   for(%file = findFirstFile("./behaviors/*.cs*"); %file !$= ""; %file = findNextFile("./behaviors/*.cs*"))
   {
      %behaviors.addEntry( %file );
   }

   // Load 'generated' behaviors
   for(%file = findFirstFile("./generatedBehaviors/*.cs"); %file !$= ""; %file = findNextFile("./generatedBehaviors/*.cs"))
   {
      %behaviors.addEntry( %file );
   }
   for(%file = findFirstFile("./generatedBehaviors/*.cs*"); %file !$= ""; %file = findNextFile("./generatedBehaviors/*.cs*"))
   {
      %behaviors.addEntry( %file );
   }

   %behaviors.sort();
   
   %entries = %behaviors.getCount();
   for(%count=0; %count<%entries; %count++)
   {
      // Following 'tricky' code allows for discover and loading of .dso files later,
      // when we delete the .cs files.
      %entry = %behaviors.getEntry( %count );
      
      //echo("%entry: ", %entry);
      
      %entry = strreplace( %entry, ".dso", "" );
      if( %entry !$= %this.lastExecdBehaviorFile)
      {      
         exec(%entry);
         //error("executed: ", %entry);
         %this.lastExecdBehaviorFile = %entry;
      }
   }
   %behaviors.delete();
}




function RG_SK001_TGB_SSK::UnloadResource( %this )
{
   // Unregister the behaviors
   %behaviorList = %this.behaviors;
   behaviorManager.unregisterBehaviors( %behaviorList);
   
   // We must clean up all the mess we've made in the Sim.
   if( isObject( %this.Data ) && %this.Data.GetCount() > 0 )
   {      
      while( %this.Data.getCount() > 0 )
      {
         %datablockObj = %this.Data.getObject( 0 );
         %this.Data.remove( %datablockObj );
         if( isObject( %datablockObj ) )
         %datablockObj.delete();
      }
   }
}

