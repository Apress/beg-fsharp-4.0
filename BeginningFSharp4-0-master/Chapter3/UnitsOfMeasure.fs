#if INTERACTIVE
#else
module UnitsOfMeasure
#endif

// A unit of measure for meters:
[<Measure>]type m
// A distance in meters:
let meters = 1.0<m>

// Units of measure for volume:
[<Measure>]type liter
[<Measure>]type pint

// Some volumes:
let vol1 = 2.5<liter>
let vol2 = 2.5<pint>

// Uncomment the following line to see an error;
// you can't add different units of measure:
// let newVol = vol1 + vol2

// Define the ratio of pints to liters:
let ratio =  1.0<liter> / 1.76056338<pint> 

// A function to convert pints to liters:
let convertPintToLiter pints =
    pints * ratio

// Perform the conversion and add the values:
let newVol = vol1 + (convertPintToLiter vol2)

// Using a format placeholder with a unit-of-measure value (>= F# 4.0)
printfn "The volume is %f" vol1 
