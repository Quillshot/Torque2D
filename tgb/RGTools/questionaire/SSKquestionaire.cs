///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------
function SSKQ_LoadPageScripts()
{
   exec("./Attributes.cs");
   exec("./CollidesWith.cs");
   exec("./Core.cs");
   exec("./GameObjects.cs");
   exec("./SaveLoadGenerate.cs");
}

function SSKQuestionaireDlg::onAdd(%this)
{
   %this.schedule( 1000, lateInit );
}

function SSKQuestionaireCreateMemory()
{
   new SimSet( SSKQuestionaireMemory );
   error("Created questionnaire memory!");
   
   error("isObject($roamingGamerSet) ==> ", isObject($roamingGamerSet));
   
   if(isObject($roamingGamerSet))
   {
      ($roamingGamerSet).add( SSKQuestionaireMemory );
      error("Added questionnaire memory to $roamingGamerSet!");
   }
}

function SSKQuestionaireMemory::onAdd(%this)
{
   error("SSKQuestionaireMemory::onAdd() -> ", %this.getid());
}

function SSKQuestionaireMemory::onRemove(%this)
{
   error("SSKQuestionaireMemory::onRemove() -> ", %this.getid());
}

function SSKQuestionaireTabBook::onAdd(%this)
{
   // Add Pages To Tab Book
   %this.addCoreTabPage();   
   %this.addGameObjectsTabPage();   
   %this.addAttributesTabPage();   
   %this.addCollisionTabPage();   
}

function SSKQuestionaireDlg::lateInit(%this)
{   
   if(!isObject( SSKQuestionaireMemory ) )  
   {
      SSKQuestionaireCreateMemory();
   }
   
   //// HACK TO LOAD LAST QUICK CONFIG IF THERE WAS ONE
   //if($pref::SSKQ_LastRulesFile !$= "") 
   //{
      //error( "Attempting to load ", $pref::SSKQ_LastRulesFile );
      ////Canvas.schedule(10, pushDialog, SSKQuestionaireDlg);
      //SSKQuestionaireTabBook.schedule(20, selectPage,2);   
      ////EFM schedule(10,0, LoadQuestionaire, $pref::SSKQ_LastRulesFile);
      ////SSKQ_GameObjectsRefresh( )
      ////schedule(40,0,closeSSKQuestionaireDialog); 
   //}
}

function SSKQuestionaireDlg::onWake(%this)
{
   error("SSKQuestionaireDlg()::onWake()");
   SSKQuestionaireTabBook.selectPage(0);  

   ////
   //   CORE
   ////
   SSKQ_GameName.setValue(SSKQuestionaireMemory.GameName);
   SSKQ_GameGoal.setValue(SSKQuestionaireMemory.GameGoal);
   
   SSKQ_CoreMechanicsList.clear();
   SSKQ_CoreMechanicsList.uniqueEntryNum = 0;

   for(%count = 0; %count < SSKQuestionaireMemory.mechanicsList; %count++)
   {
      %rowText = SSKQuestionaireMemory.mechanicsList[%count];
      SSKQ_CoreMechanicsList.addRow( SSKQ_CoreMechanicsList.uniqueEntryNum, %rowText );
      SSKQ_CoreMechanicsList.uniqueEntryNum++;        
   }

   ////
   //   GAME OBJECTS
   ////
   error("SSKQuestionaireMemory.gameObjects == ", SSKQuestionaireMemory.gameObjects);
   for(%count = 0; %count < SSKQuestionaireMemory.gameObjects; %count++)
   {
      %rowText = SSKQuestionaireMemory.gameObjects[%count];
      SSKQ_DebugAddGameObject(%rowText);
   }

}


function SSKQuestionaireDlg::onSleep(%this)
{
   error("SSKQuestionaireDlg()::onSleep()");
   
   ////
   //   CORE
   ////
   SSKQuestionaireMemory.GameName = SSKQ_GameName.getValue();
   SSKQuestionaireMemory.GameGoal = SSKQ_GameGoal.getValue();
   
   SSKQuestionaireMemory.mechanicsList = SSKQ_CoreMechanicsList.rowCount();
   for(%count = 0; %count < SSKQuestionaireMemory.mechanicsList; %count++)
   {
      %rowText = SSKQ_CoreMechanicsList.getRowText( %count );
      SSKQuestionaireMemory.mechanicsList[%count] = %rowText;
   }
   
   ////
   //   GAME OBJECTS
   ////
   SSKQuestionaireMemory.gameObjects = SSKQ_GameObjectsList.rowCount();
   error("SSKQuestionaireMemory.gameObjects == ", SSKQuestionaireMemory.gameObjects);
   for(%count = 0; %count < SSKQuestionaireMemory.gameObjects; %count++)
   {
      %rowText = SSKQ_GameObjectsList.getRowText( %count );
      SSKQuestionaireMemory.gameObjects[%count] = %rowText;
   }

}



function closeSSKQuestionaireDialog( %save )
{
   Canvas.popDialog(SSKQuestionaireDlg);
   GenerateQuickConfigRules();
}

SSKQ_LoadPageScripts();


