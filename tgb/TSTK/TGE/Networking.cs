//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

//// 
// Server to Client - Action Map push/pop
////
/*
Description: Push the specified action map (%mapName) on a numbered %client.
Arguments:
EFM - EFM 
Returns: EFM 
*/
function pushActionMapOnClient( %client , %mapName ) {
	commandToClient( %client, 'pushActionMap', %mapName );
}

/*
Description: Client command that goes with pushActionMapOnClient()
*/
function clientCmdPushActionMap( %mapName ) {
    if(!isObject(%mapMap)) return;
	%mapMap.getID().push();
}


/*
Description: Pop the specified action map (%mapName) on a numbered %client.
*/
function popActionMapOnClient( %client , %mapName ) {
	commandToClient( %client, 'popActionMap', %mapName );
}

/*
Description: Client command that goes with popActionMapOnClient()
*/
function clientCmdPopActionMap( %mapName ) {
    if(!isObject(%mapMap)) return;
	%mapMap.getID().pop();
}

//// 
// Server to Client - Activate/Deactivate Package
////
/*
Description: Activate the specified package on a numbered %client.
*/
function activatePackageOnClient( %client , %packageName ) {
	commandToClient( %client, 'activatePackage', %packageName );
}

/*
Description: Client command that goes with activatePackageOnClient()
*/
function clientCmdActivatePackage( %packageName ) {
	activatePackage( %packageName  );
}


/*
Description: Deactivate the specified package on a numbered %client.
*/
function deactivatePackageOnClient( %client , %packageName ) {
	commandToClient( %client, 'deactivatePackage', %packageName );
}

/*
Description: Client command that goes with deactivatePackageOnClient()
*/
function clientCmdDeactivatePackage( %packageName ) {
	deactivatePackage( %packageName  );
}




