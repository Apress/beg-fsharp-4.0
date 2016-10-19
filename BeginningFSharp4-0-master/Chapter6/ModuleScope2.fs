// Move this module above ModuleScope1.fs in the compilation order
// (e.g. Solution Explorer -> Right Click -> Move Up) to see
// an error:

module ModuleTwo

// Print out the text defined in ModuleOne:
printfn "ModuleOne.text: %s" ModuleOne.text
