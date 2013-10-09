//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

#ifndef _TORQUECONFIG_H_
#define _TORQUECONFIG_H_

//Hi, and welcome to the Torque Config file.
//
//This file is a central reference for the various configuration flags that
//you'll be using when controlling what sort of a Torque build you have. In
//general, the information here is global for your entire codebase, applying
//not only to your game proper, but also to all of your tools.
//
//This file also contains information which is used for various other needs,
//for instance, defines indicating what engine we're building, or what version
//we're at.

/// What engine are we running? The presence and value of this define are
/// used to determine what engine (TGE, T2D, etc.) and version thereof we're
/// running - useful if you're a content pack or other 3rd party code
/// snippet!
///
/// Version number is major * 1000 + minor * 100 + revision * 10.
#define TORQUE_GAME_ENGINE          1430

/// What's the name of your game? Used in a variety of places.
#define TORQUE_GAME_NAME            "Torque Game Builder"

/// Human readable version string.
#define TORQUE_GAME_VERSION_STRING  "Torque Game Builder 1.8"

/// Used to suppress unused compiler warnings.
#define TORQUE_UNUSED( arg )

/// Define me if you want to enable multithreading support.
#define TORQUE_MULTITHREAD

// Define me if this build is a tools build

#ifndef TORQUE_PLAYER
#  define TORQUE_TOOLS
#else
#  undef TORQUE_TOOLS
#endif

/// Define me if you want to enable the profiler.
///    See also the TORQUE_SHIPPING block below
//#define TORQUE_ENABLE_PROFILER

/// Define me to enable unicode support.
#define TORQUE_UNICODE

/// Define me to enable debug mode; enables a great number of additional
/// sanity checks, as well as making AssertFatal and AssertWarn do something.
/// This is usually defined by the build target.
//#define TORQUE_DEBUG

/// Define me if this is a shipping build; if defined I will instruct Torque
/// to batten down some hatches and generally be more "final game" oriented.
/// Notably this disables a liberal resource manager file searching, and
/// console help strings.
//#define TORQUE_SHIPPING

/// Define me to enable a variety of network debugging aids.
//#define TORQUE_DEBUG_NET

/// Modify me to enable metric gathering code in the renderers.
///
/// 0 does nothing; higher numbers enable higher levels of metric gathering.
//#define TORQUE_GATHER_METRICS 0

/// Define me if you want to enable debug guards in the memory manager.
///
/// Debug guards are known values placed before and after every block of
/// allocated memory. They are checked periodically by Memory::validate(),
/// and if they are modified (indicating an access to memory the app doesn't
/// "own"), an error is flagged (ie, you'll see a crash in the memory
/// manager's validate code). Using this and a debugger, you can track down
/// memory corruption issues quickly.
//#define TORQUE_DEBUG_GUARD

/// Define me if you want to enable debug guards on the FrameAllocator.
/// 
/// This is similar to the above memory manager guards, but applies only to the
/// fast FrameAllocator temporary pool memory allocations. The guards are only
/// checked when the FrameAllocator frees memory (when it's water mark changes).
/// This is most useful for detecting buffer overruns when using FrameTemp<> .
/// A buffer overrun in the FrameAllocator is unlikely to cause a crash, but may
/// still result in unexpected behavior, if other FrameTemp's are stomped.
//#define FRAMEALLOCATOR_DEBUG_GUARD

/// Define to disable Ogg Vorbis audio support. Libs are compiled without this by
/// default.
//#define TORQUE_NO_OGGVORBIS


/// This #define is used by the FrameAllocator to align starting addresses to
/// be byte aligned to this value. This is important on the 360 and possibly
/// on other platforms as well. Use this #define anywhere alignment is needed.
///
/// NOTE: Do not change this value per-platform unless you have a very good
/// reason for doing so. It has the potential to cause inconsistencies in 
/// memory which is allocated and expected to be contiguous.
///
///@ TODO: Make sure that everywhere this should be used, it is being used.
#define TORQUE_BYTE_ALIGNMENT 4


// Finally, we define some dependent #defines. This enables some subsidiary
// functionality to get automatically turned on in certain configurations.

#ifdef TORQUE_DEBUG
#  define TORQUE_GATHER_METRICS 0
#endif

#ifdef TORQUE_RELEASE
  // If it's not DEBUG, it's a RELEASE build, put appropriate things here.
#endif

#ifdef TORQUE_SHIPPING
 // TORQUE_SHIPPING flags here.
#else
   // enable the profiler by default, if we're not doing a shipping build
#  define TORQUE_ENABLE_PROFILER
#endif

#ifdef TORQUE_LIB
   #ifndef TORQUE_NO_OGGVORBIS
   #define TORQUE_NO_OGGVORBIS
   #endif
#endif

#ifdef TORQUE_TOOLS
#  define TORQUE_INSTANCE_EXCLUSION   "TorqueToolsTest"
#else
#  define TORQUE_INSTANCE_EXCLUSION   "TorqueTest"
#endif

#define DSO_VERSION (U32(Con::DSOVersion))

// This is defined in trial builds to implement trial code.
#define _WPB(x)

#ifdef TGB_TRIAL
#  include "drm/trialDefines.h"
#endif

// Someday, it might make sense to do some pragma magic here so we error
// on inconsistent flags.

#endif

