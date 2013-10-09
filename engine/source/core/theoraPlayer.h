//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

#ifndef _THEORATEXTURE_H_
#define _THEORATEXTURE_H_

#ifndef _CONSOLE_H_
#include "console/console.h"
#endif

#ifndef _GTEXMANAGER_H_
#include "dgl/gTexManager.h"
#endif

#ifndef _GBITMAP_H_
#include "dgl/gBitmap.h"
#endif

#ifndef _O_THEORA_H_
#include "libtheora/include/theora/theora.h"
#endif

#ifndef _vorbis_codec_h_
#include "libvorbis/include/vorbis/codec.h"
#endif

#ifndef _PLATFORMTHREAD_H_
#include "platform/threads/thread.h"
#endif

#ifndef _OGGMIXEDSTREAMSOURCE_H_
#include "audio/oggMixedStreamSource.h"
#endif

#ifndef _VORBISSTREAMSOURCE_H_
#include "audio/vorbisStreamSource.h"
#endif


/// TheoraTexture decodes Ogg Theora files, and their audio.
///
/// TheoraTexture objects can be used similarly to TextureObjects. Just
/// set the video, call play(), and then refresh every frame to get the
/// latest video. Audio happens automagically.
///
/// @note Uses Theora and ogg libraries which are Copyright (C) Xiph.org Foundation
class TheoraTexture
{
private:
	Thread*				mPlayThread;
	
	/// Ogg and codec state for demux/decode.
	ogg_sync_state		mOggSyncState;
	ogg_page			   mOggPage;
	ogg_stream_state	mOggTheoraStream;
	ogg_stream_state	mOggVorbisStream;

	theora_info			mTheoraInfo;
	theora_comment		mTheoraComment;
	theora_state		mTheoraState;
		
	vorbis_info			mVorbisInfo;
	vorbis_comment		mVorbisComment;
	vorbis_dsp_state	mVorbisDspState;
	vorbis_block		mVorbisBlock;

	/// File handle for the theora file.
	Stream*				mTheoraFile;

	volatile bool		mReady;
	volatile bool		mPlaying;

	volatile bool		mHasVorbis;
	OggMixedStreamSource* mVorbisBuffer;
	AUDIOHANDLE			mVorbisHandle;
   AudioStreamSource* mVorbisStream;
   
   F32               mFPS;

   volatile F32      mCurrentTime;
   volatile U32      mStartTick;
   
   Semaphore*        mPlayThreadWakeEvent;
   Mutex*            mFrameQueueMutex;
   
   const char* mFileName;
   Audio::Description* mDesc;

	void init();

	bool parseHeaders();
	bool createVideoBuffers();
	bool createAudioBuffers(Audio::Description* desc);

   /// We precalculate adjusted YUV values for faster RGB conversion. This
   /// function is responsible for making sure they're present and valid.
	void generateLookupTables();
	void destroyTexture(bool restartOgg = false);
	
	void drawFrame();

	bool readyVideo(const F64 lastFrame, F64 &vBuffTime);
	bool readyAudio();
	
	bool demandOggPage();
	S32  bufferOggPage();
	S32  queueOggPage(ogg_page *page);

   /// Return the current playback time in seconds.
	F64 getTheoraTime();

	/// Background playback thread.
	static void playThread( void *udata );
	bool playLoop();

   struct FrameBuffer
   {
      bool mIsDirty;
      TextureHandle mTexture;
      
      FrameBuffer( GBitmap* bitmap )
         : mIsDirty( false ),
           mTexture( NULL, bitmap, true ) {}
   };

   FrameBuffer* mFrontBuffer;
   FrameBuffer* mBackBuffer;

public:
   TheoraTexture();
   TheoraTexture(const char *filename, bool play = false, Audio::Description* desc = NULL);
   ~TheoraTexture();

   operator TextureObject*()
   {
      return mFrontBuffer->mTexture;
   }

   bool setFile(const char*, bool play = false, bool restart = false, Audio::Description* desc = NULL);

   const bool isPlaying() const { return mPlaying; }
   const bool isReady() const { return mReady; }
   bool play();
   void stop();
   bool pause();

   /// Update the GL texture from the bitmap the background thread writes to.
   void refresh();

   const F64 getCurrentTime()
   {
      return getTheoraTime();
   }

   TextureHandle*	mTextureHandle;
};

#endif
