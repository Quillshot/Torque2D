function rldtp()
{
   exec("./ToolPopup.cs");
}

function ToolPopup::onWake( %theControl )
{
   
   GlobalActionMap.bind(mouse, "CTRL button0", doToolPopup);
   
}

function ToolPopup::onSleep( %theControl )
{   
   GlobalActionMap.unbind(mouse, "CTRL button0");
   if( isObject( ToolPopupScroll ) ) ToolPopupScroll.delete();
}





function doToolPopup( %object )
{
   if( !%object ) return;

   %objectsList = SSKQ_GetGameObjectTypesList();
   
   if( %objectsList $= "" ) return;
   
   if( isObject( ToolPopupScroll ) )
   {
      ToolPopupScroll.delete();
   }
   
   if( !isObject( ToolPopupScroll ) )
   {
      new guiScrollCtrl ( ToolPopupScroll )
      {
         position = LevelBuilderBase.extent; // Start offscreen
         extent   = "100 200";   
         hScrollBar = "alwaysOff";      
         vScrollBar = "alwaysOff";
         
         new guiStackControl( ToolPopupStack ) 
         {
            extent = "100 100";
         };
      };
      
      LevelBuilderBase.add( ToolPopupScroll );
      addLevelBuilderBase(%object, %objectsList);
   }    

   placeToolPopup();
}

function removeToolPopup()
{
   if( isObject( ToolPopupScroll ) )
   {
      //ToolPopupScroll.schedule(0,setVisible,false);
      ToolPopupScroll.schedule(100,delete);
   }
}

function addLevelBuilderBase(%object, %objectsList)
{
   %buttoncount = getWordCount(%objectsList) + 2;
   
   %objectsList = "Cancel Update" SPC %objectsList;
   
   
   ToolPopupScroll.extent = "100" SPC 30 * %buttoncount;
   for( %count = 0; %count < %buttoncount; %count++ )
   {
      %buttonText = getWord( %objectsList, %count );
      
      switch( %count )
      {
      case 0:  %buttonCommand = "removeToolPopup();";
      case 1:  %buttonCommand = "RGQC.reApplyQC( " @ %object @ " ); removeToolPopup();";
      default: %buttonCommand = "RGQC.applyQC( " @ %object @ ", " @ %buttonText @ "  ); removeToolPopup();";
      }
      
      
      
      
      %button = new guiButtonCtrl()
      {
         text = %buttonText;
         command = %buttonCommand;
         extent = "100 30";
      };
      ToolPopupStack.add( %button );
   }
   
   
}

function placeToolPopup()
{
   
   %cursorPos = Canvas.getCursorPos();
   
   %offset = vectorSub( %cursorPos , LevelBuilderBase.position  );

   echo("%cursorPos                 == ", %cursorPos  );
   echo("LevelBuilderBase.position  == ", LevelBuilderBase.position  );
   echo("%offset                    == ", %offset  );
   
   // Prevent popup from extending past right edge or parent
   if( ( getWord( %offset , 0 ) +  getWord( ToolPopupScroll.extent , 0 ) ) >
       getWord( ToolPopupScroll.getGroup().extent , 0 ) ) 
   {
      %offset = setWord( %offset , 0 ,( getWord( ToolPopupScroll.getGroup().extent , 0 ) - getWord( ToolPopupScroll.extent , 0 )  )  );
   }

   // Prevent popup from extending past bottom edge or parent
   if( ( getWord( %offset , 1 ) +  getWord( ToolPopupScroll.extent , 1 ) ) >
       getWord( ToolPopupScroll.getGroup().extent , 1 ) ) 
   {
      %offset = setWord( %offset , 1 ,( getWord( ToolPopupScroll.getGroup().extent , 1 ) - getWord( ToolPopupScroll.extent , 1 )  )  );
   }


   echo("updated %offset            == ", %offset , "\n" );

   ToolPopupScroll.position = %offset;   
}

