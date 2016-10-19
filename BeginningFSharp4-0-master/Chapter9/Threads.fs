#if INTERACTIVE
#else
module Threads
#endif

open System.Threading

let main() =
    // Create a new thread passing it a lambda function:
    let thread = new Thread(fun () ->
        // Print a message on the newly created thread:
        printfn "Created thread: %i" Thread.CurrentThread.ManagedThreadId)
    // Start the new thread:
    thread.Start()
    // Print an message on the original thread:
    printfn "Orginal thread: %i" Thread.CurrentThread.ManagedThreadId
    // Wait for the created thread to exit:
    thread.Join()

do main()
