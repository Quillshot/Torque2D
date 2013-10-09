if (!isObject(copyWorldLimitFromCamera))
{
   %behavior = new BehaviorTemplate(copyWorldLimitFromCamera)
   {
      friendlyName = "Copy World Limit From Camera";
      behaviorType = "03 - Scene and Camera";
      description  = "Copy camera area and use as world limit.";
   };
   
   %behavior.addValidObjectClass("t2dSceneObject");
   
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging output for this behavior.", bool, false);
   
   %behavior.addBehaviorField( "WLMode", "World Limit Mode", "enum", "null", "off\tclamp\tnull\tbounce\tsticky\tkill");
   //%behavior.addBehaviorField( "WLMode", "World Limit Mode", "enum", "NULL", "OFF\tCLAMP\tNULL\tBOUNCE\tSTICKY\tKILL");
   
   %behavior.addBehaviorField( "Multiply_Area", "Multiply (initial) area by this.", "point2f", "1.0 1.0");

   %behavior.addBehaviorField( "Add_Margin", "Add this margin to the world limit extent.", "point2f", "0.0 0.0");
   
   %behavior.addBehaviorField("Add_Size", "Add object size to world limit bounds.", bool, true);
}

//
// Behavior Methods and Callbacks
//
function copyWorldLimitFromCamera::onAddToScene(%this, %scenegraph) 
//function copyWorldLimitFromCamera::onAdd(%this) 
{
   if($LevelEditorActive) return;
   if(!%this.enable) return;
   %area = sceneWindow2D.getCurrentCameraArea();
   %position = sceneWindow2D.getCurrentCameraPosition();

   if(%this.debugMode) echo(%area);
   if(%this.debugMode) echo(%position);
   
   %limitMin = getWords( %area, 0, 1 );
   %limitMax = getWords( %area, 2, 3 );

   %limitMin = t2dVectorAdd( %limitMin, %position );
   %limitMax = t2dVectorAdd( %limitMax, %position );

   %limitMin = t2dVectorMult( %limitMin, %this.Multiply_Area);
   %limitMax = t2dVectorMult( %limitMax, %this.Multiply_Area);
   
   %limitMin = t2dVectorSub( %limitMin, %this.Add_Margin);
   %limitMax = t2dVectorAdd( %limitMax, %this.Add_Margin);
   
   if( %this.Add_Size ) 
   {
      %size = %this.owner.getSize();
      %limitMin = t2dVectorSub( %limitMin, %size);
      %limitMax = t2dVectorAdd( %limitMax, %size);
   }
   
   %this.owner.setWorldLimitMode( %this.WLMode );

   %this.owner.setWorldLimitMinX( getWord( %limitMin , 0 ) );
   %this.owner.setWorldLimitMinY( getWord( %limitMin , 1 ) );
   %this.owner.setWorldLimitMaxX( getWord( %limitMax , 0 ) );
   %this.owner.setWorldLimitMaxY( getWord( %limitMax , 1 ) );
   
   %wrapBehavior = %this.owner.getBehavior( "onWorldLimitWrap" );
   
   // If the wrap behavior is present and enabled, force mode to "NULL"
   if(isObject(%wrapBehavior) && %wrapBehavior.enable)
   {
      %this.owner.setWorldLimitMode( "NULL" );
   }
}
