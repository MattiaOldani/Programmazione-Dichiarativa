// Funzione @ applicabile a qualunque lista, a prescindere al contenuto
// Operazione strutturale, non sui valori della lista
// Un tipo polimorfo è un tipo parametrico su "variabili" di tipo type variable

// Funzione identità
let id x = x

// Funzione swap
let swap = fun (x,y) -> (y,x) 

// Funzione first
let first = fun (x,y) -> x

// Funzione append
let rec append xs ys =
    match xs with
    | [] -> ys
    | z::zs -> z :: append zs ys

// Si può definire un polimorfismo con vincoli, utilizzando i type constraints