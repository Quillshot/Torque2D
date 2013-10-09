//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

// Create Resource Descriptor
$instantResource = new ScriptObject()
{
	Class          = "RG_ProtoArt";
	Name           = "RG_ProtoArt";
	User           = "TGB";
	LoadFunction   = "RG_ProtoArt::LoadResource";
	UnloadFunction = "RG_ProtoArt::UnloadResource";
};

$instantResource.Data = new SimGroup() 
{
	canSaveDynamicFields = "1";
};


function createImageMapDB( %name , %path , %imageMode , %smoothing , %cellWidth, %cellHeight )
{
   %cellWidth = (%cellWidth $= "") ? 0 : %cellWidth;
   %cellHeight = (%cellHeight $= "") ? %cellWidth : %cellHeight;
   
	%imageMap = new t2dImageMapDatablock(%name) {
		canSaveDynamicFields = "1";
		imageName = expandFileName(%path);
		imageMode = ("" $= %imageMode) ? "FULL" : %imageMode;
		frameCount = "-1";
		filterMode = ("" $= %smoothing) ? "SMOOTH" : %smoothing ;
		filterPad = "1";
		preferPerf = "0";
		cellRowOrder = "1";
		cellOffsetX = "0";
		cellOffsetY = "0";
		cellStrideX = "0";
		cellStrideY = "0";
		cellCountX = "-1";
		cellCountY = "-1";
		cellWidth = %cellWidth ;
		cellHeight = %cellHeight ;
		preload = "1";
		allowUnload = "0";
	};
	return %imageMap;
}

function RG_ProtoArt::LoadResource( %this )
{               
   ////
   //   Load RG Prototyping Art
   ////

   %fileList = 
   "protPlayers.png CELL SMOOTH 64 64" SPC
   "protEnemies.png CELL SMOOTH 64 64" SPC
   "protBullets.png CELL SMOOTH 32 32" SPC
   "protHelpers.png CELL SMOOTH 64 64" SPC
   "codejars.png CELL SMOOTH 45 60" SPC   
   "protLetters.png CELL SMOOTH 64 64" SPC
   "protCircles.png CELL SMOOTH 64 64" SPC
   "protBlocks.png CELL SMOOTH 64 64" SPC
   "protBlocks2.png CELL SMOOTH 64 64" SPC
   "laserBlock.png NA NA NA NA" SPC 
   "simpleTurret.png NA NA NA NA" SPC 
   "energyField.png NA NA NA NA" SPC
   "honeycombGrid.png CELL SMOOTH 64 64" SPC
   "starField.png NA NA NA NA" SPC 
   "protPlanets.png CELL SMOOTH 50 50" SPC
   "protStars.png CELL SMOOTH 50 50" SPC   
   // <== Insert new images before this line
   "";
   
   %fileList = trim(%fileList);

   %tmpTokens = %fileList;
   while( "" !$= %tmpTokens ) 
   {
      %tmpTokens = nextToken( %tmpTokens , "imageFile" , " " );
      %tmpTokens = nextToken( %tmpTokens , "imageMode" , " " );
      %tmpTokens = nextToken( %tmpTokens , "smoothing" , " " );
      %tmpTokens = nextToken( %tmpTokens , "cellWidth" , " " );
      %tmpTokens = nextToken( %tmpTokens , "cellHeight" , " " );

      %imageMapName = strreplace( %imageFile , ".jpg" , "");
      %imageMapName = strreplace( %imageMapName , ".png" , "");
      
      %imageMode = strreplace( %imageMode , "NA" , "");
      %smoothing = strreplace( %smoothing , "NA" , "");
      %cellWidth = strreplace( %cellWidth , "NA" , "");
      %cellHeight = strreplace( %cellHeight , "NA" , "");
      
      %imagePath = findFirstFile("./images/*" @ %imageFile );
      %imagePath = expandFilename("./images/" @ %imageFile );

      %this.Data.add( createImageMapDB( %imageMapName,  %imagePath , %imageMode, %smoothing, %cellWidth, %cellHeight) );
   } 
}

function RG_ProtoArt::UnloadResource( %this )
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


