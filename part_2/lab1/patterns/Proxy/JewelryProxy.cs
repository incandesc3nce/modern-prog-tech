namespace lab1
{
    public class JewelryProxy : AbstractJewelry
    {
        private Jewelry jewelry;
        private double discount;

        public JewelryProxy(double weight, double pricePerGramm, double discount) : base(weight, pricePerGramm)
        {
            this.discount = discount;
            jewelry = new Jewelry(weight, pricePerGramm);
        }

        public override void Display()
        {
            jewelry.Display();
            Console.WriteLine($"Скидка: {discount * 100}%");
        }

        public override double GetFullPrice()
        {
            return jewelry.GetFullPricePerGramm();
        }
    }
}