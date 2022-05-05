// Oggetti built-in costruite in maniera induttiva
// Eager evaluation -> valutazione durante la costruzione

// Lista vuota
let a = []

// Aggiunta in testa di un elemento con "cons"
let b = 2 :: []

// Dichiarazione di una lista con cons "impliciti"
// Equivalente a "1 :: 2 :: 3 :: []"
// Separare i valori con ";"
let c = [1; 2; 3]

// Lista dichiarata con range expression
// Simile alla list comprehension di Python
// [inizio .. fine]
let d = [1 .. 10]

// Lista dichiarata con range expression
// [inizio .. passo .. fine]
let e = [10 .. -2 .. 0]

// Pattern matching sulle lista
let f xs =
    match xs with
    | [] -> "Lista vuota"
    | y :: ys -> "Testa: " + string y + ", coda: " + string ys

// Pattern matching ricorsivo
let rec sum xs =
    match xs with
    | [] -> 0
    | y :: ys -> y + (sum ys)

// Operazione di append
// Richiede due list di tipo T
let g = [1 .. 10] @ [11 .. 20]