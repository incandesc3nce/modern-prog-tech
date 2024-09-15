public class Main {
    public static void main(String[] args) {
        Circle c1 = new Circle();
        Circle[] circleArray = new Circle[3];

        for (int i = 0; i < circleArray.length; i++) {
            circleArray[i] = new Circle();
        }

        c1.init(5, 1, 2);
        c1.display();
        System.out.println(c1.distance());

        for (Circle circle : circleArray) {
            circle.read();
            circle.display();
        }

        Circle c2 = new Circle();
        c2.init(0, 0, 0);

        for (Circle circle : circleArray) {
            c2 = c2.add(c2, circle);
        }

        c2.display();
    }
}