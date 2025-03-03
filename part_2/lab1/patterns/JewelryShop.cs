using System;

namespace lab1
{
    public class JewelryShop
    {
        private Jewelry jewelry1;
        private Jewelry jewelry2;
        private Jewelry jewelry3;
        private int count1;
        private int count2;
        private int count3;

        public double ExtraPrice { get; set; }

        private string name;

        public void Init(string arg_name, Jewelry j1, int c1, Jewelry j2, int c2, Jewelry j3, int c3, double arg_extraPrice)
        {
            jewelry1 = j1;
            jewelry2 = j2;
            jewelry3 = j3;

            count1 = c1;
            count2 = c2;
            count3 = c3;

            name = arg_name;
            ExtraPrice = arg_extraPrice;
        }

        public void Read()
        {
            Console.Write("Введите название магазина: ");
            name = Console.ReadLine();

            Console.Write("Введите количество украшений 1: ");
            count1 = Convert.ToInt32(Console.ReadLine());
            jewelry1 = new Jewelry();
            jewelry1.Read();

            Console.Write("Введите количество украшений 2: ");
            count2 = Convert.ToInt32(Console.ReadLine());
            jewelry2 = new Jewelry();
            jewelry2.Read();

            Console.Write("Введите количество украшений 3: ");
            count3 = Convert.ToInt32(Console.ReadLine());
            jewelry3 = new Jewelry();
            jewelry3.Read();

            Console.Write("Введите стоимость доп. аксессуаров: ");
            ExtraPrice = Convert.ToDouble(Console.ReadLine());
        }

        public void Display()
        {
            Console.WriteLine($"Название магазина: {name}");

            Console.WriteLine("Украшение 1:");
            jewelry1.Display();
            Console.WriteLine($"Количество: {count1}");

            Console.WriteLine("Украшение 2:");
            jewelry2.Display();
            Console.WriteLine($"Количество: {count2}");

            Console.WriteLine("Украшение 3:");
            jewelry3.Display();
            Console.WriteLine($"Количество: {count3}");

            Console.WriteLine($"Стоимость доп. аксессуаров: {ExtraPrice}");
        }

        public double GetFullPrice()
        {
            return jewelry1.GetFullPricePerGramm() * count1 +
                   jewelry2.GetFullPricePerGramm() * count2 +
                   jewelry3.GetFullPricePerGramm() * count3 +
                   ExtraPrice;
        }

        public Jewelry MostExpensiveJewelry()
        {
            double price1 = jewelry1.GetFullPricePerGramm();
            double price2 = jewelry2.GetFullPricePerGramm();
            double price3 = jewelry3.GetFullPricePerGramm();

            if (price1 > price2 && price1 > price3)
            {
                return jewelry1;
            }
            else if (price2 > price1 && price2 > price3)
            {
                return jewelry2;
            }
            return jewelry3;
        }
    }
}
