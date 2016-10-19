#if INTERACTIVE
#else
module AbstractClasses
#endif

// A abstract class that represents a user
// its constructor takes one parameter,
// the user's name:
[<AbstractClass>]
type User(name) =
    // The implementation of this method should hash the
    // user's password and checks it against the known hash
    abstract Authenticate: evidence: string -> bool

    // Gets the users logon message
    member x.LogonMessage() =
        Printf.sprintf "Hello, %s" name
