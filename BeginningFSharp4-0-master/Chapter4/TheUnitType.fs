#if INTERACTIVE
#else
module TheUnitType
#endif

// A function which both takes and returns 'unit':
let aFunction() =
    ()

// Three ways to call the unit -> unit function:
let () = aFunction ()
// -- or --
do aFunction ()
// -- or --
aFunction ()

// Calling several functions which return unit:
let poem() =
    printfn "I wandered lonely as a cloud"
    printfn "That floats on high o'er vales and hills,"
    printfn "When all at once I saw a crowd,"
    printfn "A host, of golden daffodils"

poem()

// Three ways to call a function which returns a value,
// without using the value:
let getShorty() = "shorty"

let _ = getShorty()
// -- or --
ignore(getShorty())
// -- or --
getShorty() |> ignore
