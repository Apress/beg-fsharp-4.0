#if INTERACTIVE
#else
module QuotedCode
#endif

// Quote the integer one:
let quotedInt = <@ 1 @>

// Print the quoted integer:
printfn "%A" quotedInt

// Define an identifier n:
let n = 1
// Quote the identifier:
let quotedId = <@ n @>

// Print the quoted identifier:
printfn "%A" quotedId

// Define a function:
let inc x = x + 1
// Quote the function applied to a value:
let quotedFun = <@ inc 1 @>

// Print the quotation:
printfn "%A" quotedFun

open Microsoft.FSharp.Quotations

// Quote an operator applied to two operands:
let quotedOp = <@ 1 + 1 @>

// Print the quotation:
printfn "%A" quotedOp

open Microsoft.FSharp.Quotations

// Quote an anonymous function:
let quotedAnonFun = <@ fun x -> x + 1 @>

// Print the quotation:
printfn "%A" quotedAnonFun

open Microsoft.FSharp.Quotations.Patterns

// A function to interpret very simple quotations:
let interpretInt exp =
    match exp with
    | Value (x, typ) when typ = typeof<int> -> printfn "%d" (x :?> int)
    | _ -> printfn "not an int"
        
// Test the function:
interpretInt <@ 1 @>
interpretInt <@ 1 + 1 @>

open Microsoft.FSharp.Quotations.Patterns
open Microsoft.FSharp.Quotations.DerivedPatterns

// A function to interpret very simple quotations:
let rec interpret exp =
    match exp with
    | Value (x, typ) when typ = typeof<int> -> printfn "%d" (x :?> int)
    | SpecificCall <@ (+) @> (_, _, [l;r])  -> interpret l
                                               printfn "+"
                                               interpret r
    | _ -> printfn "not supported"
        
// Test the function:
interpret <@ 1 @>
interpret <@ 1 + 1 @>

// This defines a function and quotes it:
[<ReflectedDefinition>]
let inc2 n = n + 1

// Fetch the quoted defintion:
let incQuote = <@@ inc2 @@>

// Print the quotation:
printfn "%A" incQuote
// Use the function:
printfn "inc 1: %i" (inc2 1)
