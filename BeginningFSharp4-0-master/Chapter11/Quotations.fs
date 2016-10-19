#if INTERACTIVE
#else
module Quotations
#endif

open System.Collections.Generic
open Microsoft.FSharp.Quotations
open Microsoft.FSharp.Quotations.Patterns
open Microsoft.FSharp.Quotations.DerivedPatterns

let interpret exp =
    let operandsStack = new Stack<int>()
    let preformOp f name =
        let x, y = operandsStack.Pop(), operandsStack.Pop()
        printfn "%s %i, %i" name x y
        let result = f x y
        operandsStack.Push(result)
    let rec interpretInner exp =
        match exp with
        | SpecificCall <@ (*) @> (_,_, [l;r])  -> interpretInner l 
                                                  interpretInner r
                                                  preformOp (*) "Mult"
        | SpecificCall <@ (+) @> (_,_, [l;r])  -> interpretInner l 
                                                  interpretInner r
                                                  preformOp (+) "Add"
        | SpecificCall <@ (-) @> (_,_, [l;r])  -> interpretInner l 
                                                  interpretInner r
                                                  preformOp (-) "Sub"
        | SpecificCall <@ (/) @> (_,_, [l;r])  -> interpretInner l 
                                                  interpretInner r
                                                  preformOp (/) "Div"
        | Value (x,ty) when ty = typeof<int>    -> 
                                                   let i = x :?> int
                                                   printfn "Push: %i" i
                                                   operandsStack.Push(x :?> int)
        | _ -> failwith "not a valid op"
    interpretInner exp
    printfn "Result: %i" (operandsStack.Pop())
    
interpret <@ (2 * (2 - 1)) / 2 @>
