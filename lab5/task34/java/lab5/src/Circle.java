import java.util.Scanner;

class Result {
    public double distance;
}

public class Circle {
    private double radius;
    private double x;
    private double y;

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

    public void init(double r, double arg_x, double arg_y) {
        try {
            if (r < 0) {
                throw new Exception("Радиус не может быть отрицательным!");
            }
            if (r == 0) {
                throw new Exception("Радиус не может быть равен нулю!");
            }
        } catch (Exception e) {
            System.out.println(e.getMessage());
            System.exit(0);
        }

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

//    public void display() {
//        System.out.println("Радиус: " + radius);
//        System.out.println("Координата x: " + x);
//        System.out.println("Координата y: " + y);
//    }

    public double distance() {
        try {
            if (radius < 0) {
                throw new Exception("Радиус не может быть отрицательным!");
            }
            if (radius == 0) {
                throw new Exception("Радиус не может быть равен нулю!");
            }
        } catch (Exception e) {
            System.out.println(e.getMessage());
            return 0;
        }
        return Math.sqrt(x * x + y * y);
    }

    public static double staticDistance(Circle c) {
        try {
            if (c.radius < 0) {
                throw new Exception("Радиус не может быть отрицательным!");
            }
            if (c.radius == 0) {
                throw new Exception("Радиус не может быть равен нулю!");
            }
        } catch (Exception e) {
            System.out.println(e.getMessage());
            return 0;
        }
        return Math.sqrt(c.x * c.x + c.y * c.y);
    }

    public void distance(Result res) {
        try {
            if (radius < 0) {
                throw new Exception("Радиус не может быть отрицательным!");
            }
            if (radius == 0) {
                throw new Exception("Радиус не может быть равен нулю!");
            }
        } catch (Exception e) {
            System.out.println(e.getMessage());
            res.distance = 0;
            return;
        }
        res.distance = Math.sqrt(x * x + y * y);
    }

    public static double distance(Circle c1, Circle c2) {
        return Math.sqrt((c1.x - c2.x) * (c1.x - c2.x) + (c1.y - c2.y) * (c1.y - c2.y));
    }

    public static Circle add(Circle c1, Circle c2) {
        Circle result = new Circle();
        result.init(c1.radius + c2.radius, c1.x + c2.x, c1.y + c2.y);
        return result;
    }

    public Circle add(Circle c) {
        Circle result = new Circle();
        result.init(this.radius + c.radius, this.x + c.x, this.y + c.y);
        return result;
    }

    public String toString() {
        return "Радиус: " + radius + "\nКоордината x: " + x + "\nКоордината y: " + y;
    }

    public static void arr(double a[], int n, double b[], int m) {
        for (int i = 0; i < n; ++i) {
            a[i] = 1.0;
            for (int j = 1; j <= i; ++j) {
                a[i] += (double)(j + 1) / j;
            }
        }

        for (int i = 0; i < m; ++i) {
            b[i] = Math.sin(a[i]) + i * i;
        }
    }
}
