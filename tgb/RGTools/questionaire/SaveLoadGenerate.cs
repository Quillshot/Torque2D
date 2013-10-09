///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------
function ResetQuestionare()
{
   
   if(isObject( SSKQuestionaireMemory ) )  
   {
      %oldQuestionaire = SSKQuestionaireMemory.getId();
      SSKQuestionaireCreateMemory();
      
      //error("old ", %oldQuestionaire, " new ", SSKQuestionaireMemory.getId());
      %oldQuestionaire.delete();      
   }
   else
   {
      SSKQuestionaireCreateMemory();
   }
   
   SSKQ_GameName.setValue("");
   SSKQ_GameGoal.setValue("");
   SSKQ_CoreMechanicsList.clear();
   
   SSKQ_GameObjectsList.clear();
   
   SSKQ_GameObjectsRefresh();
}

function LoadQuestionaire( %fileName )
{
   // HACK: IF %fileName is provided, go directly to load
   
   if( %fileName $= "" )
   {
   
      //error($Pref::Dialogs::LastProjectPath @ "/game/gameScripts/");
      %dlg = new OpenFileDialog()
      {
         Title = "Load SSK Questionare";
         DefaultPath = $Pref::Dialogs::LastProjectPath @ "/game/gameScripts/";
         Filters = "SSK Projects (*.sskq)|*.sskq|All Files (*.*)|*.*";
         MustExist = true;
         MultipleFiles = false;
         ChangePath = false;
      };
   
      if(%dlg.Execute())
      {
         %loadPath = filePath( %dlg.FileName );
         %fileName = fileName( %dlg.FileName );
      
         $pref::SSKQ_LastRulesFile = %dlg.FileName;
      
         echo("%loadPath == ", %loadPath );
         echo("%fileName == ", %fileName );
      }

      %handle = openFileForRead( %dlg.FileName );
   }
   else
   {
      %handle = openFileForRead( %fileName );
      error("In hack: ", %handle );
   }
   
   if(!isObject( %handle ) ) 
   {
      error( "LoadQuestionaire() --> Failed to open file: ", %dlg.FileName );
      return; 
   }
   
   ResetQuestionare();
   
   while( !%handle.isEOF() )
   {
      %line = %handle.readLine();
      
      %key = getWord( %line , 0 );
      
      //error( %line );
      
      switch$( %key )
      {
      case "SSKQ_GAMENAME":
         %name = getWords( %line, 1 );
         SSKQ_GameName.setValue(%name);

      case "SSKQ_GAMEGOAL":
         %goal = getWords( %line, 1 );
         SSKQ_GameGoal.setValue(%goal);

      case "SSKQ_MECHANIC":
         %mechanic = getWords( %line, 1 );
         SSKQ_CurCoreMechanic.setValue(%mechanic);
         SSKQ_AddCoreMechanic();
         
      case "SSKQ_OBJTYPE":
         %objType = getWord( %line, 1 );
         SSKQ_CurGameObject.setValue(%objType);
         SSKQ_AddGameObject();
         
      case "SSKQ_LAYER":
         if( !%layerFirstWake ) 
         {
            SSKQ_AttributesMatrix.onWake();
            %layerFirstWake = true;
         }
         
         %objType = getWord( %line, 1 );
         %layer = getWord( %line, 2 );
         %popupName = %objType @ "_" @ "Layer";
         //error( %popupName, " is Object? ", isObject(%popupName), " layer: ", %layer);
         
         SSKQuestionaireMemory.LayerMatrix[ %popupName ] = %layer;         
         (%popupName).setValue( %layer );

      case "SSKQ_COLLIDESWITH":
         if( !%collidesWithFirstWake ) 
         {
            SSKQ_CollidesWithMatrix.onWake();
            %collidesWithFirstWake = true;
         }
         %objType = getWord( %line, 1 );
         %objType2 = getWord( %line, 2 );
         
         %name = %objType @ "_" @ %objType2 @ "_COL";
         (%name).setValue( 1 );
         
         
      }
   }
}

function SaveQuestionare()
{
   getSaveFilename("*.sskq", saveQuestionaireCB, $Pref::Dialogs::LastProjectPath @ "/game/gameScripts/");
}

function saveQuestionaireCB(%saveName)
{
   // Trim possible 'extra' trailer
   %fileName = strreplace( %saveName, ".sskq", "");
   %fileName = %fileName @ ".sskq";

   echo("%fileName == ", %fileName );   
   
   $pref::SSKQ_LastRulesFile = %fileName;

   ////
   //   Game Name, Goal, and core mechanics
   ////
   writeFile(%fileName , "SSKQ_GAMENAME" SPC SSKQ_GameName.getValue() );   
   appendToFile(%fileName , "SSKQ_GAMEGOAL" SPC SSKQ_GameGoal.getValue() );   
   for(%count = 0; %count < SSKQ_CoreMechanicsList.rowCount(); %count++)
   {
      %row = SSKQ_CoreMechanicsList.getRowText( %count );
      appendToFile(%fileName , "SSKQ_MECHANIC" SPC %row );   
   }

   
   ////
   //   Types
   ////
   %numGameObjects = SSKQ_GameObjectsList.rowCount();
   //error( "%numGameObjects == ", %numGameObjects );
   
   for(%count = 0; %count < %numGameObjects; %count++)
   {
      %objType = SSKQ_GameObjectsList.getRowText( %count );
      appendToFile(%fileName , "SSKQ_OBJTYPE" SPC %objType );
   }

   ////
   //   Save Types (one by one)
   ////
   for(%count = 0; %count < %numGameObjects; %count++)
   {
      %objType = SSKQ_GameObjectsList.getRowText( %count );

      %layer           = (%objType @ "_Layer").getValue(); 

      appendToFile(%fileName , "SSKQ_LAYER" SPC %objType SPC %layer );
      
      // Collides With
      for(%count2 = 0; %count2 < %numGameObjects; %count2++)
      {
         %objType2 = SSKQ_GameObjectsList.getRowText( %count2 );
         
         %collidesGUI = %objType @ "_" @ %objType2 @ "_COL";
         %collides = %collidesGUI.getValue();
         
         if( %collides )
         {
            appendToFile(%fileName , "SSKQ_COLLIDESWITH" SPC %objType SPC %objType2 );
         }
      }
   }
}


function GenerateQuickConfigRules( %loop )
{
   %fileName = expandFilename("./edochiSSK_quickConfigRules.cs");
   writeFile( %fileName   , "///------------------------------------------------------" );
   appendToFile(%fileName , "// Copyright Roaming Gamer, LLC." );   
   appendToFile(%fileName , "//------------------------------------------------------" );   
   //appendToFile(%fileName , "/*" );   
   
   ////
   //   Game Name, Goal, and core mechanics
   ////
   appendToFile(%fileName , "//      Game Name:" SPC SSKQ_GameName.getValue() );   
   appendToFile(%fileName , "//           Goal:" SPC SSKQ_GameGoal.getValue() );   
   appendToFile(%fileName , "// Core Mechanics:" );   
   
   appendToFile(%fileName , "//" );   
   
   for(%count = 0; %count < SSKQ_CoreMechanicsList.rowCount(); %count++)
   {
      %row = SSKQ_CoreMechanicsList.getRowText( %count );
      appendToFile(%fileName , "// ->" SPC %row );   
   }
   appendToFile(%fileName , "//" );   

   ////
   //   Prolog
   ////
   appendToFile(%fileName , "////");
   appendToFile(%fileName , "//   0 - Initialize Roaming Gamer Quick Configuration System");
   appendToFile(%fileName , "////");
   appendToFile(%fileName , "RGQC::Prolog();");
   appendToFile(%fileName , "" );   

   
   ////
   //   Create Types
   ////
   appendToFile(%fileName , "////");
   appendToFile(%fileName , "//   1 - Create object types" );
   appendToFile(%fileName , "////");
   
   %numGameObjects = SSKQ_GameObjectsList.rowCount();
   error( "%numGameObjects == ", %numGameObjects );
   
   for(%count = 0; %count < %numGameObjects; %count++)
   {
      %objType = SSKQ_GameObjectsList.getRowText( %count );
      
      // LONG VERSION appendToFile(%fileName , "RGQC.createType( \"" @ %objType @ "\", " @ %count @ ");" );
      appendToFile(%fileName , "RGQC.createType( \"" @ %objType @ "\"" @ " );" );
   }
   appendToFile(%fileName , "" );   

   ////
   //   Configure Types (one by one)
   ////
   appendToFile(%fileName , "////");
   appendToFile(%fileName , "//   2 - Configure Types (one by one)" );
   appendToFile(%fileName , "////");
   appendToFile(%fileName , "" );   
   for(%count = 0; %count < %numGameObjects; %count++)
   {
      %objType = SSKQ_GameObjectsList.getRowText( %count );
      
      appendToFile(%fileName , "//" SPC %objType );   
      %layer           = (%objType @ "_Layer").getValue(); 

      appendToFile(%fileName , "RGQC.setLayer( \"" @ %objType @ "\", " @ %layer @ " );" );         
      

      // Collides With
      for(%count2 = 0; %count2 < %numGameObjects; %count2++)
      {
         %objType2 = SSKQ_GameObjectsList.getRowText( %count2 );
         
         %collidesGUI = %objType @ "_" @ %objType2 @ "_COL";
         %collides = %collidesGUI.getValue();
         
         if( %collides )
         {
            appendToFile(%fileName , "RGQC.collidesWith( \"" @ 
               %objType  @ "\", \"" @ 
               %objType2 @ "\" " @ " );" );
         }
      }
      
      appendToFile(%fileName , "" );   
   }

   exec(%fileName);   
   
   if( %loop )
   {
      schedule(1000,0,"GenerateQuickConfigRules", 1 );   
   }
   //appendToFile(%fileName , "*/" );   
}


//function GenerateQuickConfigRules()
//{
   //%fileName = expandFilename("./edochiSSK_quickConfigRules.cs");
   //writeFile( %fileName   , "///------------------------------------------------------" );
   //appendToFile(%fileName , "// Copyright Roaming Gamer, LLC." );   
   //appendToFile(%fileName , "//------------------------------------------------------" );   
   //appendToFile(%fileName , "/*" );   
   //
   //////
   ////   Game Name, Goal, and core mechanics
   //////
   //appendToFile(%fileName , "//      Game Name:" SPC SSKQ_GameName.getValue() );   
   //appendToFile(%fileName , "//           Goal:" SPC SSKQ_GameGoal.getValue() );   
   //appendToFile(%fileName , "// Core Mechanics:" );   
   //
   //appendToFile(%fileName , "//" );   
   //
   //for(%count = 0; %count < SSKQ_CoreMechanicsList.rowCount(); %count++)
   //{
      //%row = SSKQ_CoreMechanicsList.getRowText( %count );
      //appendToFile(%fileName , "// ->" SPC %row );   
   //}
   //appendToFile(%fileName , "//" );   
//
   //////
   ////   Prolog
   //////
   //appendToFile(%fileName , "////");
   //appendToFile(%fileName , "//   0 - Initialize Roaming Gamer Quick Configuration System");
   //appendToFile(%fileName , "////");
   //appendToFile(%fileName , "RGQC::Prolog();");
   //appendToFile(%fileName , "" );   
//
   //
   //////
   ////   Create Types
   //////
   //appendToFile(%fileName , "////");
   //appendToFile(%fileName , "//   1 - Create object types" );
   //appendToFile(%fileName , "////");
   //
   //%numGameObjects = SSKQ_GameObjectsList.rowCount();
   //error( "%numGameObjects == ", %numGameObjects );
   //
   //for(%count = 0; %count < %numGameObjects; %count++)
   //{
      //%objType = SSKQ_GameObjectsList.getRowText( %count );
      //
      //// LONG VERSION appendToFile(%fileName , "RGQC.createType( \"" @ %objType @ "\", " @ %count @ ");" );
      //appendToFile(%fileName , "RGQC.createType( \"" @ %objType @ "\"" @ " );" );
   //}
   //appendToFile(%fileName , "" );   
//
   //////
   ////   Configure Types (one by one)
   //////
   //appendToFile(%fileName , "////");
   //appendToFile(%fileName , "//   2 - Configure Types (one by one)" );
   //appendToFile(%fileName , "////");
   //appendToFile(%fileName , "" );   
   //for(%count = 0; %count < %numGameObjects; %count++)
   //{
      //%objType = SSKQ_GameObjectsList.getRowText( %count );
      //
      //appendToFile(%fileName , "//" SPC %objType );   
      //%layer           = (%objType @ "_Layer").getValue(); 
      //%colResponse     = (%objType @ "_ColResponse").getValue(); 
      //%immovable       = (%objType @ "_Immovable").getValue(); 
//
      //%maxDamage       = (%objType @ "_MaxDamage").getValue(); 
      //%disabledDamage  = (%objType @ "_DisabledDamage").getValue(); 
      //%destroyedDamage = (%objType @ "_DestroyedDamage").getValue(); 
      //%repairRate      = (%objType @ "_RepairRate").getValue(); 
//
      //%maxEnergy       = (%objType @ "_MaxEnergy").getValue(); 
      //%disabledEnergy  = (%objType @ "_DisabledEnergy").getValue(); 
      //%destroyedEnergy = (%objType @ "_DestroyedEnergy").getValue(); 
      //%rechargeRate      = (%objType @ "_RechargeRate").getValue(); 
//
//
      //%maxDamage       = (%maxDamage $= "") ? 0 : %maxDamage;
      //%disabledDamage  = (%disabledDamage $= "") ? -1 : %disabledDamage;
      //%destroyedDamage = (%destroyedDamage $= "") ? -1 : %destroyedDamage;
      //%repairRate      = (%repairRate $= "") ? 0 : %repairRate;
//
      //%maxEnergy       = (%maxEnergy $= "") ? 0 : %maxEnergy;
      //%disabledEnergy  = (%disabledEnergy $= "") ? -1 : %disabledEnergy;
      //%destroyedEnergy = (%destroyedEnergy $= "") ? -1 : %destroyedEnergy;
      //%rechargeRate      = (%rechargeRate $= "") ? 0 : %rechargeRate;
      //
      //appendToFile(%fileName , "RGQC.setLayer( \"" @ %objType @ "\", " @ %layer @ " );" );         
      //appendToFile(%fileName , "RGQC.onCollision_" @ %colResponse @"( \"" @ %objType @ "\" );" );   
      //appendToFile(%fileName , "RGQC.setImmovable( \"" @ %objType @ "\", " @ %immovable @ " );" );   
      //
      //if( %maxDamage > 0 )
      //{
         //appendToFile(%fileName , "RGQC.setDamagePoints( \"" @ %objType @ "\", " @ 
            //%maxDamage @ ", " @ 
            //%disabledDamage @ ", " @ 
            //%destroyedDamage @ ", " @ 
            //%repairRate @ 
             //" );" );            
      //}
      //
      //if( %maxEnergy > 0 )
      //{
         //appendToFile(%fileName , "RGQC.setEnergyPoints( \"" @ %objType @ "\", " @ 
            //%maxEnergy @ ", " @ 
            //%disabledEnergy @ ", " @ 
            //%destroyedEnergy @ ", " @ 
            //%rechargeRate @ 
             //" );" );            
      //}
      //
      //// Does Damage
      //for(%count2 = 0; %count2 < %numGameObjects; %count2++)
      //{
         //%objType2 = SSKQ_GameObjectsList.getRowText( %count2 );
         //
         //%dmgGUI = %objType @ "_" @ %objType2 @ "_DMG";
         //%dmgValue = %dmgGUI.getValue();
         //
         //if( %dmgValue < 0 || %dmgValue > 0 )
         //{
            //appendToFile(%fileName , "RGQC.doesDamage_onCollision( \"" @ 
               //%objType  @ "\", \"" @ 
               //%objType2 @ "\", " @ 
               //%dmgValue @ " );" );
         //}
      //}
//
      //// Does Drain
      //for(%count2 = 0; %count2 < %numGameObjects; %count2++)
      //{
         //%objType2 = SSKQ_GameObjectsList.getRowText( %count2 );
         //
         //%drnGUI = %objType @ "_" @ %objType2 @ "_DRN";
         //%drnValue = %drnGUI.getValue();
         //
         //if( %drnValue < 0 || %drnValue > 0 )
         //{
            //appendToFile(%fileName , "RGQC.doesDrain_onCollision( \"" @ 
               //%objType  @ "\", \"" @ 
               //%objType2 @ "\", " @ 
               //%drnValue @ " );" );
         //}
      //}
//
      //// Collides With
      //for(%count2 = 0; %count2 < %numGameObjects; %count2++)
      //{
         //%objType2 = SSKQ_GameObjectsList.getRowText( %count2 );
         //
         //%collidesGUI = %objType @ "_" @ %objType2 @ "_COL";
         //%collides = %collidesGUI.getValue();
         //
         //if( %collides )
         //{
            //appendToFile(%fileName , "RGQC.collidesWith( \"" @ 
               //%objType  @ "\", \"" @ 
               //%objType2 @ "\" " @ " );" );
         //}
      //}
      //
      //appendToFile(%fileName , "" );   
   //}
//
//
//
   //
   //
   //appendToFile(%fileName , "*/" );   
//}
