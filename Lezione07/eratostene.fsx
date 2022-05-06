// Funzione int -> seq<int> -> seq<int> che, dato un intero n, rimuove tutti i multipli di n
let rec sift n sq = Seq.filter (fun x -> x % n <> 0) sq

// Funzione seq<int> -> seq<int> che esegue il crivello di Eratostene
let rec sieve sq = seq {
    let head = Seq.head sq
    yield head
    yield! sieve (sift head sq)
}

// Funzione sift ma con il caching
let siftC n sq = Seq.cache (sift n sq)

// Funzione sieve ma con il caching
let rec sieveC sq = seq {
    let head = Seq.head sq
    yield head
    yield! sieveC (siftC head sq)
}