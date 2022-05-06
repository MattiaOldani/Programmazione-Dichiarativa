// ESERCIZIO C


// Tipi operator, token e funzione evalRpn
#r "stack"
open Stack.Stack

type operator =
    | Add
    | Prod
    | Minus

type token =
    | Op of operator
    | C  of int

exception IllegalExpression

let evalRpn token =
    let rec eval expr stack =
        match expr with
        | [] ->
            match size stack with
            | 1 -> top stack
            | _ -> raise IllegalExpression
        | x::xs ->
            match x with
            | Op(op) ->
                let (n1,s1) = pop stack
                let (n2,s2) = pop s1
                let res =
                    match op with
                    | Add -> n1 + n2
                    | Prod -> n1 * n2
                    | Minus -> n2 - n1
                eval xs (push res s2)
            | C(n) ->
                let s = push n stack
                eval xs s
    eval token empty


// Test funzione evalRpn
let rpn1 = [ C 7 ; C 5 ;  Op Minus ]
let rpn2 = [ C 10 ; C 3 ; C 2 ; Op Prod ; Op Add ]
let rpn3 = [ C 10 ; C 3 ; Op Add ; C 2 ; Op Prod  ]
let rpn4 = [ C 10 ; C 6 ; C 1 ; Op Minus ; Op Prod ; C 4 ; Op Minus ; C 2 ; C 5 ; Op Prod ;  Op Add ]

let r1 = evalRpn rpn1
let r2 = evalRpn rpn2
let r3 = evalRpn rpn3
let r4 = evalRpn rpn4