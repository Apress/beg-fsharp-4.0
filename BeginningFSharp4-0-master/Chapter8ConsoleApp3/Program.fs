open System
open System.Configuration
open System.Data
open System.Data.SqlClient

// Get the connection string:
let connectionString =
    let connectionSetting =
        ConfigurationManager.ConnectionStrings.["MyConnection"]
    connectionSetting.ConnectionString

[<EntryPoint>]
let main argv =     
    // Create a connection:
    use connection = new SqlConnection(connectionString)
    
    // Create a command:
    let command =
        connection.CreateCommand(CommandText = "select * from Person.Person", CommandType = CommandType.Text)

    // Open the connection:
    connection.Open()

    // Open a reader to read data from the DB:
    use reader = command.ExecuteReader()    
    // Fetch the column-indexes of the required columns:
    let title = reader.GetOrdinal("Title")
    let firstName = reader.GetOrdinal("FirstName")
    let lastName = reader.GetOrdinal("LastName")
    
    // Function to read strings from the data reader:
    let getString (r: #IDataReader) x =
        if r.IsDBNull(x) then ""
        else r.GetString(x)
    
    // Read all the items:
    while reader.Read() do
        printfn "%s %s %s"
            (getString reader title )
            (getString reader firstName)
            (getString reader lastName)

    Console.ReadKey(false) |> ignore
    0
