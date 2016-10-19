#if INTERACTIVE
#else
module ThreadLocking
#endif

open System
open System.Threading

// Function to print to the console character by character
// this increases the chance of there being a context switch
// between threads:
let printSlowly (s : string) =
    s.ToCharArray()
    |> Array.iter (printf "%c")
    printfn ""

// Create a thread that prints to the console in an unsafe way:
let makeUnsafeThread() =
    new Thread(fun () ->
    for x in 1 .. 100 do
        printSlowly "One ... Two ... Three ... ")
    
// The object that will be used as a lock:
let lockObj = new Object()

 
// Create a thread that prints to the console in a safe way:
let makeSafeThread() =
    new Thread(fun () ->
        for x in 1 .. 100 do
            // Use lock to ensure operation is atomic:
            lock lockObj (fun () ->
                printSlowly "One ... Two ... Three ... "))
        
// Helper function to run the test:
let runTest (f: unit -> Thread) message =
    printfn "%s" message
    let t1 = f()
    let t2 = f()
    t1.Start()
    t2.Start()
    t1.Join()
    t2.Join()
    
// Run the demonstrations:
let main() =
    runTest
        makeUnsafeThread
        "Running test without locking ..."
    runTest
        makeSafeThread
        "Running test with locking ..."
    
do main()
