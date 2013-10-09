///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------
/*
Description: Use this method to set the damage (hit) points for one or more types.
Note: %srcType accepts a comma separated list of type names.
*/
function RGQC::setDamagePoints( %this, %srcType, %max, %disabledAt, %destroyedAt, %amountPerSecond ) 
{
   // Handle case where %dstType is comma-separated list of types
   if(strContains(%srcType,","))
   {
      %typeList = strreplace(%srcType, ",", " ");
      while(getWordCount( %typeList ))
      {
         %srcType = getWord( %typeList, 0);
         %typeList = popWordFront(%typeList);
         %this.Types[%srcType,"damagePoints_Max"] = %max;
         %this.Types[%srcType,"damagePoints_DisabledAt"] = %disabledAt;
         %this.Types[%srcType,"damagePoints_DestroyedAt"] = %destroyedAt;
         %this.Types[%srcType,"AutoRepair"] = %amountPerSecond;
      }
      return;
   }
   
   %this.Types[%srcType,"damagePoints_Max"] = %max;
   %this.Types[%srcType,"damagePoints_DisabledAt"] = %disabledAt;
   %this.Types[%srcType,"damagePoints_DestroyedAt"] = %destroyedAt;
   %this.Types[%srcType,"AutoRepair"] = %amountPerSecond;
}

/*
Description: Get a the specified type's 'maximum' damagePoints value.
*/
function RGQC::getDamagePoints_Max( %this, %srcType ) 
{
   return (%this.Types[%srcType,"damagePoints_Max"]);
}

/*
Description: Get a the specified type's 'disabled at' damagePoints value.
*/
function RGQC::getDamagePoints_DisabledAt( %this, %srcType ) 
{
   return (%this.Types[%srcType,"damagePoints_DisabledAt"]);
}

/*
Description: Get a the specified type's 'destroyed at' damagePoints value.
*/
function RGQC::getDamagePoints_DestroyedAt( %this, %srcType ) 
{   
   return (%this.Types[%srcType,"damagePoints_DestroyedAt"]);
}

/*
Description: Apply the damagePoints settings to a specified object using the specified type's settings.
Called by 'RGQC::applyQC()'
*/
function RGQC::config_damagePoints( %this, %obj, %typeName )
{
   %maxDamage = %this.getDamagePoints_Max( %typeName );

   error("RGQC::config_damagePoints() - %maxDamage == ", %maxDamage );

   if(%maxDamage !$= "")
   {
      %disabledAt = %this.getDamagePoints_DisabledAt( %typeName );
      %destroyedAt = %this.getDamagePoints_DestroyedAt( %typeName );
      %autoRepairRate = %this.getAutoRepair( %typeName );
      %obj.initDamage(%maxDamage,%disabledAt,%destroyedAt,%autoRepairRate);
   }   
}

/*
Description: Use this method to set the autorepair rate for one or more types.
Note: %srcType accepts a comma separated list of type names.
*/
function RGQC::setAutoRepair( %this, %srcType, %amountPerSecond ) 
{
   // Handle case where %dstType is comma-separated list of types
   if(strContains(%srcType,","))
   {
      %typeList = strreplace(%srcType, ",", " ");
      while(getWordCount( %typeList ))
      {
         %srcType = getWord( %typeList, 0);
         %typeList = popWordFront(%typeList);
         %this.Types[%srcType,"AutoRepair"] = %amountPerSecond;
      }
      return;
   }
   
   %this.Types[%srcType,"AutoRepair"] = %amountPerSecond;
}

/*
Description: Get the autorepair rate for a specified type.
*/
function RGQC::getAutoRepair( %this, %srcType ) 
{
   return (%this.Types[%srcType,"AutoRepair"] );
}

