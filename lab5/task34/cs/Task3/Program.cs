using System;

namespace Task3 {

public class Program
{ 

    public static void Main(string[] args)
    {
        const int N = 6;
        const int M = 3;

        double[,] a = new double[N, M];
        Circle.Arr2(a, N, M);

        for (int i = 0; i < N; ++i)
        {
            for (int j = 0; j < M; ++j)
            {
                Console.Write(a[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
}