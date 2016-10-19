#if INTERACTIVE
#else
module Enums
#endif

// An ordinary enum:
type Scale =
| C = 1
| D = 2
| E = 3
| F = 4
| G = 5
| A = 6
| B = 7

// An enum for use for flags:
[<System.Flags>]
type ChordScale =
| C = 0b0000000000000001
| D = 0b0000000000000010
| E = 0b0000000000000100
| F = 0b0000000000001000
| G = 0b0000000000010000
| A = 0b0000000000100000
| B = 0b0000000001000000
