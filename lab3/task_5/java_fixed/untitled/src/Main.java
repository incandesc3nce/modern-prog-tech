public class Main {
    public static void main(String[] args) {
        JewelryShop[] shops = new JewelryShop[6];

        for (int i = 0; i < shops.length; i++) {
            shops[i] = new JewelryShop();
            shops[i].read();

            String shopName = shops[i].getName();
            if (shopName.length() >= 3) {
                String newName = shopName.charAt(0) + shopName.substring(3) + shopName.charAt(1) + shopName.charAt(2);
                shops[i].setName(newName);
            }
            System.out.println(shops[i].getName());
        }
    }
}
