//--------------------------------------
//
// This class is basically a buffer that is filled from
// the ogg stream the theoraplayer has open
//
//--------------------------------------

#include "audio/oggMixedStreamSource.h"

OggMixedStreamSource::OggMixedStreamSource(const char *filename)
{
   bIsValid = false;
   bBuffersAllocated = false;
   for(int i = 0; i < BUFFERCNT; i++)
   {
      mBufferList[i] = 0;
      m_fBufferInUse[i] = false;
   }


   mHandle = NULL_AUDIOHANDLE;
   mSource = NULL;

   mFilename = filename;
   mPosition = Point3F(0.f,0.f,0.f);

   dMemset(&mDescription, 0, sizeof(Audio::Description));
   mEnvironment = 0;
   mPosition.set(0.f,0.f,0.f);
   mDirection.set(0.f,1.f,0.f);
   mPitch = 1.f;
   mScore = 0.f;
   mCullTime = 0;

   bFinishedPlaying = false;
   bIsValid = false;
   bBuffersAllocated = false;
   
   mUnqueuedTime = 0.f;
   mTotalQueuedTime = 0.f;
}

OggMixedStreamSource::~OggMixedStreamSource()
{
   if(bIsValid)
      freeStream();
}

bool OggMixedStreamSource::initStream()
{
   alSourceStop(mSource);
   alSourcei(mSource, AL_BUFFER, 0);

   // Clear Error Code
   alGetError();

   alGenBuffers(BUFFERCNT, mBufferList);
   if (alGetError() != AL_NO_ERROR)
      return false;

   bBuffersAllocated = true;

   alSourcei(mSource, AL_LOOPING, AL_FALSE);

   bIsValid = true;

   return true;
}

bool OggMixedStreamSource::updateBuffers()
{
   // buffers are updated from theora player
   return true;
}

void OggMixedStreamSource::freeStream()
{
   // free the al buffers
   if(bBuffersAllocated)
   {
      alSourceStop(mSource);
      alSourcei(mSource, AL_BUFFER, 0);
      alDeleteBuffers(BUFFERCNT, mBufferList);

      alGetError();

      for(int i = 0; i < BUFFERCNT; i++)
      {
         mBufferList[i] = 0;
         m_fBufferInUse[i] = false;
      }

      bBuffersAllocated = false;
   }
}

ALuint OggMixedStreamSource::GetAvailableBuffer()
{
   if(!bBuffersAllocated)
      return 0;

   // test for unused buffers
   for(int i = 0; i < BUFFERCNT; i++)
   {
      if(!m_fBufferInUse[i])
      {
         m_fBufferInUse[i] = true;
         return mBufferList[i];
      }
   }

   // test for processed buffers
   ALint         processed;
   alGetSourcei(mSource, AL_BUFFERS_PROCESSED, &processed);

   if(!processed)
      return 0; // no available buffers

   ALuint BufferID;
   alSourceUnqueueBuffers(mSource, 1, &BufferID);
   
   // Record the playtime.
   
   ALint bufferFreq;
   ALint bufferSize;
   ALint bufferChannels;
   ALint bufferBits;
   
   alGetBufferi( BufferID, AL_FREQUENCY, &bufferFreq );
   alGetBufferi( BufferID, AL_SIZE, &bufferSize );
   alGetBufferi( BufferID, AL_CHANNELS, &bufferChannels );
   alGetBufferi( BufferID, AL_BITS, &bufferBits );
   
   mUnqueuedTime += F32( bufferSize ) / F32( ( bufferBits / 8 ) * bufferChannels * bufferFreq );

   /* Don't check for error.  We're on a thread and OpenAL's error state is global.
   if (alGetError() != AL_NO_ERROR)
      return 0; // something went wrong..
   */

   return BufferID;
}

bool OggMixedStreamSource::QueueBuffer(ALuint BufferID)
{
   alSourceQueueBuffers(mSource, 1, &BufferID);

   ALint bufferFreq;
   ALint bufferSize;
   ALint bufferChannels;
   ALint bufferBits;
   
   alGetBufferi( BufferID, AL_FREQUENCY, &bufferFreq );
   alGetBufferi( BufferID, AL_SIZE, &bufferSize );
   alGetBufferi( BufferID, AL_CHANNELS, &bufferChannels );
   alGetBufferi( BufferID, AL_BITS, &bufferBits );

   mTotalQueuedTime += F32( bufferSize ) / F32( ( bufferBits / 8 ) * bufferChannels * bufferFreq );

   return true;
}

bool OggMixedStreamSource::isPlaying()
{
   ALint state;
   alGetSourcei( mSource, AL_SOURCE_STATE, &state );
   
   return ( state == AL_PLAYING );
}

F32 OggMixedStreamSource::getElapsedTime()
{
   ALfloat sourcePos = 0;
   alGetSourcef( mSource, AL_SEC_OFFSET, &sourcePos );
   return sourcePos + mUnqueuedTime;
}
