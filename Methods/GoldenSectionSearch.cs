using OptimizationMethods.ValueTypes;

namespace OptimizationMethods.Methods;

public class GoldenSectionSearch : BaseSearch
{
    public GoldenSectionSearch(
        Func<double, double> function, 
        double start = 0, 
        double step = 1e-2, 
        double precision = 1e-4, 
        int maxCounter = 150, 
        Extremum extremum = Extremum.Min
        ) : base(function, start, step, precision, maxCounter, extremum)
    { }

    public double FindOptimal()
    {
        var borders = FindArea();

        var counter = 0;
        while (Math.Abs(borders.b - borders.a) >= Precision)
        {
            if (counter++ > MaxCounter) throw new ApplicationException("Не удалось найти решение");

            var x1 = borders.b - (borders.b - borders.a) / 1.6180339887;
            var x2 = borders.a + (borders.b - borders.a) / 1.6180339887;
            if (Extremum == Extremum.Max)
            {
                if (Function(borders.a) <= Function(borders.b))
                    borders.a = x1;
                else
                    borders.b = x2;
            }
            else
            {
                if (Function(borders.a) >= Function(borders.b))
                    borders.a = x1;
                else
                    borders.b = x2;
            }
        }

        return (borders.a + borders.b) / 2;
    }
}
