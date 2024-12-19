#include <iostream>
#include "JewelryShop.cpp"
#include "Jewelry.cpp"
#include "ValuableJewelry.cpp"
#include <string>

using namespace std;

int main() {
  BaseShop baseShop;
  MixedShop mixedShop;
  ValuableShop valuableShop;

  baseShop.init(new string("Магазин с обычными изделиями"), Jewelry(10, 100), 2, Jewelry(15, 160), 5, 200);
  mixedShop.init(new string("Магазин с обычным и ценным изделиями"), Jewelry(15, 70), 3, ValuableJewelry(20, 180), 4, 300);
  valuableShop.init(new string("Магазин с ценными изделиями"), ValuableJewelry(5, 120), 4, ValuableJewelry(25, 220), 3, 400);

  baseShop.display();
  cout << "Общая стоимость магазина с обычными изделиями: " << baseShop.getFullPrice() << endl;
  cout << "Стоимость всех изделий магазина с обычными изделиями: " << baseShop.getJewelryPrice() << endl << endl;

  mixedShop.display();
  cout << "Общая стоимость магазина с обычным и ценным изделиями: " << mixedShop.getFullPrice() << endl;
  cout << "Стоимость всех изделий магазина с обычным и ценным изделиями: " << mixedShop.getJewelryPrice() << endl << endl;

  valuableShop.display();
  cout << "Общая стоимость магазина с ценными изделиями: " << valuableShop.getFullPrice() << endl;
  cout << "Стоимость всех изделий магазина с ценными изделиями: " << valuableShop.getJewelryPrice() << endl;

  return 0;
}
