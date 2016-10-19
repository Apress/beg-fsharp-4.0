#if INTERACTIVE
#else
module Arrays
#endif

// Define an array literal:
let rhymeArray =
    [| "Went to market"; // Semi-colons are optional when items are on separate lines
       "Stayed home";
       "Had roast beef";
       "Had none" |]

// Unpack the array into identifiers:
let firstPiggy = rhymeArray.[0]
let secondPiggy = rhymeArray.[1]
let thirdPiggy = rhymeArray.[2]
let fourthPiggy = rhymeArray.[3]

// Update elements of the array:
rhymeArray.[0] <- "Wee,"
rhymeArray.[1] <- "wee,"
rhymeArray.[2] <- "wee,"
rhymeArray.[3] <- "all the way home"

// Give a short name to the new line characters:
let nl = System.Environment.NewLine

// Print out the identifiers & array:
printfn "%s%s%s%s%s%s%s"
    firstPiggy nl
    secondPiggy nl
    thirdPiggy nl
    fourthPiggy
printfn "%A" rhymeArray

// Define a jagged array literal:
let jagged = [| [| "one" |] ; [| "two" ; "three" |] |]

// Unpack elements from the arrays:
let singleDim = jagged.[0]
let itemOne = singleDim.[0]
let itemTwo = jagged.[1].[0]

// Print some of the unpacked elements:
printfn "%s %s" itemOne itemTwo

// Create a square array,
// initially populated with zeros:
let square = Array2D.create 2 2 0

// Populate the array:
square.[0,0] <- 1
square.[0,1] <- 2
square.[1,0] <- 3
square.[1,1] <- 4

// Print the array:
printfn "%A" square

// Define Pascal's Triangle as an
// array literal:
let pascalsTriangle =
    [| [|1|];
       [|1; 1|];
       [|1; 2; 1|];
       [|1; 3; 3; 1|];
       [|1; 4; 6; 4; 1|];
       [|1; 5; 10; 10; 5; 1|];
       [|1; 6; 15; 20; 15; 6; 1|];
       [|1; 7; 21; 35; 35; 21; 7; 1|];
       [|1; 8; 28; 56; 70; 56; 28; 8; 1|]; |]

// Collect elements from the jagged array
// assigning them to a square array:
let numbers =
    let length = (Array.length pascalsTriangle)
    let temp = Array2D.create 3 length 0
    for index = 0 to length - 1 do
        let naturelIndex = index - 1
        if naturelIndex >= 0 then
            temp.[0, index] <- pascalsTriangle.[index].[naturelIndex]
        let triangularIndex = index - 2
        if triangularIndex >= 0 then
            temp.[1, index] <- pascalsTriangle.[index].[triangularIndex]
        let tetrahedralIndex = index - 3
        if tetrahedralIndex >= 0 then
            temp.[2, index] <- pascalsTriangle.[index].[tetrahedralIndex]
    done
    temp

// Print the array:
printfn "%A" numbers

// An array of characters created using a comprehension:
let chars = [| '1' .. '9' |]

// An array of tuples of number, square created using
// a for loop in a comprehension:
let squares =
    [| for x in 1 .. 9 -> x, x*x |]

// Print out both arrays:
printfn "%A" chars
printfn "%A" squares

// An array literal:
let arr = [|1; 3; 5; 7; 11; 13|]
// Get a slice from the array:
let middle = arr.[1..4] // [|3; 5; 7; 11|]

// Omit the starting or ending index to start from 
// the beginning or end of the input array:
let start = arr.[..3] // [|1; 3; 5; 7|]
let tail = arr.[1..] // [|3; 5; 7; 11; 13|]

// Slicing also works for multi-dimensional arrays:
let ocean = Array2D.create 100 100 0
// Create a ship:
for i in 3..6 do
    ocean.[i, 5] <- 1
// Pull out an area hit by a 'shell':
let hitArea = ocean.[2..5, 2..5]

// Slice a rectangular area:
let radarArea = ocean.[3..4, *]
