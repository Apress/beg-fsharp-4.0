#if INTERACTIVE
#else
module Interfaces
#endif

// An interface "IUser":
type IUser =
    // Hashes the user's password and checks it against
    // the known hash:
    abstract Authenticate: evidence: string -> bool
    // Gets the users logon message:
    abstract LogonMessage: unit -> string

// A very crude hasher - don't
// use this method in real code!
let hash (s : string) = 
    s.GetHashCode()

// A User class which implements IUser:
type User(name, passwordHash) =
    interface IUser with

        // Authenticate implementation:
        member x.Authenticate(password) =
            let hashResult = hash (password)
            passwordHash = hashResult

        // LogonMessage implementation:
        member x.LogonMessage() =
            Printf.sprintf "Hello, %s" name

// Create a new instance of the user
// 281887125 is the hash of "mypassword":
let user = User("Robert", 281887125)

// Get the logon message by casting to IUser then calling LogonMessage:
let logonMessage = (user :> IUser).LogonMessage()

// Function to demonstrate logging on via IUser:
let logon (user: IUser) (password : string) =
    // Authenticate user and print appropriate message:
    if user.Authenticate(password) then
        printfn "%s" (user.LogonMessage())
    else
        printfn "Logon failed"  

// A successful logon attempt:
do logon (user:>IUser) "mypassword"

// An unsuccessful logon attempt:
do logon (user:>IUser) "guess"

// A version of User which doesn't require callers to cast
// the User instance to the interface, to use the interface
// members:
type User2(name, passwordHash) =
    interface IUser with

        // Authenticate implementation:
        member x.Authenticate(password) =
            let hashResult = hash (password)
            passwordHash = hashResult

        // LogonMessage implementation:
        member x.LogonMessage() =
            Printf.sprintf "Hello, %s" name
    // Expose Authenticate implementation:
    member x.Authenticate(password) = x.Authenticate(password)
    // Expose LogonMessage implementation:
    member x.LogonMessage() = x.LogonMessage()
