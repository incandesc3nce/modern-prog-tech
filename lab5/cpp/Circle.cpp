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
    // void Read();
    // void Display();

    double distance();
    void distance(double& d);
    void distance(double* d);
    static double staticDistance(Circle c);

    static Circle staticAdd(Circle c1, Circle c2);
    Circle add(Circle c2);

    friend double nearestPointDistance(Circle c);

    Circle operator+(Circle c);
    Circle operator+(double val);
    friend Circle operator+(double val, Circle c);

    Circle& operator++();
    Circle operator++(int unused);

    friend void operator << (ostream& os, Circle c);
    friend Circle operator >> (istream& is, Circle& c);
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

  // void Circle::Read() {
  //   cout << "Введите радиус:";
  //   cin >> radius;
  //   cout << "Введите координату x:";
  //   cin >> x;
  //   cout << "Введите координату y:";
  //   cin >> y;
  // }

  // void Circle::Display() {
  //   cout << "Радиус: " << radius << endl;
  //   cout << "Координата x: " << x << endl;
  //   cout << "Координата y: " << y << endl;
  // }

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

  double nearestPointDistance(Circle c) {
    double distanceToCenter = sqrt(c.x * c.x + c.y + c.y);
    
    return distanceToCenter - c.radius;
  }

  Circle Circle::operator+(Circle c) {
    Circle result;
    result.x = this->x + c.x;
    result.y = this->y + c.y;
    result.radius = this->radius + c.radius;

    return result;
  }

  Circle Circle::operator+(double val) {
    Circle result;
    result.radius = this->radius + val;
    result.x = this->x;
    result.y = this->y;

    return result;
  }

  Circle operator+(double val, Circle c) {
    Circle result;
    result.radius = c.radius + val;
    result.x = c.x;
    result.y = c.y;

    return result;
  }

  Circle &Circle::operator++() {
    this->radius++;
    return *this;
  }

  Circle Circle::operator++(int unused) {
    Circle result = *this;
    this->radius++;
    return result;
  }

  void operator << (ostream& os, Circle c) {
    cout << "Радиус: " << c.radius << endl;
    cout << "Координата x: " << c.x << endl;
    cout << "Координата y: " << c.y << endl;
  }

  Circle operator >> (istream& is, Circle& c) {
    cout << "Введите радиус: ";
    cin >> c.radius;
    cout << "Введите координату x: ";
    cin >> c.x;
    cout << "Введите координату y: ";
    cin >> c.y;

    return c;
  }