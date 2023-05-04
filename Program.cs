using OptimizationMethods.ValueTypes;
using OptimizationMethods.Methods;
//
// double F(double x) =>
//     Math.Pow(x, 6) - 2 * Math.Pow(x, 5) + 2 * Math.Pow(x, 3) - 10 * x * x + x;
//
// double F2(Vector x) =>
//     5 * Math.Pow(x.X2 - x.X1, 2) + Math.Pow(1 - x.X1, 2);
//     
// var d = new DichotomySearch(F);
// var g = new GoldenSectionSearch(F);
//
// Console.WriteLine($"Дихотомия - Ответ: {d.FindOptimal()}");
// Console.WriteLine($"Золотое сечение - Ответ: {g.FindOptimal()}");
//
// var gr = new GradientDescent(F2, new Vector(6, 6));
// var x = gr.FindOptimal();
// Console.WriteLine($"Градиентный спуск - Ответ: {x.X1} - {x.X2}");

double F (double x) =>
    Math.Pow(x, 6) - 2 * Math.Pow(x, 5) + 4 * Math.Pow(x, 3) - 10 * Math.Pow(x, 2) + x;

double dF(double x) =>
    6 * Math.Pow(x, 5) - 10 * Math.Pow(x, 4) + 12 * Math.Pow(x, 2) - 20 * x + 1;

// double dF2(double x) =>
//     30 * Math.Pow(x, 4) - 40 * Math.Pow(x, 3) + 24 * x - 20;

var d = new DichotomySearch(F);
Console.WriteLine($"Новый метод (Точка минимума): {d.FindOptimal()}");
Console.WriteLine($"Старый метод: {d.FindOptimalOld()}");

var df = new DichotomySearch(dF);
Console.WriteLine($"Новый метод (Точка минимума): {df.FindOptimal()}");
Console.WriteLine($"Старый метод: {df.FindOptimalOld()}");

var dfm = new DichotomySearch(F, extremum: Extremum.Max, step: 0.001, precision: 0.01, maxCounter: 10000);
Console.WriteLine($"Новый метод (Точка максимума): {dfm.FindOptimal()}");
// Console.WriteLine($"Старый метод: {dfm.FindOptimalOld()}");
// var g = new GoldenSectionSearch(F);
// Console.WriteLine(g.FindOptimal());
//
// var gf = new GoldenSectionSearch(dF);
// Console.WriteLine(gf.FindOptimal());
