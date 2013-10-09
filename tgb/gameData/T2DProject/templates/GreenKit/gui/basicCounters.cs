///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------
function gameBackground::addNumericCounter( %this, %counterName, %profile, %posX, %posY, %extX, %extY )
{   
   %newIFC = new GuiTextCtrl( %counterName ) 
   {
      class                = "NumericCounter";
      canSaveDynamicFields = "0";
      Profile              = %profile;
      HorizSizing          = "relative";
      VertSizing           = "relative";
      Position             = %posX SPC %posY;
      Extent               = %extX SPC %extY;
      MinExtent            = "8 2";
      canSave              = "1";
      Visible              = "1";
      text                 = "0";
      //maxLength            = 1024;//%digits; // No effect?
   };
   %this.add(%newIFC);
}
function gameBackground::addLabel( %this, %labelText, %profile, %posX, %posY, %extX, %extY )
{   
   %newIFC = new GuiTextCtrl( ) 
   {
      canSaveDynamicFields = "0";
      Profile              = %profile;
      HorizSizing          = "relative";
      VertSizing           = "relative";
      Position             = %posX SPC %posY;
      Extent               = %extX SPC %extY;
      MinExtent            = "8 2";
      canSave              = "1";
      Visible              = 1 ;
      text                 = %labelText;
      maxLength            = 1024;
   };
   %this.add(%newIFC);

   return %extX;
}

function gameBackground::addIcon( %this, %posX, %posY, %width, %height, %iconPath  )
{   
   %thisIcon = new GuiBitmapCtrl( ) 
   {   
      canSaveDynamicFields = "0";
      Profile              = "IFCIconProfile";
      HorizSizing          = "relative";
      VertSizing           = "relative";
      Position             = %posX SPC %posY;
      Extent               = %width SPC %height;
      MinExtent            = "8 2";
      canSave              = "1";
      Visible              = "1";
      bitmap               = %iconPath;
      wrap                 = "0";
   };
   %this.add(%thisIcon);
}

function gameBackground::addVerticalBarMeter( %this, %meterName, %posX, %posY, %width, %height, %profileName  )
{   

   %newIFC = new GuiControl( ) 
   {
      canSaveDynamicFields = "0";
      Profile              = "IFCFillWrapper";
      HorizSizing          = "relative";
      VertSizing           = "relative";
      Position             = %posX SPC %posY;
      Extent               = %width SPC %height;
      MinExtent            = "8 2";
      canSave              = "1";
      Visible              = "1";
      wrap                 = "0";

      new GuiControl( %meterName ) 
      {
         class                = "VerticalBarMeter";
         canSaveDynamicFields = "0";
         Profile              = %profileName;
         HorizSizing          = "relative";
         VertSizing           = "relative";
         Position             = "0 0";
         Extent               = %width SPC %height;
         MinExtent            = "8 2";
         canSave              = "1";
         Visible              = "1";
         wrap                 = "0";
         percent              = "1";
      };
   };
   %this.add(%newIFC);
}
function gameBackground::addHorizontalBarMeter( %this, %meterName, %posX, %posY, %width, %height, %profileName  )
{   

   %newIFC = new GuiControl( ) 
   {
      canSaveDynamicFields = "0";
      Profile              = "IFCFillWrapper";
      HorizSizing          = "relative";
      VertSizing           = "relative";
      Position             = %posX SPC %posY;
      Extent               = %width SPC %height;
      MinExtent            = "8 2";
      canSave              = "1";
      Visible              = "1";
      wrap                 = "0";

      new GuiControl( %meterName ) 
      {
         class                = "HorizontalBarMeter";
         canSaveDynamicFields = "0";
         Profile              = %profileName;
         HorizSizing          = "relative";
         VertSizing           = "relative";
         Position             = "0 0";
         Extent               = %width SPC %height;
         MinExtent            = "8 2";
         canSave              = "1";
         Visible              = "1";
         wrap                 = "0";
         percent              = "1";
      };
   };
   %this.add(%newIFC);
}

function VerticalBarMeter::setValue( %this, %percent )
{
   %baseExt = %this.getParent().getExtent();
   
   %baseExtX = getWord( %baseExt , 0 );
   %baseExtY = getWord( %baseExt , 1 );
   
   if( %percent < 0 ) %percent = 0;
   if( %percent > 1 ) %percent = 1;   
   
   %offsetY = %percent * %baseExtY;
   
   %this.setPosition( 0, %baseExtY - %offsetY );
   
   %this.percent = %percent;   
}

function VerticalBarMeter::getValue( %this, %percent )
{
   return %this.percent;
}

function VerticalBarMeter::increment( %this, %percent )
{
   %oldPercent = %this.getValue();
   %this.setValue( %oldPercent + %percent );
}

function VerticalBarMeter::decrement( %this, %percent )
{
   %oldPercent = %this.getValue();
   %this.setValue( %oldPercent - %percent );
}

function HorizontalBarMeter::setValue( %this, %percent )
{
   %baseExt = %this.getParent().getExtent();
   
   %baseExtX = getWord( %baseExt , 0 );
   %baseExtY = getWord( %baseExt , 1 );
   
   if( %percent < 0 ) %percent = 0;
   if( %percent > 1 ) %percent = 1;   
   
   %offsetX = %percent * %baseExtX;
   
   %this.setPosition( -(%baseExtX - %offsetX), 0 );
   
   %this.percent = %percent;   
}

function HorizontalBarMeter::getValue( %this, %percent )
{
   return %this.percent;
}

function HorizontalBarMeter::increment( %this, %percent )
{
   %oldPercent = %this.getValue();
   %this.setValue( %oldPercent + %percent );
}

function HorizontalBarMeter::decrement( %this, %percent )
{
   %oldPercent = %this.getValue();
   %this.setValue( %oldPercent - %percent );
}


function NumericCounter::increment( %this, %value )
{
   %oldValue = %this.getValue();
   %this.setValue( %oldValue + %value );
}

function NumericCounter::decrement( %this, %value )
{
   %oldValue = %this.getValue();
   %this.setValue( %oldValue - %value );
}

function VerticalBarMeter::autoTest( %this, %totalSteps, %curStep )
{
   if( %totalSteps $= "" ) %totalSteps = 50;
   if ( %curStep $= "" ) %curStep = %totalSteps;
   
   if( %curStep < 0) return;
   
   %halfSteps = %totalSteps / 2;
   
   %down = ( %curStep > %halfSteps );

   %stepDelta = 1 / %halfSteps; 
   
   //error( "autoTest ", %totalSteps SPC %curStep SPC %down SPC %stepDelta );
     
   
   if(%down)
   {
      %this.decrement(%stepDelta);
   }
   else
   {
      %this.increment(%stepDelta);      
   }
   
   %curStep--;
   
   %this.schedule( 30, autoTest, %totalSteps, %curStep );
}
function VerticalBarMeter::autoTest2( %this, %steps )
{
   if( %steps $= "" ) %steps = 100;
   if( %steps < 0 ) return;
   %dir = getRandom(0,1);
   if(%dir)
   {
      %this.increment(getRandom(0,100) / 1000);
   }
   else
   {
      %this.decrement(getRandom(0,100) / 1000);
   }
   %this.schedule( 100, autoTest2, %steps-- );
}

function HorizontalBarMeter::autoTest( %this, %totalSteps, %curStep )
{
   if( %totalSteps $= "" ) %totalSteps = 50;
   if ( %curStep $= "" ) %curStep = %totalSteps;
   
   if( %curStep < 0) return;
   
   %halfSteps = %totalSteps / 2;
   
   %down = ( %curStep > %halfSteps );

   %stepDelta = 1 / %halfSteps; 
   
   //error( "autoTest ", %totalSteps SPC %curStep SPC %down SPC %stepDelta );
     
   
   if(%down)
   {
      %this.decrement(%stepDelta);
   }
   else
   {
      %this.increment(%stepDelta);      
   }
   
   %curStep--;
   
   %this.schedule( 30, autoTest, %totalSteps, %curStep );}

function HorizontalBarMeter::autoTest2( %this, %steps )
{
   if( %steps $= "" ) %steps = 100;
   if( %steps < 0 ) return;
   %dir = getRandom(0,1);
   if(%dir)
   {
      %this.increment(getRandom(0,100) / 1000);
   }
   else
   {
      %this.decrement(getRandom(0,100) / 1000);
   }
   %this.schedule( 100, autoTest2, %steps-- );
}

