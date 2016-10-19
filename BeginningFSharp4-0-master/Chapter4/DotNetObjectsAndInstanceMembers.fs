#if INTERACTIVE
#else
module DotNetObjectsAndInstanceMembers
#endif

open System.IO

// Create a FileInfo object:
// ('new' is optional)
let file = new FileInfo("test.txt")

// Test if the file exists,
// if not create a file:
if not file.Exists then
    use stream = file.CreateText()
    stream.WriteLine("hello world")
    file.Attributes <- FileAttributes.ReadOnly

// Print the full file name:
printfn "%s" file.FullName

// File name to test:
let filename = "test.txt"

// Bind file to an option type, depending on whether
// the file exists or not:
let file2 =
    if File.Exists(filename) then
        Some(new FileInfo(filename, Attributes = FileAttributes.ReadOnly))
    else
        None

open System

// An integer list:
let intList =
    let temp = new ResizeArray<int>()
    temp.AddRange([| 1; 2; 3 |]);
    temp

// Print each int using the ForEach member method:
intList.ForEach( fun i -> Console.WriteLine(i) )

// Wrap a method that takes a delegate with an F# function:
let findIndex f arr = Array.FindIndex(arr, new Predicate<_>(f))

// Define an array literal
let rhyme = [| "The"; "cat"; "sat"; "on"; "the"; "mat" |]

// Print index of the first word ending in 'at':
printfn "First word ending in 'at' in the array: %i"
    (rhyme |> findIndex (fun w -> w.EndsWith("at")))



