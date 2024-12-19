#include <iostream>
#ifndef JEWELRY_H
#define JEWELRY_H
using namespace std;

class Jewelry {
  protected: 
    double weight;
    double pricePerGramm;

  public:
    void init(double arg_weight, double arg_pricePerGramm);

    void read();

    void display();

    double getFullPricePerGramm();

    Jewelry();
    
    Jewelry(double arg_weight, double arg_pricePerGramm);
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

  Jewelry::Jewelry() {
    weight = 1;
    pricePerGramm = 1;
  }

  Jewelry::Jewelry(double arg_weight, double arg_pricePerGramm) {
    weight = arg_weight;
    pricePerGramm = arg_pricePerGramm;
  }

#endif