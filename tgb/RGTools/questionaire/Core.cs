///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

function GuiControl::addCoreTabPage( %this )
{
   /////////////////////////
   // TAB PAGE: Core
   /////////////////////////
   %thePage = new GuiTabPageCtrl() 
   {
      canSaveDynamicFields = "0";
      internalName = "ControlSSKQuestionaireTabPage";
      isContainer = "1";
      Profile = "GuiTabPageProfile";
      HorizSizing = "relative";
      VertSizing = "relative";
      position = "0 22";
      Extent = "794 345";
      MinExtent = "8 2";
      canSave = "1";
      Visible = "0";
      hovertime = "1000";
      text = "Core";
      maxLength = "255";
      tooltipprofile = "GuiDefaultProfile";
      //ToolTip = "Core Mechanics";

      new GuiTextCtrl() 
      {
         canSaveDynamicFields = "0";
         Profile = "GuiSSKQCenterTextProfile";
         HorizSizing = "right";
         VertSizing = "bottom";
         Position = "0 5";
         Extent = "794 18";
         MinExtent = "8 8";
         canSave = "1";
         Visible = "1";
         hovertime = "1000";
         text = "Core Mechanics";
         maxLength = "255";
         };
            
      new GuiTextCtrl() 
      {
         canSaveDynamicFields = "0";
         Profile = "GuiTextProfile";
         HorizSizing = "right";
         VertSizing = "bottom";
         Position = "30 30";
         Extent = "70 18";
         MinExtent = "8 8";
         canSave = "1";
         Visible = "1";
         hovertime = "1000";
         text = "Game Name:";
         maxLength = "255";
      };

      new GuiTextEditCtrl(SSKQ_GameName) 
      {
         canSaveDynamicFields = "0";
         internalName = "textEdit";
         isContainer = "0";
         Profile = "GuiTextEditProfile";
         HorizSizing = "right";
         VertSizing = "center";
         Position = "110 30";
         Extent = "665 18";
         MinExtent = "8 20";
         canSave = "1";
         Visible = "1";
         //Command = "$ThisControl.getParent().updateFromChild($ThisControl);";
         hovertime = "1000";
         text = "";
         maxLength = "1024";
         historySize = "0";
         password = "0";
         tabComplete = "0";
         sinkAllKeyEvents = "0";
         password = "0";
         passwordMask = "*";
      };
      new GuiTextCtrl() 
      {
         canSaveDynamicFields = "0";
         Profile = "GuiTextProfile";
         HorizSizing = "right";
         VertSizing = "bottom";
         Position = "30 60";
         Extent = "70 18";
         MinExtent = "8 8";
         canSave = "1";
         Visible = "1";
         hovertime = "1000";
         text = "Goal:";
         maxLength = "255";
      };

      new GuiTextEditCtrl(SSKQ_GameGoal) 
      {
         canSaveDynamicFields = "0";
         internalName = "textEdit";
         isContainer = "0";
         Profile = "GuiTextEditProfile";
         HorizSizing = "right";
         VertSizing = "center";
         Position = "110 60";
         Extent = "665 18";
         MinExtent = "8 20";
         canSave = "1";
         Visible = "1";
         //Command = "$ThisControl.getParent().updateFromChild($ThisControl);";
         hovertime = "1000";
         text = "";
         maxLength = "1024";
         historySize = "0";
         password = "0";
         tabComplete = "0";
         sinkAllKeyEvents = "0";
         password = "0";
         passwordMask = "*";
      };
      new GuiTextCtrl() 
      {
         canSaveDynamicFields = "0";
         Profile = "GuiTextProfile";
         HorizSizing = "right";
         VertSizing = "bottom";
         Position = "30 90";
         Extent = "200 18";
         MinExtent = "8 8";
         canSave = "1";
         Visible = "1";
         hovertime = "1000";
         text = "Core Mechanics List:";
         maxLength = "255";
      };
            
      new GuiScrollCtrl() 
      {
         canSaveDynamicFields = "0";
         Profile = "GuiScrollProfile";
         HorizSizing = "right";
         VertSizing = "bottom";
         Position = "30 120";
         Extent = "745 130";
         MinExtent = "8 2";
         canSave = "1";
         Visible = "1";
         hovertime = "1000";
         willFirstRespond = "1";
         hScrollBar = "alwaysOn";
         vScrollBar = "alwaysOn";
         constantThumbHeight = "0";
         childMargin = "0 0";     
               
         new GuiTextListCtrl(SSKQ_CoreMechanicsList) 
         {
            profile = "GuiTextListProfile";
            horizSizing = "right";
            vertSizing = "bottom";
            position = "2 2";
            extent = "80 16";
            minExtent = "8 2";
            visible = "1";
            enumerate = "0";
            resizeCell = "1";
            columns = "0";
            fitParentWidth = "1";
            clipColumnText = "0";
         };
      };

      new GuiTextEditCtrl(SSKQ_CurCoreMechanic) 
      {
         canSaveDynamicFields = "0";
         internalName = "textEdit";
         isContainer = "0";
         Profile = "GuiTextEditProfile";
         HorizSizing = "right";
         VertSizing = "center";
         Position = "30 260";
         Extent = "745 18";
         MinExtent = "8 20";
         canSave = "1";
         Visible = "1";
         //Command = "$ThisControl.getParent().updateFromChild($ThisControl);";
         hovertime = "1000";
         text = "";
         maxLength = "1024";
         historySize = "0";
         password = "0";
         tabComplete = "0";
         sinkAllKeyEvents = "0";
         password = "0";
         passwordMask = "*";
      };
      new GuiButtonCtrl() 
      {
         canSaveDynamicFields = "0";
         isContainer = "0";
         Profile = "GuiButtonProfile";
         HorizSizing = "right";
         VertSizing = "top";
         position = "40 298";
         Extent = "100 25";
         MinExtent = "8 2";
         canSave = "1";
         Visible = "1";
         Command = "SSKQ_AddCoreMechanic();";
         hovertime = "1000";
         text = "Add";
         groupNum = "-1";
         buttonType = "PushButton";
         useMouseEvents = "0";
      };
      new GuiButtonCtrl() 
      {
         canSaveDynamicFields = "0";
         isContainer = "0";
         Profile = "GuiButtonProfile";
         HorizSizing = "right";
         VertSizing = "top";
         position = "150 298";
         Extent = "100 25";
         MinExtent = "8 2";
         canSave = "1";
         Visible = "1";
         Command = "SSKQ_UpdateCoreMechanic();";
         hovertime = "1000";
         text = "Update";
         groupNum = "-1";
         buttonType = "PushButton";
         useMouseEvents = "0";
      };            
      new GuiButtonCtrl() 
      {
         canSaveDynamicFields = "0";
         isContainer = "0";
         Profile = "GuiButtonProfile";
         HorizSizing = "right";
         VertSizing = "top";
         position = "260 298";
         Extent = "100 25";
         MinExtent = "8 2";
         canSave = "1";
         Visible = "1";
         Command = "SSKQ_DeleteCoreMechanic();";
         hovertime = "1000";
         text = "Delete";
         groupNum = "-1";
         buttonType = "PushButton";
         useMouseEvents = "0";
      };            
      new GuiButtonCtrl() 
      {
         canSaveDynamicFields = "0";
         isContainer = "0";
         Profile = "GuiButtonProfile";
         HorizSizing = "right";
         VertSizing = "top";
         position = "370 298";
         Extent = "100 25";
         MinExtent = "8 2";
         canSave = "1";
         Visible = "1";
         Command = "SSKQ_CoreMechanicsList.clear();";
         hovertime = "1000";
         text = "Delete All";
         groupNum = "-1";
         buttonType = "PushButton";
         useMouseEvents = "0";
      };                        
   };
   
   %this.add(%thePage);
}


function SSKQ_CoreMechanicsList::onAdd(%this)
{
   %this.uniqueEntryNum = 0;  
}

function SSKQ_CoreMechanicsList::onDeleteKey( %this , %entry )
{
   //echo( "SSKQ_CoreMechanicsList::onDeleteKey(", %this, " , ", %entry, " )");
   SSKQ_DeleteCoreMechanic();
}

function SSKQ_CoreMechanicsList::onSelect( %this , %entry )
{
   //echo( "SSKQ_CoreMechanicsList::onSelect(", %this, " , ", %entry, " )");
   %entryText = SSKQ_CoreMechanicsList.getRowTextById( %entry );
   SSKQ_CurCoreMechanic.setValue( %entryText );
}

function SSKQ_AddCoreMechanic()
{
   %curCureMechanic = SSKQ_CurCoreMechanic.getValue();
   
   if( %curCureMechanic $= "") return;
   
   SSKQ_CoreMechanicsList.addRow( SSKQ_CoreMechanicsList.uniqueEntryNum, %curCureMechanic );
   
   SSKQ_CoreMechanicsList.uniqueEntryNum++;   
}

function SSKQ_UpdateCoreMechanic()
{
   %curCureMechanic = SSKQ_CurCoreMechanic.getValue();
   
   if( %curCureMechanic $= "") return;
   
   %selID = SSKQ_CoreMechanicsList.getSelectedID();
   
   if(%selID == -1 ) return;
   
   SSKQ_CoreMechanicsList.setRowByID( %selID, %curCureMechanic );
}

function SSKQ_DeleteCoreMechanic()
{
   %selID = SSKQ_CoreMechanicsList.getSelectedID();
   
   if(%selID == -1 ) return;

   SSKQ_CoreMechanicsList.removeRowByID( %selID );
}
