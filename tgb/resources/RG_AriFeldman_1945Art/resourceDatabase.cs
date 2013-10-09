//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

// Create Resource Descriptor
$instantResource = new ScriptObject()
{
	Class = "RG_AriFeldman_1945Art";
	Name = "RG_AriFeldman_1945Art";
	User = "TGB";
	LoadFunction = "RG_AriFeldman_1945Art::LoadResource";
	UnloadFunction = "RG_AriFeldman_1945Art::UnloadResource";
};

$instantResource.Data = new SimGroup() 
{
	canSaveDynamicFields = "1";
};

// Load Resource Function - Hooks into game
function RG_AriFeldman_1945Art::LoadResource( %this )
{
   %fileList = "bomb.png bombDrop.png bulletDual.png bulletSingle.png " SPC
               "enemyPlaneBlue.png enemyPlaneFlipBlue.png enemyShip.png" SPC
               "enemySub.png islands.png playerPlaneAddon.png" SPC
               "playerPlaneShadow.png playerPowerupSet1.png playerPowerupSet2.png playerPowerupSet3.png shot0.png shot1.png";
   //
   // Sprite Lib - Transparent Backgrounds
   //
   %tmpTokens = %fileList;
   while( "" !$= %tmpTokens ) 
   {
      %tmpTokens = nextToken( %tmpTokens , "myToken" , " " );

      %imageMapName = "transparent" @ strreplace( %myToken , ".png" , "") @ "ImageMap" ;
      %this.Data.add( createImageMapDB( %imageMapName,  expandFileName("./images/PNGTransparent/" @ %myToken ) , "KEY" ) );
   } 
   
   %this.Data.add( createImageMapDB( "waterImageMap",  expandFileName("./images/PNGTransparent/waterSingle" ) ) );              
   
   //  Datablocks   
   exec("./datablocks/TransparentBackgroundDB.cs");
}

// Unload Resource Function - Remove from game Sim.
function RG_AriFeldman_1945Art::UnloadResource( %this )
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
