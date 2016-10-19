#if INTERACTIVE
#else
module PatternMatchingLists
#endif

// Use :: and @ to build up a list recursively:

// List of lists to be concatenated into one list:
let listOfList = [[2; 3; 5]; [7; 11; 13]; [17; 19; 23; 29]]

// Definition of a concatenation function:
let rec concatList l =
    match l with
    | head :: tail -> head @ (concatList tail)
    | [] -> []

// Call the function:
let primes = concatList listOfList

// Print the results:
printfn "%A" primes

// Some kinds of pattern matching you can do on lists:

// Function that attempts to find various sequences:
let rec findSequence l =
    match l with
    // Match a list containing exactly 3 numbers:
    | [x; y; z] ->
        printfn "Last 3 numbers in the list were %i %i %i"
            x y z
    // Match a list of 1, 2, 3 in a row:
    | 1 :: 2 :: 3 :: tail ->
        printfn "Found sequence 1, 2, 3 within the list"
        findSequence tail
    // If neither case matches and items remain
    // recursively call the function:
    | head :: tail -> findSequence tail
    // If no items remain terminate:
    | [] -> ()

// Some test data:
let testSequence = [1; 2; 3; 4; 5; 6; 7; 8; 9; 8; 7; 6; 5; 4; 3; 2; 1]

// Call the function:
findSequence testSequence

// Many operations have been defined for you in the List module.

// You could do this...
let rec addOneAll list =
    match list with
    | head :: rest -> 
        head + 1 :: addOneAll rest
    | [] -> []
    
printfn "(addOneAll [1; 2; 3]) = %A" (addOneAll [1; 2; 3])

// ...or this, injecting the operation to be applied to each
// element:
let rec map func list =
    match list with
    | head :: rest -> 
        func head :: map func rest
    | [] -> []

// ...but this feature is already provided as the List.map
// function:
let result = List.map ((+) 1) [1; 2; 3]

printfn "List.map ((+) 1) [1; 2; 3] = %A" result
