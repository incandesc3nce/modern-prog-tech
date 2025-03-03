namespace lab1
{
    public sealed class JewelryShopSingleton
    {
        public static int Number = 0;
        private static JewelryShopSingleton instance = new JewelryShopSingleton();
        private Jewelry j1;
        private Jewelry j2;
        private JewelryShopSingleton()
        {
            Number++;
        }

        public Jewelry J1
        {
            get
            {
                return j1;
            }
            set
            {
                j1 = value;
            }
        }

        public Jewelry J2
        {
            get
            {
                return j2;
            }
            set
            {
                j2 = value;
            }
        }

        public double GetFullPrice()
        {
            return j1.GetFullPricePerGramm() + j2.GetFullPricePerGramm();
        }

        public void Display()
        {
            j1.Display();
            j2.Display();
            Console.WriteLine($"Полная стоимость: {GetFullPrice()}");
            Console.WriteLine($"Количество созданных магазинов: {Number}");
        }

        public static JewelryShopSingleton Instance
        {
            get
            {
                return instance;
            }
        }
    }
}