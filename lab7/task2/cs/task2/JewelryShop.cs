using System;

namespace task2
{
    // абстрактный класс
    abstract public class JewelryShop
    {
        protected int count1;
        protected int count2;

        public double extraPrice;

        private string name;

        public void Init(string arg_name, int c1, int c2, double arg_extraPrice)
        {
            count1 = c1;
            count2 = c2;

            name = arg_name;
            extraPrice = arg_extraPrice;
        }

        public void Read() {
            Console.WriteLine("Введите название магазина:");
            name = Console.ReadLine();

            Console.WriteLine("Введите количество украшений 1:");
            count1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите количество украшений 2:");
            count2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите стоимость доп. аксессуаров:");
            extraPrice = double.Parse(Console.ReadLine());
        }

        public void Display()
        {
            Console.WriteLine($"Название магазина: {name}");
            Console.WriteLine($"Количество украшений 1: {count1}");
            Console.WriteLine($"Количество украшений 2: {count2}");

            Console.WriteLine($"Стоимость доп. аксессуаров: {extraPrice}");
        }

        public abstract double GetFullPrice();

        public abstract double GetJewelryPrice();
    }

    // класс типа 1 - два базовых класса
    public class BaseShop: JewelryShop {
        private Jewelry j1;
        private Jewelry j2;

        public void Init(string arg_name, Jewelry j1, int c1, Jewelry j2, int c2, double arg_extraPrice)
        {
            base.Init(arg_name, c1, c2, arg_extraPrice);
            this.j1 = j1;
            this.j2 = j2;
        }

        public void Read() {
            base.Read();

            Console.WriteLine("Введите информацию об украшении 1:");
            j1.Read();

            Console.WriteLine("Введите информацию об украшении 2:");
            j2.Read();
        }

        public void Display()
        {
            base.Display();
            Console.WriteLine("Обычное украшение 1:");
            j1.Display();
            Console.WriteLine("Обычное украшение 2:");
            j2.Display();
        }

        public override double GetFullPrice()
        {
            return j1.GetFullPricePerGramm() * count1 + j2.GetFullPricePerGramm() * count2 + extraPrice;
        }

        public override double GetJewelryPrice()
        {
            return j1.GetFullPricePerGramm() + j2.GetFullPricePerGramm();
        }
    }

    // класс типа 2 - один базовый и один производный класс
    public class MixedShop: JewelryShop {
        private Jewelry j1;
        private ValuableJewelry j2;

        public void Init(string arg_name, Jewelry j1, int c1, ValuableJewelry j2, int c2, double arg_extraPrice)
        {
            base.Init(arg_name, c1, c2, arg_extraPrice);
            this.j1 = j1;
            this.j2 = j2;
        }

        public void Read() {
            base.Read();

            Console.WriteLine("Введите информацию об украшении:");
            j1.Read();

            Console.WriteLine("Введите информацию о ценном украшении:");
            j2.Read();
        }

        public void Display()
        {
            base.Display();
            Console.WriteLine("Обычное украшение:");
            j1.Display();
            Console.WriteLine("Ценное украшение:");
            j2.Display();
        }

        public override double GetFullPrice()
        {
            return j1.GetFullPricePerGramm() * count1 + j2.GetFullPricePerGramm() * count2 + extraPrice;
        }

        public override double GetJewelryPrice()
        {
            return j1.GetFullPricePerGramm() + j2.GetFullPricePerGramm();
        }
    }

    // класс типа 3 - два производных класса
    public class ValuableShop: JewelryShop {
        private ValuableJewelry j1;
        private ValuableJewelry j2;

        public void Init(string arg_name, ValuableJewelry j1, int c1, ValuableJewelry j2, int c2, double arg_extraPrice)
        {
            base.Init(arg_name, c1, c2, arg_extraPrice);
            this.j1 = j1;
            this.j2 = j2;
        }

        public void Read() {
            base.Read();

            Console.WriteLine("Введите информацию о ценном украшении 1:");
            j1.Read();

            Console.WriteLine("Введите информацию о ценном украшении 2:");
            j2.Read();
        }

        public void Display()
        {
            base.Display();
            Console.WriteLine("Ценное украшение 1:");
            j1.Display();
            Console.WriteLine("Ценное украшение 2:");
            j2.Display();
        }

        public override double GetFullPrice()
        {
            return j1.GetFullPricePerGramm() * count1 + j2.GetFullPricePerGramm() * count2 + extraPrice;
        }

        public override double GetJewelryPrice()
        {
            return j1.GetFullPricePerGramm() + j2.GetFullPricePerGramm();
        }
    }
}

