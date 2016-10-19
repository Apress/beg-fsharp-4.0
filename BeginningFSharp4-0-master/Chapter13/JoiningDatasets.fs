#if INTERACTIVE
// You may have to alter this path depending on the version
// of FSharp.Data downloaded and on you project structure
#r @"../packages/FSharp.Data.2.2.5/lib/net40/FSharp.Data.dll"
#r @"../packages/FSharp.Data.SqlClient.1.7.7/lib/net40/FSharp.Data.SqlClient.dll"
#else
module VerifyCountryCodes
#endif

open FSharp.Data

[<Literal>]
let url = "https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2"
[<Literal>]
let connectionString = 
    @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2014;Integrated Security=True"

type WikipediaPage = 
    HtmlProvider<url>

type WikiCode =
    {
        Code : string
        Name : string
        Notes : string
    }

type DbCode =
    {
        Code : string
        Name : string
    }

type ReportItem =
    {
        Code : string
        WikiName : string
        DBName : string
        Notes : string
    }

let CountryCodesWikipedia() = 
    let page = WikipediaPage.Load(url)

    let codes = page.Tables.``Officially assigned code elements``

    [ for row in codes.Rows -> 
        { WikiCode.Code = row.Code
          Name = row.``Country name``
          Notes = row.Notes } ]

let CountryCodesDatabase() = 
    use cmd = new SqlCommandProvider<"""
        SELECT
	        CountryRegionCode,
	        Name
        FROM
	        Person.CountryRegion
        ORDER BY
	        CountryRegionCode
        """ , connectionString>()

    let data = cmd.Execute()

    [ for row in data ->
        { DbCode.Code = row.CountryRegionCode
          Name = row.Name } ]

let Report() =
    query {
        for dbc in CountryCodesDatabase() do
        join wkc in CountryCodesWikipedia() on 
            (dbc.Code = wkc.Code)
        where (wkc.Notes <> "" || wkc.Name <> dbc.Name)
        sortBy (wkc.Code)
        select 
            {
                ReportItem.Code = wkc.Code
                WikiName = wkc.Name
                DBName = dbc.Name
                Notes = wkc.Notes
            }
    } 
    |> Array.ofSeq

do Report() |> printfn "%A"
