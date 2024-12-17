#include <iostream>
#include "JewelryShop.cpp"
#include "Jewelry.cpp"
#include "ValuableJewelry.cpp"
#include <vector>
#include <string>

using namespace std;

int main() {
  JewelryShop shop;
  shop.init(new string("Магазин"), Jewelry(5, 100), 2, ValuableJewelry(5, 60), 3, 100);
  shop.display();
  cout << "Общая стоимость магазина: " << shop.getFullPrice() << endl;
  
  double jewelryPrice = shop.getJewelryPrice();
  cout << "Общая стоимость изделий: " << jewelryPrice << endl;

  return 0;
}
