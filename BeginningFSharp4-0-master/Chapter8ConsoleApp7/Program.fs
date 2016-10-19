open System.Configuration
open System.Data.SqlClient
open System.Windows.Forms
open Dapper

// A record containing some of the Person fields:
type Contact =
   {
      FirstName : string
      LastName : string
      Title : string
      PhoneNumber : string
   }

// A record for any arguments we want to send to the query:
type GetContactsArgs =
   {
      LastNamePattern : string
   }

// The SQL we want to run:
let sql =
   """
      SELECT
	      P.FirstName,
	      P.LastName,
	      P.Title,
	      PP.PhoneNumber
      FROM
	      Person.Person P
      JOIN
	      Person.PersonPhone PP 
      ON 
	      P.BusinessEntityID = PP.BusinessEntityID
      WHERE
         P.LastName LIKE @LastNamePattern
   """

// Get all the contacts whose last name matches a search pattern
// and return them as F# Contact records:
let getContacts pattern =
   let connString =
      ConfigurationManager
          .ConnectionStrings.["MyConnection"]
          .ConnectionString
   use conn = new SqlConnection(connString)
   conn.Open()
   // Use Dapper's 'Query' extension method to run the query, supplying
   // the query argument through the 'args' record and automatically
   // transforming the query results to 'Contact' records:
   let args = { LastNamePattern = pattern }
   let contacts = conn.Query<Contact>(sql, args)
   contacts |> Seq.toArray

let form =
    let frm = new Form()
    let grid = new DataGridView(Dock = DockStyle.Fill)
    frm.Controls.Add(grid)
    // Get all the contacts with 'smi' in the last name:
    let contacts = getContacts "%smi%"
    grid.DataSource <- contacts
    frm

[<EntryPoint>]
let main argv = 
   // Show the form:
   Application.Run(form)
   0
