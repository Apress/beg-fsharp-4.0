#if INTERACTIVE
#r "System.Xml.dll"
#else
module Http
#endif

open System
open System.Diagnostics
open System.Net
open System.Xml

/// Makes a http request to the given url:
let getUrlAsXml (url: string) =
    let request = WebRequest.Create(url)
    let response = request.GetResponse()
    let stream = response.GetResponseStream()
    let xml = new XmlDocument()
    xml.Load(stream)
    xml

/// The url we interested in:
let url = "http://newsrss.bbc.co.uk/rss/newsonline_uk_edition/sci/tech/rss.xml"

/// Main application function:
let main() =
    // Read the rss feed:
    let xml = getUrlAsXml url
    
    // Write out the tiles of all the news items:
    let nodes = xml.SelectNodes("/rss/channel/item/title")
    for i in 0 .. (nodes.Count - 1) do
        printf "%i. %s\r\n" (i + 1) (nodes.[i].InnerText)
    
    // Read the number the user wants from the console:
    let item = int(Console.ReadLine())

    // Find the new url:
    let newUrl =
        let xpath = sprintf "/rss/channel/item[%i]/link" item
        let node = xml.SelectSingleNode(xpath)
        node.InnerText
        
    // Start the url using the shell, this automatically opens 
    // the default browser:
    let procStart = new ProcessStartInfo(UseShellExecute = true,
                                         FileName = newUrl)
    let proc = new Process(StartInfo = procStart)
    proc.Start() |> ignore

do main()
