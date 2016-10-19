// !!! C# Source !!!
using System;
using Strangelights;

class GetQuantityThreeClass
{
    public static void GetQuantityThree()
    {
        // get a random quantity
        ImprovedModule.EasyQuantity q = ImprovedModule.getRandomEasyQuantity();
        // convert quantity to a float and show it
        Console.WriteLine("Value as a float: {0}", q.ToFloat());
    }
}
