///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

////
//   Collision Page
////

function GuiControl::addCollisionTabPage( %this )
{
   /////////////////////////
   // TAB PAGE: Collision
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
      text = "Collides With";
      maxLength = "255";
      tooltipprofile = "GuiDefaultProfile";
      //ToolTip = "Collides With";
      tooltipprofile = "GuiDefaultProfile";
      //ToolTip = "Collides With";

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
         text = "Collides With";
         maxLength = "255";
      };
            
      new GuiScrollCtrl(SSKQ_CollidesWithMatrix) 
      {
         canSaveDynamicFields = "0";
         Profile = "GuiScrollProfile";
         HorizSizing = "right";
         VertSizing = "bottom";
         Position = "30 30";
         Extent = "745 260";
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
         Command = "SSKQ_doCollidesWithClear();";
         hovertime = "1000";
         text = "Clear";
         groupNum = "-1";
         buttonType = "PushButton";
         useMouseEvents = "0";
      };
   };
   %this.add(%thisPage);
}




function SSKQ_CollidesWithMatrix::onWake(%this)
{  
   %numGameObjects = SSKQ_GameObjectsList.rowCount();
   for(%count = 0; %count < %numGameObjects; %count++)
   {
      %objNames[%count] = SSKQ_GameObjectsList.getRowText( %count );
   }
   
   if( isObject( collidesWithSheet ) ) collidesWithSheet.delete( );
   
   %widthHeaderText = 100;
   %width = 100;

   new guiControl( collidesWithSheet ) 
   {
      position  = "8 0";
      extent    = %width + %numGameObjects * %width SPC %numGameObjects * 25;
   };

   for(%count = 0; %count < %numGameObjects; %count++)
   {
      %name1 = %objNames[%count];
      
      %obj = new GuiTextCtrl() {
         canSaveDynamicFields = "0";
         Profile = "GuiSSKQTextProfile";
         HorizSizing = "right";
         VertSizing = "bottom";
         Position = "4" SPC %count * 25;
         Extent = %widthHeaderText SPC "25";
         MinExtent = "8 8";
         canSave = "1";
         Visible = "1";
         hovertime = "1000";
         text = %name1;
         maxLength = "255";
      };
      
      collidesWithSheet.add( %obj );
      
      for(%count2 = 0; %count2 < %numGameObjects; %count2++)
      {
         %name2 = %objNames[%count2];

         %name = %name1 @ "_" @ %name2 @ "_COL";
         if( (%count2 % 2) == 0 ) 
         {
            %profile = "SSKQ_GuiBack0";
         }
         else
         {
            %profile = "SSKQ_GuiBack1";
         }
         %obj = new GuiControl() {
            canSaveDynamicFields = "0";
            isContainer = "1";
            Profile = %profile;
            HorizSizing = "right";
            VertSizing = "bottom";
            position = %widthHeaderText + %count2 * %width SPC %count * 25;
            Extent = %width SPC "25";
            MinExtent = "8 8";
            canSave = "1";
            Visible = "1";
            hovertime = "1000";
   
            new GuiCheckBoxCtrl( %name ) {
               class = "collidesWithCheckBox";
               canSaveDynamicFields = "0";
               Profile = "GuiSSKCheckBoxProfile";
               HorizSizing = "right";
               VertSizing = "bottom";
               Position = "2 2";
               Extent = %width SPC "25";
               MinExtent = "8 8";
               canSave = "1";
               Visible = "1";
               hovertime = "1000";
               text = %name2;
               groupNum = "-1";
               buttonType = "ToggleButton";
            };
         };
         (%name).setvalue(SSKQuestionaireMemory.CollidesWithMatrix[ %name ]);
         collidesWithSheet.add( %obj );
      }
   }
   SSKQ_CollidesWithMatrix.add(collidesWithSheet);
}


function collidesWithCheckBox::onAction( %this )
{
   %name = %this.getName();
   %val  = %this.getValue();
   
   SSKQuestionaireMemory.CollidesWithMatrix[ %name ] = %val;
   
   %splitName = strreplace( %name , "_", " " );
   %otherName = getWord( %splitName, 1 ) @ "_" @ getWord( %splitName, 0 ) @ "_COL";
   
   //echo("collidesWithCheckBox::onAction() - ", %name SPC %val );
   //echo("collidesWithCheckBox::onAction() - ", %otherName );
   
   if(%name $= %otherName) return;
   
   (%otherName).setValue( %val );
   
   SSKQuestionaireMemory.CollidesWithMatrix[ %otherName ] = %val;
}



function SSKQ_doCollidesWithClear()
{
   %numGameObjects = SSKQ_GameObjectsList.rowCount();
   for(%count = 0; %count < %numGameObjects; %count++)
   {
      %objNames[%count] = SSKQ_GameObjectsList.getRowText( %count );
   }

   for(%count = 0; %count < %numGameObjects; %count++)
   {
      %name1 = %objNames[%count];
      for(%count2 = 0; %count2 < %numGameObjects; %count2++)
      {
         %name2 = %objNames[%count2];

         %collidesWith = %name1 @ "_" @ %name2 @ "_COL";
         %collidesWith2 = %name2 @ "_" @ %name1 @ "_COL";

         %collidesWith.setValue(0);
         SSKQuestionaireMemory.CollidesWithMatrix[ %collidesWith ] = 0;

         %collidesWith2.setValue(0);
         SSKQuestionaireMemory.CollidesWithMatrix[ %collidesWith2 ] = 0;
      }
   }
}


function collidesWithCheckBox::onAdd( %this )
{
   %this.doRestore();
}

function collidesWithCheckBox::onRemove( %this )
{
   %this.doStore();
}

function collidesWithCheckBox::doStore( %this )
{
   %name = %this.getName();
   %val  = %this.getValue();
   
   SSKQuestionaireMemory.CollidesWithMatrix[ %name ] = %val;
}

function collidesWithCheckBox::doRestore( %this )
{
   %name = %this.getName();
   

   if( SSKQuestionaireMemory.CollidesWithMatrix[ %name ]  )
   {
      %this.setValue( SSKQuestionaireMemory.CollidesWithMatrix[ %name ] );
   }

}
