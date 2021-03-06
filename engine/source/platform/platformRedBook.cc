//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

#include "console/console.h"
#include "platform/platformRedBook.h"

//------------------------------------------------------------------------------
// Class: RedBookDevice
//------------------------------------------------------------------------------
RedBookDevice::RedBookDevice()
{
   mAcquired = false;
   mDeviceName = 0;
}

RedBookDevice::~RedBookDevice()
{
   delete [] mDeviceName;
}

//------------------------------------------------------------------------------
// Class: RedBook
//------------------------------------------------------------------------------
Vector<RedBookDevice *>    RedBook::smDeviceList(__FILE__, __LINE__);
RedBookDevice *            RedBook::smCurrentDevice;
char                       RedBook::smLastError[1024];

//------------------------------------------------------------------------------
void RedBook::init()
{
}

void RedBook::destroy()
{
   close();

   for( Vector<RedBookDevice*>::iterator i = smDeviceList.begin( ); i != smDeviceList.end( ); i++ ) {
	   delete *i;
   }

   smDeviceList.clear( );
}

//------------------------------------------------------------------------------
void RedBook::installDevice(RedBookDevice * device)
{
   smDeviceList.push_back(device);
}

RedBookDevice * RedBook::getCurrentDevice()
{
   return(smCurrentDevice);
}

U32 RedBook::getDeviceCount()
{
   return(smDeviceList.size());
}

const char * RedBook::getDeviceName(U32 idx)
{
   if(idx >= getDeviceCount())
   {
      setLastError("Invalid device index");
      return("");
   }
   return(smDeviceList[idx]->mDeviceName);
}

void RedBook::setLastError(const char * error)
{
   if(!error || dStrlen(error) >= sizeof(smLastError))
      setLastError("Invalid error string passed");
   else
      dStrcpy(smLastError, error);
}

const char * RedBook::getLastError()
{
   return(smLastError);
}

void RedBook::handleCallback(U32 type)
{
   switch(type)
   {
      case PlayFinished:
         Con::executef(2, "RedBookCallback", "PlayFinished");
         break;
   }
}

//------------------------------------------------------------------------------
bool RedBook::open(const char * deviceName)
{
   if(!deviceName)
   {
      setLastError("Invalid device name");
      return(false);
   }

   for(U32 i = 0; i < smDeviceList.size(); i++)
      if(!dStricmp(deviceName, smDeviceList[i]->mDeviceName))
         return(open(smDeviceList[i]));

   setLastError("Failed to find device");
   return(false);
}

bool RedBook::open(RedBookDevice * device)
{
   if(!device)
   {
      setLastError("Invalid device passed");
      return(false);
   }

   close();
   smCurrentDevice = device;
   return(smCurrentDevice->open());
}

bool RedBook::close()
{
   if(smCurrentDevice)
   {
      bool ret = smCurrentDevice->close();
      smCurrentDevice = 0;
      return(ret);
   }

   setLastError("No device is currently open");
   return(false);
}

bool RedBook::play(U32 track)
{
   if(!smCurrentDevice)
   {
      setLastError("No device is currently open");
      return(false);
   }
   return(smCurrentDevice->play(track));
}

bool RedBook::stop()
{
   if(!smCurrentDevice)
   {
      setLastError("No device is currently open");
      return(false);
   }
   return(smCurrentDevice->stop());
}

bool RedBook::getTrackCount(U32 * trackCount)
{
   if(!smCurrentDevice)
   {
      setLastError("No device is currently open");
      return(false);
   }
   return(smCurrentDevice->getTrackCount(trackCount));
}

bool RedBook::getVolume(F32 * volume)
{
   if(!smCurrentDevice)
   {
      setLastError("No device is currently open");
      return(false);
   }
   return(smCurrentDevice->getVolume(volume));
}

bool RedBook::setVolume(F32 volume)
{
   if(!smCurrentDevice)
   {
      setLastError("No device is currently open");
      return(false);
   }
   return(smCurrentDevice->setVolume(volume));
}

//------------------------------------------------------------------------------
// console methods
//------------------------------------------------------------------------------

ConsoleFunctionGroupBegin( Redbook, "Control functions for Redbook audio (ie, CD audio).")

ConsoleFunction(redbookOpen, bool, 1, 2, "(string device=NULL) Opens a redbook device"
				"@param device The device name (defaults to device 0)\n"
				"@return Returns true on success, false otherwise")
{
   if(argc == 1)
      return(RedBook::open(RedBook::getDeviceName(0)));
   else
      return(RedBook::open(argv[1]));
}

ConsoleFunction(redbookClose, bool, 1, 1, "() Close the current Redbook device.\n"
				"@return Returns true on success, false otherwise.")
{
   return(RedBook::close());
}

ConsoleFunction( redbookPlay, bool, 2, 2, "(int track) Play the selected track.\n"
				"@param track The track index\n"
				"@return Returns true on success, false otherwise (probably track not found)")
{
   return(RedBook::play(dAtoi(argv[1])));
}

ConsoleFunction( redbookStop, bool, 1, 1, "() Stop playing the current track."
				"@return Returns true on success, false otherwise")
{
   return(RedBook::stop());
}
ConsoleFunction(redbookGetTrackCount, S32, 1, 1, "() Return the number of tracks."
				"@return Returns the number of tracks as a nonnegative integer")
{
   U32 trackCount;
   if(!RedBook::getTrackCount(&trackCount))
      return(0);
   return(trackCount);
}

ConsoleFunction(redbookGetVolume, F32, 1, 1, "() Get the volume.\n"
				"@return Returns the volume as a floatingpoint value")
{
   F32 vol;
   if(!RedBook::getVolume(&vol))
      return(0.f);
   else
      return(vol);
}

ConsoleFunction(redbookSetVolume, bool, 2, 2, "(float volume) Set playback volume."
				"@param The desired volume\n"
				"@return Returns true on success, false otherwise (invalid value or device failure)")
{
   return(RedBook::setVolume(dAtof(argv[1])));
}

ConsoleFunction( redbookGetDeviceCount, S32, 1, 1, "() Get the number of redbook devices."
				"@return Returns the number of currently mounted redbook devices as an integer")
{
   return(RedBook::getDeviceCount());
}

ConsoleFunction( redbookGetDeviceName, const char *, 2, 2, "(int index) Get name of specified Redbook device.\n"
				"@param index The index of the desired device\n"
				"@return Returns the device's name as a string")
{
   return(RedBook::getDeviceName(dAtoi(argv[1])));
}

ConsoleFunction( redbookGetLastError, const char*, 1, 1, "() Get a string explaining the last redbook error.\n"
				"@return The error message as a string")
{
   return(RedBook::getLastError());
}

ConsoleFunctionGroupEnd( Redbook );
