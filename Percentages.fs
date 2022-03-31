namespace Functions

open System
open System.Collections.Generic

module internal Percentages =

    let relativePercentage serie serie2 = Math.Round(((serie - serie2) / serie2) * 100.0M, 4);

    let relativeTotalPercentage serie total = Math.Round((serie / total) * 100.0M, 4);

    let getPercentagesComparedByPartial (series) (series2) (partials) =

        let dictionary = new Dictionary<string, decimal>(); 

        (partials, series, series2)
        |||> List.map3(fun partial serie serie2 -> dictionary.Add(partial, relativePercentage serie serie2)) |> ignore;

        dictionary

    let getPercentagesOnTotalByPartial (series) (partials) =

        let dictionary = new Dictionary<string, decimal>(); 

        let total = List.sum series;

        (partials, series)
        ||> List.map2(fun partial serie -> dictionary.Add(partial, relativeTotalPercentage serie total)) |> ignore;

        dictionary


