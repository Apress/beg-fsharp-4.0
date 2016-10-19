#if INTERACTIVE
#else
module TypeTests
#endif

// Create a string and upcast it to an object:
let anotherObject = ("This is a string" :> obj)

// Do a type test to see if the original object was a string:
if (anotherObject :? string) then
    printfn "This object is a string"
else
    printfn "This object is not a string"
  
 // Do a type test to see if the original object was a string array:
if (anotherObject :? string[]) then
    printfn "This object is a string array"
else
    printfn "This object is not a string array"
