#include "Jewelry.cpp"
#include "ValuableJewelry.cpp"
#include <iostream>
#include <string> 

using namespace std;

class JewelryShop {
  private:
    Jewelry jewelry;
    ValuableJewelry valuableJewelry;
    int count1;
    int count2;
    double extraPrice;
    string* name;

  public:
    void init(string* name, Jewelry j1, int c1, ValuableJewelry j2, int c2, double arg_extraPrice);

    void read();

    void display();

    double getFullPrice();

    double getJewelryPrice();
};

void JewelryShop::init(string* arg_name, Jewelry j1, int c1, ValuableJewelry j2, int c2, double arg_extraPrice) {
      jewelry = j1;
      valuableJewelry = j2;

      count1 = c1;
      count2 = c2;

      name = arg_name;

      extraPrice = arg_extraPrice;
    };

void JewelryShop::display() {
  cout << "Название магазина: " << *(name) << endl;

  cout << "Обычное украшение: " << endl;
  jewelry.display();
  cout << "Количество: " << count1 << endl;

  cout << "Ценное украшение: " << endl;
  valuableJewelry.display();
  cout << "Количество: " << count2 << endl;

  cout << "Стоимость доп. аксессуаров: " << extraPrice << endl;
};

double JewelryShop::getFullPrice() {
  return jewelry.getFullPricePerGramm() * count1 + valuableJewelry.getFullPricePerGramm() * count2 + extraPrice;
};

double JewelryShop::getJewelryPrice() {
  double price1 = jewelry.getFullPricePerGramm();
  double price2 = valuableJewelry.getFullPricePerGramm();

  return price1 + price2;
};
