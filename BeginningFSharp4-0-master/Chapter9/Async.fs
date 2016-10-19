#if INTERACTIVE
#r @"../packages/FSPowerPack.Core.Community.3.0.0.0/Lib/Net40/FSharp.PowerPack.dll"
#else
module Async
#endif

open System.IO

// A function to read a text file asynchronously:
let readFile file =
    async { let! stream = File.AsyncOpenText(file)
            let! fileContents = stream.AsyncReadToEnd()
            return fileContents }

// Create an instance of the workflow:
let readFileWorkflow = readFile @"C:\Data\Gutenberg\TomJones\TomJones.txt"

// Invoke the workflow and get the contents:
let fileContents = Async.RunSynchronously readFileWorkflow
