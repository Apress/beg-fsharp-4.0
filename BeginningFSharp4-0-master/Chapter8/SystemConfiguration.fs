namespace SystemConfiguration

open System

// This will only work in a compiled context, not in F# Interactive.

module Demo =

    open System.Configuration

    // Read an application setting:
    let setting = ConfigurationManager.AppSettings.["MySetting"]

    // Print the setting:
    printfn "Setting: %s" setting

    // Get a connection string:
    let connectionStringDetails =
        ConfigurationManager.ConnectionStrings.["MyConnectionString"]

    // Print the details:
    printfn "Connection string: %s\r\n%s"
        connectionStringDetails.ConnectionString
        connectionStringDetails.ProviderName

    // Open the machine config:
    let config =
        ConfigurationManager.OpenMachineConfiguration()

    // Print the names of all sections:
    printfn "Machine Config:"
    for x in config.Sections do
        printfn "%s" x.SectionInformation.Name

    [<EntryPoint>]
    let main args =
        printfn "Press a key to exit."
        Console.ReadKey(false) |> ignore
        0