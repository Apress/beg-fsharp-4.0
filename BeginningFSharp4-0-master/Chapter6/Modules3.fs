namespace Modules3

// A module of operators:
module MyOps =
    // Check equality via hash code:
    let (===) x y =
        x.GetHashCode() =
          y.GetHashCode()

module AnotherModule = 

    // Open the MyOps module:
    open MyOps

    // Use the triple equal operator:
    let equal = 1 === 1
    let nEqual = 1 === 2
