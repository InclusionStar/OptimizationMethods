namespace OptimizationMethods.ValueTypes;

public class Matrix
{
    private double[,] Data { get; } = new double[2, 2]; 
    public double Det => this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0];

    public double this[int i, int j]
    {
        get => Data[i, j];
        set => Data[i, j] = value;
    }

    public Matrix Invert()
    {
        double D = Det;
        if (D == 0)
            throw new ArgumentException("Неверная матрица. Определитель равен нулю");

        var resultMatrix = new Matrix
        {
            [0, 0] = this[1, 1] / D,
            [1, 1] = this[0, 0] / D,
            [0, 1] = -this[0, 1] / D,
            [1, 0] = -this[1, 0] / D
        };

        return resultMatrix;
    }
}