using System;

namespace Task3 {

public class Program
{ 

    public static void Main(string[] args)
    {
        const int N = 8;
        const int M = 5;
        double[] a = new double[N];
        double[] b = new double[M];
        Circle.Arr(a, N, b, M);

        for (int i = 0; i < N; ++i)
        {
            Console.Write(a[i] + " ");
        }
        Console.WriteLine();

        for (int i = 0; i < M; ++i)
        {
            Console.Write(b[i] + " ");
        }
        Console.WriteLine();

    }
}
}