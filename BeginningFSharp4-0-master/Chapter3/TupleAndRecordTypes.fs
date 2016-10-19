#if INTERACTIVE
#else
module TupleAndRecordTypes
#endif

// Bind a tuple using "," syntax:
let pair = true, false
// Split out the tuple elements using "," syntax:
let b1, b2 = pair
// Ignore an element using "_":
let b3, _ = pair
let _, b4 = pair

// You can declare an 'alias' for a type:
type Name = string
// You can declare an alias for a tuple:
type Fullname = string * string

// ...and use that alias later as a type specifier:
let fullNameToSting (x: Fullname) =
    let first, second = x in
    first + " " + second

// Use Record types for small groups of named fields:

// Define an organization with unique fields:
type Organization1 = { boss: string; lackeys: string list }

// Create an instance of this organization:
let rainbow =
    { boss = "Jeffrey";
      lackeys = ["Zippy"; "George"; "Bungle"] }

// If field names are the same between two record types,
// you can disambiguate by specifing which you mean:

// Define two organizations with overlapping fields:
type Organization2 = { chief: string; underlings: string list }
type Organization3 = { chief: string; reports: string list }

// Create an instance of Organization2:
let (thePlayers: Organization2) = 
    { chief = "Peter Quince"; 
      underlings = ["Francis Flute"; "Robin Starveling";
                    "Tom Snout"; "Snug"; "Nick Bottom"] }

// Create an instance of Organization3:
let (wayneManor: Organization3) = 
    { chief = "Batman"; 
      reports = ["Robin"; "Alfred"] }

// Access a field from a record type:
printfn "wayneManor.chief = %s" wayneManor.chief

// Create a modified instance of a record type:
let wayneManor' = 
    { wayneManor with reports = [ "Alfred" ] }

// Print out the two organizations:
printfn "wayneManor = %A" wayneManor
printfn "wayneManor' = %A" wayneManor'

// Type representing a mixed-gender couple:
type Couple = { him : string ; her : string }

// List of mixed-gender couples (and ex-couples!):
let couples =
    [ { him = "Brad" ; her = "Angelina" };
      { him = "Becks" ; her = "Posh" };
      { him = "Chris" ; her = "Gwyneth" };
      { him = "Michael" ; her = "Catherine" } ]
    
// Function to find "David" (via "Posh")
// from a list of couples, using pattern 
// matching over records:
let rec findDavid l =
    match l with
    | { him = x ; her = "Posh" } :: tail -> x
    | _ :: tail -> findDavid tail
    | [] -> failwith "Couldn't find David"

// Print the results:
printfn "%A" (findDavid couples)

// Function to find couples via the female's
// surname using a when guard:
let rec findPartner soughtHer l =
    match l with
    | { him = x ; her = her } :: tail when her = soughtHer -> x
    | _ :: tail -> findPartner soughtHer tail
    | [] -> failwith "Couldn't find him"

