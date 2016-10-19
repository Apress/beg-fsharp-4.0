module Shortener

open System
open System.Collections.Concurrent

// Initialize a .NET random number generator:
let private random = Random()

// Generate a random string of lower-case letters
// of a specified length.  WARNING: this has the
// potential to generate rude words!
let private randomString len =
   Array.init len (fun _ -> random.Next(26) + 97 |> char)
   |> String

// A dictionary of mappings from the long to the shortened URLs:
let private longToShort = ConcurrentDictionary<string, string>()
// A dictionary of mappings from the shortened to the long URLs:
let private shortToLong = ConcurrentDictionary<string, string>()

// Shorten a URL, and as a side-effect store the short->long
// and long->short mappings:
let Shorten (long : string) =
   longToShort.GetOrAdd(long, fun _ ->
      let short = randomString 5
      shortToLong.[short] <- long
      short)

// Try to resolve a shortened URL to the long version:
let TryResolve (short : string) =
   match shortToLong.TryGetValue short with
   | true, long -> Some long
   | false, _-> None
