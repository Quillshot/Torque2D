///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

////
//   KILL (delete) object onCollision()
////
/*
Description: Use this method to set the KILL onCollision response for one or more types.
Note: %srcType accepts a comma separated list of type names.
*/
function RGQC::onCollision_KILL( %this, %srcType )
{
   // Handle case where %dstType is comma-separated list of types
   if(strContains(%srcType,","))
   {
      %typeList = strreplace(%srcType, ",", " ");
      while(getWordCount( %typeList ))
      {
         %srcType = getWord( %typeList, 0);
         %typeList = popWordFront(%typeList);
         %this.Types[%srcType,"collisionResponse"] = "KILL";
      }
      return;
   }   
   %this.Types[%srcType,"collisionResponse"] = "KILL";
}

////
//   BOUNCE object onCollision()
////
/*
Description: Use this method to set the BOUNCE onCollision response for one or more types.
Note: %srcType accepts a comma separated list of type names.
*/
function RGQC::onCollision_BOUNCE( %this, %srcType )
{
   if(strContains(%srcType,","))
   {
      %typeList = strreplace(%srcType, ",", " ");
      while(getWordCount( %typeList ))
      {
         %srcType = getWord( %typeList, 0);
         %typeList = popWordFront(%typeList);
         %this.Types[%srcType,"collisionResponse"] = "BOUNCE";
      }
      return;
   }   
   %this.Types[%srcType,"collisionResponse"] = "BOUNCE";
}

/*
Description: Apply the collisionResponse settings to a specified object using the specified type's settings.
Called by 'RGQC::applyQC()'
*/
function RGQC::config_collisionResponse( %this, %obj, %typeName )
{
   if(%this.Types[%typeName,"collisionResponse"]!$= "")
   {
      %obj.setCollisionResponse( %this.Types[%typeName,"collisionResponse"] );
   }
}