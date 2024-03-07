using System;

public class FibonacciOptymalizacja
{
    public static double Optymalizacja(Func<double, double> funkcja, double a, double b)
    {
        double c = b - (b - a) / Fibonacci(20);
        double d = a + (b - a) / Fibonacci(20);
        double fc = funkcja(c);
        double fd = funkcja(d);

        for (int i = 19; i >= 0; i--)
        {
            if (fc < fd)
            {
                b = d;
                d = c;
                fd = fc;
                c = b - (b - a) / Fibonacci(i);
                fc = funkcja(c);
            }
            else
            {
                a = c;
                c = d;
                fc = fd;
                d = a + (b - a) / Fibonacci(i);
                fd = funkcja(d);
            }
        }

        return (b + a) / 2;
    }

    private static double Fibonacci(int n)
    {
        if (n == 0)
        {
            return 0;
        }

        if (n == 1)
        {
            return 1;
        }

        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
    public static void Main()
    {
     
        Func<double, double> function = x => Math.Sin(x)-Math.Pow(x,2)*Math.Cos(x);

     
        double result = FibonacciOptymalizacja.Optymalizacja(function, -5, 5);
        Console.WriteLine(result); 
    }
}

