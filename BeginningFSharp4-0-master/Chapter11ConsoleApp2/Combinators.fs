namespace Strangelights.GraphicDSL
open System.Drawing

// Represents a point within the scene:
type Position = int * int

// Represents the basic shapes that will make up the scene:
type Shape =
    | Line of Position * Position
    | Polygon of List<Position>
    | CompositeShape of List<Shape>

// Allows us to give a color to a shape:
type Element = Shape * Color

module Combinators =
    // Allows us to compose a list of elements into a 
    // single shape:
    let compose shapes = CompositeShape shapes

    // A simple line made from two points:
    let line pos1 pos2 = Line (pos1, pos2)
    
    // A line composed of two or more points:
    let lines posList =
        // Grab first value in the list:
        let initVal = 
            match posList with 
            | first :: _ -> first
            | _ -> failwith "must give more than one point"
        // Creates a new link in the line:
        let createList (prevVal, acc) item = 
            let newVal = Line(prevVal, item)
            item, newVal :: acc
        // Folds over the list accumlating all points into a 
        // list of line shapes:
        let _, lines = List.fold createList (initVal, []) posList
        // Compose the list of lines into a single shape:
        compose lines
    
    // A polygon defined by a set of points:
    let polygon posList = Polygon posList    
    
    // A triangle that can be either hollow or filled:
    let triangle filled pos1 pos2 pos3 =
        if filled then
            polygon [ pos1; pos2; pos3; pos1 ]
        else
            lines [ pos1; pos2; pos3; pos1 ]

    // A square that can either be hollow or filled:
    let square filled (top, right) size =
        let pos1, pos2 = (top, right), (top, right + size)
        let pos3, pos4 = (top + size, right + size), (top + size, right)
        if filled then
            polygon [ pos1; pos2; pos3; pos4; pos1 ]
        else
            lines [ pos1; pos2; pos3; pos4; pos1 ]
