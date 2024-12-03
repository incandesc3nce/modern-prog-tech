using System;

namespace Task2
{
    [Serializable]
    public class Jewelry
    {
        public double weight = 1;
        public double pricePerGramm = 1;

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

        public static Jewelry operator +(Jewelry j1, Jewelry j2)
        {
            return new Jewelry
            {
                weight = j1.weight + j2.weight,
                pricePerGramm = (j1.pricePerGramm + j2.pricePerGramm) / 2
            };
        }

        public static Jewelry operator +(Jewelry j, double val)
        {
            return new Jewelry
            {
                weight = j.weight + val,
                pricePerGramm = j.pricePerGramm
            };
        }

        public static Jewelry operator +(double val, Jewelry j)
        {
            return new Jewelry
            {
                weight = j.weight + val,
                pricePerGramm = j.pricePerGramm
            };
        }

        public static Jewelry operator ++(Jewelry j)
        {
            ++j.pricePerGramm;
            return j;
        }
    }
}
