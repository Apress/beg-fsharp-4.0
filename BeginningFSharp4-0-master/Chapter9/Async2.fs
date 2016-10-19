#if INTERACTIVE
#else
module Async2
#endif

// Read three files (synchronous version):

open System
open System.IO
open System.Threading

let print s =
    let tid = Thread.CurrentThread.ManagedThreadId
    Console.WriteLine(sprintf "Thread %i: %s" tid s)

let readFileSync file =
    print (sprintf "Beginning file %s" file)
    let stream = File.OpenText(file)
    let fileContents = stream.ReadToEnd()
    print (sprintf "Ending file %s" file)
    fileContents

// invoke the workflow and get the contents
let filesContents = 
    [| readFileSync (__SOURCE_DIRECTORY__ + "/text1.txt");
       readFileSync (__SOURCE_DIRECTORY__ + "/text2.txt"); 
       readFileSync (__SOURCE_DIRECTORY__ + "/text3.txt"); |]

// Read three files (asynchronous version):

open System
open System.IO
open System.Threading

let print2 s =
    let tid = Thread.CurrentThread.ManagedThreadId
    Console.WriteLine(sprintf "Thread %i: %s" tid s)

// a function to read a text file asynchronusly
let readFileAsync file =
    async { do print (sprintf "Beginning file %s" file)
            let! stream = File.AsyncOpenText(file)
            let! fileContents = stream.AsyncReadToEnd()
            do print (sprintf "Ending file %s" file)
            return fileContents }

let filesContents2 = 
    Async.RunSynchronously
        (Async.Parallel [ readFileAsync (__SOURCE_DIRECTORY__ + "/text1.txt");
                          readFileAsync (__SOURCE_DIRECTORY__ + "/text2.txt"); 
                          readFileAsync (__SOURCE_DIRECTORY__ + "/text3.txt"); ])

