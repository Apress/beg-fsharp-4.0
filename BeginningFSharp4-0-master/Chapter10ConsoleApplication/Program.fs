open System
open System.Collections.Concurrent
open Suave
open Suave.Http
open Suave.Web
open Suave.Filters
open Suave.Operators

// Initialize a .NET random number generator:
let random = Random()

// Generate a random string of lower-case letters
// of a specified length.  WARNING: this has the
// potential to generate rude words!
let randomString len =
   Array.init len (fun _ -> random.Next(26) + 97 |> char)
   |> String

// A dictionary of mappings from the long to the shortened URLs:
let longToShort = ConcurrentDictionary<string, string>()
// A dictionary of mappings from the shortened to the long URLs:
let shortToLong = ConcurrentDictionary<string, string>()

// Shorten a URL, and as a side-effect store the short->long
// and long->short mappings:
let shorten (long : string) =
   longToShort.GetOrAdd(long, fun _ ->
      let short = randomString 5
      shortToLong.[short] <- long
      short)

// Try resolve a shortened URL to the long version:
let tryResolve (short : string) =
   match shortToLong.TryGetValue short with
   | true, long -> Some long
   | false, _-> None

// Create a Suave app which can add and resolve URLs:
let app =
   choose
      [ 
         POST >=> choose
            [ path "/add" >=> request (fun req -> 
               match (req.formData "url") with
               | Choice1Of2 long -> 
                  let short = shorten long
                  // You may need to amend the port number:
                  let url = sprintf "localhost:8083/go/%s" short
                  Successful.CREATED url
               | _ ->
                  RequestErrors.BAD_REQUEST "Url not supplied") 
            ]
         GET >=> choose
            [ pathScan "/go/%s" (fun short -> 
               match tryResolve short with
               | Some long ->
                  Redirection.MOVED_PERMANENTLY (sprintf "http://%s" long)
               | None ->
                  RequestErrors.NOT_FOUND "Url not found")
            ]
      ]

[<EntryPoint>]
let main args =
   // Start the service:
   startWebServer defaultConfig app
   0
