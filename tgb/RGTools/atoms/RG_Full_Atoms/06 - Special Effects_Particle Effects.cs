//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_06SpecialEffects_ParticleEffects_onRightMouseHold_PlayEffect) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "06 - Special Effects";
      description = "Play a specified effect when the right mouse button is pressed and held.";
      details_atomName = "onRightMouseHold_PlayEffect";
      details_category = "06 - Special Effects";
      details_eventAction = "full";
      details_subCategory = "Particle Effects";
      friendlyName = "onRightMouseHold() -> Play Effect";
      segmentbehaviorFields = "5";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"EffectFile\", \"Effect file to play.\", \"enum\", %firstEffect, %effectNames);   ";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"effectOffset\", \"Play effect at this offset.\", \"point2f\" , \"0.0 0.0\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField(\"trackRotation\", \"Rotate effect to match rotation of this object.\", bool, true);";
      segmentbehaviorFields_3 = "   %behavior.addBehaviorField( \"rotationOffset\", \"Additional rotation (in degrees) to account for incorrectly rotated effects.\", \"float\" , \"0.0\");";
      segmentbehaviorFields_4 = "   %behavior.addBehaviorField(\"mountEffect\", \"If true, mount effect to this object.\", bool, false);";
      segmentkeepAll = "53";
      segmentkeepAll_0 = "function onRightMouseHold_PlayEffect::playEffect( %this )";
      segmentkeepAll_1 = "{      ";
      segmentkeepAll_10 = "   %owner = %this.owner; ";
      segmentkeepAll_11 = "   %theEffect = new t2dParticleEffect() ";
      segmentkeepAll_12 = "   {";
      segmentkeepAll_13 = "      scenegraph = %this.owner.getScenegraph(); ";
      segmentkeepAll_14 = "   };";
      segmentkeepAll_15 = "   if(!%this.debugMode) echo(\"%theEffect: \", %theEffect ); ";
      segmentkeepAll_16 = "   if(!%this.debugMode) echo(\"%this.owner.getScenegraph(): \", %this.owner.getScenegraph() ); ";
      segmentkeepAll_17 = "   %theEffect.loadEffect( %file );";
      segmentkeepAll_18 = "   %theEffect.setEffectLifeMode(\"INFINITE\", 0.0);";
      segmentkeepAll_19 = "   %theEffect.setEffectCollisionStatus(false);   ";
      segmentkeepAll_2 = "   if(!%this.debugMode) echo(\"onRightMouseHold_PlayEffect::playEffect( \", %this,  \" ) @ \", getSimTime() );";
      segmentkeepAll_20 = "   ";
      segmentkeepAll_21 = "   if(%this.trackRotation) ";
      segmentkeepAll_22 = "   {  ";
      segmentkeepAll_23 = "      ";
      segmentkeepAll_24 = "      if(%this.mountEffect)";
      segmentkeepAll_25 = "      {";
      segmentkeepAll_26 = "         %rotation = %this.rotationOffset;";
      segmentkeepAll_27 = "      }";
      segmentkeepAll_28 = "      else";
      segmentkeepAll_29 = "      {";
      segmentkeepAll_3 = "   %found = false;";
      segmentkeepAll_30 = "         %rotation = %owner.getRotation() + %this.rotationOffset;";
      segmentkeepAll_31 = "      }";
      segmentkeepAll_32 = "      ";
      segmentkeepAll_33 = "      %theEffect.setRotation(%rotation); ";
      segmentkeepAll_34 = "   }   ";
      segmentkeepAll_35 = "   ";
      segmentkeepAll_36 = "   if(%this.mountEffect)";
      segmentkeepAll_37 = "   {  ";
      segmentkeepAll_38 = "      %theEffect.mount(%this.owner, %this.effectOffset,";
      segmentkeepAll_39 = "                       0, true, false, false, false);  ";
      segmentkeepAll_4 = "   %file = findFirstFile(\"*\"@%this.EffectFile); ";
      segmentkeepAll_40 = "   }";
      segmentkeepAll_41 = " ";
      segmentkeepAll_42 = "   else";
      segmentkeepAll_43 = "   {";
      segmentkeepAll_44 = "      %position = %owner.getWorldPoint(%this.effectOffset);  ";
      segmentkeepAll_45 = "      %theEffect.setPosition(%position);";
      segmentkeepAll_46 = "   }";
      segmentkeepAll_47 = "   ";
      segmentkeepAll_48 = "   %theEffect.ignoreMe = true;   ";
      segmentkeepAll_49 = "   %theEffect.playEffect();";
      segmentkeepAll_5 = "   if(!%this.debugMode) echo(\"%this.EffectFile: \", %this.EffectFile );   ";
      segmentkeepAll_50 = "      ";
      segmentkeepAll_51 = "   return %theEffect;";
      segmentkeepAll_52 = "}";
      segmentkeepAll_6 = "   if(!%this.debugMode) echo(\"%file: \", %file );   ";
      segmentkeepAll_7 = "   ";
      segmentkeepAll_8 = "   if(%file $= \"\") return;   ";
      segmentkeepAll_9 = "  ";
      segmentonAddToScene = "3";
      segmentonAddToScene_0 = "   %this.owner.setUseMouseEvents(true);";
      segmentonAddToScene_1 = "   %this.owner.setMouseLocked(true);";
      segmentonAddToScene_2 = "   sceneWindow2D.setUseObjectMouseEvents(1);";
      segmentonRightMouseDown = "2";
      segmentonRightMouseDown_0 = "   if (!%this.enable) return;";
      segmentonRightMouseDown_1 = "      %this.lastEffect = %this.playEffect();";
      segmentonRightMouseUp = "2";
      segmentonRightMouseUp_0 = "   if (!%this.enable) return;";
      segmentonRightMouseUp_1 = "      %this.lastEffect.safeDelete();";
      segments = "behaviorFields\tonAddToScene\tonRightMouseDown\tonRightMouseUp\tkeepAll";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_06SpecialEffects_ParticleEffects_onRepairedPlayEffect) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "06 - Special Effects";
      description = "Play effect when this object isDestroyed.";
      details_atomName = "onRepairedPlayEffect";
      details_category = "06 - Special Effects";
      details_eventAction = "full";
      details_subCategory = "Particle Effects";
      friendlyName = "onRepaired() -> Play Effect";
      segmentbehaviorFields = "3";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"EffectFile\", \"Effect file to play.\", \"enum\", %firstEffect, %effectNames);";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"KillDelay\", \"Kill effect after this many seconds.\", \"float\", \"0.0\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"effectImmovable\", \"If true, effect is not affected by external forces.\", bool, true);";
      segmentkeepAll = "35";
      segmentkeepAll_0 = "function onRepairedPlayEffect::onRepaired(%this) ";
      segmentkeepAll_1 = "{";
      segmentkeepAll_10 = "   %found = false;";
      segmentkeepAll_11 = "   %file = findFirstFile(\"*\"@%this.EffectFile); ";
      segmentkeepAll_12 = "   if(!%this.debugMode) echo(\"%this.EffectFile: \", %this.EffectFile );   ";
      segmentkeepAll_13 = "   if(!%this.debugMode) echo(\"%file: \", %file );   ";
      segmentkeepAll_14 = "   ";
      segmentkeepAll_15 = "   if(%file $= \"\") return;   ";
      segmentkeepAll_16 = "  ";
      segmentkeepAll_17 = "   %owner = %this.owner;    ";
      segmentkeepAll_18 = "   %position = %owner.getPosition(); ";
      segmentkeepAll_19 = "   ";
      segmentkeepAll_2 = "   if(!%this.enable) return;";
      segmentkeepAll_20 = "   %theEffect = new t2dParticleEffect() ";
      segmentkeepAll_21 = "   {";
      segmentkeepAll_22 = "      scenegraph = %this.owner.getScenegraph(); ";
      segmentkeepAll_23 = "      Immovable  = %this.effectImmovable;";
      segmentkeepAll_24 = "   };";
      segmentkeepAll_25 = "   if(!%this.debugMode) echo(\"%theEffect: \", %theEffect ); ";
      segmentkeepAll_26 = "   if(!%this.debugMode) echo(\"%this.owner.getScenegraph(): \", %this.owner.getScenegraph() ); ";
      segmentkeepAll_27 = "   %theEffect.loadEffect( %file );";
      segmentkeepAll_28 = "   %theEffect.setEffectLifeMode(\"KILL\", %this.KillDelay);";
      segmentkeepAll_29 = "   %theEffect.setEffectCollisionStatus(false);";
      segmentkeepAll_3 = "   if(!%this.debugMode) echo(\"onRepairedPlayEffect::onRepaired( \", %this,  \" ) @ \", getSimTime() );";
      segmentkeepAll_30 = "   %theEffect.setPosition(%position);";
      segmentkeepAll_31 = "   %theEffect.ignoreMe = true;   ";
      segmentkeepAll_32 = "   %theEffect.playEffect();";
      segmentkeepAll_33 = "   //%theEffect.schedule( %this.KillDelay * 1000, safeDelete );";
      segmentkeepAll_34 = "}";
      segmentkeepAll_4 = "    ";
      segmentkeepAll_5 = "   %this.playEffect();";
      segmentkeepAll_6 = "}";
      segmentkeepAll_7 = "function  onRepairedPlayEffect::playEffect( %this )";
      segmentkeepAll_8 = "{      ";
      segmentkeepAll_9 = "   if(!%this.debugMode) echo(\"onRepairedPlayEffect::playEffect( \", %this,  \" ) @ \", getSimTime() );";
      segments = "behaviorFields\tkeepAll";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_06SpecialEffects_ParticleEffects_onRechargedPlayEffect) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "06 - Special Effects";
      description = "Play effect when this object isDestroyed.";
      details_atomName = "onRechargedPlayEffect";
      details_category = "06 - Special Effects";
      details_eventAction = "full";
      details_subCategory = "Particle Effects";
      friendlyName = "onRecharged() -> Play Effect";
      segmentbehaviorFields = "3";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"EffectFile\", \"Effect file to play.\", \"enum\", %firstEffect, %effectNames);";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"KillDelay\", \"Kill effect after this many seconds.\", \"float\", \"0.0\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"effectImmovable\", \"If true, effect is not affected by external forces.\", bool, true);";
      segmentkeepAll = "35";
      segmentkeepAll_0 = "function onRechargedPlayEffect::onRecharged(%this) ";
      segmentkeepAll_1 = "{";
      segmentkeepAll_10 = "   %found = false;";
      segmentkeepAll_11 = "   %file = findFirstFile(\"*\"@%this.EffectFile); ";
      segmentkeepAll_12 = "   if(!%this.debugMode) echo(\"%this.EffectFile: \", %this.EffectFile );   ";
      segmentkeepAll_13 = "   if(!%this.debugMode) echo(\"%file: \", %file );   ";
      segmentkeepAll_14 = "   ";
      segmentkeepAll_15 = "   if(%file $= \"\") return;   ";
      segmentkeepAll_16 = "  ";
      segmentkeepAll_17 = "   %owner = %this.owner;    ";
      segmentkeepAll_18 = "   %position = %owner.getPosition(); ";
      segmentkeepAll_19 = "   ";
      segmentkeepAll_2 = "   if(!%this.enable) return;";
      segmentkeepAll_20 = "   %theEffect = new t2dParticleEffect() ";
      segmentkeepAll_21 = "   {";
      segmentkeepAll_22 = "      scenegraph = %this.owner.getScenegraph(); ";
      segmentkeepAll_23 = "      Immovable  = %this.effectImmovable;";
      segmentkeepAll_24 = "   };";
      segmentkeepAll_25 = "   if(!%this.debugMode) echo(\"%theEffect: \", %theEffect ); ";
      segmentkeepAll_26 = "   if(!%this.debugMode) echo(\"%this.owner.getScenegraph(): \", %this.owner.getScenegraph() ); ";
      segmentkeepAll_27 = "   %theEffect.loadEffect( %file );";
      segmentkeepAll_28 = "   %theEffect.setEffectLifeMode(\"KILL\", %this.KillDelay);";
      segmentkeepAll_29 = "   %theEffect.setEffectCollisionStatus(false);";
      segmentkeepAll_3 = "   if(!%this.debugMode) echo(\"onRechargedPlayEffect::onRecharged( \", %this,  \" ) @ \", getSimTime() );";
      segmentkeepAll_30 = "   %theEffect.setPosition(%position);";
      segmentkeepAll_31 = "   %theEffect.ignoreMe = true;  ";
      segmentkeepAll_32 = "   %theEffect.playEffect();";
      segmentkeepAll_33 = "   //%theEffect.schedule( %this.KillDelay * 1000, safeDelete );";
      segmentkeepAll_34 = "}";
      segmentkeepAll_4 = "    ";
      segmentkeepAll_5 = "   %this.playEffect();";
      segmentkeepAll_6 = "}";
      segmentkeepAll_7 = "function  onRechargedPlayEffect::playEffect( %this )";
      segmentkeepAll_8 = "{      ";
      segmentkeepAll_9 = "   if(!%this.debugMode) echo(\"onRechargedPlayEffect::playEffect( \", %this,  \" ) @ \", getSimTime() );";
      segments = "behaviorFields\tkeepAll";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_06SpecialEffects_ParticleEffects_onMouseHold_PlayEffect) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "06 - Special Effects";
      description = "Play a specified effect when the (left) mouse button is pressed and held.";
      details_atomName = "onMouseHold_PlayEffect";
      details_category = "06 - Special Effects";
      details_eventAction = "full";
      details_subCategory = "Particle Effects";
      friendlyName = "onMouseHold() -> Play Effect";
      segmentbehaviorFields = "5";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"EffectFile\", \"Effect file to play.\", \"enum\", %firstEffect, %effectNames);   ";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"effectOffset\", \"Play effect at this offset.\", \"point2f\" , \"0.0 0.0\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField(\"trackRotation\", \"Rotate effect to match rotation of this object.\", bool, true);";
      segmentbehaviorFields_3 = "   %behavior.addBehaviorField( \"rotationOffset\", \"Additional rotation (in degrees) to account for incorrectly rotated effects.\", \"float\" , \"0.0\");";
      segmentbehaviorFields_4 = "   %behavior.addBehaviorField(\"mountEffect\", \"If true, mount effect to this object.\", bool, false);";
      segmentkeepAll = "52";
      segmentkeepAll_0 = "function onMouseHold_PlayEffect::playEffect( %this )";
      segmentkeepAll_1 = "{      ";
      segmentkeepAll_10 = "   %owner = %this.owner; ";
      segmentkeepAll_11 = "   %theEffect = new t2dParticleEffect() ";
      segmentkeepAll_12 = "   {";
      segmentkeepAll_13 = "      scenegraph = %this.owner.getScenegraph(); ";
      segmentkeepAll_14 = "   };";
      segmentkeepAll_15 = "   if(!%this.debugMode) echo(\"%theEffect: \", %theEffect ); ";
      segmentkeepAll_16 = "   if(!%this.debugMode) echo(\"%this.owner.getScenegraph(): \", %this.owner.getScenegraph() ); ";
      segmentkeepAll_17 = "   %theEffect.loadEffect( %file );";
      segmentkeepAll_18 = "   %theEffect.setEffectLifeMode(\"INFINITE\", 0.0);";
      segmentkeepAll_19 = "   %theEffect.setEffectCollisionStatus(false);";
      segmentkeepAll_2 = "   if(!%this.debugMode) echo(\"onMouseHold_PlayEffect::playEffect( \", %this,  \" ) @ \", getSimTime() );";
      segmentkeepAll_20 = "   ";
      segmentkeepAll_21 = "   if(%this.trackRotation) ";
      segmentkeepAll_22 = "   {  ";
      segmentkeepAll_23 = "      ";
      segmentkeepAll_24 = "      if(%this.mountEffect)";
      segmentkeepAll_25 = "      {";
      segmentkeepAll_26 = "         %rotation = %this.rotationOffset;";
      segmentkeepAll_27 = "      }";
      segmentkeepAll_28 = "      else";
      segmentkeepAll_29 = "      {";
      segmentkeepAll_3 = "   %found = false;";
      segmentkeepAll_30 = "         %rotation = %owner.getRotation() + %this.rotationOffset;";
      segmentkeepAll_31 = "      }";
      segmentkeepAll_32 = "      ";
      segmentkeepAll_33 = "      %theEffect.setRotation(%rotation); ";
      segmentkeepAll_34 = "   }   ";
      segmentkeepAll_35 = "   ";
      segmentkeepAll_36 = "   if(%this.mountEffect)";
      segmentkeepAll_37 = "   {  ";
      segmentkeepAll_38 = "      %theEffect.mount(%this.owner, %this.effectOffset,";
      segmentkeepAll_39 = "                       0, true, false, false, false);  ";
      segmentkeepAll_4 = "   %file = findFirstFile(\"*\"@%this.EffectFile); ";
      segmentkeepAll_40 = "   }";
      segmentkeepAll_41 = " ";
      segmentkeepAll_42 = "   else";
      segmentkeepAll_43 = "   {";
      segmentkeepAll_44 = "      %position = %owner.getWorldPoint(%this.effectOffset);  ";
      segmentkeepAll_45 = "      %theEffect.setPosition(%position);";
      segmentkeepAll_46 = "   }";
      segmentkeepAll_47 = "   %theEffect.ignoreMe = true;  ";
      segmentkeepAll_48 = "   %theEffect.playEffect();";
      segmentkeepAll_49 = "      ";
      segmentkeepAll_5 = "   if(!%this.debugMode) echo(\"%this.EffectFile: \", %this.EffectFile );   ";
      segmentkeepAll_50 = "   return %theEffect;";
      segmentkeepAll_51 = "}";
      segmentkeepAll_6 = "   if(!%this.debugMode) echo(\"%file: \", %file );   ";
      segmentkeepAll_7 = "   ";
      segmentkeepAll_8 = "   if(%file $= \"\") return;   ";
      segmentkeepAll_9 = "  ";
      segmentonAddToScene = "3";
      segmentonAddToScene_0 = "   %this.owner.setUseMouseEvents(true);";
      segmentonAddToScene_1 = "   %this.owner.setMouseLocked(true);";
      segmentonAddToScene_2 = "   sceneWindow2D.setUseObjectMouseEvents(1);";
      segmentonMouseDown = "2";
      segmentonMouseDown_0 = "   if (!%this.enable) return;";
      segmentonMouseDown_1 = "      %this.lastEffect = %this.playEffect();";
      segmentonMouseUp = "2";
      segmentonMouseUp_0 = "   if (!%this.enable) return;";
      segmentonMouseUp_1 = "      %this.lastEffect.safeDelete();";
      segments = "behaviorFields\tonAddToScene\tonMouseDown\tonMouseUp\tkeepAll";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_06SpecialEffects_ParticleEffects_onKeyHold_PlayEffect) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "06 - Special Effects";
      description = "Play effect while specified key is pressed and held.";
      details_atomName = "onKeyHold_PlayEffect";
      details_category = "06 - Special Effects";
      details_eventAction = "full";
      details_subCategory = "Particle Effects";
      friendlyName = "On Key Hold -> Play Effect (multi)";
      segmentbehaviorFields = "6";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"effectKey\", \"Play effect while this key is held.\",  keybind, \"Keyboard space\" );";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"EffectFile\", \"Effect file to play.\", \"enum\", %firstEffect, %effectNames);   ";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"effectOffset\", \"Play effect at this offset.\", \"point2f\" , \"0.0 0.0\");";
      segmentbehaviorFields_3 = "   %behavior.addBehaviorField(\"trackRotation\", \"Rotate effect to match rotation of this object.\", bool, true);";
      segmentbehaviorFields_4 = "   %behavior.addBehaviorField( \"rotationOffset\", \"Additional rotation (in degrees) to account for incorrectly rotated effects.\", \"float\" , \"0.0\");";
      segmentbehaviorFields_5 = "   %behavior.addBehaviorField(\"mountEffect\", \"If true, mount effect to this object.\", bool, false);";
      segmentkeepAll = "67";
      segmentkeepAll_0 = "function onKeyHold_PlayEffect::onEffectKey(%this, %val) ";
      segmentkeepAll_1 = "{";
      segmentkeepAll_10 = "   else";
      segmentkeepAll_11 = "   {";
      segmentkeepAll_12 = "      %this.lastEffect.safeDelete();";
      segmentkeepAll_13 = "   }";
      segmentkeepAll_14 = "}";
      segmentkeepAll_15 = "function onKeyHold_PlayEffect::playEffect( %this )";
      segmentkeepAll_16 = "{      ";
      segmentkeepAll_17 = "   if(!%this.debugMode) echo(\"onKeyHold_PlayEffect::playEffect( \", %this,  \" ) @ \", getSimTime() );";
      segmentkeepAll_18 = "   %found = false;";
      segmentkeepAll_19 = "   %file = findFirstFile(\"*\"@%this.EffectFile); ";
      segmentkeepAll_2 = "   if(!%this.enable) return;";
      segmentkeepAll_20 = "   if(!%this.debugMode) echo(\"%this.EffectFile: \", %this.EffectFile );   ";
      segmentkeepAll_21 = "   if(!%this.debugMode) echo(\"%file: \", %file );   ";
      segmentkeepAll_22 = "   ";
      segmentkeepAll_23 = "   if(%file $= \"\") return;   ";
      segmentkeepAll_24 = "  ";
      segmentkeepAll_25 = "   %owner = %this.owner; ";
      segmentkeepAll_26 = "   %theEffect = new t2dParticleEffect() ";
      segmentkeepAll_27 = "   {";
      segmentkeepAll_28 = "      scenegraph = %this.owner.getScenegraph(); ";
      segmentkeepAll_29 = "   };";
      segmentkeepAll_3 = "   if(!%this.debugMode) echo(\"onKeyHold_PlayEffect::onEffectKey( \", %this,  \" ) @ \", getSimTime() );";
      segmentkeepAll_30 = "   if(!%this.debugMode) echo(\"%theEffect: \", %theEffect ); ";
      segmentkeepAll_31 = "   if(!%this.debugMode) echo(\"%this.owner.getScenegraph(): \", %this.owner.getScenegraph() ); ";
      segmentkeepAll_32 = "   %theEffect.loadEffect( %file );";
      segmentkeepAll_33 = "   %theEffect.setEffectLifeMode(\"INFINITE\", 0.0);";
      segmentkeepAll_34 = "   %theEffect.setEffectCollisionStatus(false);";
      segmentkeepAll_35 = "   ";
      segmentkeepAll_36 = "   if(%this.trackRotation) ";
      segmentkeepAll_37 = "   {  ";
      segmentkeepAll_38 = "      ";
      segmentkeepAll_39 = "      if(%this.mountEffect)";
      segmentkeepAll_4 = "   ";
      segmentkeepAll_40 = "      {";
      segmentkeepAll_41 = "         %rotation = %this.rotationOffset;";
      segmentkeepAll_42 = "      }";
      segmentkeepAll_43 = "      else";
      segmentkeepAll_44 = "      {";
      segmentkeepAll_45 = "         %rotation = %owner.getRotation() + %this.rotationOffset;";
      segmentkeepAll_46 = "      }";
      segmentkeepAll_47 = "      ";
      segmentkeepAll_48 = "      %theEffect.setRotation(%rotation); ";
      segmentkeepAll_49 = "   }   ";
      segmentkeepAll_5 = "   ";
      segmentkeepAll_50 = "   ";
      segmentkeepAll_51 = "   if(%this.mountEffect)";
      segmentkeepAll_52 = "   {  ";
      segmentkeepAll_53 = "      %theEffect.mount(%this.owner, %this.effectOffset,";
      segmentkeepAll_54 = "                       0, true, false, false, false);  ";
      segmentkeepAll_55 = "   }";
      segmentkeepAll_56 = " ";
      segmentkeepAll_57 = "   else";
      segmentkeepAll_58 = "   {";
      segmentkeepAll_59 = "      %position = %owner.getWorldPoint(%this.effectOffset);  ";
      segmentkeepAll_6 = "   if (%val )";
      segmentkeepAll_60 = "      %theEffect.setPosition(%position);";
      segmentkeepAll_61 = "   }";
      segmentkeepAll_62 = "   %theEffect.ignoreMe = true;  ";
      segmentkeepAll_63 = "   %theEffect.playEffect();";
      segmentkeepAll_64 = "      ";
      segmentkeepAll_65 = "   return %theEffect;";
      segmentkeepAll_66 = "}";
      segmentkeepAll_7 = "   {";
      segmentkeepAll_8 = "      %this.lastEffect = %this.playEffect();";
      segmentkeepAll_9 = "   }";
      segmentonAddToScene = "2";
      segmentonAddToScene_0 = "{   ";
      segmentonAddToScene_1 = "   moveMap.bindMulti( getWord( %this.effectKey , 0 ),  getWord( %this.effectKey , 1 ),  %this, \"onEffectKey\" );";
      segments = "behaviorFields\tonAddToScene\tkeepAll";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_06SpecialEffects_ParticleEffects_onDrainedPlayEffect) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "06 - Special Effects";
      description = "Play effect when this object is drained.";
      details_atomName = "onDrainedPlayEffect";
      details_category = "06 - Special Effects";
      details_eventAction = "full";
      details_subCategory = "Particle Effects";
      friendlyName = "onDrained() -> Play Effect";
      segmentbehaviorFields = "3";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"EffectFile\", \"Effect file to play.\", \"enum\", %firstEffect, %effectNames);";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"KillDelay\", \"Kill effect after this many seconds.\", \"float\", \"0.0\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"effectImmovable\", \"If true, effect is not affected by external forces.\", bool, true);";
      segmentkeepAll = "35";
      segmentkeepAll_0 = "function onDrainedPlayEffect::onDrained(%this) ";
      segmentkeepAll_1 = "{";
      segmentkeepAll_10 = "   %found = false;";
      segmentkeepAll_11 = "   %file = findFirstFile(\"*\"@%this.EffectFile); ";
      segmentkeepAll_12 = "   if(!%this.debugMode) echo(\"%this.EffectFile: \", %this.EffectFile );   ";
      segmentkeepAll_13 = "   if(!%this.debugMode) echo(\"%file: \", %file );   ";
      segmentkeepAll_14 = "   ";
      segmentkeepAll_15 = "   if(%file $= \"\") return;   ";
      segmentkeepAll_16 = "  ";
      segmentkeepAll_17 = "   %owner = %this.owner;    ";
      segmentkeepAll_18 = "   %position = %owner.getPosition(); ";
      segmentkeepAll_19 = "   ";
      segmentkeepAll_2 = "   if(!%this.enable) return;";
      segmentkeepAll_20 = "   %theEffect = new t2dParticleEffect() ";
      segmentkeepAll_21 = "   {";
      segmentkeepAll_22 = "      scenegraph = %this.owner.getScenegraph(); ";
      segmentkeepAll_23 = "      Immovable  = %this.effectImmovable;";
      segmentkeepAll_24 = "   };";
      segmentkeepAll_25 = "   if(!%this.debugMode) echo(\"%theEffect: \", %theEffect ); ";
      segmentkeepAll_26 = "   if(!%this.debugMode) echo(\"%this.owner.getScenegraph(): \", %this.owner.getScenegraph() ); ";
      segmentkeepAll_27 = "   %theEffect.loadEffect( %file );";
      segmentkeepAll_28 = "   %theEffect.setEffectLifeMode(\"KILL\", %this.KillDelay);";
      segmentkeepAll_29 = "   %theEffect.setEffectCollisionStatus(false);";
      segmentkeepAll_3 = "   if(!%this.debugMode) echo(\"onDrainedPlayEffect::onDrained( \", %this,  \" ) @ \", getSimTime() );";
      segmentkeepAll_30 = "   %theEffect.setPosition(%position);";
      segmentkeepAll_31 = "   %theEffect.ignoreMe = true;  ";
      segmentkeepAll_32 = "   %theEffect.playEffect();";
      segmentkeepAll_33 = "   //%theEffect.schedule( %this.KillDelay * 1000, safeDelete );";
      segmentkeepAll_34 = "}";
      segmentkeepAll_4 = "    ";
      segmentkeepAll_5 = "   %this.playEffect();";
      segmentkeepAll_6 = "}";
      segmentkeepAll_7 = "function  onDrainedPlayEffect::playEffect( %this )";
      segmentkeepAll_8 = "{      ";
      segmentkeepAll_9 = "   if(!%this.debugMode) echo(\"onDrainedPlayEffect::playEffect( \", %this,  \" ) @ \", getSimTime() );";
      segments = "behaviorFields\tkeepAll";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_06SpecialEffects_ParticleEffects_onDestroyedPlayEffect) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "06 - Special Effects";
      description = "Play effect when this object is destroyed.";
      details_atomName = "onDestroyedPlayEffect";
      details_category = "06 - Special Effects";
      details_eventAction = "full";
      details_subCategory = "Particle Effects";
      friendlyName = "onDestroyed() -> Play Effect";
      segmentbehaviorFields = "3";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"EffectFile\", \"Effect file to play.\", \"enum\", %firstEffect, %effectNames);";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"KillDelay\", \"Kill effect after this many seconds.\", \"float\", \"0.0\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"effectImmovable\", \"If true, effect is not affected by external forces.\", bool, true);";
      segmentkeepAll = "35";
      segmentkeepAll_0 = "function onDestroyedPlayEffect::onDestroyed(%this) ";
      segmentkeepAll_1 = "{";
      segmentkeepAll_10 = "   %found = false;";
      segmentkeepAll_11 = "   %file = findFirstFile(\"*\"@%this.EffectFile); ";
      segmentkeepAll_12 = "   if(!%this.debugMode) echo(\"%this.EffectFile: \", %this.EffectFile );   ";
      segmentkeepAll_13 = "   if(!%this.debugMode) echo(\"%file: \", %file );   ";
      segmentkeepAll_14 = "   ";
      segmentkeepAll_15 = "   if(%file $= \"\") return;   ";
      segmentkeepAll_16 = "  ";
      segmentkeepAll_17 = "   %owner = %this.owner;    ";
      segmentkeepAll_18 = "   %position = %owner.getPosition(); ";
      segmentkeepAll_19 = "   ";
      segmentkeepAll_2 = "   if(!%this.enable) return;";
      segmentkeepAll_20 = "   %theEffect = new t2dParticleEffect() ";
      segmentkeepAll_21 = "   {";
      segmentkeepAll_22 = "      scenegraph = %this.owner.getScenegraph(); ";
      segmentkeepAll_23 = "      Immovable  = %this.effectImmovable;";
      segmentkeepAll_24 = "   };";
      segmentkeepAll_25 = "   if(!%this.debugMode) echo(\"%theEffect: \", %theEffect ); ";
      segmentkeepAll_26 = "   if(!%this.debugMode) echo(\"%this.owner.getScenegraph(): \", %this.owner.getScenegraph() ); ";
      segmentkeepAll_27 = "   %theEffect.loadEffect( %file );";
      segmentkeepAll_28 = "   %theEffect.setEffectLifeMode(\"KILL\", %this.KillDelay);";
      segmentkeepAll_29 = "   %theEffect.setEffectCollisionStatus(false);";
      segmentkeepAll_3 = "   if(!%this.debugMode) echo(\"onDestroyedPlayEffect::onDestroyed( \", %this,  \" ) @ \", getSimTime() );";
      segmentkeepAll_30 = "   %theEffect.setPosition(%position);";
      segmentkeepAll_31 = "   %theEffect.ignoreMe = true;  ";
      segmentkeepAll_32 = "   %theEffect.playEffect();";
      segmentkeepAll_33 = "   //%theEffect.schedule( %this.KillDelay * 1000, safeDelete );";
      segmentkeepAll_34 = "}";
      segmentkeepAll_4 = "    ";
      segmentkeepAll_5 = "   %this.playEffect();";
      segmentkeepAll_6 = "}";
      segmentkeepAll_7 = "function  onDestroyedPlayEffect::playEffect( %this )";
      segmentkeepAll_8 = "{      ";
      segmentkeepAll_9 = "   if(!%this.debugMode) echo(\"onDestroyedPlayEffect::playEffect( \", %this,  \" ) @ \", getSimTime() );";
      segments = "behaviorFields\tkeepAll";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_06SpecialEffects_ParticleEffects_onDamagedPlayEffect) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "06 - Special Effects";
      description = "Play effect when this object is damaged.";
      details_atomName = "onDamagedPlayEffect";
      details_category = "06 - Special Effects";
      details_eventAction = "full";
      details_subCategory = "Particle Effects";
      friendlyName = "onDamaged() -> Play Effect";
      segmentbehaviorFields = "3";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"EffectFile\", \"Effect file to play.\", \"enum\", %firstEffect, %effectNames);";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"KillDelay\", \"Kill effect after this many seconds.\", \"float\", \"0.0\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"effectImmovable\", \"If true, effect is not affected by external forces.\", bool, true);";
      segmentkeepAll = "35";
      segmentkeepAll_0 = "function onDamagedPlayEffect::onDamaged(%this) ";
      segmentkeepAll_1 = "{";
      segmentkeepAll_10 = "   %found = false;";
      segmentkeepAll_11 = "   %file = findFirstFile(\"~/*\"@%this.EffectFile); ";
      segmentkeepAll_12 = "   if(!%this.debugMode) echo(\"%this.EffectFile: \", %this.EffectFile );   ";
      segmentkeepAll_13 = "   if(!%this.debugMode) echo(\"%file: \", %file );   ";
      segmentkeepAll_14 = "   ";
      segmentkeepAll_15 = "   if(%file $= \"\") return;   ";
      segmentkeepAll_16 = "  ";
      segmentkeepAll_17 = "   %owner = %this.owner;    ";
      segmentkeepAll_18 = "   %position = %owner.getPosition(); ";
      segmentkeepAll_19 = "   ";
      segmentkeepAll_2 = "   if(!%this.enable) return;";
      segmentkeepAll_20 = "   %theEffect = new t2dParticleEffect() ";
      segmentkeepAll_21 = "   {";
      segmentkeepAll_22 = "      scenegraph = %this.owner.getScenegraph(); ";
      segmentkeepAll_23 = "      Immovable  = %this.effectImmovable;";
      segmentkeepAll_24 = "   };";
      segmentkeepAll_25 = "   if(!%this.debugMode) echo(\"%theEffect: \", %theEffect ); ";
      segmentkeepAll_26 = "   if(!%this.debugMode) echo(\"%this.owner.getScenegraph(): \", %this.owner.getScenegraph() ); ";
      segmentkeepAll_27 = "   %theEffect.loadEffect( %file );";
      segmentkeepAll_28 = "   %theEffect.setEffectLifeMode(\"KILL\", %this.KillDelay);";
      segmentkeepAll_29 = "   %theEffect.setEffectCollisionStatus(false);";
      segmentkeepAll_3 = "   if(!%this.debugMode) echo(\"onDamagedPlayEffect::onDamaged( \", %this,  \" ) @ \", getSimTime() );";
      segmentkeepAll_30 = "   %theEffect.setPosition(%position);";
      segmentkeepAll_31 = "   %theEffect.ignoreMe = true;  ";
      segmentkeepAll_32 = "   %theEffect.playEffect();";
      segmentkeepAll_33 = "   //%theEffect.schedule( %this.KillDelay * 1000, safeDelete );";
      segmentkeepAll_34 = "}";
      segmentkeepAll_4 = "    ";
      segmentkeepAll_5 = "   %this.playEffect();";
      segmentkeepAll_6 = "}";
      segmentkeepAll_7 = "function  onDamagedPlayEffect::playEffect( %this )";
      segmentkeepAll_8 = "{      ";
      segmentkeepAll_9 = "   if(!%this.debugMode) echo(\"onDamagedPlayEffect::playEffect( \", %this,  \" ) @ \", getSimTime() );";
      segments = "behaviorFields\tkeepAll";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_06SpecialEffects_ParticleEffects_onCollisionPlayEffect) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "06 - Special Effects";
      description = "Play effect when this object isDestroyed.";
      details_atomName = "onCollisionPlayEffect";
      details_category = "06 - Special Effects";
      details_eventAction = "full";
      details_subCategory = "Particle Effects";
      friendlyName = "onCollision() -> Play Effect";
      segmentbehaviorFields = "4";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"EffectFile\", \"Effect file to play.\", \"enum\", %firstEffect, %effectNames);";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"KillDelay\", \"Kill effect after this many seconds.\", \"float\", \"0.0\");";
      segmentbehaviorFields_2 = "   %behavior.addBehaviorField( \"atCollisionPoint\", \"If true, place effect at collision location, otherwise place in center of this object.\", bool, true);";
      segmentbehaviorFields_3 = "   %behavior.addBehaviorField( \"effectImmovable\", \"If true, effect is not affected by external forces.\", bool, true);";
      segmentkeepAll = "36";
      segmentkeepAll_0 = "function  onCollisionPlayEffect::playEffect( %this, %collisionPosition )";
      segmentkeepAll_1 = "{      ";
      segmentkeepAll_10 = "   %owner = %this.owner;";
      segmentkeepAll_11 = "   ";
      segmentkeepAll_12 = "   if(%this.atCollisionPoint)  ";
      segmentkeepAll_13 = "   {";
      segmentkeepAll_14 = "      %position = %collisionPosition;";
      segmentkeepAll_15 = "   }";
      segmentkeepAll_16 = "   else";
      segmentkeepAll_17 = "   {";
      segmentkeepAll_18 = "      %position = %owner.getPosition();";
      segmentkeepAll_19 = "   }    ";
      segmentkeepAll_2 = "   if(%this.debugMode) echo(\"onCollisionPlayEffect::playEffect( \", %this,  \" ) @ \", getSimTime() );";
      segmentkeepAll_20 = "   ";
      segmentkeepAll_21 = "   %theEffect = new t2dParticleEffect() ";
      segmentkeepAll_22 = "   {";
      segmentkeepAll_23 = "      scenegraph = %this.owner.getScenegraph(); ";
      segmentkeepAll_24 = "   };";
      segmentkeepAll_25 = "   if(%this.debugMode) echo(\"%theEffect: \", %theEffect ); ";
      segmentkeepAll_26 = "   if(%this.debugMode) echo(\"%this.owner.getScenegraph(): \", %this.owner.getScenegraph() ); ";
      segmentkeepAll_27 = "   %theEffect.loadEffect( %file );";
      segmentkeepAll_28 = "   %theEffect.setEffectLifeMode(\"KILL\", %this.KillDelay);";
      segmentkeepAll_29 = "   %theEffect.setEffectCollisionStatus(false);";
      segmentkeepAll_3 = "   %found = false;";
      segmentkeepAll_30 = "   %theEffect.setPosition(%position);";
      segmentkeepAll_31 = "   %theEffect.setImmovable(%this.effectImmovable);";
      segmentkeepAll_32 = "   %theEffect.ignoreMe = true;  ";
      segmentkeepAll_33 = "   %theEffect.playEffect();";
      segmentkeepAll_34 = "   //%theEffect.schedule( %this.KillDelay * 1000, safeDelete );";
      segmentkeepAll_35 = "}";
      segmentkeepAll_4 = "   %file = findFirstFile(\"*\"@%this.EffectFile); ";
      segmentkeepAll_5 = "   if(%this.debugMode) echo(\"%this.EffectFile: \", %this.EffectFile );   ";
      segmentkeepAll_6 = "   if(%this.debugMode) echo(\"%file: \", %file );   ";
      segmentkeepAll_7 = "   ";
      segmentkeepAll_8 = "   if(%file $= \"\") return;   ";
      segmentkeepAll_9 = "  ";
      segmentonCollision = "1";
      segmentonCollision_0 = "   %this.playEffect(%points);";
      segments = "behaviorFields\tonCollision\tkeepAll";
};
//--- OBJECT WRITE END ---