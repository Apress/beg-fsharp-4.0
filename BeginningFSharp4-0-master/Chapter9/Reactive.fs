#if INTERACTIVE
#r "System.Windows.Forms.dll"
#else
module ReactiveDemo1
#endif

let fibs =
      (1I,1I) |> Seq.unfold
         (fun (n0, n1) ->
            Some(n0, (n1, n0 + n1)))

let fib n = Seq.item n fibs

open System
open System.Windows.Forms

// This version becomes unresponsive when you ask it to calculate 
// long Fibonacci sequences.

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
 
    // Do all the work when the button is clicked:
    button.Click.Add(fun _ -> 
        output.Text <- Printf.sprintf "%A" (fib (Int32.Parse(input.Text)))) 
    // Add the controls:
    let dc c = c :> Control
    form.Controls.AddRange([|dc input; dc button; dc output |])
    // Return the form:
    form

// Show the form:
form.ShowDialog() |> ignore


