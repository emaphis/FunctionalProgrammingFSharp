// Intro to Active Patterns

let (| FileExtension|) (s: string) =
    let ext = System.IO.Path.GetExtension  s
    ext

let x = "MyFile.xlsx"
let (FileExtension ext) = x
printfn $"Extension: {ext}"

let files =
    [
        "MyFile.xlsx"
        "MyFile.txt"
        "MyFile.csv"
        "MyFile.tab"
        "MyFile.mmm"
        "MyFile.pgr"
        "MyFile.xlsx"
    ]

for file in files do
    let ext = System.IO.Path.GetExtension file
    printfn $"Ext: {ext}"

for FileExtension ext in files do
    printfn $"Ext: {ext}"

// Using KeyValue active pattern

open System.Collections.Generic

let myDictionary = Dictionary [
    KeyValuePair (1, "A")
    KeyValuePair (2, "b")
]

for x in myDictionary do
    printfn $"Key: {x.Key} Value: {x.Value}"

for KeyValue (key, value) in myDictionary do
    printfn $"Key: {key} Value: {value}"


let (|Even|Odd|) (v: int) =
    if v % 2 = 0 then
        Even
    else
        Odd

let myFunction (v: int) =
    match v with
    | Even  -> printfn "Is Even"
    | Odd   -> printfn "Is Odd"

myFunction 2
myFunction 3


let (|Email|Phone|Pager|Other|) (contact: string) =
    if contact.Contains "@" then
        Email
    elif contact.Contains "-" then
        Phone
    elif contact.Contains "Pager:" then
        Pager
    else
        Other

let myContactHandler (c: string) =
    match c with
    | Email -> printfn "It's an email"
    | Phone -> printfn "It's a phone number"
    | Pager -> printfn "It's a pager"
    | Other -> printfn "Other contact"

myContactHandler "Pager:compmite.com"
myContactHandler "alpha@alpha.com"
myContactHandler "1-800-555-5555"
myContactHandler "Jimmy Smith"


// Partial active pattern
let (|IsEven|_|) (v: int) =
    if v % 2 = 0 then
        Some v
    else
        None

let (|IsOdd|_|) (v: int) =
    if v % 2 = 0 then
        Some v
    else
        None        

let myPartialActivePatternFunc (v: int) =
    match v with
    | IsEven evenValue -> printfn $"Is Even{evenValue}"
    | IsOdd oddValue -> printfn $"Is Odd{oddValue}"
    | _  -> printfn "Unkown"        

