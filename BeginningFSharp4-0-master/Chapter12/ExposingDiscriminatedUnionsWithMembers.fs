module Strangelights.ImprovedModule
open System

// Type that can represent a discrete or continuous quantity
// with members to improve interoperability:
type EasyQuantity =
| Discrete of int
| Continuous of float
    // Convert quantity to a float:
    member x.ToFloat() =
        match x with
        | Discrete x -> float x
        | Continuous x -> x
    // Convert quantity to a integer:
    member x.ToInt() =
        match x with
        | Discrete x -> x
        | Continuous x -> int x

// Initalize random number generator:
let rand = new Random()

// Create a random quantity:
let getRandomEasyQuantity() =
    match rand.Next(1) with
    | 0 -> EasyQuantity.Discrete (rand.Next())
    | _ -> 
        EasyQuantity.Continuous 
            (rand.NextDouble() * float (rand.Next()))
