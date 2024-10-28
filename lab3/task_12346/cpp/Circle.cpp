#include <iostream>
using namespace std;

class Circle {
  private:
    double radius;
    double x;
    double y;

  public:
    Circle();
    Circle(double r);
    Circle(double r, double x, double y);

    void Init(double r, double x, double y);
    void Read();
    void Display();

    double distance();
    void distance(double& d);
    void distance(double* d);
    static double staticDistance(Circle c);

    static Circle staticAdd(Circle c1, Circle c2);
    Circle add(Circle c2);
};

  Circle::Circle() {
    this->Init(0, 0, 0);
  }

  Circle::Circle(double r) {
    this->Init(r, 0, 0);
  }

  Circle::Circle(double r, double x, double y) {
    this->Init(r, x, y);
  }

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
    try {
      if (radius < 0) {
        throw "Радиус не может быть отрицательным";
      }
      if (radius == 0) {
        throw "Радиус не может быть равен нулю";
      }
    } catch (const char* msg) {
      cout << msg << endl;
      return -1;
    }

    return sqrt(x * x + y * y);
  }

  void Circle::distance(double& d) {
    d = distance();
  }

  void Circle::distance(double* d) {
    *d = distance();
  }

  double Circle::staticDistance(Circle c) {
    return c.distance();
  }

  Circle Circle::staticAdd(Circle c1, Circle c2) {
    Circle result;
    result.Init(c1.radius + c2.radius, c1.x + c2.x, c1.y + c2.y);
    return result;
  }

  Circle Circle::add(Circle c2) {
    this->radius = this->radius + c2.radius;
    this->x = this->x + c2.x;
    this->y = this->y + c2.y;

    Circle result;
    result.Init(this->radius, this->x, this->y);
    return result;
  }