//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

/*
Description: Create an instance TGB event manager, extra work required to make the manager work properly.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function createTGBEventManager(%name)
{
   
   if(isObject(%name))
   {
      error("CreateTGBEventManager() unable to create EventManager => ", 
            %name, " already exists!" );
      return 0; 
   }
   
   if(isQueueRegistered(%name @ "_queue"))
   {
      error("CreateTGBEventManager() unable to create EventManager queue => ", 
            %name @ "_queue", " already exists!" );
      return 0;
   }
   
   registerMessageQueue(%name @ "_queue");
   
   %mgr = new EventManager( %name )
   {
      queue = %name @ "_queue";
   };
   
   if(!isObject(%mgr))
   {
      error("CreateTGBEventManager() unable to create EventManager => ", %name );
      return 0;
   }
   
   return %mgr;
}


/*
Description: Bind an input event to an (optional) object and a (required) callback (method/function), using a TGB event manager.
Warning: I've had problems with this, to the extent of encountering crashes.  I suggest you use the Roaming Gamer bindMulti feature instead.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function ActionMap::bindTGBEvent( %this, %device, %action, %object, %callback )
{   
   echo("ActionMap::bindTGBEvent( " SPC %this SPC "," SPC %device SPC "," SPC %action SPC "," SPC %object SPC "," SPC %callback SPC ")");
   // Be sure "TGB_AcionMap_EM" exists
   if( !isObject( "TGB_AcionMap_EM" ) )
   {
      error("************ CREATING EVENT MGR ******************");
      createTGBEventManager( "TGB_AcionMap_EM" );
   }
   
   // Try to create a unique name for the input binder
   %actionMapName = %this.getName();
   %actionMapName = (%actionMapName !$= "") ? %actionMapName : "NONAME";   
   %bindTGBEventFunction = %actionMapName @ "_" @ %device @ "_" @ %action;
   //
   //error( "=====> Check to see if event: ", %bindTGBEventFunction, " is registered..." );
//
   //%isRegistered = TGB_AcionMap_EM.isRegisteredEvent( %bindTGBEventFunction );
   //
   //if(%isRegistered)
      //error(" YES - It is registered. --> ", %isRegistered );
   //else
      //error(" NO - It is not registered. --> ", %isRegistered );
//
   //// Be sure the event is bound
   //if( %isRegistered == 0)
   //{
      //error( %bindTGBEventFunction, " not registered?" );
      //TGB_AcionMap_EM.registerEvent(%bindTGBEventFunction);
   //}
   TGB_AcionMap_EM.registerEvent(%bindTGBEventFunction);

   
   // Check to see if this event function exists.  If not, create it.
   if(!isFunction( %bindTGBEventFunction ))
   {
      //error( "Generate multi-bind function for ", %bindTGBEventFunction );
      %evalStr = 
      "function" SPC %bindTGBEventFunction @ "( %val )" @
      "{" @
      "   TGB_AcionMap_EM.postEvent( " @ %bindTGBEventFunction @ " , %val );" @
      "}";
   
      //error( %evalStr ); 
      eval( %evalStr );      
   }
   // Bind the binder (function) to the specified device + action
   %this.bind( %device, %action, "D", (-$pref::JoystickDeadZone) SPC $pref::JoystickDeadZone, %bindTGBEventFunction );

   // Register a method handler for the binder (event)
   echo("TGB_AcionMap_EM.subscribe( " SPC %object SPC "," SPC %bindTGBEventFunction SPC "," SPC %callback SPC ")");
   TGB_AcionMap_EM.subscribe( %object, %bindTGBEventFunction, %callback );
}

/*
Description: Unbind an input event from an (optional) object and a (required) callback (method/function), using a TGB event manager.
Warning: I've had problems with this, to the extent of encountering crashes.  I suggest you use the Roaming Gamer bindMulti feature instead.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function ActionMap::unbindTGBEvent( %this, %device, %action, %object, %callback )
{   
   // Be sure "TGB_AcionMap_EM" exists
   if( !isObject( "TGB_AcionMap_EM" ) )
   {
      createTGBEventManager( "TGB_AcionMap_EM" );
   }
   
   // Try to create a unique name for the input binder
   %actionMapName = %this.getName();
   %actionMapName = (%actionMapName !$= "") ? %actionMapName : "NONAME";   
   %bindTGBEventFunction = %actionMapName @ "_" @ %device @ "_" @ %action;

   %this.unbind( %device, %action );

   // Un-Register a method handler for the binder (event)
   TGB_AcionMap_EM.remove( %object, %bindTGBEventFunction ) ;
}

/// INTERNAL ONLY BELOW THIS LINE - USED FOR TESTING EVENT MANAGER

function foo::testEventA( %this, %val )
{
   echo("foo::testEventA(" SPC %this SPC "," SPC %val SPC ")" );
}

function bar::testEventB( %this, %val )
{
   echo("bar::testEventB(" SPC %this SPC "," SPC %val SPC ")" );
}
function foo::testEventC( %this, %val )
{
   echo("foo::testEventC(" SPC %this SPC "," SPC %val SPC ")" );
}

function bar::testEventC( %this, %val )
{
   echo("bar::testEventC(" SPC %this SPC "," SPC %val SPC ")" );
}

function testIsRegistered( %event )
{
   error( "=====> Check to see if event: ", %event, " is registered..." );
   
   %isRegistered = bobo.isRegisteredEvent( %event );
   
   if(%isRegistered)
      error(" YES - It is registered. --> ", %isRegistered );
   else
      error(" NO - It is not registered. --> ", %isRegistered );
}

/*
Description: Internal only. Used to test TGB event manager.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function testEM()
{
   createTGBEventManager("bobo");
 
   testIsRegistered(eventA);
   bobo.registerEvent("eventA");
   testIsRegistered(eventA);
   bobo.registerEvent("eventB");
   testIsRegistered(eventB);
   testIsRegistered(eventA);
   
   new ScriptObject(foo);
   new ScriptObject(bar);
   
   bobo.subscribe( foo, eventA, testEventA );
   bobo.subscribe( bar, eventB, testEventB );

   bobo.registerEvent("eventA");
   bobo.registerEvent("eventB");   
   
   bobo.subscribe( foo, eventA, testEventC );
   bobo.subscribe( bar, eventB, testEventC );   
   
   bobo.postEvent( eventA, 0 );
   bobo.postEvent( eventB, 1 );   
   
   bobo.delete();
}


