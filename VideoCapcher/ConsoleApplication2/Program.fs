// Дополнительные сведения о F# см. на http://fsharp.net
// Дополнительную справку см. в проекте "Учебник по F#".

open System

[<EntryPoint>]
let main (argv : string[]) =
    //1 програмка
    let greeting, thing = "some", "any"
    let timeOfDay = System.DateTime.Now.ToString("hh.mm tt")
    printfn "%s %s at %s" greeting thing timeOfDay
    //2-я рограмка и первая функция

    let printTruthTable f =
        printfn "        |true   |false  |"
        printfn "        +---------------+"
        printfn "    true|%5b  |%5b  |" (f true true)(f true false)
        printfn "   false|%5b  |%5b  |" (f false true)(f false false)
        printfn "        +---------------+"
        printfn ""
          //();;
    printTruthTable (&&)
    printTruthTable (||)

      
    0 // возвращение целочисленного кода выхода
