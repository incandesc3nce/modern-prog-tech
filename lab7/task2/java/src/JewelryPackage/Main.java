package JewelryPackage;

public class Main {
    public static void main(String[] args) {
        BaseShop baseShop = new BaseShop();
        MixedShop mixedShop = new MixedShop();
        ValuableShop valuableShop = new ValuableShop();

        baseShop.init("Магазин с обычными украшениями", 10, 20, 100, new Jewelry(10, 100), new Jewelry(20, 200));
        mixedShop.init("Магазин с обычным и ценным украшениями", 30, 40, 200, new Jewelry(30, 300), new ValuableJewelry(40, 400));
        valuableShop.init("Магазин с ценными украшениями", 50, 60, 300, new ValuableJewelry(50, 500), new ValuableJewelry(60, 600));

        baseShop.display();
        System.out.println("Общая стоимость магазина с обычными изделиями: " + baseShop.getFullPrice());
        System.out.println("Стоимость всех изделий магазина с обычными изделиями: " + baseShop.getJewelryPrice() + "\n");

        mixedShop.display();
        System.out.println("Общая стоимость магазина с обычным и ценным изделиями: " + mixedShop.getFullPrice());
        System.out.println("Стоимость всех изделий магазина с обычным и ценным изделиями: " + mixedShop.getJewelryPrice() + "\n");
        System.out.println();

        valuableShop.display();
        System.out.println("Общая стоимость магазина с ценными изделиями: " + valuableShop.getFullPrice());
        System.out.println("Стоимость всех изделий магазина с ценными изделиями: " + valuableShop.getJewelryPrice());
    }
}
