#if INTERACTIVE
#else
module PartialApplication
#endif

// Prevent accidental partial application of a function by bracketing 
// its arguments into a 'tuple':
let sub (a, b) = a - b

// Un-comment this line to see an error:
// let subFour = sub 4
