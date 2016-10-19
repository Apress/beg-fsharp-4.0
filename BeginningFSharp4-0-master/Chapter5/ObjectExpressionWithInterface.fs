#if INTERACTIVE
#r "System.Drawing.dll"
#r "System.Windows.Forms.dll"
#else
module ObjectExpressionWithInterface
#endif

open System
open System.Drawing
open System.Windows.Forms

// Create a new instance of a number control:
let makeNumberControl (n: int) =
    { new TextBox(Tag = n, Width = 32, Height = 16, Text = n.ToString())
          // Implement the IComparable interface so the controls
          // can be compared:
          interface IComparable with
              member x.CompareTo(other) =
                  let otherControl = other :?> Control in
                  let n1 = otherControl.Tag :?> int in
                  n.CompareTo(n1) }

// A sorted array of the numbered controls:
let numbers =
    // Initalize the collection:
    let temp = new ResizeArray<Control>()
    // Initalize the random number generator:
    let rand = new Random()
    // Add the controls collection:
    for index = 1 to 10 do
        temp.Add(makeNumberControl (rand.Next(100)))
    // Sort the collection:
    temp.Sort()
    // Layout the controls correctly:
    let height = ref 0
    temp |> Seq.iter
        (fun c ->
            c.Top <- !height
            height := c.Height + !height)
    // Return collection as an array:
    temp.ToArray()

// Create a form to show the number controls:
let numbersForm =
    let temp = new Form() in
    temp.Controls.AddRange(numbers);
    temp

// Show the form:
#if INTERACTIVE
do numbersForm.ShowDialog() |> ignore
#else
[<STAThread>]
do Application.Run(numbersForm)
#endif
