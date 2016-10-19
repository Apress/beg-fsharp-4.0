module Strangelights.DemoModule2
open System

/// A function that provides filtering:
let filterStringList f ra = 
    ra |> Seq.filter f

// Another function that provides filtering:
let filterStringListDelegate (pred: Predicate<string>) ra = 
        let f x = pred.Invoke(x)
        new ResizeArray<string>(ra |> Seq.filter f)
