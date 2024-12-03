#include <iostream>
#include "Circle.cpp"

using namespace std;

int main() {
    const int N = 5;
    const int M = 6;

    double a[N][M];
    double* b[N];
    for (int i = 0; i < M; i++) {
        b[i] = a[i];
    }

    Circle::arr2(b, N, M);

    for (int i = 0; i < N; i++) {
        for (int j = 0; j < M; j++) {
            cout << a[i][j] << " ";
        }
        cout << endl;
    }

    return 0;
}
