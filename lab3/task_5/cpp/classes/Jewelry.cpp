#include <iostream>
#ifndef JEWELRY_H
#define JEWELRY_H
using namespace std;

class Jewelry {
  private: 
    double weight =1;
    double pricePerGramm =1;

  public:
    void init(double arg_weight, double arg_pricePerGramm);

    void read();

    void display();

    double getFullPricePerGramm();
};

  void Jewelry::init(double arg_weight, double arg_pricePerGramm) {
    weight = arg_weight;
    pricePerGramm = arg_pricePerGramm;
  }

  void Jewelry::read() {
    cout << "Введите вес в граммах: ";
    cin >> weight;
    cout << "Введите цену за грамм: ";
    cin >> pricePerGramm;
  }

  void Jewelry::display() {
    cout << "Вес: " << weight << endl;
    cout << "Цена за грамм: " << pricePerGramm << endl;
  }

  double Jewelry::getFullPricePerGramm() {
    return weight * pricePerGramm;
  }

#endif