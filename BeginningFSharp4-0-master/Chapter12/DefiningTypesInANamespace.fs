namespace Strangelights
open System.Collections.Generic

// this is a counter class
type TheClass(i) =
    let mutable theField = i
    member x.TheField
        with get() = theField
    // increments the counter
    member x.Increment() = 
        theField <- theField + 1
    // decrements the count
    member x.Decrement() = 
        theField <- theField - 1

// this is a module for working with the TheClass
module TheModule = 
    // increments a list of TheClass
    let incList (theClasses: List<TheClass>) = 
        theClasses |> Seq.iter (fun c -> c.Increment())
    // decrements a list of TheClass
    let decList (theClasses: List<TheClass>) = 
        theClasses |> Seq.iter (fun c -> c.Decrement())

