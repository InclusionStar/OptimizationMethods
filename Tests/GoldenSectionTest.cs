using NUnit.Framework;
using OptimizationMethods.Methods;

namespace OptimizationMethods.Tests;

[TestFixture]
[TestOf(typeof(GoldenSectionSearch))]
public class GoldenSectionTest
{
    [Test]
    public void TestLeftParabola()
    {
        var o = new GoldenSectionSearch(LeftParabola, start: -2);
        var got = o.FindOptimal();
        Assert.AreEqual(-1, got, 1E-04);
    }

    [Test]
    public void TestParabola()
    {
        var o = new GoldenSectionSearch(Parabola, start: 1);
        var got = o.FindOptimal();
        Assert.AreEqual(0, got, 1e-4);
    }

    [Test]
    public void TestAreaNotFound()
    {
        var o = new GoldenSectionSearch(Line);
        Assert.Catch<ApplicationException>(() => o.FindOptimal());
    }

    private double LeftParabola(double x) =>
        x * x + 2 * x + 1;

    private double Parabola(double x) =>
        x * x;

    private double Line(double x) => 2 * x;
}
