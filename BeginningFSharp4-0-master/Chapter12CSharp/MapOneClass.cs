// !!! C# Source !!!
using System;
using System.Collections.Generic;
using Strangelights;
using Microsoft.FSharp.Core;

class MapOneClass
{
    public static void MapOne()
    {
        // define a list of names
        List<string> names = new List<string>(
                new string[] { "Stefany", "Oussama",
        "Sebastien", "Frederik" });

        // define a predicate delegate/function
        Converter<string, bool> pred =
                delegate (string s) { return s.StartsWith("S"); };

        // convert to a FastFunc
        FSharpFunc<string, bool> ff =
                FuncConvert.ToFSharpFunc<string, bool>(pred);

        // call the F# demo function
        IEnumerable<string> results =
                 DemoModule2.filterStringList(ff, names);

        // write the results to the console
        foreach (var name in results)
        {
            Console.WriteLine(name);
        }
    }
}
