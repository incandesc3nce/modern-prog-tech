import java.util.Scanner;

public class Jewelry {
    private double weight = 1;
    private double pricePerGram = 1;

    public void init(double weight, double pricePerGram) {
        this.weight = weight;
        this.pricePerGram = pricePerGram;
    }

    public void read() {
        Scanner sc = new Scanner(System.in);
        System.out.print("Введите вес в граммах: ");
        this.weight = sc.nextDouble();
        System.out.print("Введите цену за грамм: ");
        this.pricePerGram = sc.nextDouble();
    }

    public void display() {
        System.out.println("Вес: " + weight);
        System.out.println("Цена за грамм: " + pricePerGram);
    }

    public double getFullPricePerGram() {
        return weight * pricePerGram;
    }
}
