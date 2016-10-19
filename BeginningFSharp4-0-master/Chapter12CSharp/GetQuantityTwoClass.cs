// !!! C# Source !!!
using System;
using Strangelights;

static class GetQuantityTwoClass
{
    public static void GetQuantityTwo()
    {
        // get a random quantity
        DemoModule3.Quantity q = DemoModule3.getRandomQuantity();
        // use if ... else chain to display value
        if (q.IsDiscrete)
        {
            Console.WriteLine("Discrete value: {0}", (q as DemoModule3.Quantity.Discrete).Item);
        }
        else if (q.IsContinuous)
        {
            Console.WriteLine("Continuous value: {0}", (q as DemoModule3.Quantity.Continuous).Item);
        }
    }
}
