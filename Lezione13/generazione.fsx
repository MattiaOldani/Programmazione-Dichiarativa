// Il testing con FsCheck può essere difficile per via della distribuzione non ottimale dei test case

#r "FsCheck"
open FsCheck

let rec insert el lst =
    match lst with
    | [] -> [el]
    | x::xs when el <= x -> el :: lst
    | x::xs -> x :: (insert el xs)

let rec ordered lst =
    match lst with
    | [] -> true
    | [x] -> true
    | x::y::ys -> if x <= y then ordered ys else false

let prop_insert (x : int) (lst : int list) =
    ordered lst ==> ordered (insert x lst)

// I test case verranno esauriti dopo un certo numero di casi

// Andiamo a creare noi un generatore per poter testare la nostra proprietà

// Generatore di booleani
let trueGen = gen {return true}
let falseGen = gen {return false}

let boolGen = Gen.oneof [trueGen; falseGen]
let anotherBoolGen = Arb.generate<bool>

let test = Gen.sample 1 15 boolGen

// Generatore di liste di interi
let orderedGen = Arb.mapFilter List.sort (fun x -> true) Arb.from<int list>

let prop_insert_ord x =
    Prop.forAll orderedGen (fun lst -> ordered (insert x lst))

// Bene, ma possiamo migliorare la distribuzione

// Generatore di liste di interi con bias

// Da questo momento in poi ho avuto un blackout al cervello
let moreTrueBoolGen = Gen.frequency [
    (4, trueGen);
    (1, falseGen)
]

let test2 = Gen.sample 1 15 moreTrueBoolGen