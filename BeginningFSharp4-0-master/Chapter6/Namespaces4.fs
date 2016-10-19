#if INTERACTIVE
#else
module Namespaces4
#endif

// Call a method using its full name:
System.Console.WriteLine("Hello world")

// Open a namespace and call a method using
// its short name:
open System
Console.WriteLine("Hello world")

// Open a namespace to a certain level:
open System.Collections

// Call a method using the rest of the namespace:
let wordCountDict =
    new Generic.Dictionary<string, int>()
