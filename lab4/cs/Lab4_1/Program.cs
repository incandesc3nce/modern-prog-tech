using System;

namespace Lab4_1 {

public class Program
{ 
  public static double Distance(double x, double y, double r)
    {
        return Math.Sqrt(x * x + y * y);
    }

  public static double nearestPointDistance(double x, double y, double r) {
    double distanceToCenter = Math.Sqrt(x * x + y + y);
    
    return distanceToCenter - r;
  }

  public delegate double DistanceDelegate(double x, double y, double r);

    public static void Main(string[] args)
    {
        DistanceDelegate distance = Distance;

        Circle c1 = new Circle();
        c1.Init(1, 4, 4);

        double x = c1.GetX();
        double y = c1.GetY();
        double r = c1.GetRadius();

        double distanceToCenter = distance(x, y, r);
        distance = nearestPointDistance;
        double distanceToNearestPoint = distance(x, y, r);

        Console.WriteLine($"Расстояние до центра: {distanceToCenter}");
        Console.WriteLine($"Расстояние до ближайшей точки: {distanceToNearestPoint}");
    }
}
}