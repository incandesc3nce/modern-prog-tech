#include <iostream>
#include "JewelryShop.cpp"
#include "Jewelry.cpp"
#include <vector>
#include <string>

using namespace std;

// вариант 22

int main() {
  JewelryShop shop1;
  string* name = new string("Магазин 1");
  shop1.init(name, Jewelry(), 1, Jewelry(), 2, Jewelry(), 3, 100);
  shop1.display();

  JewelryShop shop2 = JewelryShop(shop1); // глубокое копирование

  cout << endl << "Магазин 2 (глубокое копирование):" << endl;
  shop2.display();

  *name = "Магазин 3";
  shop1.init(name, Jewelry(), 2, Jewelry(), 3, Jewelry(), 4, 200);

  cout << endl << "После изменения названия:" << endl;
  
  cout << "Магазин 1:" << endl;
  shop1.display();

  cout << "Магазин 2:" << endl;
  shop2.display();

  JewelryShop* shop4 = new JewelryShop();
  shop4->display();

  JewelryShop* shop5 = new JewelryShop(); // глубокое копирование
  *shop5 = *shop4;
  cout << endl << "Магазин 5 (глубокое копирование):" << endl;
  shop5->display();

  *name = "Магазин 6";

  shop4->init(name, Jewelry(), 3, Jewelry(), 4, Jewelry(), 5, 300);

  cout << endl << "После изменения названия:" << endl;

  cout << "Магазин 4:" << endl;
  shop4->display();

  cout << "Магазин 5:" << endl;
  shop5->display();

  return 0;
}
