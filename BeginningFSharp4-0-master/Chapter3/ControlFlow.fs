#if INTERACTIVE
#else
module ControlFlow
#endif

// Use 'if' to return a different value under
// different circumstances:
let result =
    if System.DateTime.Now.Second % 2 = 0 then
        "heads"
    else
        "tails"
        
printfn "%A" result

// 'match' is often an alternative to 'if':
let result2 =
    match System.DateTime.Now.Second % 2 = 0 with
    | true -> "heads"
    | false ->  "tails"

printfn "%A" result2

// Return types of each branch need to be the same.
// Very rarely you might need to box them to make
// this happen, but this is usually a sign you're
// doing something wrong.
let result3 =
    if System.DateTime.Now.Second % 2 = 0 then
        box "heads"
    else
        box false
        
printfn "%A" result3
