#include "Jewelry.cpp"
#include <iostream>

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
    char name[100];

  public:
    void init(char name[], Jewelry j1, int c1, Jewelry j2, int c2, Jewelry j3, int c3, double arg_extraPrice);

    void read();

    void display();

    double getFullPrice();

    Jewelry mostExpensiveJewelry();
};

void JewelryShop::init(char arg_name[], Jewelry j1, int c1, Jewelry j2, int c2, Jewelry j3, int c3, double arg_extraPrice) {
      jewelry1 = j1;
      jewelry2 = j2;
      jewelry3 = j3;

      count1 = c1;
      count2 = c2;
      count3 = c3;

      strcpy(name, arg_name);

      extraPrice = arg_extraPrice;
    };

    void JewelryShop::read() {
      cout << "Введите название магазина: ";
      cin >> name;

      cout << "Введите количество украшений 1: ";
      cin >> count1;
      jewelry1.read();

      cout << "Введите количество украшений 2: ";
      cin >> count2;
      jewelry2.read();

      cout << "Введите количество украшений 3: ";
      cin >> count3;
      jewelry3.read();

      cout << "Введите стоимость доп. аксессуаров: ";
      cin >> extraPrice;
    };

void JewelryShop::display() {
  cout << "Название магазина: " << name << endl;

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
