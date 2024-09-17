using System;

public class Circle
{
    private double radius;
    private double x;
    private double y;

    public double Radius {
      get { return radius; }
      set { radius = value; }
    }

    public void Init(double r, double arg_x, double arg_y)
    {
        Radius = r;
        x = arg_x;
        y = arg_y;
    }

    public void Read()
    {
        Console.Write("Введите радиус: ");
        radius = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите координату x: ");
        x = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите координату y: ");
        y = Convert.ToDouble(Console.ReadLine());
    }

    public void Display()
    {
        Console.WriteLine($"Радиус: {radius}");
        Console.WriteLine($"Координата x: {x}");
        Console.WriteLine($"Координата y: {y}");
    }

    public double Distance()
    {
        return Math.Sqrt(x * x + y * y);
    }

    public Circle Add(Circle c)
    {
        Circle result = new Circle();
        result.Init(radius + c.radius, x + c.x, y + c.y);
        return result;
    }
}
