if (!isObject(isTextMeter))
{
   %behavior = new BehaviorTemplate(isTextMeter)
   {
      friendlyName = "Is Text Meter";
      behaviorType = "20 - Interfaces";
      description  = "Designate this as a (generic) text meter object (used for displaying score, lives, health, or energy).";
   };
   
   //%behavior.addValidObjectClass("t2dTextObject");   

   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   
   %behavior.addBehaviorField(Meter_Type, "What kind of data does this meter track?", 
                              enum, "LIFE", "ENERGY\tHEALTH\tLIFE\tSCORE");
                              
   %behavior.addBehaviorField(decimal_places, "How many decimal places should be displayed", int, 0);                              
}

function isTextMeter::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   
   %this.owner.ignoreMe = true;
   
   // Verify game master is present and add Meter to game master tracking set
   if(!isObject( theGameMaster )) new ScriptGroup( theGameMaster );
   theGameMaster.MeterSet.add(%this);
   
   theGameMaster.updateMeters();
}

function isTextMeter::getMeterType(%this) 
{
   return %this.Meter_Type;
}

function isTextMeter::getDecimalPlaces(%this) 
{
   return %this.decimal_places;
}



function isTextMeter::isEnergyMeter(%this) 
{
   return (%this.Meter_Type $= "ENERGY");
}

function isTextMeter::isHealthMeter(%this) 
{
   return (%this.Meter_Type $= "HEALTH");
}

function isTextMeter::isLifeMeter(%this) 
{
   return (%this.Meter_Type $= "LIFE");
}

function isTextMeter::isScoreMeter(%this) 
{
   return (%this.Meter_Type $= "SCORE");
}

function isTextMeter::setValue(%this, %value) 
{
   %this.owner.text = %value;
}

function isTextMeter::getValue(%this) 
{
   return %this.owner.getValue(%this, %value);
}