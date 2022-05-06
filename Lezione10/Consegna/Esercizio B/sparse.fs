// ESERCIZIO B


namespace Sparse

module Sparse =
    type 'a sparse = {dim : int; deflt : 'a; vect : Map<int, 'a>}

    exception OutOfBound

    let empty n value = {dim = n; deflt = value; vect = Map.empty}

    let dimn {dim = n; deflt = d; vect = v} = n

    let deflt {dim = n; deflt = d; vect = v} = d
    
    let lookup index {dim = n; deflt = d; vect = v} =
        match index >= 0 && index < n with
        | true ->
            match Map.tryFind index v with
            | None -> d
            | Some(value) -> value
        | false -> raise OutOfBound

    let update index value {dim = n; deflt = d; vect = v} =
        match index >= 0 && index < n with
        | true ->
            match value = d with
            | true ->
                match Map.tryFind index v with
                | None -> {dim = n; deflt = d; vect = v}
                | Some(_) -> {dim = n; deflt = d; vect = Map.remove index v}
            | false -> {dim = n; deflt = d; vect = Map.add index value v}
        | false -> raise OutOfBound

    let toList {dim = n; deflt = d; vect = v} = Map.toList v

    let verbosetoList {dim = n; deflt = d; vect = v} =
        let rec createList index =
            match index < n with
            | true ->
                match Map.tryFind index v with
                | Some(value) -> (index,value) :: createList (index+1)
                | None -> (index,deflt) :: createList (index+1)
            | false -> []
        createList 0