using System;

namespace GaussElimination
{
    class Program
    {
        static double[] GaussEliminate(double[,] A, double[] b)
        {
            int n = b.Length;

            // Perform Gaussian elimination on the augmented matrix
            for (int i = 0; i < n; i++)
            {
                // Find the pivot row
                int pivot = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (Math.Abs(A[j, i]) > Math.Abs(A[pivot, i]))
                    {
                        pivot = j;
                    }
                }

                // Swap the pivot row with the current row
                for (int j = i; j < n; j++)
                {
                    double tmp = A[i, j];
                    A[i, j] = A[pivot, j];
                    A[pivot, j] = tmp;
                }
                double t = b[i];
                b[i] = b[pivot];
                b[pivot] = t;

                // Eliminate the current variable from the rows below
                for (int j = i + 1; j < n; j++)
                {
                    double factor = A[j, i] / A[i, i];
                    for (int k = i; k < n; k++)
                    {
                        A[j, k] -= factor * A[i, k];
                    }
                    b[j] -= factor * b[i];
                }
            }

            // Perform back substitution to find the solution
            double[] x = new double[n];
            for (int i = n - 1; i >= 0; i--)
            {
                double sum = 0;
                for (int j = i + 1; j < n; j++)
                {
                    sum += A[i, j] * x[j];
                }
                x[i] = (b[i] - sum) / A[i, i];
            }

            return x;
        }

        public static void Main(string[] args)
        {
            // Example: Solve the system of equations
            // 3x + 2y - z = 1
            // 2x - 2y + 4z = -2
            // -x + y/2 - z = 0
            double[,] A = { { 3, 2, -1 }, { 2, -2, 4 }, { -1, 1 / 2, -1 } };
            double[] b = { 1, -2, 0 };

            double[] x = GaussEliminate(A, b);
            Console.WriteLine("The solution is x = {0}, y = {1}, z = {2}", x[0], x[1], x[2]);
        }
    }
}
