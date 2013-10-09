//--- OBJECT WRITE BEGIN ---
new ScriptObject(event_BehaviorCallbacks_Game_onWorldLimit) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Game Event ->";
      description = "When this object hits/crosses it\'s world limit";
      details_atomName = "onWorldLimit";
      details_category = "Behavior Callbacks";
      details_eventAction = "event";
      details_subCategory = "Game";
      friendlyName = "onWorldLimit() ->";
      segmentonAddToScene = "2";
      segmentonAddToScene_0 = "   %this.owner.setUseMouseEvents(true);";
      segmentonAddToScene_1 = "   sceneWindow2D.setUseObjectMouseEvents(1);";
      segmentonWorldLimit = "5";
      segmentonWorldLimit_0 = "   //%limitMode - The world limit response mode set on the object.";
      segmentonWorldLimit_1 = "   //%limit - This is either \"Left\", \"Right\", \"Top\", or \"Bottom\", depending on the side of the world limit that was hit.   %this.owner.last[onWorldLimit,dstObj]   = %dstObj;";
      segmentonWorldLimit_2 = "   %this.owner.last[onWorldLimit,limitMode]  = %limitMode;";
      segmentonWorldLimit_3 = "   %this.owner.last[onWorldLimit,limit]      = %limit;";
      segmentonWorldLimit_4 = "   %this.executeAction();";
      segments = "onAddToScene\tonWorldLimit";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(event_BehaviorCallbacks_Game_onUpdate) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Game Event ->";
      description = "When this object is updated (every tick)";
      details_atomName = "onUpdate";
      details_category = "Behavior Callbacks";
      details_eventAction = "event";
      details_subCategory = "Game";
      friendlyName = "onUpdate() ->";
      segmentonAddToScene = "2";
      segmentonAddToScene_0 = "   %this.owner.setUseMouseEvents(true);";
      segmentonAddToScene_1 = "   sceneWindow2D.setUseObjectMouseEvents(1);";
      segmentonUpdate = "1";
      segmentonUpdate_0 = "   %this.executeAction();";
      segments = "onAddToScene\tonUpdate";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(event_BehaviorCallbacks_Game_onTimer) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Game Event ->";
      description = "When this object\'s timer event occurs";
      details_atomName = "onTimer";
      details_category = "Behavior Callbacks";
      details_eventAction = "event";
      details_subCategory = "Game";
      friendlyName = "onTimer() ->";
      segmentonAddToScene = "2";
      segmentonAddToScene_0 = "   %this.owner.setUseMouseEvents(true);";
      segmentonAddToScene_1 = "   sceneWindow2D.setUseObjectMouseEvents(1);";
      segmentonTimer = "1";
      segmentonTimer_0 = "   %this.executeAction();";
      segments = "onAddToScene\tonTimer";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(event_BehaviorCallbacks_Game_onRotationTarget) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Game Event ->";
      description = "When the object completes a rotateTo() (with callback == true) action";
      details_atomName = "onRotationTarget";
      details_category = "Behavior Callbacks";
      details_eventAction = "event";
      details_subCategory = "Game";
      friendlyName = "onRotationTarget() ->";
      segmentonAddToScene = "2";
      segmentonAddToScene_0 = "   %this.owner.setUseMouseEvents(true);";
      segmentonAddToScene_1 = "   sceneWindow2D.setUseObjectMouseEvents(1);";
      segmentonRotationTarget = "1";
      segmentonRotationTarget_0 = "   %this.executeAction();";
      segments = "onAddToScene\tonRotationTarget";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(event_BehaviorCallbacks_Game_onPositionTarget) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Game Event ->";
      description = "When the object completes a moveTo() (with callback == true) action";
      details_atomName = "onPositionTarget";
      details_category = "Behavior Callbacks";
      details_eventAction = "event";
      details_subCategory = "Game";
      friendlyName = "onPositionTarget() ->";
      segmentonAddToScene = "2";
      segmentonAddToScene_0 = "   %this.owner.setUseMouseEvents(true);";
      segmentonAddToScene_1 = "   sceneWindow2D.setUseObjectMouseEvents(1);";
      segmentonPositionTarget = "1";
      segmentonPositionTarget_0 = "   %this.executeAction();";
      segments = "onAddToScene\tonPositionTarget";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(event_BehaviorCallbacks_Game_onCollision) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Game Event ->";
      description = "When this object collides with another object";
      details_atomName = "onCollision";
      details_category = "Behavior Callbacks";
      details_eventAction = "event";
      details_subCategory = "Game";
      friendlyName = "onCollision() ->";
      segmentonAddToScene = "2";
      segmentonAddToScene_0 = "   %this.owner.setUseMouseEvents(true);";
      segmentonAddToScene_1 = "   sceneWindow2D.setUseObjectMouseEvents(1);";
      segmentonCollision = "8";
      segmentonCollision_0 = "   //%dstObj - The object that is being collided with.";
      segmentonCollision_1 = "   //%srcRef - Custom information set by the source object. Only used by t2dTileLayer to pass the logical tile position of the tile that is colliding.";
      segmentonCollision_2 = "   //%dstRef - Custom information set by the destination object. Only used by t2dTileLayer to pass the logical tile position of the tile that is collided with.";
      segmentonCollision_3 = "   //%time - The time since the previous tick when the collision happened.";
      segmentonCollision_4 = "   //%normal - The normal vector of the collision.";
      segmentonCollision_5 = "   //%contacts - The number of contacts in the collision.";
      segmentonCollision_6 = "   //%points - The list of contact points.";
      segmentonCollision_7 = "   %this.executeAction();";
      segments = "onAddToScene\tonCollision";
};
//--- OBJECT WRITE END ---
