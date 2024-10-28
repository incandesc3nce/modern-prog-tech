public class Main {
    public static void main(String[] args) {
        Circle c1 = new Circle();
        Circle c2 = new Circle();

        c1.read();
        c1.display();

        c2.init(5, 3, 4);
        c2.display();

        Result res = new Result();
        c1.distance(res);
        System.out.println("Расстояние по значению: " + c1.distance());
        System.out.println("Расстояние по вспомогательному классу: " + res.distance);

        Circle c3 = Circle.add(c1, c2);
        System.out.println("Два аргумента: ");
        c3.display();

        System.out.println("Один аргумент: ");
        c1.add(c2).display();

        Circle q = new Circle();
        Circle w = new Circle(5);
        Circle e = new Circle(5, 3, 5);

        System.out.println("Расстояние из статического метода: ");
        System.out.println(Circle.staticDistance(c2));
    }
}