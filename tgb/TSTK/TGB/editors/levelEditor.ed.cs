//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

package RG_levelEditorPackage 
{

/*
Description: Overloaded to capture current object selection in global $TSTK::CurrentlySelectedObject
*/
function LevelBuilderSceneEdit::onAcquireObject(%this, %object)
{   
   $TSTK::CurrentlySelectedObject = %object;
   Parent::onAcquireObject(%this, %object);
}

/*
Description: Overloaded to capture current object de-selection in global $TSTK::CurrentlySelectedObject
*/
function LevelBuilderSceneEdit::onRelinquishObject(%this, %object)
{   
   $TSTK::CurrentlySelectedObject  = "";
   Parent::onRelinquishObject(%this, %object);
}

/*
Description: Returns current selection object(s).
*/
function getTGBLevelEditorCurrentSelection()
{
   return $TSTK::CurrentlySelectedObject;
}

};

activatePackage(RG_levelEditorPackage);