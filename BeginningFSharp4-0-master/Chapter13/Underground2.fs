#if INTERACTIVE
// You may have to alter this path depending on the version
// of FSharp.Data downloaded and on you project structure
#r @"../packages/FSharp.Data.2.2.5/lib/net40/FSharp.Data.dll"
#else
module Underground2
#endif

open FSharp.Data

type Stations = CsvProvider< @"StationsSample.csv", 
                             HasHeaders=true>

let ListStations() = 
    // Add this line to Stations.csv to see an error at run time:
    // (You may need to reset F# Interactive to be able to save
    // Stations.csv)
    // Archway,Northern,Islington,2;3,8.94
    let stations = Stations.Load(@"Stations.csv")

    for station in stations.Rows do
        printfn "%s is in %i" station.Station station.Zone

do ListStations()