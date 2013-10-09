//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

/*
Description: It is suggested that you use the multiBind variant instead as it is more lightweight.  This is being retained for legacy purposes ONLY.
Warning: This is very similar to the bindMulti code in actionmap.cs, but uses the event router system. 
Arguments:
EFM - EFM 
Returns: EFM 
*/
function ActionMap::bindEvent( %this, %device, %action, %object, %callback )
{   
   // Be sure ActionMapER exists
   if( !isObject( ActionMapER ) )
   {
      createEventRouter( ActionMapER );
   }
   
   // Try to create a unique name for the input binder
   %actionMapName = %this.getName();
   %actionMapName = (%actionMapName !$= "") ? %actionMapName : "NONAME";   
   %bindEventFunction = %actionMapName @ "_" @ %device @ "_" @ %action;
   
   // Check to see if this event function exists.  If not, create it.
   if(!isFunction( %bindEventFunction ))
   {
      //error( "Generate multi-bind function for ", %bindEventFunction );
      %evalStr = 
      "function" SPC %bindEventFunction @ "( %val )" @
      "{" @
      "   ActionMapER.postEvent( " @ %bindEventFunction @ " , %val );" @
      "}";
   
      //error( %evalStr ); 
      eval( %evalStr );      
   }
   // Bind the binder (function) to the specified device + action
   %this.bind( %device, %action, "D", (-$pref::JoystickDeadZone) SPC $pref::JoystickDeadZone, %bindEventFunction );

   // Register a method handler for the binder (event)
   ActionMapER.registerHandlerMethod( %bindEventFunction, %callback, %object ) ;
}

/*
Description: It is suggested that you use the multiBind variant instead as it is more lightweight.  This is being retained for legacy purposes ONLY.
Warning: This is very similar to the bindMulti code in actionmap.cs, but uses the event router system. 
Arguments:
EFM - EFM 
Returns: EFM 
*/
function ActionMap::unbindEvent( %this, %device, %action, %object, %callback )
{   
   // Be sure ActionMapER exists
   if( !isObject( ActionMapER ) )
   {
      createEventRouter( ActionMapER );
   }
   
   // Try to create a unique name for the input binder
   %actionMapName = %this.getName();
   %actionMapName = (%actionMapName !$= "") ? %actionMapName : "NONAME";   
   %bindEventFunction = %actionMapName @ "_" @ %device @ "_" @ %action;

   %this.unbind( %device, %action );

   // Un-Register a method handler for the binder (event)
   ActionMapER.unregisterMethodHandler( %bindEventFunction, %callback, %object ) ;
}
