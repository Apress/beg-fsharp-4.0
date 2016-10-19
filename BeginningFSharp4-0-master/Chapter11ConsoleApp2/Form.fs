namespace Strangelights.GraphicDSL

open System.Drawing
open System.Windows.Forms

// A form that can be used to display the scene:
type EvalForm(items: List<Element>) as x =
    inherit Form()
    // Handle the paint event to draw the scene:
    do x.Paint.Add(fun ea ->
        let rec drawShape (shape, (color: Color)) =
            match shape with
            | Line ((x1, y1), (x2, y2)) ->
                // Draw a line 
                let pen = new Pen(color)
                ea.Graphics.DrawLine(pen, x1, y1, x2, y2)
            | Polygon points ->
                // Draw a polygon:
                let points = 
                    points
                    |> List.map (fun (x,y) -> new Point(x, y))
                    |> Array.ofList 
                let brush = new SolidBrush(color)
                ea.Graphics.FillPolygon(brush, points)
            | CompositeShape shapes -> 
                // Recursively draw the other contained elements:
                List.iter (fun shape -> drawShape(shape, color)) shapes
        // draw all the items we have been passed:
        items |> List.iter drawShape)
