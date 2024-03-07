using System;

namespace RK4
{
    public static class RK4
    {
        public static double[] RK4metoda(Func<double, double, double> f, double x0, double y0, double h, int n)
        {
            double[] y = new double[n + 1];
            y[0] = y0;

            for (int i = 0; i < n; i++)
            {
                double k1 = h * f(x0, y[i]);
                double k2 = h * f(x0 + h / 2, y[i] + k1 / 2);
                double k3 = h * f(x0 + h / 2, y[i] + k2 / 2);
                double k4 = h * f(x0 + h, y[i] + k3);

                y[i + 1] = y[i] + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                x0 += h;
            }

            return y;
        }
        static void Main(string[] args)
        {
            Func<double, double, double> f = (x, y) => -3 * y + Math.Sqrt(4*Math.Pow(x,2) + 1);
            double[] y = RK4metoda(f, 2.6, 3.5, 0.2, 10);
            double x0 = 2.6;
        
            for (int i = 0; i < y.Length; i++)
            {
                Console.WriteLine($"y({x0:F1}) = {y[i]:F5}");
                x0 = x0 + 0.2;
            }
        }
    }
}
