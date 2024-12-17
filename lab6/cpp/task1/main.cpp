#include <iostream>
#include "Cylinder.cpp"

using namespace std;

int main() {
    Circle staticCircle = Circle(5);
    Circle* dynamicCircle = new Circle(7, 10, 12);

    Cylinder staticCylinder = Cylinder(5);
    Cylinder* dynamicCylinder = new Cylinder(7, 5, 8, 10);

    // put get
    staticCylinder.Put(10);
    cout << "Длина стороны z статического цилиндра: " << staticCylinder.Get() << endl;

    // init, display, distance
    dynamicCylinder->Init(5, 10, 12, 10);
    dynamicCylinder->Display();
    cout << "Расстояние от начала координат до статического цилиндра: " << dynamicCylinder->distance() << endl;

    // operator =
    staticCircle.Init(5, 10, 12);
    staticCylinder = staticCircle;
    staticCylinder.Display();

    delete dynamicCircle;
    delete dynamicCylinder;

    return 0;
}
