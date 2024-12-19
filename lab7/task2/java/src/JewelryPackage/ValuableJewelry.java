package JewelryPackage;

public class ValuableJewelry extends Jewelry {
    public double getFullPricePerGram() {
        return super.getFullPricePerGram() * 2;
    }

    public ValuableJewelry() {
        super();
    }

    public ValuableJewelry(double weight, double pricePerGram) {
        super(weight, pricePerGram);
    }
}
