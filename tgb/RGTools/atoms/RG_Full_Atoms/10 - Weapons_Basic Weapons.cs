//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_10Weapons_BasicWeapons_laserTurret) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "10 - Weapons";
      description = "This turret fires (animated or static) lasers.";
      details_atomName = "laserTurret";
      details_category = "10 - Weapons";
      details_eventAction = "full";
      details_subCategory = "Basic Weapons";
      friendlyName = "Laser Turret";
      segmentbehaviorFields = "4";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"beam\", \"Datablock specifying beam to fire when key is pressed.\", \"managedDB\", \"\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"repeatRate\",  \"If greater than 0, the turret will fire this many beams per-second while the fire button is depressed.\", integer, 0 );";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"muzzleOffset\", \"Offset to use for muzzle position\", \"point2f\" , \"0.0 -1.0\");";
      segmentbehaviorFields_3 = "   %behavior.addBehaviorField( \"mountTrackRotation\",  \"If true, this turret will track the rotation of any object it is mounted to.\", bool, false );   ";
      segmentkeepAll = "94";
      segmentkeepAll_0 = "function laserTurret::onFire( %this , %val )";
      segmentkeepAll_1 = "{ ";
      segmentkeepAll_10 = "      %this.isFiring--;";
      segmentkeepAll_11 = "   }";
      segmentkeepAll_12 = "   error(%this.isFiring);";
      segmentkeepAll_13 = "   ";
      segmentkeepAll_14 = "   // limit rate (if using repeat) and prevent multiple fire inputs from causing re-entrance";
      segmentkeepAll_15 = "   if( isEventPending(%this.lastSchedule) ) return;";
      segmentkeepAll_16 = "   if(%val) %this.doFire();";
      segmentkeepAll_17 = "}";
      segmentkeepAll_18 = "function laserTurret::doFire( %this )";
      segmentkeepAll_19 = "{ ";
      segmentkeepAll_2 = "   if(!%this.enable) return;  ";
      segmentkeepAll_20 = "   error(\"laserTurret::doFire( %this.isFiring == \", %this.isFiring , \" ) \" );";
      segmentkeepAll_21 = "   ";
      segmentkeepAll_22 = "   if(!%this.isFiring) return;";
      segmentkeepAll_23 = "   %this.createLaser();";
      segmentkeepAll_24 = "   if(%this.repeatRate > 0 )";
      segmentkeepAll_25 = "   {";
      segmentkeepAll_26 = "      %period = ( (1000 / %this.repeatRate ) >= 1) ? 1000 / %this.repeatRate : 1;";
      segmentkeepAll_27 = "      ";
      segmentkeepAll_28 = "      %period = mFloatLength( %period, 0 );";
      segmentkeepAll_29 = "      ";
      segmentkeepAll_3 = "   //error(\"laserTurret::onFire( \", %val , \" ) \" );";
      segmentkeepAll_30 = "      %this.lastSchedule = %this.schedule( %period, doFire );";
      segmentkeepAll_31 = "   }";
      segmentkeepAll_32 = "}";
      segmentkeepAll_33 = "function laserTurret::createLaser( %this )";
      segmentkeepAll_34 = "{ ";
      segmentkeepAll_35 = "   error(\"laserTurret::createLaser( %this.isFiring == \", %this.isFiring , \" ) \" );";
      segmentkeepAll_36 = "   ";
      segmentkeepAll_37 = "   %owner = %this.owner; ";
      segmentkeepAll_38 = "   ";
      segmentkeepAll_39 = "   %position = %owner.getWorldPoint(%this.muzzleOffset);";
      segmentkeepAll_4 = "   if(%val > 0)";
      segmentkeepAll_40 = "   %rotation = %owner.getRotation();";
      segmentkeepAll_41 = "   ";
      segmentkeepAll_42 = "   error(\"Rotation 1 == \", %rotation );";
      segmentkeepAll_43 = "   ";
      segmentkeepAll_44 = "   if(%this.mountTrackRotation && isObject(%owner.getMountedParent()) )";
      segmentkeepAll_45 = "   {";
      segmentkeepAll_46 = "      %rotation = %owner.getMountedParent().getRotation();";
      segmentkeepAll_47 = "   }";
      segmentkeepAll_48 = "   ";
      segmentkeepAll_49 = "   error(\"Rotation 2 == \", %rotation );";
      segmentkeepAll_5 = "   {   ";
      segmentkeepAll_50 = "   ";
      segmentkeepAll_51 = "   if(%this.beam.animationName $= \"\")";
      segmentkeepAll_52 = "   {";
      segmentkeepAll_53 = "      %beam = new t2dStaticSprite( )      ";
      segmentkeepAll_54 = "      {";
      segmentkeepAll_55 = "         config   = %this.beam;";
      segmentkeepAll_56 = "         //Position = %position;";
      segmentkeepAll_57 = "         //Rotation = %rotation;";
      segmentkeepAll_58 = "         scenegraph = %owner.scenegraph;";
      segmentkeepAll_59 = "         //MountTrackRotation = 0;";
      segmentkeepAll_6 = "      %this.isFiring++;";
      segmentkeepAll_60 = "      };";
      segmentkeepAll_61 = "      ";
      segmentkeepAll_62 = "      //%beam.setRotation( %rotation );   ";
      segmentkeepAll_63 = "      %beam.setVisible( 0 );   ";
      segmentkeepAll_64 = "      %beam.setPosition( %position );   ";
      segmentkeepAll_65 = "   }";
      segmentkeepAll_66 = "   else";
      segmentkeepAll_67 = "   {";
      segmentkeepAll_68 = "      %beam = new t2dAnimatedSprite( )";
      segmentkeepAll_69 = "      {";
      segmentkeepAll_7 = "   }";
      segmentkeepAll_70 = "         config = %this.beam;";
      segmentkeepAll_71 = "         Position      = %position;";
      segmentkeepAll_72 = "         //Rotation      = %rotation;";
      segmentkeepAll_73 = "         scenegraph    = %owner.scenegraph;";
      segmentkeepAll_74 = "         //MountTrackRotation = 0;";
      segmentkeepAll_75 = "      };   ";
      segmentkeepAll_76 = "   }";
      segmentkeepAll_77 = "   ";
      segmentkeepAll_78 = "   %beam.mount(%owner,";
      segmentkeepAll_79 = "         %this.muzzleOffset, // offset";
      segmentkeepAll_8 = "   else";
      segmentkeepAll_80 = "         0,     // force";
      segmentkeepAll_81 = "         true, //,  // track rotation";
      segmentkeepAll_82 = "         true, // send to mount ";
      segmentkeepAll_83 = "         true, // owned by mount";
      segmentkeepAll_84 = "         false); // inherit Attributes";
      segmentkeepAll_85 = "         ";
      segmentkeepAll_86 = "   // EFM - mounting is causing a visual artifact I have not yet resolved.  It seems that the ";
      segmentkeepAll_87 = "   // beam renders at 0-degrees of rotation then adjusts on the next cycle. i.e. Mounting track rotation";
      segmentkeepAll_88 = "   // lags for 1 cycle;";
      segmentkeepAll_89 = "   %beam.schedule( 50, setVisible, 1 );";
      segmentkeepAll_9 = "   {";
      segmentkeepAll_90 = "                 ";
      segmentkeepAll_91 = "   error(\"Rotation 3 == \", %beam.getRotation() );";
      segmentkeepAll_92 = "                 ";
      segmentkeepAll_93 = "}";
      segmentonAddToScene = "3";
      segmentonAddToScene_0 = "   %this.owner.MountTrackRotation = %this.mountTrackRotation;";
      segmentonAddToScene_1 = "   ";
      segmentonAddToScene_2 = "   %this.isFiring = 0;";
      segments = "behaviorFields\tonAddToScene\tkeepAll";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_10Weapons_BasicWeapons_laserBeam) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "10 - Weapons";
      description = "Make this object act like a laser beam.)";
      details_atomName = "laserBeam";
      details_category = "10 - Weapons";
      details_eventAction = "full";
      details_subCategory = "Basic Weapons";
      friendlyName = "Laser Beam";
      segmentbehaviorFields = "6";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField(enable, \"Enable this behavior.\", \"bool\", true);";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField(\"beamWidth\", \"Width of laser beam.\", \"float\", 1.0);";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField(\"maxBeamLength\", \"Maximum length of beam (when finally extended).\", \"float\", 50.0);";
      segmentbehaviorFields_3 = "   %behavior.addBehaviorField(\"extendSteps\", \"Number of steps to take while extending beam. (0 is immediate)\", \"integer\", 10);";
      segmentbehaviorFields_4 = "   %behavior.addBehaviorField(\"extendDuration\", \"Time it takes beam to extend to maximum length. (Ignored if extendSteps is 0)\", \"integer\", 100);";
      segmentbehaviorFields_5 = "   %behavior.addBehaviorField(\"beamLife\", \"How long beam remains (including extend time). (-1 is infinite)\", \"integer\", -1);";
      segmentkeepAll = "21";
      segmentkeepAll_0 = "function laserBeam::extendBeam(%this, %stepsRemaining, %stepTime) ";
      segmentkeepAll_1 = "{";
      segmentkeepAll_10 = "}";
      segmentkeepAll_11 = "//EFM hack!!! why is beam re-aligning?";
      segmentkeepAll_12 = "function laserBeam::myRot(%this, %iter) ";
      segmentkeepAll_13 = "{";
      segmentkeepAll_14 = "   %iter--;";
      segmentkeepAll_15 = "   ";
      segmentkeepAll_16 = "   if(%iter <= 0) return;";
      segmentkeepAll_17 = "   %owner = %this.owner;";
      segmentkeepAll_18 = "   error(\"laserBeam Rotation  == \", %owner.getRotation() );";
      segmentkeepAll_19 = "   %this.schedule( 100, myRot, %iter );     ";
      segmentkeepAll_2 = "   if(!%this.enable) return;";
      segmentkeepAll_20 = "}";
      segmentkeepAll_3 = "   %curLength = %this.owner.getHeight();";
      segmentkeepAll_4 = "   ";
      segmentkeepAll_5 = "   %this.owner.setHeight(%curLength + %this.lengthStep); ";
      segmentkeepAll_6 = "   ";
      segmentkeepAll_7 = "   %stepsRemaining--;";
      segmentkeepAll_8 = "   ";
      segmentkeepAll_9 = "   if(%stepsRemaining > 0 )  %this.schedule( %stepTime, extendBeam, %stepsRemaining, %stepTime);";
      segmentonAddToScene = "24";
      segmentonAddToScene_0 = "   if(%this.extendSteps <= 0)";
      segmentonAddToScene_1 = "   {";
      segmentonAddToScene_10 = "      {";
      segmentonAddToScene_11 = "         %this.extendSteps = 1;";
      segmentonAddToScene_12 = "         %this.stepTime = 0;";
      segmentonAddToScene_13 = "      }";
      segmentonAddToScene_14 = "   }";
      segmentonAddToScene_15 = "         ";
      segmentonAddToScene_16 = "   %this.lengthStep = %this.maxBeamLength / %this.extendSteps;";
      segmentonAddToScene_17 = "   %this.owner.setWidth( %this.beamWidth );   ";
      segmentonAddToScene_18 = "   %this.owner.setHeight( 0 );";
      segmentonAddToScene_19 = "   ";
      segmentonAddToScene_2 = "      %this.extendSteps = 1;";
      segmentonAddToScene_20 = "   if(%this.beamLife > 0 ) %this.owner.schedule( %this.beamLife, safeDelete );";
      segmentonAddToScene_21 = "   ";
      segmentonAddToScene_22 = "   %this.extendBeam(%this.extendSteps, %this.stepTime );";
      segmentonAddToScene_23 = "   %this.myRot(10);";
      segmentonAddToScene_3 = "      %this.stepTime = 0;";
      segmentonAddToScene_4 = "   }";
      segmentonAddToScene_5 = "   else";
      segmentonAddToScene_6 = "   {";
      segmentonAddToScene_7 = "      %this.stepTime = mFloatLength( %this.extendDuration / %this.extendSteps, 0);";
      segmentonAddToScene_8 = "      // Extremely short extend times are treated as instantaneous";
      segmentonAddToScene_9 = "      if(%this.stepTime <= 1)";
      segments = "behaviorFields\tonAddToScene\tkeepAll";
};
//--- OBJECT WRITE END ---