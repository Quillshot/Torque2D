///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

/*
Description: Use this method to set the energy points for one or more types.
Note: %srcType accepts a comma separated list of type names.
*/
function RGQC::setEnergyPoints( %this, %srcType, %max, %disabledAt, %destroyedAt, %amountPerSecond ) 
{
   // Handle case where %dstType is comma-separated list of types
   if(strContains(%srcType,","))
   {
      %typeList = strreplace(%srcType, ",", " ");
      while(getWordCount( %typeList ))
      {
         %srcType = getWord( %typeList, 0);
         %typeList = popWordFront(%typeList);
         %this.Types[%srcType,"energyPoints_Max"] = %max;
         %this.Types[%srcType,"energyPoints_DisabledAt"] = %disabledAt;
         %this.Types[%srcType,"energyPoints_DestroyedAt"] = %destroyedAt;
         %this.Types[%srcType,"AutoRecharge"] = %amountPerSecond;
      }
      return;
   }
   
   %this.Types[%srcType,"energyPoints_Max"] = %max;
   %this.Types[%srcType,"energyPoints_DisabledAt"] = %disabledAt;
   %this.Types[%srcType,"energyPoints_DestroyedAt"] = %destroyedAt;
   %this.Types[%srcType,"AutoRecharge"] = %amountPerSecond;
}

/*
Description: Get a the specified type's 'maximum' energyPoints value.
*/
function RGQC::getEnergyPoints_Max( %this, %srcType ) 
{
   return (%this.Types[%srcType,"energyPoints_Max"]);
}

/*
Description: Get a the specified type's 'disabled at' energyPoints value.
*/
function RGQC::getEnergyPoints_DisabledAt( %this, %srcType ) 
{
   return (%this.Types[%srcType,"energyPoints_DisabledAt"]);
}

/*
Description: Get a the specified type's 'destroyed at' energyPoints value.
*/
function RGQC::getEnergyPoints_DestroyedAt( %this, %srcType ) 
{   
   return (%this.Types[%srcType,"energyPoints_DestroyedAt"]);
}

/*
Description: Apply the energyPoints settings to a specified object using the specified type's settings.
Called by 'RGQC::applyQC()'
*/
function RGQC::config_energyPoints( %this, %obj, %typeName )
{
   %maxEnergy = %this.getEnergyPoints_Max( %typeName );

   if(%maxEnergy !$= "")
   {
      %disabledAt = %this.getEnergyPoints_DisabledAt( %typeName );
      %destroyedAt = %this.getEnergyPoints_DestroyedAt( %typeName );
      %autoRechargeRate = %this.getAutoRecharge( %typeName );
      %obj.initEnergy(%maxEnergy,%disabledAt,%destroyedAt,%autoRechargeRate);
   }   
}

/*
Description: Use this method to set the autorecharge rate for one or more types.
Note: %srcType accepts a comma separated list of type names.
*/
function RGQC::setAutoRecharge( %this, %srcType, %amountPerSecond ) 
{
   // Handle case where %dstType is comma-separated list of types
   if(strContains(%srcType,","))
   {
      %typeList = strreplace(%srcType, ",", " ");
      while(getWordCount( %typeList ))
      {
         %srcType = getWord( %typeList, 0);
         %typeList = popWordFront(%typeList);
         %this.Types[%srcType,"AutoRecharge"] = %amountPerSecond;
      }
      return;
   }

   %this.Types[%srcType,"AutoRecharge"] = %amountPerSecond;
}

/*
Description: Get the autorecharge rate for a specified type.
*/
function RGQC::getAutoRecharge( %this, %srcType ) 
{
   return (%this.Types[%srcType,"AutoRecharge"] );
}

