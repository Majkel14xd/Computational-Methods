using System;

namespace BisectionExample
{
    class Program
    {
        static double f1(double x)
        {
            return 3*x-2*Math.Exp(x)-1;
        }

        static double f2(double x)
        {
            return 3  - 2 * Math.Exp(x);
        }

        static void Main(string[] args)
        {
        
            double epsilon = 0.1;

       
            Console.WriteLine("f1(x) =  3*x-2*e^x-1");
            Console.WriteLine("Szukanie rozwiązania w przedziale (-0.8, -0.2)");
            bisection(-0.8, -0.2, f1, epsilon);

          
            Console.WriteLine("f2(x) = 3-2*e^x");
            Console.WriteLine("Szukanie rozwiązania w przedziale (-0.8, -0.2)");
            bisection(-0.8, -0.22, f2, epsilon);
        }

        static void bisection(double a, double b, Func<double, double> f, double epsilon)
        {
            double fa = f(a), fb = f(b), c=0, fc;
            int k = 0;

            while (b - a > epsilon)
            {
                c = (a + b) / 2;
                fc = f(c);
                if (fc == 0)
                    break;
                else if (fa * fc < 0)
                    b = c;
                else
                    a = c;
                k++;
            }

            Console.WriteLine("Rozwiązanie znaleziono w kroku " + k);
            Console.WriteLine("x = " + c);
        }
    }
}
