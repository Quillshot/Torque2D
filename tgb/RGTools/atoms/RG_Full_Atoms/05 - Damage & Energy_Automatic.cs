//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_05DamageEnergy_Automatic_onDrained_AutoRecharge) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "05 - Damage & Energy";
      description = "This object onDrained_AutoRecharge itself (over time) when drained.";
      details_atomName = "onDrained_AutoRecharge";
      details_category = "05 - Damage & Energy";
      details_eventAction = "full";
      details_subCategory = "Automatic";
      friendlyName = "onDrained() -> AutoRecharge";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"Recharge_Ammout\", \"Add this many points per recharging cycle.\", \"float\", 1);";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"Recharge_Time\", \"Time between each recharging cycle in milliseconds.\", \"integer\", 1000);";
      segmentkeepAll = "22";
      segmentkeepAll_0 = "function onDrained_AutoRecharge::onDrained(%this) ";
      segmentkeepAll_1 = "{";
      segmentkeepAll_10 = "   if(!%this.enable) return;";
      segmentkeepAll_11 = "   if(!%this.debugMode) echo(\"onDrained_AutoRecharge::recharge( \", ((%this.getName() $= \"\") ? %this : %this.getName()) , \" ) @ \", getSimTime() );";
      segmentkeepAll_12 = "   if(!%usesEnergyBehavior.isDrained()) return;  ";
      segmentkeepAll_13 = "   %takesDamageBehavior = %this.owner.getBehavior( \"takesDamage\" );";
      segmentkeepAll_14 = "   if(isObject(%takesDamageBehavior) && %takesDamageBehavior.isDestroyed) return; // Don\'t recharge once destroyed";
      segmentkeepAll_15 = "   ";
      segmentkeepAll_16 = "   %this.isRecharging = true;   ";
      segmentkeepAll_17 = "   %usesEnergyBehavior.applyRecharge( %this.Recharge_Ammout );";
      segmentkeepAll_18 = "   ";
      segmentkeepAll_19 = "   if(!%usesEnergyBehavior.isDrained()) %this.isRecharging = false;";
      segmentkeepAll_2 = "   if(!%this.enable) return;";
      segmentkeepAll_20 = "   if(%this.isRecharging) %this.schedule( %this.Recharge_Time, recharge, %usesEnergyBehavior );   ";
      segmentkeepAll_21 = "}";
      segmentkeepAll_3 = "   if(!%this.debugMode) echo(\"onDrained_AutoRecharge::onDrained( \", ((%this.getName() $= \"\") ? %this : %this.getName()) , \" ) @ \", getSimTime() );";
      segmentkeepAll_4 = "   %usesEnergyBehavior = %this.owner.getBehavior( \"usesEnergy\" );";
      segmentkeepAll_5 = "   if(%this.isRecharging) return; // Already recharging";
      segmentkeepAll_6 = "   %this.recharge( %usesEnergyBehavior );";
      segmentkeepAll_7 = "}";
      segmentkeepAll_8 = "function onDrained_AutoRecharge::recharge( %this, %usesEnergyBehavior )";
      segmentkeepAll_9 = "{";
      segments = "behaviorFields\tkeepAll";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_05DamageEnergy_Automatic_onDamaged_AutoRepair) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "05 - Damage & Energy";
      description = "This object onDamaged_AutoRepair itself (over time) when damaged.";
      details_atomName = "onDamaged_AutoRepair";
      details_category = "05 - Damage & Energy";
      details_eventAction = "full";
      details_subCategory = "Automatic";
      friendlyName = "onDamaged() -> AutoRepair";
      segmentbehaviorFields = "2";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"Heal_Ammout\", \"Add this many points per healing cycle.\", \"float\", 1);";
      segmentbehaviorFields_1 = "   %behavior.addBehaviorField( \"Heal_Time\", \"Time between each healing cycle in milliseconds.\", \"integer\", 1000);";
      segmentkeepAll = "21";
      segmentkeepAll_0 = "function onDamaged_AutoRepair::onDamaged(%this) ";
      segmentkeepAll_1 = "{";
      segmentkeepAll_10 = "   if(!%this.enable) return;";
      segmentkeepAll_11 = "   if(!%this.debugMode) echo(\"onDamaged_AutoRepair::heal( \", ((%this.getName() $= \"\") ? %this : %this.getName()) , \" ) @ \", getSimTime() );";
      segmentkeepAll_12 = "   if(!%takesDamageBehavior.isDamaged()) return;   ";
      segmentkeepAll_13 = "   if(%takesDamageBehavior.isDestroyed) return; // Don\'t heal once destroyed";
      segmentkeepAll_14 = "   ";
      segmentkeepAll_15 = "   %this.isHealing = true;   ";
      segmentkeepAll_16 = "   %takesDamageBehavior.applyRepair( %this.Heal_Ammout );";
      segmentkeepAll_17 = "   ";
      segmentkeepAll_18 = "   if(!%takesDamageBehavior.isDamaged()) %this.isHealing = false;";
      segmentkeepAll_19 = "   if(%this.isHealing) %this.schedule( %this.Heal_Time, heal, %takesDamageBehavior );   ";
      segmentkeepAll_2 = "   if(!%this.enable) return;";
      segmentkeepAll_20 = "}";
      segmentkeepAll_3 = "   if(!%this.debugMode) echo(\"onDamaged_AutoRepair::onDamaged( \", ((%this.getName() $= \"\") ? %this : %this.getName()) , \" ) @ \", getSimTime() );";
      segmentkeepAll_4 = "   %takesDamageBehavior = %this.owner.getBehavior( \"takesDamage\" );";
      segmentkeepAll_5 = "   if(%this.isHealing) return; // Already healing";
      segmentkeepAll_6 = "   %this.heal( %takesDamageBehavior );";
      segmentkeepAll_7 = "}";
      segmentkeepAll_8 = "function onDamaged_AutoRepair::heal( %this, %takesDamageBehavior )";
      segmentkeepAll_9 = "{";
      segments = "behaviorFields\tkeepAll";
};
//--- OBJECT WRITE END ---