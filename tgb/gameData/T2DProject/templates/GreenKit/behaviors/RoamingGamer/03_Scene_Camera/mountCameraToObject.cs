//EFM - assumes name of scenewindow is default (sceneWindow2d)
if (!isObject(mountCameraToObject))
{
   %behavior = new BehaviorTemplate(mountCameraToObject)
   {
      friendlyName = "Mount Camera To Object";
      behaviorType = "03 - Scene and Camera";
      description  = "Mount the camera to this object and configure camera interpolation.";
   };
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);

   %behavior.addBehaviorField( "interpMode", "Camera interpolation mode. (01 - causes slow start/stop.) ",
                               "enum" , "0", "0" TAB "1");

   %behavior.addBehaviorField( "mountOffset", "Camera mounting offset." , "point2f" , "0.0 0.0");
   %behavior.addBehaviorField( "mountForce", "Mount tracking strength. (0 - Tracking is rigid; >0 - Tracking increases slow-to-fast)" , "float" , "0.0");
   %behavior.addBehaviorField( "sendToMount", "Send camera instantly to mount point." , "bool" , "0");
   %behavior.addBehaviorField( "mountingDelay", "Delay initial mount by this many milliseconds." , "integer" , "0");
}

function mountCameraToObject::onAddToScene(%this, %scenegraph) 
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("isSplashScreen::onAddToScene()");
   
   %owner = %this.owner;

   if(%this.debugMode) echo("isSplashScreen::onAddToScene() => playerMounted");

   sceneWindow2d.schedule(%this.mountingDelay, setCameraInterpolationMode, %this.interpMode );
   sceneWindow2d.schedule(%this.mountingDelay, mount, %owner , %this.mountOffset, %this.mountForce , %this.sendToMount );
}
