// Valutazione di espressioni, non esecuzione di comandi
// Il programmatore dichiara COSA fa il programma

// Funzione int -> int che calcola il quadrato di un intero
let square x = x * x

// Funzione int -> int che calcola il cubo di un intero
// Utilizzo della lambda expression
let cube = fun x -> x * x * x

// Funzione float -> float che calcola il quadrato di un float
// Uso della type annotation per evitare una funzione int -> int
let squareFloat (x : float) = x * x

// Funzione int -> int che calcola il doppio del quadrato di un int
// Uso di identificatori "locali"
let doubleSquare x =
    let y = square x
    2 * y

// Funzione float -> float che fa robe
// Uso di identificatori "locali" con l'uso di in
let roba x = let y = sin x in let z = cos y in y + z

// Funzione float -> float che calcola l'area di una circonferenza dato il raggio
let circleArea r = System.Math.PI * squareFloat r

// Funzione int -> int -> int che calcola la somma di due numeri interi
// Uso della lambda expression annidata per definire con 2+ parametri
// Formulazione analoga a "fun x y -> x + y"
let sum = fun x -> fun y -> x + y

// Funzione int -> int -> int che calcola la differenza di due numeri interi
// Altro modo di definire funzioni con 2+ parametri
let dif x y = x - y