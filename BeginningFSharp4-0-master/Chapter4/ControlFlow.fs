#if INTERACTIVE
#else
module ControlFlow
#endif

// An 'if' expression with one branch - imperative style:
if System.DateTime.Now.DayOfWeek = System.DayOfWeek.Sunday then
    printfn "Sunday Playlist: Lazy On A Sunday Afternoon - Queen"

// An 'if' expression with two branches - imperative style:
if System.DateTime.Now.DayOfWeek = System.DayOfWeek.Monday then
        printfn "Monday Playlist: Blue Monday - New Order"
    else
        printfn "Alt Playlist: Fell In Love With A Girl - White Stripes"

// Scope of an if statement is determined by indenting:
if System.DateTime.Now.DayOfWeek = System.DayOfWeek.Tuesday then
    printfn "Tuesday Playlist: Ruby Tuesday - Rolling Stones"
printfn "Everyday Playlist: Eight Days A Week - Beatles"

if System.DateTime.Now.DayOfWeek = System.DayOfWeek.Friday then
    printfn "Friday Playlist: Friday I'm In Love - The Cure"
    printfn "Friday Playlist: View From The Afternoon - Arctic Monkeys"

// An array for words:
let words = [| "Red"; "Lorry"; "Yellow"; "Lorry" |]

// Use a for loop to print each element:
for word in words do
    printfn "%s" word

// A Ryunosuke Akutagawa haiku array:
let ryunosukeAkutagawa = [| "Green "; "frog,";
    "Is"; "your"; "body"; "also";
    "freshly"; "painted?" |]

// A for loop over the array printing each element
// using indexed access to the array:
for index = 0 to Array.length ryunosukeAkutagawa - 1 do
    printf "%s " ryunosukeAkutagawa.[index]

// A Shuson Kato hiaku array (backwards)
let shusonKato = [| "watching."; "been"; "have";
    "children"; "three"; "my"; "realize"; "and";
    "ant"; "an"; "kill"; "I";
    |]

// Loop over the array backwards printing each word
for index = Array.length shusonKato - 1 downto 0 do
    printf "%s " shusonKato.[index]

// For loops using range notation:

// Count upwards:
for i in 0..10 do
    printfn "%i green bottles" i
// Count downwards:
for i in 10..-1..0 do
    printfn "%i green bottles" i
// Count upwards in tens
for i in 0..10..100 do
    printfn "%i green bottles" i

// A Matsuo Basho hiaku in a mutable list
let mutable matsuoBasho = [ "An"; "old"; "pond!";
    "A"; "frog"; "jumps"; "in-";
    "The"; "sound"; "of"; "water" ]

// A while loop:
while (List.length matsuoBasho > 0) do
    printf "%s " (List.head matsuoBasho)
    matsuoBasho <- List.tail matsuoBasho

