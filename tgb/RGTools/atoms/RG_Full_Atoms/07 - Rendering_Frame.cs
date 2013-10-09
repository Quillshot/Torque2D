//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_07Rendering_Frame_multiObjectUniqueFrameRandomizer) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "07 - Rendering / Frame";
      description = "Uniquely randomize the frame used by this and N other other objects between min/max Frame.";
      details_atomName = "multiObjectUniqueFrameRandomizer";
      details_category = "07 - Rendering";
      details_eventAction = "full";
      details_subCategory = "Frame";
      friendlyName = "Multi-Object Unique Frame Randomizer";
      segmentbehaviorFields = "3";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"minFrame\", \"Minimum frame number (inclusive) to randomize to.\", \"int\", \"0\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"maxFrame\", \"Maximum frame number (inclusive) to randomize to.\", \"int\", \"7\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"globalNum\", \"(Warning Advanced!) Allows this behavior to be used with more than one set of objects and ranges. (Leave at 0 for one set of objects to be randomized.)\", \"int\", \"0\");";
      segmentonAddToScene = "17";
      segmentonAddToScene_0 = "   %sequenceGroup = %this.globalNum;";
      segmentonAddToScene_1 = "   ";
      segmentonAddToScene_10 = "      $TimeRandomizer::Sequence[%sequenceGroup] = randomizeWords( $TimeRandomizer::Sequence[%sequenceGroup], 10 * (%this.maxFrame - %this.minFrame)  );";
      segmentonAddToScene_11 = "      $TimeRandomizer::Sequence[%sequenceGroup] = trim($TimeRandomizer::Sequence[%sequenceGroup]);";
      segmentonAddToScene_12 = "   }";
      segmentonAddToScene_13 = "   ";
      segmentonAddToScene_14 = "   %myFrame = getWord($TimeRandomizer::Sequence[%sequenceGroup], 0 );";
      segmentonAddToScene_15 = "   $TimeRandomizer::Sequence[%sequenceGroup] = popWordFront( $TimeRandomizer::Sequence[%sequenceGroup] );";
      segmentonAddToScene_16 = "   %this.owner.setFrame( %myFrame );";
      segmentonAddToScene_2 = "   // First tile in, need to create random sequence";
      segmentonAddToScene_3 = "   if( ($TimeRandomizer::Sequence[%sequenceGroup]) $= \"\" )";
      segmentonAddToScene_4 = "   {";
      segmentonAddToScene_5 = "      for(%count = %this.minFrame; %count <= %this.maxFrame; %count++)";
      segmentonAddToScene_6 = "      {";
      segmentonAddToScene_7 = "         $TimeRandomizer::Sequence[%sequenceGroup] = $TimeRandomizer::Sequence[%sequenceGroup] SPC %count;";
      segmentonAddToScene_8 = "      }";
      segmentonAddToScene_9 = "      $TimeRandomizer::Sequence[%sequenceGroup] = trim($TimeRandomizer::Sequence[%sequenceGroup]);";
      segments = "behaviorFields\tonAddToScene";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_07Rendering_Frame_FrameRandomizer) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "07 - Rendering / Frame";
      description = "Randomize the frame used for this object between min/max Frame.";
      details_atomName = "FrameRandomizer";
      details_category = "07 - Rendering";
      details_eventAction = "full";
      details_subCategory = "Frame";
      friendlyName = "Frame Randomizer";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"minFrame\", \"Minimum frame number (inclusive) to randomize to.\", \"int\", \"0\");";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"maxFrame\", \"Maximum frame number (inclusive) to randomize to.\", \"int\", \"7\");";
      segmentonAddToScene = "2";
      segmentonAddToScene_0 = "   %myFrame = getRandom( %this.minFrame, %this.maxFrame );";
      segmentonAddToScene_1 = "   %this.owner.setFrame( %myFrame );";
      segments = "behaviorFields\tonAddToScene";
};
//--- OBJECT WRITE END ---
