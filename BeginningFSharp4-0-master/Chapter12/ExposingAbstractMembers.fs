namespace Strangelights

type IDemoInterface =
    // Method in the curried style:
    abstract CurriedStyle: int -> int -> int
    // Method in the C# style:
    abstract CSharpStyle: int * int -> int
    // Method in the C# style with named arguments:
    abstract CSharpNamedStyle: x : int * y : int -> int
    // Method in the tupled style:
    abstract TupleStyle: (int * int) -> int
