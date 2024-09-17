#include <iostream>
#include "Circle.cpp"

using namespace std;

int main() {
    int staticSize = 3;
    Circle circles_static[staticSize];
    int dynamicSize = 3;
    Circle *circles_dynamic = new Circle[dynamicSize];

    Circle c1, c2, c3;
    c1.Init(4, 2, -1);
    c2.Init(6, -5, 2);
    c3.Init(2, 1, 1);

    circles_static[0] = c1;
    circles_static[1] = c2;
    circles_static[2] = c3;

    Circle c4, c5, c6;
    c4.Init(3, -1, 1);
    c5.Init(2, 2, -2);
    c6.Init(1, 3, 3);

    circles_dynamic[0] = c4;
    circles_dynamic[1] = c5;
    circles_dynamic[2] = c6;

    Circle totalCircle;
    totalCircle.Init(0, 0, 0);
    
    for (int i = 0; i < staticSize; i++) {
        totalCircle = totalCircle.add(totalCircle, circles_static[i]);
    }

    for (int i = 0; i < dynamicSize; i++) {
        totalCircle = totalCircle.add(totalCircle, circles_dynamic[i]);
    }

    totalCircle.Display();

    delete[] circles_dynamic;

    return 0;
}
