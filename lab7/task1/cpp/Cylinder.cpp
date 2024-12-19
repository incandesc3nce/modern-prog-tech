#include <iostream>
#include "Circle.cpp"
using namespace std;

class Cylinder: public Circle {
  private:
    double z;

  public:
  // методы Cylinder
    double Get();
    void Put(double z);

  // перегруженные методы Circle
    double distance();
    void Init(double r, double x, double y, double z);
    void Display();

  // конструкторы Cylinder
    Cylinder();
    Cylinder(double r);
    Cylinder(double r, double x, double y, double z);

  // присваивание
    void operator=(Circle c);

  // метод, с использованием виртуального метода
    void shiftCenter();
};

double Cylinder::Get() {
  return z;
}

void Cylinder::Put(double newZ) {
  z = newZ;
}

double Cylinder::distance() {
  return (x + y) + (z / 2);
}

void Cylinder::Init(double r, double arg_x, double arg_y, double arg_z) {
  Circle::Init(r, arg_x, arg_y);
  z = arg_z;
}

void Cylinder::Display() {
  Circle::Display();
  cout << "Длина стороны z: " << z << endl;
}

Cylinder::Cylinder(): Circle() {
  z = 0;
}

Cylinder::Cylinder(double r): Circle(r) {
  z = 0;
}

Cylinder::Cylinder(double r, double x, double y, double arg_z): Circle(r, x, y) {
  z = arg_z;
}

void Cylinder::operator=(Circle c) {
  radius = c.getRadius();
  x = c.getX();
  y = c.getY();
  z = radius / 2;
}

void Cylinder::shiftCenter() {
  double Z = distance();
  x += 5 * Z;
}