///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

////
//   TYPE CREATION
////
/*
Description: Use this metod to create a new 'named' Quick Config type. You may optionally specify a specific graph group to associate with the type, but if one is not supplied, this method will choose one automatically.
*/
function RGQC::createType( %this, %typeName, %group )
{
   if(%this.Settings[Debug]) echo("%this.Types[", %typeName, "] == ", %this.Types[%typeName]  );
   if(%this.Settings[Debug]) echo("%this.Settings[Debug] == ", %this.Settings[Debug]  );
   
   %typeName = strlwr( %typeName );

   // Check if type exists already and if so, exit early
   if( %this.Types[%typeName] !$= "" ) 
   {
      return;
   }
   
   // Check whether group number is OK and if not, select one automatically
   if( ( %group $= "" ) || ( ( %this.Settings[TypesMask] & (0x1 << %group) ) != 0 ) )
   {
      %group=0;
      while( ( %this.Settings[TypesMask] & (0x1 << %group) ) != 0 ) 
      {
         %group++;
         
         if(%group >= 32)
         {
            error("RGQC::createType() - Error, out of groups.");      
            return;
         }
      }
   }
   
   // Store group number and reserve associated bit in Types Mask
   %this.Settings[TypesMask] = %this.Settings[TypesMask] | (0x1 << %group);
   %this.Types[%typeName] =  %group;
   %this.Settings[KnownTypes] = trim(%this.Settings[KnownTypes] SPC %typeName);
   %this.Settings[KnownTypes] = sortWords( %this.Settings[KnownTypes] );
   

   // Create a SimSet to store all objects of the current type in when we config them
   // later
   %this.set[%typeName] = new SimSet();
   
   if(%this.Settings[Debug])
   {
      echo("Assigned RGQC.Types[", %typeName, "] group number: " , %group );
      echo("Current Types Mask: ", %this.Settings[TypesMask]  );
      echo("Current Known Types: ", %this.Settings[KnownTypes]  );
   }
}
