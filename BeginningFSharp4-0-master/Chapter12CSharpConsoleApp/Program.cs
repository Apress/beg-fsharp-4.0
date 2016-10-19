using System;
using Strangelights;
using Microsoft.FSharp.Core;
using Microsoft.FSharp.Collections;

class Program
{
    static void Main(string[] args)
    {
        // get the list of integers
        FSharpList<int> ints = DemoModule4.getList();

        // foreach over the list printing it
        foreach (int i in ints)
        {
            Console.WriteLine(i);
        }
    }
}