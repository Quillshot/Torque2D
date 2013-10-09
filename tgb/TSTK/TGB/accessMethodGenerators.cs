//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

/*
Description: Utility function to generate a get/set method in a specified namespace for a specified field name.

Ex:
This call => generateBasicAccessMethods( "SimObject", "SomeField");
Generates two methods

// Returns value of 'SomeField' on %this.
function SimObject::getSomeField(%this)
{
   return %this.SomeField;
}

// Sets value of 'SomeField' on %this and returns new value.
function SimObject::getSomeField(%this, %value)
{
   %this.SomeField = %value;
   return %this.SomeField;
}
Arguments:
EFM - EFM 
Returns: EFM 
*/
function generateBasicAccessMethods( %namespace , %fieldName )
{
   generateBasicGetMethod( %namespace , %fieldName );
   generateBasicSetMethod( %namespace , %fieldName );
}

/*
Description: Utility function to generate a get method in a specified namespace for a specified field name.

Ex:
This call => generateBasicGetMethod( "SimObject", "SomeField");
Generates one method

// Returns value of 'SomeField' on %this.
function SimObject::getSomeField(%this)
{
   return %this.SomeField;
}
Arguments:
EFM - EFM 
Returns: EFM 
*/
function generateBasicGetMethod( %namespace , %fieldName )
{
   %evalStr = 
   "function " @ %namespace @ "::get" @ %fieldName @ "( %this )" @
   "{" @
   "    return %this." @ %fieldName @ ";" @
   "}";
   //echo( "\c3" @ %evalStr );
   eval( %evalStr );
}

/*
Description: Utility function to generate a set method in a specified namespace for a specified field name.

Ex:
This call => generateBasicSetMethod( "SimObject", "SomeField");
Generates one method

// Sets value of 'SomeField' on %this and returns new value.
function SimObject::getSomeField(%this, %value)
{
   %this.SomeField = %value;
   return %this.SomeField;
}
Arguments:
EFM - EFM 
Returns: EFM 
*/
function generateBasicSetMethod( %namespace , %fieldName )
{
   %evalStr = 
   "function " @ %namespace @ "::set" @ %fieldName @ "( %this , %value )" @
   "{" @
   "    %this." @ %fieldName @ " = %value;" @
   "    return %this." @ %fieldName @ ";" @
   "}";
   //echo( "\c3" @ %evalStr );
   eval( %evalStr );
}

