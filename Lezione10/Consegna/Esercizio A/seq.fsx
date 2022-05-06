// ESERCIZIO A


// Funzione collect
let rec collect (f : 'a -> seq<'b>) sq = seq {
    yield! f (Seq.item 0 sq)
    yield! collect f (Seq.skip 1 sq)
}


// Sequenza sq1
let start1 = Seq.initInfinite id

let f1 n = seq {
    "uno"
    "due"
    "tre"
}

let sq1 = collect f1 start1


// Sequenza sq2
let start2 = Seq.initInfinite id

let f2 n = Seq.ofList [0 .. n]

let sq2 = collect f2 start2


// Lista ls1
let ls1 = Seq.toList (Seq.take 10 sq1)


// Lista ls2
let ls2 = Seq.toList (Seq.take 30 sq2)