#if INTERACTIVE
#else
module Events
#endif

// Create an event, publish and trigger it:
let event = new Event<string>()
event.Publish.Add(fun x -> printfn "%s" x)
event.Trigger "hello"

// Create an event which only triggers when
// the string starts with "H":
let newEvent = event.Publish |> Event.filter (fun x -> x.StartsWith("H"))

newEvent.Add(fun x -> printfn "new event: %s" x)

event.Trigger "Harry"
event.Trigger "Jane"
event.Trigger "Hillary"
event.Trigger "John"
event.Trigger "Henry"

// Listen to the original event, and trigger one of two different new events
// depending on the results of a function:
let hData, nonHData = event.Publish |> Event.partition (fun x -> x.StartsWith "H") 

hData.Add(fun x -> printfn "H data: %s" x)
nonHData.Add(fun x -> printfn "None H data: %s" x)

event.Trigger "Harry"
event.Trigger "Jane"
event.Trigger "Hillary"
event.Trigger "John"
event.Trigger "Henry"

// Map the incoming data before passing to another event:
let newEvent2 = event.Publish |> Event.map (fun x -> "Mapped data: " + x)
newEvent2.Add(fun x -> printfn "%s" x)

event.Trigger "Harry"
event.Trigger "Sally"
