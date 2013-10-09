//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_03SceneCamera_Cameras_mountCameraToObject) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "03 - Scene & Camera";
      description = "Mount the camera to this object and configure camera interpolation.";
      details_atomName = "mountCameraToObject";
      details_category = "03 - Scene & Camera";
      details_eventAction = "full";
      details_subCategory = "Cameras";
      friendlyName = "Mount Camera To Object";
      segmentbehaviorFields = "5";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"interpMode\", \"Camera interpolation mode. (01 - causes slow start/stop.) \", \"enum\" , \"0\", \"0\" TAB \"1\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"mountOffset\", \"Camera mounting offset.\" , \"point2f\" , \"0.0 0.0\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"mountForce\", \"Mount tracking strength. (0 - Tracking is rigid; >0 - Tracking increases slow-to-fast)\" , \"float\" , \"0.0\");";
      segmentbehaviorFields_3 = "   %behavior.addBehaviorField( \"sendToMount\", \"Send camera instantly to mount point.\" , \"bool\" , \"0\");";
      segmentbehaviorFields_4 = "   %behavior.addBehaviorField( \"mountingDelay\", \"Delay initial mount by this many milliseconds.\" , \"integer\" , \"0\");";
      segmentonAddToScene = "3";
      segmentonAddToScene_0 = "   %owner = %this.owner;";
      segmentonAddToScene_1 = "   sceneWindow2d.schedule(%this.mountingDelay, setCameraInterpolationMode, %this.interpMode );";
      segmentonAddToScene_2 = "   sceneWindow2d.schedule(%this.mountingDelay, mount, %owner , %this.mountOffset, %this.mountForce , %this.sendToMount );";
      segments = "behaviorFields\tonAddToScene";
};
//--- OBJECT WRITE END ---
