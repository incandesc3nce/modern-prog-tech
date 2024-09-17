using System;

public class Program
{
    public static void Main(string[] args)
    {
        Circle c1 = new Circle();
        c1.Init(5, 1, 2);
        c1.Display();
        Console.WriteLine("Distance: " + c1.Distance());

        Circle[] circleArray = new Circle[3];
        for (int i = 0; i < circleArray.Length; i++)
        {
            circleArray[i] = new Circle();
            circleArray[i].Read();
            circleArray[i].Display();
        }

        Circle c2 = new Circle();
        c2.Init(0, 0, 0);

        for (int i = 0; i < circleArray.Length; i++)
        {
            c2 = c2.Add(circleArray[i]);
        }

        c2.Display();
    }
}
