//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_03SceneCamera_WorldLimit_onWorldLimitWrap) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "03 - Scene & Camera";
      description = "Wrap when world limit encountered.";
      details_atomName = "onWorldLimitWrap";
      details_category = "03 - Scene & Camera";
      details_eventAction = "full";
      details_subCategory = "World Limit";
      friendlyName = "Wrap on World Limit";
      segmentonAddToScene = "2";
      segmentonAddToScene_0 = "   %this.owner.worldLimitMode = \"NULL\";";
      segmentonAddToScene_1 = "   %this.owner.worldLimitCallback = true;";
      segmentonBehaviorAdd = "2";
      segmentonBehaviorAdd_0 = "   %this.owner.worldLimitMode = \"NULL\";";
      segmentonBehaviorAdd_1 = "   %this.owner.worldLimitCallback = true;";
      segmentonWorldLimit = "15";
      segmentonWorldLimit_0 = "   switch$ (%limit)";
      segmentonWorldLimit_1 = "   {";
      segmentonWorldLimit_10 = "            %this.owner.setPositionY(getWord(%this.owner.getWorldLimit(), 4) - (%this.owner.getHeight() / 2));";
      segmentonWorldLimit_11 = "      case \"bottom\":";
      segmentonWorldLimit_12 = "         if (%this.owner.getLinearVelocityY() > 0)";
      segmentonWorldLimit_13 = "            %this.owner.setPositionY(getWord(%this.owner.getWorldLimit(), 2) + (%this.owner.getHeight() / 2));";
      segmentonWorldLimit_14 = "   }";
      segmentonWorldLimit_2 = "      case \"left\":";
      segmentonWorldLimit_3 = "         if (%this.owner.getLinearVelocityX() < 0)";
      segmentonWorldLimit_4 = "            %this.owner.setPositionX(getWord(%this.owner.getWorldLimit(), 3) - (%this.owner.getWidth() / 2));";
      segmentonWorldLimit_5 = "      case \"right\":";
      segmentonWorldLimit_6 = "         if (%this.owner.getLinearVelocityX() > 0)";
      segmentonWorldLimit_7 = "            %this.owner.setPositionX(getWord(%this.owner.getWorldLimit(), 1) + (%this.owner.getWidth() / 2));";
      segmentonWorldLimit_8 = "      case \"top\":";
      segmentonWorldLimit_9 = "         if (%this.owner.getLinearVelocityY() < 0)";
      segments = "onBehaviorAdd\tonAddToScene\tonWorldLimit";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_03SceneCamera_WorldLimit_copyWorldLimitFromCamera) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "03 - Scene & Camera";
      description = "Copy camera area and use as world limit.";
      details_atomName = "copyWorldLimitFromCamera";
      details_category = "03 - Scene & Camera";
      details_eventAction = "full";
      details_subCategory = "World Limit";
      friendlyName = "Copy World Limit From Camera";
      segmentbehaviorFields = "4";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"WLMode\", \"World Limit Mode\", \"enum\", \"null\", \"off\\tclamp\\tnull\\tbounce\\tsticky\\tkill\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"Multiply_Area\", \"Multiply (initial) area by this.\", \"point2f\", \"1.0 1.0\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"Add_Margin\", \"Add this margin to the world limit extent.\", \"point2f\", \"0.0 0.0\");";
      segmentbehaviorFields_3 = "   %behavior.addBehaviorField(\"Add_Size\", \"Add object size to world limit bounds.\", bool, true);";
      segmentonAddToScene = "36";
      segmentonAddToScene_0 = "   if($LevelEditorActive) return;";
      segmentonAddToScene_1 = "   %area = sceneWindow2D.getCurrentCameraArea();";
      segmentonAddToScene_10 = "   %limitMin = t2dVectorMult( %limitMin, %this.Multiply_Area);";
      segmentonAddToScene_11 = "   %limitMax = t2dVectorMult( %limitMax, %this.Multiply_Area);";
      segmentonAddToScene_12 = "   ";
      segmentonAddToScene_13 = "   %limitMin = t2dVectorSub( %limitMin, %this.Add_Margin);";
      segmentonAddToScene_14 = "   %limitMax = t2dVectorAdd( %limitMax, %this.Add_Margin);";
      segmentonAddToScene_15 = "   ";
      segmentonAddToScene_16 = "   if( %this.Add_Size ) ";
      segmentonAddToScene_17 = "   {";
      segmentonAddToScene_18 = "      %size = %this.owner.getSize();";
      segmentonAddToScene_19 = "      %limitMin = t2dVectorSub( %limitMin, %size);";
      segmentonAddToScene_2 = "   %position = sceneWindow2D.getCurrentCameraPosition();";
      segmentonAddToScene_20 = "      %limitMax = t2dVectorAdd( %limitMax, %size);";
      segmentonAddToScene_21 = "   }";
      segmentonAddToScene_22 = "   ";
      segmentonAddToScene_23 = "   %this.owner.setWorldLimitMode( %this.WLMode );";
      segmentonAddToScene_24 = "   %this.owner.setWorldLimitMinX( getWord( %limitMin , 0 ) );";
      segmentonAddToScene_25 = "   %this.owner.setWorldLimitMinY( getWord( %limitMin , 1 ) );";
      segmentonAddToScene_26 = "   %this.owner.setWorldLimitMaxX( getWord( %limitMax , 0 ) );";
      segmentonAddToScene_27 = "   %this.owner.setWorldLimitMaxY( getWord( %limitMax , 1 ) );";
      segmentonAddToScene_28 = "   ";
      segmentonAddToScene_29 = "   %wrapBehavior = %this.owner.getBehavior( \"onWorldLimitWrap\" );";
      segmentonAddToScene_3 = "   error(%area);";
      segmentonAddToScene_30 = "   ";
      segmentonAddToScene_31 = "   // If the wrap behavior is present and enabled, force mode to \"NULL\"";
      segmentonAddToScene_32 = "   if(isObject(%wrapBehavior) && %wrapBehavior.enable)";
      segmentonAddToScene_33 = "   {";
      segmentonAddToScene_34 = "      %this.owner.setWorldLimitMode( \"NULL\" );";
      segmentonAddToScene_35 = "   }";
      segmentonAddToScene_4 = "   error(%position);";
      segmentonAddToScene_5 = "   ";
      segmentonAddToScene_6 = "   %limitMin = getWords( %area, 0, 1 );";
      segmentonAddToScene_7 = "   %limitMax = getWords( %area, 2, 3 );";
      segmentonAddToScene_8 = "   %limitMin = t2dVectorAdd( %limitMin, %position );";
      segmentonAddToScene_9 = "   %limitMax = t2dVectorAdd( %limitMax, %position );";
      segments = "behaviorFields\tonAddToScene";
};
//--- OBJECT WRITE END ---