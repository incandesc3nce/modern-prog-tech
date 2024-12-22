#include <iostream>
#include "Cylinder.cpp"
#include <random>

using namespace std;

int main() {
    vector<Circle*> v;

    int cylinderCount = 0;
    int circleCount = 0;

    for (int i = 0; i < 15; i++) {
        bool isCylinder = rand() % 2;
        if (isCylinder) {
            v.push_back(new Cylinder(rand() % 20 + 1, rand() % 20 + 1, rand() % 20 + 1, rand() % 20 + 1));
        } else {
            v.push_back(new Circle(rand() % 20 + 1, rand() % 20 + 1, rand() % 20 + 1));
        }
    }

    vector<Circle*>::iterator ir;

    for (ir = v.begin(); ir != v.end(); ++ir) {
        if (dynamic_cast<Cylinder*>(*ir)) {
            cylinderCount++;
        } else {
            circleCount++;
        }
    }

    cout << "Количество цилиндров (производный класс): " << cylinderCount << endl;
    cout << "Количество окружностей (базовый класс): " << circleCount << endl;

    for (ir = v.begin(); ir != v.end(); ++ir) {
        (*ir)->Display();
        cout << endl;
    }

    double distanceSum = 0;
    
    for (ir = v.begin(); ir != v.end(); ++ir) {
        distanceSum += (*ir)->distance();
    }

    cout << "Сумма расстояний до начала координат: " << distanceSum << endl;

    return 0;
}
