//------------------------------------------------------
// Copyright, Roaming Gamer, LLC.
//------------------------------------------------------

// Caution: This tool can crash the editor.  Save your work before using it.
// 
// After running, save the contents of your copy-buffer to a file and save that file
// with a .csv extension.  Then you can view the results in Excel or another
// spreadsheet program that can read comma separated values

function rldanalysis()
{
   exec("./analysis.cs");
}



// behavior usage analysis
function bua( %scenegraph, %levelFileName )
{
   echo("in bua!!!!");
   new SimGroup( bua_Group );
   
   %sceneGraph.foreach( analyzeUsedBehaviors, true );
   
   bua_Group.buaSummarize( %levelFileName );

   bua_Group.delete();
}

function t2dSceneObject::analyzeUsedBehaviors( %obj )
{   
   %behaviorCount = %obj.getBehaviorCount();

   if(%behaviorCount == 0) return;
   
   for(%nCount =0; %nCount < %behaviorCount; %nCount++)
   {
      %behavior = %obj.getBehaviorByIndex( %nCount );
      
      %template = %behavior.template;

      %behaviorName  = (%template).getName();      
      
      %buaObjName = "bua_" @ %behaviorName @ "_bua";
      
      if(!isObject( %buaObjName ))
      {
         new SimObject( %buaObjName )
         {
            timesUsed = 0;
            behaviorName  = (%template).getName();
            behaviorType  = (%template).behaviorType;
            friendlyName  = (%template).friendlyName;
            description   = (%template).description;
         };
         bua_Group.add( %buaObjName );         
      }
      ( %buaObjName ).timesUsed++;
      
      echo("in analyzeUsedBehaviors!!!! ==>", %behaviorName);      
   }   
   %behaviorCount = %obj.getBehaviorCount();
}

function SimGroup::buaSummarize( %group, %levelFileName )
{
   %count = %group.getCount();
   
   %tmpData = "";

   for(%nCount = 0; %nCount < %count; %nCount++)
   {
      %behavior = %group.getObject( %nCount );
      
      %tmpData2 = 
         %levelFileName @ "," @ 
         %behavior.timesUsed @ "," @ 
         %behavior.behaviorName @ "," @ 
         %behavior.behaviorType @ "," @ 
         %behavior.friendlyName;
      echo(%tmpData2);
      %tmpData =  %tmpData NL %tmpData2; 
   }
   %tmpData = trim( %tmpData );
   //echo(%tmpData);
   setClipboard( %tmpData );
}

