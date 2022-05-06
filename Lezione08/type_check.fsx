// Tipo vname per implementare delle variabili
type vname = string

// Tipi exp e environment che implementano espressioni con interi e booleani
type exp =
    | I of int
    | V of vname
    | Sum of exp * exp
    | B of bool
    | Eq of exp * exp
    | Neg of exp 
    | Less of exp * exp

type enviroment = Map<vname,exp>

// Scriviamo un valutatore però che ritorna una espressione
let rec eval e (env : enviroment) =
    match e with
    | I(n) -> I(n)
    | V(name) -> Map.find name env
    | Sum(e1,e2) ->
        let (I n1) = eval e1 env
        let (I n2) = eval e2 env
        I(n1 + n2)
    | B(b) -> B(b)
    | Eq(e1,e2) ->
        let v1 = eval e1 env
        let v2 = eval e2 env
        B(v1 = v2)
    | Neg(e1) ->
        let (B b) = eval e1 env
        B(not b)
    | Less(e1,e2) ->
        let (I n1) = eval e1 env
        let (I n2) = eval e2 env
        B(n1 < n2)

// Problema: pattern matching incompleto in Sum e Less
// Questo perchè eval ritorna una exp e noi facciamo pattern matching solo su I(n)

// Prima soluzione: eccezioni
exception NotABool
exception NotAInt
exception NotSameType
exception UndefinedVariable of vname

let rec evalException e env =
    match e with
    | I(n) -> I(n)
    | V(name) ->
        match Map.tryFind name env with
        | Some(e) -> e
        | None -> raise (UndefinedVariable name)
    | Sum(e1,e2) ->
        match (evalException e1 env, evalException e2 env) with
        | (I(n1), I(n2)) -> I(n1 + n2)
        | _ -> raise NotAInt
    | B(b) -> B(b)
    | Eq(e1,e2) ->
        match (evalException e1 env, evalException e2 env) with
        | (I(n1), I(n2)) -> B(n1 = n2)
        | (B(b1), B(b2)) -> B(b1 = b2)
        | _ -> raise NotSameType
    | Neg(e1) ->
        match evalException e1 env with
        | B(b) -> B(not b)
        | _ -> raise NotABool
    | Less(e1,e2) ->
        match (evalException e1 env, evalException e2 env) with
        | (I(n1), I(n2)) -> B(n1 < n2)
        | _ -> raise NotAInt

// Seconda soluzione: uso di un altro tipo per i possibili risultati
type tp =
    | INT
    | BOOL

type tenviroment = Map<vname,tp>

let rec evalSium e env =
    match e with
    | I(n) -> Some(INT)
    | V(name) -> Map.tryFind name env
    | Sum(e1,e2) ->
        match (evalSium e1 env, evalSium e2 env) with
        | (Some(INT), Some(INT)) -> Some(INT)
        | _ -> None
    | B(b) -> Some(BOOL)
    | Eq(e1,e2) ->
        match (evalSium e1 env, evalSium e2 env) with
        | (Some(t1), Some(t2)) when t1 = t2 -> Some(BOOL)
        | _ -> None
    | Neg(e1) ->
        match evalSium e1 env with
        | Some(BOOL) -> Some(BOOL)
        | _ -> None
    | Less(e1,e2) ->
        match (evalSium e1 env, evalSium e2 env) with
        | (Some(INT), Some(INT)) -> Some(BOOL)
        | _ -> None