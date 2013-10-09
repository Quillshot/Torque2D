//--- OBJECT WRITE BEGIN ---
new ScriptObject(event_RoamingGamerAtoms_Input_onKeyUp) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Input Event ->";
      description = "When a key is pressed";
      details_atomName = "onKeyUp";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "event";
      details_subCategory = "Input";
      friendlyName = "onKeyUp() ->";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"actionKey\",   \"Key that is pressed to cause an action.\", keybind, \"Keyboard space\" );";
      segmentonAddToScene = "4";
      segmentonAddToScene_0 = "   moveMap.bindCmd( getWord(%this.actionKey, 0), ";
      segmentonAddToScene_1 = "                    getWord(%this.actionKey, 1), ";
      segmentonAddToScene_2 = "                    \"\",";
      segmentonAddToScene_3 = "                    %this.getId()@\".executeAction();\" );";
      segments = "behaviorFields\tonAddToScene";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(event_RoamingGamerAtoms_Input_onKeyDown) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Input Event ->";
      description = "When a key is pressed";
      details_atomName = "onKeyDown";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "event";
      details_subCategory = "Input";
      friendlyName = "onKeyDown() ->";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"actionKey\",   \"Key that is pressed to cause an action.\", keybind, \"Keyboard space\" );";
      segmentonAddToScene = "4";
      segmentonAddToScene_0 = "   moveMap.bindCmd( getWord(%this.actionKey, 0), ";
      segmentonAddToScene_1 = "                    getWord(%this.actionKey, 1), ";
      segmentonAddToScene_2 = "                    %this.getId()@\".executeAction();\", ";
      segmentonAddToScene_3 = "                    \"\" );";
      segments = "behaviorFields\tonAddToScene";
};
//--- OBJECT WRITE END ---
//--- OBJECT WRITE BEGIN ---
new ScriptObject(event_RoamingGamerAtoms_Input_onInput) {
   canSaveDynamicFields = "1";
   class = "behaviorAtom";
      behaviorType = "Input Event ->";
      description = "When a key is pressed";
      details_atomName = "onInput";
      details_category = "Roaming Gamer Atoms";
      details_eventAction = "event";
      details_subCategory = "Input";
      friendlyName = "onInput() (multibind) ->";
      segmentbehaviorFields = "1";
      segmentbehaviorFields_0 = "   %behavior.addBehaviorField( \"actionKey\",   \"Key that is pressed to cause an action.\", keybind, \"Keyboard space\" );";
      segmentonAddToScene = "2";
      segmentonAddToScene_0 = "   // Note: Assumes executeAction will be modified to accept a variable %val indicating whether a key is pressed/released.";
      segmentonAddToScene_1 = "   moveMap.bindMulti( getWord(%this.actionKey, 0), getWord(%this.actionKey, 1), %this, \"executeAction\" );";
      segments = "behaviorFields\tonAddToScene";
};
//--- OBJECT WRITE END ---
