#if INTERACTIVE
#else
module ArithmeticOperators
#endif

// Apply some basic arithmetic operators:
let x1 = 1 + 1
let x2 = 1 - 1

// Declare a person record type:
type person = { name : string ; favoriteColor : string }

// Create some record instance:
let robert1 = { name = "Robert" ; favoriteColor = "Red" }
let robert2 = { name = "Robert" ; favoriteColor = "Red" }
let robert3 = { name = "Robert" ; favoriteColor = "Green" }

// Demonstrate structural equality:
printfn "(robert1 = robert2): %b" (robert1 = robert2)
printfn "(robert1 <> robert3): %b" (robert1 <> robert3)

// Demonstrate structural comparison:
printfn "(robert2 > robert3): %b" (robert2 > robert3)

// Demonstrate physical equality:
printfn "(LanguagePrimitives.PhysicalEquality robert1 robert2): %b" 
    (LanguagePrimitives.PhysicalEquality robert1 robert2)

