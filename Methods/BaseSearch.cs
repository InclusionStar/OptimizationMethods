using OptimizationMethods.ValueTypes;

namespace OptimizationMethods.Methods;

public abstract class BaseSearch
{
    protected Func<double, double> Function { get; }
    protected double Start { get; }
    protected double Step { get; set; }
    protected double Precision { get; }
    protected double MaxCounter { get; }
    protected Extremum Extremum { get; }

    protected BaseSearch(
        Func<double, double> function,
        double start = 0,
        double step = 1e-2,
        double precision = 1e-4,
        double maxCounter = 150,
        Extremum extremum = Extremum.Min
    )
    {
        Function = function;
        Start = start;
        Step = function(start + step) > function(start - step)
            ? Extremum == Extremum.Max ? step : -step
            : Extremum == Extremum.Max
                ? -step
                : step;
        Precision = precision;
        MaxCounter = maxCounter;
        Extremum = extremum;
    }

    protected (double a, double b) FindArea()
    {
        var a = Start;
        var b = Start + Step;

        var counter = 0;
        while (!IsDecentBorders(a, b))
            if (counter++ > MaxCounter) throw new ApplicationException("Не удалось найти решение");
            else
            {
                b += Step;
                Step *= 2;
            }

        return (a, b);
    }

    protected bool IsDecentBorders(double a, double b)
    {
        var center = (a + b) / 2;
        return Extremum == Extremum.Max
            ? Function(center) >= Function(a) && Function(center) >= Function(b)
            : Function(center) <= Function(a) && Function(center) <= Function(b);
    }
}