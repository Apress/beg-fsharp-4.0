#if INTERACTIVE
#else
module IdentifiersAndLetBindings
#endif

// A literal value:
let x = 42

// Binding (declaring) a function (the hard way!):
let myAdd = fun x y -> x + y

let y = myAdd 3 4

// Binding a function (the easy way):
let raisePowerTwo x = x ** 2.0

let z = raisePowerTwo 3.

// Binding literal values, binding functions, and calling
// functions to bind other values all use 'let':
let n = 10
let add a b = a + b
let result = add n 4

printfn "result = %i" result

// You can use ' ("prime") to denote some variation on an original value:
let x' = 43

// Identifiers can be Unicode:
let 标识符 = 42

// Use otherwise-illegal characters by double-backtick quoting:
let ``more? `` = true
let ``class`` = "style"

// Indenting defines scope:
let halfWay a b =
    let dif = b - a
    let mid = dif / 2
    mid + a

printfn "(halfWay 5 11) = %i" (halfWay 5 11)
printfn "(halfWay 11 5) = %i" (halfWay 11 5)

// You can use OCaml's 'in' (but no-one ever does):
let halfWay2 a b =
    let dif = b - a in
    let mid = dif / 2 in
    mid + a

// When identifiers are out of scope (as define by indenting)
// it's a compiler error to use them:
let printMessage() =
    let message = "Help me"
    printfn "%s" message

// Un-comment the next line to see an error:
//printfn "%s" message

// Within a function you can re-bind an identifier using 
// another value:
// (This is not the same as variable assignment.)
let SafeUpperCase (s : string) =
    let s = if s = null then "" else s
    s.ToUpperInvariant()
    
// You can re-bind an identifer using a different type:
// (This is not the same as dynamic typing.)
let changeType () =
    let x = 1             // Bind x to an integer
    let x = "change me"   // Rebind x to a string
    // Un-comment the next line to see an error:
    //let x = x + 1         // Attempt to rebind to itself plus an integer
    printfn "%s" x

// When you bind using the same name in an inner scope,
// the original value becomes accessible again when you 
// come out of that scope:
let printMessages() =
    // Define message and print it:
    let message = "Important"
    printfn "%s" message;
    // Define an inner function that redefines value of message:
    let innerFun () =
        let message = "Very Important"
        printfn "%s" message
    // Call the inner function:
    innerFun ()
    // Finally print the first message again:
    printfn "%s" message
    
printMessages()

// Functions can return functions:
let calculatePrefixFunction prefix =
    // Calculate prefix:
    let prefix' = Printf.sprintf "[%s]: " prefix
    // Define function to perform prefixing:
    let prefixFunction appendee =
        Printf.sprintf "%s%s" prefix' appendee
    // Return function:
    prefixFunction
    
// Create the prefix function:
let prefixer = calculatePrefixFunction "DEBUG"

// Use the prefix function:
printfn "%s" (prefixer "My message")
