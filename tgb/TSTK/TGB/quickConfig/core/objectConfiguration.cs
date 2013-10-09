//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------
/*
Description: Apply the QC configuration attributes to the specified object as defined for the type %typeName.
*/
function RGQC::applyQC( %this, %obj, %typeName  )
{   
   ////
   //   0. Set graph group
   ////
   %obj.setGraphGroup( %this.Types[%typeName]  );
   
   %this.config_collidesWith(%obj, %typeName);
   %this.config_damagePoints(%obj, %typeName);
   %this.config_energyPoints(%obj, %typeName);
   %this.config_collisionResponse(%obj, %typeName);
   %this.config_immovable(%obj, %typeName);
   %this.config_layer(%obj, %typeName);
   
   %obj.quickConfigType = %typeName;
  
   ////
   //   Add this object to its group set
   ////
   (%this.set[%typeName]).add(%obj);
}

function RGQC::reApplyQC( %this, %obj  )
{   
   %typeName = %obj.quickConfigType;
   
   if( %typeName $= "" ) return;
   
   %this.applyQC( %obj, %typeName );
}
