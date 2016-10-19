#if INTERACTIVE
#else
module ArrayParallel
#endif

open System.IO
open System.Security.Cryptography

// Calculate the MD5 hash of many
// files in parallel:
let Hashes path =
    Directory.EnumerateFiles(path)     
    |> Array.ofSeq       
    |> Array.map (fun name ->
        use md5 = MD5.Create()
        use stream = File.OpenRead(name)
        let hash = md5.ComputeHash(stream)
        path, hash)

Hashes @"c:\temp" |> Array.iter (printfn "%A")

// Calculate the MD5 hash of many
// files in parallel - complete 
// with threading bug!
//
// (Inner Exception #4) System.Security.Cryptography.CryptographicException: Hash not valid for use in specified state.
//
let HashesBad path =
    use md5 = MD5.Create()
    Directory.EnumerateFiles(path)
    |> Array.ofSeq
    |> Array.Parallel.map (fun name ->
        use stream = File.OpenRead(name)
        let hash = md5.ComputeHash(stream)
        path, hash)

HashesBad @"c:\temp" |> Array.iter (printfn "%A")
