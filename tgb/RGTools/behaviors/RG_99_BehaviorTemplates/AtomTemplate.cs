//registerAtom( event,  "Category", "SubCategory", "AtomName" );
//registerAtom( action, "Category", "SubCategory", "AtomName" );
//registerAtom( full,   "Category", "SubCategory", "BehaviorName" );
// Note: One of the above lines must be used as the first line this file.

//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------
if (!isObject(AtomTemplate))
{
   // 1. Create a new behavior script object.
   %behavior = new BehaviorTemplate(AtomTemplate)
   {
      friendlyName = "Atom Template";
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
   
   // Following are field types added in resources TSTK/TGB/editors/fieldTypes.ed.cs
   %behavior.addBehaviorField( "A_Point3F", "A Point3F", "point3f", "1.0 2.0 3.0");
   %behavior.addBehaviorField( "A_ManagedDB", "A List of Managed DBs", "managedDB", "");
   %behavior.addBehaviorField( "A_AnimationDB", "A List of Animation DBs", "AnimationDB", "");
   //EFM Not currently working properly %behavior.addBehaviorField( "A_t2dImageMapDatablock"  , "A List of t2dImageMap DBs"   , "t2dImageMapDatablock" , "");

   %behavior.addBehaviorField( "A_Bitmask", "This is for editing 32-bit bitmask lists.", "bitmask", "0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31");   

   %behavior.addBehaviorField( "A_Function", "echo \"hello world\"", "functionButton", "", "echo(\"hello world\");");   
}

////
// Initialization Events
////
function AtomTemplate::onBehaviorAdd(%this) 
{
}//onBehaviorAdd

function AtomTemplate::onBehaviorRemove(%this) 
{
}//onBehaviorRemove

function AtomTemplate::onLevelLoaded(%this, %scenegraph) 
{
}//onLevelLoaded

function AtomTemplate::onLevelEnded(%this, %scenegraph) 
{
}//onLevelEnded

function AtomTemplate::onAddToScene(%this, %scenegraph) 
{
}//onAddToScene

function AtomTemplate::onRemoveFromScene(%this, %scenegraph) 
{
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

function AtomTemplate::onMouseMove(%this, %modifier, %worldPosition, %clicks) 
{
}//onMouseMove

function AtomTemplate::onMouseEnter(%this, %modifier, %worldPosition, %clicks) 
{
}//onMouseEnter

function AtomTemplate::onMouseLeave(%this, %modifier, %worldPosition, %clicks) 
{
}//onMouseLeave

function AtomTemplate::onMouseDown(%this, %modifier, %worldPosition, %clicks) 
{
}//onMouseDown

function AtomTemplate::onMouseDragged(%this, %modifier, %worldPosition, %clicks) 
{
}//onMouseDragged

function AtomTemplate::onMouseUp(%this, %modifier, %worldPosition, %clicks) 
{
}//onMouseUp

function AtomTemplate::onRightMouseDown(%this, %modifier, %worldPosition, %clicks) 
{
}//onRightMouseDown

function AtomTemplate::onRightMouseDragged(%this, %modifier, %worldPosition, %clicks) 
{
}//onRightMouseDragged

function AtomTemplate::onRightMouseUp(%this, %modifier, %worldPosition, %clicks) 
{
}//onRightMouseUp


////
// Game Events
////
function AtomTemplate::onCollision(%this, %srcObj, %dstObj, %srcRef, %dstRef, %time, %normal, %contacts, %points)
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
}//onCollision

function AtomTemplate::onWorldLimit( %this, %limitMode, %limit)
{
   //%limitMode - The world limit response mode set on the object.
   //%limit - This is either "Left", "Right", "Top", or "Bottom", depending on 
   //         the side of the world limit that was hit.
}//onWorldLimit

function AtomTemplate::onUpdate(%this)
{
   //This is called every tick (32 milliseconds). 
}//onUpdate

function AtomTemplate::onPositionTarget(%this)
{
}//onPositionTarget

function AtomTemplate::onRotationTarget(%this)
{
}//onRotationTarget

function AtomTemplate::onTimer(%this)
{
}//onTimer

////
// Animation Events
////
function AtomTemplate::onAnimationStart(%this)
{
}//onAnimationStart

function AtomTemplate::onAnimationEnd(%this)
{
}//onAnimationEnd

function AtomTemplate::onFrameChange(%this, %frame)
{
}//onFrameChange

////
// Trigger Events
////
function AtomTemplate::onEnter(%this, %object)
{
}//onEnter

function AtomTemplate::onStay(%this, %object)
{
}//onStay

function AtomTemplate::onLeave(%this, %object)
{
}//onLeave
