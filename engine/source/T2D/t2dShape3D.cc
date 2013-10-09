//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//
// T2D Shape 3D
//-----------------------------------------------------------------------------

#include "dgl/dgl.h"
#include "console/consoleTypes.h"
#include "./t2dUtility.h"
#include "./t2dShape3D.h"

// T2D Debug Profiling.
#ifdef TORQUE_ENABLE_PROFILER
#include "platform/profiler.h"
#endif


//-----------------------------------------------------------------------------
// *** N O T E S ***
//
// The axis translation for T2D<->T3D is as follows:
//
//  x -> x
//  y -> z
//  z -> y
//-----------------------------------------------------------------------------


//----------------------------------------------------------------------------

IMPLEMENT_CONOBJECT(t2dShape3D);

//----------------------------------------------------------------------------


//-----------------------------------------------------------------------------
// Constructor.
//-----------------------------------------------------------------------------
t2dShape3D::t2dShape3D() :	T2D_Stream_HeaderID(makeFourCCTag('2','D','S','3'))
{
	// Reset Shape File.
	mShapeFile = StringTable->insert("");
	mAnimationName = StringTable->insert("");
	// Reset Shape Instance.
	mShapeInstance = NULL;
    // Reset Shape Thread.
    mShapeThread = NULL;
    // Reset Trigger Active.
    mTriggerActive = false;
    // Reset Detail.
    mShapeDetailLevel = 0;
    mShapeIntraDetailLevel = 0.0f;

    // Reset Shape Rotation.
    setShapeRotation( EulerF(0,0,0) );
	// Reset Shape Angular Velocity.
	setShapeAngularVelocity( EulerF(0,0,0) );
    // Reset Shape Offset.
    setShapeOffset( VectorF(0,0,0) );
    // Reset Shape Scale.
    setShapeScale( VectorF(1,1,1) );

   if (getDefaultConfig())
   {
      getDefaultConfig()->setDataField(StringTable->insert("detailLevel"), NULL, "0");
      getDefaultConfig()->setDataField(StringTable->insert("intraDetailLevel"), NULL, "1");
      getDefaultConfig()->setDataField(StringTable->insert("shapeAngularVelocity"), NULL, "0 0 0");
      getDefaultConfig()->setDataField(StringTable->insert("shapeOffset"), NULL, "0 0 0");
      getDefaultConfig()->setDataField(StringTable->insert("shapeRotation"), NULL, "0 0 0");
      getDefaultConfig()->setDataField(StringTable->insert("shapeScale"), NULL, "1 1 1");
   }
}


//-----------------------------------------------------------------------------
// Destructor.
//-----------------------------------------------------------------------------
t2dShape3D::~t2dShape3D()
{
}


//-----------------------------------------------------------------------------
// OnAdd
//-----------------------------------------------------------------------------
bool t2dShape3D::onAdd()
{
   // Call Parent.
   if(!Parent::onAdd())
      return false;

   // Return Okay.
   return true;
}

//-----------------------------------------------------------------------------
// OnRemove.
//-----------------------------------------------------------------------------
void t2dShape3D::onRemove()
{
   // Unload any existing shape.
   unloadShape();

   // Call Parent.
   Parent::onRemove();
}

//----------------------------------------------------------------------------
// Set Shape.
//----------------------------------------------------------------------------
ConsoleMethod(t2dShape3D, setShape, bool, 3, 3, "( shapeFile$ ) - Loads a shape into the object."
			  "@param shapeFile The file where shape is stored."
			  "@return Returns true on success and false otherwise.")
{
   // Set Shape.
   return object->setShape( argv[2] );
}
// Set Shape.
bool t2dShape3D::setShape( const char* pShapeFile )
{
    // Ignore invalid shape filename.
    if ( !pShapeFile )
    {
        // Warn.
        Con::warnf("t2dShape3D::setShape() - Invalid Shape filename specified!");
        // Return Shape Error.
        return false;
    }

    // Unload any existing shape.
    unloadShape();

    // Expand relative paths.
    static char buffer[256];
    if ( Con::expandScriptFilename( buffer, sizeof( buffer ), pShapeFile ) )
    {
        pShapeFile = buffer;
    }

    // Yes, so Load Shape Resource.
    Resource<TSShape> hShape;
    hShape = ResourceManager->load( pShapeFile );

    // Did we get the shape?
    if ( bool(hShape) )
    {
        // Yes, so keep shape filename.
        mShapeFile = StringTable->insert( pShapeFile );
        // Create a shape instance.
        mShapeInstance = new TSShapeInstance(hShape, true);

        // Reset Current Detail Level.
        mShapeInstance->setCurrentDetail( 0 );

        // Have we got any sequences?
        if ( mShapeInstance->getShape()->sequences.size() > 0 )
        {
            // Yes, so add a thread.
            mShapeThread = mShapeInstance->addThread();
        }

        // Reset All Trigger States.
        resetAllTriggers();

        // Return Okay.
        return true;
    }
    else
    {
        // Warn.
        Con::warnf("t2dShape3D::setShape() - Could not load shape '%s'.", pShapeFile);
        // Return Shape Error.
        return false;
    }
}


//--------------------------------------------------------------------------
// Unload Shape.
//--------------------------------------------------------------------------
void t2dShape3D::unloadShape( void )
{
   // Have we got a shape?
   if ( getIsShapeValid() )
   {
      // Yes, so did we have any sequences?
      if ( getIsShapeThreadValid() )
      {
         // Yes, so remove the thread.
         mShapeInstance->destroyThread( mShapeThread );
         mShapeThread = NULL;
      }

      // Remove shape instace.
      delete mShapeInstance;
      mShapeInstance = NULL;
   }
}


//--------------------------------------------------------------------------
// Reset All Triggers.
//--------------------------------------------------------------------------
void t2dShape3D::resetAllTriggers(void)
{
    // Have we got a shape?
    if ( getIsShapeValid() )
    {
        // Yes, so reset All Triggers.
        mShapeInstance->setTriggerStateBit( U32_MAX, false );
    }
}



//--------------------------------------------------------------------------
// Transpose VectorF Y/Z (from 3D to 2D system).
//--------------------------------------------------------------------------
VectorF& t2dShape3D::transpose3D2D(VectorF& vector)
{
    // Transpose Y/Z.
    mSwap(vector.y, vector.z);
    // Return Vector.
    return vector;
}


//--------------------------------------------------------------------------
// Degree->Radian VectorF.
//--------------------------------------------------------------------------
VectorF& t2dShape3D::degToRad3D(VectorF& vector)
{
    // Convert to Radians.
    vector.x = mDegToRad(vector.x);
    vector.y = mDegToRad(vector.y);
    vector.z = mDegToRad(vector.z);
    // Return Vector.
    return vector;
}


//-----------------------------------------------------------------------------
// Set Skin.
//-----------------------------------------------------------------------------
ConsoleMethod(t2dShape3D, setSkin, bool, 4, 4, "( skinSet$, skinName$ ) - Changes the skin to the specified texture\n"
			  "@param skinSet Set in which desired skin is located.\n"
			  "@param Name of desired texture.\n"
			  "@return Returns true on success, false otherwise.")
{
	// Set Skin.
	return object->setSkin(argv[2], argv[3]);
}
// Set Skin.
bool t2dShape3D::setSkin( const char* pSkinSet, const char* pSkinName )
{
    // Is Shape Valid?
    if (!getIsShapeValid() )
    {
        // No, so warn.
        Con::warnf("t2dShape3D::setSkin() - Cannot set skin without a shape! SkinSet:%s/SkinName:%s", pSkinSet, pSkinName);
        // Return.
        return false;
    }

    // Fetch Path of current Shape-File.
    char pathBuffer[256];
    const char* pFilePath = ResourceManager->getPathOf( mShapeFile );

    // Append the skinset to the filePath.
    dSprintf(pathBuffer, 256, "%s/%s", pFilePath, pSkinSet);

    // Have we got a copy of our own materials list?
    if ( !mShapeInstance->ownMaterialList() )
    {
        // No, so clone one.
        mShapeInstance->cloneMaterialList();
    }

    // Fetch the Materials List.
    TSMaterialList* pMaterialList = mShapeInstance->getMaterialList();

    // Get Material Count.
    const U32 materialCount = pMaterialList->mMaterialNames.size();

    // Iterate Materials.
    for ( U32 n = 0; n < materialCount; n++)
    {
        // Get the name of this material.
        const char* pMaterialName = pMaterialList->mMaterialNames[n];

        // Skip to next one if invalid.
        if( !pMaterialName ) continue;

        char fullFilePathBuffer[256];
        char skinFileBuffer[256];

        // Funky string replacing, eek!
        dStrcpy(skinFileBuffer, pSkinName);
        const char* findPeriod = dStrrchr(pMaterialName, '.');
        if ( findPeriod )
        {
            dStrcat(skinFileBuffer, findPeriod);
            dSprintf(fullFilePathBuffer, 256, "%s/%s.%s", pathBuffer, pSkinSet, skinFileBuffer);
        }
        else
        {
            dSprintf(fullFilePathBuffer, 256, "%s/%s", pathBuffer, pSkinSet);
        }

        // Load the texture.
        pMaterialList->mMaterials[n].set( fullFilePathBuffer, MeshTexture, false );
    }

    // Return Okay.
    return true;
} 

ConsoleMethod( t2dShape3D, getTextureFileList, const char*, 2, 2, "() \n @return Retrieves a tab separated list of all textures used by this shape." )
{
   Vector<StringTableEntry> files;
   object->getTextureFileList( files );

   if( files.empty() )
      return "";

   S32 bufferSize = files.size() * 512;
   char* buffer = Con::getReturnBuffer( bufferSize );
   dStrcpy( buffer, files[0] );
   for( U32 i = 1; i < files.size(); i++ )
   {
      dStrcat(buffer, "\t");
      dStrcat(buffer, files[i]);
   }

   return buffer;
}

void t2dShape3D::getTextureFileList( Vector<StringTableEntry>& files)
{
   // Is Shape Valid?
   if (!getIsShapeValid() )
   {
      // No, so warn.
      Con::warnf("t2dShape3D::getTextureFileList() - Cannot get a texture list from an invalid shape");
      // Return.
      return;
   }

   // Have we got a copy of our own materials list?
    if ( !mShapeInstance->ownMaterialList() )
    {
        // No, so clone one.
        mShapeInstance->cloneMaterialList();
    }

    // Fetch the Materials List.
    TSMaterialList* pMaterialList = mShapeInstance->getMaterialList();

    const char* path = ResourceManager->getPathOf( mShapeFile );

    // Possible texture file extensions.
    static const int extCount = 5;
    const char* extArray[extCount] = { ".jpg", ".png", ".gif", ".bmp", ".bm8" };

    // Get Material Count.
    const U32 materialCount = pMaterialList->mMaterials.size();

    // Iterate Materials.
    for ( U32 n = 0; n < materialCount; n++)
    {
        // Get the name of this material.
        const char* pMaterialName = pMaterialList->mMaterials[n].getName();

        // Skip to next one if invalid.
        if( !pMaterialName ) continue;

        // Try to find the full name with extension.
        char fullName[512];
        for( S32 i = 0; i <= extCount; i++ )
        {
           if( i == extCount )
              fullName[0] = '\0';

           dSprintf(fullName, 512, "%s%s", pMaterialName, extArray[i]);
           if( Platform::isFile( fullName ) )
              break;
        }

        if( !*fullName )
           continue;

        files.push_back( StringTable->insert( fullName ) );
    }

    // IFL's?
    U32 iflCount = mShapeInstance->mIflMaterialInstances.size();
    for( U32 i = 0; i < iflCount; i++ )
    {
       TSShapeInstance::IflMaterialInstance& ifl = mShapeInstance->mIflMaterialInstances[i];

       if( mShapeInstance->getShape() && ifl.iflMaterial )
       {
          char fullName[512];
          dSprintf( fullName, 512, "%s/%s", path, mShapeInstance->getShape()->getName( ifl.iflMaterial->nameIndex ) );
          files.push_back( StringTable->insert( fullName ) );
       }
    }
}

//----------------------------------------------------------------------------
// Play Animation Name.
//----------------------------------------------------------------------------
ConsoleMethod(t2dShape3D, playAnimation, bool, 3, 5, "( animationName, [startTime], [transitionTime] ) - Plays an Animation by Sequence Name.\n"
			  "@param animationName The internal name of the desired animation.\n"
			  "@param startTime (optional) The start time to set (default 0.0f)\n"
			  "@param transitionTime The transition time between animations (default 0.0f)\n"
			  "@return Returns true on success.")
{
    // Calculate Start Position.
    const F32 startPosition = ( argc > 3 ) ? dAtof(argv[3]) : 0.0f;
    // Calculate Transition Time.
    const F32 transitionTime = ( argc > 4 ) ? dAtof(argv[4]) : 0.0f;
    // Play Animation Name.
    return object->playAnimation( argv[2], startPosition, transitionTime );
}
// Play Animation Name.
bool t2dShape3D::playAnimation( const char* sequenceName, F32 startTime, const F32 transitionTime )
{
    // Validate shape.
    if ( !getIsShapeValid() )
    {
        // Warn.
        Con::printf("t2dShape3D::playAnimation() - Cannot play animation without valid shape!");
        // Return Error.
        return false;
    }

    // Validate shape thread.
    if ( !getIsShapeThreadValid() )
    {
        // Warn.
        Con::printf("t2dShape3D::playAnimation() - Cannot play animation; shape has no animations!");
        // Return Error.
        return false;
    }

    // Get Shape.
    const TSShape* pShape = mShapeInstance->getShape();

    // Find Sequence.
    const S32 sequence = pShape->findSequence( sequenceName );
    // Check for Valid Sequence.
    if ( sequence == -1 )
    {
        // Warn.
        Con::warnf("t2dShape3D::playAnimationName() - Attempt to play invalid sequence name '%s'.", sequenceName);
        // Return Error.
        return false;
    }

    // Check Upper-bound start time.
    if ( startTime > 0.9999f && pShape->sequences[sequence].isCyclic() )
    {
        // Warn.
        Con::printf("t2dShape3D::playAnimation() - Cannot set start-time to >1 on cyclic animations!");
        // 1.0f doesn't exist for cyclic sequences!
        startTime = 0.9999f;
    }
    else if ( startTime < 0.0f )
    {
        // Warn.
        Con::printf("t2dShape3D::playAnimation() - Cannot set start-time to <0!");
        // Cannot go back in time!
        startTime = 0.0f;
    }

    // Reset All Trigger States.
    resetAllTriggers();

    // Transition?
    if ( transitionTime > 0.0f  )
    {
        // Yes, so transition to sequence.
        mShapeInstance->transitionToSequence( mShapeThread, sequence, startTime, transitionTime, true );
    }
    else
    {
        // No, so just set the sequence.
        mShapeInstance->setSequence( mShapeThread, sequence, startTime );
    }

    mAnimationName = StringTable->insert(sequenceName);

    // Return Okay.
    return true;
}



//----------------------------------------------------------------------------
// Play Animation Sequence.
//----------------------------------------------------------------------------
ConsoleMethod(t2dShape3D, playAnimationSequence, bool, 3, 5, "( sequence, [startTime], [transitionTime]  ) - Plays an Animation by Sequence Index."
			  "@param sequence Index of desired animation.\n"
			  "@param startTime (optional) The start time to set (default 0.0f)\n"
			  "@param transitionTime The transition time (default 0.0f)\n"
			  "@return Returns true on success.")
{
    // Calculate Start Position.
    const F32 startPosition = ( argc > 3 ) ? dAtof(argv[3]) : 0.0f;
    // Calculate Transition Time.
    const F32 transitionTime = ( argc > 4 ) ? dAtof(argv[4]) : 0.0f;

    // Play Animation Sequence.
    return object->playAnimationSequence( dAtoi(argv[2]), startPosition, transitionTime );
}
// Play Animation Sequence.
bool t2dShape3D::playAnimationSequence( const S32 sequence, F32 startTime, const F32 transitionTime )
{
    // Validate shape.
    if ( !getIsShapeValid() )
    {
        // Warn.
        Con::printf("t2dShape3D::playAnimationSequence() - Cannot play animation sequence without valid shape!");
        // Return Error.
        return false;
    }

    // Validate shape thread.
    if ( !getIsShapeThreadValid() )
    {
        // Warn.
        Con::printf("t2dShape3D::playAnimationSequence() - Cannot play animation; shape has no animations!");
        // Return Error.
        return false;
    }

    // Get Shape.
    const TSShape* pShape = mShapeInstance->getShape();

    // Check valid sequence.
    if ( sequence >= pShape->sequences.size() )
    {
        // Report.
        Con::warnf("t2dShape3D::playAnimationSequence() - Attempt to play animation sequence %d; object only has %d animation sequences!", sequence, pShape->sequences.size());
        // Return Error.
        return false;
    }

    // Check Upper-bound start time.
    if ( startTime > 0.9999f && pShape->sequences[sequence].isCyclic() )
    {
        // Warn.
        Con::printf("t2dShape3D::playAnimation() - Cannot set start-time to >1 on cyclic animations!");
        // 1.0f doesn't exist for cyclic sequences!
        startTime = 0.9999f;
    }
    else if ( startTime < 0.0f )
    {
        // Warn.
        Con::printf("t2dShape3D::playAnimation() - Cannot set start-time to <0!");
        // Cannot go back in time!
        startTime = 0.0f;
    }

    // Reset All Trigger States.
    resetAllTriggers();

    // Transition?
    if ( transitionTime > 0.0f  )
    {
        // Yes, so transition to sequence.
        mShapeInstance->transitionToSequence( mShapeThread, sequence, startTime, transitionTime, true );
    }
    else
    {
        // No, so just set the sequence.
        mShapeInstance->setSequence( mShapeThread, sequence, startTime );
    }

    // Return Okay.
    return true;
}


//-----------------------------------------------------------------------------
// Set Animation Time Scale.
//-----------------------------------------------------------------------------
ConsoleMethod(t2dShape3D, setTimeScale, bool, 3, 3, "( timeScale ) Set the animation time-scale.\n"
			  "@param timeScale Desired time scale value.\n"
			  "@return Returns true on success.")
{
    // Set Animation Time Scale.
    return object->setTimeScale( dAtof(argv[2]) );
}
// Set Animation Time Scale.
bool t2dShape3D::setTimeScale( const F32 timeScale )
{
    // Validate shape.
    if ( !getIsShapeValid() )
    {
        // Warn.
        Con::printf("t2dShape3D::setTimeScale() - Cannot set time-scale without valid shape!");
        // Return Error.
        return false;
    }

    // Validate shape thread.
    if ( !getIsShapeThreadValid() )
    {
        // Warn.
        Con::printf("t2dShape3D::setTimeScale() - Cannot set time-scale; shape has no animations!");
        // Return Error.
        return false;
    }

    // Set Time Scale.
    mShapeInstance->setTimeScale( mShapeThread, timeScale );

    // Return Okay.
    return true;
}


//-----------------------------------------------------------------------------
// Set Shape Rotation.
//-----------------------------------------------------------------------------
ConsoleMethod(t2dShape3D, setShapeRotation, bool, 3, 5, "(x / y / z) - Sets Shape Rotation\n"
			  "@param x/y/z Directional components either as (x,y,z) or (\"x y z\")\n"
			  "@return Returns true on success.")
{
   VectorF vec;

   U32 elementCount = t2dSceneObject::getStringElementCount(argv[2]);

   // ("x y z")
   if ((elementCount == 3) && (argc == 3))
   {
      vec = t2dSceneObject::getStringElementVector3D(argv[2], 0);
   }

   // ("x, y, z")
   else if ((elementCount == 1) && (argc == 5))
   {
      vec.x = dAtof(argv[2]);
      vec.y = dAtof(argv[3]);
      vec.z = dAtof(argv[4]);
   }

   // Invalid
   else
   {
      Con::warnf("t2dShape3D::setShapeRotation() - Invalid number of parameters!");
      return false;
   }

	vec = t2dShape3D::degToRad3D(vec);
    vec = t2dShape3D::transpose3D2D(vec);

    // Set Shape Rotation.
    object->setShapeRotation( vec );

    // Return Okay.
    return true;
}
// Set Shape Rotation.
void t2dShape3D::setShapeRotation( const EulerF& rotation )
{
    // Set Angular Quaternion.
    mShapeRotation = rotation;
    mAngularQuaternion.set( rotation );
}


//-----------------------------------------------------------------------------
// Set Shape Angular Velocity.
//-----------------------------------------------------------------------------
ConsoleMethod(t2dShape3D, setShapeAngularVelocity, bool, 3, 5, "(x / y / z) - Sets Shape Angular Velocity."
			  "@param x/y/z Directional components either as (x,y,z) or (\"x y z\")\n"
			  "@return Returns true on success.")
{
   VectorF vec;

   U32 elementCount = t2dSceneObject::getStringElementCount(argv[2]);

   // ("x y z")
   if ((elementCount == 3) && (argc == 3))
   {
      vec = t2dSceneObject::getStringElementVector3D(argv[2], 0);
   }

   // ("x, y, z")
   else if ((elementCount == 1) && (argc == 5))
   {
      vec.x = dAtof(argv[2]);
      vec.y = dAtof(argv[3]);
      vec.z = dAtof(argv[4]);
   }

   // Invalid
   else
   {
      Con::warnf("t2dShape3D::setShapeAngularVelocity() - Invalid number of parameters!");
      return false;
   }

	vec = t2dShape3D::degToRad3D(vec);
	vec = t2dShape3D::transpose3D2D(vec);

    // Set Shape Angular Velocity.
    object->setShapeAngularVelocity( vec );

    // Return Okay.
    return true;
}
// Set Shape Angular Velocity.
void t2dShape3D::setShapeAngularVelocity( const EulerF& shapeAngular )
{
    // Set Shape Angular Velocity.
    mShapeAngularVelocity = shapeAngular;

    // Set Shape Angular Velocity Active Status.
    mShapeAngularVelocityActive = !mShapeAngularVelocity.isZero();
};


//-----------------------------------------------------------------------------
// Set Shape Offset.
//-----------------------------------------------------------------------------
ConsoleMethod(t2dShape3D, setShapeOffset, bool, 3, 5, "(x / y / z) - Sets Shape Offset."
			  "@param x/y/z Directional components either as (x,y,z) or (\"x y z\")\n"
			  "@return Returns true on success.")
{
   VectorF vec;

   U32 elementCount = t2dSceneObject::getStringElementCount(argv[2]);

   // ("x y z")
   if ((elementCount == 3) && (argc == 3))
   {
      vec = t2dSceneObject::getStringElementVector3D(argv[2], 0);
   }

   // (x, y, z)
   else if ((elementCount == 1) && (argc == 5))
   {
      vec.x = dAtof(argv[2]);
      vec.y = dAtof(argv[3]);
      vec.z = dAtof(argv[4]);
   }

   // Invalid
   else
   {
      Con::warnf("t2dShape3D::setShapeOffset() - Invalid number of parameters!");
      return false;
   }
 
	vec = t2dShape3D::transpose3D2D(vec);

    // Set Shape Offset.
    object->setShapeOffset( vec );

    // Return Okay.
    return true;
}
// Set Shape Offset.
void t2dShape3D::setShapeOffset( const VectorF& shapeOffset )
{
    // Set Shape Offset.
    mShapeOffset = shapeOffset;
}


//-----------------------------------------------------------------------------
// Set Shape Scale.
//-----------------------------------------------------------------------------
ConsoleMethod(t2dShape3D, setShapeScale, bool, 3, 5, "(x [/ y / z]) - Sets Shape Offset."
			  "@param x/y/z Scale components either as (x,y,z) or (\"x y z\")\n"
			  "@return Returns true on success.")
{
   VectorF shapeScale;

   U32 elementCount = t2dSceneObject::getStringElementCount(argv[2]);

   // ("x y z")
   if ((elementCount == 3) && (argc == 3))
   {
      VectorF vec = t2dSceneObject::getStringElementVector3D(argv[2], 0);
      shapeScale = t2dShape3D::transpose3D2D(vec);
   }

   // (x, [y, z])
   else if (elementCount == 1)
   {
      shapeScale.x = dAtof(argv[2]);

      if (argc == 5)
      {
         shapeScale.y = dAtof(argv[3]);
         shapeScale.z = dAtof(argv[4]);
      }
      else if (argc == 3)
      {
         shapeScale.y = shapeScale.z = shapeScale.x;
      }
      else
      {
         Con::warnf("t2dShape3D::setShapeScale() - Invalid number of parameters!");
         return false;
      }
   }

   // Invalid
   else
   {
      Con::warnf("t2dShape3D::setShapeScale() - Invalid number of parameters!");
      return false;
   }

    // Set Shape Scale.
    return object->setShapeScale( shapeScale );
}
// Set Shape Scale.
bool t2dShape3D::setShapeScale( const VectorF& shapeScale )
{
    // Check Scale.
    if ( mLessThanOrEqual(shapeScale.x,0.0f) || mLessThanOrEqual(shapeScale.y,0.0f) || mLessThanOrEqual(shapeScale.z,0.0f) )
    {
        // Warn.
        Con::warnf("t2dShape3D::setShapeScale() - Scale components cannot be negative!");
        return false;
    }

    // Set Shape Scale.
    mShapeScale = shapeScale;

    // Return Okay.
    return true;
}


//-----------------------------------------------------------------------------
// Set Trigger Active Status.
//-----------------------------------------------------------------------------
ConsoleMethod(t2dShape3D, setTriggerActive, bool, 3, 3, "(status) Sets Trigger active/inactive.\n"
			  "@param status Boolean. Set true for active, false for inactive.\n"
			  "@return Returns true on success.")
{
    // Set Trigger Active Status.
    return object->setTriggerActive( dAtob(argv[2]) );
}
// Set Trigger Active Status.
bool t2dShape3D::setTriggerActive( const bool status )
{
    // Validate shape.
    if ( !getIsShapeValid() )
    {
        // Warn.
        Con::printf("t2dShape3D::setTriggerActive() - Cannot set trigger status without valid shape!");
        // Return Error.
        return false;
    }

    // Set Trigger Active Status.
    mTriggerActive = status;

    // Reset All Trigger States.
    resetAllTriggers();

    // Return Okay.
    return true;
}


//-----------------------------------------------------------------------------
// Set Detail Level.
//-----------------------------------------------------------------------------
ConsoleMethod(t2dShape3D, setDetailLevel, bool, 3, 4, "(detailLevel, [intraDetail] ) Sets Current Detail Level.\n"
			  "@param detailLevel The detail level to display. It must be defined within the dts shape.\n"
			  "@param intraDetail (optional) The intra detail level. This is the percentage to the next detail level. (default 1.0f)\n"
			  "@return Returns true on success. False otherwise.")
{
    // Calculate Intra-Detail.
    const F32 intraDetail = (argc > 3) ? dAtof(argv[3]) : 0.0f;

    // Set Detail Level.
    return object->setDetailLevel( dAtoi(argv[2]), intraDetail );
}
// Set Detail Level.
bool t2dShape3D::setDetailLevel( const U32 detailLevel, const F32 intraDetail )
{
    // Validate shape.
    if ( !getIsShapeValid() )
    {
        // Warn.
        Con::printf("t2dShape3D::setDetailLevel() - Cannot set current detail-level without valid shape!");
        // Return Error.
        return false;
    }

    // Validate Detail Level.
    if ( detailLevel >= mShapeInstance->getNumDetails() )
    {
        // Warn.
        Con::printf("t2dShape3D::setDetailLevel() - Cannot set detail (%d); valid detail levels are 0 to %d!", detailLevel, mShapeInstance->getNumDetails()-1);
        // Return Error.
        return false;
    }

    // Validate Intra Detail Level.
    if ( intraDetail < 0.0f || intraDetail > 1.0f )
    {
        // Warn.
        Con::printf("t2dShape3D::setDetailLevel() - Cannot set intra-detail (%f); must be in the range 0.0 to 1.0!");
        // Return Error.
        return false;
    }

    // Set Shape Detail.
    mShapeDetailLevel = detailLevel;
    mShapeIntraDetailLevel = intraDetail;

    // Return Okay.
    return true;
}


//-----------------------------------------------------------------------------
// Get Detail Level Count.
//-----------------------------------------------------------------------------
ConsoleMethod(t2dShape3D, getDetailLevelCount, S32, 2, 2, "() Gets the number of detail levels defined in the dts shape.\n"
			  "@return Return the count as a nonnegative integer. Returns 0 on failure.")
{
    // Get Detail Level Count.
    return S32(object->getDetailLevelCount());
}
// Get Detail Level Count.
U32 t2dShape3D::getDetailLevelCount( void )
{
    // Validate shape.
    if ( !getIsShapeValid() )
    {
        // Warn.
        Con::printf("t2dShape3D::getDetailLevelCount() - Cannot retrieve detail-level count without valid shape!");
        return 0;
    }

    // Return Detail Level Count.
    return mShapeInstance->getNumDetails();
}


//-----------------------------------------------------------------------------
// Get Current Detail Level.
//-----------------------------------------------------------------------------
ConsoleMethod(t2dShape3D, getCurrentDetailLevel, S32, 2, 2, "() Get the current detail level.\n"
			  "@return Returns the detail level as a integer.")
{
    // Get Current Detail Level.
    return S32(object->getCurrentDetailLevel());
}
// Get Current Detail Level.
S32 t2dShape3D::getCurrentDetailLevel( void )
{
    // Validate shape.
    if ( !getIsShapeValid() )
    {
        // Warn.
        Con::printf("t2dShape3D::getDetailLevel() - Cannot retrieve detail-level without valid shape!");
        return 0;
    }

    // Return Get Current Detail Level.
    return mShapeInstance->getCurrentDetail();
}


//-----------------------------------------------------------------------------
// Get Current Intra-Detail-Level.
//-----------------------------------------------------------------------------
ConsoleMethod(t2dShape3D, getCurrentIntraDetailLevel, F32, 2, 2, "() Get current Intra-Detail-Level.\n"
			  "@return Returns the intra-detail level as a floating point value between 0.0 and 1.0 (0.0 is return on failure)")
{
    // Get Current Intra-Detail-Level.
    return object->getCurrentIntraDetailLevel();
}
// Get Current Intra-Detail-Level.
F32 t2dShape3D::getCurrentIntraDetailLevel( void )
{
    // Validate shape.
    if ( !getIsShapeValid() )
    {
        // Warn.
        Con::printf("t2dShape3D::getDetailIntraLevel() - Cannot retrieve detail intra-level without valid shape!");
        return 0;
    }

    // Return Get Current Intra-Detail-Level.
    return mShapeInstance->getCurrentIntraDetail();
}

ConsoleMethod(t2dShape3D, getShapeAngularVelocity, const char*, 2, 2, "() \n @return Returns the angular velocity as a string formatted as \"val.x val.y val.z\"")
{
   Point3F val = object->getShapeAngularVelocity();
   char* buffer = Con::getReturnBuffer(64);
   dSprintf(buffer, 64, "%f %f %f", val.x, val.y, val.z);
   return buffer;
}

ConsoleMethod(t2dShape3D, getShapeAngularRotation, const char*, 2, 2, "() \n @return Returns the angular rotation as a string formatted as \"axis.x axis.y axis.z angle\"")
{
   QuatF quat = object->getShapeAngularRotation();
   AngAxisF aa(quat); // convert to angle axis

   char* buffer = Con::getReturnBuffer(64);
   dSprintf(buffer, 64, "%f %f %f %f", aa.axis.x, aa.axis.y, aa.axis.z, aa.angle);
   return buffer;
}

ConsoleMethod(t2dShape3D, getShapeRotation, const char*, 2, 2, "()  \n @return Returns the shape rotation as a string formatted as \"val.x val.y val.z\"")
{
   Point3F val = object->getShapeRotation();
   char* buffer = Con::getReturnBuffer(64);
   dSprintf(buffer, 64, "%f %f %f", val.x, val.y, val.z);
   return buffer;
}

ConsoleMethod(t2dShape3D, getShapeOffset, const char*, 2, 2, "()  \n @return Returns the shape's offset as a string formatted as \"val.x val.y val.z\"")
{
   Point3F val = object->getShapeOffset();
   char* buffer = Con::getReturnBuffer(64);
   dSprintf(buffer, 64, "%f %f %f", val.x, val.y, val.z);
   return buffer;
}

ConsoleMethod(t2dShape3D, getShapeScale, const char*, 2, 2, "()  \n @return Returns the shape's scale as a string formatted as \"val.x val.y val.z\"")
{
   Point3F val = object->getShapeScale();
   char* buffer = Con::getReturnBuffer(64);
   dSprintf(buffer, 64, "%f %f %f", val.x, val.y, val.z);
   return buffer;
}



//-----------------------------------------------------------------------------
// Integrate Object.
//-----------------------------------------------------------------------------
void t2dShape3D::integrateObject( const F32 sceneTime, const F32 elapsedTime, CDebugStats* pDebugStats )
{
	// Call Parent.
	Parent::integrateObject( sceneTime, elapsedTime, pDebugStats );

// T2D Debug Profiling.
#ifdef TORQUE_ENABLE_PROFILER
		PROFILE_START(T2D_t2dShape3D_integrateObject);
#endif

    // Remove any rotation!
    getParentPhysics().mRotation = 0.0f;

    // Valid Shape?
    if ( getIsShapeValid() )
    {
        // Shape Thread?
        if ( getIsShapeThreadValid() )
        {
            // Yes, so advance the shape time.
            mShapeInstance->advanceTime( elapsedTime, mShapeThread );
            // Animate the shape.
            mShapeInstance->animate();

            // Is trigger active?
            if ( mTriggerActive )
            {
			    // Yes, os check All Triggers.
			    for ( U32 n = 1; n < 33; n++ )
			    {
				    // Is Trigger Active?
				    if ( mShapeInstance->getTriggerState(n, true) )
				    {
                        // Yes, so Argument Buffer.
                        static char argBuffer[8];
                        // Format Buffer.
                        dSprintf( argBuffer, 8, "%d", n );

                        // Yes, so do callback.
                        Con::executef( this, 2, "onAnimationTrigger", argBuffer );
                    }
                }
            }
        }

        // Is Angular Velocity active?
        if ( mShapeAngularVelocityActive )
        {
		    // Yes, so fetch current angular velocity and integrate.
		    const EulerF angularVel = getShapeAngularVelocity() * elapsedTime;
		    // Create a quaternion for the angular integral.
		    const QuatF angularIntegral(angularVel);
		    // Add it into our angular quaternion.
		    mAngularQuaternion *= angularIntegral;
		    // Renormalise it to stop overflows.
            mAngularQuaternion.normalize();
        }
    }

// T2D Debug Profiling.
#ifdef TORQUE_ENABLE_PROFILER
		PROFILE_END();   // T2D_t2dShape3D_integrateObject
#endif
}

const EulerF& t2dShape3D::getShapeRotation()
{
   // rdbnote: this was causing the editor to change the input values in the editor as the user was setting them...
   //   changed and move this code into separate functions, see getShapeAngularRotation
//	F32 x = -mAtan(2 * ((mAngularQuaternion.w * mAngularQuaternion.x) + (mAngularQuaternion.y * mAngularQuaternion.z)),
//                   1 - (2 * ((mAngularQuaternion.x * mAngularQuaternion.x) + (mAngularQuaternion.y * mAngularQuaternion.y))));
//
//	F32 y = -mAsin(2 * ((mAngularQuaternion.w * mAngularQuaternion.y) - (mAngularQuaternion.z * mAngularQuaternion.x)));
//
//	F32 z = -mAtan(2 * ((mAngularQuaternion.w * mAngularQuaternion.z) + (mAngularQuaternion.x * mAngularQuaternion.y)),
//                   1 - (2 * ((mAngularQuaternion.y * mAngularQuaternion.y) + (mAngularQuaternion.z * mAngularQuaternion.z))));
//	mShapeRotation.set(x, y, z);
	return mShapeRotation;
}

//-----------------------------------------------------------------------------
// Serialisation.
//-----------------------------------------------------------------------------

// Register Handlers.
REGISTER_SERIALISE_START( t2dShape3D )
	REGISTER_SERIALISE_VERSION( t2dShape3D, 1, false )
REGISTER_SERIALISE_END()

// Implement Base Serialisation.
IMPLEMENT_T2D_SERIALISE_PARENT( t2dShape3D, 1 )


//-----------------------------------------------------------------------------
// Load v1
//-----------------------------------------------------------------------------
IMPLEMENT_T2D_LOAD_METHOD( t2dShape3D, 1 )
{
	// Load Shape Object Data...
    StringTableEntry shapeFile;
    bool triggerActive;
    S32 shapeDetailLevel;
    F32 shapeIntraDetailLevel;
    QuatF angularQuaternion;
    VectorF angularVelocity;
    VectorF shapeOffset;
    VectorF shapeScale;

    // Read Shape File.
    shapeFile = stream.readSTString();

    // Read Shape Detail.
    if  (   !stream.read( &triggerActive ) ||
            !stream.read( &shapeDetailLevel ) ||
            !stream.read( &shapeIntraDetailLevel ) ||

            !stream.read( &angularQuaternion.x ) ||
            !stream.read( &angularQuaternion.y ) ||
            !stream.read( &angularQuaternion.z ) ||
            !stream.read( &angularQuaternion.w ) ||

            !stream.read( &angularVelocity.x ) ||
            !stream.read( &angularVelocity.y ) ||
            !stream.read( &angularVelocity.z ) ||

            !stream.read( &shapeOffset.x ) ||
            !stream.read( &shapeOffset.y ) ||
            !stream.read( &shapeOffset.z ) ||

            !stream.read( &shapeScale.x ) ||
            !stream.read( &shapeScale.y ) ||
            !stream.read( &shapeScale.z ) )
        // Error.
        return false;

    // Set Shape File.    
    object->setShape( shapeFile );

    // Set Trigger Active.
    object->setTriggerActive( triggerActive );

    // Set Angular Quaternion.
    object->mAngularQuaternion = angularQuaternion;

    // Set Angular Velocity.
     object->setShapeAngularVelocity( angularVelocity );

    // Set Shape Offset.
     object->setShapeOffset( shapeOffset );

    // Set Shape Scale.
     object->setShapeScale( shapeScale );

    // Return Okay.
    return true;
}

//-----------------------------------------------------------------------------
// Save v1
//-----------------------------------------------------------------------------
IMPLEMENT_T2D_SAVE_METHOD( t2dShape3D, 1 )
{
	// Save Shape Object Data...

    // Write Shape File.
    stream.writeString( object->mShapeFile );

    // Write Shape Detail.
    if  (   !stream.write( object->mTriggerActive ) ||
            !stream.write( object->mShapeDetailLevel ) ||
            !stream.write( object->mShapeIntraDetailLevel ) ||

            !stream.write( mRadToDeg(object->mAngularQuaternion.x) ) ||
            !stream.write( mRadToDeg(object->mAngularQuaternion.y) ) ||
            !stream.write( mRadToDeg(object->mAngularQuaternion.z) ) ||
            !stream.write( mRadToDeg(object->mAngularQuaternion.w) ) ||
            // Transpose Y/Z.
            !stream.write( mRadToDeg(object->mShapeAngularVelocity.x) ) ||
            !stream.write( mRadToDeg(object->mShapeAngularVelocity.z) ) ||
            !stream.write( mRadToDeg(object->mShapeAngularVelocity.y) ) ||
            // Transpose Y/Z.
            !stream.write( object->mShapeOffset.x ) ||
            !stream.write( object->mShapeOffset.z ) ||
            !stream.write( object->mShapeOffset.y ) ||
            // Transpose Y/Z.
            !stream.write( object->mShapeScale.x ) ||
            !stream.write( object->mShapeScale.z ) ||
            !stream.write( object->mShapeScale.y ) )
        // Error.
        return false;

    // Return Okay.
	return true;
}


//-----------------------------------------------------------------------------
// Render Object.
//-----------------------------------------------------------------------------
void t2dShape3D::renderObject( const RectF& viewPort, const RectF& viewIntersection )
{
   const char* display = Con::getVariable("$pref::Video::displayDevice");
   // Validate Shape Instance
   if( !mShapeInstance || dStricmp(display, "D3D") == 0 )
   {
      // Call Parent.
      Parent::renderObject( viewPort, viewIntersection );	// Always use for Debug Support!

      return;
   }

   // T2D Debug Profiling.
#ifdef TORQUE_ENABLE_PROFILER
   PROFILE_START(T2D_t2dShape3D_renderObject);
#endif

   // Save Viewport.
   RectI viewport;
   dglGetViewport(&viewport);

	// Validate scene window.
	if ( getIsShapeValid() && getSceneGraph() && getSceneGraph()->getCurrentRenderWindow() )
	{
		// Calculate new Viewport.

		// Fetch the Current Render Window.
		t2dSceneWindow* pSceneWindow = getSceneGraph()->getCurrentRenderWindow();
		
      // Convert from T2D coords to GUI coords.
		t2dVector mWindowMin;
		t2dVector mWindowMax;
		pSceneWindow->sceneToWindowCoord( t2dVector(mWorldClipLeft,mWorldClipTop) , mWindowMin );
		pSceneWindow->sceneToWindowCoord( t2dVector(mWorldClipRight,mWorldClipBottom) , mWindowMax );
      
		// Account for Local GUI Position in Global Canvas-Space.
      Point2I globalMin = pSceneWindow->localToGlobalCoord(Point2I(mWindowMin.mX,mWindowMin.mY));
      Point2I globalMax = pSceneWindow->localToGlobalCoord(Point2I(mWindowMax.mX,mWindowMax.mY));
      
      // Set new viewport.
		RectI globalViewport(globalMin.x, globalMin.y, S32(globalMax.x - globalMin.x), S32(globalMax.y - globalMin.y));
		dglSetViewport(globalViewport);  

      // Clip off things outside the original viewport.
      RectI scissorRect = globalViewport;
      scissorRect.intersect(viewport);

      glEnable(GL_SCISSOR_TEST);
      glScissor(scissorRect.point.x, Platform::getWindowSize().y - scissorRect.point.y - scissorRect.extent.y, 
                scissorRect.extent.x, scissorRect.extent.y);
      
   }
      
   // Save Projection / Modelview Matrices.
   glMatrixMode(GL_PROJECTION);
   glPushMatrix();

   // Clear the depth-buffer ( in our viewport only ).
   glLoadIdentity();
   glEnable(GL_DEPTH_TEST);
   glDepthFunc(GL_ALWAYS);
   glColor4f(0,0,0,1);
   glColorMask(false, false, false, false);
   glBegin(GL_TRIANGLE_FAN);
   glVertex3f(-1, -1, 0);
   glVertex3f(-1,  1, 0);
   glVertex3f( 1,  1, 0);
   glVertex3f( 1, -1, 0);
   glEnd();
   glColorMask(true, true, true, true);
   
   // Get Shape.
   const TSShape* pShape = mShapeInstance->getShape();
   
   // Fetch Shape Box.
   const Box3F shapeBox = pShape->bounds;
   
   // Fetch Shape Radius.
   const F32 shapeRadius = pShape->radius;
   
   //// Calculate Dimensional Axis.
   const F32 boxX = shapeBox.len_x();
   const F32 boxY = shapeBox.len_y();
   const F32 boxZ = shapeBox.len_z();
   const F32 boxHalfX = shapeBox.len_x() * 0.5f;
   const F32 boxHalfY = shapeBox.len_y() * 0.5f;
   const F32 boxHalfZ = shapeBox.len_z() * 0.5f;
   
   // Calculate Depth Scale.
   const F32 depthScale = getMax(getMax(mShapeScale.x,mShapeScale.y),mShapeScale.z);
   
   // Setup Shape Frustum.
   // NOTE:-   We set the near/far clipping planes to the shape radius which is a
   //          sphere that superscribes the whole shape.  We do this so that the
   //          shape can undergo any arbitrary rotation and not be clipped.
   dglSetFrustum(-boxHalfX, +boxHalfX, -boxHalfY, +boxHalfY, -shapeRadius*depthScale, 10.0f * shapeRadius * depthScale, true);
   
   // Set-up our Modelview matrix.
   glMatrixMode(GL_MODELVIEW);
   glPushMatrix();
   glLoadIdentity();
   
   // Fetch the quaternion rotation (no gimbal lock!).
   MatrixF xForm;
   mAngularQuaternion.setMatrix(&xForm);
   dglMultMatrix(&xForm);
   
   // Set Shape Scale.
   glScalef(mShapeScale.x, mShapeScale.y, mShapeScale.z);
   
   // Convert Shape Offset from World-Space to Clipping-Space.
   const t2dVector localSize = getSize();
   const Point3F clipShapeOffset(mShapeOffset.x/localSize.mX, mShapeOffset.y, mShapeOffset.z/localSize.mY);
   
   // Calculate Center Offset.
   const Point3F centerOffset = -pShape->center - clipShapeOffset;
   // Translate by offset.
   glTranslatef( centerOffset.x, centerOffset.y, centerOffset.z );
   
   // Normal Depth-Testing.
   glEnable(GL_DEPTH_TEST);
   glDepthFunc(GL_LEQUAL);
   
   // Set Current Detail.
   mShapeInstance->setCurrentDetail( mShapeDetailLevel, mShapeIntraDetailLevel );
   
   // Set Alpha-Blending (use object alpha).
   mShapeInstance->setAlphaAlways( getBlendAlpha() );
   mShapeInstance->render();
   
   // Restore Texture Environment.
   glTexEnvi( GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_MODULATE );
   
   // Reset Projection/Modelview.
   glPopMatrix();
   glMatrixMode(GL_PROJECTION);
   glPopMatrix();
   glMatrixMode(GL_MODELVIEW);
   
   // Disable Depth-Testing.
   glDisable(GL_DEPTH_TEST);
   
   // Restore Viewport.
   dglSetViewport(viewport);
   
   glDisable(GL_SCISSOR_TEST);
   
   
	// Call Parent.
	Parent::renderObject( viewPort, viewIntersection );	// Always use for Debug Support!
   
   // T2D Debug Profiling.
#ifdef TORQUE_ENABLE_PROFILER
		PROFILE_END();   // T2D_t2dShape3D_renderObject
#endif
	
}


//-----------------------------------------------------------------------------
// Clone With Behaviors Support.
//-----------------------------------------------------------------------------
void t2dShape3D::copyTo(SimObject* obj)
{
   Parent::copyTo(obj);

   AssertFatal(dynamic_cast<t2dShape3D*>(obj), "t2dShape3D::copyTo - Copy object is not a t2dShape3D!");
   t2dShape3D* object = static_cast<t2dShape3D*>(obj);

   // Copy fields
   object->setShape(mShapeFile);
   object->setDetailLevel(mShapeDetailLevel, mShapeIntraDetailLevel);
   object->setShapeAngularVelocity(mShapeAngularVelocity);
   object->setShapeOffset(mShapeOffset);
   object->setShapeRotation(mShapeRotation);
   object->setShapeScale(mShapeScale);
   if ( mAnimationName && (mAnimationName != StringTable->insert("") ))
	   object->playAnimation(mAnimationName);
}


void t2dShape3D::initPersistFields()
{
   addProtectedField("shape", TypeFilename, Offset(mShapeFile, t2dShape3D), &setShape, &defaultProtectedGetFn, "");
   addProtectedField("animation", TypeString, Offset(mAnimationName, t2dShape3D), &setAnimation, &defaultProtectedGetFn, "");
   addProtectedField("detailLevel", TypeS32, Offset(mShapeDetailLevel, t2dShape3D), &setDetailLevel, &defaultProtectedGetFn, "");
   addProtectedField("intraDetailLevel", TypeS32, Offset(mShapeIntraDetailLevel, t2dShape3D), &setIntraDetailLevel, &defaultProtectedGetFn, "");
   addProtectedField("shapeAngularVelocity", TypePoint3F, Offset(mShapeAngularVelocity, t2dShape3D), &setShapeAngularVelocity, &defaultProtectedGetFn, "");
   addProtectedField("shapeOffset", TypePoint3F, Offset(mShapeOffset, t2dShape3D), &setShapeOffset, &defaultProtectedGetFn, "");
   addProtectedField("shapeRotation", TypePoint3F, Offset(mShapeRotation, t2dShape3D), &setShapeRotation, &defaultProtectedGetFn, "");
   addProtectedField("shapeScale", TypePoint3F, Offset(mShapeScale, t2dShape3D), &setShapeScale, &defaultProtectedGetFn, "");

   Parent::initPersistFields();
}
