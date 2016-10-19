// !!! C# Source !!!
using System;
using Strangelights;

static class PrintClass
{
    internal static void HourMinute()
    {
        // Call the "hourAndMinute" function and collect the
        // tuple that's returned:
        Tuple<int, int> t = DemoModule.hourAndMinute(DateTime.Now);
        // Print the tuple's contents:
        Console.WriteLine("Hour {0} Minute {1}", t.Item1, t.Item2);
    }
}
