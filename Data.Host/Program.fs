// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
namespace Data.Host

module Program =
    open Nancy
    open Nancy.Hosting.Self
    open System


    [<EntryPoint>]
    let main argv = 
        let config = Data.Host.Bootstrapper.SetUpConfiguration


        let nancyHost = new NancyHost(config, new Uri("http://localhost:18888/"), new Uri("http://127.0.0.1:18888/"))
        
        nancyHost.Start()
        printfn "ready..."
        Console.ReadKey()
        nancyHost.Stop()
        0