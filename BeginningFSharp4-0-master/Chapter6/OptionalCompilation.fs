#if COMPILED
module ConditionalCompilation
#else
#r "System.Windows.Forms"
#endif

open System.Windows.Forms

// Define a form:
let form = new Form()

// Do something different depending if we're running
// as a compiled program, versus as a script:
#if COMPILED
Application.Run form
#else
form.Show()
#endif
