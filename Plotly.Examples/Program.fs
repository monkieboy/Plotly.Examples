module Program
open System
open Plotly.Examples.BarChart
[<EntryPoint>]
let main x =
    Console.ReadKey()
    BarChart.printAssertion
    Console.ReadKey()
    0