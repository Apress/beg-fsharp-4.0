#if INTERACTIVE
#else
module FSharpTypesWithMembers
#endif

// A point type with a member:
type Point =
    { Top: int;
      Left: int }
    with
        // The swap member creates a new point
        // with the left/top coords reveresed:
        member x.Swap() =
            { Top = x.Left;
              Left = x.Top }

// Create a new point:
let myPoint = 
    { Top = 3;
      Left = 7 }
     
// Print the inital point:
printfn "%A" myPoint
// Create a new point with the coords swapped:
let nextPoint = myPoint.Swap()
// Print the new point:
printfn "%A" nextPoint

// A DU with a member:
type DrinkAmount =
    | Coffee of int
    | Tea of int
    | Water of int
    with
        // Get a string representation of the value:
        override x.ToString() =
            match x with
            | Coffee x -> Printf.sprintf "Coffee: %i" x
            | Tea x -> Printf.sprintf "Tea: %i" x
            | Water x -> Printf.sprintf "Water: %i" x

// Create a new instance of DrinkAmount:
let t = Tea 2

// Print out the string:
printfn "%s" (t.ToString())
