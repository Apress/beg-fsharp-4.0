#if INTERACTIVE
#else
module ListComprehensions
#endif

// Create some list comprehensions:
let numericList = [ 0 .. 9 ]
let alpherSeq = seq { 'A' .. 'Z' }

// Print them:
printfn "%A" numericList
printfn "%A" alpherSeq

// Create some list comprehensions with 
// defined intervals:
let multiplesOfThree = [ 0 .. 3 .. 30 ]
let revNumericSeq = [ 9 .. -1 .. 0 ]

// Print them:
printfn "%A" multiplesOfThree
printfn "%A" revNumericSeq

// Loop over a range to produce a sequence of squares:
let squares =
    seq { for x in 1 .. 10 -> x * x }

// Print the sequence:
printfn "%A" squares

// Use 'yield' to add an element to the 
// sequence being produced:

// A sequence of even numbers:
let evens n =
    seq { for x in 1 .. n do 
            if x % 2 = 0 then yield x }
    
// Print the sequence:
printfn "%A" (evens 10)

// You can nest loops:

// A sequence of tuples representing points:
let squarePoints n =
    seq { for x in 1 .. n do
            for y in 1 .. n do 
                yield x, y }

// Print the sequence:
printfn "%A" (squarePoints 3)
