#if INTERACTIVE
#else
module PatternMatching
#endif

// Definition of Lucas numbers using pattern matching:
let rec luc x =
    match x with
    | x when x <= 0 -> failwith "value must be greater than 0"
    | 1 -> 1
    | 2 -> 3
    | x -> luc (x - 1) + luc (x - 2)

// Call the function and print the results:
printfn "(luc 2) = %i" (luc 2)
printfn "(luc 6) = %i" (luc 6)
printfn "(luc 11) = %i" (luc 11)
printfn "(luc 12) = %i" (luc 12)

// Combine two patterns into one rule:

// Function for converting a boolean to a string:
let booleanToString x =
    match x with false -> "False" | _ -> "True"

// Function for converting a string to a boolean
let stringToBoolean x =
    match x with
    | "True" | "true" -> true
    | "False" | "false" -> false
    | _ -> failwith "unexpected input"

// Call the functions and print the results:
printfn "(booleanToString true) = %s"
    (booleanToString true)
printfn "(booleanToString false) = %s"
    (booleanToString false)
printfn "(stringToBoolean \"True\") = %b"
    (stringToBoolean "True")
printfn "(stringToBoolean \"false\") = %b"
    (stringToBoolean "false")
printfn "(stringToBoolean \"Hello\") = %b"
    (stringToBoolean "Hello")

// You can pattern match over tuples:

let myOr b1 b2 =
    match b1, b2 with
    | true, _ -> true
    | _, true -> true
    | _ -> false

let myAnd p =
    match p with
    | true, true -> true
    | _ -> false
    
printfn "(myOr true false) = %b" (myOr true false)
printfn "(myOr false false) = %b" (myOr false false)
printfn "(myAnd (true, false)) = %b" (myAnd (true, false))
printfn "(myAnd (true, true)) = %b" (myAnd (true, true))

// Use the 'function' keyword to make pattern matching more concise:

// Concatenate a list of strings into single string:
let rec concatStringList =
    function head :: tail -> head + concatStringList tail
           | [] -> ""

// Test data:
let jabber = ["'Twas "; "brillig, "; "and "; "the "; "slithy "; "toves "; "..."]
// Call the function:
let completJabber = concatStringList jabber
// Print the result:
printfn "%s" completJabber


