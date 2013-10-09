//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

/*
Description: Bind a specified %callback on a specified %object such that it is called whenever %device + %action occurs.
This is different from normal binds in that multiple objects and/or callbacks can be bound to the same %device + %action.

Note: If %object is 0 or "", then %callback is treated as a plain function.
*/
function ActionMap::bindMulti( %this, %device, %action, %object, %callback )
{   
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
      "   multiBinder.executeCallbacks( " @ %bindEventFunction @ " , %val );" @
      "}";
   
      //error( %evalStr ); 
      eval( %evalStr );      
   }
   // Bind the binder (function) to the specified device + action
   %this.bind( %device, %action, "D", (-$pref::JoystickDeadZone) SPC $pref::JoystickDeadZone, %bindEventFunction );

   // Create a multibinder
   createMultiBinder( %bindEventFunction, %object, %callback ) ;
}

/*
Description: Unbind a specified %callback on a specified %object which was previously bound to %device + %action.
EFM - Not yet implemented.
*/
function ActionMap::unbindMulti( %this, %device, %action, %object, %callback )
{   
   // Currently does NOTHING.
}

/*
Description: Internal only.  Creates a special 'multiBinder' object used to create multi-binding routers.
*/
function createMultiBinder( %bindEventFunction, %objID, %callbackName )
{
   if( !isObject("multiBinder") ) 
   {   
      %binder = new ScriptObject( "multiBinder" );
      %binder.routers = new SimSet();
   }
   //error("multiBinder.getId() == ", multiBinder.getId());
   
   if( !isObject( multiBinder.routers[%bindEventFunction] ) )
   {
      %routers = new SimSet();
      multiBinder.routers[%bindEventFunction] = %routers;
      //error("multiBinder.routers[", %bindEventFunction, "] == ", multiBinder.routers[%bindEventFunction]);
      //error("multiBinder.routers.getID() == ", multiBinder.routers.getID());
      multiBinder.routers.add(%routers);
   }
   %router = createMultiBindRouter( %objID, %callbackName );
   (multiBinder.routers[%bindEventFunction]).add( %router );

}

/*
Description: Internal only. Used to connect input events to multiple object->callbacks and/or functions.
*/
function createMultiBindRouter( %objID, %callbackName )
{
   %multibindRouter = new ScriptObject( multiBindRouter )
   {
      obj          = %objID;
      callbackName = %callbackName;
   };
   return %multibindRouter;   
}

/*
Description: Internal only. Execute the callback specified for this router and pass in the input actoin %val.
*/
function multiBindRouter::executeCallback( %this, %val )
{
   //error("multiBindRouter.executeCallback( ", %val, " )" );
   
   if(isObject(%this.obj))
   {
      %evalStr = (%this.obj).getID() @ "." @ %this.callbackName @ "(" @ %val @ ");";
   }
   else
   {
      %evalStr = %this.callbackName @ "(" @ %val @ ");";
   }
   //error(%evalStr);
   eval(%evalStr);
}

/*
Description: Internal only. Execute all callbacks associated with the specific binding event.
*/
function multiBinder::executeCallbacks(%this, %bindEventFunction, %val )
{
   //error("multiBinder.executeCallbacks( ", %bindEventFunction, ",", %val, " )" );
   %routers = %this.routers[%bindEventFunction];
   //error("multiBinder.executeCallbacks() %routers.getID() == ", %routers.getID() );
   
   if(isObject(%routers))
   {
      %routers.forEachStmt( "tok.executeCallback(" @ %val @ ");", tok  );
   }
}



