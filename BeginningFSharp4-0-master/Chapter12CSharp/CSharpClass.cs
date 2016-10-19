using System;

class CSharpClass : Strangelights.IDemoInterface
{
    public int CurriedStyle(int value1, int value2)
    {
        return value1 + value2;
    }

    public int CSharpStyle(int value1, int value2)
    {
        return value1 + value2;
    }

    public int CSharpNamedStyle(int x, int y)
    {
        return x + y;
    }

    public int TupleStyle(Tuple<int, int> value)
    {
        return value.Item1 + value.Item2;
    }
}
