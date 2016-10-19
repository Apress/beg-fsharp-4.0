#if INTERACTIVE
// You may have to alter this path depending on the version
// of FSharp.Data downloaded and on you project structure
#r @"../packages/FSharp.Data.2.2.5/lib/net40/FSharp.Data.dll"
#else
module Underground
#endif

open FSharp.Data

type Stations = CsvProvider< @"Stations.csv", 
                             HasHeaders=true>

let ListStations() = 
    let stations = Stations.Load(@"Stations.csv")

    for station in stations.Rows do
        printfn "%s is in %s" station.Station station.``Local Authority``

do ListStations()