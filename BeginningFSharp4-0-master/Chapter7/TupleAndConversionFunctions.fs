#if INTERACTIVE
#else
module TupleAndConversionFunctions
#endif

// Get the first and second elements of a tuple:
printfn "(fst (1, 2)): %i" (fst (1, 2))
printfn "(snd (1, 2)): %i" (snd (1, 2))

// Convert an int into an enum:
open System

let dayInt = int DateTime.Now.DayOfWeek
let (dayEnum : DayOfWeek) = enum dayInt

printfn "%i" dayInt
printfn "%A" dayEnum
