#if INTERACTIVE
#else
module BitwiseOrAndAndOperators
#endif

open System.Windows.Forms

// Bitwise OR two AnchorStyles:
let anchor = AnchorStyles.Left ||| AnchorStyles.Top

// Bitwise and two anchor styles:
printfn "test AnchorStyles.Left: %b"
    (anchor &&& AnchorStyles.Left <> enum 0)
printfn "test AnchorStyles.Right: %b"
    (anchor &&& AnchorStyles.Right <> enum 0)
