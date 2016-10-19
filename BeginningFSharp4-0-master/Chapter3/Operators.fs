#if INTERACTIVE
#else
module Operators
#endif

// Use the + operator to concatenate strings:
let rhyme = "Jack " + "and " + "Jill"

// ...or Dates and TimeSpans:
open System

let oneYearLater =
    DateTime.Now + new TimeSpan(365, 0, 0, 0, 0)

// Use brackets to allow an operator to be treated as a function:
let result = (+) 1 1
let add = (+)

// You can redefine operators - use with care!
let (+) a b = a - b
printfn "%i" (1 + 1)

// You can define your own operators:
let (+*) a b = (a + b) * a * b
printfn "(1 +* 2) = %i" (1 +* 2)


