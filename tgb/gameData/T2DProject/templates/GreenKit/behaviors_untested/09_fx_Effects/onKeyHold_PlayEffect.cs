if (!isObject(onKeyHold_PlayEffect)) 
{
   %behavior = new BehaviorTemplate(onKeyHold_PlayEffect)
   {
      friendlyName = "On Key Hold -> Play Effect";
      behaviorType = "09 - Special Effects";
      description  = "Play effect while specified key is pressed and held.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging for this behavior.", bool, false);   
   
   %behavior.addBehaviorField( "effectKey", "Play effect while this key is held.",  keybind, "Keyboard space" );

   %effectNames = findEffectsFileNames();

   %firstEffect = getField( %effectNames , 0 );
   
   %behavior.addBehaviorField( "EffectFile", "Effect file to play.", "enum", %firstEffect, %effectNames);   
   
   %behavior.addBehaviorField( "effectOffset", "Play effect at this offset.", "point2f" , "0.0 0.0");
   
   %behavior.addBehaviorField("trackRotation", "Rotate effect to match rotation of this object.", bool, true);
   
   %behavior.addBehaviorField( "rotationOffset", "Additional rotation (in degrees) to account for incorrectly rotated effects.", "float" , "0.0");
 
   %behavior.addBehaviorField("mountEffect", "If true, mount effect to this object.", bool, false);
}

function onKeyHold_PlayEffect::onAddToScene(%this, %scenegraph) 
{   
   if(!%this.enable) return;
   if(!%this.debugMode) echo("onKeyHold_PlayEffect::onAddToScene( ", %this,  " ) @ ", getSimTime() );
   
   moveMap.unbindMulti( getWord( %this.effectKey , 0 ),  getWord( %this.effectKey , 1 ),  %this, "onEffectKey" );
}

function onKeyHold_PlayEffect::onEffectKey(%this, %val) 
{
   if(!%this.enable) return;
   if(!%this.debugMode) echo("onKeyHold_PlayEffect::onEffectKey( ", %this,  " ) @ ", getSimTime() );
   
   
   if (%val )
   {
      %this.lastEffect = %this.playEffect();
   }
   else
   {
      %this.lastEffect.safeDelete();
   }
}

function onKeyHold_PlayEffect::playEffect( %this )
{      
   if(!%this.debugMode) echo("onKeyHold_PlayEffect::playEffect( ", %this,  " ) @ ", getSimTime() );
   %found = false;

   %file = findFirstFile("~/*"@%this.EffectFile); 

   if(!%this.debugMode) echo("%this.EffectFile: ", %this.EffectFile );   
   if(!%this.debugMode) echo("%file: ", %file );   
   
   if(%file $= "") return;   
  
   %owner = %this.owner; 

   %theEffect = new t2dParticleEffect() 
   {
      scenegraph = %this.owner.getScenegraph(); 
   };

   if(!%this.debugMode) echo("%theEffect: ", %theEffect ); 
   if(!%this.debugMode) echo("%this.owner.getScenegraph(): ", %this.owner.getScenegraph() ); 

   %theEffect.loadEffect( %file );
   %theEffect.setEffectLifeMode("INFINITE", 0.0);
   %theEffect.setEffectCollisionStatus(false);
   
   if(%this.trackRotation) 
   {  
      
      if(%this.mountEffect)
      {
         %rotation = %this.rotationOffset;
      }
      else
      {
         %rotation = %owner.getRotation() + %this.rotationOffset;
      }
      
      %theEffect.setRotation(%rotation); 
   }   
   
   if(%this.mountEffect)
   {  
      %theEffect.mount(%this.owner, %this.effectOffset,
                       0, true, false, false, false);  
   }
 
   else
   {
      %position = %owner.getWorldPoint(%this.effectOffset);  
      %theEffect.setPosition(%position);
   }
   %theEffect.ignoreMe = true;  
   %theEffect.playEffect();
      
   return %theEffect;
}