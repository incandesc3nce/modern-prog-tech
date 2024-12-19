package JewelryPackage;

import java.util.Scanner;

// абстрактный класс
abstract class JewelryShop {
    protected int count1;
    protected int count2;
    protected double extraPrice;
    protected String name;

    public void init(String name, int c1, int c2, double extraPrice) {
        this.count1 = c1;
        this.count2 = c2;
        this.name = name;
        this.extraPrice = extraPrice;
    }

    public void display() {
        System.out.println("Название магазина: " + name);

        System.out.println("Количество украшений 1: " + count1);
        System.out.println("Количество украшений 2: " + count2);

        System.out.println("Стоимость доп. аксессуаров: " + extraPrice);
    }

    abstract double getFullPrice();

    abstract double getJewelryPrice();
}
