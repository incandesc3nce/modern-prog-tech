using System;

public class Program
{
    public static void Main(string[] args)
    {
        Circle[] circles = new Circle[3];

        Circle c1 = new Circle();
        Circle c2 = new Circle();
        Circle c3 = new Circle();

        c1.Init(4, 2, 1);
        c2.Init(3, -1, -2);
        c3.Init(5, 3, 4);

        circles[0] = c1;
        circles[1] = c2;
        circles[2] = c3;

        Circle totalCircle = new Circle();
        totalCircle.Init(0, 0, 0);

        for (int i = 0; i < circles.Length; i++) {
            totalCircle = totalCircle.Add(totalCircle, circles[i]);
        }

        totalCircle.Display();
    }
}
