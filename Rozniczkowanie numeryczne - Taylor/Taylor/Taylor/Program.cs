using System;

namespace Taylor
{
    public class Taylor
    {
        static double Rozniczkowanietaylor(double[] x, double[] y, double h) {
            double[,] tab = new double[x.Length, x.Length + 1];
            double fx = 0;
            double result;

            for (int i = 0; i < x.Length; i++)
            {
                tab[i, 0] = x[i];
                tab[i, 1] = y[i];
            }


            for (int j = 2; j < x.Length + 1; j++)
            {
                for (int i = x.Length - j; i >= 0; i--)
                {
                    tab[i, j] = tab[i + 1, j - 1] - tab[i, j - 1];
                }
                fx += tab[x.Length - j, j] / (j - 1);
            }
             result = fx* 1 / h;
            return result;
        }

        static void Main(string[] args)
        {

           // double[] x = { 0.0, 0.2, 0.4, 0.6, 0.8,1.0, 1.2 };

            //double[] y = { -21, -10.296, -2.728, 2.088, 4.536, 0.6984, 4.432 };

            double[] x = {-0.4,-0.2, 0.0, 0.2, 0.4, 0.6, 0.8, 1.0, 1.2 };

            double[] y = { -3.42, 0.983, - 21, -10.296, -2.728, 2.088, 4.536, 0.6984, 4.432};
            double h = 0.2;
            Console.WriteLine("Wynik to: "+Rozniczkowanietaylor(x, y, h));

        }
    }
}
