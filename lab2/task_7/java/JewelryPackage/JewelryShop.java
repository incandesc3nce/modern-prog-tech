package JewelryPackage;

import java.util.Scanner;

public class JewelryShop {
    private Jewelry[] jewelry = new Jewelry[3];
    private int count1;
    private int count2;
    private int count3;
    private double extraPrice;
    private String name;

    public void init(String name, Jewelry[] jewelries, int c1, int c2, int c3, double extraPrice) {
        jewelry = jewelries;
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

        System.out.print("Введите количество украшений 1: ");
        this.count1 = sc.nextInt();
        if (jewelry[0] == null) {
            jewelry[0] = new Jewelry();
        }
        jewelry[0].read();

        System.out.print("Введите количество украшений 2: ");
        this.count2 = sc.nextInt();
        if (jewelry[1] == null) {
            jewelry[1] = new Jewelry();
        }
        jewelry[1].read();

        System.out.print("Введите количество украшений 3: ");
        this.count3 = sc.nextInt();
        if (jewelry[2] == null) {
            jewelry[2] = new Jewelry();
        }
        jewelry[2].read();

        System.out.print("Введите стоимость доп. аксессуаров: ");
        this.extraPrice = sc.nextDouble();
    }

    public void display() {
        System.out.println("Название магазина: " + name);

        System.out.println("Украшение 1: ");
        jewelry[0].display();
        System.out.println("Количество: " + count1);

        System.out.println("Украшение 2: ");
        jewelry[1].display();
        System.out.println("Количество: " + count2);

        System.out.println("Украшение 3: ");
        jewelry[2].display();
        System.out.println("Количество: " + count3);

        System.out.println("Стоимость доп. аксессуаров: " + extraPrice);
    }

    public double getFullPrice() {
        double fullPrice = 0;

        for (int i = 0; i < 3; i++) {
            fullPrice += jewelry[i].getFullPricePerGram();
        }
        
        return fullPrice;
    }

    public Jewelry mostExpensiveJewelry() {
        Jewelry mostExpensive = jewelry[0];

        for (int i = 1; i < 3; i++) {
            if (jewelry[i].getFullPricePerGram() > mostExpensive.getFullPricePerGram()) {
                mostExpensive = jewelry[i];
            }
        }

        return mostExpensive;
    }
}