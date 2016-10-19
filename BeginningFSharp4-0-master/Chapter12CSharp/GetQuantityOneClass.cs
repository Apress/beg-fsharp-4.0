// !!! C# Source !!!
using System;
using Strangelights;

static class GetQuantityOneClass
{
    public static void GetQuantityOne()
    {
        // get a random quantity
        DemoModule3.Quantity q = DemoModule3.getRandomQuantity();

        // use the .Tags property to switch over the quatity
        switch (q.Tag)
        {
            case DemoModule3.Quantity.Tags.Discrete:
                Console.WriteLine("Discrete value: {0}", (q as DemoModule3.Quantity.Discrete).Item);
                break;
            case DemoModule3.Quantity.Tags.Continuous:
                Console.WriteLine("Continuous value: {0}", (q as DemoModule3.Quantity.Continuous).Item);
                break;
        }
    }
}
