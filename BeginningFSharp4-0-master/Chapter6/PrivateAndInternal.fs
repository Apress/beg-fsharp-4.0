#if INTERACTIVE
#else
module PrivateAndInternal
#endif

// This is only visible in the current module:
let private aPrivateBinding = "Keep this private"

// This is only visible in the current assembly:
let internal aInternalBinding = "Keep this internal"

// This DU is only visible in the current assembly:
type internal MyUnion =
    | String of string
    | TwoStrings of string * string

type Thing() =
    // This member is only visible in the current module:
    member private x.PrivateThing() =
        ()
    // This member is only visible in the current assembly:
    member x.ExternalThing() =
        ()
