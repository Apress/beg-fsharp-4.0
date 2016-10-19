#if INTERACTIVE
#else
module Delegates
#endif

// Define a delegate type:
type MyDelegate = delegate of int -> unit

// Create an instance of the delgate type and
// make it print an integer when evoked:
let inst = new MyDelegate (fun i -> printf "%i" i)

// Invoke the delegate for each of a list of ints:
let ints = [1 ; 2 ; 3 ]
ints
|> List.iter (fun i -> inst.Invoke(i))
