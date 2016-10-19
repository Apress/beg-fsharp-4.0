#if INTERACTIVE
// You may have to alter this path depending on the version
// of FSharp.Data downloaded and on you project structure
#r @"../packages/FSharp.Data.2.2.5/lib/net40/FSharp.Data.dll"
#else
module StationsOnLine
#endif

open FSharp.Data

type Stations = HtmlProvider< @"https://en.wikipedia.org/wiki/List_of_London_Underground_stations">

let StationsOnLine (lineName : string) =
    let stations = 
        Stations.Load( @"https://en.wikipedia.org/wiki/List_of_London_Underground_stations")

    let list = stations.Tables.Stations

    let stations =  
        list.Rows 
        |> Array.filter (fun s -> s.``Line(s)[*]``.Contains lineName)
    
    for station in stations do
        printfn "%s, %s" station.Station station.``Line(s)[*]``

do StationsOnLine "Northern"