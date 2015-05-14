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

        let results = fullTimeResults |> Seq.map(fun (d, _, _, (h,a), _) -> (d,(h,a)))

        let groupedResults =
            results
            |> Seq.groupBy (fun fixture -> fixture |> fst)
            |> Seq.toList

        let sumify f =
            let (a:int),(b:int) = f
            a+b


//        let goalsOverSeason =
//            let result = 
//                groupedResults
//                |> Seq.map (fun (r, l) -> l |> sumify) 
//            result
//        
//        goalsOverSeason
        groupedResults
    
    let mergify l:DateTime*(int*int) =
        let a, (b,c) = l
        (a, b+c)

    let chart =
//        let r = goalsScoredOverSeason |> List.map(fun l -> l |> mergify)
//        let series = goalsScoredOverSeason |> List.map (fun l (h,a) -> (l, h+a)) |> List.toSeq
//        let inputs = goalsScoredOverSeason |> List.map (fun _ r -> fst r) |> List.toSeq

        let series = goalsScoredOverSeason |> Seq.map(fun s -> fst s)
        let inputs = goalsScoredOverSeason |> Seq.map(fun s -> snd s)

        inputs
        |> Chart.Combo
        |> Chart.WithLegend true
        |> Chart.WithSize (600,300)
        

   //let printAssertion = printfn "goals scored in the season should equal 1063, calculated: %i" goalsScored





