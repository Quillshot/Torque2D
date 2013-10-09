///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------
$enableScoreCounter = true;
$enableLivesCounter = true;
$enableDamageMeter  = true;
$enableEnergyMeter  = true;
$GameNameLabel      = "A Cool Game";
$CompanyNameLabel   = "Uses Green Kit";

function initializeGUIs()
{
   // Load up the in game gui.
   exec("./profiles.cs");
   exec("./mainScreen.cs");
   exec("./basicCounters.cs");
   exec("./mainScreen.gui");
   exec("./mainMenu/mainMenu.gui"); 
   exec("./splashScreen/splashScreen.gui");
   
   
   exec("./exampleFrames/exampleFrame2.cs");
   exec("./exampleFrames/exampleFrame3.cs");
   exec("./exampleFrames/exampleFrame4.cs");
   exec("./exampleFrames/exampleFrame5.cs");
   exec("./exampleFrames/exampleFrame6.cs");
   exec("./exampleFrames/exampleFrame7.cs");

   // Use only one (or none for no frame):
   //exampleFrame2();   
   //exampleFrame3();   
   //exampleFrame4);   
   //exampleFrame5();   
   //exampleFrame6();   
   //exampleFrame7();   
}
initializeGUIs();
