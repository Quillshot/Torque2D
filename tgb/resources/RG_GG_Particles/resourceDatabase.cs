///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

// This resource WILL NOT WORK WITHOUT THE Roaming Gamer Green Kit (http://roaminggamer.com/)

$instantResource = new ScriptObject()
{
   Class          = "RG_GG_Particles";
   Name           = "RG_GG_Particles";
   User           = "TGB";
   LoadFunction   = "RG_GG_Particles::LoadResource";
   UnloadFunction = "RG_GG_Particles::UnloadResource";
};

function RG_GG_Particles::LoadResource( %this )
{
}


function RG_GG_Particles::UnloadResource( %this )
{
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

// Resource Data
$instantResource.Data = new SimGroup() 
   {
      canSaveDynamicFields = "1";
   
   new t2dImageMapDatablock(particles1ImageMap) {
      canSaveDynamicFields = "1";
      imageName = "./images/particles1";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "64";
      cellHeight = "64";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(particles2ImageMap) {
      canSaveDynamicFields = "1";
      imageName = "./images/particles2";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "128";
      cellHeight = "128";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(particles3ImageMap) {
      canSaveDynamicFields = "1";
      imageName = "./images/particles3";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "128";
      cellHeight = "128";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(particles4ImageMap) {
      canSaveDynamicFields = "1";
      imageName = "./images/particles4";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "64";
      cellHeight = "64";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(particles5ImageMap) {
      canSaveDynamicFields = "1";
      imageName = "./images/particles5";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "64";
      cellHeight = "64";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(particles6ImageMap) {
      canSaveDynamicFields = "1";
      imageName = "./images/particles6";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "64";
      cellHeight = "64";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(raindropImageMap) {
      canSaveDynamicFields = "1";
      imageName = "./images/raindrop";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "32";
      cellHeight = "32";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(lightningImageMap)
   {
	   imageName = "./images/lightning";
	   imageMode = cell;
	   cellWidth = 64;
	   cellHeight = 128;		
   };
   new t2dAnimationDatablock(lightningAnimation)
   {
      imageMap = lightningImageMap;
      animationFrames = "0 1 2 3 1 2 3";
      animationTime = 0.3;
      animationCycle = true;
      randomStart = true;
   };
   new t2dImageMapDatablock(bagPuffImageMap)
   {
	   imageMode = full;
	   imageName = "./images/puffs/bag_puff";
	   filterPad = false;
   };

   new t2dImageMapDatablock(bagPuff2ImageMap)
   {
	   imageMode = full;
	   imageName = "./images/puffs/bag_puff2";
	   filterPad = false;
   };
   new t2dImageMapDatablock(font1ImageMap) {
      imageName = "./images/font1.png";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "1";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "16";
      cellHeight = "16";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(ggLogoImageMap) {
      imageName = "./images/gglogo.png";
      imageMode = "FULL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "1";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(ringImageMap) {
      canSaveDynamicFields = "1";
      imageName = "./images/ring.png";
      imageMode = "FULL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(shipImageMap) {
      canSaveDynamicFields = "1";
      imageName = "./images/ship.png";
      imageMode = "FULL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(flamesImageMap) {
      canSaveDynamicFields = "1";
      imageName = "./images/flames.png";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "32";
      cellHeight = "32";
      preload = "1";
      allowUnload = "0";
   };
   new t2dAnimationDatablock(flamesAnimation) {
      canSaveDynamicFields = "1";
      imageMap = "flamesImageMap";
      animationFrames = "0 1 2 3";
      animationTime = "0.3";
      animationCycle = "1";
      randomStart = "1";
      startFrame = "0";
   };
   new t2dAnimationDatablock(matrixAnimation) {
      canSaveDynamicFields = "1";
      imageMap = "font1ImageMap";
      animationTime = "10";
      animationCycle = "1";
      randomStart = "1";
      startFrame = "0";
   };
   new t2dImageMapDatablock(beamImageMap) {
      canSaveDynamicFields = "1";
      imageName = "./images/beam.png";
      imageMode = "FULL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(strikeImageMap) {
      canSaveDynamicFields = "1";
      imageName = "./images/strike.png";
      imageMode = "FULL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(smokeImageMap) {
      canSaveDynamicFields = "1";
      imageName = "./images/smoke.png";
      imageMode = "FULL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(emberImageMap) {
      canSaveDynamicFields = "1";
      imageName = "./images/ember.png";
      imageMode = "FULL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(dustImageMap) {
      canSaveDynamicFields = "1";
      imageName = "./images/dust.png";
      imageMode = "FULL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(exhaustImageMap) {
      canSaveDynamicFields = "1";
      imageName = "./images/exhaust.png";
      imageMode = "FULL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(shotImageMap) {
      canSaveDynamicFields = "1";
      imageName = "./images/shot.png";
      imageMode = "FULL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(particle_block_glowImageMap) {
      imageName = "./images/particle_block_glow.png";
      imageMode = "FULL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "1";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(particles_arcImageMap) {
      imageName = "./images/particles_arc.png";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "1";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "2";
      cellCountY = "2";
      cellWidth = "64";
      cellHeight = "64";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(particles_glowImageMap) {
      imageName = "./images/particles_glow.png";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "1";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "2";
      cellCountY = "2";
      cellWidth = "64";
      cellHeight = "64";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(particles_spiralImageMap) {
      imageName = "./images/particles_spiral.png";
      imageMode = "CELL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "1";
      preferPerf = "1";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "2";
      cellCountY = "2";
      cellWidth = "64";
      cellHeight = "64";
      preload = "1";
      allowUnload = "0";
   };
   new t2dImageMapDatablock(tracksImageMap) {
      imageName = "./images/tracks.png";
      imageMode = "FULL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "1";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";
   };
   new t2dAnimationDatablock(particles_arcAnimation) {
      imageMap = "particles_arcImageMap";
      animationFrames = "0 1 2 3";
      animationTime = "0.4";
      animationCycle = "1";
      randomStart = "0";
      startFrame = "0";
   };
   new t2dImageMapDatablock(puzzlesymbol_crossImageMap) {
      canSaveDynamicFields = "1";
      imageName = "./images/symbol_cross";
      imageMode = "FULL";
      frameCount = "-1";
      filterMode = "SMOOTH";
      filterPad = "0";
      preferPerf = "0";
      cellRowOrder = "1";
      cellOffsetX = "0";
      cellOffsetY = "0";
      cellStrideX = "0";
      cellStrideY = "0";
      cellCountX = "-1";
      cellCountY = "-1";
      cellWidth = "0";
      cellHeight = "0";
      preload = "1";
      allowUnload = "0";
   };
};