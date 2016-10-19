#if INTERACTIVE
#else
module PInvokeMessageBeep
#endif

open System.Runtime.InteropServices

// Declare a function found in an external dll:
[<DllImport("User32.dll")>]
extern bool MessageBeep(uint32 beepType)

// Call this method ignoring the result:
MessageBeep(0ul) |> ignore
