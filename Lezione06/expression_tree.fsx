// Abstract Syntax Tree --> alberi usati per definire la sintassi del linguaggio

// Espressioni intere con operazioni + - /
// Un'espressione "e" di tipo expr1 è definita induttivamente dalla grammatica BNF
//      e ::= n | e1 + e2 | e1 - e2 | e1 * e2
// dove n è una costante intera e e1,e2 sono espressioni di tipo expr1
// Una costante intera n è un'espressione di tipo expr1
// Se e1,e2 sono di tipo expr1, allora anche (+ - *) sono espressioni di tipo expr1
// Ogni tipo di espressione di tipo expr1 ha una delle due forme precedenti
// Ogni espressione può essere espressa come un albero, detto expression tree
// Ciascun nodo dell'albero contiene una constante intera o un'operazione
type expr1 =
    | C of int
    | Sum of expr1 * expr1
    | Diff of expr1 * expr1 
    | Prod of expr1 * expr1

// Un'espressione è un oggetto sintattico che si può valutare definendo una funzione di valutazione
// La funzione è e >> v, e indica che la valutazione di e è v; chiamata anche "giudizio"
// La funzione >> è definita per induzione sulla struttura di expr1
// Se e è la costante intera n, allora e >> n
// Se e è l'espressione e1+e2, e1 >> v1 e e2 >> v2, allora e >> v1 + v2
// La regola generale è e1+e2 >> v1+v2
// In modo analogo si definiscono differenza e prodotto
// e1+e2 usa il "+" come operatore del linguaggio expr1, v1+v2 usa il "+" della somma tra interi
let rec eval e =
    match e with
    | C(n)-> n
    | Sum(e1,e2) -> eval e1 + eval e2
    | Diff(e1,e2) -> eval e1 - eval e2
    | Prod(e1,e2) -> eval e1 * eval e2

// Essendo un albero, si possono scrivere tutte le funzioni definite prima
// Scriviamo il catamorfismo per expr1
let rec foldExpr fc fs fd fp expr = 
    match expr with
    | C(n) -> fc n
    | Sum(e1,e2) -> fs (foldExpr fc fs fd fp e1) (foldExpr fc fs fd fp e2)
    | Diff(e1,e2) -> fd (foldExpr fc fs fd fp e1) (foldExpr fc fs fd fp e2)
    | Prod(e1,e2) -> fp (foldExpr fc fs fd fp e1) (foldExpr fc fs fd fp e2)

// Funzione che ottimizza le somme e i prodotti per 0
let rec opt e =
    match e with
    | C(n) -> C(n)
    | Sum(C(0), a) -> opt a
    | Sum(a, C(0)) -> opt a
    | Sum(a, b) -> Sum(opt a, opt b)
    | Prod(C(0), a) -> C(0)
    | Prod(a, C(0)) -> C(0)
    | Prod(a, b) -> Prod(opt a, opt b)
    | Diff(a, b) -> Diff(opt a, opt b)

// Espressioni con variabili
// Un'espressione "e" di tipo expr2 è definita induttivamente dalla grammatica BNF
//      e ::= x | n | e1 + e2 | e1 - e2 | e1 * e2
// dove x è una variabile, n è una costante intera e e1,e2 sono espressioni di tipo expr2
type expr2 =
    | V of string
    | C of int
    | Sum of expr2 * expr2
    | Diff of expr2 * expr2
    | Prod of expr2 * expr2

// La valutazione di un'espressione di tipo expr2 ha senso solo
// alle variabili che compaiono in essa è assegnato un valore
// La funzione che mappa ogni identificatore con il proprio valore è l'environment
// env(x) = v associa all'identificatore x il suo valore v
// Il giudizio è env |- e >> v
// Denota che l'ambiente env valuta e con v
// La funzione si definisce per induzione sulla struttura di expr2
// Se l'espressione e è la variabile x e env(x) = v, allora env |- e >> v
// Se l'espressione e è la costante intera n, allora env |- e >> n
// env |- e1 >> v1 e env |- e2 >> v2, valgono le regole precedenti
// L'environment è un insieme finito di associazioni {x1->v1 ,..., xn->vn} --> è una mappa
// Si implementa con il tipo Map, che è una funzione 'a -> 'b
// L'insieme dei valori 'a è detto insieme delle chiavi, e contiene valori distinti
// Il nostro environmente è una Map<string,int>
let rec eval2 e env =
    match e with
    | V(x) -> Map.find x env
    | C(n) -> n
    | Sum(e1,e2) -> eval2 e1 env + eval2 e2 env
    | Diff(e1,e2) -> eval2 e1 env - eval2 e2 env
    | Prod(e1,e2) -> eval2 e1 env * eval2 e2 env

// Espressioni con variabili e let-definition
// Un'espressione "e" di tipo expr2 è definita induttivamente dalla grammatica BNF
//      e ::= x | n | e1 + e2 | e1 - e2 | e1 * e2 | let x = e1 in e2
// dove x è una variabile, n è una costante intera e e1,e2 sono espressioni di tipo expr2
// let y = 2 in (y + y)
// Si deve seguire la Barendregt's Variable Convention, ovvero la variabile x occorre in e2 ed è vincolata
// Il valore di e1 invece è libero
type expr3 =
    | V of string
    | C of int
    | Sum of expr3 * expr3
    | Diff of expr3 * expr3
    | Prod of expr3 * expr3
    | Let of string * expr3 * expr3

// La funzione di valutazione è la stessa delle expr2, ma ora l'environment è modificabile
// env[x := v] indica l'ambiente arricchito con l'associazione x -> v
// env |- (let x = e1 in e2) >> v2
// Si valuta e1 in env, quindi env |- e1 >> v1, e lo si lega a x
// Si valuta e2 con il nuovo binding, quindi env[x := v1] |- e2 >> v2
let rec eval3 e env =
    match e with
    | V(x) -> Map.find x env
    | C(n) -> n
    | Sum(e1, e2) -> eval3 e1 env + eval3 e2 env
    | Diff(e1, e2) -> eval3 e1 env - eval3 e2 env
    | Prod(e1, e2) -> eval3 e1 env * eval3 e2 env
    | Let(x, e1, e2) ->
        let v1 = eval3 e1 env
        let envx = Map.add x v1 env
        eval3 e2 envx