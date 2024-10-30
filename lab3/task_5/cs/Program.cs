using System;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            JewelryShop[] shops = new JewelryShop[6];
            int CONST_LEN = 4;

            for (int i = 0; i < shops.Length; i++)
            {
                shops[i] = new JewelryShop();
                shops[i].Read();

                string shopName = shops[i].GetName();
                string[] words = shopName.Split(' ');

                var shortWords = words.Where(word => word.Length < CONST_LEN);
                var longWords = words.Where(word => word.Length >= CONST_LEN);

                string newName = string.Join(" ", shortWords) + " " + string.Join(" ", longWords);

                shops[i].SetName(newName);
                Console.WriteLine(shops[i].GetName());
            }
        }
    }
}
