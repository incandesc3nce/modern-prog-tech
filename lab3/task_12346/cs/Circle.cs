using System;

namespace Lab3 {

public class Circle
{
    private double radius;
    private double x;
    private double y;

    public double Radius {
      get { return radius; }
      set { radius = value; }
    }

    public double X {
      get { return x; }
      set { x = value; }
    }

    public double Y {
      get { return y; }
      set { y = value; }
    }

    public Circle()
    {
        radius = 0;
        x = 0;
        y = 0;
    }

    public Circle(double r)
    {
        radius = r;
        x = 0;
        y = 0;
    }

    public Circle(double r, double arg_x, double arg_y)
    {
        radius = r;
        x = arg_x;
        y = arg_y;
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
      try {
        if (radius < 0) {
          throw new Exception("Радиус не может быть отрицательным");
        }
        if (radius == 0) {
          throw new Exception("Радиус не может быть равен нулю");
        }
      } catch (Exception e) {
        Console.WriteLine(e.Message);
        return 0;
      }
        return Math.Sqrt(x * x + y * y);
    }

    public static double StaticDistance(Circle c)
    {
        return Math.Sqrt(c.x * c.x + c.y * c.y);
    }

    public void CircleRef(ref double distance)
    {
        distance = Math.Sqrt(x * x + y * y);
    }

    public void CircleOut(out double distance)
    {
        distance = Math.Sqrt(x * x + y * y);
    }

    public static Circle Add(Circle c1, Circle c2)
    {
        Circle result = new Circle();
        result.Init(c1.radius + c2.radius, c1.x + c2.x, c1.y + c2.y);
        return result;
    }

    public Circle add(Circle c)
    {
        Circle result = new Circle();
        result.Init(this.radius + c.radius, this.x + c.x, this.y + c.y);
        return result;
    }
}
}
