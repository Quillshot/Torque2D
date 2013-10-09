#include "component/simpleComponent.h"

IMPLEMENT_CONOBJECT(SimpleComponent);

//////////////////////////////////////////////////////////////////////////
// It may seem like some weak sauce to use a unit test for this, however
// it is very, very easy to set breakpoints in a unit test, and trace 
// execution in the debugger, so I will use a unit test.
//
// Note I am not using much actual 'test' functionality, just providing
// an easy place to examine the functionality that was described and implemented
// in the header file.
//
// If you want to run this code, simply run Torque, pull down the console, and
// type:
//    unitTest_runTests("Components/SimpleComponent");

