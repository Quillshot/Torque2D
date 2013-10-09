///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

////
//
// configureFrame() currently supports 4 frame configs:
// 0 - No frame
// 1 - Blank frame "800 600" play area
// 2 - "600 450" play area @ offset "100 50"
// 3 - "600 450" play area @ offset "0 50"
// 4 - "700 525" play area @ offset "50 25"
// 5 - "600 450" play area @ offset "200 50"
// 6 - "700 525" play area @ offset "100 25"
// 7 - "700 525" play area @ offset "0 25"
//
// The above play areas, all have the same aspect ratio => 1.33
//
// When using a non-zero frame config, be sure to pass in an appropriate image
// There are template images for configs 1..7 in ~/gui/images/
// underlayBack.png - Config 1
// dummyBack2.png - Config 2 w/ dimension text
// dummyBack3.png - Config 3 w/ dimension text
// dummyBack4.png - Config 4 w/ dimension text
// dummyBack5.png - Config 5 w/ dimension text
// dummyBack6.png - Config 6 w/ dimension text
// dummyBack7.png - Config 7 w/ dimension text
// dummyBack[2,7]b.png - Same as prior six w/o text
//
////

function mainScreenGui::configureFrame( %this, %frameConfig, %frameImage )
{
   %posXList = "0 0 100 0 50 200 100 0";
   %posYList = "0 0 50 50 25 50 25 25";
   %extXList = "800 800 600 600 700 600 700 700";
   %extYList = "600 600 450 450 525 450 525 525";

   %posX = getWord( %posXList, %frameConfig );
   %posY = getWord( %posYList, %frameConfig  );
   %extX = getWord( %extXList, %frameConfig  );
   %extY = getWord( %extYList, %frameConfig  );

   ////
   //   No Frame
   ////
   if( %frameConfig == 0)
   {
      gameBackground.setVisible( false );
      sceneWindow2D.setPosition(0, 0);
      sceneWindow2D.setExtent(%extX, %extY);

   }
   ////
   //   Full-Sized Underlay Frame
   ////
   else if( %frameConfig == 1)
   {
      gameBackground.setVisible( true );
      gameBackground.setBitmap(%frameImage);
      sceneWindow2D.setPosition(%posX, %posY);
      sceneWindow2D.setExtent(%extX, %extY);     
   }
   ////
   //   (6) Frame Variations
   ////
   else if( %frameConfig < 8 )
   {
      gameBackground.setVisible( true );
      gameBackground.setBitmap(%frameImage);
      sceneWindow2D.setPosition(%posX, %posY);
      sceneWindow2D.setExtent(%extX, %extY);     
   }
}
