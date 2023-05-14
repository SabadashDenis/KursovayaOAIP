using System;

class SimpleIteration
{
    static double[] Solve(double[,] A, double[] b, double epsilon = 1e-4, int maxIterations = 1000)
    {
        int n = A.GetLength(0);
        double[] x = new double[n];
        double[] xPrev = new double[n];

        for (int iteration = 0; iteration < maxIterations; iteration++)
        {
            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        sum += A[i, j] * xPrev[j];
                    }
                }
                x[i] = (b[i] - sum) / A[i, i];
            }

            double error = 0;
            for (int i = 0; i < n; i++)
            {
                error += Math.Abs(x[i] - xPrev[i]);
            }

            if (error < epsilon)
            {
                break;
            }

            Array.Copy(x, xPrev, n);
        }

        return x;
    }


    static void Main(string[] args)
    {
        string cont = "No";
        int size = 2;
        double[,] A;
        double[] b;

        for (; ; )
        {
            Console.Write("Размерность исходной матрицы: ");
            size = Convert.ToInt32(Console.ReadLine());

            A = new double[size, size];
            b = new double[size];

            Console.WriteLine($"Введите матрицу А размерностью {size}x{size}:");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Строка {i+1}: ");
                double[] numbers = Console.ReadLine().Split(' ').Select(s => double.Parse(s)).ToArray();
                for (int j = 0; j < size; j++)
                {
                    A[i, j] = numbers[j];
 
                }
            }

            Console.WriteLine($"\nВведите столбец B размерностью {size}:");
            for(int i = 0; i < size; i++)
            {
                Console.Write($"Строка {i+1}: ");
                b[i]= Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine();

            double[] x = Solve(A, b);

            Console.WriteLine("Ответ:");
            for (int i = 0; i < x.Length; i++)
            {
                Console.WriteLine($"x{i + 1} = {Math.Round(x[i], 5)}");
            }

            Console.WriteLine("Повторить ввод? (Yes/No): ");
            cont = Console.ReadLine();

            if (cont != "Yes")
                break;
        }
    }
}
