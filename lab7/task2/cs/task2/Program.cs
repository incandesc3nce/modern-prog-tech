using System;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseShop baseShop = new BaseShop();
            MixedShop mixedShop = new MixedShop();
            ValuableShop valuableShop = new ValuableShop();

            baseShop.Init("Магазин с обычными украшениями", new Jewelry(10, 100), 5, new Jewelry(20, 200), 10, 50);

            mixedShop.Init("Магазин с обычными и ценными украшениями", new Jewelry(20, 200), 5, new ValuableJewelry(30, 300), 10, 50);

            valuableShop.Init("Магазин с ценными украшениями", new ValuableJewelry(30, 300), 5, new ValuableJewelry(40, 400), 10, 50);

            baseShop.Display();
            Console.WriteLine("Общая стоимость магазина с обычными изделиями: " + baseShop.GetFullPrice());
            Console.WriteLine("Стоимость всех изделий магазина с обычными изделиями: " + baseShop.GetJewelryPrice() + "\n");

            mixedShop.Display();
            Console.WriteLine("Общая стоимость магазина с обычным и ценным изделиями: " + mixedShop.GetFullPrice());
            Console.WriteLine("Стоимость всех изделий магазина с обычным и ценным изделиями: " + mixedShop.GetJewelryPrice() + "\n");
            Console.WriteLine();

            valuableShop.Display();
            Console.WriteLine("Общая стоимость магазина с ценными изделиями: " + valuableShop.GetFullPrice());
            Console.WriteLine("Стоимость всех изделий магазина с ценными изделиями: " + valuableShop.GetJewelryPrice());
        }
    }
}
