#if INTERACTIVE
#r "System.Drawing.dll"
#r "System.Windows.Forms.dll"
#else
module RecordsAsObjectsWithDrawing
#endif

open System
open System.Drawing
open System.Windows.Forms

// A Shape record that will act as our object:
type Shape =
    { Reposition: Point -> unit;
      Draw : Graphics -> unit }

// Create a new instance of Shape
let movingShape initPos draw =
    // currPos is the internal state of the object:
    let currPos = ref initPos in
    { Reposition = 
        // The Reposition member updates the internal state:
        (fun newPos -> currPos := newPos);
      Draw = 
        // Draw the shape passing the current position
        // and graphics object to given draw function:
        (fun g -> draw !currPos g); }

// Create a new circle Shape:
let movingCircle initPos diam =
    movingShape initPos (fun pos g ->
        g.DrawEllipse(Pens.Blue,pos.X,pos.Y,diam,diam))
        
// Create a new square Shape:
let movingSquare initPos size =
    movingShape initPos (fun pos g ->
    g.DrawRectangle(Pens.Blue,pos.X,pos.Y,size,size) )

// List of shapes in their inital positions:
let shapes =
    [ movingCircle (new Point (10,10)) 20;
      movingSquare (new Point (30,30)) 20;
      movingCircle (new Point (20,20)) 20;
      movingCircle (new Point (40,40)) 20; ]

// Create the form to show the items:
let mainForm =
    let form = new Form()
    let rand = new Random()
    // Add an event handler to draw the shapes:
    form.Paint.Add(fun e ->
        shapes |> List.iter (fun s ->
        s.Draw e.Graphics))
    // Add an event handler to move the shapes
    // when the user clicks the form:
    form.Click.Add(fun e ->
        shapes |> List.iter (fun s ->
        s.Reposition(new Point(rand.Next(form.Width),
                               rand.Next(form.Height)))
        form.Invalidate()))
    form

// Show the form:
#if INTERACTIVE
do mainForm.ShowDialog() |> ignore
#else
[<STAThread>]
do Application.Run(mainForm)
#endif
