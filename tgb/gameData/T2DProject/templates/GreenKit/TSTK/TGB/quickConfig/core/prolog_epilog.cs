///------------------------------------------------------
// Copyright Roaming Gamer, LLC.
//------------------------------------------------------
////
//   INITIALIZATION and SHUTDOWN
////

/*
Description: Internal only.  Congfigures RGQC system when the RGQC object is first created.
 */
function RGQC::onAdd( %this )
{   
   //echo("RGQC::onAdd( ", ((%this.getName() $= "") ? %this : %this.getName()) , " ) @ ", getSimTime() );
   %this.Settings[Debug] = true; 

   // Init various $RGQC::* settings
   %this.Settings[TypesMask] = 0;
   %this.Settings[KnownTypes] = "";

   ////
   //   1 - Create All Required Types (optionally assign group numbers)
   ////
   %this.createType( "Player" );
   %this.createType( "Enemy" );
   %this.createType( "PlayerWeapon" );
   %this.createType( "EnemyWeapon" );
   %this.createType( "Wall" );

   ////
   //    2 - Set up individual types' attributes
   ////
   // *********** wall
   %this.collidesWith( "player", "enemy,enemyWeapon" );
   %this.collidesWith( "enemy", "player,playerWeapon" );
   %this.collidesWith( "wall", "player,enemy,playerWeapon,enemyWeapon" );

}