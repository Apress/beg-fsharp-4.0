#if INTERACTIVE
#else
module ForwardPipeOperator
#endif

// The definition of the pipe-forward operator
// (for information only - you don't really need
// to define it yourself):
let (|>) x f = f x

// pipe the parameter 0.5 to the sin function
let result = 0.5 |> System.Math.Sin

// Iterating over a list of integers, without the |>
// operator:

let intList = [ 1; 2; 3 ]
let printInt = printf "%i"
List.iter printInt intList

// Iterating over a list of DateTimes printing the year:

open System

// A date list:
let importantDates = [ new DateTime(1066,10,14);
                       new DateTime(1999,01,01);
                       new DateTime(2999,12,31) ]

// A printing function:
let printInt2 = printf "%i "

// Case 1: type annotation required:
List.iter (fun (d: DateTime) -> printInt2 d.Year) importantDates

// Case 2: no type annotation required:
importantDates |> List.iter (fun d -> printInt d.Year)

// Chaining operations together using the |> operator:

// Grab a list of all methods in memory:
let methods = System.AppDomain.CurrentDomain.GetAssemblies()
                |> List.ofArray
                |> List.map ( fun assm -> assm.GetTypes() )
                |> Array.concat
                |> List.ofArray
                |> List.map ( fun t -> t.GetMethods() )
                |> Array.concat

// Print the list:
printfn "%A" methods

