#if INTERACTIVE
#else
module Classes
#endif

// A very crude hasher - don't
// use this method in real code!:
let hash (s : string) = 
    s.GetHashCode()

// A class that represents a user;
// its constructor takes two parameters, the user's
// name and a hash of their password:
type User(name, passwordHash) =
    // Hashes the users password and checks it against
    // the known hash:
    member x.Authenticate(password) =
        let hashResult = hash password
        passwordHash = hashResult

    // Gets the users logon message:
    member x.LogonMessage() =
        sprintf "Hello, %s" name

// Create a user using the primary constructor:
let user1 = User("kiteason", 1234)
// Access a method of the User instance:
printfn "*** %s" (user1.LogonMessage())

// A class that represents a user;
// its constructor takes three parameters, the user's
// first name, last name and a hash of their password:
type User2(firstName, lastName, passwordHash) =
    // Calculate the user's full name and store of later use:
    let fullName = Printf.sprintf "%s %s" firstName lastName
    // Print users fullname as object is being constructed:   
    do printfn "User: %s" fullName
    
    // Hashes the users password and checks it against
    // the known hash:
    member x.Authenticate(password) =
        let hashResult = hash password
        passwordHash = hashResult

    // Retrieves the users full name:
    member x.GetFullname() = fullName

// A class that represents a user;
// its constructor takes two parameters, the user's
// name and a hash of their password.
// This version can 'change' the password by
// returning a new instance with the new password:
type User3(name, passwordHash) =
    // Hashes the users password and checks it against
    // the known hash:
    member x.Authenticate(password) =
        let hashResult = hash password
        passwordHash = hashResult

    // Gets the user's logon message:
    member x.LogonMessage() =
        Printf.sprintf "Hello, %s" name

    // Creates a copy of the user with the password changed:
    member x.ChangePassword(password) =
        new User3(name, hash password)

// A class that represents a user;
// its constructor takes two parameters, the user's
// name and a hash of their password.
// This version can change the password
// by updating a mutable field:
type User4(name, passwordHash) =
    // Store the password hash in a mutable let
    // binding, so it can be changed later:
    let mutable passwordHash = passwordHash

    // Hashes the users password and checks it against
    // the known hash:
    member x.Authenticate(password) =
        let hashResult = hash password
        passwordHash = hashResult

    // Gets the users logon message:
    member x.LogonMessage() =
        Printf.sprintf "Hello, %s" name

    // Changes the user's password:
    member x.ChangePassword(password) =
        passwordHash <- hash password
