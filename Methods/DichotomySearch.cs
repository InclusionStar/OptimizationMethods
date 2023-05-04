using OptimizationMethods.ValueTypes;

namespace OptimizationMethods.Methods;

public class DichotomySearch : BaseSearch
{
    public DichotomySearch(
        Func<double, double> function,
        double start = 0,
        double step = 1e-2,
        double precision = 1e-4,
        double maxCounter = 150,
        Extremum extremum = Extremum.Min
    ) : base(function, start, step, precision, maxCounter, extremum)
    {
    }

    public double FindOptimal()
    {
        var borders = FindArea();
        var rnd = new Random();

        var counter = 0;
        while (Math.Abs(borders.b - borders.a) >= Precision)
        {
            if (counter++ > MaxCounter) throw new ApplicationException("Не удалось найти решение");

            var borderForEps = (borders.b - borders.a) / 2;
            var eps = rnd.NextDouble() * borderForEps;
            var x1 = (borders.a + borders.b) / 2 - eps;
            var x2 = (borders.a + borders.b) / 2 + eps;
            if (Extremum == Extremum.Min)
            {
                if (Function(x1) > Function(x2))
                    borders.a = x1;
                else
                    borders.b = x2;
            }
            else
            {
                if (Function(x1) < Function(x2))
                    borders.a = x1;
                else
                    borders.b = x2;
            }
            // var center = (borders.a + borders.b) / 2;
            //
            // if (IsDecentBorders(borders.a, center)) 
            //     borders.b = center;
            // else if (IsDecentBorders(center, borders.b)) 
            //     borders.a = center;
            // else
            // {
            //     var leftCenter = (borders.a + center) / 2;
            //     var rightCenter = (borders.b + center) / 2;
            //     if (Extremum == Extremum.Max
            //             ? Function(leftCenter) > Function(rightCenter)
            //             : Function(leftCenter) < Function(rightCenter))
            //         borders.b = center;
            //     else
            //         borders.a = center;
            // }
        }


        return (borders.a + borders.b) / 2;
    }

    public double FindOptimalOld()
    {
        var borders = FindArea();

        var counter = 0;
        while (Math.Abs(borders.b - borders.a) >= Precision)
        {
            if (counter++ > MaxCounter) throw new ApplicationException("Не удалось найти решение");
            
            var center = (borders.a + borders.b) / 2;

            if (IsDecentBorders(borders.a, center))
                borders.b = center;
            else if (IsDecentBorders(center, borders.b))
                borders.a = center;
            else
            {
                var leftCenter = (borders.a + center) / 2;
                var rightCenter = (borders.b + center) / 2;
                if (Extremum == Extremum.Max
                        ? Function(leftCenter) > Function(rightCenter)
                        : Function(leftCenter) < Function(rightCenter))
                    borders.b = center;
                else
                    borders.a = center;
            }
        }
        
        return (borders.a + borders.b) / 2;
    }
}
