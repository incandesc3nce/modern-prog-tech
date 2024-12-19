#include <iostream>
#include "Cylinder.cpp"

using namespace std;

int main() {
    // вызов метода для смещения центра
    Cylinder c(2, 4, 5, 3);
    c.Display();
    cout << "Расстояние до начала координат: " << c.distance() << endl;
    c.shiftCenter();
    cout << "После смещения центра по оси OX: " << endl;
    c.Display();

    // демонстрация
    Circle* a = new Circle(3, 4, 5);
    Cylinder* b = new Cylinder(3, 4, 5, 3);
    a = b;
    cout << endl << "Метод distance виртуальный, значит берется из Cylinder" << endl;
    cout << "Расстояние до начала координат: " << a->distance() << endl;

    return 0;
}
