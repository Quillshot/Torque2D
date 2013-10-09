//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_10Weapons_InputFiring_rightMouse_Fire) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "10 - Weapons";
      description = "Face the mouse when it is clicked.";
      details_atomName = "rightMouse_Fire";
      details_category = "10 - Weapons";
      details_eventAction = "full";
      details_subCategory = "Input Firing";
      friendlyName = "onRightMouseClicked() -> Fire";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"enable\", \"Enable behavior.\", bool, true );   ";
      segmentonAddToScene = "3";
      segmentonAddToScene_0 = "   %this.owner.setUseMouseEvents(true);";
      segmentonAddToScene_1 = "   %this.owner.setMouseLocked(true);";
      segmentonAddToScene_2 = "   sceneWindow2D.setUseObjectMouseEvents(1);";
      segmentonRightMouseDown = "2";
      segmentonRightMouseDown_0 = "   if (!%this.enable) return;";
      segmentonRightMouseDown_1 = "   %this.broadcastMethod( onFire, 1 );";
      segmentonRightMouseUp = "2";
      segmentonRightMouseUp_0 = "   if (!%this.enable) return;";
      segmentonRightMouseUp_1 = "   %this.broadcastMethod( onFire, 0 );";
      segments = "behaviorFields\tonAddToScene\tonRightMouseDown\tonRightMouseUp";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_10Weapons_InputFiring_leftMouse_Fire) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "10 - Weapons";
      description = "Face the mouse when it is clicked.";
      details_atomName = "leftMouse_Fire";
      details_category = "10 - Weapons";
      details_eventAction = "full";
      details_subCategory = "Input Firing";
      friendlyName = "onMouseClicked() -> Fire";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"enable\", \"Enable behavior.\", bool, true );   ";
      segmentonAddToScene = "3";
      segmentonAddToScene_0 = "   %this.owner.setUseMouseEvents(true);";
      segmentonAddToScene_1 = "   %this.owner.setMouseLocked(true);";
      segmentonAddToScene_2 = "   sceneWindow2D.setUseObjectMouseEvents(1);";
      segmentonMouseDown = "2";
      segmentonMouseDown_0 = "   if (!%this.enable) return;";
      segmentonMouseDown_1 = "   %this.broadcastMethod( onFire, 1 );";
      segmentonMouseUp = "2";
      segmentonMouseUp_0 = "   if (!%this.enable) return;";
      segmentonMouseUp_1 = "   %this.broadcastMethod( onFire, 0 );";
      segments = "behaviorFields\tonAddToScene\tonMouseDown\tonMouseUp";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_10Weapons_InputFiring_keyButton_Fire) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "10 - Weapons";
      description = "Calls onFire() behavior method for all behaviors attached to this object.";
      details_atomName = "keyButton_Fire";
      details_category = "10 - Weapons";
      details_eventAction = "full";
      details_subCategory = "Input Firing";
      friendlyName = "onKeyPress() -> Fire (multi)";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"fireKey\", \"Rotate left\",  keybind, \"Keyboard space\" );";
      segmentkeepAll = "6";
      segmentkeepAll_0 = "function keyButton_Fire::onKeyButtonFire( %this , %val )";
      segmentkeepAll_1 = "{ ";
      segmentkeepAll_2 = "   if(!%this.enable) return;  ";
      segmentkeepAll_3 = "   //error(\"keyButton_Fire::onKeyButtonFire( \", %val , \" ) \" );   ";
      segmentkeepAll_4 = "   %this.broadcastMethod(onFire, %val );";
      segmentkeepAll_5 = "}";
      segmentonAddToScene = "1";
      segmentonAddToScene_0 = "   moveMap.bindMulti( getWord( %this.fireKey , 0 ),  getWord( %this.fireKey , 1 ),  %this, \"onKeyButtonFire\" );";
      segments = "behaviorFields\tonAddToScene\tkeepAll";
};
//--- OBJECT WRITE END ---
