#if INTERACTIVE
#else
module LazyEvaluation
#endif

// Define a computation which will not be executed straight away:
let lazyValue = lazy ( 2 + 2 )
// Trigger evaluation of the computation:
let actualValue = lazyValue.Force()

// Print the value:
printfn "%i" actualValue

// Define a computation which has a side effect:
let lazySideEffect =
    lazy
        ( let temp = 2 + 2
          printfn "%i" temp
          temp )
    
// Trigger evaluation of the computation the first time;
// the side effect occurs:    
printfn "Force value the first time: "
let actualValue1 = lazySideEffect.Force()

// Trigger evaluation of the computation the second time;
// the side effect does not occur:
printfn "Force value the second time: "
let actualValue2 = lazySideEffect.Force()

// Create a lazy collection using Seq.unfold:
let lazyList =
    Seq.unfold
        (fun x ->
            if x < 13 then
                // If smaller than the limit return
                // the current and next value:
                Some(x, x + 1)
            else
                // If great than the limit 
                // terminate the sequence:
                None)
        10

// Print the results:
printfn "%A" lazyList

// Create an infinite list of Fibonacci numbers:
let fibs =
    Seq.unfold
        (fun (n0, n1) ->
            Some(n0, (n1, n0 + n1)))
        (1I,1I)

// Take the first twenty items from the infinite list:
let first20 = Seq.take 20 fibs

// Print the first twenty items:
printfn "%A" first20
