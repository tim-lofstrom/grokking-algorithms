open System

let random = Random()

let list =
    [ for _ in 1..100 -> random.Next(1, 101) ]
    |> List.sortBy (fun _ -> random.Next())
    |> List.toArray


let rec binary_search (list: int array) low high target =
    let mid = (low + high) / 2
    let guess = list[mid]

    match guess with
    | _ when low >= high && guess <> target -> -1
    | _ when guess > target -> binary_search list low (mid - 1) target
    | _ when guess < target -> binary_search list (mid + 1) high target
    | _ -> mid


let target = 5
let sorted = list |> Array.sort
let result = binary_search sorted 0 (list.Length - 1) target

printfn "Random lista: %A " sorted
printfn "Söker efter %i " target
printfn "Position %i " result
