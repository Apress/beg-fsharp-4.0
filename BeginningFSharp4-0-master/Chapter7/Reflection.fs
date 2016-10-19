#if INTERACTIVE
#else
module ReflectionOverTypes
#endif

open FSharp.Reflection

// Check whether a type is a tuple,
// and if it is print the types of
// the elements:
let printTupleTypes (x: obj) =
    let t = x.GetType()
    if FSharpType.IsTuple t then
        let types = FSharpType.GetTupleElements t
        printf "("
        types
        |> Seq.iteri
            (fun i t ->
            if i <> Seq.length types - 1 then
                printf " %s * " t.Name
            else
                printf "%s" t.Name)
        printfn " )"
    else 
        printfn "not a tuple"
    
printTupleTypes ("hello world", 1)

open FSharp.Reflection

// Check whether a type is a tuple,
// and if it is print the values of
// the elements:
let printTupleValues (x: obj) =
    if FSharpType.IsTuple(x.GetType()) then
        let vals = FSharpValue.GetTupleFields x
        printf "("
        vals
        |> Seq.iteri
            (fun i v ->
                if i <> Seq.length vals - 1 then
                    printf " %A, " v
                else
                    printf " %A" v)
        printfn " )"
    else
        printfn "not a tuple"
    
printTupleValues ("hello world", 1)

