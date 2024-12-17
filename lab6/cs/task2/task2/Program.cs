using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            JewelryShop shop = new JewelryShop();
            shop.Init("Магазин", new Jewelry(10, 100), 5, new ValuableJewelry(20, 200), 3, 50);
            shop.Display();
            Console.WriteLine("Общая стоимость: " + shop.GetFullPrice());

            double jewelryPrice = shop.getJewelryPrice();
            Console.WriteLine("Стоимость изделий: " + jewelryPrice);
        }
    }
}
