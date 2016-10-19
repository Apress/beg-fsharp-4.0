#if INTERACTIVE
#else
module Inheritance
#endif

// A base class:
type Base() =
    member x.GetState() = 0
    
// A class which inherits from the base class
// and introduces an extra method:
type Sub() =
    inherit Base()
    member x.GetOtherState() = 0

// Instantiate the sub-class:
let myObject = new Sub()

// Call members from the base and the sub class:
printfn
    "myObject.state = %i, myObject.otherState = %i"
    (myObject.GetState())
    (myObject.GetOtherState())
