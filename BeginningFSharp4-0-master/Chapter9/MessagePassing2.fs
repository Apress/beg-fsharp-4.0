#if INTERACTIVE
#r "System.Windows.Forms.dll"
#r "System.Drawing.dll"
#else
module MailboxProcessorSimulation
#endif

open System
open System.Threading
open System.Windows.Forms
open System.Drawing.Imaging
open System.Drawing

// The width & height for the simulation:
let width, height = 500, 600

// The bitmap that will hold the output data:
let bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb)

// A form to display the bitmap:
let form = new Form(Width = width, Height = height,
                    BackgroundImage = bitmap)

// The function which recieves that points to be plotted
// and marshals to the GUI thread to plot them:
let printPoints points =
    form.Invoke(new Action(fun () -> 
        List.iter bitmap.SetPixel points
        form.Invalidate())) 
    |> ignore

// The mailbox that will be used to collect the data:
let mailbox = 
    MailboxProcessor.Start(fun mb ->
        // Main loop to read from the message queue;
        // the parameter "points" holds the working data:
        let rec loop points =
            async { // Read a message:
                    let! msg = mb.Receive()
                    // If we have over 100 messages write
                    // message to the GUI:
                    if List.length points > 100 then
                        printPoints points
                        return! loop []
                    // Otherwise append message and loop:
                    return! loop (msg :: points) }
        loop [])

// Start a worker thread running our fake simulation:
let startWorkerThread() = 
    // Function that loops infinitely generating random
    // "simulation" data:
    let fakeSimulation() =
        let rand = new Random()
        let colors = [| Color.Red; Color.Green; Color.Blue |] 
        while true do
            // Post the random data to the mailbox
            // then sleep to simulate work being done:
            mailbox.Post(rand.Next(width), 
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
