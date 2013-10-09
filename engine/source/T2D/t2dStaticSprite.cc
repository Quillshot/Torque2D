//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//
// 2D Static Sprite.
//-----------------------------------------------------------------------------

#include "dgl/dgl.h"
#include "console/consoleTypes.h"
#include "core/bitStream.h"
#include "./t2dStaticSprite.h"
#include "core/stringBuffer.h"


//------------------------------------------------------------------------------

IMPLEMENT_CONOBJECT(t2dStaticSprite);

t2dQuadBatch t2dStaticSprite::sStaticSpriteBatch;


//-----------------------------------------------------------------------------
// Constructor.
//-----------------------------------------------------------------------------
t2dStaticSprite::t2dStaticSprite() :    T2D_Stream_HeaderID(makeFourCCTag('2','D','S','S')),
                                        mImageMapDataBlock(NULL),
                                        mImageMapDataBlockName(NULL),
                                        mFrame(0),
										mUseSourceRect(false),
										mSrcRect(0, 0, 0, 0),
										mSrcTexCoords(0.0f, 0.0f, 1.0f, 1.0f)
{
}

//-----------------------------------------------------------------------------
// Destructor.
//-----------------------------------------------------------------------------
t2dStaticSprite::~t2dStaticSprite()
{
}

void t2dStaticSprite::initPersistFields()
{
   addProtectedField("imageMap", TypeString, Offset(mImageMapDataBlockName, t2dStaticSprite), &setImageMap, &defaultProtectedGetFn, "");
   addProtectedField("frame", TypeS32, Offset(mFrame, t2dStaticSprite), &setFrame, &defaultProtectedGetFn, "");
   addProtectedField("useSourceRect", TypeBool, Offset(mUseSourceRect, t2dStaticSprite), &setUseSourceRect, &defaultProtectedGetFn, "");
   addProtectedField("sourceRect", TypeRectI, Offset(mSrcRect, t2dStaticSprite), &setSourceRect, &defaultProtectedGetFn, "");

   Parent::initPersistFields();

   // Bad place for this, but submit the static sprite quad batch to the batcher
   t2dQuadBatch::submitBatch( &sStaticSpriteBatch );
}

//-----------------------------------------------------------------------------
// OnAdd
//-----------------------------------------------------------------------------
bool t2dStaticSprite::onAdd()
{
    // Eventually, we'll need to deal with Server/Client functionality!

    // Call Parent.
    if(!Parent::onAdd())
        return false;
   
	//calculate the texture coordinates
	setSourceTextureCoords();
	
	// Return Okay.
    return true;
}


//-----------------------------------------------------------------------------
// OnRemove.
//-----------------------------------------------------------------------------
void t2dStaticSprite::onRemove()
{
    // Call Parent.
    Parent::onRemove();
}


//-----------------------------------------------------------------------------
// Set ImageMap.
//-----------------------------------------------------------------------------
ConsoleMethod(t2dStaticSprite, setImageMap, bool, 3, 4, "(string imageMapName, [int frame]) - Sets imageMap/Frame.\n"
														"@param imageMapName The imagemap to display\n"
														"@param frame The frame of the imagemap to display\n"
														"@return Returns true on success.")
{
    // Calculate Frame.
    U32 frame = argc >= 4 ? dAtoi(argv[3]) : 0;

    // Set ImageMap.
    return object->setImageMap( argv[2], frame );
}   
// Set ImageMap/Frame.
bool t2dStaticSprite::setImageMap( const char* imageMapName, U32 frame )
{
    // Invalid ImageMap Name.
    if ( !imageMapName || imageMapName == StringTable->insert("") )
        return false;

    // Find ImageMap Datablock.
    t2dImageMapDatablock* pImageMapDataBlock = dynamic_cast<t2dImageMapDatablock*>(Sim::findObject( imageMapName ));

    // Set Datablock.
    if ( !t2dCheckDatablock( pImageMapDataBlock ) )
    {
        // Warn.
        Con::warnf("t2dStaticSprite::setImageMap() - t2dImageMapDatablock Datablock is invalid! (%s)", imageMapName);
        // Return Here.
        return false;
    }

    // Check Frame Validity.
    if ( frame >= pImageMapDataBlock->getImageMapFrameCount() )
    {
        // Warn.
        Con::warnf("t2dStaticSprite::setImageMap() - Invalid Frame #%d for t2dImageMapDatablock Datablock! (%s)", frame, imageMapName);
        // Return Here.
        return false;
    }

    // Set ImageMap Datablock.
    mImageMapDataBlockName = StringTable->insert(imageMapName);
    mImageMapDataBlock = pImageMapDataBlock;
    

    // Set Frame.
    mFrame = frame;
	
	//calculate the texture coordinates
	setSourceTextureCoords();

    // Return Okay.
    return true;
}




//-----------------------------------------------------------------------------
// Set ImageMap Frame.
//-----------------------------------------------------------------------------
ConsoleMethod(t2dStaticSprite, setFrame, bool, 3, 3, "(int frame) - Sets imageMap frame.\n"
													 "@param frame The frame to display\n"
													 "@return Returns true on success.")
{
    // Set ImageMap Frame.
    return object->setFrame( dAtoi(argv[2]) );
}   
// Set ImageMap/Frame.
bool t2dStaticSprite::setFrame( U32 frame )
{
    // Check Existing ImageMap.
    if ( !mImageMapDataBlock )
    {
        // Warn.
        Con::warnf("t2dStaticSprite::setFrame() - Cannot set Frame without existing t2dImageMapDatablock Datablock!");
        // Return Here.
        return false;
    }

    // Check Frame Validity.
    if ( frame >= mImageMapDataBlock->getImageMapFrameCount() )
    {
        // Warn.
        Con::warnf("t2dStaticSprite::setFrame() - Invalid Frame #%d for t2dImageMapDatablock Datablock! (%s)", frame, getIdString());
        // Return Here.
        return false;
    }

    // Set Frame.
    mFrame = frame;

    // Return Okay.
    return true;
}


//-----------------------------------------------------------------------------
// Get ImageMap Name.
//-----------------------------------------------------------------------------
ConsoleMethod(t2dStaticSprite, getImageMap, const char*, 2, 2, "() - Gets current imageMap name.\n"
															   "@return (string imageMapName) The imagemap being displayed")
{
    // Get ImageMap Name.
    return object->getImageMapName();
}   


//-----------------------------------------------------------------------------
// Get ImageMap Frame.
//-----------------------------------------------------------------------------
ConsoleMethod(t2dStaticSprite, getFrame, S32, 2, 2, "() - Gets current imageMap Frame.\n"
													"@return (int frame) The frame currently being displayed")
{
    // Get ImageMap Frame.
    return object->getFrame();
}   

//----------------------------------------------------------------------------
// Source rect controls
//----------------------------------------------------------------------------
ConsoleMethod(t2dStaticSprite, getUseSourceRect, bool, 2, 2, "() - Gets whether the source rects are used in this sprite.\n"
															   "@return (bool) 1 if it is being used or 0 if it is not")
{
    //Return correct values
	if(object->getUseSourceRect())
		return 1;
	else
		return 0;
}   

ConsoleMethod(t2dStaticSprite, setUseSourceRect, void, 3, 3, "(shouldUseSourceRect) - Sets whether the source rectangle is used in this scroller.\n"
			  "@param shouldUseSourceRect 1 to use a source rect, 0 otherwise")
{
	if(dAtob(argv[2]))
	{
		object->setUseSourceRect(true);
	}
	else if(dAtob(argv[2]))
	{
		object->setUseSourceRect(false);
	}
	else
	{
		Con::errorf("Bad data passed to setUseSourceRect. Defaulting to 0");
		object->setUseSourceRect(false);
	}
}   


ConsoleMethod(t2dStaticSprite, getSpriteSourceRect, const char*, 2, 2, "() - Gets the source rect of this sprite.\n"
															   "@return (four component rect) X Y Width Height")
{
	if(object->getUseSourceRect())
	{
		RectI source = object->getSourceRect();
		//Return correct values
		StringBuffer value;
		char topleft[4];
		char topright[4];
		char width[4];
		char height[4];

		dItoa(source.point.x, topleft);
		dItoa(source.point.y, topright);
		dItoa(source.extent.x, width);
		dItoa(source.extent.y, height);

		value.append(topleft);
		value.append(" ");
		value.append(topright);
		value.append(" ");
		value.append(width);
		value.append(" ");
		value.append(height);
		
		const char* values = value.createCopy8();
		return values;
	}
	else
	{
		return "0 0 0 0";
	}

	return "0 0 0 0";
}   

//-----------------------------------------------------------------------------
// Set the source rect
//-----------------------------------------------------------------------------
ConsoleMethod( t2dStaticSprite, setSpriteSourceRect, void, 3, 3, "(S32 x, S32 y, S32 w, S32 h) Set the source rect for the object")
{
	if(argc == 3)
	{
		F32 xCoordinate;
		F32 yCoordinate;
		F32 width;
		F32 height;
		S32 arguments = dSscanf(argv[2], "%g %g %g %g", &xCoordinate, &yCoordinate, &width, &height);

		if(arguments == 4)
		{
			RectI tempRect = RectI(xCoordinate, yCoordinate, width, height);
			object->setSourceRect(tempRect);
		}
	}
	else
	{
		Con::errorf("Bad data passed to setSpriteSourceRect. Defaulting to NULL rectangle");
		object->setSourceRect(RectI(0,0,0,0));
	}
}

void t2dStaticSprite::copyTo(SimObject* object)
{
   AssertFatal(dynamic_cast<t2dStaticSprite*>(object), "t2dStaticSprite::copyTo - Copy object is not a t2dStaticSprite!");
   t2dStaticSprite* staticSprite = static_cast<t2dStaticSprite*>(object);
   staticSprite->setImageMap(getImageMapName(), getFrame());
   
   staticSprite->setUseSourceRect(getUseSourceRect());
   staticSprite->setSourceRect(getSourceRect());
   
   Parent::copyTo(object);
}


//-----------------------------------------------------------------------------
// Set up source rect for the object
//-----------------------------------------------------------------------------
void t2dStaticSprite::setSourceRect(RectI pNewRect)
{
	if(pNewRect.isValidRect() && !(pNewRect.len_x() < 0.001) && !(pNewRect.len_y() < 0.001))
	{
		mUseSourceRect = true;
		mSrcRect = RectI(pNewRect.point.x, pNewRect.point.y, pNewRect.extent.x, pNewRect.extent.y  );
	}
	else
	{
		mUseSourceRect = false;
		mSrcRect = RectI(0, 0, 0, 0);
	}

	//set new texture coordinates
	setSourceTextureCoords();
}


//-----------------------------------------------------------------------------
// Calculate the source texture coords for this object
//-----------------------------------------------------------------------------
void t2dStaticSprite::setSourceTextureCoords(void)
{
	if(mUseSourceRect)
	{
		F32 minX = 0;
		F32 minY = 0;
		F32 maxX = 0;
		F32 maxY = 0;

		if( mSrcRect.isValidRect())
		{
			if(mImageMapDataBlock)
			{
				const TextureHandle& texture = mImageMapDataBlock->getImageMapFrameTexture( mFrame );
				F32	fTexelWidth = 1.0f / texture.getWidth();
				F32	fTexelHeight = 1.0f / texture.getHeight();
				
				F32	fAreaWidth = mSrcRect.extent.x * fTexelWidth;
				F32	fAreaHeight = mSrcRect.extent.y * fTexelHeight;
				
				minX = mSrcRect.point.x * fTexelWidth;
				minY = mSrcRect.point.y * fTexelHeight;
				maxX = minX + fAreaWidth;
				maxY = minY + fAreaHeight;
			}
		}
		else
		{
			Con::warnf("t2dStaticSprite :: Invalid Source Rect (%s) Ignoring (no rendering will happen!)" ,mImageMapDataBlockName);
		}

		mSrcTexCoords = RectF(minX, minY, maxX, maxY);
	}
	else
	{
		// Fetch Current Frame Area as normal
		if(mImageMapDataBlock)
		{
			const t2dImageMapDatablock::cFrameTexelArea& frameArea = mImageMapDataBlock->getImageMapFrameArea( 0 );
			mSrcTexCoords = RectF(frameArea.mX, frameArea.mY, frameArea.mX2, frameArea.mY2);
		}
		else
		{
			mSrcTexCoords = RectF();
		}
	}
}

//-----------------------------------------------------------------------------
// Render Object.
//-----------------------------------------------------------------------------
void t2dStaticSprite::renderObject( const RectF& viewPort, const RectF& viewIntersection )
{
    // Cannot render without Texture.
    if ( !mImageMapDataBlock )
        return;

    // Insert this sprite into the render list instead
    if( false && getSceneGraph() && getSceneGraph()->getCurrentRenderWindow() ) // Disable this for now -pw
      sStaticSpriteBatch.submitQuad( &mWorldClipBoundary[0], mImageMapDataBlock, mFrame );
    else
    {
       // Bind Texture.
       glEnable        ( GL_TEXTURE_2D );
       mImageMapDataBlock->bindImageMapFrame( mFrame );
       glTexEnvi       ( GL_TEXTURE_ENV, GL_TEXTURE_ENV_MODE, GL_MODULATE );

       // Set Blend Options.
       setBlendOptions();

	   //handle source rects
	   if(!mUseSourceRect)
	   {
		   // Fetch Current Frame Area as normal
		   const t2dImageMapDatablock::cFrameTexelArea& frameArea = mImageMapDataBlock->getImageMapFrameArea( mFrame );
		   mSrcTexCoords = RectF(frameArea.mX,frameArea.mY,frameArea.mX2,frameArea.mY2);
       }
       
       // Fetch Positions.
       const F32& minX = mSrcTexCoords.point.x;
       const F32& minY = mSrcTexCoords.point.y;
       const F32& maxX = mSrcTexCoords.extent.x;
       const F32& maxY = mSrcTexCoords.extent.y;

       // Draw Object.
       glBegin(GL_QUADS);
         glTexCoord2f( minX, minY );
         glVertex2fv ( (GLfloat*)&(mWorldClipBoundary[0]) );
         glTexCoord2f( maxX, minY );
         glVertex2fv ( (GLfloat*)&(mWorldClipBoundary[1]) );
         glTexCoord2f( maxX, maxY );
         glVertex2fv ( (GLfloat*)&(mWorldClipBoundary[2]) );
         glTexCoord2f( minX, maxY );
         glVertex2fv ( (GLfloat*)&(mWorldClipBoundary[3]) );
       glEnd();

       // Disable Texturing.
       glDisable       ( GL_TEXTURE_2D );
    }

    // Call Parent.
    Parent::renderObject( viewPort, viewIntersection ); // Always use for Debug Support!
}

//-----------------------------------------------------------------------------
// Serialisation.
//-----------------------------------------------------------------------------

// Register Handlers.
REGISTER_SERIALISE_START( t2dStaticSprite )
    REGISTER_SERIALISE_VERSION( t2dStaticSprite, 3, false )
	REGISTER_SERIALISE_VERSION( t2dStaticSprite, 4, false )
REGISTER_SERIALISE_END()

// Implement Parent  Serialisation.
IMPLEMENT_T2D_SERIALISE_PARENT( t2dStaticSprite, 4 )


//-----------------------------------------------------------------------------
// Load v3
//-----------------------------------------------------------------------------
IMPLEMENT_T2D_LOAD_METHOD( t2dStaticSprite, 3 )
{
    U32                     frame;
    bool                    imageMapFlag;
    char                    imageMapName[256];

    // Read Ad-Hoc Info.
    if ( !stream.read( &imageMapFlag ) )
        return false;

    // Do we have an imageMap?
    if ( imageMapFlag )
    {
        // Yes, so read ImageMap Name.
        stream.readString( imageMapName );

        // Read Frame.
        if  ( !stream.read( &frame ) )
            return false;

        // Set ImageMap/Frame.
        object->setImageMap( imageMapName, frame );
    }

    // Return Okay.
    return true;
}

//-----------------------------------------------------------------------------
// Save v3
//-----------------------------------------------------------------------------
IMPLEMENT_T2D_SAVE_METHOD( t2dStaticSprite, 3 )
{
    // Ad-Hoc Info.
    if ( object->mImageMapDataBlock )
    {
        // Write ImageMap Datablock Name.
        if ( !stream.write( true ) )
            return false;

        // Write ImageMap Datablock Name.
        stream.writeString( object->mImageMapDataBlock->getName() );

        // Write Frame.
        if  ( !stream.write( object->mFrame ) )
            return false;
    }
    else
    {
        // Write "No ImageMap Datablock".
        if ( !stream.write( false ) )
            return false;
    }

    // Return Okay.
    return true;
}


//-----------------------------------------------------------------------------
// Load v4
//-----------------------------------------------------------------------------
IMPLEMENT_T2D_LOAD_METHOD( t2dStaticSprite, 4 )
{
    U32                     frame;
    bool                    imageMapFlag;
    char                    imageMapName[256];
	bool                    useSourceRect;
	char					sourceRect[256];

    // Read Ad-Hoc Info.
    if ( !stream.read( &imageMapFlag ) )
        return false;

    // Do we have an imageMap?
    if ( imageMapFlag )
    {
        // Yes, so read ImageMap Name.
        stream.readString( imageMapName );

        // Read Frame.
        if  ( !stream.read( &frame ) )
            return false;

        // Set ImageMap/Frame.
        object->setImageMap( imageMapName, frame );
    }

	if( !stream.read( &useSourceRect ) )
		return false;

	object->setUseSourceRect( useSourceRect );

	if(useSourceRect)
	{
		stream.readString(sourceRect);
		F32 xCoordinate;
		F32 yCoordinate;
		F32 width;
		F32 height;
		S32 arguments = dSscanf(sourceRect, "%g %g %g %g", &xCoordinate, &yCoordinate, &width, &height);

		if(arguments == 4)
		{
			RectI tempRect = RectI(xCoordinate, yCoordinate, width, height);
			object->setSourceRect(tempRect);
		}
	}
	else
	{
		RectI tempRect(0, 0, 0, 0);
	}

    // Return Okay.
    return true;
}

//-----------------------------------------------------------------------------
// Save v4
//-----------------------------------------------------------------------------
IMPLEMENT_T2D_SAVE_METHOD( t2dStaticSprite, 4 )
{
    // Ad-Hoc Info.
    if ( object->mImageMapDataBlock )
    {
        // Write ImageMap Datablock Name.
        if ( !stream.write( true ) )
            return false;

        // Write ImageMap Datablock Name.
        stream.writeString( object->mImageMapDataBlock->getName() );

        // Write Frame.
        if  ( !stream.write( object->mFrame ) )
            return false;
    }
    else
    {
        // Write "No ImageMap Datablock".
        if ( !stream.write( false ) )
            return false;
    }

	if( !stream.write( object->mUseSourceRect ) )
		return false;
	
	if( object->mUseSourceRect )
	{
		RectI source = object->getSourceRect();

		//Return correct values
		StringBuffer value;
		char topleft[4];
		char topright[4];
		char width[4];
		char height[4];

		dItoa(source.point.x, topleft);
		dItoa(source.point.y, topright);
		dItoa(source.extent.x, width);
		dItoa(source.extent.y, height);

		value.append(topleft);
		value.append(" ");
		value.append(topright);
		value.append(" ");
		value.append(width);
		value.append(" ");
		value.append(height);
		
		const char* values = value.createCopy8();
		
		if( !stream.write(values) )
			return false;
	}
	else
	{
		if( !stream.write("0 0 0 0" ) )
			return false;
	}

    // Return Okay.
    return true;
}


