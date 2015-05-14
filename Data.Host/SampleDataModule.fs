namespace Data.Host
module Nancy =
    open Nancy
    open System
    open System.Net
    open System.IO
    open FSharp.Data
    open Plotly.Examples.PremierLeague.Data

    let feed = "https://raw.githubusercontent.com/footballcsv/en-england/master/2010s/2013-14/1-premierleague.csv"
    let client = new WebClient()
    let large = client.DownloadString(feed)
    let small = File.ReadAllText("sample.csv")

    type SampleDataModule() as self = 
        inherit NancyModule()
        do         
            self.Get.["/smallDataSet"] <- (fun _ -> self.Response.AsText(small) :> obj)
            self.Get.["/largeDataSet"] <- (fun _ -> self.Response.AsText(large) :> obj)
    