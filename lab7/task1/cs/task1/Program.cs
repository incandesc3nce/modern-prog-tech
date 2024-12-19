using System;

namespace task1 {

public class Program
{
    public static void Main(string[] args)
    {   
        // вызов метода для смещения центра
        Cylinder c = new Cylinder(2, 4, 5, 3);
        c.Display();
        Console.WriteLine($"Расстояние от центра до центра: {c.Distance()}");
        c.ShiftCenter();
        Console.WriteLine("После смещения центра по оси OX:");
        c.Display();

        // демонстрация
        Circle a = new Circle(3, 4, 5);
        Cylinder b = new Cylinder(3, 4, 5, 3);
        a = b;
        double dist = a.Distance();
        Console.WriteLine("Метод Distance() виртуальный.\n");
        Console.WriteLine($"Расстояние от начала координат до центра: {dist}");
    }
}
}
