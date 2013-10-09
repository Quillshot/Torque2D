///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------
function exampleFrame5() // Designed for 800 x 600 Resolution
{
   // Select which frame to use
   mainScreenGui.configureFrame( 5, expandFilename("~/gui/images/protoBack5.png") );

   if($enableScoreCounter)
   {
      // Score Counter
      gameBackground.addLabel( "Score:", "IFCTextProfile_S", 25, 5, 100, 40 );
      gameBackground.addNumericCounter( "scoreCounter", "IFCTextProfile_S", 130, 5, 200, 40 );
   }

   if($enableLivesCounter)
   {
      // Lives Counter
      gameBackground.addLabel( "Lives:", "IFCTextProfile_S", 625, 5, 100, 40 );
      gameBackground.addNumericCounter( "livesCounter", "IFCTextProfile_S", 730, 5, 70, 40 );
   }
   
   if($enableDamageMeter)
   {
      // Damage Meter
      gameBackground.addIcon( 25, 450, 50, 50, expandFilename("~/gui/images/icons/damageIcon40.png") );
      gameBackground.addVerticalBarMeter( "damageMeterBack" , 30, 75, 40, 375, "IFCFill_Red" );
      gameBackground.addVerticalBarMeter( "damageMeter" , 30, 75, 40, 375, "IFCFill_Green" );
   }

   if($enableEnergyMeter)
   {
      // Energy Meter
      gameBackground.addIcon( 125, 450, 50, 50, expandFilename("~/gui/images/icons/energyIcon40.png") );
      gameBackground.addVerticalBarMeter( "energyMeter" , 130, 75, 40, 375, "IFCFill_Blue" );
   }

   if($GameNameLabel !$= "")
   {
      // Energy Meter
      gameBackground.addLabel( $GameNameLabel, "IFCTextProfile_S", 300, 5, 200, 40 );
   }

   if($CompanyNameLabel !$= "")
   {
      // Energy Meter
      gameBackground.addLabel( $CompanyNameLabel, "IFCTextProfile_S", 500, 550, 300, 40 );
   }

}
