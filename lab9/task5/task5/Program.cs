using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList a = new ArrayList();
            Random rand = new Random();

            for (int i = 0; i < 15; i++) {
                if (rand.Next(0, 2) == 0) {
                    a.Add(new Jewelry(rand.Next(1, 100), rand.Next(1, 100)));
                } else {
                    a.Add(new ValuableJewelry(rand.Next(1, 100), rand.Next(1, 100)));
                }
            }

            int jewelryCount = 0;
            int valuableJewelryCount = 0;

            double jewelryPrice = 0;
            double valuableJewelryPrice = 0;
            for (int i = 0; i < a.Count; i++) {
                System.Type type = a[i].GetType();
                if (type == typeof(Jewelry)) {
                    ((Jewelry)a[i]).Display();
                    jewelryCount++;
                    jewelryPrice += ((Jewelry)a[i]).GetFullPricePerGramm();
                } else {
                    ((ValuableJewelry)a[i]).Display();
                    valuableJewelryCount++;
                    valuableJewelryPrice += ((ValuableJewelry)a[i]).GetFullPricePerGramm();
                }
            }

            Console.WriteLine($"Количество обычных украшений: {jewelryCount}");
            Console.WriteLine($"Количество ценных украшений: {valuableJewelryCount}");
            Console.WriteLine($"Общая стоимость обычных украшений: {jewelryPrice}");
            Console.WriteLine($"Общая стоимость ценных украшений: {valuableJewelryPrice}");
        }
    }
}
