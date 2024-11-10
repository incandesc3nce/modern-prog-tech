using System;

namespace Lab4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Jewelry j1 = new Jewelry();
            j1.Init(10, 100);

            Jewelry j2 = new Jewelry();
            j2.Init(5, 50);

            Jewelry j3 = j1 + j2;
            Console.WriteLine("Сложение двух объектов:");
            j3.Display();

            Console.WriteLine("Сложение объекта и числа:");
            j3 = j1 + 5;
            j3.Display();

            j3 = 10 + j1;
            j3.Display();

            Console.WriteLine("Сложение 2 объектов и числа:");
            j3 = j1 + j2 + 5;
            j3.Display();
            
            j1.Init(10, 100);
            j3 = j1++;
            Console.WriteLine("Постфиксный инкремент:");
            j3.Display();

            j1.Init(10, 100);
            j3 = ++j1;
            Console.WriteLine("Префиксный инкремент:");
            j3.Display();
        }
    }
}
