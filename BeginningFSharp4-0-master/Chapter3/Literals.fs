#if INTERACTIVE
#else
module Literals
#endif

// Some strings:
let message = "Hello
World\r\n\t!"
let dir = @"c:\projects"

// A byte array:
let bytes = "bytesbytesbytes"B

// Some numeric types:
let xA = 0xFFy
let xB = 0o7777un
let xC = 0b10010UL

// Print the results:
let main() =
    printfn "%A" message
    printfn "%A" dir
    printfn "%A" bytes
    printfn "%A" xA
    printfn "%A" xB
    printfn "%A" xC

// Call the main function:
main()
