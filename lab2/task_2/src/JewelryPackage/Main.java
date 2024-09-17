package JewelryPackage;

public class Main {
    public static void main(String[] args) {
        JewelryShop shop = new JewelryShop();

        shop.read();
        shop.display();
        System.out.println("Полная стоимость: " + shop.getFullPrice());
        System.out.println("Самое дорогое украшение:");
        shop.mostExpensiveJewelry().display();
    }
}
