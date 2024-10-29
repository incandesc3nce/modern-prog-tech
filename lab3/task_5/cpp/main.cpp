#include <iostream>
#include "classes/JewelryShop.cpp"
#include "classes/Jewelry.cpp"
#include <vector>
#include <string>

using namespace std;

// вариант 22

int main() {
  vector<JewelryShop> shops;
  string names = "";
  
  for (int i = 0; i < 6; i++) {
    JewelryShop shop;
    shop.read();
    shops.push_back(shop);
    string name = shop.getName();
    if (name.length() >= 5) {
      name.replace(1, 4, "aa");
    }

    if (name.find("ccc")) {
      names += name;
    }
  }

  shops[0].setName(names);
  shops[0].display();

  return 0;
}
