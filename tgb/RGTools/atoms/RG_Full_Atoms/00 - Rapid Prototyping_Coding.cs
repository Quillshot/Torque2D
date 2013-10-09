//--- OBJECT WRITE BEGIN ---
new ScriptObject(full_00RapidPrototyping_Coding_CodeJar) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "00 - Rapid Prototyping / Coding";
      description = "An empty code jar provding an easy place to place game code.";
      details_atomName = "CodeJar";
      details_category = "00 - Rapid Prototyping";
      details_eventAction = "full";
      details_subCategory = "Coding";
      friendlyName = "Code Jar";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"hideMe\", \"Automatically hide jar (object) when added to scene.\", \"bool\", \"true\");";
      segmentonAddToScene = "2";
      segmentonAddToScene_0 = "   %this.owner.setVisible( !%this.hideMe );";
      segmentonAddToScene_1 = "   %this.owner.setImmovable( true );";
      segments = "behaviorFields\tonAddToScene";
};
//--- OBJECT WRITE END ---
