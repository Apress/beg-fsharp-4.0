#if INTERACTIVE
#else
module UseBindings
#endif

open System.IO

// Use "use" bindings to dispose disposable
// instances when they go out of scope:

// Function to read first line from a file:
let readFirstLine filename =
    // Open file using a "use" binding:
    use file = File.OpenText filename
    file.ReadLine() 

// Call function and print the result:
printfn "First line was: %s" (readFirstLine "mytext.txt")
