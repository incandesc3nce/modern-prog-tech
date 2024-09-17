#include <iostream>
#include "JewelryShop.cpp"
#include "Jewelry.cpp"

using namespace std;

// вариант 22

int main() {
  JewelryShop shop;
  
  shop.read(); 
  shop.display();
  cout << shop.getFullPrice() << endl;
  shop.mostExpensiveJewelry().display();

  return 0;
}
