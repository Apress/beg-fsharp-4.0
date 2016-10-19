#if INTERACTIVE
#else
module Casting
#endif

// Upcast a string to an object:
let myObject = ("This is a string" :> obj)

open System.Windows.Forms

// Upcast some Windows controls to Control
// so that they can go into the same collection:
let myControls =
    [| (new Button() :> Control);
       (new TextBox() :> Control);
       (new Label() :> Control) |]

// Upcast a value type, causing it to be placed
// on the heap:
let boxedInt = (1 :> obj)

// Make another array of controls upcast to Control:
let moreControls =
    [| (new Button() :> Control);
       (new TextBox() :> Control) |]

// Pick one of the controls access a property which
// all controls have in common, and return it as
// a control:
let control =
    let temp = moreControls.[0]
    temp.Text <- "Click Me!"
    temp

// Cast the control to its 'real' type (Button) and
// access a property that is specific to buttons,
// and return it as a Button:
let button =
    let temp = (control :?> Button)
    temp.AutoEllipsis <- true
    temp

