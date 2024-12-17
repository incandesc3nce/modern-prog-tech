using System;

namespace task2
{
    public class JewelryShop
    {
        private Jewelry jewelry;
        private ValuableJewelry valuableJewelry;
        private int count1;
        private int count2;

        public double extraPrice;

        private string name;

        public void Init(string arg_name, Jewelry arg_jewelry, int c1, ValuableJewelry arg_valuableJewelry, int c2, double arg_extraPrice)
        {
            jewelry = arg_jewelry;
            valuableJewelry = arg_valuableJewelry;

            count1 = c1;
            count2 = c2;

            name = arg_name;
            extraPrice = arg_extraPrice;
        }

        public void Read()
        {
            Console.Write("Введите название магазина: ");
            name = Console.ReadLine();

            Console.Write("Введите количество украшений 1: ");
            count1 = Convert.ToInt32(Console.ReadLine());
            jewelry = new Jewelry();
            jewelry.Read();

            Console.Write("Введите количество украшений 2: ");
            count2 = Convert.ToInt32(Console.ReadLine());
            valuableJewelry = new ValuableJewelry();
            valuableJewelry.Read();

            Console.Write("Введите стоимость доп. аксессуаров: ");
            extraPrice = Convert.ToDouble(Console.ReadLine());
        }

        public void Display()
        {
            Console.WriteLine($"Название магазина: {name}");

            Console.WriteLine("Обычное украшение:");
            jewelry.Display();
            Console.WriteLine($"Количество: {count1}");

            Console.WriteLine("Ценное украшение:");
            valuableJewelry.Display();
            Console.WriteLine($"Количество: {count2}");

            Console.WriteLine($"Стоимость доп. аксессуаров: {extraPrice}");
        }

        public double GetFullPrice()
        {
            return jewelry.GetFullPricePerGramm() * count1 + valuableJewelry.GetFullPricePerGramm() * count2 + extraPrice;
        }

        public double getJewelryPrice() {
            return jewelry.GetFullPricePerGramm() + valuableJewelry.GetFullPricePerGramm();
        }
    }
}
