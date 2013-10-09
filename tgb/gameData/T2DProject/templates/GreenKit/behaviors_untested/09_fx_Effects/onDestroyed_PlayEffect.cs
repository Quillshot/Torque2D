if (!isObject(onDestroyedPlayEffect)) 
{
   %behavior = new BehaviorTemplate(onDestroyedPlayEffect)
   {
      friendlyName = "onDestroyed() -> Play Effect";
      behaviorType = "09 - Special Effects";
      description  = "Play effect when this object is destroyed.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging for this behavior.", bool, false);   

   %effectNames = findEffectsFileNames();

   %firstEffect = getField( %effectNames , 0 );
   
   %behavior.addBehaviorField( "EffectFile", "Effect file to play.", "enum", %firstEffect, %effectNames);
   
   %behavior.addBehaviorField( "KillDelay", "Kill effect after this many seconds.", "float", "0.0");
   
   %behavior.addBehaviorField( "effectImmovable", "If true, effect is not affected by external forces.", bool, true);
}

function onDestroyedPlayEffect::onAddToScene(%this, %scenegraph) 
{   
   if(!%this.enable) return;
   if(!%this.debugMode) echo("onDestroyedPlayEffect::onAddToScene( ", %this,  " ) @ ", getSimTime() );
}

function onDestroyedPlayEffect::onDestroyed(%this) 
{
   if(!%this.enable) return;
   if(!%this.debugMode) echo("onDestroyedPlayEffect::onDestroyed( ", %this,  " ) @ ", getSimTime() );
    
   %this.playEffect();
}

function  onDestroyedPlayEffect::playEffect( %this )
{      
   if(!%this.debugMode) echo("onDestroyedPlayEffect::playEffect( ", %this,  " ) @ ", getSimTime() );
   %found = false;

   %file = findFirstFile("~/*"@%this.EffectFile); 

   if(!%this.debugMode) echo("%this.EffectFile: ", %this.EffectFile );   
   if(!%this.debugMode) echo("%file: ", %file );   
   
   if(%file $= "") return;   
  
   %owner = %this.owner;    
   %position = %owner.getPosition(); 
   
   %theEffect = new t2dParticleEffect() 
   {
      scenegraph = %this.owner.getScenegraph(); 
      Immovable  = %this.effectImmovable;
   };

   if(!%this.debugMode) echo("%theEffect: ", %theEffect ); 
   if(!%this.debugMode) echo("%this.owner.getScenegraph(): ", %this.owner.getScenegraph() ); 

   %theEffect.loadEffect( %file );
   %theEffect.setEffectLifeMode("KILL", %this.KillDelay);
   %theEffect.setEffectCollisionStatus(false);
   %theEffect.setPosition(%position);
   %theEffect.ignoreMe = true;  
   %theEffect.playEffect();
   //%theEffect.schedule( %this.KillDelay * 1000, safeDelete );
}