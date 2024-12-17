import java.util.Scanner;

public class Circle {
    protected double radius;
    protected double x;
    protected double y;

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

    double getRadius() {
        return radius;
    }

    double getX() {
        return x;
    }

    double getY() {
        return y;
    }
}
