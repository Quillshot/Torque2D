///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------
if(!isObject(IFCTextProfile_S)) new GuiControlProfile (IFCTextProfile_S)
{
   fontType = "Lucida Console";
   fontSize = 30;
   fontColor = "255 255 255";
   Modal = false;
   border = 1;
   borderColor = "0 0 0 255";
   justify = "left";
};

if(!isObject(IFCTextProfile_M)) new GuiControlProfile (IFCTextProfile_M)
{
   fontType = "Lucida Console";
   fontSize = 40;
   fontColor = "255 255 255";
   Modal = false;
   border = 1;
   borderColor = "0 0 0 255";
   justify = "left";
};

if(!isObject(IFCTextProfile_L)) new GuiControlProfile (IFCTextProfile_L)
{
   fontType = "Lucida Console";
   fontSize = 60;
   fontColor = "255 255 255";
   Modal = false;
   border = 1;
   borderColor = "0 0 0 255";
   justify = "left";
};

if(!isObject(IFCTextProfile_XL)) new GuiControlProfile (IFCTextProfile_XL)
{
   fontType = "Lucida Console";
   fontSize = 80;
   fontColor = "255 255 255";
   Modal = false;
   border = 1;
   borderColor = "0 0 0 255";
   justify = "left";
};

if(!isObject(IFCFillWrapper)) new GuiControlProfile (IFCFillWrapper)
{
   border          = 0;
   fillColor       = "0 0 0 0";
   opaque          = false;
};

if(!isObject(IFCFill_White)) new GuiControlProfile (IFCFill_White : GuiDefaultProfile)
{
   border          = 0;
   fillColor       = "255 255 255 255";
   opaque          = true;
};

if(!isObject(IFCFill_Black)) new GuiControlProfile (IFCFill_Black : GuiDefaultProfile)
{
   border          = 0;
   fillColor       = "0 0 0 255";
   opaque          = true;
};

if(!isObject(IFCFill_Red)) new GuiControlProfile (IFCFill_Red : GuiDefaultProfile)
{
   border          = 0;
   fillColor       = "255 0 0 255";
   opaque          = true;
};

if(!isObject(IFCFill_Green)) new GuiControlProfile (IFCFill_Green : GuiDefaultProfile)
{
   border          = 0;
   fillColor       = "0 255 0 255";
   opaque          = true;
};

if(!isObject(IFCFill_Blue)) new GuiControlProfile (IFCFill_Blue : GuiDefaultProfile)
{
   border          = 0;
   fillColor       = "0 0 255 255";
   opaque          = true;
};

if(!isObject(IFCFill_Red50)) new GuiControlProfile (IFCFill_Red50 : IFCFill_Red)
{
   fillColor       = "255 0 0 128";
};

if(!isObject(IFCFill_Green50)) new GuiControlProfile (IFCFill_Green50 : IFCFill_Green)
{
   fillColor       = "0 255 0 128";
};

if(!isObject(IFCFill_Blue50)) new GuiControlProfile (IFCFill_Blue50 : IFCFill_Blue)
{
   fillColor       = "0 0 255 128";
};

if(!isObject(IFCIconProfile)) new GuiControlProfile (IFCIconProfile)
{
   border          = 0;
   borderColor     = "0 0 0 255";
   fillColor       = "255 255 255 255";
   opaque          = true;
   borderThickness = 2;
};
