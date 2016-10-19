#if INTERACTIVE
#else
module PrintfModule
#endif

// Print a string:
printf "Hello %s" "Robert"

// Uncomment this to see an error:
//printf "Hello %s" 1

// Types are often inferred from the
// format string of a printf call:
let myPrintInt x =
   printf "An integer: %i" x

// Print π in various formats:
let pi = System.Math.PI

printfn "%f" pi
printfn "%1.1f" pi
printfn "%2.2f" pi
printfn "%2.8f" pi

// Write to a string:
let s = Printf.sprintf "Hello %s\r\n" "string"
printfn "%s" s
// Print a string to a .NET TextWriter:
fprintf System.Console.Out "Hello %s\r\n" "TextWriter"
// Create a string that will be placed
// in an exception message:
failwithf "Hello %s" "exception"

