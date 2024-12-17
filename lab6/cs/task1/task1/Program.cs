using System;

namespace task1 {

public class Program
{
    public static void Main(string[] args)
    {
        Cylinder c1 = new Cylinder();

        c1.Init(1, 2, 3, 4);
        c1.Display();

        Console.WriteLine($"Расстояние от центра до точки: {c1.Distance()}");

        c1 = new Cylinder(5);
        c1.Display();

        c1 = new Cylinder(6, 7, 8, 9);
        c1.Display();
        Console.WriteLine($"Расстояние от центра до точки: {c1.Distance()}");
    }
}
}
