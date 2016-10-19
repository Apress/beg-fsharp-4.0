module Strangelights.DemoModule3
open System

// type that can represent a discrete or continuous quantity
type Quantity =
| Discrete of int
| Continuous of float

// initalize random number generator
let rand = new Random()
// create a random quantity
let getRandomQuantity() =
    match rand.Next(1) with
    | 0 -> Quantity.Discrete (rand.Next())
    | _ -> 
        Quantity.Continuous 
            (rand.NextDouble() * float (rand.Next()))
