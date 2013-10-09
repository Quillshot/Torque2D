//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------


/*
Description: Causes objects to wrap around axis.  Assumes that screen is centered. i.e. Does not account for cases where the camera is offset.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function limitTeleport( %obj , %limit )
{
   %curPosX = %obj.getPositionX();
   %curPosY = %obj.getPositionY();
   
   switch$(%limit)
   {
   case "top": %curPosY = -%curPosY - 2;
   case "bottom": %curPosY = -%curPosY + 2;
   case "left": %curPosX = -%curPosX - 2;
   case "right": %curPosX = -%curPosX + 2;
   }
   
   %obj.setWorldLimitCallback( false );
   %obj.setPosition( %curPosX , %curPosY );
   %obj.schedule( 200 , setWorldLimitCallback , true );  
}

/*
Description: Copy the world-limit settings from %srcObject to %dstObject.
Optionally scale the bounds by %scaleFactor.
Optionally set a specified new mode.
Optionally specify a new callback.
*/
function copyWorldLimit( %srcObj, %dstObj, %scaleFactor , %newMode , %newCallback )
{
    %limit = %srcObj.getWorldLimit();

    // use scale of 1.0 if scale not specified
    %limitScale = ("" $= %scaleFactor ) ? 1.0 : %scaleFactor;

    // Use src limit mode if not specified
    %limitMode = ("" $= %newMode ) ? %srcObj.getWorldLimitMode() : %newMode;
    
    // use src limit callback if not specified
    %limitCallback = ("" $= %newCallback ) ? %srcObj.getWorldLimitCallback() : %newCallback;

    %limitUL = getWords( %limit , 1 , 2 );
    %limitLR = getWords( %limit , 3 , 4 );
    
    %limitBounds = t2DVectorScale( %limitUL , %limitScale ) SPC t2DVectorScale( %limitLR , %limitScale );

    %dstObj.setWorldLimit( %limitMode , %limitBounds , %limitCallback );
}

/*
Description: Get the current world limit mode for this object.
*/
function t2dSceneObject::getWorldLimitMode(%this)
{
   %worldLimit = %this.getWorldLimit();
   return getWord(%worldLimit, 0);
}

/*
Description: Set the current world limit mode for this object.
*/
function t2dSceneObject::setWorldLimitMode(%this, %mode)
{
   %worldLimit = %this.getWorldLimit();
   %this.setWorldLimit(%mode, %this.getWorldLimitMinX(), %this.getWorldLimitMinY(), %this.getWorldLimitMaxX(), %this.getWorldLimitMaxY(), %this.getWorldLimitCallback());
}

/*
Description: Get the current world limit min-X bound for this object.
*/
function t2dSceneObject::getWorldLimitMinX(%this)
{
   %worldLimit = %this.getWorldLimit();
   return getWord(%worldLimit, 1);
}

/*
Description: Set the current world limit min-X bound for this object.
*/
function t2dSceneObject::setWorldLimitMinX(%this, %val)
{
   %worldLimit = %this.getWorldLimit();
   %this.setWorldLimit(%this.getWorldLimitMode(), %val, %this.getWorldLimitMinY(), %this.getWorldLimitMaxX(), %this.getWorldLimitMaxY(), %this.getWorldLimitCallback());
}

/*
Description: Get the current world limit min-Y bound for this object.
*/
function t2dSceneObject::getWorldLimitMinY(%this)
{
   %worldLimit = %this.getWorldLimit();
   return getWord(%worldLimit, 2);
}

/*
Description: Set the current world limit min-Y bound for this object.
*/
function t2dSceneObject::setWorldLimitMinY(%this, %val)
{
   %worldLimit = %this.getWorldLimit();
   %this.setWorldLimit(%this.getWorldLimitMode(), %this.getWorldLimitMinX(), %val, %this.getWorldLimitMaxX(), %this.getWorldLimitMaxY(), %this.getWorldLimitCallback());
}

/*
Description: Get the current world limit max-X bound for this object.
*/
function t2dSceneObject::getWorldLimitMaxX(%this)
{
   %worldLimit = %this.getWorldLimit();
   return getWord(%worldLimit, 3);
}

/*
Description: Set the current world limit max-X bound for this object.
*/
function t2dSceneObject::setWorldLimitMaxX(%this, %val)
{
   %worldLimit = %this.getWorldLimit();
   %this.setWorldLimit(%this.getWorldLimitMode(), %this.getWorldLimitMinX(), %this.getWorldLimitMinY(), %val, %this.getWorldLimitMaxY(), %this.getWorldLimitCallback());
}

/*
Description: Get the current world limit max-Y bound for this object.
*/
function t2dSceneObject::getWorldLimitMaxY(%this)
{
   %worldLimit = %this.getWorldLimit();
   return getWord(%worldLimit, 4);
}

/*
Description: set the current world limit max-Y bound for this object.
*/
function t2dSceneObject::setWorldLimitMaxY(%this, %val)
{
   %worldLimit = %this.getWorldLimit();
   %this.setWorldLimit(%this.getWorldLimitMode(), %this.getWorldLimitMinX(), %this.getWorldLimitMinY(), %this.getWorldLimitMaxX(), %val, %this.getWorldLimitCallback());
}

/*
Description: Get the current world limit callback for this object.
*/
function t2dSceneObject::getWorldLimitCallback(%this)
{
   %worldLimit = %this.getWorldLimit();
   return getWord(%worldLimit, 5);
}

/*
Description: Set the current world limit callback for this object.
*/
function t2dSceneObject::setWorldLimitCallback(%this, %callback)
{
   %worldLimit = %this.getWorldLimit();
   %this.setWorldLimit(%this.getWorldLimitMode(), %this.getWorldLimitMinX(), %this.getWorldLimitMinY(), %this.getWorldLimitMaxX(), %this.getWorldLimitMaxY(), %callback);
}