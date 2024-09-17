public class Main {
    public static void main(String[] args) {
        Circle[] circles = new Circle[3];

        Circle c1 = new Circle();
        Circle c2 = new Circle();
        Circle c3 = new Circle();

        c1.init(4, 2, 1);
        c2.init(3, -1, -2);
        c3.init(5, 3, 4);

        circles[0] = c1;
        circles[1] = c2;
        circles[2] = c3;

        Circle totalCircle = new Circle();
        totalCircle.init(0, 0, 0);

        for (Circle circle : circles) {
            totalCircle = totalCircle.add(totalCircle, circle);
        }

        totalCircle.display();
    }
}