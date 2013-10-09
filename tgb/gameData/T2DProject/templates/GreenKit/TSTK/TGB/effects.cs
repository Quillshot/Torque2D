///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

/*
Description: Returns a list of event files in the local path.
Warning: This is depricated because the path is local to the TSTK root and may not find the files you really want to locate.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function findEffectsFileNames()
{
   %effectNames = "";
   %pattern = "~/*.eff";
   %filename = findFirstFile( %pattern );
   
   while("" !$= %filename ) 
   {
      %effectNames = %effectNames TAB fileName(%filename);
      %filename = findNextFile(%pattern);
   }
   
   %effectNames = trim(%effectNames);
   
   %effectNames = sortFields( %effectNames );
   
   return %effectNames;   
}

