// Costrutti che aggregano più oggetti diversi
// Gli elementi di una tupla vanno separati dalle virgole, che sono i costruttori

// Funzione int * int -> int che calcola la somma degli elementi di una tupla di 2 interi
let somma1 (x,y) = x + y 

// Funzione int -> int -> int che calcola la somma di due interi
let somma2 x y = x + y

// Dal punto di vista delle valutazioni, le due funzioni di somma sono identiche
// Dal punto di vista dei tipi sono totalmente diverse

// Per accedere agli elementi di una tupla si usa il patern matching
let triple = (1,2,3)
let (x,y,z) = triple

// Altri modi per fare pattern matching
let square = fun x -> (string x, x * x)
let s = square 5

let first = 
    match s with
    | (a,b) -> a

let second =
    match s with
    | (_,b) -> b

let other =
    let (a,b) = s
    a

let otherOther =
    let (_,b) = s
    b