///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

////
//   Layer
////
/*
Description: Use this method to set the layer for one or more types.
Note: %srcType accepts a comma separated list of type names.
*/
function RGQC::setLayer( %this, %srcType, %layer ) 
{
   if(strContains(%srcType,","))
   {
      %typeList = strreplace(%srcType, ",", " ");
      while(getWordCount( %typeList ))
      {
         %srcType = getWord( %typeList, 0);
         %typeList = popWordFront(%typeList);
         %this.Types[%srcType,"Layer"] = %layer;
      }
      return;
   }   
   %this.Types[%srcType,"Layer"] = %layer;
}

/*
Description: Apply the layer settings to a specified object using the specified type's settings.
Called by 'RGQC::applyQC()'
*/
function RGQC::config_layer( %this, %obj, %typeName )
{
   if(%this.Types[%typeName,"Layer"] !$= "")
   {
      %obj.setLayer(%this.Types[%typeName,"Layer"]);
   }
}