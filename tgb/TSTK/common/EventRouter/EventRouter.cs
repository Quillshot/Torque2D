//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

/*
Description: Initialize the event router system and create the global event router "GER".
Arguments:
EFM - EFM 
Returns: EFM 
*/
function initializeEventRouterSystem(  )
{
   if(isObject("GER"))
   {
      return GER.getID();
   }
   return( createEventRouter( "GER" ) );
}

/*
Description: Shutdown the event router system and destroy the global event router "GER" and all of its subrouters.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function cleanupEventRouterSystem(  )
{
   if(!isObject("GER") ) return;
   
   GER.deleteSet(true);
}

/*
Description: Create a new event router named %name.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function createEventRouter( %name )
{
   if( isObject( %name ) ) return %name.getID();

   // Be sure to create the Global Event Router if it does not exist.   
   if( ("GER" !$= %name ) && (!isObject("GER")) ) createEventRouter( "GER" );
   
   %theRouter = new scriptGroup( %name )
   {
      class = "eventRouter";
      enabled = true;
   };
   
   if ("GER" !$= %name ) GER.add( %theRouter );

   %theRouter.eventHandlers = new SimSet();
   %theRouter.eventChains   = new SimSet();
   
   %theRouter.lastClean = getSimTime();

   return %theRouter;
}

/*
Description: Add new event to list of catchable events.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function eventRouter::registerEvent( %theRouter, %eventName ) 
{
   %theRouter.eventList[%eventName] = "enabled";
}

/*
Description: Checks to see if %eventName is catchable event
Arguments:
EFM - EFM 
Returns: EFM 
*/
function eventRouter::isValidEvent( %theRouter, %eventName )
{
   if( "" $= %theRouter.eventList[%eventName] ) 
   {
       return false;
   }
   return true;
}

/*
Description: Enables/disables response to event %eventName
Arguments:
EFM - EFM 
Returns: EFM 
*/
function eventRouter::enableEvent( %theRouter, %eventName, %enabled )
{
   if(%enabled)
	   %theRouter.eventList[%eventName] = "enabled";
   else
      %theRouter.eventList[%eventName] = "disabled";
}

/*
Description: Return true if the specified event is enabled.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function eventRouter::isEventEnabled( %theRouter, %eventName )
{
	return( "enabled" $= %theRouter.eventList[%eventName] );
}

/*
Description: Enables/disables router
Arguments:
EFM - EFM 
Returns: EFM 
*/
function eventRouter::enable( %theRouter, %enabled )
{
	%theRouter.enabled = %enabled;
}

/*
Description: Returns true if this router is enabled.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function eventRouter::isEnabled( %theRouter )
{
	return( %theRouter.enabled );
}

/*
Description:  Deletes the event router and contents
Arguments:
EFM - EFM 
Returns: EFM 
*/
function eventRouter::delete( %theRouter )
{
	%theRouter.eventHandlers.deleteSet(true);
	%theRouter.eventChains.deleteSet(true);
	Parent::delete( %theRouter );
}

/*
Description: Registers a handler (function) to catch an event.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function eventRouter::registerHandler( %theRouter, %eventName , %handler ) 
{
	if( %theRouter.isValidEvent( %eventName ) == false )
		%theRouter.registerEvent( %eventName );

	%eventHandler = new ScriptObject()
	{
		handler   = %handler;
		eventName = %eventName;
	};

	%theRouter.eventHandlers.add( %eventHandler );
}

/*
Description: Registers a handler method to catch an event, calls this method on registered object.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function eventRouter::registerHandlerMethod( %theRouter, %eventName , %handler , %obj ) 
{
	if( !isObject( %obj  ) )
	{
	   error("ERROR::  eventRouter::registerHandlerMethod() - Invalid Object ID, did you mean to call registerHandler()?");
	   return;
	}

	if( %theRouter.isValidEvent( %eventName ) == false )
		%theRouter.registerEvent( %eventName );

	%eventHandler = new ScriptObject()
	{
		methodHandler   = %handler;
		obj             = %obj.getID();
		eventName       = %eventName;
	};

	%theRouter.eventHandlers.add( %eventHandler );
}

/*
Description: Registers an event to fired when %eventName is fired.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function eventRouter::registerChainedEvent( %theRouter, %eventName , %chainedEventName ) 
{
	if( %theRouter.isValidEvent( %eventName ) == false )
		%theRouter.registerEvent( %eventName );

	if( %theRouter.isValidEvent( %chainedEventName ) == false )
		%theRouter.registerEvent( %chainedEventName );

	%eventChain = new ScriptObject()
	{
		eventName        = %eventName;
		chainedEventName = %chainedEventName;
	};

	%theRouter.eventChains.add( %eventChain );
}

//
// EFM Routine to unregister chained events?
//

/*
Description: Removes the specified handler(s) for the named event.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function eventRouter::unregisterHandler( %theRouter, %eventName , %handler )
{
	%deadHandlers = new simSet();

	%stmt = "if( ( tok.handler $= " @ %handler @ " ) && ( tok.eventName $= " @ %eventName @ " ) ) " @ %deadHandlers @ ".add(tok);";

	%theRouter.eventHandlers.forEachStmt(  %stmt , "tok" );

	%deadHandlers.deleteSet(true);
}

/*
Description: Removes the specified handler(s) method for the named event if it/they match the specified object.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function eventRouter::unregisterMethodHandler( %theRouter, %eventName , %handlerMethod , %obj ) 
{
	%deadHandlers = new simSet();

	%stmt = "if( ( tok.obj == " @ %obj @ " ) && ( tok.handlerMethod $= " @ %handlerMethod @ " ) && ( tok.eventName $= " @ %eventName @ " ) ) " @ %deadHandlers @ ".add(tok);";

	%theRouter.eventHandlers.forEachStmt(  %stmt , "tok" );

	%deadHandlers.deleteSet(true);
}

/*
Description: Search the router for any handlers associated with objects that no longer exist and unregister the handlers.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function eventRouter::unregisterDeadObjects( %theRouter  ) 
{
	%deadHandlers = new simSet();

	%stmt = "if( !isObject( tok.obj ) ) " @ %deadHandlers @ ".add(tok);";

	%theRouter.eventHandlers.forEachStmt(  %stmt , "tok" );

	%deadHandlers.deleteSet(true);
}

/*
Description: Find all handlers associated with a specific object and unregister them with this handler.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function eventRouter::unregisterObject( %theRouter, %obj ) 
{
	%deadHandlers = new simSet();

	%stmt = "if( tok.obj == " @ %obj @ " ) " @ %deadHandlers @ ".add(tok);";

	%theRouter.eventHandlers.forEachStmt(  %stmt , "tok" );

	%deadHandlers.deleteSet(true);
}

// Post event to all registered routers
/*
Description: Post a named event to the global event router with up to 10 optional arguments.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function postEvent( %eventName , %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10 )
{
   if(!isObject("GER") ) createEventRouter( "GER" );
   
   GER.eventProcessingStack = pushWordFront( GER.eventProcessingStack , %eventName );
   
   // Post event to any handlers in GER first
   GER.postEvent( %eventName , %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10 );
   
   // Post event to any registered routers next
   for(%count = 0; %count < GER.getCount(); %count++)
   {
      (GER.getObject(%count)).postEvent( %eventName , %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10 );
      //error("Posted ", %eventName, " to router ", (GER.getObject(%count)).getName() );
   }
   
   if( %eventName !$= getWord( GER.eventProcessingStack  , 0 ) )
   {
      error("ERROR:: eventRouter::postEvent() - Event ", %eventName, "got popped prematurely?");
      error("ERROR:: eventRouter::postEvent() - Front event is: ", getWord( GER.eventProcessingStack , 0 ));
   }
   
   GER.eventProcessingStack = popWordFront( GER.eventProcessingStack );
}

/*
Description: Post a named event to a specific router with up to 10 optional arguments.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function eventRouter::postEvent( %theRouter, %eventName , %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10 )  // Post an event for handling with up to 10 optional arguments
{
	if( %theRouter.isValidEvent( %eventName ) == false )
	{
      //warn(%theRouter.getName(), ":: Event ", %eventName , " was not registered to this event handler?" );
      return;
	}
	
	// Check if a cleaning is needed (once ever 15000 seconds or less)
	if ( (getSimTime() - %theRouter.lastClean) > 15000 )
	{
	   %theRouter.unregisterDeadObjects();
	   %theRouter.lastClean = getSimTime();
	}

	if( false == %theRouter.isEnabled() ) return false;

	for( %count = 0 ; %count < %theRouter.eventHandlers.getCount(); %count++ )
	{
		%theHandlerObject = %theRouter.eventHandlers.getObject( %count );

		if(%theHandlerObject.eventName !$= %eventName ) continue;

		if( false == %theRouter.isEventEnabled( %theHandlerObject.eventName ) ) continue;

		if( "" !$= %theHandlerObject.handler )
		{
      //echo("\c5Event: " , %eventName , " ==> Handler: ", %theHandlerObject.handler );
      call( %theHandlerObject.handler , %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10 );		
		}
		else if ( ( "" !$= %theHandlerObject.methodHandler )  && (isObject( %theHandlerObject.obj ) ) )
		{
      //echo("\c5Event: " , %eventName , " ==> Method Handler: ", %theHandlerObject.methodHandler, " ==> Obj: ", %theHandlerObject.obj );
      
      for( %count2 = 1; %count2 <= 10 ; %count2++ ) 
      {
         %arg[%count2] = ("" $= %a[%count2]) ? "\"\"" : "\"" @ %a[%count2] @ "\""  ;
      }
      
      if( "" $= %a1 )
      {
         %evalStr = %theHandlerObject.obj @ "." @ %theHandlerObject.methodHandler @"();";
      }
      else
      {
         %evalStr = %theHandlerObject.obj @ "." @ %theHandlerObject.methodHandler @"("@
               %arg1@","@
               %arg2@","@
               %arg3@","@
               %arg4@","@
               %arg5@","@
               %arg6@","@
               %arg7@","@
               %arg8@","@
               %arg9@","@
               %arg10@");";		
      }
            
      //echo( %evalStr );
      eval( %evalStr );
		}
	}
	%theRouter.fireChainedEvents( %eventName , %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10 );
}

/*
Description: Fire event chains for a specific event name for on this event router, passing in up to 10 optional arguments.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function eventRouter::fireChainedEvents( %theRouter, %eventName , %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10 )  // Post an event for handling with up to 10 optional arguments
{
	if( %theRouter.isValidEvent( %eventName ) == false )
	{
		warn("Event ", %eventName , " was not registered to this event handler?" );
		return false;
	}

	if( false == %theRouter.isEnabled() ) return false;

	for( %count = 0 ; %count < %theRouter.eventChains.getCount(); %count++ )
	{
		%theChainObject = %theRouter.eventChains.getObject( %count );

		if(%theChainObject.eventName !$= %eventName ) continue;

		if( false == %theRouter.isEventEnabled( %theChainObject.eventName ) ) continue;

		//echo("\c3Event: " , %eventName , " ==> Chained Event: ", %theChainObject.chainedEventName );

		%theRouter.postEvent( %theChainObject.chainedEventName , %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10 );
	}
}

/*
Description: Determine what the currently processing event is.  
Arguments:
EFM - EFM 
Returns: EFM 
*/
function getCurrentlyProcessingEvent()
{
   if(!isObject("GER") )
   {
      return "";
   }
   return getWord( GER.eventProcessingStack  , 0 );
}

/*
Description: 
Determine whether the specified event is being processed by the global event handler.  This can be used in handlers that post to insure that they don't enter an endless loop. i.e. Event A -> Event B -> ... -> Event A
Arguments:
EFM - EFM 
Returns: EFM 
*/
function isEventProcessing( %eventName )
{
   if(!isObject("GER") )
   {
      return false;
   }
   return strContains( GER.eventProcessingStack  , %eventName ); //EFM can return false positives for sub-string matches
}
