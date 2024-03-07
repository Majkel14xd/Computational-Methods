using System;
using System.Collections.Generic;

namespace Lagrangemo
{
    class Program
    {
        static double[] Y = { 0.050042, 0.100335, 0.171657, 0.255534, 0.309336, 0.376403 };
        static double[] X = { 0.050000, 0.100000, 0.170000, 0.250000, 0.300000, 0.360000 };
        static double lagrange(double x)
        {
            int n = 6;
            double top;
            double bot;
            double result = 0;
         
            for (int i = 0; i < n; i++)
            {
                top = 1;
                bot = 1;
                for (int j = 0; j < n; j++)
                {
                    if (X[i] == X[j])
                        continue;
                    top *= (x - X[j]);
                    if (X[i] == X[j])
                        continue;
                    bot *= (X[i] - X[j]);
                }
                result += (Y[i] * (top / bot));
            }
            return result;
        }

        static void Wspolczynniki() {
            {
                List<double> list = new List<double>();

                double[] wspolczynniki = new double[X.Length];

                for (int m = 0; m < X.Length; m++)
                {
                    wspolczynniki[m] = 0;
                }
                for (int m = 0; m < X.Length; m++)
                {
                    double[] newwspolczynniki = new double[X.Length];
                    for (int nc = 0; nc < X.Length; nc++)
                    {
                        newwspolczynniki[nc] = 0;
                    }
                    if (m > 0)
                    {
                        newwspolczynniki[0] = -X[0] / (X[m] - X[0]);

                        newwspolczynniki[1] = 1 / (X[m] - X[0]);

                    }
                    else
                    {
                        newwspolczynniki[0] = -X[1] / (X[m] - X[1]);

                        newwspolczynniki[1] = 1 / (X[m] - X[1]);

                    }
                    int indexstartowy = 1;

                    if (m == 0)
                    {
                        indexstartowy = 2;

                    }
                    for (int n = indexstartowy; n < X.Length; n++)
                    {
                        if (m == n)
                        {
                            continue;

                        }
                        for (int nc = X.Length - 1; nc >= 1; nc--)
                        {
                            newwspolczynniki[nc] = newwspolczynniki[nc] * (-X[n] / (X[m] - X[n])) + newwspolczynniki[nc - 1] / (X[m] - X[n]);

                        }
                        newwspolczynniki[0] = newwspolczynniki[0] * (-X[n] / (X[m] - X[n]));

                    }
                    for (int nc = 0; nc < X.Length; nc++)
                    {
                        wspolczynniki[nc] += Y[m] * newwspolczynniki[nc];
                        list.Add(wspolczynniki[nc]);

                    }

                }
                Console.WriteLine(wspolczynniki[0]);
                for (int i = 1; i < X.Length; i++)
                    Console.WriteLine("x" + i + " " + wspolczynniki[i]);
            }


        }
        static void Main(string[] args)
        {
            double x;
            string xstr;
            while (true)
            {
                Console.WriteLine("Insert x: ");
                xstr = Console.ReadLine();
                if (double.TryParse(xstr, out x))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong value, try again...");
                }
             
            }
            Console.WriteLine("Wspolczynniki to");
            Wspolczynniki();
            Console.WriteLine($"Result of calculations of W_5({x}) is: {lagrange(x)}");
           
        }
    }
}
