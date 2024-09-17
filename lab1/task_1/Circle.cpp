#include <iostream>
using namespace std;

class Circle {
  private:
    double radius;
    double x;
    double y;

  public:
    void Init(double r, double x, double y);

    void Read();

    void Display();

    double distance();

    Circle add(Circle c1, Circle c2);

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