// Create Resource Descriptor
$instantResource = new ScriptObject()
{
	Class          = "__RESOURCENAME__";
	Name           = "__RESOURCENAME__";
	User           = "TGB";
	LoadFunction   = "__RESOURCENAME__::LoadResource";
	UnloadFunction = "__RESOURCENAME__::UnloadResource";

	//__BEHAVIOR_LIST_ENABLE__behaviors = __BEHAVIORS_LIST__;

};

$instantResource.Data = new SimGroup() 
{
	canSaveDynamicFields = "1";
};

// Load Resource Function - Hooks into game
function __RESOURCENAME__::LoadResource( %this )
{
   // Load The Behaviors 
   %behaviorList = %this.behaviors;
   %count = getWordCount(%behaviorList);
   for (%i = 0; %i < %count; %i++)
   {
      %behavior = getWord(%behaviorList, %i);
      %file = "./behaviors/"@%behavior@".cs";
      exec( %file );
   }
}

// Unload Resource Function - Remove from game Sim.
function __RESOURCENAME__::UnloadResource( %this )
{
   // Unregister the behaviors
   %behaviorList = %this.behaviors;
   behaviorManager.unregisterBehaviors( %behaviorList);
   
   // We must clean up all the mess we've made in the Sim.
   if( isObject( %this.Data ) && %this.Data.GetCount() > 0 )
   {      
      while( %this.Data.getCount() > 0 )
      {
         %datablockObj = %this.Data.getObject( 0 );
         %this.Data.remove( %datablockObj );
         if( isObject( %datablockObj ) )
         %datablockObj.delete();
      }
   }   
}