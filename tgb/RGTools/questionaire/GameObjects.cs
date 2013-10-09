///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------
////
//   Game Objects Page
////



function GuiControl::addGameObjectsTabPage( %this )
{
   /////////////////////////
   // TAB PAGE: Game Objects
   /////////////////////////
   %thisPage = new GuiTabPageCtrl() 
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
      text = "Objects";
      maxLength = "255";
      tooltipprofile = "GuiDefaultProfile";
      //ToolTip = "Game Objects";
            
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
         text = "Game Objects";
         maxLength = "255";
      };

      new GuiScrollCtrl() 
      {
         canSaveDynamicFields = "0";
         Profile = "GuiScrollProfile";
         HorizSizing = "right";
         VertSizing = "bottom";
         Position = "30 30";
         Extent = "745 220";
         MinExtent = "8 2";
         canSave = "1";
         Visible = "1";
         hovertime = "1000";
         willFirstRespond = "1";
         hScrollBar = "alwaysOn";
         vScrollBar = "alwaysOn";
         constantThumbHeight = "0";
         childMargin = "0 0";     
               
         new GuiTextListCtrl(SSKQ_GameObjectsList) 
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

      new GuiTextEditCtrl(SSKQ_CurGameObject) 
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
         Command = "SSKQ_AddGameObject();";
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
         Command = "SSKQ_RenameGameObject();";
         hovertime = "1000";
         text = "Rename";
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
         Command = "SSKQ_DeleteGameObject();";
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
         Command = "SSKQ_GameObjectsList.clear();";
         hovertime = "1000";
         text = "Delete All";
         groupNum = "-1";
         buttonType = "PushButton";
         useMouseEvents = "0";
      };       
   };

   %this.add(%thisPage);
}



function SSKQ_GameObjectsList::onAdd(%this)
{
   %this.uniqueEntryNum = 0;  
   //SSKQ_DebugAddGameObject( "player" );
   //SSKQ_DebugAddGameObject( "playerBullet" );
   //SSKQ_DebugAddGameObject( "enemy" );
   //SSKQ_DebugAddGameObject( "enemyBullet" );
   //SSKQ_DebugAddGameObject( "wall" );
   //SSKQ_DebugAddGameObject( "turret" );

   //SSKQ_DebugAddGameObject( "A" );
   //SSKQ_DebugAddGameObject( "B" );
   //SSKQ_DebugAddGameObject( "C" )   ;
   //SSKQ_DebugAddGameObject( "D" );
}

function SSKQ_GameObjectsList::onDeleteKey( %this , %entry )
{
   //echo( "SSKQ_GameObjectsList::onDeleteKey(", %this, " , ", %entry, " )");
   SSKQ_DeleteCoreMechanic();
}

function SSKQ_GameObjectsList::onSelect( %this , %entry )
{
   //echo( "SSKQ_GameObjectsList::onSelect(", %this, " , ", %entry, " )");
   %entryText = SSKQ_GameObjectsList.getRowTextById( %entry );
   SSKQ_CurGameObject.setValue( %entryText );
}

function SSKQ_GameObjectsRefresh( )
{
   //SSKQ_GameObjectsList.sort(0);
   SSKQ_AttributesMatrix.onWake(); // cheat to refresh list
   SSKQ_CollidesWithMatrix.onWake(); // cheat to refresh list
   
   // Known objects
   %knownObjects = "";
   %numGameObjects = SSKQ_GameObjectsList.rowCount();
   for(%count = 0; %count < %numGameObjects; %count++)
   {
      %knownObjects = %knownObjects SPC SSKQ_GameObjectsList.getRowText( %count );
      if(%text $= %curObjectName) return; // No duplicates allowed
   }
   %knownObjects = trim( %knownObjects );
   
   collidesWithSheet.knownObjects = %knownObjects;

}


function SSKQ_DebugAddGameObject( %curObjectName )
{
   
   if( %curObjectName $= "") return;
   
   %numGameObjects = SSKQ_GameObjectsList.rowCount();
   
   if(%numGameObjects >= 32) return; // Max of 32 object types in a game
   
   for(%count = 0; %count < %numGameObjects; %count++)
   {
      %text = SSKQ_GameObjectsList.getRowText( %count );
      
      if(%text $= %curObjectName) return; // No duplicates allowed
   }
   
   SSKQ_GameObjectsList.addRow( SSKQ_GameObjectsList.uniqueEntryNum, %curObjectName );
   
   SSKQ_GameObjectsRefresh();
   
   SSKQ_GameObjectsList.uniqueEntryNum++;   
}


function SSKQ_AddGameObject()
{
   %curObjectName = SSKQ_CurGameObject.getValue();
   
   if( %curObjectName $= "") return;
   
   %numGameObjects = SSKQ_GameObjectsList.rowCount();
   
   if(%numGameObjects >= 32) return; // Max of 32 object types in a game
   
   for(%count = 0; %count < %numGameObjects; %count++)
   {
      %text = SSKQ_GameObjectsList.getRowText( %count );
      
      if(%text $= %curObjectName) return; // No duplicates allowed
   }
   
   SSKQ_GameObjectsList.addRow( SSKQ_GameObjectsList.uniqueEntryNum, %curObjectName );
   
   SSKQ_GameObjectsRefresh();
   
   SSKQ_GameObjectsList.uniqueEntryNum++;   
}

function SSKQ_GetGameObjectTypesCount()
{
   %numGameObjects = SSKQ_GameObjectsList.rowCount();
   
   return %numGameObjects;
}

function SSKQ_GetGameObjectTypesList()
{
   %numGameObjects = SSKQ_GameObjectsList.rowCount();
   
   //error( "%numGameObjects == ", %numGameObjects );
   
   for(%count = 0; %count < %numGameObjects; %count++)
   {
      %text = SSKQ_GameObjectsList.getRowText( %count );
      
      //error( "%text == ", %text );
      
      %typeList = %typeList SPC %text;
   }

   
   return trim( %typeList );
}


function SSKQ_RenameGameObject()
{
   %curObjectName = SSKQ_CurGameObject.getValue();
   
   if( %curObjectName $= "") return;
   
   %numGameObjects = SSKQ_GameObjectsList.rowCount();
   
   for(%count = 0; %count < %numGameObjects; %count++)
   {
      %text = SSKQ_GameObjectsList.getRowText( %count );
      
      if(%text $= %curObjectName) return; // No duplicates allowed
   }
   
   %selID = SSKQ_GameObjectsList.getSelectedID();
   
   if(%selID == -1 ) return;
   
   SSKQ_GameObjectsList.setRowByID( %selID, %curObjectName );

   SSKQ_GameObjectsRefresh();

}

function SSKQ_DeleteGameObject()
{
   %selID = SSKQ_GameObjectsList.getSelectedID();
   
   if(%selID == -1 ) return;

   SSKQ_GameObjectsList.removeRowByID( %selID );
   
   SSKQ_GameObjectsRefresh();
}
