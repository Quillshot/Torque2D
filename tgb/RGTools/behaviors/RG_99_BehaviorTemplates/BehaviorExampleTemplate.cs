//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------
if (!isObject(BehaviorExampleTemplate))
{
   // 1. Create a new behavior script object.
   %behavior = new BehaviorTemplate(BehaviorExampleTemplate)
   {
      friendlyName = "Behavior Template";
      behaviorType = "99 - Templates and Examples";
      description  = "Demonstrates all standard field types and any new SSK field types.";
   };

   //
   // 2. Provide class type validation(s). (optional)
   //
   //%behavior.addValidObjectClass("t2dSceneObject");

   //
   // 3. Add dependencies. (optional)
   //
   //%behavior.addDependency("isSSKObject", "true");
   //%behavior.addDependency("superClass", "player");

   //
   // 4. Add any needed fields.
   //
   // addBehaviorField( fieldName, desc, type, [ defaultValue, userData] )
   //
   // KEEP
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);  
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);
   
   // Add additional fields below this line   
   %behavior.addBehaviorField( "A_Default", "Default Field", "default", "a free form text field" );
   %behavior.addBehaviorField( "A_Bool", "A Boolean", "bool", "0");
   %behavior.addBehaviorField( "A_Color", "A Color", "color", "0.1  0.2  0.3 0.5");
   %behavior.addBehaviorField( "A_ENUM", "A Enum", "enum", "this", "this"TAB"is"TAB"a"TAB"list");
   %behavior.addBehaviorField( "A_Float", "A Float", "float", "999.99");
   %behavior.addBehaviorField( "A_Int", "A Integer", "int", "100");
   %behavior.addBehaviorField( "A_Keybind", "A Keybind", "keybind", "Keyboard A");
   %behavior.addBehaviorField( "A_Object", "A Object", "object", "t2dSceneObject");
   %behavior.addBehaviorField( "A_Point2F", "A Point2F", "point2f", "1.0 -1.0");
      
   // Following two not often used 
   %behavior.addBehaviorField( "A_polygon", "A Polygon", "polygon" );
   %behavior.addBehaviorField( "A_localpointlist", "A Local Point List", "localpointlist");
   
   //  Following types REQUIRE the "Torque Script ToolKit" (TSTK)
   //  to function properly.
   //  
   //  Visit: http://roaminggamer.com/ for additional help.
   //
   // Following are field types added in resources TSTK/TGB/editors/fieldTypes.ed.cs
   %behavior.addBehaviorField( "A_Point3F", "A Point3F", "point3f", "1.0 2.0 3.0");
   %behavior.addBehaviorField( "A_ManagedDB", "A List of Managed DBs", "managedDB", "");
   %behavior.addBehaviorField( "A_AnimationDB", "A List of Animation DBs", "AnimationDB", "");
   //EFM Not currently working properly %behavior.addBehaviorField( "A_t2dImageMapDatablock"  , "A List of t2dImageMap DBs"   , "t2dImageMapDatablock" , "");
   %behavior.addBehaviorField( "A_Bitmask", "This is for editing 32-bit bitmask lists.", "bitmask", "0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31");   
   %behavior.addBehaviorField( "A_FunctionButton", "echo \"hello world\"", "functionButton", "", "echo(\"hello world\");");   
}

////
// Initialization Events
////
function BehaviorExampleTemplate::onBehaviorAdd(%this) 
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onBehaviorAdd( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onBehaviorAdd

function BehaviorExampleTemplate::onBehaviorRemove(%this) 
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onBehaviorRemove( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onBehaviorRemove

function BehaviorExampleTemplate::onLevelLoaded(%this, %scenegraph) 
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onLevelLoaded( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onLevelLoaded

function BehaviorExampleTemplate::onLevelEnded(%this, %scenegraph) 
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onLevelEnded( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onLevelEnded

function BehaviorExampleTemplate::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onAddToScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onAddToScene

function BehaviorExampleTemplate::onRemoveFromScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onRemoveFromScene( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onRemoveFromScene


////
// Mouse Events
////
// For any of these events to be triggered, the object must have useMouseEvents 
// enabled by calling setUseMouseEvents(true). 
// Also, objects can call setMouseLocked(true) to lock the mouse with the object. 
// This allows the object to receive all mouse event callbacks regardless of 
// whether or not the mouse is within the bounding box of the object. 
//
//  %modifier - A bitmask specifying any modifier keys that are pressed.
//   Bit 0: Left Shift
//   Bit 1: Right Shift
//   Bit 2: Left Control
//   Bit 3: Right Control
//   Bit 4: Left Alt (Windows) or Command (Mac)
//   Bit 5: Right Alt (Windows) or Command (Mac)
//   Bit 6: Left Option (Mac)
//   Bit 7: Right Option (Mac)
// %worldPosition - The current position of the mouse.
// %clicks - The number of times the mouse has been clicked in the same spot in a short amount of time.

function BehaviorExampleTemplate::onMouseMove(%this, %modifier, %worldPosition, %clicks) 
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onMouseMove( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onMouseMove

function BehaviorExampleTemplate::onMouseEnter(%this, %modifier, %worldPosition, %clicks) 
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onMouseEnter( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onMouseEnter

function BehaviorExampleTemplate::onMouseLeave(%this, %modifier, %worldPosition, %clicks) 
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onMouseLeave( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onMouseLeave

function BehaviorExampleTemplate::onMouseDown(%this, %modifier, %worldPosition, %clicks) 
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onMouseDown( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onMouseDown

function BehaviorExampleTemplate::onMouseDragged(%this, %modifier, %worldPosition, %clicks) 
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onMouseDragged( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onMouseDragged

function BehaviorExampleTemplate::onMouseUp(%this, %modifier, %worldPosition, %clicks) 
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onMouseUp( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onMouseUp

function BehaviorExampleTemplate::onRightMouseDown(%this, %modifier, %worldPosition, %clicks) 
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onRightMouseDown( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onRightMouseDown

function BehaviorExampleTemplate::onRightMouseDragged(%this, %modifier, %worldPosition, %clicks) 
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onRightMouseDragged( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onRightMouseDragged

function BehaviorExampleTemplate::onRightMouseUp(%this, %modifier, %worldPosition, %clicks) 
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onRightMouseUp( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onRightMouseUp


////
// Game Events
////
function BehaviorExampleTemplate::onCollision(%this, %srcObj, %dstObj, %srcRef, %dstRef, %time, %normal, %contacts, %points)
{
   //%srcObj - This object, that's colliding.
   //%dstObj - The object that is being collided with.
   //%srcRef - Custom information set by the source object. Only used by t2dTileLayer 
   //to pass the logical tile position of the tile that is colliding.
   //%dstRef - Custom information set by the destination object. Only used by 
   //          t2dTileLayer to pass the logical tile position of the tile that 
   //          is collided with.
   //%time - The time since the previous tick when the collision happened.
   //%normal - The normal vector of the collision.
   //%contacts - The number of contacts in the collision.
   //%points - The list of contact points.

   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onCollision( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onCollision

function BehaviorExampleTemplate::onWorldLimit( %this, %limitMode, %limit)
{
   //%limitMode - The world limit response mode set on the object.
   //%limit - This is either "Left", "Right", "Top", or "Bottom", depending on 
   //         the side of the world limit that was hit.

   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onWorldLimit( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onWorldLimit

function BehaviorExampleTemplate::onUpdate(%this)
{
   //This is called every tick (32 milliseconds). 

   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onUpdate( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onUpdate

function BehaviorExampleTemplate::onPositionTarget(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onPositionTarget( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onPositionTarget

function BehaviorExampleTemplate::onRotationTarget(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onRotationTarget( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onRotationTarget

function BehaviorExampleTemplate::onTimer(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onTimer( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onTimer

////
// Animation Events
////
function BehaviorExampleTemplate::onAnimationStart(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onAnimationStart( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onAnimationStart

function BehaviorExampleTemplate::onAnimationEnd(%this)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onAnimationEnd( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onAnimationEnd

function BehaviorExampleTemplate::onFrameChange(%this, %frame)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onFrameChange( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onFrameChange

////
// Trigger Events
////
function BehaviorExampleTemplate::onEnter(%this, %object)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onEnter( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onEnter

function BehaviorExampleTemplate::onStay(%this, %object)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onStay( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onStay

function BehaviorExampleTemplate::onLeave(%this, %object)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("BehaviorExampleTemplate::onLeave( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
}//onLeave
