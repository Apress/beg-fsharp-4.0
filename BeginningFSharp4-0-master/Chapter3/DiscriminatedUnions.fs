#if INTERACTIVE
#else
module DiscriminatedUnions
#endif

// A discriminated union (DU) to represent various measures of volume:
type Volume =
    | Liter of float
    | UsPint of float
    | ImperialPint of float

// Create instances of each type of volume:
let vol1 = Liter 2.5
let vol2 = UsPint 2.5
let vol3 = ImperialPint (2.5)

// A DU using varying numbers of fields, and field labels
type Shape =
| Square of side:float
| Rectangle of width:float * height:float
| Circle of radius:float

// Create an instance of a union type without using the field label:
let sq = Square 1.2
// Create an instance of a union type using the field label:
let sq2 = Square(side=1.2)
// Create an instance of a union type using multiple field labels
// and assigning the fields out-of-order:
let rect3 = Rectangle(height=3.4, width=1.2)

// Some functions to convert between volumes, using pattern matching:
let convertVolumeToLiter x =
    match x with
    | Liter x -> x
    | UsPint x -> x * 0.473
    | ImperialPint x -> x * 0.568
let convertVolumeUsPint x =
    match x with
    | Liter x -> x * 2.113
    | UsPint x -> x
    | ImperialPint x -> x * 1.201
let convertVolumeImperialPint x =
    match x with
    | Liter x -> x * 1.760
    | UsPint x -> x * 0.833
    | ImperialPint x -> x

// Function to print a volume in each of its representations:
let printVolumes x =
    printfn "Volume in liters = %f, in US pints = %f, in Imperial pints = %f"
        (convertVolumeToLiter x)
        (convertVolumeUsPint x)
        (convertVolumeImperialPint x)
        
// Print the results:
printVolumes vol1
printVolumes vol2
printVolumes vol3

// Define a binary tree using 'before the type name' syntax:
type 'a BinaryTree =
| BinaryNode of 'a BinaryTree * 'a BinaryTree
| BinaryValue of 'a

// Create an instance of the binary tree:
let tree1 =
    BinaryNode(
        BinaryNode ( BinaryValue 1, BinaryValue 2),
        BinaryNode ( BinaryValue 3, BinaryValue 4) )

// Define a tree using angle bracket syntax:
type Tree<'a> =
    | Node of Tree<'a> list
    | Value of 'a

// Create an instance of a tree:
let tree2 =
    Node( [ Node( [Value "one"; Value "two"] ) ;
        Node( [Value "three"; Value "four"] ) ] )

// Function to print the binary tree:
let rec printBinaryTreeValues x =
    match x with
    | BinaryNode (node1, node2) ->
        printBinaryTreeValues node1
        printBinaryTreeValues node2
    | BinaryValue x -> 
        printf "%A, " x

// Function to print the tree:
let rec printTreeValues x =
    match x with
    | Node l -> List.iter printTreeValues l
    | Value x ->
        printf "%A, " x
        
// Print the results:
printBinaryTreeValues tree1
printfn ""
printTreeValues tree2
