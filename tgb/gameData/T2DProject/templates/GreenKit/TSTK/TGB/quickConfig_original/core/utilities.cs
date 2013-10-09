//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

////
//   MISC UTILITY FUNCTIONS
////
/*
Description: Return the graph group for specified type: %typeName.
*/
function RGQC::getGraphGroup( %this, %typeName ) 
{
   return %this.Types[%typeName];
}

/*
Description: Return the space-seperated list of known types.
*/
function RGQC::getKnownTypes( %this )
{   
   return %this.Settings[KnownTypes];
}

/*
Description: Return the generic QC attribute %attr for specified type: %typeName.
*/
function RGQC::getQCAttribute( %this, %typeName, %attr  ) 
{
   return %this.Types[%typeName,%attr];
}

/*
Description: Return the generic QC attribute %attr amount relationship for specified types: %srcType and %dstType.
*/
function RGQC::getQCAttributeAmount( %this, %srcType, %dstType, %attr  ) 
{
   return %this.Types[%srcType,%dstType,%attr,amount];
}