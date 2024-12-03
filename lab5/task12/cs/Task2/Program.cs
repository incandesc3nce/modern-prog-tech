using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Jewelry[] jewerlies = new Jewelry[3];
            for (int i = 0; i < 3; i++)
            {
                jewerlies[i] = new Jewelry();
                jewerlies[i].Init(i + 5, i + 1);
            }
            // Сериализация массива объектов Jewelry
            FileStream fs1 = new FileStream("jewerlies.bin", FileMode.Create);
            formatter.Serialize(fs1, jewerlies);
            fs1.Close();
            Console.WriteLine("Объект jewelries сериализован");

            // Десериализация
            fs1 = new FileStream("jewerlies.bin", FileMode.Open);
            Jewelry[] d = (Jewelry[])formatter.Deserialize(fs1);
            Console.WriteLine("Объект jewelries десериализован");
            fs1.Close();


            JewelryShop shop = new JewelryShop();
            shop.Init("Магазин", d[0], 1, d[1], 2, d[2], 3, 100);
            // Сериализация объекта JewelryShop
            XmlSerializer xmlFormatter = new XmlSerializer(typeof(JewelryShop));
            FileStream fs2 = new FileStream("shop.xml", FileMode.Create);
            xmlFormatter.Serialize(fs2, shop);
            fs2.Close();
            Console.WriteLine("Объект shop сериализован");
            fs2 = new FileStream("shop.xml", FileMode.Open);
            JewelryShop d2 = (JewelryShop)xmlFormatter.Deserialize(fs2);
            Console.WriteLine("Объект shop десериализован");
            fs2.Close();
        }
    }
}
