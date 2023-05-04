using NUnit.Framework;
using OptimizationMethods.Methods;
using OptimizationMethods.ValueTypes;

namespace OptimizationMethods.Tests;

[TestFixture]
[TestOf(typeof(GradientDescent))]
public class GradientDescentTest
{
    [Test]
    public void TestX2Y2()
    {
        var o = new GradientDescent(X2Y2, new Vector(5.0, 5.0));
        var got = o.FindOptimal();
        Assert.AreEqual(0, got.X1, 1e-2);
        Assert.AreEqual(0, got.X2, 1e-2);
    }

    private double X2Y2(Vector x) =>
        x.X1 * x.X1 + x.X2 * x.X2;
}