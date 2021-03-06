//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//
// 2D Static Sprite.
//-----------------------------------------------------------------------------

#ifndef _T2DSTATICSPRITE_H_
#define _T2DSTATICSPRITE_H_

#ifndef _T2DSCENEOBJECT_H_
#include "./t2dSceneObject.h"
#endif

#ifndef _T2DIMAGEMAPDATABLOCK_H_
#include "./t2dImageMapDatablock.h"
#endif

#include "T2D/t2dQuadBatch.h"


///-----------------------------------------------------------------------------
/// Static Object 2D.
///-----------------------------------------------------------------------------
class t2dStaticSprite : public t2dSceneObject
{
    typedef t2dSceneObject          Parent;
    t2dImageMapSmartPtr             mImageMapDataBlock;
    StringTableEntry                mImageMapDataBlockName;
    U32                             mFrame;
	bool							mUseSourceRect;
	RectF							mSrcTexCoords;
	RectI							mSrcRect;

    static t2dQuadBatch             sStaticSpriteBatch;


	void setSourceTextureCoords(void);

public:
    t2dStaticSprite();
    virtual ~t2dStaticSprite();

    static void initPersistFields();
    static bool setImageMap(void* obj, const char* data) 
    { 
       //[neo, 5/7/2007 - #2999]
       // Initialization order would call this after setframe and zero out frame so
       // just use current frame instead.
       t2dStaticSprite *spr = static_cast<t2dStaticSprite*>(obj);

       spr->setImageMap(data, spr->mFrame); 
       
       return false; 
    };
    static bool setFrame(void* obj, const char* data) { static_cast<t2dStaticSprite*>(obj)->setFrame(dAtoi(data)); return false; };
    static bool setUseSourceRect(void* obj, const char* data) { static_cast<t2dStaticSprite*>(obj)->setUseSourceRect(dAtob(data)); return false; };
    static bool setSourceRect(void* obj, const char* data) { static_cast<t2dStaticSprite*>(obj)->setSourceRect(getStringElementRectI(data)); return false; };

    bool setImageMap( const char* imageMapName, U32 frame );
    bool setFrame( U32 frame );
	void setUseSourceRect( bool bUseSourceRect ) { mUseSourceRect = bUseSourceRect; setSourceTextureCoords();}
	void setSourceRect( RectI pNewRect );

    const char* getImageMapName( void ) const   { if (mImageMapDataBlock) return mImageMapDataBlock->getName(); else return NULL; };
    U32 getFrame( void ) const                  { return mFrame; };
 	bool		getUseSourceRect( )				{ return mUseSourceRect; }
	RectI		getSourceRect()					{ return mSrcRect; }


    virtual bool onAdd();
    virtual void onRemove();
    virtual void renderObject( const RectF& viewPort, const RectF& viewIntersection );

    virtual void copyTo(SimObject* object);

    /// Declare Serialise Object.
    DECLARE_T2D_SERIALISE( t2dStaticSprite );
    /// Declare Serialise Objects.
    DECLARE_T2D_LOADSAVE_METHOD( t2dStaticSprite, 3 );
	DECLARE_T2D_LOADSAVE_METHOD( t2dStaticSprite, 4 );

    /// Declare Console Object.
    DECLARE_CONOBJECT( t2dStaticSprite );
};

#endif // _T2DSTATICSPRITE_H_
