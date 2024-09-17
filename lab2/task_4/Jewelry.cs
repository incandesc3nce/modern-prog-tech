using System;

namespace Task_4
{
    public class Jewelry
    {
        private double weight;
        private double pricePerGramm;

        public void Init(double arg_weight, double arg_pricePerGramm)
        {
            weight = arg_weight;
            pricePerGramm = arg_pricePerGramm;
        }

        public void Read()
        {
            Console.Write("Введите вес в граммах: ");
            weight = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите цену за грамм: ");
            pricePerGramm = Convert.ToDouble(Console.ReadLine());
        }


        public void Display()
        {
            Console.WriteLine($"Вес: {weight}");
            Console.WriteLine($"Цена за грамм: {pricePerGramm}");
        }

        public double GetFullPricePerGramm()
        {
            return weight * pricePerGramm;
        }
    }
}
