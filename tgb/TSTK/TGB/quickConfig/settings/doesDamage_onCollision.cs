///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

/*
Description: Use this method to set the damage %amount done by %srcType to %dstType upon collision.
Note: %srcType accepts a comma separated list of type names.
*/
function RGQC::doesDamage_onCollision( %this, %srcType, %dstType, %amount )
{
   // Handle case where %dstType is comma-separated list of types
   if(strContains(%dstType,","))
   {
      %typeList = strreplace(%dstType, ",", " ");
      while(getWordCount( %typeList ))
      {
         %dstType = getWord( %typeList, 0);
         %typeList = popWordFront(%typeList);
         %this.doesDamage_onCollision( %srcType, %dstType, %amount );
      }
      return;
   }
   
   // Be sure types exist before doing any work
   %this.createType(%srcType);
   %this.createType(%dstType);
   
   // Be sure collision settings are configured
   %this.collidesWith( %srcType, %dstType );
   
   // Build up damage bits list
   %this.Types[%srcType,"damage_onCollisionBits"] = addUniqueWord( %this.Types[%srcType,"damage_onCollisionBits"], %this.Types[%dstType] ); 

   // Set the damage mask up too (may seem wasteful to do over and over, but saves a lot of time later)
   %this.Types[%srcType,"damage_onCollisionMask"] = bits( %this.Types[%srcType,"damage_onCollisionBits"] );
   %this.Types[%srcType,%dstType,"damage_onCollisionAmount"] = %amount;   
}

/*
Description: Get a space separated list of numbers representing graph group of all objects that %srcType does damage to onCollision.
*/
function RGQC::getDamage_onCollisionBits( %this, %srcType ) // not sorted
{
   return( %this.Types[%srcType,"damage_onCollisionBits"] );
}

/*
Description: Get a bitmask representing graph group of all objects that %srcType does damage to onCollision.
*/
function RGQC::getDamage_onCollisionMask( %this, %srcType )
{
   return( %this.Types[%srcType,"damage_onCollisionMask"] );
}

/*
Description: Get the amount of damage %srcType does to %dstType onCollision.
*/
function RGQC::getDamage_onCollisionAmount( %this, %srcType, %dstType )
{
   %amount =  %this.Types[%srcType,%dstType,"damage_onCollisionAmount"];
   
   if(%amount $= "") return 0;
   return( %amount );
}

