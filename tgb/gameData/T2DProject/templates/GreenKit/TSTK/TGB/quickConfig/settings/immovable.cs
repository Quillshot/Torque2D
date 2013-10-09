///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

////
//   Immovable
////
/*
Description: Use this method to set the immovable flag for one or more types.
Note: %srcType accepts a comma separated list of type names.
*/
function RGQC::setImmovable( %this, %srcType, %val ) 
{
   if(strContains(%srcType,","))
   {
      %typeList = strreplace(%srcType, ",", " ");
      while(getWordCount( %typeList ))
      {
         %srcType = getWord( %typeList, 0);
         %typeList = popWordFront(%typeList);
         %this.Types[%srcType,"Immovable"] = %val;
      }
      return;
   }   
   %this.Types[%srcType,"Immovable"] = %val;
}

/*
Description: Apply the immovable settings to a specified object using the specified type's settings.
Called by 'RGQC::applyQC()'
*/
function RGQC::config_immovable( %this, %obj, %typeName )
{
   if(%this.Types[%typeName,"Immovable"] !$= "")
   {
      %obj.setImmovable(%this.Types[%typeName,"Immovable"]);
   }
}
