///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------
function GuiControl::addAttributesTabPage( %this )
{
   /////////////////////////
   // TAB PAGE: Attributes
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
      text = "Attributes";
      maxLength = "255";
      tooltipprofile = "GuiDefaultProfile";
      //ToolTip = "Game Object Attributes (HP, Energy, Layer, etc.)";

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
         text = "Game Object Attributes";
         maxLength = "255";
      };
      new GuiScrollCtrl(SSKQ_AttributesMatrix) 
      {
         canSaveDynamicFields = "0";
         Profile = "GuiScrollProfile";
         HorizSizing = "right";
         VertSizing = "bottom";
         Position = "30 30";
         Extent = "745 290";
         MinExtent = "8 2";
         canSave = "1";
         Visible = "1";
         hovertime = "1000";
         willFirstRespond = "1";
         hScrollBar = "alwaysOn";
         vScrollBar = "alwaysOn";
         constantThumbHeight = "0";
         childMargin = "0 0";     
      };
   };
   %this.add(%thisPage);
}


////
//    Attributes Page
////
function SSKQ_AttributesMatrix::onRemove(%this)
{  
}

function SSKQ_AttributesMatrix::onWake(%this)
{  
   %numGameObjects = SSKQ_GameObjectsList.rowCount();
   for(%count = 0; %count < %numGameObjects; %count++)
   {
      %objNames[%count] = SSKQ_GameObjectsList.getRowText( %count );
   }
   
   if( isObject( AttributesSheet ) ) AttributesSheet.delete( );
   
   %attributes = "Layer";
   
   %numAttributes = getFieldCount( %attributes );
   
   %widthHeaderText = 100;
   %offset = 5;
   %widthText = 100;
   %widthTextEdit = 60;
   %width = %widthText + %offset + %widthTextEdit;

   new guiControl( AttributesSheet ) 
   {
      position  = "8 0";
      extent    = %width + %numAttributes * %width SPC %numGameObjects * 25;
   };

   for(%count = 0; %count < %numGameObjects; %count++)
   {
      %name1 = %objNames[%count];
      
      %obj = new GuiTextCtrl() {
         canSaveDynamicFields = "0";
         Profile = "GuiSSKQTextProfile";
         HorizSizing = "right";
         VertSizing = "bottom";
         Position = "4" SPC 2 + %count * 25;
         Extent = %widthHeaderText SPC "25";
         MinExtent = "8 8";
         canSave = "1";
         Visible = "1";
         hovertime = "1000";
         text = %name1;
         maxLength = "255";
      };
      
      AttributesSheet.add( %obj );
      
      // Layer Popup Menu
      %popupName = %name1 @ "_" @ "Layer";
      
      %obj = new GuiControl() {
         canSaveDynamicFields = "0";
         isContainer = "1";
         Profile = "SSKQ_GuiBack0";
         HorizSizing = "right";
         VertSizing = "bottom";
         //position = %widthHeaderText + %count2 * %width SPC %count * 25;
         position = %widthHeaderText SPC %count * 25;
         Extent = %width SPC "25";
         MinExtent = "8 8";
         canSave = "1";
         Visible = "1";
         hovertime = "1000";

         new GuiPopUpMenuCtrl(%popupName) {
            class = "LayerPopupMenu";
            canSaveDynamicFields = "0";
            Profile = "GuiPopUpMenuProfile";
            HorizSizing = "right";
            VertSizing = "bottom";
            Position = "2 2";
            Extent = %widthTextEdit SPC "25";
            MinExtent = "8 8";
            canSave = "1";
            Visible = "1";
            hovertime = "1000";
            maxLength = "255";
            maxPopupHeight = "200";
         };

         new GuiTextCtrl() {
            canSaveDynamicFields = "0";
            Profile = "GuiSSKQLeftTextProfile";
            HorizSizing = "right";
            VertSizing = "bottom";
            Position = (2 + %widthTextEdit + %offset) SPC 2;
            Extent = %widthText SPC "25";
            MinExtent = "8 8";
            canSave = "1";
            Visible = "1";
            hovertime = "1000";
            text = "Layer";
            maxLength = "255";
         };
      };
      
      for(%layers = 0; %layers < 32; %layers++)
      {
         (%popupName).add(%layers,%layers);
      }
      if( ! SSKQuestionaireMemory.LayerMatrix[ %popupName ] )
      {
         (%popupName).setSelected(0);
      }
      else
      {
         (%popupName).setSelected( SSKQuestionaireMemory.LayerMatrix[ %popupName ] );
      }
      AttributesSheet.add( %obj );  
    }
   SSKQ_AttributesMatrix.add(AttributesSheet);
}

function AttributesTextEditField::onAdd( %this )
{
   %this.doRestore();
}

function AttributesTextEditField::onRemove( %this )
{
   %this.doStore();
}

function AttributesTextEditField::doStore( %this )
{
   %name = %this.getName();
   %val  = %this.getValue();
   
   SSKQuestionaireMemory.HPEngMatrix[ %name ] = %val;
}

function AttributesTextEditField::doRestore( %this )
{
   %name = %this.getName();
   

   if( SSKQuestionaireMemory.HPEngMatrix[ %name ]  )
   {
      %this.setValue( SSKQuestionaireMemory.HPEngMatrix[ %name ] );
   }

}

function LayerPopupMenu::onSelect(%this, %id, %text)
{
   %name = %this.getName();
   SSKQuestionaireMemory.LayerMatrix[ %name ] = %text;
   
   //echo("LayerPopupMenu::onSelect() - ", %name SPC %text );
}
