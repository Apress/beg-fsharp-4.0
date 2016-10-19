#if INTERACTIVE
#else
module TypesAndTypeInference
#endif

// Types of values are inferred from what
// is bound to them. (Hover over the
// value identifier or send to F# Interactive
// to see the type.)

let aString = "Spring time in Paris"
let anInt = 42

let makeMessage x = (Printf.sprintf "%i" x) + " days to spring time"
let half x = x / 2

// The types of 'curried' (partially-applicable) and 'tupled'
// functions differ:
let div1 x y = x / y
let div2 (x, y) = x / y

let divRemainder x y = x / y, x % y

// Where appropriate functions are generalised; this
// function takes any type and returns its value 
// unchanged:
let doNothing x = x

// You can constrain a value to be a specific type
// by specifying the type after a colon:
let doNothingToAnInt (x: int) = x

// By default the element type of generic containers like
// lists is inferred...
let intList = [1; 2; 3]

// ...but you can specify it if you want:
let (stringList: list<string>) = ["one"; "two"; "three"]

