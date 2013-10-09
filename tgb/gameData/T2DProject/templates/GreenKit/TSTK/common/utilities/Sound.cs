//------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------

$pref::Audio::masterVolume   = 1.0; //EFM will interfer with saved prefs!
$pref::Audio::channelVolume1 = 1.0; //EFM will interfer with saved prefs!
$pref::Audio::channelVolume2 = 1.0; //EFM will interfer with saved prefs!

new AudioDescription(musicEffect)
{
   volume      = 1.0;
   isLooping   = false;
   is3D        = false;
   type        = 1; //$musicAudioType;
};

new AudioDescription(loopingMusicEffect)
{
   volume      = 1.0;
   isLooping   = true;
   is3D        = false;
   type        = 1; //$musicAudioType;
};

new AudioDescription(audioEffect)
{
   volume      = 1.0;
   isLooping   = false;
   is3D        = false;
   type        = 2; //$effectsAudioType;
};
new AudioDescription(loopingAudioEffect)
{
   volume      = 1.0;
   isLooping   = true;
   is3D        = false;
   type        = 2; //$effectsAudioType;
};

/*
Description: Create an audioProfile with specified:
             %name - Name of new profile
       %sourceFile - Audio file to play
 %audioDescription - Any of these:
                     musicEffect - For single, non-repeating track of music.  (Music channel)
                     loopingMusicEffect - Same as above, but loops till stopped. (Music channel)
                     audioEffect - For single, non-repeating audio effect. (Effect channel)
                     loopingAudioEffect - Same as above, buyt loops till stopped. (Effect channel)
*/
function createAudioProfile( %name, %sourceFile, %audioDescription, %preload )
{
   if( %preload $= "" ) %preload = true;

   %sourceFile = expandFilename( %sourceFile );
   
   if( !isFile( %sourceFile ) )
   {
      error("createAudioProfile():: Can't find audio file: ", %sourceFile );
      return 0;
   }

   if( !isObject( %audioDescription ) )
   {
      error("createAudioProfile():: Invalid audio description! " );
      return 0;
   }
   
   %profile = new AudioProfile(%name)
   {
      filename    = %sourceFile;
      description = %audioDescription;
      preload     = %preload;
   };

   if( !isObject( %profile ) )
   {
      error("createAudioProfile():: Failed to create audio profile!" );
      return 0;
   }
   return %profile;
}
