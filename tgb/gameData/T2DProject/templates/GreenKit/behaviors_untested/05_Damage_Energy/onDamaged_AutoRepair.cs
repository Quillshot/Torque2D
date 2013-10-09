if (!isObject(onDamaged_AutoRepair))
{
   %behavior = new BehaviorTemplate(onDamaged_AutoRepair)
   {
      friendlyName = "onDamaged() -> AutoRepair";
      behaviorType = "05 - Damage and Energy";
      description  = "This object onDamaged_AutoRepair itself (over time) when damaged.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);

   %behavior.addBehaviorField( "Heal_Ammout", "Add this many points per healing cycle.", "float", 1);
   %behavior.addBehaviorField( "Heal_Time", "Time between each healing cycle in milliseconds.", "integer", 1000);
}

function onDamaged_AutoRepair::onDamaged(%this) 
{
   //echo("onDamaged_AutoRepair::onDamaged( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(!%this.enable) return;   
   %takesDamageBehavior = %this.owner.getBehavior( "takesDamage" );

   if(%this.isHealing) return; // Already healing
   %this.heal( %takesDamageBehavior );
}

function onDamaged_AutoRepair::heal( %this, %takesDamageBehavior )
{
   //echo("onDamaged_AutoRepair::heal( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   if(!%takesDamageBehavior.isDamaged()) return;   
   if(%takesDamageBehavior.isDestroyed) return; // Don't heal once destroyed
   
   %this.isHealing = true;   

   %takesDamageBehavior.applyRepair( %this.Heal_Ammout );
   
   if(!%takesDamageBehavior.isDamaged()) %this.isHealing = false;

   if(%this.isHealing) %this.schedule( %this.Heal_Time, heal, %takesDamageBehavior );   
}
