namespace Functions

open System
open System.Collections.Generic

module internal Aggregates =

    let getAggregates (series) (series2) =

        let dsAggregates = new Dictionary<string, decimal>();

        let total_series : decimal = List.sum series;
        let total_series2 : decimal = List.sum series2;

        dsAggregates.Add("TotalSeries", Math.Round(total_series, 4));
        dsAggregates.Add("TotalSeries2", Math.Round(total_series2, 4));
        dsAggregates.Add("TotalDiffPercentage", Percentages.relativePercentage total_series total_series2);
        dsAggregates.Add("AverageSerie", Math.Round(List.average series, 4));
        dsAggregates.Add("MaxSerie", Math.Round(List.max series, 4));
        dsAggregates.Add("MinSerie", Math.Round(List.min series, 4));
        dsAggregates.Add("AverageSerie2", Math.Round(List.average series2, 4));
        dsAggregates.Add("MaxSerie2", Math.Round(List.max series2, 4));
        dsAggregates.Add("MinSerie2", Math.Round(List.min series2, 4));

        dsAggregates;



