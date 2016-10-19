// This file is not cross-platform. Delete it from the solution
// if working on a non-Microsoft environment.
#if INTERACTIVE
#r "Microsoft.Office.Interop.Excel.dll"
#else
module COMToExcel
#endif

open System
open Microsoft.Office.Interop.Excel 

let main() =
    // Initalize an Excel application:
    let app = new ApplicationClass()
    
    // Load a Excel work book:
    let workBook = app.Workbooks.Open(__SOURCE_DIRECTORY__ + @"/Book1.xls", ReadOnly = true) 
    // Ensure work book is closed corectly:
    use bookCloser = { new IDisposable with 
                        member x.Dispose() = workBook.Close() }

    // Open the first worksheet:
    let worksheet = workBook.Worksheets.[1] :?> _Worksheet 

    // Get the A1 cell and all surrounding cells:
    let a1Cell = worksheet.Range("A1") 
    let allCells = a1Cell.CurrentRegion 
    // Load all cells into a list of lists:
    let matrix = 
        [ for row in allCells.Rows -> 
            let row = row :?> Range 
            [ for cell in row.Columns -> 
                let cell = cell :?> Range 
                cell.Value2 ] ] 
   
    // Print the matrix:
    printfn "%A" matrix 

do main()
