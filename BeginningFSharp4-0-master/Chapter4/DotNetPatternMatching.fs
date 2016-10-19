#if INTERACTIVE
#else
module DotNetPatternMatching
#endif

// A list of objects:
let simpleList = [ box 1; box 2.0; box "three" ]

// A function that pattern matches over the
// type of the object it is passed:
let recognizeType (item : obj) =
    match item with
    | :? System.Int32 -> printfn "An integer"
    | :? System.Double -> printfn "A double"
    | :? System.String -> printfn "A string"
    | _ -> printfn "Unknown type"

// Iterate over the list of objects:
List.iter recognizeType simpleList

// Another list of objects:
let anotherList = [ box "one"; box 2; box 3.0 ]

// Pattern match to get type and print value:
let recognizeAndPrintType (item : obj) =
    match item with
    | :? System.Int32 as x -> printfn "An integer: %i" x
    | :? System.Double as x -> printfn "A double: %f" x
    | :? System.String as x -> printfn "A string: %s" x
    | x -> printfn "An object: %A" x

// Iterate over the list pattern matching each item:
List.iter recognizeAndPrintType anotherList

// Pattern matching for exception handling:

try
    // Look at current time and raise an exception
    // based on whether the second is a multiple of 3:
    if System.DateTime.Now.Second % 3 = 0 then
        raise (new System.Exception())
    else
        raise (new System.ApplicationException())
with
| :? System.ApplicationException ->
    // This will handle "ApplicationException" case:
    printfn "A second that was not a multiple of 3"
| _ ->
    // This will handle all other exceptions
    printfn "A second that was a multiple of 3"
