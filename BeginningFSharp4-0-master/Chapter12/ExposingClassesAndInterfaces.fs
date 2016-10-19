namespace Strangelights

type DemoClass(z: int) =
    // Method in the curried style:
    member this.CurriedStyle x y = x + y + z
    // Method in the tuple style:
    member this.TupleStyle (x, y) = x + y + z
