///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

/*
Description: Use this method to enable Collision between %srcType and or more %dstType types.
Note: %dstType accepts a comma separated list of type names.
*/
function RGQC::collidesWith( %this, %srcType, %dstType )
{
   // Handle case where %dstType is comma-separated list of types
   if(strContains(%dstType,","))
   {
      %typeList = strreplace(%dstType, ",", " ");
      while(getWordCount( %typeList ))
      {
         %dstType = getWord( %typeList, 0);
         %typeList = popWordFront(%typeList);
         %this.collidesWith( %srcType, %dstType );
      }
      return;
   }
   // Be sure types exist before doing any work
   %this.createType(%srcType);
   %this.createType(%dstType);
   
   // Build up collision bits lists 
   %this.Types[%srcType,"collisionBits"] = addUniqueWord( %this.Types[%srcType,"collisionBits"], %this.Types[%dstType] ); 
   %this.Types[%dstType,"collisionBits"] = addUniqueWord( %this.Types[%dstType,"collisionBits"], %this.Types[%srcType] ); 

   // Set the collision masks up too (may seem wasteful to do over and over, but saves a lot of time later)
   %this.Types[%srcType,"collisionMask"] = bits( %this.Types[%srcType,"collisionBits"] );
   %this.Types[%dstType,"collisionMask"] = bits( %this.Types[%dstType,"collisionBits"] );
}

/*
Description: Get a space separated list of numbers representing the bits that are to be set for the specified object type's (%srcType) collision settings.
*/
function RGQC::getCollisionBits( %this, %srcType ) // not sorted
{
   return( %this.Types[%srcType,"collisionBits"] );
}

/*
Description: Get a bitmask representing the bits that are to be set for the specified object type's (%srcType) collision settings.
*/
function RGQC::getCollisionMask( %this, %srcType )
{
   return( %this.Types[%srcType,"collisionMask"] );
}

/*
Description: Apply the collidesWith settings to a specified object using the specified type's settings.
Called by 'RGQC::applyQC()'
*/
function RGQC::config_collidesWith( %this, %obj, %typeName )
{
   if(%this.Types[%typeName,"collisionMask"] !$= "")
   {
      if(%this.Settings[Debug]) 
      {
         warn("Enabling collision for type: ", %typeName, " Mask: ", %this.Types[%typeName,"collisionMask"] );
      }
      %obj.setCollisionActiveSend(true);
      %obj.setCollisionActiveReceive(true);
      %obj.setCollisionCallback(true);
      
      %obj.setCollisionMasks( %this.Types[%typeName,"collisionMask"] );
   }
   else
   {
      %obj.setCollisionActiveSend(false);
      %obj.setCollisionActiveReceive(false);
      %obj.setCollisionCallback(false);
   }
}
