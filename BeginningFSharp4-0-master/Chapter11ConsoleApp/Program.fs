open Argu

type Arguments =
| Dir of string
| Sep of string
| Date of bool
| Size of bool
with
    interface IArgParserTemplate with
        member s.Usage =
            match s with
            | Dir _ -> "specify a directory to list."
            | Sep _ -> "specify a separator."
            | Date _ -> "specify whether to include the date."
            | Size _ -> "specify whether to include the size."


open System.IO

let ListFiles 
    (directory : string) (sep : string) 
    (includeDate : bool) (includeSize : bool) =
    directory
    |> Directory.EnumerateFiles
    // If you are limited to F# 3.x you will have to replace the following line with
    // |> Seq.map (fun name -> FileInfo name)
    |> Seq.map FileInfo
    |> Seq.iter (fun info ->
        printfn "%s%s%s"
            info.Name
            (if includeDate then 
                sprintf "%s%s" sep (info.LastWriteTime.ToString()) 
             else 
                "")
            (if includeSize then 
                sprintf "%s%s" sep (info.Length.ToString()) 
             else 
                "")
    )

[<EntryPoint>]
let main argv = 
    let parser = ArgumentParser.Create<Arguments>()
    let args =
        try
            parser.Parse argv |> Some
        with
        | _ -> 
            printfn "Usage: %s" (parser.Usage())
            None
    match args with
    | Some a ->
        let dir = a.GetResult(<@ Dir @>, defaultValue = ".")
        let incDate = a.GetResult(<@ Date @>, defaultValue = false)
        let incSize = a.GetResult(<@ Size @>, defaultValue = false)
        let sep = a.GetResult(<@ Sep @>, defaultValue = ",")
        ListFiles dir sep incDate incSize
        0 
    | None -> 1
