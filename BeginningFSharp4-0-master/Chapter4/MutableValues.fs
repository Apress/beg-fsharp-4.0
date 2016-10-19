#if INTERACTIVE
#else
module MutableValues
#endif

// A mutable identifier:
let mutable phrase = "How can I be sure, "

// Print the phrase:
printfn "%s" phrase
// Update the phrase:
phrase <- "In a world that's constantly changing"
// Reprint the phrase:
printfn "%s" phrase

// You can't update a mutable with a value
// of a different type:
let mutable number = "one"
// Uncomment this line to see an error:
//phrase <- 1

// Redefining (shadowing) a value in
// an inner scope means the old value
// is still there afterwards:
let redefineX() =
    let x = "One"
    printfn "Redefining:\r\nx = %s" x
    if true then
        let x = "Two"
        printfn "x = %s" x
    printfn "x = %s" x

// Mutating a mutable value in an inner 
// scope leaves the mutated value available 
// afterwards:
let mutableX() =
    let mutable x = "One"
    printfn "Mutating:\r\nx = %s" x
    if true then
        x <- "Two"
        printfn "x = %s" x
    printfn "x = %s" x

// Run the demos:
redefineX()
mutableX()

// Mutables can be captured in F# 4.0
// but not in earlier versions:
let mutableY() =
    let mutable y = "One"
    printfn "Mutating:\r\nx = %s" y
    let f() =
        // This causes an error in
        // F# 3.1 and earlier as
        // mutables can't be captured
        y <- "Two"
        printfn "x = %s" y
    f()
    printfn "x = %s" y

// Records can have mutable fields:
type Couple = { Her: string; mutable Him: string }

// Create an instance of the record:
let theCouple = { Her = "Elizabeth Taylor "; Him = "Nicky Hilton" }

// A function to change the contents of
// the record over time:
let changeCouple() =
    printfn "%A" theCouple
    theCouple.Him <- "Michael Wilding"
    printfn "%A" theCouple
    theCouple.Him <- "Michael Todd"
    printfn "%A" theCouple
    theCouple.Him <- "Eddie Fisher"
    printfn "%A" theCouple
    theCouple.Him <- "Richard Burton"
    printfn "%A" theCouple
    theCouple.Him <- "Richard Burton"
    printfn "%A" theCouple
    theCouple.Him <- "John Warner"
    printfn "%A" theCouple
    theCouple.Him <- "Larry Fortensky"
    printfn "%A" theCouple

// Call the function:
changeCouple()

// You can only mutate those fields which are mutable:
// Uncomment the next line to see an error:
//theCouple.Her <- "Sybil Williams"

// You can use a ref type as another kind of
// updatable value:

// Function to compute the total of an array using a
// ref type:
let totalArray () =
    // Define an array literal:
    let array = [| 1; 2; 3 |]
    // Define an accumulator:
    let total = ref 0
    // Loop over the array:
    for x in array do
        // Keep a running total:
        total := !total + x
    // Print the total:
    printfn "total: %i" !total

totalArray()

// Use a hidden reference value to implement an
// incrementable/decrementable counter:

// Define inc, dec and show functions that share
// a ref value that is hidden from outside:
let inc, dec, show =
    // Define the shared state:
    let n = ref 0
    // A function to increment:
    let inc () =
        n := !n + 1
    // A function to decrement:
    let dec () =
        n := !n - 1
    // A function to show the current state
    let show () =
        printfn "%i" !n

    // Return the functions to the top level:
    inc, dec, show

// Test the functions:
inc()
inc()
dec()
show()

// Use a hidden mutable value to implement an
// incrementable/decrementable counter (from F# 4.0):

// Define inc, dec and show functions that share
// a mutable value that is hidden from outside:
let inc2, dec2, show2 =
    // Define the shared state:
    let mutable n = 0
    // A function to increment:
    let inc2 () =
        n <- n + 1
    // A function to decrement:
    let dec2 () =
        n <- n - 1
    // A function to show the current state:
    let show2 () =
        printfn "%i" n

    // return the functions to the top level:
    inc2, dec2, show2

// test the functions
inc2()
inc2()
dec2()
show2()
