#if INTERACTIVE
// You may have to alter this path depending on the version
// of FSharp.Data.SqlClient downloaded and on your project structure
#r @"../packages/FSharp.Data.SqlClient.1.7.7/lib/net40/FSharp.Data.SqlClient.dll"
#else
module AdventureWorks
#endif

open FSharp.Data

[<Literal>]
let connectionString = 
    @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2014;Integrated Security=True"

let FindPeople surnameWildCard =
    use cmd = new SqlCommandProvider<"""
        SELECT 
            BusinessEntityId,
            Title,
            FirstName,
            LastName
        FROM
            Person.Person
        WHERE
            Person.LastName LIKE @surnameWildCard
        ORDER BY
            LastName,
            FirstName
        """ , connectionString>()

    cmd.Execute(surnameWildCard = surnameWildCard)

do FindPeople "%sen" |> printfn "%A"

let (~~) (s : string option) =
    match s with
    | Some s -> s
    | None -> ""

let ShowPeople =
    FindPeople 
    >> Seq.iter (fun person ->
        printfn "%s\t%s\t%s" 
            // Remove the ~~ to see an error:
            ~~person.Title person.FirstName person.LastName)

do ShowPeople "%sen"