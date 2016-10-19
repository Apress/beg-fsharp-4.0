#if INTERACTIVE
#else
module Interpret
#endif

open System

type Ast = 
   | Ident of string
   | Val of System.Double
   | Multi of Ast * Ast
   | Div of Ast * Ast
   | Plus of Ast * Ast
   | Minus of Ast * Ast

// Requesting a value for variable from the user:
let getVariableValues e =
    let rec getVariableValuesInner input (variables : Map<string, float>) =
        match input with
        | Ident (s) ->
            match variables.TryFind(s) with
            | Some _ -> variables
            | None ->
                printfn "%s: " s
                let v = float(Console.ReadLine())
                variables.Add(s,v)
        | Multi (e1, e2) -> 
            variables
            |> getVariableValuesInner e1
            |> getVariableValuesInner e2
        | Div (e1, e2) -> 
            variables
            |> getVariableValuesInner e1
            |> getVariableValuesInner e2
        | Plus (e1, e2) ->
            variables
            |> getVariableValuesInner e1
            |> getVariableValuesInner e2
        | Minus (e1, e2) ->
            variables
            |> getVariableValuesInner e1
            |> getVariableValuesInner e2
        | _ -> variables
    getVariableValuesInner e (Map.empty)

// Function to handle the interpretation:
let interpret input (variableDict : Map<string,float>) = 
    let rec interpretInner input =
        match input with
        | Ident (s) -> variableDict.[s] 
        | Val (v) -> v
        | Multi (e1, e2) -> (interpretInner e1) * (interpretInner e2)
        | Div (e1, e2) -> (interpretInner e1) / (interpretInner e2)
        | Plus (e1, e2) -> (interpretInner e1) + (interpretInner e2)
        | Minus (e1, e2) -> (interpretInner e1) - (interpretInner e2)
    interpretInner input
    
// The expression to be interpreted:
let e = Multi(Val 2., Plus(Val 2., Ident "a"))

// Collect the arguments from the user:
let args = getVariableValues e

// Interpret the expression:
let v = interpret e args

// Print the results:
printf "result: %f" v
