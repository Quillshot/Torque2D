//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_05DamageEnergy_Collision_onCollision_DrainEnergy) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "05 - Damage & Energy";
      description = "This object attempts to drain energy from another object upon collision. (Warning: Don\'t use with QC!)";
      details_atomName = "onCollision_DrainEnergy";
      details_category = "05 - Damage & Energy";
      details_eventAction = "full";
      details_subCategory = "Collision";
      friendlyName = "onCollision() -> Drain Energy (manual)";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"Drain\", \"Deal this much drain to objects on collision.\", \"float\", 0.0);";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"Drain_Groups\", \"Only apply drain to objects in these graph groups.\", \"bitmask\", \"0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31\");   ";
      segmentonCollision = "9";
      segmentonCollision_0 = "   %drainBehavior = %dstObject.getBehavior( \"usesEnergy\" );";
      segmentonCollision_1 = "  ";
      segmentonCollision_2 = "   if( !isObject(%drainBehavior) ) return; // Not using drain behavior";
      segmentonCollision_3 = "   ";
      segmentonCollision_4 = "   %inDrainGroup = strstr( %this.Drain_Groups, %dstObject.getGraphGroup() );";
      segmentonCollision_5 = "   ";
      segmentonCollision_6 = "   if( %inDrainGroup == -1 ) return; // Not in drain group";
      segmentonCollision_7 = "   ";
      segmentonCollision_8 = "   %drainBehavior.applyDrain( %this.Drain );   ";
      segments = "behaviorFields\tonCollision";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_05DamageEnergy_Collision_onCollision_DoDamage) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "05 - Damage & Energy";
      description = "This object does damage to other objects on collision. (Warning: Don\'t use with QC!)";
      details_atomName = "onCollision_DoDamage";
      details_category = "05 - Damage & Energy";
      details_eventAction = "full";
      details_subCategory = "Collision";
      friendlyName = "onCollision() -> Do Damage (manual)";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"Damage\", \"Deal this much damage to objects on collision.\", \"float\", 0.0);";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"Damage_Groups\", \"Only apply damage to objects in these graph groups.\", \"bitmask\", \"0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31\");   ";
      segmentonCollision = "9";
      segmentonCollision_0 = "   %damageBehavior = %dstObject.getBehavior( \"takesDamage\" );";
      segmentonCollision_1 = "  ";
      segmentonCollision_2 = "   if( !isObject(%damageBehavior) ) return; // Not using damage behavior";
      segmentonCollision_3 = "   ";
      segmentonCollision_4 = "   %inDamageGroup = strstr( %this.Damage_Groups, %dstObject.getGraphGroup() );";
      segmentonCollision_5 = "   ";
      segmentonCollision_6 = "   if( %inDamageGroup == -1 ) return; // Not in damage group";
      segmentonCollision_7 = "   ";
      segmentonCollision_8 = "   %damageBehavior.applyDamage( %this.Damage );   ";
      segments = "behaviorFields\tonCollision";
};
//--- OBJECT WRITE END ---
