package JewelryPackage;

import java.util.Scanner;

public class JewelryShop {
    private Jewelry jewelry;
    private ValuableJewelry valuableJewelry;
    private int count1;
    private int count2;
    private double extraPrice;
    private String name;

    public void init(String name, Jewelry j1, int c1, ValuableJewelry j2, int c2, double extraPrice) {
        this.jewelry = j1;
        this.valuableJewelry = j2;
        this.count1 = c1;
        this.count2 = c2;
        this.name = name;
        this.extraPrice = extraPrice;
    }

    public void read() {
        Scanner sc = new Scanner(System.in);
        System.out.print("Введите название магазина: ");
        this.name = sc.nextLine();

        System.out.print("Введите количество украшений 1: ");
        this.count1 = sc.nextInt();
        jewelry.read();

        System.out.print("Введите количество украшений 2: ");
        this.count2 = sc.nextInt();
        valuableJewelry.read();

        System.out.print("Введите стоимость доп. аксессуаров: ");
        this.extraPrice = sc.nextDouble();
    }

    public void display() {
        System.out.println("Название магазина: " + name);

        System.out.println("Обычное украшение: ");
        jewelry.display();
        System.out.println("Количество: " + count1);

        System.out.println("Ценное украшение: ");
        valuableJewelry.display();
        System.out.println("Количество: " + count2);

        System.out.println("Стоимость доп. аксессуаров: " + extraPrice);
    }

    public double getFullPrice() {
        return jewelry.getFullPricePerGram() * count1 +
                valuableJewelry.getFullPricePerGram() * count2 + +
                extraPrice;
    }

    public double getJewelryPrice() {
        return jewelry.getFullPricePerGram() +
                valuableJewelry.getFullPricePerGram();
    }
}