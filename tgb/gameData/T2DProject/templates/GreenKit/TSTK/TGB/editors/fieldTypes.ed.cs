//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

// Point3F. Three text edits validated to a number with 3 digits of precision.
BehaviorEditor::registerFieldType("Point3F", "createPoint3FGui");

function BehaviorFieldStack::createPoint3FGui(%this, %behavior, %fieldIndex)
{
   %fieldInfo = %behavior.template.getBehaviorField(%fieldIndex);
   %name = getField(%fieldInfo, 0);
   %description = %behavior.template.getBehaviorFieldDescription(%fieldIndex);
   
   %control = %this.createTextEdit3(%name, %name, %name, 3, %name, "R", "G", "B",%description);
   %edit1 = %control.findObjectByInternalName(%name @ "TextEdit0");
   %edit2 = %control.findObjectByInternalName(%name @ "TextEdit1");
   %edit3 = %control.findObjectByInternalName(%name @ "TextEdit2");
   %edit1.isProperty = true;
   %edit2.isProperty = true;
   %edit3.isProperty = true;
   %edit1.object = %behavior;
   %edit2.object = %behavior;
   %edit3.object = %behavior;
}



////
//   managedDB
////

// Object. Drop down list containing named objects of a specified type.
BehaviorEditor::registerFieldType("managedDB", "createManagedDBGui");

function BehaviorFieldStack::createManagedDBGui(%this, %behavior, %fieldIndex)
{
   %fieldInfo = %behavior.template.getBehaviorField(%fieldIndex);
   %name = getField(%fieldInfo, 0);
   %description = %behavior.template.getBehaviorFieldDescription(%fieldIndex);
   %objectType = %behavior.template.getBehaviorFieldUserData(%fieldIndex);
   
   // Get the set containing all imagemap datablocks
   

   %datablockSet = $managedDatablockSet;
   %datablockCount = %datablockSet.getCount();
   
   for(%i=0;%i<%datablockCount;%i++)
   {
      %db = %datablockSet.getObject(%i);
      
      // dont include ignored datablocks or non image maps
      if(!$ignoredDatablockSet.isMember(%db))
      {
         // rdbhack: also don't allow any datablocks named prevT2DImageMap or
         //  any datablocks with the same name as the sourcedb
         %dbName = %db.getName();
         
         %list = %list TAB %dbName;
      }
   }
   
   %list = trim(%list);

   %control = %this.createDropDownList(%name, %name, "", %list, %description, true, true);
   %listCtrl = %control.findObjectByInternalName(%name @ "DropDown");
   %listCtrl.object = %behavior;
}



////
//   t2dAnimationDatablock
////

// Object. Drop down list containing named objects of a specified type.
BehaviorEditor::registerFieldType("AnimationDB", "createAnimationDBGui");

function BehaviorFieldStack::createAnimationDBGui(%this, %behavior, %fieldIndex)
{
   %fieldInfo = %behavior.template.getBehaviorField(%fieldIndex);
   %name = getField(%fieldInfo, 0);
   %description = %behavior.template.getBehaviorFieldDescription(%fieldIndex);
   %objectType = %behavior.template.getBehaviorFieldUserData(%fieldIndex);
   
   // Get the set containing all imagemap datablocks
   

   %datablockSet = getT2DDatablockSet();
   %datablockCount = %datablockSet.getCount();
   
   for(%i=0;%i<%datablockCount;%i++)
   {
      %db = %datablockSet.getObject(%i);
      
      // dont include ignored datablocks or non image maps
      if(!$ignoredDatablockSet.isMember(%db) && %db.getClassName() $= "t2dAnimationDatablock")
      {
         // rdbhack: also don't allow any datablocks named prevT2DImageMap or
         //  any datablocks with the same name as the sourcedb
         %dbName = %db.getName();
         
         %list = %list TAB %dbName;
      }
   }
   
   %list = trim(%list);

   %control = %this.createDropDownList(%name, %name, "", %list, %description, true, true);
   %listCtrl = %control.findObjectByInternalName(%name @ "DropDown");
   %listCtrl.object = %behavior;
}


////
//   t2dImageMapDatablock
////

// Object. Drop down list containing named objects of a specified type.
BehaviorEditor::registerFieldType("ImageMapDB", "createImageMapDBGui");

function BehaviorFieldStack::createImageMapDBGui(%this, %behavior, %fieldIndex)
{
   %fieldInfo = %behavior.template.getBehaviorField(%fieldIndex);
   %name = getField(%fieldInfo, 0);
   %description = %behavior.template.getBehaviorFieldDescription(%fieldIndex);
   %objectType = %behavior.template.getBehaviorFieldUserData(%fieldIndex);
   
   // Get the set containing all imagemap datablocks
   

   %datablockSet = getT2DDatablockSet();
   %datablockCount = %datablockSet.getCount();
   
   for(%i=0;%i<%datablockCount;%i++)
   {
      %db = %datablockSet.getObject(%i);
      
      // dont include ignored datablocks or non image maps
      if(%db.getClassName() $= "t2dImageMapDatablock")
      {
         // rdbhack: also don't allow any datablocks named prevT2DImageMap or
         //  any datablocks with the same name as the sourcedb
         %dbName = %db.getName();
         
         if (%dbName !$= "prevT2DImageMap")
         {
            %list = %list TAB %dbName;
         }
      }
   }
   
   %list = trim(%list);

   %control = %this.createDropDownList(%name, %name, "", %list, %description, true, true);
   %listCtrl = %control.findObjectByInternalName(%name @ "DropDown");
   %listCtrl.object = %behavior;
}


// Bitmask Editor
BehaviorEditor::registerFieldType("bitmask", "createBitmaskGui");

function BehaviorFieldStack::createBitmaskGui(%this, %behavior, %fieldIndex)
{
   %fieldInfo = %behavior.template.getBehaviorField(%fieldIndex);
   %name = getField(%fieldInfo, 0);
   %description = %behavior.template.getBehaviorFieldDescription(%fieldIndex);
   
   %this.object = %behavior;
   %control = %this.createMask(%name, %name, 0, 31, %description);   
   %objectlist = %control.findObjectByInternalName("objectlist");
   
   %objectlist.isProperty = true;
   for( %count = 0; %count <= 31; %count++ )
   {
      %maskButton = %control.findObjectByInternalName("MaskButton" @ %count, true);
      %maskButton.isProperty=true;
   }
}


////
//   Function Button
////
BehaviorEditor::registerFieldType("functionButton", "createFunctionButton");

function BehaviorFieldStack::createFunctionButton(%this, %behavior, %fieldIndex)
{
   %fieldInfo = %behavior.template.getBehaviorField(%fieldIndex);
   %name = getField(%fieldInfo, 0);
   %description = %behavior.template.getBehaviorFieldDescription(%fieldIndex);
   %function = %behavior.template.getBehaviorFieldUserData(%fieldIndex);


   %control = %this.createCommandButton(%function, %description );
}

