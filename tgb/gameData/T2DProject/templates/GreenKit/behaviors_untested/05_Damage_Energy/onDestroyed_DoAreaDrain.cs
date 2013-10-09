if (!isObject(onDestroyed_DoAreaDrain)) 
{
   %behavior = new BehaviorTemplate(onDestroyed_DoAreaDrain)
   {
      friendlyName = "onDestroyed() -> Do Area Drain";
      behaviorType = "05 - Damage and Energy";
      description  = "This object drains other objects in the area when it is destroyed.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   
   %behavior.addBehaviorField( "Drain", "Do this much drain to objects in a specified radius.", float, 0.0);
   %behavior.addBehaviorField( "Drain_Groups", "Apply drain to objects in these graph groups.", "bitmask", "0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31");   
   %behavior.addBehaviorField( "Drain_Radius", "Radius to drain in.", float, 0.0);
   %behavior.addBehaviorField( "Drain_Falloff", "Drain falls off as specified.", ENUM, "ZERO", "ZERO\tLINEAR\tLOG");
   %behavior.addBehaviorField( "Drain_Delay", "Wait this many milliseconds before applying drain to objects.", "integer", 0);
   
   
}

function onDestroyed_DoAreaDrain::onDestroyed(%this) 
{
   if(!%this.enable) return;   
   echo("onDestroyed_DoAreaDrain::onDestroyed(" SPC %this SPC ")");
   
   %owner        = %this.owner.getID();
   %pickPosition = %owner.getPosition();
   %pickRadius   = %this.Drain_Radius;
   %sceneGraph   = %owner.getSceneGraph();
   %pickGroups   = %this.Drain_Groups;
   %pickBits     = bits( %pickGroups );
   
   if( (%this.Drain > 0) && (%this.Drain_Radius > 0))
   {
      %tmpTokens = %sceneGraph.pickRadius( %pickPosition, %pickRadius, %pickBits);
      
      while( "" !$= %tmpTokens ) 
      {
         %tmpTokens = nextToken( %tmpTokens , "theToken" , " " );
         
         %theID = %theToken.getID();
         
         %isOwner = (%owner == %theID);
         
         %drainBehavior = %theID.getBehavior( "usesEnergy" );
      
         if( ( isObject(%drainBehavior) ) && !%isOwner )
         {
            %this.applyAreaDrain( %drainBehavior, %theID,
                                   %this.Drain_Radius, %this.Drain, 
                                   %this.Drain_Falloff, %this.Drain_Delay );
         }
      }
     
   }
}

function onDestroyed_DoAreaDrain::applyAreaDrain( %this, %drainBehavior, 
                                                    %targetID,
                                                    %radius, %amount, %falloff, 
                                                    %delay )
{ 
   //echo("onDestroyed_DoAreaDrain::applyAreaDrain( ", %this, ", ", %drainBehavior, "  ) @ ", getSimTime() );
   
   %targetPos = %targetID.getPosition();
   %srcPos = %this.owner.getPosition();
   
   // 1
   %distance = t2dVectorDistance( %targetPos , %srcPos );
   
   // 2
   switch$( %falloff )
   {
   case "ZERO": // Drain fall-off by distance == 0
      %amount = %amount;
      
   case "LINEAR": // Drain fall-off by distance == ( radius - distance ) / radius
      %amount = %amount * ( ( %radius - %distance ) / %radius );
         
   case "LOG": // Drain fall-off by distance == 01 - log( distance ) / log( radius )
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
   %drainBehavior.schedule(%delay, applyDrain, %amount );  
}
