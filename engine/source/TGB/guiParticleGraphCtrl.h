//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

#ifndef _GUIPARTICLEGRAPHCTRL_H_
#define _GUIPARTICLEGRAPHCTRL_H_

#ifndef _GUICONTROL_H_
#include "gui/core/guiControl.h"
#endif
#ifndef _GTEXMANAGER_H_
#include "dgl/gTexManager.h"
#endif
#ifndef _STRINGTABLE_H_
#include "core/stringTable.h"
#endif


class GuiParticleGraphCtrl : public GuiControl
{
private:
	typedef GuiControl Parent;

protected:
   /// The color of the nuts.
   ColorI            mNutColor;
   /// The outline color of the nuts.
   ColorI            mOutlineColor;
   /// The rectangle size to check for clicks on nuts (default 8) which is RectI( pointClick - 4, pointClick - 4, 8, 8 )
   S32               mVertexClickSize;

   Point2I findHitNut( Point2I hitPoint );

public:
   enum Constants {
      MaxPlots = 32,
      MaxDataPoints = 200
   };

   enum GraphType {
      Point,
      Polyline,
      Filled,
      Bar
   };

   struct PlotInfo
   {
	  ColorF		  mGraphColor;
	  Vector<Point2F> mGraphData;
	  Vector<Point2F> mNutList;
	  Point2F		  mGraphMax;
	  Point2F		  mGraphMin;
	  GraphType		  mGraphType;
	  StringTableEntry            mGraphName;
	  bool            mHidden;
	  F32             mGraphScale;
   };

   S32          mSelectedPlot;
   S32          mSelectedPoint;
   S32          mOriginalSelectedPoint;
   S32          mLastSelectedPoint;
   S32          mTooltipSelectedPlot;
   S32          mAddedPointIndex;
   bool         mAutoMax;
   bool         mAutoRemove;
   bool         mRenderAllPoints;
   bool         mPointWasAdded;
   bool         mRenderGraphTooltip;
   bool         mRenderNextGraphTooltip;
   bool         mPointXMovementClamped;
   Point2F      mAddedPoint;
   Point2F      mLastMousePos;

   Point2I      mCursorPos;

   PlotInfo		mPlots[MaxPlots];

	//creation methods
   DECLARE_CONOBJECT(GuiParticleGraphCtrl);
   GuiParticleGraphCtrl();
   virtual ~GuiParticleGraphCtrl() { };

   void onMouseMove(const GuiEvent &event);
   void onMouseDown( const GuiEvent &event );
   void onMouseUp( const GuiEvent &event );
   void onMouseDragged( const GuiEvent &event );
   void onRightMouseDown( const GuiEvent &event );
   void onRightMouseUp( const GuiEvent &event );
   void onRightMouseDragged( const GuiEvent &event );

   //Parental methods
   bool onWake();

   void onRender(Point2I offset, const RectI &updateRect);
   bool renderGraphTooltip(Point2I cursorPos, StringTableEntry tooltip);

   // Graph interface
   S32 addPlotPoint(S32 plotID, Point2F v, bool setAdded = true);
   void insertPlotPoint(S32 plotID, S32 i, Point2F v);
   S32 changePlotPoint(S32 plotID, S32 i, Point2F v);
   S32 removePlotPoint(S32 plotID, S32 i);
   Point2F convertToGraphCoord(S32 plotID, Point2I v);
   
   // Set Graph specific functions
   void setGraphType(S32 plotID, const char *graphType);
   void setSelectedPlot(S32 plotID);
   void setSelectedPoint(S32 point);
   void resetSelectedPoint();
   void setGraphHidden(S32 plotID, bool isHidden);

   // Set Global Options
   void setAutoGraphMax(bool autoMax);
   void setAutoRemove(bool autoRemove);
   void setRenderAll(bool renderAll);
   void setRenderGraphTooltip(bool renderGraphTooltip);
   void setPointXMovementClamped(bool clamped);

   // Get Functions
   Point2F getGraphExtent(S32 plotID);
   ColorF getGraphColor(S32 plotID);
   S32 getSelectedPlot();
   S32 getSelectedPoint();
   Point2F getPlotPoint(S32 plotID, S32 samples);
   S32 getPlotIndex(S32 plotID, F32 x, F32 y);
   Point2F getGraphMax(S32 plotID);
   Point2F getGraphMin(S32 plotID);

   bool isExistingPoint(S32 plotID, S32 point);

   StringTableEntry getGraphName(S32 plotID);
  
   // Set Graph Min and MaxFunctions
   void setGraphMin(S32 plotID, Point2F graphMin);
   void setGraphMinX(S32 plotID, F32 graphMinX);
   void setGraphMinY(S32 plotID, F32 graphMinY);
   void setGraphMax(S32 plotID, Point2F graphMax);
   void setGraphMaxX(S32 plotID, F32 graphMaxX);
   void setGraphMaxY(S32 plotID, F32 graphMaxY);

   // Other set functions for graphs
   void setGraphName(S32 plotID, StringTableEntry graphName);
  

   // Clear Functions
   void clearGraph(S32 plotID);
   void clearAllGraphs();

   // Selection nuts.
   bool inNut( const Point2I &pt, S32 x, S32 y );
   void drawNut( const Point2I &nut, S32 size, ColorI &outlineColor, ColorI &nutColor );
};

#endif
