package JewelryPackage;

public class ValuableShop extends JewelryShop {
    private ValuableJewelry j1;
    private ValuableJewelry j2;

    public void init(String name, int c1, int c2, double extraPrice, ValuableJewelry j1, ValuableJewelry j2) {
        super.init(name, c1, c2, extraPrice);
        this.j1 = j1;
        this.j2 = j2;
    }

    public void display() {
        super.display();
        System.out.println("Ценное украшение 1:");
        j1.display();
        System.out.println("Ценное украшение 2:");
        j2.display();
    }

    public double getFullPrice() {
        return count1 * j1.getFullPricePerGram() + count2 * j2.getFullPricePerGram() + extraPrice;
    }

    public double getJewelryPrice() {
        return j1.getFullPricePerGram() + j2.getFullPricePerGram();
    }
}
