if (!isObject(onDrained_AutoRecharge))
{
   %behavior = new BehaviorTemplate(onDrained_AutoRecharge)
   {
      friendlyName = "onDrained() -> AutoRecharge";
      behaviorType = "05 - Damage and Energy";
      description  = "This object onDrained_AutoRecharge itself (over time) when drained.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);

   %behavior.addBehaviorField( "Recharge_Ammout", "Add this many points per recharging cycle.", "float", 1);
   %behavior.addBehaviorField( "Recharge_Time", "Time between each recharging cycle in milliseconds.", "integer", 1000);
}

function onDrained_AutoRecharge::onDrained(%this) 
{
   //echo("onDrained_AutoRecharge::onDrained( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(!%this.enable) return;   
   %usesEnergyBehavior = %this.owner.getBehavior( "usesEnergy" );

   if(%this.isRecharging) return; // Already recharging
   %this.recharge( %usesEnergyBehavior );
}

function onDrained_AutoRecharge::recharge( %this, %usesEnergyBehavior )
{
   //echo("onDrained_AutoRecharge::recharge( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(!%usesEnergyBehavior.isDrained()) return;  

   %takesDamageBehavior = %this.owner.getBehavior( "takesDamage" );
   if(isObject(%takesDamageBehavior) && %takesDamageBehavior.isDestroyed) return; // Don't recharge once destroyed
   
   %this.isRecharging = true;   

   %usesEnergyBehavior.applyRecharge( %this.Recharge_Ammout );
   
   if(!%usesEnergyBehavior.isDrained()) %this.isRecharging = false;

   if(%this.isRecharging) %this.schedule( %this.Recharge_Time, recharge, %usesEnergyBehavior );   
}
