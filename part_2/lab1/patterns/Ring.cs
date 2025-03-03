using System;

namespace lab1
{
    public class Ring : AbstractJewelry
    {
        private double size;
        private string material;

        public Ring(double weight, double pricePerGramm, double size, string material) : base(weight, pricePerGramm)
        {
            this.size = size;
            this.material = material;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Размер: {size}");
            Console.WriteLine($"Материал: {material}");
        }

        public override double GetFullPrice()
        {
            int multiplier = 1;
            switch (material)
            {
                case "золото":
                    multiplier = 3;
                    break;
                case "серебро":
                    multiplier = 2;
                    break;
                default:
                    break;
            }
            return weight * pricePerGramm * multiplier;
        }
    }
}