using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            JewelryShop shop = new JewelryShop();

            shop.Read();

            shop.Display();

            Console.WriteLine("Общая стоимость всех украшений: " + shop.GetFullPrice());

            Console.WriteLine("Самое дорогое украшение:");
            shop.MostExpensiveJewelry().Display();
        }
    }
}
