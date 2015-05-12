namespace Plotly.Examples.PremierLeague

    open FSharp.Data
    open System
    open System.IO
    open System.Net

    type PremData = FSharp.Data.CsvProvider<"Date,Team 1,Team 2,FT,HT
    2013-08-17,Arsenal,Aston Villa,1-3,1-1
    2013-08-17,Liverpool,Stoke,1-0,1-0">

    module Data =


        let uri = new Uri("https://raw.githubusercontent.com/footballcsv/en-england/master/2010s/2013-14/1-premierleague.csv")

        let req = WebRequest.Create(uri);
        req.ContentType <- "text\csv"
        let res = req.GetResponse()
  
        let rdr = new StreamReader(res.GetResponseStream())
        let csv = rdr.ReadToEnd()
        rdr.Close()

        let prem2013 = PremData.Load "https://raw.githubusercontent.com/footballcsv/en-england/master/2010s/2013-14/1-premierleague.csv"



