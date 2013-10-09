if (!isObject(onDestroyed_DoAreaDamage)) 
{
   %behavior = new BehaviorTemplate(onDestroyed_DoAreaDamage)
   {
      friendlyName = "onDestroyed() -> Do Area Damage";
      behaviorType = "05 - Damage and Energy";
      description  = "This object damages other objects in the area when it is destroyed.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   
   %behavior.addBehaviorField( "Damage", "Do this much damage to objects in a specified radius.", float, 0.0);
   %behavior.addBehaviorField( "Damage_Groups", "Apply damage to objects in these graph groups.", "bitmask", "0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31");   
   %behavior.addBehaviorField( "Damage_Radius", "Radius to damage in.", float, 0.0);
   %behavior.addBehaviorField( "Damage_Falloff", "Damage falls off as specified.", ENUM, "ZERO", "ZERO\tLINEAR\tLOG");
   %behavior.addBehaviorField( "Damage_Delay", "Wait this many milliseconds before applying damage to objects.", "integer", 0);
   
   
}

function onDestroyed_DoAreaDamage::onDestroyed(%this) 
{
   if(!%this.enable) return;   
   echo("onDestroyed_DoAreaDamage::onDestroyed(" SPC %this SPC ")");
   
   %owner        = %this.owner.getID();
   %pickPosition = %owner.getPosition();
   %pickRadius   = %this.Damage_Radius;
   %sceneGraph   = %owner.getSceneGraph();
   %pickGroups   = %this.Damage_Groups;
   %pickBits     = bits( %pickGroups );
   
   if( (%this.Damage > 0) && (%this.Damage_Radius > 0))
   {
      %tmpTokens = %sceneGraph.pickRadius( %pickPosition, %pickRadius, %pickBits);
      
      while( "" !$= %tmpTokens ) 
      {
         %tmpTokens = nextToken( %tmpTokens , "theToken" , " " );
         
         %theID = %theToken.getID();
         
         %isOwner = (%owner == %theID);
         
         %damageBehavior = %theID.getBehavior( "takesDamage" );
      
         if( ( isObject(%damageBehavior) ) && !%isOwner )
         {
            %this.applyAreaDamage( %damageBehavior, %theID,
                                   %this.Damage_Radius, %this.Damage, 
                                   %this.Damage_Falloff, %this.Damage_Delay );
         }
      }
     
   }
}

function onDestroyed_DoAreaDamage::applyAreaDamage( %this, %damageBehavior, 
                                                    %targetID,
                                                    %radius, %amount, %falloff, 
                                                    %delay )
{ 
   //echo("onDestroyed_DoAreaDamage::applyAreaDamage( ", %this, ", ", %damageBehavior, "  ) @ ", getSimTime() );
   
   %targetPos = %targetID.getPosition();
   %srcPos = %this.owner.getPosition();
   
   // 1
   %distance = t2dVectorDistance( %targetPos , %srcPos );
   
   // 2
   switch$( %falloff )
   {
   case "ZERO": // Damage fall-off by distance == 0
      %amount = %amount;
      
   case "LINEAR": // Damage fall-off by distance == ( radius - distance ) / radius
      %amount = %amount * ( ( %radius - %distance ) / %radius );
         
   case "LOG": // Damage fall-off by distance == 01 - log( distance ) / log( radius )
      if( %distance < 1 )
      {
         %amount = %amount;
      }
      else
      {
         %amount = %amount * ( 01 - mLog( %distance ) / mLog( %radius ) );            
      }
   }
   
   // 3
   %damageBehavior.schedule(%delay, applyDamage, %amount );  
}
