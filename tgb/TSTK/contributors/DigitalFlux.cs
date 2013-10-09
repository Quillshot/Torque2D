//--------------------------------------------
// Copyright DigitalFlux Entertainment, LLC
//          (www.DigitalFlux.com)
// Free for use in your personal, commercial
// or educational project. Just give us a some
// props in the credits =) 
//--------------------------------------------

/*
Description: Basic die rolling function

Arguments:
 %numDice - Number of dice to roll.
%numSides - Number of sides per die.

Returns: Returns sum of rolled dice.
*/
function rollDice(%numDice, %numSides)
{
   //rolls %numDice number of %numSides sided dice
   %result = 0;
   for(%i = 1; %i < (%numDice + 1); %i++)
   {
      %result += getRandom(%numSides);
   }			
   return %result;
}

/*
Description: Rand in Range function with clamping
Arguments:
EFM - EFM 
Returns: EFM 
*/
function randInRange(%minrange, %maxrange)
{
   %smallrange = %maxrange - %minrange;
   %result = mFloor(getRandom(%smallrange)) + %minrange;
   if(%result >= %maxrange) %result = %maxrange;
   return %result;
}

/*
Description: Rand in Range function using a triple-roll to deliver a Bell Curve distribution
Arguments:
EFM - EFM 
Returns: EFM 
*/
function RandInRangeT(%minrange, %maxrange)
{
   %triplet = %maxrange / 3;
   %result = 0;
   for(%i = 0; %i < 3; %i++)
   {
      %smallrange = %maxrange - %minrange;
      %result += mFloor(getRandom(%smallrange)) + %minrange;
      if(%result >= %maxrange) %result += %maxrange;
   }
   return %result;
}

/*
Description: Target in given ranges of player
Arguments:
EFM - EFM 
Returns: EFM 
*/
function TargetTooCloseTooFar(%source, %target, %minRange, %maxRange)
{
   %distance = VectorDist(%source.getPosition(), %target.getPosition());

   if((%distance < %minRange) || (%distance > %maxRange))
   {
      echo("Either Too Close or Too far");
      return 0;
   }

   return 1;
}

/*
Description: Set a stat on an entity to a specific amount
Arguments:
EFM - EFM 
Returns: EFM 
*/
function setStat(%TargetID, %Stat, %Amt)
{
   %cmd = %TargetID @ "." @ %Stat SPC "=" SPC %Amt @ ";";
   %ret = eval(%cmd);
}

/*
Description: "tick" a stat up or down by a specific amount
Arguments:
EFM - EFM 
Returns: EFM 
*/
function tickStat(%TargetID, %Stat, %Amt)
{
   %cmd = %TargetID @ "." @ %Stat SPC "+=" SPC %Amt @ ";";
   %ret = eval(%cmd);
}

/*
Description: Increase a stat by a rolled amount
Arguments:
EFM - EFM 
Returns: EFM 
*/
function rollStat(%TargetID, %Stat, %RollMin, %RollMax)
{
   //You can also use the randInRangeT() function here... Or any roll function...
   %amt = randInRange(%RollMin, %RollMax);
   %cmd = %TargetID @ "." @ %Stat SPC "+=" SPC %amt @ ";";
   eval(%cmd);
}

/*
Description: Checks a stat on an entity and returns 1 on success, 0 on failure
Arguments:
EFM - EFM 
Returns: EFM 
*/
function checkStat(%TargetID, %Stat, %Amt)
{
   %res = 0;
   %cmd = "if(" @ %TargetID @ "." @ %stat @ " == " @ %Amt @ ") %res = 1; else %res = 0;";
   eval(%cmd);
   return %res;
}

/*
Description: Checks a stat on an entity within a range and returns 1 on success, 0 on failure
Arguments:
EFM - EFM 
Returns: EFM 
*/
function checkStatRanged(%TargetID, %Stat, %Min, %Max)
{
   %res = 0;
   %cmd = "if((" @ %TargetID @ "." @ %stat @ " <= " @ %Min @ ") && (" @ %TargetID @ "." @ %stat @ " >= " @ %Max @ ")) %res = 1; else %res = 0;";
   eval(%cmd);
   return %res;
}

/*
Description: Damage over time function
Arguments:
EFM - EFM 
Returns: EFM 
*/
function DOT(%source, %dmgType, %dmg, %target, %incTime, %totalTime, %timer)
{
   if((%totalTime - %incTime) > 0)
   {
      //Apply damage on this line
      %totalTime = %totalTime - %incTime;
      %timer = schedule(%incTime*1000, %timer, "DOT", %source, %dmgType, %dmg, %target, %incTime, %totalTime, %timer);
   }
   else
   {
      cancel(%timer);
   }
}

/*
Description: Damage over area function
Arguments:
EFM - EFM 
Returns: EFM 
*/
function DOA(%source, %dmgType, %dmg, %radius)
{
   %position = %source.getposition();

   InitContainerRadiusSearch(%position, %radius, $TypeMasks:AIPlayerObjectType | $TypeMasks::PlayerObjectType);

   while(%target = containerSearchNext() != 0)
   {
      if(%target != %source)
      {
         //Apply damage on this line
      }
   }
}

/*
Description: Damage over time and area function
Arguments:
EFM - EFM 
Returns: EFM 
*/
function DOTA(%source, %dmgType, %dmg, %target, %incTime, %totalTime, %timer, %radius)
{
   %position = %source.getposition();

   InitContainerRadiusSearch(%position, %radius, $TypeMasks:AIPlayerObjectType | $TypeMasks::PlayerObjectType);

   while((%target = containerSearchNext()) != 0) 
   {
      if(%target != %source)
         schedule(%incTime*1000, 0, "DOT", %source, %dmgType, %dmg, %target, %incTime, %totalTime, 0);
   }
}