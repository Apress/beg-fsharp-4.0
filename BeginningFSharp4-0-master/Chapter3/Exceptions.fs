#if INTERACTIVE
#else
module Exceptions
#endif

// Define an exception type:
exception WrongSecond of int

// A list of prime numbers:
let primes =
    [ 2; 3; 5; 7; 11; 13; 17; 19; 23; 29; 31; 37; 41; 43; 47; 53; 59 ]

// A function to test if current second is prime:
let testSecond() =
    try
        let currentSecond = System.DateTime.Now.Second in
        // Test if current second is in the list of primes:
        if List.exists (fun x -> x = currentSecond) primes then
            // Use the failwith function to raise an exception:
            failwith "A prime second"
        else
            // Raise the WrongSecond exception:
            raise (WrongSecond currentSecond)
    with
    // Catch the wrong second exception:
    WrongSecond x ->
        printf "The current was %i, which is not prime" x

// Call the function:
testSecond()

// Function to write to a file:
let writeToFile() =
    // Open a file:
    let file = System.IO.File.CreateText("test.txt")
    try
        // Write to it:
        file.WriteLine("Hello F# users")
    finally
        // Close the file; this will happen even if
        // an exception occurs writing to the file:
        file.Dispose()
        
// Call the function:
writeToFile()
