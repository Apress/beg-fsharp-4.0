#if INTERACTIVE
#r "System.Xml.dll"
#else
module HttpGoogleSpreadsheets
#endif

open System
open System.IO
open System.Net
open System.Xml
open System.Xml.XPath

// some namespace information for the XML 
let namespaces =
    [ "at", "http://www.w3.org/2005/Atom";
      "openSearch", "http://a9.com/-/spec/opensearchrss/1.0/";
      "gsx", "http://schemas.google.com/spreadsheets/2006/extended" ]

// read the XML and process it into a matrix of strings
let queryGoogleSpreadSheet (xdoc: XmlDocument) xpath columnNames =
    let nav = xdoc.CreateNavigator()
    let mngr = new XmlNamespaceManager(new NameTable())
    do List.iter (fun (prefix, url) -> 
                     mngr.AddNamespace(prefix, url)) namespaces
    let xpath = nav.Compile(xpath)
    do xpath.SetContext(mngr)
    let iter = nav.Select(xpath)
    seq { for x in iter -> 
            let x  = x :?> XPathNavigator
            let getValue nodename =
                let node = x.SelectSingleNode(nodename, mngr)
                node.Value
            Seq.map getValue columnNames }

// read the spreadsheet from its web address
let getGoogleSpreadSheet (url: string) columnNames =
    let req = WebRequest.Create(url)
    use resp = req.GetResponse()
    use stream = resp.GetResponseStream()
    let xdoc = new XmlDocument()
    xdoc.Load(stream)
    queryGoogleSpreadSheet xdoc "/at:feed/at:entry" columnNames

// a location to hold the information we're interested in
type Location =
    { Country: string;
      NameValuesList: seq<string * option<float>> }

// creates a location from the row names
let createLocation names row  =
    let country = Seq.head row
    let row = Seq.skip 1 row
    let tryParse s =
        let success,res = Double.TryParse s
        if success then Some res else None
    let values = Seq.map tryParse row
    { Country = country;
      NameValuesList = Seq.zip names values }
// get the data and process it into records
let getDataAndProcess url colNames = 
    // get the names of the columns we want
    let cols = Seq.map fst colNames
    // get the data
    let data = getGoogleSpreadSheet url cols
    
    // get the readable names of the columns
    let names = Seq.skip 1 (Seq.map snd colNames)
    // create strongly typed records from the data
    Seq.map (createLocation names) data

// function to create a spreadsheets URL from its key
let makeUrl = sprintf "http://spreadsheets.google.com/feeds/list/%s/od6/public/values"

let main() =
    // the key of the spreadsheet we're interested in
    let sheetKey = "phNtm3LmDZEP61UU2eSN1YA"
    // list of column names we're interested in
    let cols =
        [ "gsx:location", "";
          "gsx:hospitalbedsper10000population", 
            "Hospital beds per 1000";
          "gsx:nursingandmidwiferypersonneldensityper10000population", 
            "Nursing and Midwifery Personnel per 1000" ];
    // get the data
    let data = getDataAndProcess (makeUrl sheetKey) cols
    // print the data
    Seq.iter (printfn "%A") data

do main()
