using System;
public class Program
{

    public static double Wielomian(double x, int stopienwielomianu)
    {

        double[] tablicawielomianow = new double[stopienwielomianu + 1];
        for (int i = 0; i <= stopienwielomianu; i++)
        {
            Console.WriteLine("Podaj wartosc wielomianu x" + i);
            tablicawielomianow[i] = double.Parse(Console.ReadLine());
        }
        Console.WriteLine("Wielomian to:");
        for (int i = 0; i <= stopienwielomianu; i++)
        {
            Console.WriteLine("Wartosc wielomianu x" + i + " to " + tablicawielomianow[i]);

        }
        double wynik = tablicawielomianow[stopienwielomianu];
        for (int i = stopienwielomianu - 1; i >= 0; i--)
        {
            wynik = wynik * x + tablicawielomianow[i];
        }
        return wynik;
    }
    public static void Main()
    {
        Console.WriteLine("Podaj stopien wielomianu");
        int stopienwielomianu = int.Parse(Console.ReadLine());
        Console.WriteLine("Podaj x");
        double x = double.Parse(Console.ReadLine());
        Console.WriteLine("Wielomian W" + stopienwielomianu + "(" + x + ") = " + Wielomian(x, stopienwielomianu));
        Console.ReadKey();
    }
}