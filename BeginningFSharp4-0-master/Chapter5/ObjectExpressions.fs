#if INTERACTIVE
#else
module ObjectExpressions
#endif

open System
open System.Collections.Generic

// A comparer that will compare strings in their reversed order:
let comparer =
    { new IComparer<string>
        with
            member x.Compare(s1, s2) =
                // function to reverse a string
                let rev (s: String) =
                    new String(Array.rev (s.ToCharArray()))
                // reverse 1st string
                let reversed = rev s1
                // compare reversed string to 2nd strings reversed
                reversed.CompareTo(rev s2) }

// Eurovision winners in a random order:
let winners =
    [| "Sandie Shaw"; "Bucks Fizz"; "Dana International" ;
       "Abba"; "Lordi" |]

// Print the winners:
printfn "%A" winners
// Sort the winners:
Array.Sort(winners, comparer)
// Print the winners again:
printfn "%A" winners
