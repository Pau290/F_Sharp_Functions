namespace Functions

open System.Text.Json
open System.Collections.Generic

module Library =

    let getComparedStatistics (series) (series2) (partials) = 

        let ds = new Dictionary<string, Dictionary<string, decimal>>();

        ds.Add("Series", Utils.mapSeries series partials);
        ds.Add("Series2", Utils.mapSeries series2 partials);

        ds.Add("Aggregates", Aggregates.getAggregates series series2);
        ds.Add("PercentagesCompared", Percentages.getPercentagesComparedByPartial series series2 partials); 
        ds.Add("PercentagesOnTotal", Percentages.getPercentagesOnTotalByPartial series partials); 

        JsonSerializer.Serialize(ds);


    let getFinancialIndexes (series) (objectives) = 

        let ds = new Dictionary<string, Dictionary<string, decimal>>();

        ds.Add("FinancialIndexes", Financial.getFinancialIndexes series objectives);

        JsonSerializer.Serialize(ds);
        