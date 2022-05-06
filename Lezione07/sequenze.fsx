// Una sequenza è una collezione, eventualmente infinita, di elementi dello stesso tipo
// Gli elementi si possono definire tramite sequence expression
// Descrivono il processo di generazione degli elementi della sequenza
// Se si usano in let-definition, gli elementi vengono valutati on demand
// Questo permette la creazione di liste infinite
// La valutazione on demand viene anche detta lazy evaluation

// Con "yield t" si aggiunge t alla sequenza
// Con "yield! s" si aggiunge la sequenza s alla sequenza corrente
// Possibile usare il costrutto if-then come filtro
let s1 = seq [
    yield 0
    yield 1
    yield 2
    yield 3
]

let s2 = seq [
    yield! s1
    yield 100
    yield! s1
    yield 200
]

let f1 x = seq [
    if x > 50 then yield x
]

let f2 x = seq [
    if x > 0 then yield x else yield -x
]

// Per accedere all'elemento i-esimo di una sequenza si usa "Seq.item i seq"
let index = Seq.item 5 s2

// Per estrarre i primi n elementi di una sequenza si usa "Seq.take n seq"
let s3 = Seq.take 5 s2

// Per scartare i primi n elementi di una sequenza si usa "Seq.skip n seq"
let s4 = Seq.skip 5 s2

// Per trasformare una sequenza in una lista si usa "Seq.toList seq"
let lst = Seq.toList s1

// Sulle sequenze non è possibile il pattern matching
// Se si vuole decomporre una sequenza si devono usare le funzioni di librerie fornite da Seq

// Il costruttore seq può essere applicato ad una lista per ottenere una sequenza finita
// In modo analogo si può usare "Seq.ofList lst"
// Essendoci una lista, qua la valutazione è strict
// Tutti gli elementi della lista sono valutati, e quindi anche quelli della sequenza lo sono
let s5 = seq [0 .. 10]
let s6 = Seq.ofList [0 .. 10]

// Per costruire delle sequenze infinite si usa "Seq.initInfinite f"
// La sequenza viene costruita con f(0), f(1), ...
let s7 = Seq.initInfinite (fun x -> x + 5)