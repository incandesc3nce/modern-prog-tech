using System;

namespace lab1
{
    public class JewelryWithTax: JewelryTemplate
    {
        private double taxRate;

        public JewelryWithTax(double weight, double pricePerGramm, double taxRate): base(weight, pricePerGramm)
        {
            this.taxRate = taxRate;
        }

        public void Display()
        {
            base.Display();
            Console.WriteLine($"Налог: {taxRate * 100}%");
        }

        public override double FullPrice()
        {
            return weight * pricePerGramm * (1 + taxRate);
        }
    }
}