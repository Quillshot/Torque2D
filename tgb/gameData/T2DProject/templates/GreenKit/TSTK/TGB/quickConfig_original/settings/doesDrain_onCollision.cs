///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------
/*
Description: Use this method to set the energy drain %amount done by %srcType to %dstType upon collision.
Note: %srcType accepts a comma separated list of type names.
*/
function RGQC::doesDrain_onCollision( %this, %srcType, %dstType, %amount )
{
   // Handle case where %dstType is comma-separated list of types
   if(strContains(%dstType,","))
   {
      %typeList = strreplace(%dstType, ",", " ");
      while(getWordCount( %typeList ))
      {
         %dstType = getWord( %typeList, 0);
         %typeList = popWordFront(%typeList);
         %this.doesDrain_onCollision( %srcType, %dstType, %amount );
      }
      return;
   }

   // Be sure types exist before doing any work
   %this.createType(%srcType);
   %this.createType(%dstType);
   
   // Be sure collision settings are configured
   %this.collidesWith( %srcType, %dstType );
   
   // Build up drain bits list
   %this.Types[%srcType,"drain_onCollisionBits"] = addUniqueWord( %this.Types[%srcType,"drain_onCollisionBits"], %this.Types[%dstType] ); 

   // Set the drain mask up too (may seem wasteful to do over and over, but saves a lot of time later)
   %this.Types[%srcType,"drain_onCollisionMask"] = bits( %this.Types[%srcType,"drain_onCollisionBits"] );
   %this.Types[%srcType,%dstType,"drain_onCollisionAmount"] = %amount;   
}

/*
Description: Get a space separated list of numbers representing graph group of all objects that %srcType does energy drain to onCollision.
*/
function RGQC::getDrain_onCollisionBits( %this, %srcType ) // not sorted
{
   return( %this.Types[%srcType,"drain_onCollisionBits"] );
}

/*
Description: Get a bitmask representing graph group of all objects that %srcType does energy drain to onCollision.
*/
function RGQC::getDrain_onCollisionMask( %this, %srcType )
{
   return( %this.Types[%srcType,"drain_onCollisionMask"] );
}

/*
Description: Get the amount of energy drain %srcType does to %dstType onCollision.
*/
function RGQC::getDrain_onCollisionAmount( %this, %srcType, %dstType )
{
   %amount =  %this.Types[%srcType,%dstType,"drain_onCollisionAmount"];
   
   if(%amount $= "") return 0;
   return( %amount );
   
}

