// This behavior generated by the Roaming Gamer Behavior Generator
//ACTION ATOM DETAILS
//   Category: 00 - Rapid Prototyping
//Subcategory: Coding
//Action Name: ModifiedCodeJar

//registerAtom( action | event | full, "Category", "SubCategory", "BehaviorName" );

if (!isObject(ModifiedCodeJar))
{
   %behavior = new BehaviorTemplate(ModifiedCodeJar) 
   { 

      friendlyName = "Modified Code Jar";
      behaviorType = "00 - Rapid Prototyping / Coding";
      description = "An empty code jar provding an easy place to place game code.";

   };
   %behavior.addBehaviorField(enable, "Enable this behavior.", bool, true);
   %behavior.addBehaviorField(debugMode, "Enable debugging (output) for this behavior.", bool, false);
   %behavior.addBehaviorField( "hideMe", "Automatically hide jar (object) when added to scene.", "bool", "true");
}

function ModifiedCodeJar::onAddToScene(%this, %scenegraph)
{
   if(!%this.enable) return;
   if(%this.debugMode) echo(%this.getName() @ "::onAddToScene()");

   //Action Atom Code:Code Jar
   %this.owner.setVisible( !%this.hideMe );
   %this.owner.setImmovable( true );
   
   %this.doIt();

}//onAddToScene


function ModifiedCodeJar::doIt(%this)
{   
   echo("############### IT WORKED ###################");
   echo("############### IT WORKED ###################");
   echo("############### IT WORKED ###################");
   echo("############### IT WORKED ###################");
}//onAddToScene

