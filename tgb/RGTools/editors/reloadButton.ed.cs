//------------------------------------------------------
// Copyright, Roaming Gamer, LLC.
//------------------------------------------------------

function addRLCPButton()
{
   if(isObject(RLCPButton)) return;
   // Reposition the news label
   newRSSNewsLabel.setPosition(644,0);
   
   // Add our button   
   %rlcpButton = new GuiIconButtonCtrl(RLCPButton) 
   {
      canSaveDynamicFields = "0";
      Profile = "EditorButtonToolbar";
      HorizSizing = "left";
      VertSizing = "bottom";
      Position = "716 0";
      Extent = "25 25";
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      noFocusOnWake = "0";
      Command = "reloadProject();";
      tooltipprofile = "EditorToolTipProfile";
      ToolTip = "Reload Current Project";
      hovertime = "100";
      groupNum = "-1";
      buttonType = "PushButton";
      buttonMargin = "0 0";
      iconBitmap = "./images/iconRG.png";
      iconLocation = "Left";
      sizeIconToButton = "0";
      textLocation = "Left";
      textMargin = "4";
   };

   //levelBuilderMenu.add( %rlcpButton );
   LevelBuilderBase.add( %rlcpButton );
}

////EFM - move me later
//// Escape is already handled while editing, we need to handle
//// the 'after build project' case and have it either take us back to the
//// main menu, or have it quit the game.
//function escapeHandler()
//{
   //if(!$runWithEditors && $HOW::enableGameInterfaces )
   //{
      //if ($runningGame) endGame();
      //Canvas.setcontent( mainMenu );
   //}
   //else if(!$runWithEditors )
   //{
      //if ($runningGame) endGame();
      //quit();
   //}   
//}
//
