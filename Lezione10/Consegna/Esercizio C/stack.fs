// ESERCIZIO C


namespace Stack

module Stack =
    type Stack<'a> = S of 'a list

    exception EmptyStack

    let empty = S []

    let isEmpty (S lst) = lst = []

    let push el (S lst) = S(el::lst)

    let pop (S lst) =
        match lst with
        | [] -> raise EmptyStack
        | x::xs -> (x, S(xs))

    let top (S lst) = 
        match lst with
        | [] -> raise EmptyStack
        | x::xs -> x

    let size (S lst) = List.length lst