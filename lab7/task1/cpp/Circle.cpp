#include <iostream>
using namespace std;

class Circle {
  protected:
    double radius;
    double x;
    double y;

  public:
    void Init(double r, double x, double y);

    void Read();

    void Display();

    virtual double distance();

    Circle add(Circle c1, Circle c2);
    Circle();
    Circle(double r);
    Circle(double r, double x, double y);

    double getRadius();
    double getX();
    double getY();

    // метод, с использованием виртуального метода
    void shiftCenter();
};

  void Circle::Init(double r, double arg_x, double arg_y) {
    radius = r;
    x = arg_x;
    y = arg_y;
  }

  void Circle::Read() {
    cout << "Введите радиус:";
    cin >> radius;
    cout << "Введите координату x:";
    cin >> x;
    cout << "Введите координату y:";
    cin >> y;
  }

  void Circle::Display() {
    cout << "Радиус: " << radius << endl;
    cout << "Координата x: " << x << endl;
    cout << "Координата y: " << y << endl;
  }

  double Circle::distance() {
    return sqrt(x * x + y * y);
  }

  Circle Circle::add(Circle c1, Circle c2) {
    Circle result;
    result.Init(c1.radius + c2.radius, c1.x + c2.x, c1.y + c2.y);
    return result;
  }

  Circle::Circle() {
    radius = 0;
    x = 0;
    y = 0;
  }

  Circle::Circle(double r) {
    radius = r;
    x = 0;
    y = 0;
  }

  Circle::Circle(double r, double arg_x, double arg_y) {
    radius = r;
    x = arg_x;
    y = arg_y;
  }

  double Circle::getRadius() {
    return radius;
  }

  double Circle::getX() {
    return x;
  }

  double Circle::getY() {
    return y;
  }

  void Circle::shiftCenter() {
    double Z = distance();
    x += 5 * Z;
  }