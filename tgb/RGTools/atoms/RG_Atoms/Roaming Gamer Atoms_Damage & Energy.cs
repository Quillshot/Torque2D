//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_DamageEnergy_repairDamage) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Roaming Gamer - Damage & Energy";
      description = "apply damage to the owner object.";
      details_atomName = "repairDamage";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "Damage & Energy";
      friendlyName = "repairDamage";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"amount\", \"Amount of damage to apply.\", \"float\", \"0.0\");      ";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.repairDamage( %this.amount );";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_DamageEnergy_rechargeEnergy) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Roaming Gamer - Damage & Energy";
      description = "apply energy recharge to the owner object.";
      details_atomName = "rechargeEnergy";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "Damage & Energy";
      friendlyName = "rechargeEnergy";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"amount\", \"Amount of energy recharge to apply.\", \"float\", \"0.0\");      ";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.rechargeEnergy( %this.amount );";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_DamageEnergy_drainEnergy) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Roaming Gamer - Damage & Energy";
      description = "apply energy recharge to the owner object.";
      details_atomName = "drainEnergy";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "Damage & Energy";
      friendlyName = "drainEnergy";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"amount\", \"Amount of energy recharge to apply.\", \"float\", \"0.0\");      ";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.drainEnergy( %this.amount );";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(action_RoamingGamerAtoms_DamageEnergy_applyDamage) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Roaming Gamer - Damage & Energy";
      description = "apply damage to the owner object.";
      details_atomName = "applyDamage";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "action";
      details_subCategory = "Damage & Energy";
      friendlyName = "applyDamage";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"amount\", \"Amount of damage to apply.\", \"float\", \"0.0\");      ";
      segmentexecuteAction = "1";
      segmentexecuteAction_0 = "   %this.owner.applyDamage( %this.amount );";
      segments = "behaviorFields\texecuteAction";
};
//--- OBJECT WRITE END ---
