///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------
////
//   INITIALIZATION and SHUTDOWN
////
/*
Description: This routine must be run before using the RGQC system.
*/
function RGQC::Prolog()
{
   RGQC::Epilog();
   if(!isObject(RGQC)) new ScriptObject(RGQC);
}

/*
Description: This routine should be run when you are completely done with the RGQC system.  It does cleanup.
*/
function RGQC::Epilog()
{
   if(isObject(RGQC)) RGQC.schedule(0,delete);
}

/*
Description: Internal only.  Congfigures RGQC system when the RGQC object is first created.
 */
function RGQC::onAdd( %this )
{   
   //echo("RGQC::onAdd( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   %this.Settings[Debug] = true; 

   // Init various $RGQC::* settings
   %this.Settings[TypesMask] = 0;
   %this.Settings[KnownTypes] = "";
}