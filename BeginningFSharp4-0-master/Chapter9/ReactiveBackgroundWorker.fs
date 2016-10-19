#if INTERACTIVE
#r "System.Windows.Forms.dll"
#else
module ReactiveDemo2
#endif

let fibs =
      (1I,1I) |> Seq.unfold
         (fun (n0, n1) ->
            Some(n0, (n1, n0 + n1)))

let fib n = Seq.item n fibs

open System
open System.Windows.Forms

// This version uses a background worker to get round the
// problem of the UI freezing during long calculations.

open System
open System.ComponentModel
open System.Windows.Forms

let form =
    let form = new Form()
    // Input text box:
    let input = new TextBox()
    // Button to launch processing:
    let button = new Button(Left = input.Right + 10, Text = "Go")
    // Label to display the result:
    let output = new Label(Top = input.Bottom + 10, Width = form.Width, 
                           Height = form.Height - input.Bottom + 10,
                           Anchor = (AnchorStyles.Top 
                                     ||| AnchorStyles.Left 
                                     ||| AnchorStyles.Right 
                                     ||| AnchorStyles.Bottom))

    // Create and run a new background worker:
    let runWorker() =
        let background = new BackgroundWorker()
        // Parse the input to an int:
        let input = Int32.Parse(input.Text)
        // Add the "work" event handler:
        background.DoWork.Add(fun ea ->
            ea.Result <- fib input) 
        // Add the work completed event handler:
        background.RunWorkerCompleted.Add(fun ea ->
            output.Text <- Printf.sprintf "%A" ea.Result)
        // Start the worker off:
        background.RunWorkerAsync()
 
    // Hook up creating and running the worker to the button:  
    button.Click.Add(fun _ -> runWorker())
    // Add the controls:
    let dc c = c :> Control
    form.Controls.AddRange([|dc input; dc button; dc output |])
    // Return the form:
    form

// Run the form:
#if INTERACTIVE
form.ShowDialog() |> ignore
#else
Application.Run()
#endif
