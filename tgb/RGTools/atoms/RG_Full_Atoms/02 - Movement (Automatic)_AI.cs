//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_02MovementAutomatic_AI_limitedSeekerRGQC) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "02 - Movement (Automatic)";
      description = "Automatically rotate to face the nearest target and go after it. Target seeking can be limited by group, distance, and angle.";
      details_atomName = "limitedSeekerRGQC";
      details_category = "02 - Movement (Automatic)";
      details_eventAction = "full";
      details_subCategory = "AI";
      friendlyName = "Limited Seeker (RGQC)";
      segmentbehaviorFields = "15";
      segmentbehaviorFields_0 = "   %typeList = RGQC.getKnownTypes(); //addBehaviorField - trick so line is kept during parse";
      segmentbehaviorFields_1 = "   %firstType = getWord( %typeList , 0 ); //addBehaviorField - trick so line is kept during parse";
      segmentbehaviorFields_10 = "   %behavior.addBehaviorField(\"moveSpeed\", \"Speed to move at.\", \"float\", 25.0);      ";
      segmentbehaviorFields_11 = "   %behavior.addBehaviorField(\"seekPeriod\", \"Time (in milliseconds) between seek scans and course adjustments. (Minimum is 10.)\", \"integer\", 250);      ";
      segmentbehaviorFields_12 = "   %behavior.addBehaviorField(\"waitForTarget\", \"If true, this object won\'t start moving till it finds a target\", \"bool\", false);";
      segmentbehaviorFields_13 = "   %behavior.addBehaviorField( \"algorithm\", \"Algorithm for choosing a single target from many.\", \"enum\"    , \"nearest\", \"nearest\\tfurthest\\trandom\");";
      segmentbehaviorFields_14 = "   %behavior.addBehaviorField(\"canLose\", \"Target can be lost if it moves out of the aiming distance or angle.\", \"bool\", false);";
      segmentbehaviorFields_2 = "   %typelist = strreplace( %typelist, \" \", \"\\t\"); //addBehaviorField - trick so line is kept during parse";
      segmentbehaviorFields_3 = "   %typelist = strlwr(%typelist); //addBehaviorField - trick so line is kept during parse";
      segmentbehaviorFields_4 = "   %behavior.addBehaviorField( \"aimType\", \"Object type to aim at and seek.\", \"enum\", %firstType, %typeList);";
      segmentbehaviorFields_5 = "   %behavior.addBehaviorField( \"aimType\", \"Comma separated list of types this object aims at. (Requires RG Quick Config and overrides seekGroups below.)\", \"default\", \"\" );";
      segmentbehaviorFields_6 = "//EFM      %behavior.addBehaviorField( \"seekGroups\", \"Seek objects in these groups.\", \"bitmask\", \"0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31\");   ";
      segmentbehaviorFields_7 = "   %behavior.addBehaviorField(\"seekDistance\", \"Maximum distance at which targets can be detected.\", \"float\", 10000.0);   ";
      segmentbehaviorFields_8 = "   %behavior.addBehaviorField(\"seekFOV\", \"Maximum Field Of View (FOV) in which targets can be detected. [0,360]\", \"float\", 360.0);";
      segmentbehaviorFields_9 = "   %behavior.addBehaviorField(\"turnSpeed\", \"Speed to rotate at.\", \"float\", 90.0);";
      segmentkeepAll = "51";
      segmentkeepAll_0 = "function limitedSeekerRGQC::seek(%this) ";
      segmentkeepAll_1 = "{";
      segmentkeepAll_10 = "   {";
      segmentkeepAll_11 = "      if( ( %owner.inDistance( %this.target, %this.seekDistance) == false ) ||";
      segmentkeepAll_12 = "          ( %owner.inFOV( %this.target, %this.seekFOV) == false ) )";
      segmentkeepAll_13 = "      { ";
      segmentkeepAll_14 = "         %this.lastTarget = %this.target; ";
      segmentkeepAll_15 = "         %this.target = \"\";";
      segmentkeepAll_16 = "      }";
      segmentkeepAll_17 = "   }";
      segmentkeepAll_18 = "   ////";
      segmentkeepAll_19 = "   //   2. If we have no target, try to find one.";
      segmentkeepAll_2 = "   if(%this.debugMode) echo(\"limitedSeekerRGQC::seek( \", ((%this.getName() $= \"\") ? %this : %this.getName()) , \" ) @ \", getSimTime() );";
      segmentkeepAll_20 = "   ////";
      segmentkeepAll_21 = "   if( !isObject( %this.target ) )";
      segmentkeepAll_22 = "   {";
      segmentkeepAll_23 = "      switch$( %this.algorithm )";
      segmentkeepAll_24 = "      {";
      segmentkeepAll_25 = "      case \"nearest\":  %this.target = %owner.getNearestTarget( %this.seekFOV, %this.seekDistance, %this.seekGroups );";
      segmentkeepAll_26 = "      case \"furthest\": %this.target = %owner.getFurthestTarget( %this.seekFOV, %this.seekDistance, %this.seekGroups );";
      segmentkeepAll_27 = "      case \"random\":   %this.target = %owner.getRandomTarget( %this.seekFOV, %this.seekDistance, %this.seekGroups );";
      segmentkeepAll_28 = "      default:         %this.target = %owner.getNearestTarget( %this.seekFOV, %this.seekDistance, %this.seekGroups );";
      segmentkeepAll_29 = "      }";
      segmentkeepAll_3 = "   ";
      segmentkeepAll_30 = "   }";
      segmentkeepAll_31 = "         ";
      segmentkeepAll_32 = "   ////";
      segmentkeepAll_33 = "   //   3. Assuming we have a target, aim at it.   ";
      segmentkeepAll_34 = "   ////";
      segmentkeepAll_35 = "   if( isObject( %this.target ) )";
      segmentkeepAll_36 = "   {";
      segmentkeepAll_37 = "      %myPos         = %owner.getPosition();";
      segmentkeepAll_38 = "      %targetPos     = %this.target.getPosition();     ";
      segmentkeepAll_39 = "      %targetVec     = t2dVectorSub( %targetPos , %myPos );";
      segmentkeepAll_4 = "   %owner = %this.owner;";
      segmentkeepAll_40 = "      %targetAngle   = vectorToAngle( %targetVec );";
      segmentkeepAll_41 = "      //%this.owner.setRotation(%targetAngle);";
      segmentkeepAll_42 = "      %this.owner.rotateTo( %targetAngle, %this.turnSpeed, true );      ";
      segmentkeepAll_43 = "      %this.owner.setConstantForcePolar(%this.owner.getRotation(),10000,true);";
      segmentkeepAll_44 = "   }      ";
      segmentkeepAll_45 = "   if(%this.canLose && isObject( %this.lastTarget ))";
      segmentkeepAll_46 = "   {";
      segmentkeepAll_47 = "      %this.owner.setConstantForcePolar(%this.owner.getRotation(),10000,true); ";
      segmentkeepAll_48 = "   }";
      segmentkeepAll_49 = "   %this.schedule( %this.seekPeriod, seek  );";
      segmentkeepAll_5 = "    ";
      segmentkeepAll_50 = "}";
      segmentkeepAll_6 = "   ////";
      segmentkeepAll_7 = "   //   1. If we CAN lose a target, see if our target is in fact lost (out of distance and/or FOV)";
      segmentkeepAll_8 = "   ////";
      segmentkeepAll_9 = "   if(%this.canLose && isObject( %this.target ))";
      segmentonAddToScene = "27";
      segmentonAddToScene_0 = "   if(%this.seekPeriod < 10 ) %this.seekPeriod = 10;   ";
      segmentonAddToScene_1 = "   ";
      segmentonAddToScene_10 = "      %this.seekGroups = \"\";";
      segmentonAddToScene_11 = "      %types = strreplace(trim(%this.aimType),\",\", \" \");";
      segmentonAddToScene_12 = "      %typeCount = getWordCount( %types );";
      segmentonAddToScene_13 = "      for(%count=0; %count < %typeCount; %count++)";
      segmentonAddToScene_14 = "      {";
      segmentonAddToScene_15 = "         %type = getWord(%types,%count);";
      segmentonAddToScene_16 = "         %this.seekGroups = %this.seekGroups SPC RGQC.getGraphGroup( %type );";
      segmentonAddToScene_17 = "      }";
      segmentonAddToScene_18 = "      %this.seekGroups = trim(%this.seekGroups);";
      segmentonAddToScene_19 = "   }";
      segmentonAddToScene_2 = "   if(%this.seekFOV > 360) %this.seekFOV = 360;";
      segmentonAddToScene_20 = "   %this.seekGroupsMask = bits(%this.seekGroups);";
      segmentonAddToScene_21 = "   ";
      segmentonAddToScene_22 = "   if(!%this.waitForTarget) ";
      segmentonAddToScene_23 = "   {";
      segmentonAddToScene_24 = "      %this.owner.setConstantForcePolar(%this.owner.getRotation(),10000,true);";
      segmentonAddToScene_25 = "   }";
      segmentonAddToScene_26 = "   %this.seek( );";
      segmentonAddToScene_3 = "   if(%this.seekFOV < 0) %this.seekFOV = 0;   ";
      segmentonAddToScene_4 = "   ";
      segmentonAddToScene_5 = "   %this.owner.setMaxLinearVelocity( %this.moveSpeed );";
      segmentonAddToScene_6 = "   ";
      segmentonAddToScene_7 = "   // Allow use of named types to override bit selection   ";
      segmentonAddToScene_8 = "   if(%this.aimType !$= \"\")";
      segmentonAddToScene_9 = "   {";
      segments = "behaviorFields\tonAddToScene\tkeepAll";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_02MovementAutomatic_AI_aimOverTimeRGQC) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "02 - Movement (Automatic)";
      description = "Automatically rotate to face the nearest object in a specified group. (Rotation takes time.)";
      details_atomName = "aimOverTimeRGQC";
      details_category = "02 - Movement (Automatic)";
      details_eventAction = "full";
      details_subCategory = "AI";
      friendlyName = "Aim Over Time (RGQC)";
      segmentbehaviorFields = "12";
      segmentbehaviorFields_0 = "   %typeList = RGQC.getKnownTypes(); //addBehaviorField - trick so line is kept during parse";
      segmentbehaviorFields_1 = "   %firstType = getWord( %typeList , 0 ); //addBehaviorField - trick so line is kept during parse";
      segmentbehaviorFields_10 = "   %behavior.addBehaviorField( \"algorithm\", \"Algorithm for choosing a single target from many.\", \"enum\"    , \"nearest\", \"nearest\\tfurthest\\trandom\");";
      segmentbehaviorFields_11 = "   %behavior.addBehaviorField(\"canLose\", \"Target can be lost if it moves out of the aiming distance or angle.\", \"bool\", false);";
      segmentbehaviorFields_2 = "   %typelist = strreplace( %typelist, \" \", \"\\t\"); //addBehaviorField - trick so line is kept during parse";
      segmentbehaviorFields_3 = "   %typelist = strlwr(%typelist); //addBehaviorField - trick so line is kept during parse";
      segmentbehaviorFields_4 = "   %behavior.addBehaviorField( \"aimType\", \"Object type to aim at.\", \"enum\", %firstType, %typeList);";
      segmentbehaviorFields_5 = "//EFM   %behavior.addBehaviorField( \"aimGroups\", \"Groups to aim at.\", \"bitmask\", \"0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31\");   ";
      segmentbehaviorFields_6 = "   %behavior.addBehaviorField(\"maxDistance\", \"Maximum distance at which a target can be detected.\", \"float\", 25.0);";
      segmentbehaviorFields_7 = "   %behavior.addBehaviorField(\"maxFOV\", \"Maximum field-of-view (FOV) to seek within.\", \"float\", 360.0);";
      segmentbehaviorFields_8 = "   %behavior.addBehaviorField(\"turnRate\", \"Turn speed in degrees-per-second.\", \"float\", 90.0);";
      segmentbehaviorFields_9 = "   %behavior.addBehaviorField(\"updateSpeed\", \"Time between aim updates (lower values are faster and smoother looking).\", \"integer\", 32);";
      segmentkeepAll = "44";
      segmentkeepAll_0 = "function aimOverTimeRGQC::aim(%this) ";
      segmentkeepAll_1 = "{";
      segmentkeepAll_10 = "      if( ( %owner.inDistance( %this.target, %this.maxDistance) == false ) ||";
      segmentkeepAll_11 = "          ( %owner.inFOV( %this.target, %this.maxFOV) == false ) )";
      segmentkeepAll_12 = "      { ";
      segmentkeepAll_13 = "            %this.target = \"\";";
      segmentkeepAll_14 = "      }";
      segmentkeepAll_15 = "   }";
      segmentkeepAll_16 = "   ////";
      segmentkeepAll_17 = "   //   2. If we have no target, try to find one.";
      segmentkeepAll_18 = "   ////";
      segmentkeepAll_19 = "   if( !isObject( %this.target ) )";
      segmentkeepAll_2 = "   if(%this.debugMode) echo(\"aimOverTimeRGQC::aim( \", ((%this.getName() $= \"\") ? %this : %this.getName()) , \" ) @ \", getSimTime() );";
      segmentkeepAll_20 = "   {";
      segmentkeepAll_21 = "      switch$( %this.algorithm )";
      segmentkeepAll_22 = "      {";
      segmentkeepAll_23 = "      case \"nearest\":  %this.target = %owner.getNearestTarget( %this.maxFOV, %this.maxDistance, %this.aimGroups );";
      segmentkeepAll_24 = "      case \"furthest\": %this.target = %owner.getFurthestTarget( %this.maxFOV, %this.maxDistance, %this.aimGroups );";
      segmentkeepAll_25 = "      case \"random\":   %this.target = %owner.getRandomTarget( %this.maxFOV, %this.maxDistance, %this.aimGroups );";
      segmentkeepAll_26 = "      default:         %this.target = %owner.getNearestTarget( %this.maxFOV, %this.maxDistance, %this.aimGroups );";
      segmentkeepAll_27 = "      }";
      segmentkeepAll_28 = "   }";
      segmentkeepAll_29 = "   ";
      segmentkeepAll_3 = "   %owner = %this.owner;";
      segmentkeepAll_30 = "   ////";
      segmentkeepAll_31 = "   //   3. Aim at target (if we have one).   ";
      segmentkeepAll_32 = "   ////";
      segmentkeepAll_33 = "   if( isObject( %this.target ) )";
      segmentkeepAll_34 = "   {";
      segmentkeepAll_35 = "      %myPos        = %owner.getPosition();";
      segmentkeepAll_36 = "      %targetPos    = %this.target.getPosition();     ";
      segmentkeepAll_37 = "      %targetVec    = t2dVectorSub( %targetPos , %myPos );";
      segmentkeepAll_38 = "      %targetAngle  = vectorToAngle( %targetVec );";
      segmentkeepAll_39 = "      %owner.rotateTo( %targetAngle, %this.turnRate, true );";
      segmentkeepAll_4 = "    ";
      segmentkeepAll_40 = "   }";
      segmentkeepAll_41 = "   ";
      segmentkeepAll_42 = "   %this.schedule( %this.updateSpeed, aim  );";
      segmentkeepAll_43 = "}";
      segmentkeepAll_5 = "   ////";
      segmentkeepAll_6 = "   //   1. If we CAN lose a target, see if our target is in fact lost (out of distance and/or FOV)";
      segmentkeepAll_7 = "   ////";
      segmentkeepAll_8 = "   if(%this.canLose && isObject( %this.target ))";
      segmentkeepAll_9 = "   {";
      segmentonAddToScene = "16";
      segmentonAddToScene_0 = "   if( %this.maxFOV > 360 ) %this.maxFOV = 360;";
      segmentonAddToScene_1 = "   // Allow use of named types to override bit selection   ";
      segmentonAddToScene_10 = "         %this.aimGroups = %this.aimGroups SPC RGQC.getGraphGroup( %type );";
      segmentonAddToScene_11 = "      }";
      segmentonAddToScene_12 = "      %this.aimGroups = trim(%this.aimGroups);";
      segmentonAddToScene_13 = "   }";
      segmentonAddToScene_14 = "   %this.aimGroupsMask = bits(%this.aimGroups);";
      segmentonAddToScene_15 = "   %this.aim( );";
      segmentonAddToScene_2 = "   if(%this.aimType !$= \"\")";
      segmentonAddToScene_3 = "   {";
      segmentonAddToScene_4 = "      %this.aimGroups = \"\";";
      segmentonAddToScene_5 = "      %types = strreplace(trim(%this.aimType),\",\", \" \");";
      segmentonAddToScene_6 = "      %typeCount = getWordCount( %types );";
      segmentonAddToScene_7 = "      for(%count=0; %count < %typeCount; %count++)";
      segmentonAddToScene_8 = "      {";
      segmentonAddToScene_9 = "         %type = getWord(%types,%count);";
      segments = "behaviorFields\tonAddToScene\tkeepAll";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_02MovementAutomatic_AI_aimInstantlyRGQC) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "02 - Movement (Automatic)";
      description = "Automatically rotate to face the nearest object in a specified quick config group. (Rotation is instantaneous.)";
      details_atomName = "aimInstantlyRGQC";
      details_category = "02 - Movement (Automatic)";
      details_eventAction = "full";
      details_subCategory = "AI";
      friendlyName = "Aim Instantly (RGQC)";
      segmentbehaviorFields = "11";
      segmentbehaviorFields_0 = "   %typeList = RGQC.getKnownTypes(); //addBehaviorField - trick so line is kept during parse";
      segmentbehaviorFields_1 = "   %firstType = getWord( %typeList , 0 ); //addBehaviorField - trick so line is kept during parse";
      segmentbehaviorFields_10 = "   %behavior.addBehaviorField(\"canLose\", \"Target can be lost if it moves out of the aiming distance or angle.\", \"bool\", false);";
      segmentbehaviorFields_2 = "   %typelist = strreplace( %typelist, \" \", \"\\t\"); //addBehaviorField - trick so line is kept during parse";
      segmentbehaviorFields_3 = "   %typelist = strlwr(%typelist); //addBehaviorField - trick so line is kept during parse";
      segmentbehaviorFields_4 = "   %behavior.addBehaviorField( \"aimType\", \"Object type to aim at.\", \"enum\", %firstType, %typeList);";
      segmentbehaviorFields_5 = "//EFM   %behavior.addBehaviorField( \"aimGroups\", \"Groups to aim at.\", \"bitmask\", \"0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31\");   ";
      segmentbehaviorFields_6 = "   %behavior.addBehaviorField(\"maxDistance\", \"Maximum distance at which a target can be detected.\", \"float\", 25.0);";
      segmentbehaviorFields_7 = "   %behavior.addBehaviorField(\"maxFOV\", \"Maximum field-of-view (FOV) to seek within.\", \"float\", 360.0);";
      segmentbehaviorFields_8 = "   %behavior.addBehaviorField(\"updateSpeed\", \"Time between aim updates (lower values are faster and smoother looking).\", \"integer\", 32);";
      segmentbehaviorFields_9 = "   %behavior.addBehaviorField( \"algorithm\", \"Algorithm for choosing a single target from many.\", \"enum\"    , \"nearest\", \"nearest\\tfurthest\\trandom\");";
      segmentkeepAll = "46";
      segmentkeepAll_0 = "function aimInstantlyRGQC::aim(%this) ";
      segmentkeepAll_1 = "{";
      segmentkeepAll_10 = "      if( ( %owner.inDistance( %this.target, %this.maxDistance) == false ) ||";
      segmentkeepAll_11 = "          ( %owner.inFOV( %this.target, %this.maxFOV) == false ) ||";
      segmentkeepAll_12 = "          ( !%owner.inLOS( %this.target, %this.aimGroups ) == false ) )";
      segmentkeepAll_13 = "           ";
      segmentkeepAll_14 = "      { ";
      segmentkeepAll_15 = "            %this.target = \"\";";
      segmentkeepAll_16 = "      }";
      segmentkeepAll_17 = "   }";
      segmentkeepAll_18 = "   ////";
      segmentkeepAll_19 = "   //   2. If we have no target, try to find one.";
      segmentkeepAll_2 = "   if(%this.debugMode) echo(\"aimInstantlyRGQC::aim( \", ((%this.getName() $= \"\") ? %this : %this.getName()) , \" ) @ \", getSimTime() );";
      segmentkeepAll_20 = "   ////";
      segmentkeepAll_21 = "   if( !isObject( %this.target ) )";
      segmentkeepAll_22 = "   {";
      segmentkeepAll_23 = "      switch$( %this.algorithm )";
      segmentkeepAll_24 = "      {";
      segmentkeepAll_25 = "      case \"nearest\":  %this.target = %owner.getNearestTarget( %this.maxFOV, %this.maxDistance, %this.aimGroups );";
      segmentkeepAll_26 = "      case \"furthest\": %this.target = %owner.getFurthestTarget( %this.maxFOV, %this.maxDistance, %this.aimGroups );";
      segmentkeepAll_27 = "      case \"random\":   %this.target = %owner.getRandomTarget( %this.maxFOV, %this.maxDistance, %this.aimGroups );";
      segmentkeepAll_28 = "      default:         %this.target = %owner.getNearestTarget( %this.maxFOV, %this.maxDistance, %this.aimGroups );";
      segmentkeepAll_29 = "      }";
      segmentkeepAll_3 = "   %owner = %this.owner;";
      segmentkeepAll_30 = "   }";
      segmentkeepAll_31 = "   ";
      segmentkeepAll_32 = "   ////";
      segmentkeepAll_33 = "   //   3. Assuming we have a target, aim at it.   ";
      segmentkeepAll_34 = "   ////";
      segmentkeepAll_35 = "   if( isObject( %this.target ) )";
      segmentkeepAll_36 = "   {";
      segmentkeepAll_37 = "      %myPos        = %owner.getPosition();";
      segmentkeepAll_38 = "      %targetPos     = %this.target.getPosition();     ";
      segmentkeepAll_39 = "      %targetVec     = t2dVectorSub( %targetPos , %myPos );";
      segmentkeepAll_4 = "    ";
      segmentkeepAll_40 = "      %targetAngle   = vectorToAngle( %targetVec );";
      segmentkeepAll_41 = "      %this.owner.setRotation(%targetAngle);";
      segmentkeepAll_42 = "   }";
      segmentkeepAll_43 = "   ";
      segmentkeepAll_44 = "   %this.schedule( %this.updateSpeed, aim  );";
      segmentkeepAll_45 = "}";
      segmentkeepAll_5 = "   ////";
      segmentkeepAll_6 = "   //   1. If we CAN lose a target, see if our target is in fact lost (out of distance and/or FOV)";
      segmentkeepAll_7 = "   ////";
      segmentkeepAll_8 = "   if(%this.canLose && isObject( %this.target ))";
      segmentkeepAll_9 = "   {";
      segmentonAddToScene = "17";
      segmentonAddToScene_0 = "   if( %this.maxFOV > 360 ) %this.maxFOV = 360;";
      segmentonAddToScene_1 = "   // Allow use of named types to override bit selection   ";
      segmentonAddToScene_10 = "         %this.aimGroups = %this.aimGroups SPC RGQC.getGraphGroup( %type );";
      segmentonAddToScene_11 = "      }";
      segmentonAddToScene_12 = "      %this.aimGroups = trim(%this.aimGroups);";
      segmentonAddToScene_13 = "   }";
      segmentonAddToScene_14 = "   %this.aimGroupsMask = bits(%this.aimGroups);";
      segmentonAddToScene_15 = "   ";
      segmentonAddToScene_16 = "   %this.aim( );";
      segmentonAddToScene_2 = "   if(%this.aimType !$= \"\")";
      segmentonAddToScene_3 = "   {";
      segmentonAddToScene_4 = "      %this.aimGroups = \"\";";
      segmentonAddToScene_5 = "      %types = strreplace(trim(%this.aimType),\",\", \" \");";
      segmentonAddToScene_6 = "      %typeCount = getWordCount( %types );";
      segmentonAddToScene_7 = "      for(%count=0; %count < %typeCount; %count++)";
      segmentonAddToScene_8 = "      {";
      segmentonAddToScene_9 = "         %type = getWord(%types,%count);";
      segments = "behaviorFields\tonAddToScene\tkeepAll";
};
//--- OBJECT WRITE END ---
