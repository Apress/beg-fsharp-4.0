namespace Strangelights
open System
open System.Runtime.InteropServices

// Define an interface (since all COM classes must
// have a seperate interface)
// mark it with a freshly generated Guid:
[<Guid("6180B9DF-2BA7-4a9f-8B67-AD43D4EE0563")>]
type IMath =
    abstract Add : x: int * y: int -> int
    abstract Sub : x: int * y: int -> int


// Implement the interface, the class must:
// - have an empty constuctor
// - be marked with its own guid
// - be marked with the ClassInterface attribute
[<Guid("B040B134-734B-4a57-8B46-9090B41F0D62");
ClassInterface(ClassInterfaceType.None)>]
type Math() =
    interface IMath with
        member this.Add(x, y) = x + y
        member this.Sub(x, y) = x - y
