#if INTERACTIVE
#r "System.Xml.Linq"
#else
module Linq
#endif

module LinqImports =

    open System
    open System.Linq
    open System.Reflection

    // Define easier access to LINQ methods:
    let select f s = Enumerable.Select(s, new Func<_,_>(f))
    let where f s = Enumerable.Where(s, new Func<_,_>(f))
    let groupBy f s = Enumerable.GroupBy(s, new Func<_,_>(f))
    let orderBy f s = Enumerable.OrderBy(s, new Func<_,_>(f))
    let count s = Enumerable.Count(s)

open System
open LinqImports

// Query string methods using functions:
let namesByFunction =
    (typeof<string>).GetMethods()
    |> where (fun m -> not m.IsStatic)
    |> groupBy (fun m -> m.Name)
    |> select (fun m -> m.Key, count m)
    |> orderBy (fun (_, m) -> m)

// print out the data we've retrieved about the string class:
namesByFunction
|> Seq.iter (fun (name, count) -> printfn "%s - %i" name count)

open System.Xml.Linq

// Query string methods using functions (XML version):
let namesByFunctionXml =
    (typeof<string>).GetMethods()
    |> where (fun m -> not m.IsStatic)
    |> groupBy (fun m -> m.Name)
    |> select (fun m -> new XElement(XName.Get(m.Key), count m))
    |> orderBy (fun e -> int e.Value)

// Create an xml document with the overloads data:
let overloadsXml =
    new XElement(XName.Get("MethodOverloads"), namesByFunction)

// Print the xml string:
printfn "%s" (overloadsXml.ToString())
