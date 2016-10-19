#if INTERACTIVE
// You may have to alter this path depending on the version
// of FSharp.Data downloaded and on you project structure
#r @"../packages/FSharp.Data.2.2.5/lib/net40/FSharp.Data.dll"
#else
module StationsByUsage
#endif

open FSharp.Data

type Stations = HtmlProvider< @"https://en.wikipedia.org/wiki/List_of_London_Underground_stations">

let StationsByUsage() =
    let getAfter (c : char) (s : string) =
        match s |> Seq.tryFindIndex ((=) c) with
            | Some(idx) -> s.[idx+1 ..]
            | None -> s

    let getBefore (c : char) (s : string) =
        match s |> Seq.tryFindIndex ((=) c) with
            | Some(idx) -> s.[.. idx-1]
            | None -> s

    let floatOrZero (s : string) =
        let ok, f = System.Double.TryParse(s)
        if ok then f else 0.

    let usageAsFloat (s : string) =
        s |> getAfter '♠' |> getBefore '[' |> floatOrZero
        
    let stations = 
        Stations.Load(@"https://en.wikipedia.org/wiki/List_of_London_Underground_stations")

    let list = stations.Tables.Stations

    let ranked =  
        list.Rows 
        |> Array.map (fun s -> s.Station, s.``Usage[5]`` |> usageAsFloat)
        |> Array.sortByDescending snd

    for station, usage in ranked do
        printfn "%s, %f" station usage

do StationsByUsage()