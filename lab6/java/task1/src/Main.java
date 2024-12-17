public class Main {
    public static void main(String[] args) {
        Cylinder cylinder = new Cylinder();

        cylinder.init(1, 2, 3, 4);
        cylinder.display();

        System.out.println("Расстояние от центра до центра: " + cylinder.distance());

        cylinder = new Cylinder(5);
        cylinder.display();

        cylinder = new Cylinder(6, 7, 8, 9);
        cylinder.display();
        System.out.println("Расстояние от центра до центра: " + cylinder.distance());
    }
}