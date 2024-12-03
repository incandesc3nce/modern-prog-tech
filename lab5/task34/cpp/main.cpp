#include <iostream>
#include "Circle.cpp"

using namespace std;

int main() {
    const int N = 5;
    const int M = 3;
    double a[N], b[M];

    Circle::arr(a, N, b, M);

    for (int i = 0; i < N; i++) {
        cout << a[i] << " ";
    }
    cout << endl;

    for (int i = 0; i < M; i++) {
        cout << b[i] << " ";
    }
    cout << endl;

    return 0;
}
