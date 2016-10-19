#if INTERACTIVE
#else
module StaticMethods
#endif

// A very crude hasher - don't
// use this method in real code!
let hash (s : string) = 
    s.GetHashCode()

// Pretend to get a user from a database:
let getUserFromDB id =
    ((sprintf "someusername%i" id), 1234)

// A class that represents a user
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

    // A static member that provides an alternative way
    // of creating the object:     
    static member FromDB id =
        let name, ph = getUserFromDB id
        new User(name, ph)

// Create a user using the primary constructor:
let user1 = User("kiteason", 1234)
// Create a user using a static method:
let user2 = User.FromDB 999

// A re-implementation of integers which supports a + operator:
type MyInt(state:int) =
    member x.State = state
    static member ( + ) (x:MyInt, y:MyInt) : MyInt = new MyInt(x.State + y.State)
    override x.ToString() = string state

let x = new MyInt(1)
let y = new MyInt(1)

printfn "(x + y) = %A" (x + y)
