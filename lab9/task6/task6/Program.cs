using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DoubleComparer: IComparer<double>
{
  public int Compare(double x, double y)
  {
    bool xGreater = x > 1.5;
    bool yGreater = y > 1.5;

    if (xGreater && !yGreater) {
      return -1;
    }
    if (!xGreater && yGreater) {
      return 1;
    }

    if (xGreater && yGreater) {
      return x.CompareTo(y);
    } else {
      return y.CompareTo(x);
    }
    
  }
}

class Program
{
  static void Main(string[] args)
  {
    List<double> a = new List<double>();
    string[] input = File.ReadAllLines("input.txt");
    foreach (string line in input)
    {
      a.Add(double.Parse(line));
    }

    Console.WriteLine("Коллекция до сортировки: ");
    foreach (double item in a)
    {
      Console.Write(item + " ");
    }

    DoubleComparer dc = new DoubleComparer();
    a.Sort(dc);
    Console.WriteLine("\nКоллекция после сортировки: ");
    foreach (double item in a)
    {
      Console.Write(item + " ");
    }
  }
}