#include <iostream>
#include "Circle.cpp"

using namespace std;

int main() {
    Circle c1(5, 8, 3);

    c1.Display();

    double nearestDist = nearestPointDistance(c1);
    cout << "Расстояние от начала координат до ближайшей точки окружности: " << nearestDist << endl;

    Circle c2(2, 2, 1);
    Circle c3 = c1 + c2;
    cout << "Сложение двух объектов:" << endl;
    c3.Display();

    Circle c4 = c3 + 4;
    cout << "Сложение объекта и числа:" << endl;
    c4.Display();

    c4 = 6 + c3;
    cout << "Сложение числа и объекта:" << endl;
    c4.Display();

    c1.Init(5, 8, 3);

    Circle c5 = ++c1;
    cout << "После префиксного инкремента c1:" << endl;
    c5.Display();

    c1.Init(5, 8, 3);

    c5 = c1++;
    cout << "После постфиксного инкремента c1:" << endl;
    c5.Display();

    return 0;
}
