public class Cylinder extends Circle {
    private double z;

    public double get() {
        return z;
    }

    public void put(double arg_z) {
        z = arg_z;
    }

    public double distance() {
        return (x + y) + (z / 2);
    }

    public void init(double r, double arg_x, double arg_y, double arg_z) {
        super.init(r, arg_x, arg_y);
        z = arg_z;
    }

    public void display() {
        super.display();
        System.out.println("Длина стороны z: " + z);
    }

    public Cylinder() {
        super();
        z = 0;
    }

    public Cylinder(double r) {
        super(r);
        z = 0;
    }

    public Cylinder(double r, double arg_x, double arg_y, double arg_z) {
        super(r, arg_x, arg_y);
        z = arg_z;
    }
}
