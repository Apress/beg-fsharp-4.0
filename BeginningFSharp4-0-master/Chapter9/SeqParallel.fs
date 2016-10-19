#if INTERACTIVE
// You may have to adjust this path for the version which Nuget downloads:
#r @"../packages/FSharp.Collections.ParallelSeq.1.0.2/lib/net40/FSharp.Collections.ParallelSeq.dll"
#else
module SeqParallel
#endif

open System.IO
open System.Security.Cryptography
open FSharp.Collections.ParallelSeq

// Calculate the MD5 hash of many
// files in parallel, using the
// ParallelSeq module:
let Hashes path =
    Directory.EnumerateFiles(path)
    |> PSeq.map (fun name ->
        use md5 = MD5.Create()
        use stream = File.OpenRead(name)
        let hash = md5.ComputeHash(stream)
        path, hash)

Hashes @"c:\temp" |> Seq.iter (printfn "%A")
