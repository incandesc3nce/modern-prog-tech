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
        Console.WriteLine("Метод Distance() не виртуальный.\n");
        a.ShiftCenter();
        Console.WriteLine("После смещения центра по оси OX:");
        Console.WriteLine("Circle:");
        a.Display();
        Console.WriteLine("Cylinder:");
        b.Display();
        Console.WriteLine($"Расстояние от начала координат до центра (Circle): {a.Distance()}");
        Console.WriteLine($"Расстояние от начала координат до центра (Cylinder): {b.Distance()}");
    }
}
}
