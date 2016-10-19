#if INTERACTIVE
#else
module DotNetEvents
#endif

open System.Timers

let timedMessages() =
    // Define the timer:
    let timer = new Timer(Interval = 3000.0,
                          Enabled = true)

    // A counter to hold the current message:
    let mutable messageNo = 0

    // The messages to be shown:
    let messages = [ "bet"; "this"; "gets";
                     "really"; "annoying";
                     "very"; "quickly" ]

    // Add an event to the timer:
    timer.Elapsed.Add(fun _ ->
        // Print a message:
        printfn "%s" messages.[messageNo]
        messageNo <- messageNo + 1
        if messageNo = messages.Length then
            timer.Enabled <- false)

timedMessages()

let timedMessagesViaDelegate() =
    // Define the timer:
    let timer = new Timer(Interval = 3000.0,
                          Enabled = true)

    // A counter to hold the current message number:
    let mutable messageNo = 0

    // The messages to be shown:
    let messages = [ "bet"; "this"; "gets";
                     "really"; "annoying";
                     "very"; "quickly" ]

    // Function to print a message:
    let printMessage = fun _ _ ->
        // Print a message:
        printfn "%s" messages.[messageNo]
        messageNo <- (messageNo + 1) % messages.Length

    // Wrap the function in a delegate:
    let del = new ElapsedEventHandler(printMessage)

    // Add the delegate to the timer:
    timer.Elapsed.AddHandler(del) |> ignore

    // Return the time and the delegate so we can
    // remove one from the other later:
    (timer, del)

// Run this first:
let timer, del = timedMessagesViaDelegate()

// Run this later:
timer.Elapsed.RemoveHandler(del)
