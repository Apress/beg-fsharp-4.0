using System;
using Strangelights;

static class GetQuantityZeroClass
{
    public static void GetQuantityZero()
    {
        // initialize both a Discrete and Continuous quantity
        DemoModule3.Quantity d = DemoModule3.Quantity.NewDiscrete(12);
        DemoModule3.Quantity c = DemoModule3.Quantity.NewContinuous(12.0);
    }
}
