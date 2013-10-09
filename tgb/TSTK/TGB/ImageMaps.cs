//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

/*
Description: This function is a worker function designed to simplify the creation of new imagemaps.  
                %name () - Name to give new image map. (Must be unique.)
                %path () - Path + filename where image file for this image map is located.
       %imageMode (FULL) - Mode to use for generating this image map: FULL or CELL
     %smoothing (SMOOTH) - Smoothing technique to use: SMOOTH or NONE
          %cellWidth (0) - Width to use for CELL image mode.
%cellHeight (%cellWidth) - Height to use for CELL image mode.


Note: This is used extensively in the Roaming Gamer TGB art packs.
Arguments:
EFM - EFM 
Returns: EFM 
*/
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

