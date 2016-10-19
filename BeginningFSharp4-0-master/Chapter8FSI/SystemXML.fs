#if INTERACTIVE
#else
module SystemXML
#endif

open System.Xml

// Create an xml dom object:
let fruitsDoc =
    let temp = new XmlDocument()
    temp.Load(__SOURCE_DIRECTORY__ + "/fruits.xml")
    temp
    
// Select a list of nodes from the xml dom:
let fruits = fruitsDoc.SelectNodes("/fruits/*")

// Print out the name and text from each node:
for x in fruits do
    printfn "%s = %s " x.Name x.InnerText


open System.Xml

let animals =
    [
        "ants", 6
        "spiders", 8
        "cats", 4
    ]

// Create an xml dom object:
let animalsDoc = new XmlDocument()

// Create the root element and append it to the doc:
let rootNode = animalsDoc.CreateElement("animals")
animalsDoc.AppendChild(rootNode) |> ignore

// Add each animal to the document:
for animal in animals do
    let name, legs = animal
    let animalElement = animalsDoc.CreateElement(name)
    // Set the leg-count as the inner text of the element:
    animalElement.InnerText <- legs.ToString()
    rootNode.AppendChild(animalElement) |> ignore

// Save the document:
animalsDoc.Save(@"c:\temp\animals.xml")
