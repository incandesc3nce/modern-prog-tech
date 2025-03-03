using System;

namespace lab1
{
    public class Necklace : AbstractJewelry
    {
        private double length;

        public Necklace(double weight, double pricePerGramm, double length) : base(weight, pricePerGramm)
        {
            this.length = length;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Длина: {length}");
        }

        public override double GetFullPrice()
        {
            return weight * pricePerGramm * length;
        }
    }
}