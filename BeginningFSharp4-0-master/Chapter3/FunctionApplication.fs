#if INTERACTIVE
#else
module FunctionApplication
#endif

let add x y = x + y

// Calling a function is "function application":
let result = add 4 5

printfn "(add 4 5) = %i" result

// You can avoid intermediate values and force
// application-order using brackets:

// Long version with intermediate values:
let result1 = add 4 5
let result2 = add 6 7

let finalResult = add result1 result2

// Short version with brackets:
let result3 = 
    add (add 4 5) (add 6 7)

// You can chain operations with the |> operator:
let result4 = 0.5 |> System.Math.Cos

let result5 = add 6 7 |> add 4 |> add 5

