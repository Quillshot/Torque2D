//------------------------------------------------------
// Copyright, Roaming Gamer, LLC.
//------------------------------------------------------
function rldDBG()
{
   exec("./DBGenerator.cs");
}

function copyDBToClipboard( )
{
   %object = getTGBLevelEditorCurrentSelection(); 
   if(!isObject(%object)) return;
   
   MessageBoxGetString("Datablock Name?", "Please specify a name for this datablock.", "doGenerateDatablock(MBGetStringTextEdit.getValue(), \"clipboard\");" );   
}


function saveDBToManagedDB( )
{
   %object = getTGBLevelEditorCurrentSelection(); 
   if(!isObject(%object)) return;
   
   MessageBoxGetString("Datablock Name?", "Please specify a name for this datablock.", "doGenerateDatablock(MBGetStringTextEdit.getValue(), \"managed\");" );   
}

function doGenerateDatablock( %DBName, %destination, %source )
{
   if( %source !$= "clipboard" )
   {
      if("" $= %DBName) return;
      echo("Generate DB to clipboard for object ID: ", %object.getID(), " Name: ", %object.getName() );
   
      %object = getTGBLevelEditorCurrentSelection();
   
   
   //   %tmpFile = $RG::GenScriptLocation @ "dbgen_tmp_" @ getSimTime() @".cs";
      %tmpFile = "./dbgen_tmp_" @ getSimTime() @".cs";
      %tmpFile = expandFileName(%tmpFile) ;
      %result = %object.save( %tmpFile , false);
   
      %objectSize = %object.getSize();
      %sizeSet    = false;

      %tmpTokens = readFile( %tmpFile );
   
      %fieldCount = 0;
   
      while( "" !$= %tmpTokens ) 
      {
         %tmpTokens = nextToken( %tmpTokens , "myToken" , "\n" );
      
         %myToken = trim( %myToken );
      
         // Skip begin/end lines
         if( -1 != strstr( %myToken , "OBJECT WRITE BEGIN" ) ) continue;
         if( -1 != strstr( %myToken , "OBJECT WRITE END" ) ) continue;      
         if( -1 != strstr( %myToken , "};" ) ) continue;      
         if( -1 != strstr( %myToken , "position" ) ) continue; 
         if( -1 != strstr( %myToken , "Position" ) ) continue; 
         if( -1 != strstr( %myToken , "size" ) ) %sizeSet = true; 
      
         %myToken = strreplace( %myToken , ";" , "" );
      
         // Extract object type and object name
         if( 0 == strpos( %myToken , "new" ) ) 
         {
            %myToken = strreplace( %myToken , "(" , " " );
            %myToken = strreplace( %myToken , ")" , " " );
            %objectType = getWord( %myToken, 1 );
            //%objectName = getWord( %myToken, 2 );
            //%objectName = (%objectName $= "" ) ? "?????" : %objectName;
            //%objectName = (%objectName $= "{" ) ? "?????" : %objectName;
            continue;
         }

         // Extract config DB (if any)
         if( -1 != strstr( %myToken , "config =" ) ) 
         {
            %myToken = strreplace( %myToken , "\"" , "" );
            %config = getWord( %myToken , 2 );
            continue;
         }
      
         // Extract fields
         %fieldName[%fieldCount] = getWord( %myToken , 0 );
         %fieldValue[%fieldCount] = getWords( %myToken , 2 );
         %fieldCount++;
      }
   
      // Specify DB Type
      switch$( %objectType )
      {
      case "t2dStaticSprite":
         %DBType = "t2dSceneObjectDatablock";
      case "t2dAnimatedSprite":
         //%DBType = "t2dAnimationDatablock";
         // Fake out the system
         %DBType = "t2dSceneObjectDatablock";
      
      case "t2dScroller":
         %DBType = "t2dSceneObjectDatablock";
      case "t2dParticleEffect":
         %DBType = "t2dSceneObjectDatablock";
      }
   
      // Generate a NEW DB
      %DBScript = "new " @ %DBType @ "( " @ %DBName ;
      if( ("" !$= %config) && (%config !$= %DBName) ) %DBScript = %DBScript @ " : " @ %config;
      %DBScript = %DBScript @ " )\n" ;
      %DBScript = %DBScript @ "{\n" ;
   
      for( %count = 0; %count < %fieldCount; %count++ )
      {
         %DBScript = %DBScript @ "   " @ %fieldName[%count] @ " = " @ %fieldValue[%count] @ ";\n";
      }
   
      if( !%sizeSet )
      {
         %DBScript = %DBScript @ "   size = \"" @ %objectSize @ "\";\n";
      }
   
      %DBScript = %DBScript @ "};\n" ;
  
   }
   else
   {
      %DBScript = getClipboard();
      
      %line1 = getRecord( %DBScript, 0 );
      
      %line1 = strreplace( %line1, "(", "");
      %line1 = strreplace( %line1, ")", "");
      %line1 = strreplace( %line1, "{", "");
      %line1 = strreplace( %line1, "  ", " ");
      
      %DBName = getWord( %line1, 2 );
      
      //error( "newDB ", %DBName );      
      //error( "isObject ", isObject(%DBName) );      
      //error( "%tmpFile ", %tmpFile );      
      //error( "%DBScript ", %DBScript );      
   }

   if( (%destination $= "managed") && isObject(%DBName))
   {
      $RG::DBGen_Script    = %DBScript;
      $RG::DBGen_DBName    = %DBName;
      $RG::DBGen_TmpFile   = %tmpFile;
      MessageBoxYesNo("Overwrite datablock?", 
                      "A datablock with this name exists.  Do you wish to overwrite it?" , 
                      "DBGen_OverwriteOK_Yes();" );
      %result = fileDelete( %tmpFile );
      %DBName.delete();
      return;
   }
   
   //if( %source $= "clipboard" )
   //{
      //
   //}

   if( %destination $= "clipboard" )
   {
      setClipboard( %DBScript );
   }
   else if( %destination $= "managed" )
   {   
      //writeFile( %tmpFile, %DBScript );
      //exec(%tmpFile);
      eval(%DBScript);
      if(isObject( %DBName ))
      {
         LBProjectObj.addDatablock( %DBName, true );
      }
      else
      {
         error("Failed to create managed datablock name: ", %DBName );
      }
   }
   
   //%result = fileDelete( %tmpFile );
}

function DBGen_OverwriteOK_Yes()
{
   $ignoredDatablockSet.add($RG::DBGen_DBName);
   while($managedDatablockSet.isMember($RG::DBGen_DBName))
      $managedDatablockSet.remove($RG::DBGen_DBName);

   //setClipboard( $RG::DBGen_Script );
   //writeFile( $RG::DBGen_TmpFile, $RG::DBGen_Script );
   //exec($RG::DBGen_TmpFile);
   eval($RG::DBGen_Script);
   LBProjectObj.addDatablock( $RG::DBGen_DBName, true );
   //%result = fileDelete( $RG::DBGen_TmpFile );

   $RG::DBGen_Script    = "";
   $RG::DBGen_DBName    = "";
   $RG::DBGen_TmpFile   = "";
}


