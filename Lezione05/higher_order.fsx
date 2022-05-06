// Dati due tipi T1,T2, si definisce il tipo T1 -> T2
// Le funzioni hanno dominio T1 e codomonio T2
// Il costruttore per costruire tipi funzionali è ->
// Ha priorità più bassa del prodotto cartesiano * ed è associativo a destra

// Le funzioni che hanno come argomenti altre funzioni sono dette di ordine superiore

// Una espressione funzionale è una espressione avente tipo funzionale
// Possibile anche non dare un nome all'espressione funzionale
let f x = x + 1
(fun x -> x + 1) 10

// L'applicazione di una funzione f : T1 -> T2 ad un termine t : T1 si denota con "f t"
// Il risultato ha tipo T2

// Le funzioni hanno un solo argomento
// Non occorre scrivere l'argomento tra parentesi
// Se ci sono tipi polimorfi, la funzione è applicabile?
// Si, se il tipo del dominio può essere instanziato in modo da essere uguale a quello dell'argomento

// Un ambiente è una mappa che associa ad ogni identificatore un valore
// Un ambiente è una lista di legami (binding) della forma x --> vx
// Quando avviene la valutazione di una funzione, si crea un nuovo ambiente
// Il valore del parametro della funzione viene legato temporaneamente all'identificatore usato nella funzione
// Eager evaluation -> prima si valuta l'argomento, poi lo si passa alla funzione

// Le funzioni a più variabili sono in realtà funzioni annidate
// fun x -> expr, con expr funzione y -> expr
let g = fun x -> (fun y -> x + y)

// Facendo "g 5" avremo come risultato una funzione "fun y -> 5 + y"

// L'applicazione di funzione è associativa a sinistra

// Quando viene applicata una funzione istanziando solo il primo parametro si parla di applicazione parziale

// Per nominare la funzione di un operatore la si mette tra parentesi tonde
let equals = (=)
let isOne = (=) 1
let isPositive = (<) 0

// Uso della pipe |> per scrivere l'argomento di una funzione prima della funzione stessa
// |> : 'a -> ('a -> 'b) -> 'b
let squareHead lst = lst |> List.rev |> List.tail |> List.head |> (fun x -> x * x)

// Composizione di funzioni tramite l'operatore >> o <<
// "(f1 << f2) x" si può riscrivere come "f2 (f1 x)"
// In generale, la composizione non è commutativa
let f1 = fun x -> x + 1
let f2 = fun x -> x * x
let g1 = f1 >> f2
let g2 = f2 >> f1

// Esempi di funzioni higher-order
let map = List.map (fun x -> x * x) [0 .. 10]
let filter = List.filter (fun x -> x % 2 = 0) [0 .. 10]
let exists = List.exists (fun x -> x = 5) [0 .. 10]
let forall = List.forall (fun x -> x <= 10) [0 .. 10]