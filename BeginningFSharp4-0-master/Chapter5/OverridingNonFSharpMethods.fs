#if INTERACTIVE
#else
module OverridingNonFSharpMembers
#endif

// Overrides of non-F# members must be tupled:
type CredentialsFactory() =
    interface System.Net.ICredentials with
        member x.GetCredential(uri, authType) =
            new System.Net.NetworkCredential("rob", "whatever", "F# credentials")
    member x.GetCredentialList uri authTypes =
        let y = (x :> System.Net.ICredentials)
        let getCredential s = y.GetCredential(uri, s)
        List.map getCredential authTypes
