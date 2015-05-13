namespace Plotly.Examples.BarChart

//#r "../packages/XPlot.GoogleCharts.1.1.7.0/lib/net45/XPlot.GoogleCharts.dll"
//#load Plotly.Examples.PremierLeague.Data;;
open XPlot.GoogleCharts
open Plotly.Examples.PremierLeague.Data
open Plotly.Examples.Definitions
open System




module BarChart =

//    let data = load "http://localhost:18888/largeDataSet"
    let data = load "http://localhost:18888/smallDataSet"

    let convertScore (s:String) =
        let split = s.Split([|"-"|], StringSplitOptions.None)
        Convert.ToInt32 split.[0], Convert.ToInt32 split.[1]

    
    let rows = data.Rows
    
    
    let convertedResults = 
        rows 
        |> Seq.map (fun r -> (r.Date,r.``Team 1``,r.``Team 2``, r.FT |> convertScore, r.HT |> convertScore)) 
        |> Seq.toList
    
    let goalsScored = 
        let fullTimeResults = (convertedResults)
        let goals = (0, fullTimeResults) ||> List.fold (fun i (_,_,_,(h,a), _) -> i + (h+a)) 
        goals

    let goalsScoredOverSeason =
        let fullTimeResults = (convertedResults)
        let goalsOverSeason = 
            fullTimeResults
            |> List.GroupBy date
            |> List.Sumby (fun ints -> ints.fst + ints.snd)
    let printAssertion = printfn "goals scored in the season should equal 1063, calculated: %i" goalsScored





