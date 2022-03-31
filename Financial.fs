namespace Functions

open System
open MathNet.Numerics
open System.Collections.Generic

module internal Financial =

    let private getseriesf (series: list<decimal>) = 
        series
        |> List.map(fun serie -> float serie);

    let private getCompoundReturn (series: list<float>) =
        Math.Round(System.Convert.ToDecimal(Financial.AbsoluteReturnMeasures.CompoundReturn series), 4);

    let private getGainMean (series: list<float>) =
        Math.Round(System.Convert.ToDecimal(Financial.AbsoluteReturnMeasures.GainMean series), 4);


    let private indexesCompareds = [ yield "CompoundReturnCompared"; yield "GainMeanCompared"; ];
    let private indexesObjective = [ yield "CompoundReturnObjective"; yield "GainMeanObjective";  ];

    let getFinancialIndexes (series) (objectives) =

        let dsFinancial = new Dictionary<string, decimal>();

        let seriesf = getseriesf series;

        let compoundReturnResult = getCompoundReturn seriesf;
        let gainMeanResult = getGainMean seriesf;

        dsFinancial.Add("CompoundReturn", compoundReturnResult);
        dsFinancial.Add("GainMean", gainMeanResult);

        (indexesObjective, objectives)
        ||> List.map2(fun index objective -> dsFinancial.Add(index, objective)) |> ignore;

        let results = [ yield compoundReturnResult; yield gainMeanResult; ]

        (indexesCompareds, results, objectives)
        |||> List.map3(fun compared serie objective -> dsFinancial.Add(compared, Percentages.relativePercentage serie objective)) |> ignore;        

        dsFinancial;
