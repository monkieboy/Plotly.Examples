namespace Data.Host

module Bootstrapper =
    open Nancy
    open Nancy.Hosting.Self
    open System

    let SetUpConfiguration = 
        let config = new HostConfiguration()
        
        let reservations = new UrlReservations()
        reservations.CreateAutomatically <- true
        config.UrlReservations <- reservations





        config