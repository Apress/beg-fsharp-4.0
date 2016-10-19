#if INTERACTIVE
#else
module DotNetIndexers
#endif

open System.Collections.Generic

// Create and populate a ResizeArray:
let stringList =
    let temp = new ResizeArray<string>()
    temp.AddRange([| "one"; "two"; "three" |]);
    temp

// Unpack items from the resize array using Item() syntax:
let itemOne = stringList.Item(0)
// ...and using index syntax:
let itemTwo = stringList.[1]

// Print the unpacked items:
printfn "%s %s" itemOne itemTwo

