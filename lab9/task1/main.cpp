#include <iostream>
#include <vector>
#include <fstream>
#include <algorithm>

using namespace std;

bool compare(int a, int b) {
  if (a % 3 == 0 && b % 3 == 0) {
    if (a % 3 == 0) {
      return a > b;
    } else if (a % 3 == 1) {
      return a < b;
    } else if (a % 3 == 2) {
      return a > b;
    }
  }

  return a % 3 < b % 3;
}

int main() {
  vector<int> v;
  ifstream in("input.txt");

  // вводим числа в вектор
  int number;
  while (in >> number) {
    v.push_back(number);
  }

  vector<int>::iterator ir;
  cout << "Изначальный контейнер: " << endl;
  for (ir = v.begin(); ir != v.end(); ++ir) {
    cout << *ir << " ";
  }

  sort(v.begin(), v.end(), compare);

  cout << endl << "Отсортированный контейнер: " << endl;
  for (ir = v.begin(); ir != v.end(); ++ir) {
    cout << *ir << " ";
  }
  cout << endl;
  return 0;
}
