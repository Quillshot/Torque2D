//------------------------------------------------------
// Copyright, Roaming Gamer, LLC.
//------------------------------------------------------

function copyBuilderScriptToClipboard( )
{
   %object = getTGBLevelEditorCurrentSelection(); 
   if(!isObject(%object)) return;

   MessageBoxGetString("Builder Script Name?", "Please specify a name for this builder script.", "doGenerateBuilderScript( MBGetStringTextEdit.getValue() );" );   
}

function doGenerateBuilderScript( %objectName )
{
   %object = getTGBLevelEditorCurrentSelection(); 
   if(!isObject(%object)) return;
   
   echo("Generate Builder Script to clipboard for object ID: ", %object.getID(), " Name: ", %object.getName() );
   
  %builderScript = generateBuilderFunction( %object, %objectName );
   
   setClipboard( %builderScript );
}

function buildMountLists( %sceneGraph )
{
   new SimObject( mountListCollection );

   %statement = "if( isObject( tok.getMountedParent() ) )" @ // This object is mounted to a parent object
                "{" @
                "   %parent = tok.getMountedParent();" @ // Get the parent's ID
                //"   echo( tok , \" parent == \" , %parent ); " @
                "   %count = mountListCollection.childCount[%parent]++;" @ // Parent has another mounted child
                "   mountListCollection.childID[%parent,%count-1]=tok;" @ // Store the child ID
                "}";
                
   %sceneGraph.forEachStmt( %statement , tok , true );
   
}

function generateBuilderFunction( %object, %objectName )
{
   buildMountLists( %object.sceneGraph );
   
   %tmpFile = expandFilename(".\dbgen_tmp_" @ getSimTime() @".cs");
   
   %object.save( %tmpFile , false);

   %tmpTokens = readFile( %tmpFile );
   
   // Extract the primary object's NAME and SCENEGRAPH id
   //%objectName = %object.getName();
   //%objectName = (%objectName $= "" ) ? "?????" : %objectName;
   %sceneGraph = %object.sceneGraph;

   // Create the front of the builder function   
   %builderScript = "function " @ %objectName @ "( %sceneGraph, %position )\n";
   %builderScript = %builderScript @ "{\n";
   %builderScript = %builderScript @ buildGenIterator( %object , %tmpFile, 0 , -1 );
   %builderScript = %builderScript @ "   return %obj0;\n";
   %builderScript = %builderScript @ "}\n";
   
   mountListCollection.delete();
   
   %result = fileDelete( %tmpFile );
   
   return %builderScript;
}

function buildGenIterator( %object , %tmpFile, %objNum , %parentObjNum )
{
   
   %object.save( %tmpFile , false);

   %tmpTokens = readFile( %tmpFile );
   
   %fieldCount = 0;
   
   %positionSet = false;
   
   while( "" !$= %tmpTokens ) 
   {
      %tmpTokens = nextToken( %tmpTokens , "myToken" , "\n" );
      
      %myToken = trim( %myToken );
      
      // Skip begin/end lines
      if( -1 != strstr( %myToken , "OBJECT WRITE BEGIN" ) ) continue;
      if( -1 != strstr( %myToken , "OBJECT WRITE END" ) ) continue;      
      if( -1 != strstr( %myToken , "};" ) ) continue;      
      
      //%myToken = strreplace( %myToken , ";" , "" );
      
      // Extract object type and object name
      if( 0 == strpos( %myToken , "new" ) ) 
      {
         %myToken = strreplace( %myToken , "(" , " " );
         %myToken = strreplace( %myToken , ")" , " " );
         %objectType = getWord( %myToken, 1 );
         %objectName = getWord( %myToken, 2 );
         %objectName = (%objectName $= "" ) ? "" : %objectName;
         %objectName = (%objectName $= "{" ) ? "" : %objectName;
         continue;
      }
      
      if( ( strstr( %myToken , "position" ) != -1 ) ||
          ( strstr( %myToken , "Position" ) != -1 ) )
      {
         %field[%fieldCount] = "position = %position;";
         %fieldCount++;
         %positionSet = true;
         continue;
      }    
      
      // Extract fields
      %field[%fieldCount] = %myToken;
      %fieldCount++;
   }
   
   if(!%positionSet)
   {
      %field[%fieldCount] = "position = %position;";
      %fieldCount++;
      %positionSet = true;
   }
   
   // Generate a NEW Build Script   
   //%builderScript = "   %obj" @ %objNum @ " = new " @ %objectType @ "( " @ %objectName @" )\n" ;
   %builderScript = "   %obj" @ %objNum @ " = new " @ %objectType @ "( )\n" ; // Always create without a name
   %builderScript = %builderScript @ "   {\n" ;
   
   for( %count = 0; %count < %fieldCount; %count++ )
   {
      %builderScript = %builderScript @ "      " @ %field[%count] @ "\n";
   }
   
   %builderScript = %builderScript @ "   };\n\n" ;
   %builderScript = %builderScript @ "   %sceneGraph.add( %obj" @ %objNum @ " );\n";

   if( -1 != %parentObjNum )
   {
      %mountForce             = %object.mountForce;
      %mountOffset            = %object.mountOffset;
      %mountOwned             = %object.mountOwned;
      %mountTrackRotation     = %object.mountTrackRotation;
      %mountInheritAttributes = %object.mountInheritAttributes;
      
      %tmpScript   = %tmpScript @"   %obj" @ %objNum @ ".mount( %obj" @ %parentObjNum @ " , \"" @ %mountOffset @ "\" , " @ %mountForce  @ 
                     " , " @ %mountTrackRotation @ 
                     " , true , " @ %mountOwned @ 
                     " , " @ %mountInheritAttributes @ 
                     " );\n";
      %builderScript = %builderScript @ %tmpScript;      
   }

   if( %object.isMethod( onLevelLoaded ) )
   {
      %builderScript = %builderScript @ "   %obj" @ %objNum @ ".onLevelLoaded( %sceneGraph );\n\n";
   }
   
   %childCount = mountListCollection.childCount[%object] ;
   %childCount = ( "" $= mountListCollection.childCount[%object] ) ? 0 : %childCount;
   
   for( %count =0; %count < %childCount; %count ++ )
   {
      %child = mountListCollection.childID[%object,%count];
      error("%object == ", %object);
      error("%count == ", %count);
      error("%child == ", %child);
      %builderScript = %builderScript @ buildGenIterator( %child , %tmpFile, %objNum+1 , %objNum );
   }

   return %builderScript;
}
