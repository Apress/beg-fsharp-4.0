namespace SignatureFiles

module Functions =

    // Define a function to be exposed:
    let funkyFunction x =
        x + ": keep it funky!"
    
    // Define a function that will be hidden:
    let notSoFunkyFunction x = x + 1
