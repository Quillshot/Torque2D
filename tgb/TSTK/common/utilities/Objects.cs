//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

/*
Description: Search the engine created SimGroup datablockGroup for all datablocks of a specified class and return them in a SimSet.
*/
function getAllDatablocksByClassName( %className )
{
   %tmpSet = new simset();
   %stmt = "if(tok.getClassName() $= " @ %className @ ") " @ %tmpSet.getID() @ ".add(tok);";
   
   datablockGroup.foreachStmt( %stmt , tok , false );
   
   return %tmpSet;
}

/*
Description: Search the SimGroups rootGroup, missionGroup, and missionCleanup for the first object created with class %className and return that object.
*/
function findFirstInstanceByClassName( %className )
{
   %tmpSet = new simset();

   //EFM doesn't find all objects. this is not good!   
   findAllByClassName( %tmpSet , rootGroup, %className );
   findAllByClassName( %tmpSet , missionGroup, %className );
   findAllByClassName( %tmpSet , missionCleanup, %className );

   %firstObject = %tmpSet.getObject(0);

   %tmpSet.delete();

   return %firstObject;
}


/*
Description: Search the %searchSet for all objects created with class %className and return them in a SimSet.
*/
function findAllByClassName(  %set, %searchSet , %className )
{  
   %numEntries = %searchSet.getCount();
   
   for( %count = 0 ; %count < %numEntries ; %count++ )
   {
      %curObject = %searchSet.getObject(%count);
      %curClassName = %curObject.getClassName();
      
      if( ( %set != %curObject ) && (%curClassName $= %className )) %set.add( %curObject );
      
      if( %curClassName $= "SimGroup" )  
         findAllByClassName( %set, %curObject , %className );
      else if( %curClassName $= "ScriptGroup" )  
         findAllByClassName( %set, %curObject , %className );      
      else if( %curClassName $= "SimSet" )  
         findAllByClassName( %set, %curObject , %className );
      else if( %curClassName $= "ScriptSet" )  
         findAllByClassName( %set, %curObject , %className );
      else if( %curClassName $= "GuiControl" )  
         findAllByClassName( %set, %curObject , %className );
   }
}


/*
Description: Search the %searchSet for all objects containing a field %fieldName, set to the value %fieldValue and return them in a SimSet.
*/
function findAllByFieldValue(  %set, %searchSet , %fieldName, %fieldValue )
{  
   %numEntries = %searchSet.getCount();
   
   for( %count = 0 ; %count < %numEntries ; %count++ )
   {
      %curObject = %searchSet.getObject(%count);
      %evalStr = "%curFieldValue = " @ %curObject @ "." @ %fieldName @ ";";
      //echo(%evalStr);
      eval(%evalStr);

      %curClassName = %searchSet.getObject(%count).getClassName();
      
      //echo("%curObject.getname() == ", %curObject.getname() );
      //echo("%curFieldValue (", %curFieldValue, ") ?= %fieldValue (", %fieldValue, ") ==> ",  %curFieldValue $= %fieldValue);
      //echo("%curFieldValue (", %curFieldValue, ") == %fieldValue (", %fieldValue, ") ==> ",  %curFieldValue == %fieldValue);
      
      if( ( %set != %curObject ) && ( %curFieldValue $= %fieldValue )) %set.add( %curObject );
      
      if( %curClassName $= "SimGroup" ) 
         findAllByFieldValue( %set, %curObject , %fieldName, %fieldValue );
      else if( %curClassName $= "ScriptGroup" )  
         findAllByFieldValue( %set, %curObject , %fieldName, %fieldValue );      
      else if( %curClassName $= "SimSet" )  
         findAllByFieldValue( %set, %curObject , %fieldName, %fieldValue );
      else if( %curClassName $= "ScriptSet" )  
         findAllByFieldValue( %set, %curObject , %fieldName, %fieldValue );
      else if( %curClassName $= "GuiControl" )  
         findAllByFieldValue( %set, %curObject , %fieldName, %fieldValue );
   }
}


/*
Description: Safely delete an object by defering that delete till the next free sim cycle.  This insures the object won't be in use by the scripting engine when it is deleted.
*/
function safelyDelete( %object )
{
   if( isObject( %object ) ) %object.schedule(0,delete);
}
