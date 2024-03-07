using System;


namespace aproksymacja
{
    class Program
    {
        static void Aproksymacja(double[] X, double[] Y,int m)
        {


            int n = X.Length;

            double S = 0, S1 = 0, S2 = 0, T = 0, T2 = 0;
            for (int i = 0; i < n; i++)
            {
                S += m;
                S1 += X[i];
                S2 += X[i] * X[i];
                T += Y[i];
                T2 += X[i] * Y[i];
            }
            double wartosc = (S * S2) - (S1 * S1);
            double wartosc1 = (T * S2) - (S1 * T2);
            double watosc2 = (S * T2) - (T * S1);
            double x = watosc2 / wartosc;
            double wyrazwolny = wartosc1 / wartosc;
            Console.WriteLine("Wyraz wolny wynosi "+ wyrazwolny);
            Console.WriteLine("Wspolczynnik x wynosi "+ x);
         
        }
        static void Main(string[] args)
        {
            int m = 1;
            double[] X = { 9.11, 9.95, 8.90, 9.22, 8.74, 8.98, 8.77, 9.31 };
            double[] Y = { 55.65, 67.68, 105.2, 85.02, 52.76, 56.86, 72.19, 61.09 };
            Aproksymacja(X,Y,m);
            //double[] X = { 9.11, 9.95, 8.90, 9.22, 8.74, 8.98, 8.77, 9.31, 9.79, 8.97 };
            //double[] Y = { 55.65, 67.68, 105.2, 85.02, 52.76, 56.86, 72.19, 61.09 , 73.54, 67.72 };
            //Aproksymacja(X, Y, m);
        }

    }
}
