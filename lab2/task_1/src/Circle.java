import java.util.Scanner;

public class Circle {
    private double radius;
    private double x;
    private double y;

    public void init(double r, double arg_x, double arg_y) {
        radius = r;
        x = arg_x;
        y = arg_y;
    }

    public void read() {
        Scanner sc = new Scanner(System.in);
        System.out.print("Введите радиус: ");
        radius = sc.nextDouble();
        System.out.print("Введите координату x: ");
        x = sc.nextDouble();
        System.out.print("Введите координату y: ");
        y = sc.nextDouble();
    }

    public void display() {
        System.out.println("Радиус: " + radius);
        System.out.println("Координата x: " + x);
        System.out.println("Координата y: " + y);
    }

    public double distance() {
        return Math.sqrt(x * x + y * y);
    }

    public Circle add(Circle c1, Circle c2) {
        Circle result = new Circle();
        result.init(c1.radius + c2.radius, c1.x + c2.x, c1.y + c2.y);
        return result;
    }
}
