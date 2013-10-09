//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

// The functions in this file are designed to parse the tstk files and
// produce files containing wiki formated documentation.
// A lot of this is done is  brute force fashion and is based on my personal
// knowledge of how the files are 'internally' documented.

function rld_doco()
{
   deactivatePackage( TSTK_Doco_Package );
   exec("./doco.cs");
}

package TSTK_Doco_Package 
{
   function docoTSTK()
   {
      ////
      //   Find and sort common files
      ////
      %commonFiles = createArrayObject();
      for(%file = findFirstFile("./common/*.cs"); %file !$= ""; %file = findNextFile("./common/*.cs"))
      {
         %commonFiles.addEntry( %file );
      }
      %commonFiles.sort();

      ////
      //   Find and sort TGB files
      ////
      %tgbFiles = createArrayObject();
      for(%file = findFirstFile("./tgb/*.cs"); %file !$= ""; %file = findNextFile("./tgb/*.cs"))
      {
         %tgbFiles.addEntry( %file );
      }
      %tgbFiles.sort();

      ////
      //   Find and sort TGE files
      ////
      %tgeFiles = createArrayObject();
      for(%file = findFirstFile("./tge/*.cs"); %file !$= ""; %file = findNextFile("./tge/*.cs"))
      {
         %tgeFiles.addEntry( %file );
      }
      %tgeFiles.sort();


      ////
      //   Find and sort contributor files
      ////
      %contributorFiles = createArrayObject();
      for(%file = findFirstFile("./contributors/*.cs"); %file !$= ""; %file = findNextFile("./contributors/*.cs"))
      {
         %contributorFiles.addEntry( %file );
      }
      %contributorFiles.sort();

      ////
      //   Build a script object (doco container) to hold the descriptions of all TSTK functions
      ////
      parseDocoHeadersTSTK( %commonFiles );
      parseDocoHeadersTSTK( %tgbFiles );
      parseDocoHeadersTSTK( %tgeFiles );
      parseDocoHeadersTSTK( %contributorFiles );
      
      %commonFiles.schedule(0,delete);
      %tgbFiles.schedule(0,delete);
      %tgeFiles.schedule(0,delete);
      %contributorFiles.schedule(0,delete);
   }
   
   function parseDocoHeadersTSTK( %arrayObj )
   {
      %numEntries = %arrayObj.getCount();
      for(%count = 0; %count < %numEntries; %count++)
      {
         %curFile = %arrayObj.getEntry( %count );
         
         // extract the current file path, starting at "TSTK"
         %subPath = %curFile;       
         %subPathLen = strlen( %subPath );  
         
         %group = "";
         %subGroup = "";
         %remainder = "";
         
         %index = 0;
         while( (getSubStr( %subPath, %index, 4 ) !$= "TSTK" ) && ( %index < %subPathLen ) )
         {
            %index++;
         }
         if( %index < %subPathLen )
         {
            %subPath = getSubStr( %subPath, %index, %subPathLen - %index );
            %subPath = strreplace( %subPath, "/", " " );

            %group = getWord( %subPath, 1 );
            %subGroup = getWord( %subPath, 2);
            %remainder = getWords( %subPath, 3, 999);
            
            %subPath = strreplace( %subPath, " ", "/" );
            
            if(%remainder $= "")
            {
               %docoFileName = "~/generatedDocs/" @ %group @ "_" @ %subgroup @ ".cs";
            }
            else
            {
               %docoFileName = "~/generatedDocs/" @ %group @ "_" @ %subgroup @ "_" @ %remainder;
            }
            
            %docoFileName = strreplace( %docoFileName, ".cs.cs", ".cs" );
            %docoFileName = strreplace( %docoFileName, "__", "_" );
            
            //echo("Subpath: ", getSubStr( %subPath, %index, %subPathLen - %index ) );
            echo("Group: ", %group, " Subgroup: ", %subGroup, " Path: ", %subPath );
            
            writeFile( %docoFileName, 
                          "= TSTK Reference: " @  %group @ " - " @ %subGroup @ " =");

            appendToFile( %docoFileName, 
                          "== " @ %remainder @ " ==");
            
            appendToFile( %docoFileName, 
                          "The following section documents all of the functions found in the file: ''" @ %subPath @ "''." );
         }
         
         %handle = openFileForRead( %curFile );
         
         %inHeader = false;
         
         while(!%handle.isEOF())
         {
            %line = %handle.readLine();
            
            if( %inHeader && strContains( %line, "*/" ) )
            {
               %inHeader = false;
            }
            else if( %inHeader )
            {
               %headerData = %headerData NL %line;
            }
            else if( !%inHeader && strContains( %line, "/*" ) )
            {
               %inHeader = true;
               %headerData = "";
               %functionDecl = "";
            }
            else if( (strlen(%headerData) > 0) && ( getWord( trim(%line), 0) $= "function" ) )
            {
               %functionDecl = trim(%line);
               %functionDecl = applyWikiFormattingTSTK(%functionDecl);
               %headerData = applyWikiFormattingTSTK(%headerData);
               appendToFile( %docoFileName, %functionDecl @ %headerData @ "\n[[#toc | Top]]\n" );
               //echo(%functionDecl NL %headerData, "\n");
               
               // To be safe, clear this data now that its been used
               %headerData = "";
               %functionDecl = "";
            }
            
         }
      }
   }
   
   function applyWikiFormattingTSTK( %string )
   {
      %words = getWordCount( %string );
      
      for(%count = 0; %count < %words; %count++)
      {
         %word = getWord( %string, %count );

         //
         // BOLD format => Description:
         if( %word $= "Description:" )
         {
            %string = setWord(%string, %count, "'''" @ %word @ "'''");
         }
         //
         // BOLD format + Colorize => Warning:
         else if( %word $= "Warning:" )
         {
            %string = setWord(%string, %count, "<span style=\"color:#FF0000\">'''" @ %word @ "'''</span>");
         }
         //
         // italicize variable names => %*
         else if( strlen(%word) > 1 && 
                  strContains(%word,"%") )
         {
            %string = setWord(%string, %count, "''" @ %word @ "''");
         }
      }

      // Special formating for function declarations ==>      
      if( getWord(%string, 0 ) $= "function" )
      {
         
         // If this is a function declaration, remove any trailing documents
         %commentMarker = strstr( %string , "//" );
         
         if( %commentMarker != -1 )
         {
            %string = getSubStr( %string, 0, %commentMarker );
         }
         
         
         // If this is a function declaration, make it into a fourth-level header
         // and strip the word "function" off the front
         %string = getWords( %string, 1, %words-1 );
         %string = "====" SPC %string SPC "====";

      }
      // Special formating for function descriptions ==>            
      else
      {
         %string = strreplace( %string, "\n", "\n|-\n|");
         %string = "\n{| border=\"0\" style=\"width:100%; background:PaleGoldenRod\" " NL %string NL"|}";
      }

      return %string;
   }
   
};

activatePackage( TSTK_Doco_Package );
