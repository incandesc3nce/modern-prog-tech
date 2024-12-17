package JewelryPackage;

public class Main {
    public static void main(String[] args) {
        JewelryShop shop = new JewelryShop();
        shop.init("Магазин украшений", new Jewelry(2, 50), 2, new ValuableJewelry(3, 100), 1, 1000);
        shop.display();
        System.out.println("Общая стоимость: " + shop.getFullPrice());

        double jewelryPrice = shop.getJewelryPrice();
        System.out.println("Стоимость украшений: " + jewelryPrice);
    }
}
