using System;

namespace Lab2
{
    public class JewelryShop
    {
        private Jewelry[] jewelry = new Jewelry[3];
        private int count1;
        private int count2;
        private int count3;

        public double extraPrice;

        private string name;

        public void Init(string arg_name, Jewelry[] jewelries, int c1, int c2, int c3, double arg_extraPrice)
        {
            jewelry = jewelries;

            count1 = c1;
            count2 = c2;
            count3 = c3;

            name = arg_name;
            extraPrice = arg_extraPrice;
        }

        public void Read()
        {
            Console.Write("Введите название магазина: ");
            name = Console.ReadLine();

            Console.Write("Введите количество украшений 1: ");
            count1 = Convert.ToInt32(Console.ReadLine());
            jewelry[0] = new Jewelry();
            jewelry[0].Read();

            Console.Write("Введите количество украшений 2: ");
            count2 = Convert.ToInt32(Console.ReadLine());
            jewelry[1] = new Jewelry();
            jewelry[1].Read();

            Console.Write("Введите количество украшений 3: ");
            count3 = Convert.ToInt32(Console.ReadLine());
            jewelry[2] = new Jewelry();
            jewelry[2].Read();

            Console.Write("Введите стоимость доп. аксессуаров: ");
            extraPrice = Convert.ToDouble(Console.ReadLine());
        }

        public void Display()
        {
            Console.WriteLine($"Название магазина: {name}");

            Console.WriteLine("Украшение 1:");
            jewelry[0].Display();
            Console.WriteLine($"Количество: {count1}");

            Console.WriteLine("Украшение 2:");
            jewelry[1].Display();
            Console.WriteLine($"Количество: {count2}");

            Console.WriteLine("Украшение 3:");
            jewelry[2].Display();
            Console.WriteLine($"Количество: {count3}");

            Console.WriteLine($"Стоимость доп. аксессуаров: {extraPrice}");
        }

        public double GetFullPrice()
        {
            double fullPrice = 0;
            
            for (int i = 0; i < count1; i++)
            {
                fullPrice += jewelry[1].GetFullPricePerGramm();
            }

            return fullPrice;
        }

        public Jewelry MostExpensiveJewelry()
        {
            Jewelry mostExpensive = jewelry[0];
            
            for (int i = 1; i < 3; i++)
            {
                if (jewelry[i].GetFullPricePerGramm() > mostExpensive.GetFullPricePerGramm())
                {
                    mostExpensive = jewelry[i];
                }
            }

            return mostExpensive;
        }
    }
}
