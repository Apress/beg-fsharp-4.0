module Strangelights.DemoModule
open System

// Returns the hour and minute from the given date as a tuple:
let hourAndMinute (time: DateTime) = time.Hour, time.Minute

// Returns the hour from the given date:
let hour (time: DateTime) = time.Hour
// Returns the minutes from the given date:
let minute (time: DateTime) = time.Minute
