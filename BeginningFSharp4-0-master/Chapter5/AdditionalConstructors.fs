#if INTERACTIVE
#else
module AdditionalConstructors
#endif

   // A version of the User class with a secondary constructor:
   type User(name, passwordHash) =
       // Store the password hash in a mutable let
       // binding, so it can be changed later:
       let mutable passwordHash = passwordHash

       // An additional constructor to create a user given the
       // raw password:
       new(name : string, password : string) =
           User(name, (hash password))

       // Hashes the users password and checks it against
       // the known hash:
       member x.Authenticate(password) =
           let hashResult = hash password
           passwordHash = hashResult

       // Gets the users logon message:
       member x.LogonMessage() =
           Printf.sprintf "Hello, %s" name

       // Changes the users password:
       member x.ChangePassword(password) =
           passwordHash <- hash password
