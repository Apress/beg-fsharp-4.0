#if INTERACTIVE
#else
module PInvokeFileEncryptionStatus
#endif

open System.Runtime.InteropServices

// Declare a function found in an external dll:
[<DllImport("Advapi32.dll")>]
extern bool FileEncryptionStatus(string filename, uint32* status)

let main() =
    // Declare a mutable idenifier to be passed to the function:
    let mutable status = 0ul
    // Call the function, using the address of operator with the
    // second parameter:
    FileEncryptionStatus(__SOURCE_DIRECTORY__ + @"Book1.xls", && status) |> ignore
    // Print the status to check it has be altered:
    printfn "%d" status

main()


