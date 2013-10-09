//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

/*
Description:
Calls named method on all other behaviors in current owner that 
implement this method.

This is designed to allow behaviors to blindly access
callbacks in other behaviors (with the same owner) and can be thought
of as a rudimentary message system.  It allows for the design
of complex behavior interaction without knowing the name of those behaviors
in advance.

This feature is used by many of the RG damage & energy behaviors.

EFM =>
This should work, but doesn't (bug?) =>
function BehaviorInstance::broadcastMethod(%this, %methodName, ...
Using SimObject:: for now until this is resolved.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function SimObject::broadcastMethod(%this, %methodName, %arg0, %arg1, %arg2, %arg3, %arg4, %arg5, %arg6, %arg7, %arg8, %arg9)
{
   // EFM =>
   // Temporary protection from mis-calls since we're forced to use the
   // SimObject namespace to scope the method.
   if(%this.getClassName() !$= "BehaviorInstance") return;
   
   %behaviorCount = %this.owner.getBehaviorCount();

   // Try to execute the named method on all behaviors in this owner
   // except for the sender
   for( %count = 0; %count < %behaviorCount; %count++)
   {
      %behavior = %this.owner.getBehaviorByIndex( %count );

      // Only try to execute the method on other behaviors
      if(%behavior == %this ) 
      {
         //echo("Skipping this behavior: ", %behavior );
         continue;
      }
      
      if(%behavior.isMethod( %methodName ))
      {
         //echo("Found method on behavior: ", %behavior);
         %behavior.call( %methodName, %arg0, %arg1, %arg2, %arg3, %arg4,
                         %arg5, %arg6, %arg7, %arg8, %arg9);
      }
   }
}

/*
Description:
Same as broadcastMethod() but used by t2dSceneObject and its children to 
call a named method on all of that objects' behaviors.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function t2dSceneObject::broadcastBehaviorMethod(%this, %methodName, %arg0, %arg1, %arg2, %arg3, %arg4, %arg5, %arg6, %arg7, %arg8, %arg9)
{   
   %behaviorCount = %this.getBehaviorCount();

   // Try to execute the named method on all behaviors in this owner
   // except for the sender
   for( %count = 0; %count < %behaviorCount; %count++)
   {
      %behavior = %this.getBehaviorByIndex( %count );

      if(%behavior.isMethod( %methodName ))
      {
         //echo("Found method on behavior: ", %behavior);
         %behavior.call( %methodName, %arg0, %arg1, %arg2, %arg3, %arg4,
                         %arg5, %arg6, %arg7, %arg8, %arg9);
      }
   }
}


//EFM - fix for TGB 1.7.4 quirk
// If we use a config datablock to initialize an object in the editor 
// (or in the game), that object doesn't get any behaviors stored in the
// config datablock record.
// Saving and reloading a level after assigning a datablock (w/ behaviors)
// works, but that is far too late.  We need the setConfigDatablock() method
// to attach the behaviors to the object right away.
package TGB174_SetConfigDatablock_BehaviorFix
{

/*
Description:
Fix for TGB 1.7.4 setConfigDatablock() quirk.

Without this fix, if we use a config datablock to initialize an object in the editor (or in the game), that object doesn't get any behaviors stored in the config datablock record.
Saving and reloading a level after assigning a datablock (w/ behaviors) works, but that is far too late.  
We need the setConfigDatablock() method to attach the behaviors to the object right away.
Arguments:
EFM - EFM 
Returns: EFM 
*/   
   function t2dSceneObject::setConfigDatablock( %this, %newDB )
   {

      // 1. Let the Parent:: version do its work.
      Parent::setConfigDatablock( %this, %newDB );

      // 2. Remove old (existing) behaviors from this object
      //    Do it twice, becaue the first time leaves a single 
      //    behavior behind
      for(%pass = 0; %pass < 2; %pass++)
      {
         %behaviorCount = %this.getBehaviorCount();
         for( %count = 0; %count < %behaviorCount; %count++)
         {
            %behavior = %this.getBehaviorByIndex( %count );
            //error("Removing behavior instance: ", %behavior );
            %this.removeBehavior(%behavior, true);
         }
      }

      // 3. Discover each behavior that was added to this OBJ, set it aside,
      // and clear the 'tracking' field'
      %count = 0;
      while( %this._behavior[%count] !$= "" )
      {
         //error("Setting aside behavior string: ", %this._behavior[%count] );
         %tmpBehavior[%count] = %this._behavior[%count];
         %this._behavior[%count] = "";
         %count++;
      }
      %totalStrings = %count;
      
      // 5. Build new instances of each DB that was in the DB
      for(%count = 0; %count < %totalStrings; %count++)
      {
         %behavior = getField(%tmpBehavior[%count], 0);
         %instance = %behavior.createInstance();

         // Set fields in instance based on settings stored in the behavior string
         %fieldIndex = 1;
         %fieldName = getField(%tmpBehavior[%count], %fieldIndex);
         %fieldValue = getField(%tmpBehavior[%count], %fieldIndex+1);
         while( %fieldName !$= "" )
         {
            %instance.setFieldValue( %fieldName, %fieldValue);
            
            %fieldIndex++;
            %fieldName = getField(%tmpBehavior[%count], %fieldIndex);
            %fieldValue = getField(%tmpBehavior[%count], %fieldIndex+1);
         }

         //error("Adding _behavior[",%count,"] (", %instance, ") == ", %tmpBehavior[%count] );
         %this.addBehavior(%instance);
      }
      
      // Force Quick Edit GUI to update 
      schedule( 0, 0, updateQuickEdit );
   }   
};

if($TSTK::Enable_ConfigDatablock_BehaviorFix)
{
   activatePackage( TGB174_SetConfigDatablock_BehaviorFix );
}
   


