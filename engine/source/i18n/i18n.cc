//-----------------------------------------------------------------------------
// Torque Game Engine 
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

#include "platform/platform.h"
#include "core/stream.h"
#include "core/fileStream.h"
#include "core/resManager.h"
#include "console/console.h"

#include "i18n/i18n.h"
#include "i18n/lang.h"

//////////////////////////////////////////////////////////////////////////
// Globals
//////////////////////////////////////////////////////////////////////////

// [tom, 3/17/2005] Note: This is created in script
static LangTable *gCoreLangTable = NULL;

// [tom, 3/17/2005] Defined in CoreStringsDefaults.cc, which is generated by langc
//extern const UTF8 *gI18NDefaultStrings[];

// [tom, 5/2/2005] Note: Temporary kludge to keep this compilable while
// the core localization isn't finished.
static const UTF8 *gI18NDefaultStrings[] =
{
	NULL
};

//////////////////////////////////////////////////////////////////////////

const UTF8 *getCoreString(S32 id)
{
	if(gCoreLangTable)
		return gCoreLangTable->getString(id);
	else
		return gI18NDefaultStrings[id];
}

//////////////////////////////////////////////////////////////////////////

ConsoleFunction(getCoreLangTable, S32, 1, 1, "() Get the ID of the core language table\n"
				"@return The table's ID as an S32 value.")
{
	if(gCoreLangTable)
		return gCoreLangTable->getId();
   else
      return 0;
}

ConsoleFunction(setCoreLangTable, void, 2, 2, "(LangTable) Sets the core language table to the one specified\n"
				"@param LangTable The desired language table object to set.\n"
				"@return No return value.")
{
	LangTable *lt;
   
   if(Sim::findObject(argv[1], lt))
		gCoreLangTable = lt;
   else
      Con::errorf("setCoreLangTable - Unable to find LanTable '%s'", argv[1]);
}

//////////////////////////////////////////////////////////////////////////
