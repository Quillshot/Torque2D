//--------------------------------------------
// oggMixedStreamSource.h
// header for audio stream dummy class, basicly
// an audio buffer filled remotely
//
//--------------------------------------------

#ifndef _OGGMIXEDSTREAMSOURCE_H_
#define _OGGMIXEDSTREAMSOURCE_H_

#ifndef _AUDIOSTREAMSOURCE_H_
#include "audio/audioStreamSource.h"
#endif

#define BUFFERCNT 128

class OggMixedStreamSource: public AudioStreamSource
{
public:
      OggMixedStreamSource(const char *filename);
      virtual ~OggMixedStreamSource();

      virtual bool initStream();
      virtual bool updateBuffers();
      virtual void freeStream();

      ALuint GetAvailableBuffer();
      bool QueueBuffer(ALuint BufferID);
      void PlayStream();
      bool isPlaying();

      virtual F32 getElapsedTime();

      virtual F32 getTotalTime()
      {
         return 1.0f;
      }

private:
      ALuint mBufferList[BUFFERCNT];
      bool m_fBufferInUse[BUFFERCNT];
      F32 mUnqueuedTime;
      F32 mTotalQueuedTime;

      bool bBuffersAllocated;

      void clear();
};

#endif // _OGGMIXEDSTREAMSOURCE_H_
