//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

// Create Resource Descriptor
$instantResource = new ScriptObject()
{
	Class = "RG_AriFeldman_ArinoidArt";
	Name = "RG_AriFeldman_ArinoidArt";
	User = "TGB";
	LoadFunction = "RG_AriFeldman_ArinoidArt::LoadResource";
	UnloadFunction = "RG_AriFeldman_ArinoidArt::UnloadResource";
};

$instantResource.Data = new SimGroup() 
{
	canSaveDynamicFields = "1";
};

// Load Resource Function - Hooks into game
function RG_AriFeldman_ArinoidArt::LoadResource( %this )
{
   %fileList = "boardpieces.png tiles.png tiles2.png" SPC
               "adrop.png bdrop.png cdrop.png dropbomb.png" SPC
               "paddlenarrow.png paddlenormal.png paddleshoot.png paddlewide.png" SPC
               "ball.png bullet.png explosion.png smoke.png";

   //
   // Sprite Lib - Arinoid Image Maps
   //
   %tmpTokens = %fileList;
   while( "" !$= %tmpTokens ) 
   {
      %tmpTokens = nextToken( %tmpTokens , "myToken" , " " );

      %imageMapName = strreplace( %myToken , ".png" , "") @ "ImageMap" ;
      %this.Data.add( createImageMapDB( %imageMapName,  expandFileName("./images/modified/" @ %myToken ) , "KEY" ) );
   }               

   
   //  Datablocks   
   exec("./datablocks/TransparentBackgroundDB.cs");
}

// Unload Resource Function - Remove from game Sim.
function RG_AriFeldman_ArinoidArt::UnloadResource( %this )
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
