using System;

namespace lab1
{
    public abstract class AbstractJewelry
    {
        protected double weight;
        protected double pricePerGramm;

        public AbstractJewelry(double weight, double pricePerGramm)
        {
            this.weight = weight;
            this.pricePerGramm = pricePerGramm;
        }


        virtual public void Display()
        {
            Console.WriteLine($"Вес: {weight}");
            Console.WriteLine($"Цена за грамм: {pricePerGramm}");
        }

        public abstract double GetFullPrice();
    }
}