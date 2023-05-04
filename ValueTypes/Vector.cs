namespace OptimizationMethods.ValueTypes;

public class Vector
{
    public double X1 { get; set; }
    public double X2 { get; set; }

    public Vector(double x1, double x2)
    {
        X1 = x1;
        X2 = x2;
    }

    public static Vector operator +(Vector a, double b) =>
        new(a.X1 + b, a.X2 + b);

    public static Vector operator -(Vector a, Vector b) =>
        new(a.X1 - b.X1, a.X2 - b.X2);

    public static Vector operator *(Matrix A, Vector B) =>
        new(A[0, 0] * B.X1 + A[0, 1] * B.X2, A[1, 0] * B.X1 + A[1, 1] * B.X2);

    public static Vector operator *(Vector a, double b) =>
        new(a.X1 * b, a.X2 * b);
}