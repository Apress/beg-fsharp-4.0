#if INTERACTIVE
#else
module Structs
#endif

// A struct representing an IP address:
type IpAddress = struct
    val first : byte
    val second : byte
    val third : byte
    val fourth : byte
    new(first, second, third, fourth) =
        { first = first;
          second = second;
          third = third;
          fourth = fourth }
    override x.ToString() =
        Printf.sprintf "%O.%O.%O.%O" x.first x.second x.third x.fourth
    member x.GetBytes() = x.first, x.second, x.third, x.fourth
end
