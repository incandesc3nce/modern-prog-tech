#include <iostream>
#include "Circle.cpp"

using namespace std;

int main() {
    Circle c1, c2;
    c1.Init(3, 1, 1);
    c2.Init(4, 2, 2);

    cout << "Два аргумента: " << endl;
    Circle::staticAdd(c1, c2).Display();
    cout << "Один аргумент: " << endl;
    c1.add(c2).Display();

    Circle q;
    Circle w(5);
    Circle e(6, 3, 3);

    cout << Circle::staticDistance(c1) << endl;

    double result;
    try {
        c1.distance(result);
        cout << result << endl;
    } catch (const char* msg) {
        cout << msg << endl;
    }

    return 0;
}
