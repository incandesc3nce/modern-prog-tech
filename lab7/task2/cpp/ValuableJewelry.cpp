#include <iostream>
#include "Jewelry.cpp"
#ifndef VALUABLEJEWELRY_H
#define VALUABLEJEWELRY_H
using namespace std;

class ValuableJewelry : public Jewelry {
  public:
    double getFullPricePerGramm();

    ValuableJewelry();
    ValuableJewelry(double arg_weight, double arg_pricePerGramm);
};

double ValuableJewelry::getFullPricePerGramm() {
  return Jewelry::getFullPricePerGramm() * 2;
}

ValuableJewelry::ValuableJewelry() : Jewelry() {}

ValuableJewelry::ValuableJewelry(double arg_weight, double arg_pricePerGramm) : Jewelry(arg_weight, arg_pricePerGramm) {}

#endif
