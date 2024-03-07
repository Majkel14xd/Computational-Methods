using System;

namespace Metodacieciw
{
    public class Program
    {
        static void Main(string[] args)
        {
            double a =-0.8;
            double b = -0.2;
            double epsilon = 0.1;

            while (Math.Abs(b - a) > epsilon)
            {
                double c = (a + b) / 2;

                if (funkcja(c) == 0)
                {
                    Console.WriteLine("Rozwiązanie to: " + c);
                    return;
                }
                else if (funkcja(a) * funkcja(c) < 0)
                {
                    b = c;
                }
                else
                {
                    a = c;
                }

            }

            Console.WriteLine("Rozwiązanie to: " + (a + b) / 2);
        }

        static double funkcja(double x)
        {
            // tutaj należy wpisać funkcję, której rozwiązanie chcemy znaleźć
            return 3*x-2*Math.Exp(x)-1;
           // return Math.Pow(x, 3) - 3 * Math.Pow(x, 2) - 2 * x + 5;
        }
    }
}
