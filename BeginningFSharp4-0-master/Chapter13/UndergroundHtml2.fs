#if INTERACTIVE
// You may have to alter this path depending on the version
// of FSharp.Data downloaded and on you project structure
#r @"../packages/FSharp.Data.2.2.5/lib/net40/FSharp.Data.dll"
#else
module UndergroundHTML2
#endif

open FSharp.Data

type Stations = HtmlProvider< @"https://en.wikipedia.org/wiki/List_of_London_Underground_stations">

let ListStations() = 
    let stations = Stations.Load(@"https://en.wikipedia.org/wiki/List_of_London_Underground_stations")

    let list = stations.Tables.Stations
    for station in list.Rows do
        let zones = 
            match station.``Zone(s)[†]`` |> Seq.tryFindIndex ((=) '!') with
            | Some(idx) -> station.``Zone(s)[†]``.[idx+1 ..]
            | None -> station.``Zone(s)[†]``

        printfn "%s is in %s" station.Station zones


do ListStations()