namespace task1 {
public class Cylinder: Circle {
  private double z;

  public double Get() {
    return z;
  }

  public void Put(double arg_z) {
    z = arg_z;
  }

  public double Distance() {
    return x + y + (z / 2);
  }

  public void Init(double r, double arg_x, double arg_y, double arg_z) {
    base.Init(r, arg_x, arg_y);
    z = arg_z;
  }

  public void Display() {
    base.Display();
    Console.WriteLine($"Координата z: {z}");
  }

  public Cylinder(): base() {
    z = 0;
  }

  public Cylinder(double r): base(r) {
    z = 0;
  }

  public Cylinder(double r, double arg_x, double arg_y, double arg_z): base(r, arg_x, arg_y) {
    z = arg_z;
  }

  public void ShiftCenter()
  {
    double Z = Distance();
    x += 5 * Z;
  }

}
}