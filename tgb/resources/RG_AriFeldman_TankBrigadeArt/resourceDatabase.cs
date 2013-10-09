//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

// Create Resource Descriptor
$instantResource = new ScriptObject()
{
	Class = "RG_AriFeldman_TankBrigadeArt";
	Name = "RG_AriFeldman_TankBrigadeArt";
	User = "TGB";
	LoadFunction = "RG_AriFeldman_TankBrigadeArt::LoadResource";
	UnloadFunction = "RG_AriFeldman_TankBrigadeArt::UnloadResource";
};

$instantResource.Data = new SimGroup() 
{
	canSaveDynamicFields = "1";
};

// Load Resource Function - Hooks into game
function RG_AriFeldman_TankBrigadeArt::LoadResource( %this )
{
   %fileList = "blueTank.png greenTank.png";

   //
   // Sprite Lib - Tank Brigade Image Maps
   //
   %tmpTokens = %fileList;
   while( "" !$= %tmpTokens ) 
   {
      %tmpTokens = nextToken( %tmpTokens , "myToken" , " " );

      %imageMapName = strreplace( %myToken , ".png" , "") @ "ImageMap" ;
      %this.Data.add( createImageMapDB( %imageMapName,  expandFileName("./images/modified/" @ %myToken ) , "KEY" ) );
   }               

   %fileList = "blueTankIcon.png greenTankIcon.png fireball.png shell.png" SPC
   "grass.png dirt.png crete.png water.png " SPC
   "blueblock.png greenblock.png redblock.png brownblock.png greyblock.png";

   %tmpTokens = %fileList;
   while( "" !$= %tmpTokens ) 
   {
      %tmpTokens = nextToken( %tmpTokens , "myToken" , " " );

      %imageMapName = strreplace( %myToken , ".png" , "") @ "ImageMap" ;
      %this.Data.add( createImageMapDB( %imageMapName,  expandFileName("./images/modified/" @ %myToken ) , "FULL" ) );
   }               

   
   //  Datablocks   
   exec("./datablocks/TransparentBackgroundDB.cs");
}

// Unload Resource Function - Remove from game Sim.
function RG_AriFeldman_TankBrigadeArt::UnloadResource( %this )
{
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
