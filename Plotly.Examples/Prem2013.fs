namespace Plotly.Examples.PremierLeague

open FSharp.Data
open System
open System.IO
open System.Net


module Data =

    type Feed = FSharp.Data.CsvProvider<"Date,Team 1,Team 2,FT,HT
    2013-08-17,Arsenal,Aston Villa,1-3,1-1
    2013-08-17,Liverpool,Stoke,1-0,1-0">


    let load u =
        let uri = new Uri(u)

        let req = WebRequest.Create(uri);
        req.ContentType <- "text/csv"
        let res = req.GetResponse()
  
        let rdr = new StreamReader(res.GetResponseStream())
        let csv = rdr.ReadToEnd()
        rdr.Close()

        let feed = Feed.Load u
        feed


