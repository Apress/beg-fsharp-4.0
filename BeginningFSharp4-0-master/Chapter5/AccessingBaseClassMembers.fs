#if INTERACTIVE
#r "System.Drawing.dll"
#r "System.Windows.Forms.dll"
#else
module AccessingBaseClassMembers
#endif

open System
open System.Drawing
open System.Windows.Forms

// Define a class that inherits from 'Form':
type MySquareForm(color) =
    inherit Form()
    // Override the OnPaint method to draw on the form:
    override x.OnPaint(e) =
        e.Graphics.DrawRectangle(color,
                                 10, 10,
                                 x.Width - 30,
                                 x.Height - 50)
        base.OnPaint(e)
    // Override the OnResize method to respond to resizing:
    override x.OnResize(e) =
        x.Invalidate()
        base.OnResize(e)

// Create a new instance of the form:
let form = new MySquareForm(Pens.Blue)

// Show the form:
#if INTERACTIVE
do form.ShowDialog() |> ignore
#else
[<STAThread>]
do Application.Run(form)
#endif