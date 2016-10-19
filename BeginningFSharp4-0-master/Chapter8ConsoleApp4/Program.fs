open System.Configuration
open System.Collections.Generic
open System.Data
open System.Data.SqlClient
open System

/// Create and open an SqlConnection object using the connection string 
/// found in the configuration file for the given connection name:
let openSQLConnection (connName:string) =
    let connSetting = ConfigurationManager.ConnectionStrings.[connName]
    let conn = new SqlConnection(connSetting.ConnectionString)
    conn.Open()
    conn

/// Create and execute a read command for a connection using
/// the connection string found in the configuration file
/// for the given connection name:
let openConnectionReader connName cmdString =
    let conn = openSQLConnection(connName)
    let cmd = conn.CreateCommand(CommandText=cmdString,
                                 CommandType = CommandType.Text)
    let reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
    reader

 
/// Read a row from the data reader:
let readOneRow (reader: SqlDataReader) =
    if reader.Read() then
        let dict = new Dictionary<string, obj>()
        for x in [ 0 .. (reader.FieldCount - 1) ] do
            dict.Add(reader.GetName(x), reader.[x])
        Some(dict)
    else
        None

/// Execute a query using a recursive list comprehension:
let execQuery (connName: string) (cmdString: string) =
    use reader = openConnectionReader connName cmdString
    let rec read() =
        [
            let row = readOneRow reader
            match row with
            | Some r -> 
                yield r
                // Call same function recursively and add
                // all the elements returned, one-by-one
                // to the list:
                yield! read()
            | None -> ()
        ] 
    read()

let printRows() =
   /// Open the people table:
   let peopleTable =
       execQuery
           "MyConnection"
           "select top 1000 * from Person.Person"
   /// Print out the data retrieved from the database:
   for row in peopleTable do
       for col in row.Keys do
           printfn "%s = %O" col (row.Item(col))

[<EntryPoint>]
let main argv = 
    printRows()
    Console.ReadKey() |> ignore
    0
