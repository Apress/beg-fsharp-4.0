#if INTERACTIVE
#r "System.Drawing"
#else
module CustomAttributes
#endif

// Applying an attribute to a function:
open System

[<Obsolete>]
let functionOne () = ()

// Adding a parameter value to an attribute:
open System

[<Obsolete("it is a pointless function anyway!")>]
let functionTwo () = ()

// Setting a property for an attribute:
open System.Drawing.Printing
open System.Security.Permissions

[<PrintingPermission(SecurityAction.Demand, Unrestricted = true)>]
let functionThree () = ()

open System
open System.Drawing.Printing
open System.Security.Permissions

// Applying multiple attributes:
[<Obsolete; PrintingPermission(SecurityAction.Demand)>]
let functionFive () = ()

open System

// Marking a class an its members as obsolete:
[<Obsolete>]
type OOThing = class
    [<Obsolete>]
    val stringThing : string
    [<Obsolete>]
    new() = {stringThing = ""}
    [<Obsolete>]
    member x.GetTheString () = x.stringThing
end

// Running an application as a single-threaded apartment:
open System
open System.Windows.Forms

let form = new Form()

[<STAThread>]
Application.Run(form)

open System

// Using reflection to get a list of all obsolete types:
let obsolete = AppDomain.CurrentDomain.GetAssemblies()
                  |> List.ofArray
                  |> List.map (fun assm -> assm.GetTypes())
                  |> Array.concat
                  |> List.ofArray
                  |> List.filter (fun m ->
                    m.IsDefined(typeof<ObsoleteAttribute>, true))

// Print the list:
printfn "%A" obsolete
