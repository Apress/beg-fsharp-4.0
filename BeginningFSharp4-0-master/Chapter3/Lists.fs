#if INTERACTIVE
#else
module Lists
#endif

// An empty F# list:
let emptyList = []

// Use :: to join an element to a list,
// creating a new list:
let oneItem = "one " :: []
let twoItem = "one " :: "two " :: []

// A literal F# list:
let shortHand = ["apples "; "pears"]

// Use @ to concatenate two lists:
let twoLists = ["one, "; "two, "] @ ["buckle "; "my "; "shoe "]

// List elements must be of the same time. Rarely you
// may need to box elements to force this:
let objList = [box 1; box 2.0; box "three"]

// Print the lists:
let main() =
    printfn "%A" emptyList
    printfn "%A" oneItem
    printfn "%A" twoItem
    printfn "%A" shortHand
    printfn "%A" twoLists
    printfn "%A" objList

// Call the main function:
main()

// Lists are immutable; you keep creating
// new list instances by adding to existing
// ones:

// Create a list of one item:
let one = ["one "]
// Create a list of two items:
let two = "two " :: one
// Create a list of three items
let three = "three " :: two

// Reverse the list of three items:
let rightWayRound = List.rev three

// Function to print the results:
let main2() =
    printfn "%A" one
    printfn "%A" two
    printfn "%A" three
    printfn "%A" rightWayRound

// Call the main function:
main2()

