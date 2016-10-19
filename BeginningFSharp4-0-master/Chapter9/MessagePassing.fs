#if INTERACTIVE
#else
module MessagePassing
#endif

open System

// Create a MailboxProcessor (Agent) which adds 1
// to a running total:
let mailbox = 
    MailboxProcessor.Start(fun mb ->
        let rec loop x =
            async { let! msg = mb.Receive()
                    let x = x + msg
                    printfn "Running total: %i - new value %i" x msg
                    return! loop x }
        loop 0)
     
// Send some values to the MailboxProcessor in the form of
// messages:   
mailbox.Post(1)
mailbox.Post(2)
mailbox.Post(3)

// Keep the thread alive until user presses enter:
Console.ReadLine() |> ignore


