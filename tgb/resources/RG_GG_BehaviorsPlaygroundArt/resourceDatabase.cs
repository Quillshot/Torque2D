//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

// Create Resource Descriptor
$instantResource = new ScriptObject()
{
	Class          = "RG_GG_BehaviorsPlaygroundArt";
	Name           = "RG_GG_BehaviorsPlaygroundArt";
	User           = "TGB";
	LoadFunction   = "RG_GG_BehaviorsPlaygroundArt::LoadResource";
	UnloadFunction = "RG_GG_BehaviorsPlaygroundArt::UnloadResource";
};

$instantResource.Data = new SimGroup() 
{
	canSaveDynamicFields = "1";
};

function RG_GG_BehaviorsPlaygroundArt::LoadResource( %this )
{               
   ////
   //   Create File List
   ////

   %fileList = 
   "backdrop_b.png NA NA NA NA" SPC 
   "player_hover.png NA NA NA NA" SPC 
   "player_ship.png NA NA NA NA" SPC 
   "player_tank.png NA NA NA NA" SPC 
   "player_ufo.png NA NA NA NA" SPC 
   "widget_arrow.png NA NA NA NA" SPC 
   "widget_ball.png NA NA NA NA" SPC 
   "widget_fruit.png NA NA NA NA" SPC 
   "widget_spike.png NA NA NA NA" SPC 
   "barrier_circle.png NA NA NA NA" SPC 
   "barrier_wall.png NA NA NA NA" SPC 
   "button_atom.png CELL SMOOTH 127 127" SPC
   "button_axis.png CELL SMOOTH 127 127" SPC
   "button_dual.png CELL SMOOTH 127 127" SPC
   "button_flag.png CELL SMOOTH 127 127" SPC
   "button_fleur.png CELL SMOOTH 127 127" SPC
   "button_illuminati.png CELL SMOOTH 127 127" SPC
   "button_shield.png CELL SMOOTH 127 127" SPC
   "button_shuriken.png CELL SMOOTH 127 127" SPC
   "objects_blocks.png CELL SMOOTH 64 64" SPC
   "objects_bricks.png CELL SMOOTH 112 64" SPC
   "objects_bricks2.png CELL SMOOTH 112 64" SPC
   "objects_triangles.png CELL SMOOTH 62 62" SPC
   "particles_glow.png CELL SMOOTH 64 64" SPC
   "particles_glow2.png CELL SMOOTH 64 64" SPC
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
      
      %imagePath = expandFilename("./images/" @ %imageFile );
      
      %this.Data.add( createImageMapDB( %imageMapName,  %imagePath , %imageMode, %smoothing, %cellWidth, %cellHeight) );
   } 
}

function RG_GG_BehaviorsPlaygroundArt::UnloadResource( %this )
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


