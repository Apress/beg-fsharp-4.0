#if INTERACTIVE
#else
module DotNetStaticMethodsAndProperties
#endif

open System.IO

// Test whether a file "test.txt" exists:
if File.Exists("test.txt") then
    printfn "Text file \"test.txt\" is present"
else
    printfn "Text file \"test.txt\" does not exist"

// List of files to test:
let files1 = [ "test1.txt"; "test2.txt"; "test3.txt" ]

// Test if each file exists by passing the File.Exists
// function to List.map:
let results1 = List.map File.Exists files1

// Print the results:
printfn "%A" results1

// List of files names and desired contents:
let files2 = [ "test1.bin", [| 0uy |];
               "test2.bin", [| 1uy |];
               "test3.bin", [| 1uy; 2uy |]]

// Iterate over the list of files creating each one
// (each element of the list is a tuple, which is what
// 'WriteAllBytes' requires as an argument):
List.iter File.WriteAllBytes files2

// Wrap the File.Create function into a curried form
// so that it can be partially applied:
let create size name =
    File.Create(name, size, FileOptions.Encrypted)

// List of files to be created:
let names = [ "test1.bin"; "test2.bin"; "test3.bin" ]

// Open the files creating a list of streams, 
// using the curried wrapper of File.Create:
let streams = List.map (create 1024) names

// Open a file using named arguments:
let file = File.Open(path = "test.txt",
                        mode = FileMode.Append,
                        access = FileAccess.Write,
                        share = FileShare.None)

// Close it:
file.Close()

