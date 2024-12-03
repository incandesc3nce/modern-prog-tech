using System;

namespace Task3 {
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

    public double GetX()
    {
        return x;
    }

    public double GetY()
    {
        return y;
    }

    public double GetRadius()
    {
        return radius;
    }

    public Circle Add(Circle c1, Circle c2)
    {
        Circle result = new Circle();
        result.Init(c1.radius + c2.radius, c1.x + c2.x, c1.y + c2.y);
        return result;
    }

    public override string ToString() {
        return $"Радиус: {radius}\nКоордината x: {x}\nКоордината y: {y}";
    }

    static public void Arr(double []a, int n, double []b, int m) {
        for (int i = 0; i < n; ++i) {
            a[i] = 1.0;
            for (int j = 1; j <= i; ++j) {
                a[i] += (double)(j + 1) / j;
            }
        }

        for (int i = 0; i < m; ++i) {
            b[i] = Math.Sin(a[i]) + i * i;
        }
    }
}
}