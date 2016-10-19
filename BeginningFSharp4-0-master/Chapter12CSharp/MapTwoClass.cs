// !!! C# Source !!!
using System;
using System.Collections.Generic;
using Strangelights;

class MapTwoClass
{
    public static void MapTwo()
    {
        // define a list of names
        List<string> names = new List<string>(
                new string[] { "Aurelie", "Fabrice",
            "Ibrahima", "Lionel" });

        // call the F# demo function passing in an
        // anonymous delegate
        List<string> results =
                DemoModule2.filterStringListDelegate(
                        delegate (string s) { return s.StartsWith("A"); }, names);

        // write the results to the console
        foreach (var s in results)
        {
            Console.WriteLine(s);
        }
    }
}
