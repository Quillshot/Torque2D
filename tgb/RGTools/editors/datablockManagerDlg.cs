//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

function datablockManagerDlg::onWake( %this )
{
   
   curManagedDBList.refresh();     
 
   %this.updateButtonStatuses();
}

function curManagedDBList::refresh(%this)
{
   %this.clearItems();
   
   %managedDBCount = $managedDatablockSet.getCount();
   
   for( %count = 0; %count < %managedDBCount; %count++)
   {
      %this.addItem($managedDatablockSet.getObject(%count).getName());
   }

   %this.setSelected(0);  
}

function datablockManagerDlg::updateButtonStatuses(%this)
{
   %num = curManagedDBList.getSelectedItem();
   %sel =  curManagedDBList.getItemText( %num );
   %textEditVal = DBMgr_DBNameTextEdit.getValue();
  
   if( %sel $= "" )
   {
      DBMgr_DeleteButton.setActive(false);
   }
   else  
   {
      DBMgr_DeleteButton.setActive(true);
   }
   
   if( (%sel !$= "") && 
       (%textEditVal !$= "") && 
       (%textEditVal !$= %sel) && 
       (!isObject(%textEditVal)) )
   {
      DBMgr_RenameButton.setActive(true);
      DBMgr_DuplicateButton.setActive(true);
   }
   else  
   {
      DBMgr_RenameButton.setActive(false);
      DBMgr_DuplicateButton.setActive(false);
   }
  
   if(%this.isAwake()) %this.schedule( 100, updateButtonStatuses );
}


function curManagedDBList::onSelect( %this )
{
   %num = %this.getSelectedItem();
   error("curManagedDBList clicked => ", %this.getItemText( %num ));
   
   DBMgr_DBNameTextEdit.text = %this.getItemText( %num );
}

function DBMgr_DeleteButton::onClick( %this )
{
   %num = curManagedDBList.getSelectedItem();
   %sel =  curManagedDBList.getItemText( %num );
   %textEditVal = DBMgr_DBNameTextEdit.getValue();
   
//   $ignoredDatablockSet.add( %sel );
   
//   (%sel).delete();   
//   curManagedDBList.refresh();
   
   LBProjectObj.removeDatablock( %sel, true );
   curManagedDBList.refresh();
   (%sel).delete();      
}

function DBMgr_RenameButton::onClick( %this )
{
   %num = curManagedDBList.getSelectedItem();
   %sel =  curManagedDBList.getItemText( %num );
   %textEditVal = DBMgr_DBNameTextEdit.getValue();
   
   (%sel).setName(%textEditVal);   
   curManagedDBList.refresh();
}

function DBMgr_DuplicateButton::onClick( %this )
{
   %num = curManagedDBList.getSelectedItem();
   %sel =  curManagedDBList.getItemText( %num );
   %textEditVal = DBMgr_DBNameTextEdit.getValue();
   
   %newDB = duplicateDatablock( (%sel).getID(), %textEditVal );  
   LBProjectObj.addDatablock( %newDB, true );
   curManagedDBList.refresh();
}

function duplicateDatablock( %oldDB, %newDBName )
{
   %tmpFile = "./dbgen_tmp_" @ getSimTime() @".cs";
   %tmpFile = expandFileName(%tmpFile) ;
   %result = %oldDB.save( %tmpFile , false);
  
   %tmpTokens = readFile( %tmpFile );
   
   %fieldCount = 0;
   
   while( "" !$= %tmpTokens ) 
   {
      %tmpTokens = nextToken( %tmpTokens , "myToken" , "\n" );
      
      %myToken = trim( %myToken );
      
      // Skip begin/end lines
      if( -1 != strstr( %myToken , "OBJECT WRITE BEGIN" ) ) continue;
      if( -1 != strstr( %myToken , "OBJECT WRITE END" ) ) continue;      
      if( -1 != strstr( %myToken , "};" ) ) continue;      
      
      %myToken = strreplace( %myToken , ";" , "" );
      
      // Extract object type and object name
      if( 0 == strpos( %myToken , "new" ) ) 
      {
         %myToken = strreplace( %myToken , "(" , " " );
         %myToken = strreplace( %myToken , ")" , " " );
         %oldDBType = getWord( %myToken, 1 );
         continue;
      }

      // Extract config DB (if any)
      if( -1 != strstr( %myToken , "config =" ) ) 
      {
         %myToken = strreplace( %myToken , "\"" , "" );
         %config = getWord( %myToken , 2 );
         continue;
      }
      
      // Extract fields
      %fieldName[%fieldCount] = getWord( %myToken , 0 );
      %fieldValue[%fieldCount] = getWords( %myToken , 2 );
      %fieldCount++;
   }
   
   // Specify DB Type
   %DBType = %oldDBType;
   
   // Generate a NEW DB
   %DBScript = "new " @ %DBType @ "( " @ %newDBName ;
   if( ("" !$= %config) && (%config !$= %newDBName) ) %DBScript = %DBScript @ " : " @ %config;
   %DBScript = %DBScript @ " )\n" ;
   %DBScript = %DBScript @ "{\n" ;
   
   for( %count = 0; %count < %fieldCount; %count++ )
   {
      %DBScript = %DBScript @ "   " @ %fieldName[%count] @ " = " @ %fieldValue[%count] @ ";\n";
   }
   
   if( !%sizeSet )
   {
      %DBScript = %DBScript @ "   size = \"" @ %oldDBSize @ "\";\n";
   }
   
   %DBScript = %DBScript @ "};\n" ;
    
   writeFile( %tmpFile, %DBScript );
   exec(%tmpFile);
   
   %result = fileDelete( %tmpFile );
   
   return (%newDBName).getID();
}
