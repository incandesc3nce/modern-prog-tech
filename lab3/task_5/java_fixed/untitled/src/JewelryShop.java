import java.util.Scanner;

public class JewelryShop {
    private Jewelry jewelry1 = new Jewelry();
    private Jewelry jewelry2 = new Jewelry();
    private Jewelry jewelry3 = new Jewelry();
    private int count1 = 1;
    private int count2 = 1;
    private int count3 = 1;
    private double extraPrice = 1;
    private String name;

    public void init(String name, Jewelry j1, int c1, Jewelry j2, int c2, Jewelry j3, int c3, double extraPrice) {
        this.jewelry1 = j1;
        this.jewelry2 = j2;
        this.jewelry3 = j3;
        this.count1 = c1;
        this.count2 = c2;
        this.count3 = c3;
        this.name = name;
        this.extraPrice = extraPrice;
    }

    public void read() {
        Scanner sc = new Scanner(System.in);
        System.out.print("Введите название магазина: ");
        this.name = sc.nextLine();

//        System.out.print("Введите количество украшений 1: ");
//        this.count1 = sc.nextInt();
//        jewelry1.read();
//
//        System.out.print("Введите количество украшений 2: ");
//        this.count2 = sc.nextInt();
//        jewelry2.read();
//
//        System.out.print("Введите количество украшений 3: ");
//        this.count3 = sc.nextInt();
//        jewelry3.read();
//
//        System.out.print("Введите стоимость доп. аксессуаров: ");
//        this.extraPrice = sc.nextDouble();
    }

    public void display() {
        System.out.println("Название магазина: " + name);

        System.out.println("Украшение 1: ");
        jewelry1.display();
        System.out.println("Количество: " + count1);

        System.out.println("Украшение 2: ");
        jewelry2.display();
        System.out.println("Количество: " + count2);

        System.out.println("Украшение 3: ");
        jewelry3.display();
        System.out.println("Количество: " + count3);

        System.out.println("Стоимость доп. аксессуаров: " + extraPrice);
    }

    public double getFullPrice() {
        return jewelry1.getFullPricePerGram() * count1 +
                jewelry2.getFullPricePerGram() * count2 +
                jewelry3.getFullPricePerGram() * count3 +
                extraPrice;
    }

    public Jewelry mostExpensiveJewelry() {
        double price1 = jewelry1.getFullPricePerGram();
        double price2 = jewelry2.getFullPricePerGram();
        double price3 = jewelry3.getFullPricePerGram();

        if (price1 > price2 && price1 > price3) {
            return jewelry1;
        } else if (price2 > price1 && price2 > price3) {
            return jewelry2;
        }
        return jewelry3;
    }

    public String getName() {
        return this.name;
    }

    public void setName(String newName) {
        this.name = newName;
    }
}