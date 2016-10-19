#if INTERACTIVE
// You may have to alter this path depending on the version
// of FSharp.Data downloaded and on you project structure
#r @"../packages/FSharp.Data.2.2.5/lib/net40/FSharp.Data.dll"
#else
module Underground3
#endif

open FSharp.Data

type Stations = CsvProvider< @"StationsSample.csv", 
                             HasHeaders=true,
                             Schema="Zone(s)=string">

// This version should work even when you have included
// Archway,Northern,Islington,2;3,8.94
// in Stations.csv

let ListStations() = 
    let stations = Stations.Load(@"Stations.csv")

    for station in stations.Rows do
        printfn "%s is in %s" station.Station station.``Zone(s)``

do ListStations()