using OptimizationMethods.ValueTypes;

namespace OptimizationMethods.Methods;

public class GradientDescent
{
    private Func<Vector, double> Function { get; }
    private Vector Start { get; set; }
    private double Step { get; set; }
    private double Precision { get; }
    private double MaxCounter { get; }
    private Extremum Extremum { get; }

    public GradientDescent(
        Func<Vector, double> function,
        Vector start,
        double step = 1e-2,
        double precision = 1e-4,
        double maxCounter = 1000,
        Extremum extremum = Extremum.Min
    )
    {
        Function = function;
        Start = start;
        Step = step;
        Precision = precision;
        MaxCounter = maxCounter;
        Extremum = extremum;
    }

    public Vector FindOptimal()
    {
        var last = new Vector(Start.X1, Start.X2);
        var current = Start - Gradient(Start) * 0.1;
        
        var counter = 0;
        while (Function(last) - Function(current) > Precision)
        {
            if (counter++ > MaxCounter) throw new ApplicationException("Не удалось найти решение");
            
            last = new Vector(current.X1, current.X2);
            current -= Gradient(current) * 0.1;
        }

        return current;
    }

    private Vector Gradient(Vector x) => 
        new(DerivativeDx1(x), DerivativeDx2(x));

    private double DerivativeDx1(Vector x)
    {
        var oldX = new Vector(x.X1, x.X2);
        x.X1 += 1e-4;
        return (Function(x) - Function(oldX)) / 1e-4;
    }
    
    private double DerivativeDx2(Vector x)
    {
        var oldX = new Vector(x.X1, x.X2);
        x.X2 += 1e-4;
        return (Function(x) - Function(oldX)) / 1e-4;
    }
}
