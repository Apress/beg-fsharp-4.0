open System.Drawing
open System.Windows.Forms
open Strangelights.GraphicDSL

// Two test squares:
let square1 = Combinators.square true (100, 50) 50 
let square2 = Combinators.square false (50, 100) 50 

// A test triangle:
let triangle1 = 
    Combinators.triangle false 
        (150, 200) (150, 150) (250, 200)

// Compose the basic elements into a picture:
let scence = Combinators.compose [square1; square2; triangle1]

// Create the display form:
let form = new EvalForm([scence, Color.Red])

[<EntryPoint>]
let main argv = 
    // Show the form:
    Application.Run form
    0

// Uncomment this section and comment out the above for a more
// ambitious image:

//open System.Drawing
//open System.Windows.Forms
//open Strangelights.GraphicDSL
//
//// Define a function that can draw a 6 sided star:
//let star (x, y) size =
//    let offset = size / 2
//    // Calculate the first triangle:
//    let t1 = 
//        Combinators.triangle false 
//            (x, y - size - offset)
//            (x - size, y + size - offset) 
//            (x + size, y + size - offset)
//    // Calculate another inverted triangle:
//    let t2 = 
//        Combinators.triangle false 
//            (x, y + size + offset) 
//            (x + size, y - size + offset) 
//            (x - size, y - size + offset)
//    // Compose the triangles:
//    Combinators.compose [ t1; t2 ]    
//
//// The points where stars should be plotted:
//let points = [ (10, 20); (200, 10); 
//               (30, 160); (100, 150); (190, 150);
//               (20, 300); (200, 300);  ]
//
//// Compose the stars into a single scene:
//let scence = 
//    Combinators.compose 
//        (List.map (fun pos -> star pos 5) points)
//
//// Show the scene in red on the EvalForm:
//let form = new EvalForm([scence, Color.Red], 
//                        Width = 260, Height = 350)
//
//[<EntryPoint>]
//let main argv = 
//    // Show the form:
//    Application.Run form
//    0
//
