///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

// Load Core Scripts
for(%file = findFirstFile("./core/*.cs"); %file !$= ""; %file = findNextFile("./core/*.cs"))
{
   exec(%file);
}

// Load Scripts For Individual Settings
for(%file = findFirstFile("./settings/*.cs"); %file !$= ""; %file = findNextFile("./settings/*.cs"))
{
   exec(%file);
}
