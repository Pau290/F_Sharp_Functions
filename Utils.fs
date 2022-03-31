namespace Functions

open System.Collections.Generic

module internal Utils =

    let mapSeries series partials =
        
        let ds = new Dictionary<string, decimal>();

        (partials, series)
        ||> List.map2(fun partial serie -> ds.Add(partial, serie)) |> ignore;

        ds

    
