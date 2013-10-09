//------------------------------------------------------
// Copyright, Roaming Gamer, LLC.
//------------------------------------------------------
$RG::DeveloperMode = false;
function addRGMenu() 
{
   if($RG::DeveloperMode)
   {
      %RGMenu = new PopupMenu(RGMenu)
      {
         superClass = "MenuBuilder";
         barPosition = 99; // make this the last menu 
         barName     = "RGTools";
      
         //EFM OLD item[0] = "Behaviors Generator..." TAB $cmdCtrl SPC "G" TAB "Canvas.pushDialog(resourceGeneratorDlg);";
         item[0] = "Behaviors Generator..." TAB $cmdCtrl SPC "G" TAB "Canvas.pushDialog(onDemandGeneratorDlg);";
         item[1] = "-";
         item[2] = "Datablock Manager..." TAB $cmdCtrl SPC "D" TAB "Canvas.pushDialog(datablockManagerDlg);";
         item[3] = "Create Managed Datablock..." TAB "Ctrl" SPC "M" TAB "saveDBToManagedDB();";
         item[4] = "-";
         item[5] = "Create Managed Datablock from clipboard" TAB "Alt" SPC "M" TAB "doGenerateDatablock(\"\",\"managed\",\"clipboard\");";
         item[6] = "-";      
         item[7] = "Copy datablock of selected object to clipboard..." TAB "Alt" SPC "C" TAB "copyDBToClipboard();";      
         item[8] = "Copy builder script for selected object to clipboard..." TAB "Alt" SPC "B" TAB "copyBuilderScriptToClipboard();";
         item[9] = "-";
         item[10] = "Analyze behavior usage and save to clipboard... (Caution: Save Before Running!)" TAB "" SPC "" TAB "bua(ToolManager.getLastWindow().getSceneGraph(), fileName($levelEditor::LastLevel));";
         item[11] = "-";
         item[12] = "SSK Game Design Questionaire" TAB "Ctrl" SPC "Q" TAB "Canvas.pushDialog(SSKQuestionaireDlg);";      
         item[13] = "More great stuff!" TAB "" TAB "gotowebpage(\"http://roaminggamer.com/\");";      
      };
   }
   else
   {
      %RGMenu = new PopupMenu(RGMenu)
      {
         superClass = "MenuBuilder";
         barPosition = 99; // make this the last menu 
         barName     = "RGTools";
      
         item[0] = "Datablock Manager..." TAB $cmdCtrl SPC "D" TAB "Canvas.pushDialog(datablockManagerDlg);";
         item[1] = "Create Managed Datablock..." TAB "Ctrl" SPC "M" TAB "saveDBToManagedDB();";
         item[2] = "-";
         item[3] = "Create Managed Datablock from clipboard" TAB "Alt" SPC "M" TAB "doGenerateDatablock(\"\",\"managed\",\"clipboard\");";
         item[4] = "-";      
         item[5] = "Copy datablock of selected object to clipboard..." TAB "Alt" SPC "C" TAB "copyDBToClipboard();";      
         item[6] = "Copy builder script for selected object to clipboard..." TAB "Alt" SPC "B" TAB "copyBuilderScriptToClipboard();";
         item[7] = "-";
         item[8] = "Analyze behavior usage and save to clipboard... (Caution: Save Before Running!)" TAB "" SPC "" TAB "bua(ToolManager.getLastWindow().getSceneGraph(), fileName($levelEditor::LastLevel));";
         item[9] = "-";
         item[10] = "More great stuff!" TAB "" TAB "gotowebpage(\"http://roaminggamer.com/\");";      
      };
   }
      
   // Submenus will be deleted when the menu they are in is deleted
   LevelBuilderBase.menuGroup.add(%RGMenu);
}
