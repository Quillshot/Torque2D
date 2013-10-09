if (!isObject(onCollisionPlayEffect)) 
{
   %behavior = new BehaviorTemplate(onCollisionPlayEffect)
   {
      friendlyName = "onCollision() -> Play Effect";
      behaviorType = "09 - Special Effects";
      description  = "Play effect when this object isDestroyed.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging for this behavior.", bool, false);   

   %effectNames = RG_BehaviorsPack009::findEffectsFileNames();
   
   %firstEffect = getField( %effectNames , 0 );
   
   %behavior.addBehaviorField( "EffectFile", "Effect file to play.", "enum", %firstEffect, %effectNames);
   
   %behavior.addBehaviorField( "KillDelay", "Kill effect after this many seconds.", "float", "0.0");
   %behavior.addBehaviorField( "atCollisionPoint", "If true, place effect at collision location, otherwise place in center of this object.", bool, true);
   
   %behavior.addBehaviorField( "effectImmovable", "If true, effect is not affected by external forces.", bool, true);
}

function onCollisionPlayEffect::onAddToScene(%this, %scenegraph) 
{   
   if(!%this.enable) return;
   if(%this.debugMode) echo("onCollisionPlayEffect::onAddToScene( ", %this,  " ) @ ", getSimTime() );
}

function onCollisionPlayEffect::onCollision( %this, %dstObject, %srcRef, %dstRef, %time, %normal, %contacts, %points ) 
{
   if(!%this.enable) return;
   if(%this.debugMode) echo("onCollisionPlayEffect::onCollision( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );

   %this.playEffect(%points);
}

function  onCollisionPlayEffect::playEffect( %this, %collisionPosition )
{      
   if(%this.debugMode) echo("onCollisionPlayEffect::playEffect( ", %this,  " ) @ ", getSimTime() );
   %found = false;

   %file = findFirstFile("~/*"@%this.EffectFile); 

   if(%this.debugMode) echo("%this.EffectFile: ", %this.EffectFile );   
   if(%this.debugMode) echo("%file: ", %file );   
   
   if(%file $= "") return;   
  
   %owner = %this.owner;
   
   if(%this.atCollisionPoint)  
   {
      %position = %collisionPosition;
   }
   else
   {
      %position = %owner.getPosition();
   }    
   
   %theEffect = new t2dParticleEffect() 
   {
      scenegraph = %this.owner.getScenegraph(); 
   };

   if(%this.debugMode) echo("%theEffect: ", %theEffect ); 
   if(%this.debugMode) echo("%this.owner.getScenegraph(): ", %this.owner.getScenegraph() ); 

   %theEffect.loadEffect( %file );
   %theEffect.setEffectLifeMode("KILL", %this.KillDelay);
   %theEffect.setEffectCollisionStatus(false);
   %theEffect.setPosition(%position);
   %theEffect.setImmovable(%this.effectImmovable);
   %theEffect.ignoreMe = true;  
   %theEffect.playEffect();
   //%theEffect.schedule( %this.KillDelay * 1000, safeDelete );
}