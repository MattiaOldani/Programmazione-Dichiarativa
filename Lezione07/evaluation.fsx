// La lazy evaluation ritarda la valutazione di un'espressione 
// La valutazione avviene quando il risultato della valutazione deve essere utilizzato
// Lazy evaluation usata in:
//      sequence expression
//      operatori booleani && e ||
//      espressioni del tipo 0*Expr
//      definizione di funzioni
let b1 = (3 < 0) && (2/0 > 3)
let b2 = (3 > 0) || (2/0 > 0)
let e1 = 0 * (1 + 2 + 3 + 4 + 5)
let f1 = fun x -> x + 1/0

// La strict/eager evaluation valuta tutte le espressioni prima di utilizzarle in funzioni o operazioni
// Questa valutazione è quella che viene usata nelle liste