namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            // фабричный метод
            JewelryFactory ringFactory = new RingFactory();
            JewelryFactory necklaceFactory = new NecklaceFactory();

            AbstractJewelry ring = ringFactory.CreateJewelry(10, 100, 15.0, "золото");
            AbstractJewelry necklace = necklaceFactory.CreateJewelry(20, 200, 50.0);

            ring.Display();
            necklace.Display();

            System.Console.WriteLine($"Полная стоимость кольца: {ring.GetFullPrice()}");
            System.Console.WriteLine($"Полная стоимость ожерелья: {necklace.GetFullPrice()}");

            // одиночка
            JewelryShopSingleton shop = JewelryShopSingleton.Instance;
            shop.J1 = new Jewelry(10, 15);
            shop.J2 = new Jewelry(20, 50);
            shop.Display();

            JewelryShopSingleton shop2 = JewelryShopSingleton.Instance;
            shop2.J1 = new Jewelry(5, 10);
            shop2.J2 = new Jewelry(10, 20);
            shop2.Display();

            if (shop == shop2)
            {
                System.Console.WriteLine("Есть только один объект");
            }
            else
            {
                System.Console.WriteLine("Есть несколько объектов");
            }

            // заместитель
            JewelryProxy proxy = new JewelryProxy(10, 100, 0.25);
            Console.WriteLine($"Полная стоимость: {proxy.GetFullPrice()}");
            proxy.Display();

            // адаптер
            // JewelryAdapter adapter = new JewelryAdapter();
            // BaseJewelry baseJewelry = new BaseJewelry(10, 100);
            // double fullPrice = adapter.FullPrice(baseJewelry);
            // System.Console.WriteLine($"Полная стоимость: {fullPrice}");

            // посетитель
            JewelryVisitor visitor = new JewelryVisitor(10, 100);
            JewelryWithVisitor jv = new JewelryWithVisitor();
            jv.Display();
            jv.Accept(visitor);
            jv.Display();

            // шаблонный метод
            BaseJewelry bsj = new BaseJewelry(15, 100);
            JewelryWithTax jwTax = new JewelryWithTax(20, 150, 0.25);
            bsj.Display();
            jwTax.Display();
            Console.WriteLine($"Полная стоимость: {bsj.FullPrice()}");
            Console.WriteLine($"Полная стоимость: {jwTax.FullPrice()}");
        }
    }
}