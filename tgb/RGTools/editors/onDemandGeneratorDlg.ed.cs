function rldodg()
{
   exec( "./onDemandGeneratorDlg.ed.cs" );
}

function onDemandGeneratorDlg::onWake( %this )
{
   if(!%this.wokeOnce)
   {
      loadAtoms();
      // Start with clear lists
      behaviorEventsList.clearItems();
      behaviorActionsList.clearItems();

      // EFM - HACK - It would be nice to have a cleaner way to get the current 
      // game's name, but this works...
      //%resourcePath = filePath(expandFilename("./onDemandGeneratorDlg.ed.cs"));
      //%resourcePath = strreplace( %resourcePath, "editors", "");
      //%resourcePath = %resourcePath @ "generatedBehaviors";
   
      //onDemandGeneratorDlg.resourcePath = %resourcePath;
      onDemandGeneratorDlg.resourcePath = filePath($pref::lastProject) @ "/game/behaviors/RG_BehaviorsAutoLoader/behaviors/";
      
      %this.wokeOnce = true;
   }
   
   // Sort the event and action category lists list
   $RG_BehaviorGenerator::categories[event] = sortFields( $RG_BehaviorGenerator::categories[event] );
   $RG_BehaviorGenerator::categories[action] = sortFields( $RG_BehaviorGenerator::categories[action] );

   // Clear the events category dropdown menu, then populate it with the known event categories
   eventCategoryMenu.clear();
   %eventCategoriesCount = getFieldCount( $RG_BehaviorGenerator::categories[event] );   
   for( %count = 0; %count < %eventCategoriesCount; %count++)
   {
      %eventCategory = getField( $RG_BehaviorGenerator::categories[event], %count );
      eventCategoryMenu.add(%eventCategory, %count);
   }
   
   // Clear the actions category dropdown menu, then populate it with the known action categories
   actionCategoryMenu.clear();
   %actionCategoriesCount = getFieldCount( $RG_BehaviorGenerator::categories[action] );
   for( %count = 0; %count < %actionCategoriesCount; %count++)
   {
      %actionCategory = getField( $RG_BehaviorGenerator::categories[action], %count );
      actionCategoryMenu.add(%actionCategory, %count);
   }   

   // Always select the last entry in each category dropdown to start
   
   eventCategoryMenu.setSelected(eventCategoryMenu.size()-1); 
   actionCategoryMenu.setSelected(actionCategoryMenu.size()-1); 
}


// Item from events category drop down was selected...
function eventCategoryMenu::onSelect(%this, %id, %text )
{
   eventSubCategoryMenu.clear();
   %eventSubCategoriesCount = getFieldCount( $RG_BehaviorGenerator::subCategories[event,%text] );
   
   for( %count = 0; %count < %eventSubCategoriesCount; %count++)
   {
      %eventSubCategory = getField( $RG_BehaviorGenerator::subCategories[event,%text], %count );
      eventSubCategoryMenu.add(%eventSubCategory, %count);
   }

   eventSubCategoryMenu.setSelected(0);    
    
   eventSubCategoryMenu.setVisible( %eventSubCategoriesCount > 1 );   //EFM set active does not work ?? Submitted as bug
}


// Item from events sub-category drop down was selected...
function eventSubCategoryMenu::onSelect(%this, %id, %text )
{
   %category = eventCategoryMenu.getText();
   behaviorEventsList.fill(%category,%text);
}

function clearEventListSelection::onClick( %this ) // This is where we make changes to handle multiple selections
{
   %category = eventCategoryMenu.getText();
   %subcategory = eventSubCategoryMenu.getText();
   behaviorEventsList.fill(%category,%subcategory);
}

// Item from actions category drop down was selected...
function actionCategoryMenu::onSelect(%this, %id, %text )
{
   // Hack to disable event side of generator for full behaviors
   // assumes the start with numbers between 0 .. 1000
   %firstWord = getWord( %text, 0);
   
   if ( (%firstWord $= "00") || ( (%firstWord * 2) != 0 ) )
   {
      eventCategoryMenu.setVisible( false );
      eventSubCategoryMenu.setVisible( false );
      behaviorEventsScroll.setVisible( false );
      error(%firstWord SPC "- hide it");
   }
   else
   {
      eventCategoryMenu.setVisible( true );
      eventSubCategoryMenu.setVisible( true );
      behaviorEventsScroll.setVisible( true );
      error(%firstWord SPC "- show it");
   }
   
   actionSubCategoryMenu.clear();
   %actionSubCategoriesCount = getFieldCount( $RG_BehaviorGenerator::subCategories[action,%text] );
   
   for( %count = 0; %count < %actionSubCategoriesCount; %count++)
   {
      %actionSubCategory = getField( $RG_BehaviorGenerator::subCategories[action,%text], %count );
      actionSubCategoryMenu.add(%actionSubCategory, %count);
   }
   
   actionSubCategoryMenu.setSelected(0);
   
   actionSubCategoryMenu.setVisible( %actionSubCategoriesCount > 1 ); //EFM set active does not work ?? Submitted as bug
}


// Item from actions sub-category drop down was selected...
function actionSubCategoryMenu::onSelect(%this, %id, %text )
{
   %category = actionCategoryMenu.getText();
   behaviorActionsList.fill(%category,%text);
}

function clearActionListSelection::onClick( %this ) // This is where we make changes to handle multiple selections
{
   %category = actionCategoryMenu.getText();
   %subcategory = actionSubCategoryMenu.getText();
   behaviorActionsList.fill(%category,%subcategory);
}

// Utility function to add entries to the events list
function behaviorEventsList::fill( %this, %category, %subcategory )
{
   behaviorEventsList.clearItems();
   
   %events = $RG_BehaviorGenerator::atoms[event,%category,%subcategory];   

   %eventsCount = getFieldCount( %events );

   for( %count = 0; %count < %eventsCount; %count++)
   {
      %event = getField( %events, %count );
      
      //%event_UID = getSubStrMarker( %event, $RG_BehaviorGenerator::UIDMarker, "" );
      //%event = getSubStrMarker( %event, "", $RG_BehaviorGenerator::UIDMarker );
      
      //onDemandGeneratorDlg.eventUID[%event]  = %event_UID;
      
      behaviorEventsList.addItem(%event);
   }
}

// Utility function to add entries to the actions list
function behaviorActionsList::fill( %this, %category, %subcategory )
{
   behaviorActionsList.clearItems();
   
   %actions = $RG_BehaviorGenerator::atoms[action,%category,%subcategory];   

   %actionsCount = getFieldCount( %actions );

   for( %count = 0; %count < %actionsCount; %count++)
   {
      %action = getField( %actions, %count );
     
      
      //%action_UID = getSubStrMarker( %action, $RG_BehaviorGenerator::UIDMarker, "" );
      //%action = getSubStrMarker( %action, "", $RG_BehaviorGenerator::UIDMarker );
      //
      //onDemandGeneratorDlg.actionUID[%action]  = %action_UID;
            
      behaviorActionsList.addItem(%action);
   }
}


function newBehaviorFriendlyName::onWake(%this)
{
   %this.testCanGenerate();
}

function newBehaviorFriendlyName::testCanGenerate(%this)
{
   
   %event  = behaviorEventsList.getSelectedItem();
   %action = behaviorActionsList.getSelectedItem();
   if ( (%event == -1) && (%action == -1) )
   {
      generateNewBehaviorButton.setActive(false);
      newBehaviorExistsIndicator.setValue("(atom selection(s) required!)");
      if(%this.isAwake()) %this.schedule( 100, testCanGenerate );
      return;
   }      

   if( isObject(newBehaviorName.getValue()) && !behaviorOverwrite.getValue() )
   {
      generateNewBehaviorButton.setActive(false);
      newBehaviorExistsIndicator.setValue("(behavior exists!)");
      if(%this.isAwake()) %this.schedule( 100, testCanGenerate );
      return;      
   }   

   if( (newBehaviorName.getValue() $= "") )
   {
      generateNewBehaviorButton.setActive(false);
      newBehaviorExistsIndicator.setValue("(Behavior Name required!)");
      if(%this.isAwake()) %this.schedule( 100, testCanGenerate );   
      return;   
   }   

   %savePath = onDemandGeneratorDlg.resourcePath @ "/" @ newBehaviorName.getValue() @ ".cs";
   %savePath = strreplace(%savePath, ".cs.cs", ".cs"); // Just in case
   if( isFile( %savePath ) && !behaviorOverwrite.getValue() )
   {
      generateNewBehaviorButton.setActive(false);
      newBehaviorExistsIndicator.setValue("(exists!)");
      onDemandGeneratorDlg.savePath = "";
      newBehaviorExistsIndicator.setValue("(~/.../" @ newBehaviorName.getValue() @ ".cs" SPC "exists!)");
      if(%this.isAwake()) %this.schedule( 100, testCanGenerate );
      return;
   }
   else
   {
      onDemandGeneratorDlg.savePath = %savePath;
   }

   if( (newBehaviorFriendlyName.getValue() $= "") )
   {
      generateNewBehaviorButton.setActive(false);
      newBehaviorExistsIndicator.setValue("(Friendly Name required!)");
      if(%this.isAwake()) %this.schedule( 100, testCanGenerate );   
      return;   
   }   

   if( trim(newBehaviorType.getValue()) $= "" )
   {
      generateNewBehaviorButton.setActive(false);
      newBehaviorExistsIndicator.setValue("(Behavior Type required!)");
      if(%this.isAwake()) %this.schedule( 100, testCanGenerate );
      return;      
   }   
   
   if( trim(newBehaviorDescription.getValue()) $= "" )
   {
      generateNewBehaviorButton.setActive(false);
      newBehaviorExistsIndicator.setValue("(Description required!)");
      if(%this.isAwake()) %this.schedule( 100, testCanGenerate );
      return;      
   }   

   newBehaviorExistsIndicator.setValue("");
   generateNewBehaviorButton.setActive(true); 
   if(%this.isAwake()) %this.schedule( 100, testCanGenerate );
}

////
//   Double click methods to allow us to select an list line and apply some 'button action' to it
//   at the same time.
////
function behaviorEventsList::onDoubleClick( %this )
{
   autoFillButton.onClick();
}

function behaviorActionsList::onDoubleClick( %this )
{
   autoFillButton.onClick();
}


function autoFillButton::onClick( %this )
{
   %eventCategory = eventCategoryMenu.getText();
   %eventSubcategory = eventSubCategoryMenu.getText();
   %event  = behaviorEventsList.getSelectedItem();
   %eventName = behaviorEventsList.getItemText(%event);

   %actionCategory = actionCategoryMenu.getText();
   %actionSubcategory = actionSubCategoryMenu.getText();
   %action = behaviorActionsList.getSelectedItem();
   %actionName = behaviorActionsList.getItemText(%action);
   
   %eventAtom = atomSet.atomArray[event,%eventCategory,%eventSubcategory,%eventName];
   %actionAtom = atomSet.atomArray[action,%actionCategory,%actionSubcategory,%actionName];
   
   if(isObject(%eventAtom))
   {
      %friendlyName = %eventAtom.friendlyName;
      %behaviorType = %eventAtom.behaviorType;
      %description  = %eventAtom.description;
   }
   
   if(isObject(%actionAtom))
   {
      %friendlyName = trim(%friendlyName SPC %actionAtom.friendlyName);
      %behaviorType = trim(%behaviorType SPC %actionAtom.behaviorType);
      %description  = trim(%description  SPC %actionAtom.description);
   }
   
   %behaviorName = strreplace(%friendlyName, " ", "");
   %behaviorName = strreplace(%behaviorName, "'", "");
   %behaviorName = strreplace(%behaviorName, "`", "");
   %behaviorName = strreplace(%behaviorName, "~", "");
   %behaviorName = strreplace(%behaviorName, "-", "");
   %behaviorName = strreplace(%behaviorName, "+", "");
   %behaviorName = strreplace(%behaviorName, "=", "");
   %behaviorName = strreplace(%behaviorName, ":", "");
   %behaviorName = strreplace(%behaviorName, ";", "");
   %behaviorName = strreplace(%behaviorName, "#", "");
   %behaviorName = strreplace(%behaviorName, "@", "");
   %behaviorName = strreplace(%behaviorName, "$", "");
   %behaviorName = strreplace(%behaviorName, "%", "");
   %behaviorName = strreplace(%behaviorName, "^", "");
   %behaviorName = strreplace(%behaviorName, "&", "");
   %behaviorName = strreplace(%behaviorName, "*", "");
   %behaviorName = strreplace(%behaviorName, "(", "");
   %behaviorName = strreplace(%behaviorName, ")", "");
   %behaviorName = strreplace(%behaviorName, "[", "");
   %behaviorName = strreplace(%behaviorName, "]", "");
   %behaviorName = strreplace(%behaviorName, "{", "");
   %behaviorName = strreplace(%behaviorName, "}", "");
   %behaviorName = strreplace(%behaviorName, "|", "");
   %behaviorName = strreplace(%behaviorName, ">", "");
   %behaviorName = strreplace(%behaviorName, "<", "");
   
   
   newBehaviorName.setValue(%behaviorName);
   newBehaviorFriendlyName.setValue(%friendlyName);
   newBehaviorType.setValue(%behaviorType);
   newBehaviorDescription.setValue(%description);
}


function generateNewBehaviorButton::onClick( %this )
{
   %eventCategory = eventCategoryMenu.getText();
   %eventSubcategory = eventSubCategoryMenu.getText();
   %event  = behaviorEventsList.getSelectedItem();
   %eventName = behaviorEventsList.getItemText(%event);

   %actionCategory = actionCategoryMenu.getText();
   %actionSubcategory = actionSubCategoryMenu.getText();
   %action = behaviorActionsList.getSelectedItem();
   %actionName = behaviorActionsList.getItemText(%action);
   
   %eventAtom = atomSet.atomArray[event,%eventCategory,%eventSubcategory,%eventName];
   %actionAtom = atomSet.atomArray[action,%actionCategory,%actionSubcategory,%actionName];
   
   %behaviorName = newBehaviorName.getValue();
   %friendlyName = newBehaviorFriendlyName.getValue();
   %behaviorType = newBehaviorType.getValue();
   %description = newBehaviorDescription.getValue();   

   generateBehaviorCode( %behaviorName, %friendlyName, %behaviorType, %description, %eventAtom, %actionAtom );
}

function generateBehaviorCode( %behaviorName, %friendlyName, %behaviorType, %description, %eventAtom, %actionAtom )
{
   %eventCategory = eventCategoryMenu.getText();
   %eventSubcategory = eventSubCategoryMenu.getText();
   %event  = behaviorEventsList.getSelectedItem();
   %eventName = behaviorEventsList.getItemText(%event);

   %actionCategory = actionCategoryMenu.getText();
   %actionSubcategory = actionSubCategoryMenu.getText();
   %action = behaviorActionsList.getSelectedItem();
   %actionName = behaviorActionsList.getItemText(%action);
   
   %code = "// This behavior generated by the Roaming Gamer Behavior Generator";
   
   if(%eventName !$= "")
   {
      %code =    
         "//EVENT ATOM DETAILS" NL
         "//   Category:" SPC %eventCategory NL
         "//Subcategory:" SPC %eventSubcategory NL
         "// Event Name:" SPC %eventName NL "";
   }
   
   if(%actionName !$= "")
   {
      %code = %code NL  
         "//ACTION ATOM DETAILS" NL
         "//   Category:" SPC %actionCategory NL
         "//Subcategory:" SPC %actionSubcategory NL
         "//Action Name:" SPC %actionName NL "";
   }
   
   %code = %code NL  
      "//registerAtom( action | event | full, \"Category\", \"SubCategory\", \"BehaviorName\" );" NL "";
   
   %code = %code NL 
      "if (!isObject(#BEHAVIORNAME#))" NL
      "{" NL
      "   %behavior = new BehaviorTemplate(#BEHAVIORNAME#) " NL
      "   { " NL
      "";
   %code = strreplace( %code, "#BEHAVIORNAME#", %behaviorName );   

   %friendlyName = "      friendlyName = \"" @ %friendlyName @ "\";";

   %behaviorType = "      behaviorType = \"" @ %behaviorType @ "\";";

   %description = "      description = \"" @ %description @ "\";";   
      
   %code = %code NL 
           %friendlyName NL
           %behaviorType NL
           %description NL
           "" NL

      "   };" NL
      "   %behavior.addBehaviorField(enable, \"Enable this behavior.\", bool, true);" NL
      "   %behavior.addBehaviorField(debugMode, \"Enable debugging (output) for this behavior.\", bool, false);";


   %destFile = onDemandGeneratorDlg.savePath;      
   //%destFile = "resources/RG_SK001_TGB_SSK/generatedBehaviors/behaviors/" @ %behaviorName @ ".cs"; //EFM change this to place them in generatedResources directory of current resource
   writeFile( %destFile, %code );

   appendSegmentToFile(%eventAtom, "behaviorFields", %destFile);
   appendSegmentToFile(%actionAtom, "behaviorFields", %destFile);
   
   %code = "}" NL "";
   appendToFile( %destFile, %code );
   
   %segmentList = 
   "onBehaviorAdd" SPC "onBehaviorRemove" SPC "onLevelLoaded" SPC "onLevelEnded" SPC "onAddToScene" SPC "onRemoveFromScene" SPC
   "onMouseMove" SPC "onMouseEnter" SPC "onMouseLeave" SPC "onMouseDown" SPC "onMouseDragged" SPC "onMouseUp" SPC
   "onRightMouseDown" SPC "onRightMouseDragged" SPC "onRightMouseUp" SPC 
   "onCollision" SPC "onWorldLimit" SPC "onUpdate" SPC "onPositionTarget" SPC "onRotationTarget" SPC "onTimer" SPC
   "onAnimationStart" SPC "onAnimationEnd" SPC "onFrameChange" SPC 
   "onEnter" SPC "onStay" SPC "onLeave" SPC "executeAction";

   %tmpTokens = %segmentList;
   while( "" !$= %tmpTokens ) 
   {
      %tmpTokens = nextToken( %tmpTokens , "myToken" , " " );
      appendSegmentRoutinesToFile( %eventAtom, %actionAtom, %behaviorName, %myToken, %destFile );
   }  
   
   // Generate KEEP ALL sections
   if( ( %eventAtom.segment["keepAll"] ) || ( %actionAtom.segment["keepAll"] ) )
   {
      appendToFile( %destFile, "//_BEGIN_KEEP_ALL" );
   }
   
   if( %eventAtom.segment["keepAll"] )
   {      
      appendSegmentToFileWithReplace(%eventAtom, "keepAll", %behaviorName, %destFile);
   }

   if( %actionAtom.segment["keepAll"] )
   {      
      appendSegmentToFileWithReplace(%actionAtom, "keepAll", %behaviorName, %destFile);
   }

   exec(%destFile);
   if(isObject(QuickEditBehaviorList)) 
   {
         QuickEditBehaviorList.refresh(); // Updates behaviors list
   }
}

function extractFieldValue( %isEvent, %fieldName )
{
   if(%isEvent)
      %fileName = $RG_BehaviorGenerator::CurrentEventSourcePath;
   else
      %fileName = $RG_BehaviorGenerator::CurrentActionSourcePath;

   %fieldFound = false;
	%file = new FileObject();
	if(%file.openForRead(%fileName))
	{
		while(!%fieldFound && !%file.isEOF())
		{
			%input = %file.readLine();
			if(strContains( %input , %fieldName )) %fieldFound = true;
		}
	} else {
		%file.delete();
		return false;
	}
	%file.close();
	%file.delete();
	
	if(%fieldFound)
	{
	   %fieldValue = strreplace( %input, %fieldName, "" );
	   %fieldValue = strreplace( %fieldValue, "=", "");
	   %fieldValue = strreplace( %fieldValue, "\"", "");
	   %fieldValue = strreplace( %fieldValue, ";", "");
	   %fieldValue = trim( %fieldValue );
	   return %fieldValue;
	}
	return "";
}

function appendSegmentToFile( %srcAtom, %segmentName, %fileName )
{
   
   %segmentCount = %srcAtom.segment[%segmentName];

   if(!%segmentCount) return;
   
   for(%count = 0; %count < %segmentCount; %count++)
   {
      %segment = %srcAtom.segment[%segmentName,%count];
      appendToFile( %fileName, %segment );
   }
}

function appendSegmentToFileWithReplace( %srcAtom, %segmentName, %behaviorName, %fileName )
{
   
   %segmentCount = %srcAtom.segment[%segmentName];

   if(!%segmentCount) return;
   
   %oldString = %srcAtom.details_atomName @ "::"; 
   %newString = %behaviorName @ "::";
   
   for(%count = 0; %count < %segmentCount; %count++)
   {
      %segment = %srcAtom.segment[%segmentName,%count];
      %segment = strreplace( %segment, %oldString, %newString );
      appendToFile( %fileName, %segment );
   }
}

function appendSegmentRoutinesToFile( %eventAtom, %actionAtom, %behaviorName, %segmentName, %fileName )
{
   %eventSegmentCount  = %eventAtom.segment[%segmentName];
   %actionSegmentCount = %actionAtom.segment[%segmentName];
   
   if( (%eventSegmentCount) || (%actionSegmentCount) )
   {
      switch$(%segmentName)
      {
      case "onBehaviorAdd" or "onBehaviorRemove":
         appendToFile( %fileName, "function " @ %behaviorName @ "::" @ %segmentName @ "(%this)" NL "{" );

      case "onLevelLoaded" or "onLevelEnded" or "onAddToScene" or "onRemoveFromScene":
         appendToFile( %fileName, "function " @ %behaviorName @ "::" @ %segmentName @ "(%this, %scenegraph)" NL "{" );

      case "onMouseMove" or "onMouseEnter" or "onMouseLeave" or "onMouseDown" or "onMouseDragged" or "onMouseUp":
         appendToFile( %fileName, "function " @ %behaviorName @ "::" @ %segmentName @ "(%this, %modifier, %worldPos)" NL "{" );

      case "onRightMouseDown" or "onRightMouseDragged" or "onRightMouseUp":
         appendToFile( %fileName, "function " @ %behaviorName @ "::" @ %segmentName @ "(%this, %modifier, %worldPos)" NL "{" );

      case "onCollision":
         appendToFile( %fileName, "function " @ %behaviorName @ "::" @ %segmentName @ "(%this, %dstObj, %srcRef, %dstRef, %time, %normal, %contacts, %points)" NL "{" );

      case "onWorldLimit":
         appendToFile( %fileName, "function " @ %behaviorName @ "::" @ %segmentName @ "(%this, %limitMode, %limit)" NL "{" );

      case "onUpdate":
         appendToFile( %fileName, "function " @ %behaviorName @ "::" @ %segmentName @ "(%this)" NL "{" );

      case "onPositionTarget" or "onRotationTarget":
         appendToFile( %fileName, "function " @ %behaviorName @ "::" @ %segmentName @ "(%this)" NL "{" );

      case "onTimer":
         appendToFile( %fileName, "function " @ %behaviorName @ "::" @ %segmentName @ "(%this)" NL "{" );

      case "onAnimationStart" or  "onAnimationEnd":
         appendToFile( %fileName, "function " @ %behaviorName @ "::" @ %segmentName @ "(%this)" NL "{" );

      case "onFrameChange":
         appendToFile( %fileName, "function " @ %behaviorName @ "::" @ %segmentName @ "(%this, %frame)" NL "{" );

      case "onEnter" or "onStay" or "onLeave":
         appendToFile( %fileName, "function " @ %behaviorName @ "::" @ %segmentName @ "(%this, %object)" NL "{" );

      case "executeAction":
         appendToFile( %fileName, "function " @ %behaviorName @ "::" @ %segmentName @ "(%this)" NL "{" );
      }
      
      appendToFile( %fileName,"   if(!%this.enable) return;" );
      appendToFile( %fileName,"   if(%this.debugMode) echo(%this.getName() @ \"::" @ %segmentName @ "()\");" );
      appendToFile( %fileName, "" );
      
      // Event Code
      if( %eventSegmentCount ) appendToFile( %fileName, "   //Event Atom Code:" @ %eventAtom.friendlyName); 
      for(%count = 0; %count < %eventSegmentCount; %count++)
      {
         %segment = %eventAtom.segment[%segmentName,%count];
         appendToFile( %fileName, %segment );
      }
      if( %eventSegmentCount ) appendToFile( %fileName, "" );

      // Action Code
      if( %actionSegmentCount ) appendToFile( %fileName, "   //Action Atom Code:" @ %actionAtom.friendlyName); 
      for(%count = 0; %count < %actionSegmentCount; %count++)
      {
         %segment = %actionAtom.segment[%segmentName,%count];
         appendToFile( %fileName, %segment );
      }
      if( %actionSegmentCount ) appendToFile( %fileName, "" );
      
      appendToFile( %fileName, "}//" @ %segmentName NL "" );
   }
}



