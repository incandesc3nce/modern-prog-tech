using System;

namespace Task1 {

public class Program
{ 

    public static void Main(string[] args)
    {
        Circle c1 = new Circle();
        c1.Init(5, 1, 2);

        Console.WriteLine(c1.ToString());
    }
}
}