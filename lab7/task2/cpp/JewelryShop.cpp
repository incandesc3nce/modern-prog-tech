#include "Jewelry.cpp"
#include "ValuableJewelry.cpp"
#include <iostream>
#include <string> 

using namespace std;

// абстрактный основной класс
class JewelryShop {
  protected:
    int count1;
    int count2;
    double extraPrice;
    string* name;

  public:
    void init(string* name, int c1, int c2, double arg_extraPrice);

    void display();

    virtual double getFullPrice() = 0;

    virtual double getJewelryPrice() = 0;
};

// тип основного класса 1 - 2 базовых вспомогательных класса
class BaseShop: public JewelryShop {
  private:
    Jewelry j1;
    Jewelry j2;
  
  public:
    void init(string* arg_name, Jewelry arg_j1, int c1, Jewelry arg_j2, int c2, double arg_extraPrice);
    void display();
    double getFullPrice();
    double getJewelryPrice();
};

// тип основного класса 2 - 1 базовый и 1 производный классы
class MixedShop: public JewelryShop {
  private:
    Jewelry j1;
    ValuableJewelry j2;
  
  public:
    void init(string* arg_name, Jewelry arg_j1, int c1, ValuableJewelry arg_j2, int c2, double arg_extraPrice);
    void display();
    double getFullPrice();
    double getJewelryPrice();
};

// тип основного класса 3 - 2 производных класса
class ValuableShop: public JewelryShop {
  private:
    ValuableJewelry j1;
    ValuableJewelry j2;
  
  public:
    void init(string* arg_name, ValuableJewelry arg_j1, int c1, ValuableJewelry arg_j2, int c2, double arg_extraPrice);
    void display();
    double getFullPrice();
    double getJewelryPrice();
};


// определение методов


// методы абстрактного класса
void JewelryShop::init(string* arg_name, int c1, int c2, double arg_extraPrice) {
      count1 = c1;
      count2 = c2;

      name = arg_name;

      extraPrice = arg_extraPrice;
    };

void JewelryShop::display() {
  cout << "Название магазина: " << *(name) << endl;
  cout << "Стоимость доп. аксессуаров: " << extraPrice << endl;
  cout << "Количество украшений 1: " << count1 << endl;
  cout << "Количество украшений 2: " << count2 << endl;
};


// методы класса типа 1
void BaseShop::init(string* arg_name, Jewelry arg_j1, int c1, Jewelry arg_j2, int c2, double arg_extraPrice) {
  JewelryShop::init(arg_name, c1, c2, arg_extraPrice);
  j1 = arg_j1;
  j2 = arg_j2;
};

void BaseShop::display() {
  JewelryShop::display();
  cout << "Обычное украшение 1: " << endl;
  j1.display();
  cout << "Обычное украшение 2: " << endl;
  j2.display();
};

double BaseShop::getFullPrice() {
  return j1.getFullPricePerGramm() * count1 + j2.getFullPricePerGramm() * count2 + extraPrice;
};

double BaseShop::getJewelryPrice() {
  return j1.getFullPricePerGramm() + j2.getFullPricePerGramm();
};


// методы класса типа 2
void MixedShop::init(string* arg_name, Jewelry arg_j1, int c1, ValuableJewelry arg_j2, int c2, double arg_extraPrice) {
  JewelryShop::init(arg_name, c1, c2, arg_extraPrice);
  j1 = arg_j1;
  j2 = arg_j2;
};

void MixedShop::display() {
  JewelryShop::display();
  cout << "Обычное украшение 1: " << endl;
  j1.display();
  cout << "Ценное украшение 2: " << endl;
  j2.display();
};

double MixedShop::getFullPrice() {
  return j1.getFullPricePerGramm() * count1 + j2.getFullPricePerGramm() * count2 + extraPrice;
};

double MixedShop::getJewelryPrice() {
  return j1.getFullPricePerGramm() + j2.getFullPricePerGramm();
};


// методы класса типа 3
void ValuableShop::init(string* arg_name, ValuableJewelry arg_j1, int c1, ValuableJewelry arg_j2, int c2, double arg_extraPrice) {
  JewelryShop::init(arg_name, c1, c2, arg_extraPrice);
  j1 = arg_j1;
  j2 = arg_j2;
};

void ValuableShop::display() {
  JewelryShop::display();
  cout << "Ценное украшение 1: " << endl;
  j1.display();
  cout << "Ценное украшение 2: " << endl;
  j2.display();
};

double ValuableShop::getFullPrice() {
  return j1.getFullPricePerGramm() * count1 + j2.getFullPricePerGramm() * count2 + extraPrice;
};

double ValuableShop::getJewelryPrice() {
  return j1.getFullPricePerGramm() + j2.getFullPricePerGramm();
};
