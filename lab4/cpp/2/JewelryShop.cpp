#include "Jewelry.cpp"
#include <iostream>
#include <string> 

using namespace std;

class JewelryShop {
  private:
    Jewelry jewelry1;
    Jewelry jewelry2;
    Jewelry jewelry3;
    int count1;
    int count2;
    int count3;
    double extraPrice;
    string* name;

  public:
    void init(string* name, Jewelry j1, int c1, Jewelry j2, int c2, Jewelry j3, int c3, double arg_extraPrice);

    void read();

    void display();

    double getFullPrice();

    Jewelry mostExpensiveJewelry();

    JewelryShop();

    JewelryShop(const JewelryShop &shop);

    JewelryShop& operator=(JewelryShop &shop);
};

void JewelryShop::init(string* arg_name, Jewelry j1, int c1, Jewelry j2, int c2, Jewelry j3, int c3, double arg_extraPrice) {
      jewelry1 = j1;
      jewelry2 = j2;
      jewelry3 = j3;

      count1 = c1;
      count2 = c2;
      count3 = c3;

      name = arg_name;

      extraPrice = arg_extraPrice;
    };

void JewelryShop::display() {
  cout << "Название магазина: " << *(name) << endl;

  cout << "Украшение 1: " << endl;
  jewelry1.display();
  cout << "Количество: " << count1 << endl;

  cout << "Украшение 2: " << endl;
  jewelry2.display();
  cout << "Количество: " << count2 << endl;

  cout << "Украшение 3: " << endl;
  jewelry3.display();
  cout << "Количество: " << count3 << endl;

  cout << "Стоимость доп. аксессуаров: " << extraPrice << endl;
};

double JewelryShop::getFullPrice() {
  return jewelry1.getFullPricePerGramm() * count1 + jewelry2.getFullPricePerGramm() * count2 + jewelry3.getFullPricePerGramm() * count3 + extraPrice;
};

Jewelry JewelryShop::mostExpensiveJewelry() {
  double price1 = jewelry1.getFullPricePerGramm();
  double price2 = jewelry2.getFullPricePerGramm();
  double price3 = jewelry3.getFullPricePerGramm();

  if (price1 > price2 && price1 > price3) {
    return jewelry1;
  } else if (price2 > price1 && price2 > price3) {
    return jewelry2;
  } 
  return jewelry3;
};

JewelryShop::JewelryShop() {
  name = new string("Магазин");
  jewelry1 = Jewelry();
  jewelry2 = Jewelry();
  jewelry3 = Jewelry();
  count1 = 1;
  count2 = 1;
  count3 = 1;
  extraPrice = 0;
};

JewelryShop::JewelryShop(const JewelryShop &shop) {
  // this->name = shop.name; // мелкое копирование
  this->name = new string (*(shop.name)); // глубокое копирование
  this->jewelry1 = shop.jewelry1;
  this->jewelry2 = shop.jewelry2;
  this->jewelry3 = shop.jewelry3;

  this->count1 = shop.count1;
  this->count2 = shop.count2;
  this->count3 = shop.count3;

  this->extraPrice = shop.extraPrice;
};

JewelryShop& JewelryShop::operator=(JewelryShop &shop) {
  if (this == &shop) {
    return *this;
  }

  delete name;
  this->name = shop.name; // мелкое копирование
  // this->name = new string (*(shop.name)); // глубокое копирование

  this->jewelry1 = shop.jewelry1;
  this->jewelry2 = shop.jewelry2;
  this->jewelry3 = shop.jewelry3;

  this->count1 = shop.count1;
  this->count2 = shop.count2;
  this->count3 = shop.count3;

  return *this;
}
