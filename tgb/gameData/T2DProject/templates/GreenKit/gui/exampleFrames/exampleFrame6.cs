///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------
function exampleFrame6() // Designed for 800 x 600 Resolution
{
   // Select which frame to use
   mainScreenGui.configureFrame( 6, expandFilename("~/gui/images/protoBack6.png") );

   if($enableScoreCounter)
   {
      // Score Counter
      gameBackground.addLabel( "Score:", "IFCTextProfile_S", 25, 555, 100, 40 );
      gameBackground.addNumericCounter( "scoreCounter", "IFCTextProfile_S", 130, 555, 200, 40 );
   }

   if($enableLivesCounter)
   {
      // Lives Counter
      gameBackground.addLabel( "Lives:", "IFCTextProfile_S", 625, 555, 100, 40 );
      gameBackground.addNumericCounter( "livesCounter", "IFCTextProfile_S", 730, 555, 70, 40 );
   }
   
   if($enableDamageMeter)
   {
      // Damage Meter
      gameBackground.addIcon( 0, 450, 50, 50, expandFilename("~/gui/images/icons/damageIcon40.png") );
      gameBackground.addVerticalBarMeter( "damageMeterBack" , 10, 75, 30, 375, "IFCFill_Red" );
      gameBackground.addVerticalBarMeter( "damageMeter" , 10, 75, 30, 375, "IFCFill_Green" );
   }

   if($enableEnergyMeter)
   {
      // Energy Meter
      gameBackground.addIcon( 50, 450, 50, 50, expandFilename("~/gui/images/icons/energyIcon40.png") );
      gameBackground.addVerticalBarMeter( "energyMeter" , 60, 75, 30, 375, "IFCFill_Blue" );
   }

   // Can't Fit Game Name

   if($CompanyNameLabel !$= "")
   {
      // Energy Meter
      gameBackground.addLabel( $CompanyNameLabel, "IFCTextProfile_S", 300, 555, 300, 40 );
   }

}
