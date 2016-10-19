#if INTERACTIVE
#else
module Compile
#endif

open System
open System.Reflection
open System.Reflection.Emit

type Ast = 
   | Ident of string
   | Val of System.Double
   | Multi of Ast * Ast
   | Div of Ast * Ast
   | Plus of Ast * Ast
   | Minus of Ast * Ast

// get a list of all the parameter names
let rec getParamList e = 
    let rec getParamListInner e names = 
        match e with
        | Ident name -> 
            if not (List.exists (fun s -> s = name) names) then 
                name :: names
            else
                names
        | Multi (e1 , e2) -> 
            names
            |> getParamListInner e1
            |> getParamListInner e2 
        | Div (e1 , e2) -> 
            names
            |> getParamListInner e1
            |> getParamListInner e2 
        | Plus (e1 , e2) -> 
            names
            |> getParamListInner e1
            |> getParamListInner e2 
        | Minus (e1 , e2) -> 
            names
            |> getParamListInner e1
            |> getParamListInner e2 
        | _ -> names
    getParamListInner e []

// create the dyncamic method
let createDynamicMethod e (paramNames: string list) =
    let generateIl e (il : ILGenerator) =
        let rec generateIlInner e  = 
            match e with
            | Ident name -> 
                let index = List.findIndex (fun s -> s = name) paramNames
                il.Emit(OpCodes.Ldarg, index)
            | Val x -> il.Emit(OpCodes.Ldc_R8, x)
            | Multi (e1 , e2) -> 
                generateIlInner e1
                generateIlInner e2
                il.Emit(OpCodes.Mul)
            | Div (e1 , e2) -> 
                generateIlInner e1
                generateIlInner e2
                il.Emit(OpCodes.Div)
            | Plus (e1 , e2) -> 
                generateIlInner e1
                generateIlInner e2
                il.Emit(OpCodes.Add)
            | Minus (e1 , e2) -> 
                generateIlInner e1
                generateIlInner e2
                il.Emit(OpCodes.Sub)
        generateIlInner e
        il.Emit(OpCodes.Ret)

    let paramsTypes = Array.create paramNames.Length (typeof<float>)
    let meth = MethodInfo.GetCurrentMethod()
    let temp = new DynamicMethod("", (typeof<float>), paramsTypes, meth.Module)
    let il = temp.GetILGenerator()
    generateIl e il
    temp

// function to read the arguments from the command line
let collectArgs (paramNames : string list) =
    paramNames
    |> Seq.map 
        (fun n -> 
            printfn "%s: " n
            box (float(Console.ReadLine())))
    |> Array.ofSeq

// the expression to be interpreted
let e = Multi(Val 2., Plus(Val 2., Ident "a"))

// get a list of all the parameters from the expression
let paramNames = getParamList e

// compile the tree to a dynamic method
let dm = createDynamicMethod e paramNames

// print collect arguments from the user
let args = collectArgs paramNames

// execute and print out the final result
printfn "result: %O" (dm.Invoke(null, args))
