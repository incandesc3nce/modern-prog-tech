using System;

namespace Lab3 {
  public class Program
  {
    public static void Main(string[] args)
    {
     Circle circle1 = new Circle();
      circle1.Read();
      circle1.Display();
      Circle circle2 = new Circle(5, 1, 4);
      circle2.Display();

      Circle added = circle1.add(circle2); 
      added.Display();

      double distance = added.Distance();
      double distanceRef = 0; // ининциализация для ref обязательна
      double distnaceOut; // инициализация для out не обязательна

      added.CircleRef(ref distanceRef); // выдаст ошибку если не инициализировать ref
      added.CircleOut(out distnaceOut);
      
      Console.WriteLine("Расстояние: " + distance);
      Console.WriteLine("Расстояние через ref: " + distanceRef);
      Console.WriteLine("Расстояние через out: " + distnaceOut);

      Circle circle3 = Circle.Add(circle1, circle2);
      Console.WriteLine("Два аргумента: ");
      circle3.Display();

      Console.WriteLine("Один аргумент: ");
      circle1.add(circle2).Display();

      Circle q = new Circle();
      Circle w = new Circle(5);
      Circle e = new Circle(5, 1, 1);

      Console.WriteLine("Расстояние через статический метод: ");
      Console.WriteLine(Circle.StaticDistance(circle2));

      double result = 0;
      try {
        circle1.CircleRef(ref result);
        Console.WriteLine("Расстояние через ref: " + result);
      } catch (Exception ex) {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
