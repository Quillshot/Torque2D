//-----------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//
// T2D Shape 3D
//-----------------------------------------------------------------------------

#ifndef _T2DSHAPE3D_H_
#define _T2DSHAPE3D_H_

#ifndef _T2DSCENEOBJECT_H_
#include "./t2dSceneObject.h"
#endif

#ifndef _TSSHAPEINSTANCE_H_
#include "ts/tsShapeInstance.h"
#endif


//-----------------------------------------------------------------------------
// T2D Shape 3D.
//-----------------------------------------------------------------------------
class t2dShape3D : public t2dSceneObject
{
	typedef t2dSceneObject			Parent;

protected:
	StringTableEntry	mShapeFile;
	TSShapeInstance*	mShapeInstance;
	TSThread*			mShapeThread;
   StringTableEntry  mAnimationName;
    S32                 mShapeDetailLevel;
    F32                 mShapeIntraDetailLevel;
	QuatF				mAngularQuaternion;
    VectorF             mShapeRotation;
    VectorF				mShapeAngularVelocity;
    bool                mShapeAngularVelocityActive;
    bool                mTriggerActive;

    VectorF             mShapeOffset;
    VectorF             mShapeScale;

public:
	t2dShape3D();
	~t2dShape3D();

   static void initPersistFields();
   static bool setShape(void* obj, const char* data) { static_cast<t2dShape3D*>(obj)->setShape(data); return false; };
   static bool setAnimation(void* obj, const char* data) { static_cast<t2dShape3D*>(obj)->playAnimation(data); return false; };
   static bool setDetailLevel(void* obj, const char* data) { static_cast<t2dShape3D*>(obj)->setDetailLevel(dAtoi(data)); return false; };
   static bool setIntraDetailLevel(void* obj, const char* data) { static_cast<t2dShape3D*>(obj)->setDetailLevel(static_cast<t2dShape3D*>(obj)->getCurrentDetailLevel(), dAtof(data)); return false; };
   static bool setShapeAngularVelocity(void* obj, const char* data) { static_cast<t2dShape3D*>(obj)->setShapeAngularVelocity(getStringElementVector3D(data)); return false; };
   static bool setShapeOffset(void* obj, const char* data) { static_cast<t2dShape3D*>(obj)->setShapeOffset(getStringElementVector3D(data)); return false; };
   static bool setShapeRotation(void* obj, const char* data) { static_cast<t2dShape3D*>(obj)->setShapeRotation(getStringElementVector3D(data)); return false; };
   static bool setShapeScale(void* obj, const char* data) { static_cast<t2dShape3D*>(obj)->setShapeScale(getStringElementVector3D(data)); return false; };

	bool setShape( const char* pShapeFile );
	bool setSkin(const char* pSkinSet, const char* pSkinName);
   void getTextureFileList( Vector<StringTableEntry>& files );
    bool setDetailLevel( const U32 detailLevel, const F32 intraDetail = 1.0f );
	bool setTriggerActive( const bool status );
    void setShapeRotation( const EulerF& rotation );
	void setShapeAngularVelocity( const EulerF& shapeAngular );
    void setShapeOffset( const VectorF& shapeOffset );
    bool setShapeScale( const VectorF& shapeScale );
    bool setTimeScale( const F32 timeScale );

	bool playAnimation( const char* sequenceName, F32 startTime = 0.0f, const F32 transitionTime = 0.0f );
    bool playAnimationSequence( const S32 sequence, F32 startTime = 0.0f, const F32 transitionTime = 0.0f );

    const EulerF& getShapeAngularVelocity( void )   { return mShapeAngularVelocity; };
    const QuatF& getShapeAngularRotation( void ) { return mAngularQuaternion; };
    const EulerF& getShapeRotation( void );
    const Point3F& getShapeOffset( void )   { return mShapeOffset; };
    const Point3F& getShapeScale( void )   { return mShapeScale; };

	bool getIsShapeValid( void )                    { return mShapeInstance != NULL; };
    bool getIsShapeThreadValid( void )              { return mShapeThread != NULL; };
    U32 getDetailLevelCount( void );
    S32 getCurrentDetailLevel( void );
    F32 getCurrentIntraDetailLevel( void );
	void unloadShape( void );
    void resetAllTriggers( void );

    static inline VectorF& transpose3D2D(VectorF& vector);
    static inline VectorF& degToRad3D(VectorF& vector);

	virtual bool onAdd();
	virtual void onRemove();
	virtual void integrateObject( const F32 sceneTime, const F32 elapsedTime, CDebugStats* pDebugStats );   
	virtual void renderObject( const RectF& viewPort, const RectF& viewIntersection );

	/// Clone support
	void copyTo(SimObject* obj);

	// Declare Serialise Object.
	DECLARE_T2D_SERIALISE( t2dShape3D );
	// Declare Serialise Objects.
	DECLARE_T2D_LOADSAVE_METHOD( t2dShape3D, 1 );

    // Declare Console Object.
	DECLARE_CONOBJECT(t2dShape3D);
};

#endif // _T2DSHAPE3D_H_
