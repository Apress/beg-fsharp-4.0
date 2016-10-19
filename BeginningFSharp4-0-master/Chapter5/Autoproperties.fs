#if INTERACTIVE
#else
module Autoproperties
#endif

// A class which defines a simple mutable property, the hard way:
type Circle() =
    let mutable radius = 0.0
    member x.Radius 
        with get() = radius
        and set(r) = radius <- r

// A class which implments a simple mutable property, the easy way:
type Circle2() =
    member val Radius = 0.0 with get, set

// Accessing the properties:
let c = Circle()
c.Radius <- 99.9
printf "Radius: %f" c.Radius

let c2 = Circle2()
c2.Radius <- 99.9
printf "Radius: %f" c2.Radius