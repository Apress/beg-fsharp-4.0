#if INTERACTIVE
#else
module Recursion
#endif

// To use recursion use the rec keyword:

// A function to generate the Fibonacci numbers:
let rec fib x =
    match x with
    | 1 -> 1
    | 2 -> 1
    | x -> fib (x - 1) + fib (x - 2)

// Call the function and print the results:
printfn "(fib 2) = %i" (fib 2)
printfn "(fib 6) = %i" (fib 6)
printfn "(fib 11) = %i" (fib 11)
