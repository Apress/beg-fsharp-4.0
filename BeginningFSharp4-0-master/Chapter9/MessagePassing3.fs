#if INTERACTIVE
#r "System.Windows.Forms.dll"
#r "System.Drawing.dll"
#else
module MailboxProcessorSimulationGeneric
#endif

open System
open System.Threading
open System.ComponentModel
open System.Windows.Forms
open System.Drawing.Imaging
open System.Drawing

// Type that defines the messages types our updater can handle:
type Updates<'a> =
    | AddValue of 'a
    | GetValues of AsyncReplyChannel<list<'a>>
    | Stop

// A generic collecter that receives a number of post items and
// once a configurable limit is reached fires the update event:
type Collector<'a>(?updatesCount) = 
    // The number of updates to count to before firing the update even:
    let updatesCount = match updatesCount with Some x -> x | None -> 100
    
    // Capture the synchronization context of the thread that creates this object. This
    // allows us to send messages back to the GUI thread painlessly:
    let context = AsyncOperationManager.SynchronizationContext
    let runInGuiContext f =
        context.Post(new SendOrPostCallback(fun _ -> f()), null)

    // This event is fired in the synchronization context of the GUI (i.e. the thread
    // that created this object):
    let event = new Event<list<'a>>() 

    let mailboxWorkflow (inbox: MailboxProcessor<_>) =
        // Main loop to read from the message queue
        // the parameter "curr" holds the working data
        // the parameter "master" holds all values received:
        let rec loop curr master = 
            async { // Read a message:
                    let! msg = inbox.Receive()
                    match msg with
                    | AddValue x ->
                        let curr, master = x :: curr, x :: master
                        // If we have over 100 messages write
                        // message to the GUI:
                        if List.length curr > updatesCount then
                            do runInGuiContext(fun () -> event.Trigger(curr))
                            return! loop [] master
                        return! loop curr master
                    | GetValues channel ->
                        // Send all data received back:
                        channel.Reply master
                        return! loop curr master
                    | Stop -> () } // Stop by not calling "loop" 
        loop [] []

    // The mailbox that will be used to collect the data:
    let mailbox = new MailboxProcessor<Updates<'a>>(mailboxWorkflow)
    
    // The API of the collector:
    
    // Add a value to the queue:
    member w.AddValue (x) = mailbox.Post(AddValue(x))
    // Get all the values the mailbox stores:
    member w.GetValues() = mailbox.PostAndReply(fun x -> GetValues x)
    // Publish the updates event:
    [<CLIEvent>]
    member w.Updates = event.Publish
    // Start the collector:
    member w.Start() = mailbox.Start()
    // Stop the collector:
    member w.Stop() = mailbox.Post(Stop)

// Create a new instance of the collector:
let collector = new Collector<int*int*Color>()

// The width & height for the simulation:
let width, height = 500, 600

// A form to display the updates:
let form = 
    // The bitmap that will hold the output data:
    let bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb)
    let form = new Form(Width = width, Height = height, BackgroundImage = bitmap)
    // Handle the collector's update event and use it to post:
    collector.Updates.Add(fun points -> 
        List.iter bitmap.SetPixel points
        form.Invalidate())
    // Start the collector when the form loads:
    form.Load.Add(fun _ -> collector.Start())
    // When the form closes get all the values that were processed:
    form.Closed.Add(fun _ -> 
        let vals = collector.GetValues()
        MessageBox.Show(sprintf "Values processed: %i" (List.length vals))
        |> ignore
        collector.Stop())
    form

// Start a worker thread running our fake simulation:
let startWorkerThread() = 
    // Function that loops infinitely generating random
    // "simulation" data:
    let fakeSimulation() =
        let rand = new Random()
        let colors = [| Color.Red; Color.Green; Color.Blue |] 
        while true do
            // Post the random data to the collector
            // then sleep to simulate work being done:
            collector.AddValue(rand.Next(width), 
                rand.Next(height), 
                colors.[rand.Next(colors.Length)])
            Thread.Sleep(rand.Next(100))
    // Start the thread as a background thread, so it won't stop
    // the program exiting:
    let thread = new Thread(fakeSimulation, IsBackground = true)
    thread.Start()

// Start 6 instances of our simulation:
for _ in 0 .. 5 do startWorkerThread()

// Run the form:
#if INTERACTIVE
form.ShowDialog() |> ignore
#else
Application.Run()
#endif
