namespace Plotly.Examples.BarChart

open XPlot.GoogleCharts
open Plotly.Examples.PremierLeague.Data
open System

module BarChart =
    let data = prem2013
    let convertScore (s:String) =
        let split = s.Split([|"-"|], StringSplitOptions.None)
        Convert.ToInt32 split.[0], Convert.ToInt32 split.[1]

    
    let rows = data.Rows
    
    
    let convertedRows = 
        rows 
        |> Seq.map (fun r -> (r.Date,r.``Team 1``,r.``Team 2``, r.FT |> convertScore, r.HT |> convertScore))
    
    let calcGoals s =
        let a, b = s
        a + b
    
    let goalsScored = 
        let goals = 
            convertedRows 
            |> Seq.map (fun (_, _, _, f, _) -> f |> calcGoals )
        goals |> Seq.sum
        

    printfn "%i goals scored in the season should equal 1063." goalsScored





