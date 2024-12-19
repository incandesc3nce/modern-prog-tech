using System;

namespace task1
{
public class Circle
{
    protected double radius;
    protected double x;
    protected double y;

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

    virtual public double Distance()
    {
        return Math.Sqrt(x * x + y * y);
    }

    public Circle Add(Circle c1, Circle c2)
    {
        Circle result = new Circle();
        result.Init(c1.radius + c2.radius, c1.x + c2.x, c1.y + c2.y);
        return result;
    }

    public Circle() {
        radius = 0;
        x = 0;
        y = 0;
    }

    public Circle(double r) {
        radius = r;
        x = 0;
        y = 0;
    }

    public Circle(double r, double arg_x, double arg_y) {
        radius = r;
        x = arg_x;
        y = arg_y;
    }

    public double GetRadius() {
        return radius;
    }

    public double GetX() {
        return x;
    }

    public double GetY() {
        return y;
    }
}
}