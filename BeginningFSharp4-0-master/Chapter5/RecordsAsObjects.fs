#if INTERACTIVE
#r "System.Drawing.dll"
#else
module RecordsAsObjects
#endif
open System.Drawing

// A Shape record that will act as our object:
type Shape =
    { Reposition: Point -> unit;
      Draw: unit -> unit }

// Create a new instance of Shape:
let makeShape initPos draw =
    // currPos is the internal state of the object:
    let currPos = ref initPos
    { Reposition =
        // the Reposition member updates the internal state:
        (fun newPos -> currPos := newPos);
      Draw =
        // draw the shape passing the current position:
        // to given draw function
        (fun () -> draw !currPos); }

// "Draws" a shape, prints out the shapes name and position:
let draw shape (pos: Point) =
    printfn "%s, with x = %i and y = %i"
        shape pos.X pos.Y

// Creates a new circle shape:
let circle initPos =
    makeShape initPos (draw "Circle")

// Creates a new square shape:
let square initPos =
    makeShape initPos (draw "Square")

// List of shapes in their inital positions:
let shapes =
    [ circle (new Point (10,10));
      square (new Point (30,30)) ]

// Draw all the shapes:
let drawShapes() =
    shapes |> List.iter (fun s -> s.Draw())

let main() =
    // Draw the shapes:
    drawShapes() 
    // Move all the shapes:
    shapes |> List.iter (fun s -> s.Reposition (new Point (40,40)))
    // Draw the shapes:
    drawShapes() 

// Start the program    
do main()
