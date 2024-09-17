#include "Jewelry.cpp"
#include <iostream>

using namespace std;

class JewelryShop {
  private:
    Jewelry* jewelry = new Jewelry[3];

    int count1;
    int count2;
    int count3;

    double extraPrice;
    char name[100];

  public:
    void init(char name[], Jewelry jewelries[], int c1, int c2, int c3, double arg_extraPrice);

    void read();

    void display();

    double getFullPrice();

    Jewelry mostExpensiveJewelry();
};

void JewelryShop::init(char arg_name[], Jewelry jewelries[], int c1, int c2, int c3, double arg_extraPrice) {
      for (int i = 0; i < 3; i++) {
        jewelry[i] = jewelries[i];
      }
      
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
      jewelry[0].read();

      cout << "Введите количество украшений 2: ";
      cin >> count2;
      jewelry[1].read();

      cout << "Введите количество украшений 3: ";
      cin >> count3;
      jewelry[2].read();

      cout << "Введите стоимость доп. аксессуаров: ";
      cin >> extraPrice;
    };

void JewelryShop::display() {
  cout << "Название магазина: " << name << endl;

  cout << "Украшение 1: " << endl;
  jewelry[0].display();
  cout << "Количество: " << count1 << endl;

  cout << "Украшение 2: " << endl;
  jewelry[1].display();
  cout << "Количество: " << count2 << endl;

  cout << "Украшение 3: " << endl;
  jewelry[2].display();
  cout << "Количество: " << count3 << endl;

  cout << "Стоимость доп. аксессуаров: " << extraPrice << endl;
};

double JewelryShop::getFullPrice() {
  double fullPrice = 0;
  
  for (int i = 0; i < 3; i++) {
    fullPrice += jewelry[i].getFullPricePerGramm();
  }

  return fullPrice;
};

Jewelry JewelryShop::mostExpensiveJewelry() {
  Jewelry mostExpensive = jewelry[0];

  for (int i = 1; i < 3; i++) {
    if (jewelry[i].getFullPricePerGramm() > mostExpensive.getFullPricePerGramm()) {
      mostExpensive = jewelry[i];
    }
  }

  return mostExpensive;
};
