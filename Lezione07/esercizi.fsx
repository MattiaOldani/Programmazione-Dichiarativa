// Funzione 'a -> seq<'a> -> seq<'a> che esegue il cons
let cons el sq = seq {
    yield el
    yield! sq
}

// Funzione seq<'a> -> seq<'a> -> seq<'a> che esegue l'append
let append sq1 sq2 = seq {
    yield! sq1
    yield! sq2
}

// Funzione seq<'a> -> 'a che esegue la head
let head sq = Seq.item 0 sq

// Funzione seq<'a> -> seq<'a> che esegue la tail
let tail sq = Seq.skip 1 sq

// Insieme dei naturali
let nat1 = Seq.initInfinite id

// Insieme dei naturali senza 5
let nat2 = Seq.initInfinite (fun x -> if x < 5 then x else x + 1)

// Insieme dei naturali con -5 al posto di 5
// Provo ribrezzo a mettere -5 nei naturali
let nat3 = Seq.initInfinite (fun x -> if x <> 5 then x else -x)

// Insieme dei numeri pari maggiori o uguali a 10
let even10 = Seq.initInfinite (fun x -> 10 + 2 * x)

// Insieme che contiene solo 'true'
let sqTrue = Seq.initInfinite (fun x -> true)

// Insieme che contiene 'true' e 'false' alternati
let sqTrueFalse = Seq.initInfinite (fun x -> x % 2 = 0)

// Funzione int -> seq<int> che crea una sequenza con i numeri maggiori o uguali a n
let rec intFrom n = Seq.initInfinite (fun x -> n + x)

// Usando intFrom, definire i numeri naturali
let nat4 = intFrom 0

// Usando intFrom, definire i numeri interi maggiori o uguali a -10
let int10 = intFrom -10

// Da int10 estrarre la sequenza dei valori tra -4 e 4
let range = int10 |> Seq.skip 6 |> Seq.take 9 |> Seq.toList

// Funzione ('a -> 'b) -> seq<'a> -> seq<'b> che crea una nuova sequenza mappando ogni valore della prima sequenza
let rec map f sq = seq {
    yield f (Seq.head sq)
    yield! map f (Seq.skip 1 sq)
}

// Insieme dei quadrati dei numeri naturali
let square = map (fun x -> x * x) nat1

// Funzione ('a -> bool) -> seq<'a> -> seq<'a> che crea la sequenza degli elementi che verificano il predicato
let rec filter f sq = seq [
    if f (Seq.head sq) then yield Seq.head sq
    yield! filter f (Seq.skip 1 sq) 
]

// Insieme dei naturali multipli di 3
let mul3 = filter (fun x -> x % 3 = 0) nat1

// Funzione seq<int> -> seq<int> che calcola, nella posizione i, la somma dei valori fino all'indice i
let rec sumSeq sq = seq {
    let (head : int) = Seq.head sq
    yield head
    let suc = Seq.item 1 sq
    let nseq = Seq.append (seq {head + suc}) (Seq.skip 2 sq)
    yield! sumSeq nseq
}