// EFM - not the same as the OLD atom utilities
// This is all new and designed to enable the use of SO atoms for on demand
// generation of behaviors

function behaviorAtom::onAdd( %this )
{
   if(!isObject(atomSet)) new SimSet(atomSet);
   atomSet.add(%this);

   %eventAction = %this.details_eventAction;
   %category    = %this.details_category;
   %subCategory = %this.details_subCategory;
   %atomName    = %this.details_atomName;

   if(%eventAction $= "full")
   {   
      atomSet.atomArray[action,%category,%subCategory,%atomName] = %this; // For quick lookups!
      atomSet.atomArray[event,%category,%subCategory,%atomName] = %this; // For quick lookups!
   }
   else
   {
      atomSet.atomArray[%eventAction,%category,%subCategory,%atomName] = %this; // For quick lookups!
   }
   
   

   %this.registerAtom();
}

function behaviorAtom::registerAtom( %this )
{
   %eventAction = %this.details_eventAction;
   %category    = %this.details_category;
   %subCategory = %this.details_subCategory;
   %atomName    = %this.details_atomName;

   if( ( %eventAction $= "event" ) || ( %eventAction $= "action" ) )
   {
      // Add the category to the event category list if it isn't already there
      $RG_BehaviorGenerator::categories[%eventAction] = addUniqueField( $RG_BehaviorGenerator::categories[%eventAction], %category);

      // Add the subcategory to the event subcategory list if it isn't already there
      $RG_BehaviorGenerator::subCategories[%eventAction,%category] = 
         addUniqueField( $RG_BehaviorGenerator::subCategories[%eventAction,%category], %subCategory);

      //EFM move this sort elsewhere to speed things up
      $RG_BehaviorGenerator::subCategories[%eventAction,%category] = sortFields( $RG_BehaviorGenerator::subCategories[%eventAction,%category] );
   
      // Add the event to the (possibly new) categories list   
      $RG_BehaviorGenerator::atoms[%eventAction,%category,%subCategory] = 
         addUniqueField( $RG_BehaviorGenerator::atoms[%eventAction,%category,%subCategory], %atomName);

      //EFM move this sort elsewhere to speed things up
      $RG_BehaviorGenerator::atoms[%eventAction,%category,%subCategory] = sortFields( $RG_BehaviorGenerator::atoms[%eventAction,%category,%subCategory] );   

      return true;
   }
   else if( %eventAction $= "full" )
   {
      // Add as ACTION
      // Add the category to the event category list if it isn't already there
      $RG_BehaviorGenerator::categories[action] = addUniqueField( $RG_BehaviorGenerator::categories[action], %category);

      // Add the subcategory to the event subcategory list if it isn't already there
      $RG_BehaviorGenerator::subCategories[action,%category] = 
         addUniqueField( $RG_BehaviorGenerator::subCategories[action,%category], %subCategory);

      //EFM move this sort elsewhere to speed things up
      $RG_BehaviorGenerator::subCategories[action,%category] = sortFields( $RG_BehaviorGenerator::subCategories[action,%category] );
   
      // Add the event to the (possibly new) categories list   
      $RG_BehaviorGenerator::atoms[action,%category,%subCategory] = 
         addUniqueField( $RG_BehaviorGenerator::atoms[action,%category,%subCategory], %atomName);

      //EFM move this sort elsewhere to speed things up
      $RG_BehaviorGenerator::atoms[action,%category,%subCategory] = sortFields( $RG_BehaviorGenerator::atoms[action,%category,%subCategory] );   
/*
      // Add as EVENT
      // Add the category to the event category list if it isn't already there
      $RG_BehaviorGenerator::categories[event] = addUniqueField( $RG_BehaviorGenerator::categories[event], %category);

      // Add the subcategory to the event subcategory list if it isn't already there
      $RG_BehaviorGenerator::subCategories[event,%category] = 
         addUniqueField( $RG_BehaviorGenerator::subCategories[event,%category], %subCategory);

      //EFM move this sort elsewhere to speed things up
      $RG_BehaviorGenerator::subCategories[event,%category] = sortFields( $RG_BehaviorGenerator::subCategories[event,%category] );
   
      // Add the event to the (possibly new) categories list   
      $RG_BehaviorGenerator::atoms[event,%category,%subCategory] = 
         addUniqueField( $RG_BehaviorGenerator::atoms[event,%category,%subCategory], %atomName);

      //EFM move this sort elsewhere to speed things up
      $RG_BehaviorGenerator::atoms[event,%category,%subCategory] = sortFields( $RG_BehaviorGenerator::atoms[event,%category,%subCategory] );   
*/
      return true;
   }
   else
   {
      error("behaviorAtom::registerAtom() called with unkown value for %eventAction ==> ", %eventAction );
      return false;
   }
}
