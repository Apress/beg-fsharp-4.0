namespace Modules4

// Give an alias to the Array3 module:
module ArrayThreeD = Microsoft.FSharp.Collections.Array3D

module AnotherModules = 
    // Create an matrix using the module alias:
    let matrix =
        ArrayThreeD.create 3 3 3 1
