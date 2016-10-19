#if INTERACTIVE
// You may have to alter this path depending on the version
// of FSharp.Data downloaded and on you project structure
#r @"../packages/FSharp.Data.2.2.5/lib/net40/FSharp.Data.dll"
#else
module StationWithMostLetters
#endif

open FSharp.Data

type Stations = HtmlProvider< @"https://en.wikipedia.org/wiki/List_of_London_Underground_stations">


let StationWithMostLetters() =
    let stations = 
        Stations.Load( @"https://en.wikipedia.org/wiki/List_of_London_Underground_stations")

    let list = stations.Tables.Stations

    let byChars =  
        list.Rows 
        |> Array.sortByDescending 
            (fun s -> s.Station |> Seq.distinct |> Seq.length)

    byChars.[0]

do StationWithMostLetters() |> printfn "%A"