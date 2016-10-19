open System
open System.Collections.Generic
open System.Configuration
open System.Data
open System.Data.SqlClient
open System.Windows.Forms

// Creates a connections then executes the given command on it:
let createDataSet commandString =
    // Read the connection string:
    let connectionSetting =
        ConfigurationManager.ConnectionStrings.["MyConnection"]

    // Create a data adapter to fill the dataset:
    let adapter = new SqlDataAdapter(commandString, connectionSetting.ConnectionString)

    // Create a new data set and fill it:
    let ds = new DataSet()
    adapter.Fill(ds) |> ignore
    ds

// Create the data set that will be bound to the form:
let dataSet = createDataSet "select top 10 * from Person.Person"

// Create a form containing a data bound data grid view:
let form =
    let frm = new Form()
    let grid = new DataGridView(Dock = DockStyle.Fill)
    frm.Controls.Add(grid)
    grid.DataSource <- dataSet.Tables.[0]
    frm

[<EntryPoint>]
let main args =
   // Show the form:
   Application.Run(form)
   0
