#if INTERACTIVE
#else
module PropertiesAndIndexers
#endif

// A class with properties:
type Properties() =
    let mutable rand = new System.Random()
    // A property definition:
    member x.MyProp
        with get () = rand.Next()
        and set y = rand <- new System.Random(y)

// Create a new instance of the class:
let prop = new Properties()

// Run some tests for the class:
prop.MyProp <- 12
printfn "%d" prop.MyProp
printfn "%d" prop.MyProp
printfn "%d" prop.MyProp

// An interface with an abstract property:
type IAbstractProperties =
    abstract MyProp: int
        with get, set

// A class that implements our interface:
type ConcreteProperties() =
    let mutable rand = new System.Random()
    interface IAbstractProperties with
        member x.MyProp
            with get() = rand.Next()
            and set(y) = rand <- new System.Random(y)

// A class with indexers:
type Indexers(vals:string[]) =
    // A normal indexer:
    member x.Item
        with get y = vals.[y]
        and set y z = vals.[y] <- z
    // An indexer with an unusual name:
    member x.MyString
        with get y = vals.[y]
        and set y z = vals.[y] <- z

// Create a new instance of the indexer class:
let index = new Indexers [|"One"; "Two"; "Three"; "Four"|]

// Test the set indexers:
index.[0] <- "Five";
index.Item(2) <- "Six";
index.MyString(3) <- "Seven";

// Test the get indexers:
printfn "%s" index.[0]
printfn "%s" (index.Item(1))
printfn "%s" (index.MyString(2))
printfn "%s" (index.MyString(3))
