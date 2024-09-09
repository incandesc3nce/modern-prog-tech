#include <iostream>
#include "Circle.cpp"

using namespace std;

int main() {
    Circle* c1 = new Circle();
    Circle* circleArray = new Circle[3];

    c1->Init(5, 1, 2);
    c1->Display();
    cout << (*c1).distance() << endl;

    delete c1;

    for (int i = 0; i < 3; i++) {
        circleArray[i].Read();
        circleArray[i].Display();
    }

    Circle c2 = Circle();
    c2.Init(0, 0, 0);
    
    for (int i = 0; i < 3; i++) {
        c2 = c2.add(circleArray[i]);
    }

    c2.Display();
    
    delete[] circleArray;

    return 0;
}
