using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

class Program {
  static int size = int.MaxValue / 10;
  static int[] arr;
  static int threadCount = 8;
  static ConcurrentDictionary<int, ConcurrentDictionary<int, int>> threadsDict = new ConcurrentDictionary<int, ConcurrentDictionary<int, int>>();

  static int[] GenerateRandomArray(int size) {
    Random random = new Random();
    int[] randomArr = new int[size];
    for (int i = 0; i < size; i++) {
      randomArr[i] = random.Next(0, 100);
    }
    return randomArr;
  }

  // считает количество повторений чисел в массиве в одном потоке и записывает результат в общий словарь
  static void threadFunc(object param) {
    int threadNumber = (int)param;
    int chunk = size / threadCount;
    int start = threadNumber * chunk;
    int end = start + chunk;

    ConcurrentDictionary<int, int> dict = new ConcurrentDictionary<int, int>();

    for (int i = start; i < end; i++) {
      dict.AddOrUpdate(arr[i], 1, (key, oldValue) => oldValue + 1);
    }

    threadsDict[threadNumber] = dict;
    Console.WriteLine($"Поток {threadNumber} завершил работу.");
  }

  // считает количество повторений чисел в массиве без потоков
  static ConcurrentDictionary<int, int> CountRepeatedNumbers(int[] arr) {
    ConcurrentDictionary<int, int> dict = new ConcurrentDictionary<int, int>();
    foreach (int num in arr) {
      dict.AddOrUpdate(num, 1, (key, oldValue) => oldValue + 1);
    }
    return dict;
  }

  // считает количество повторений чисел в массиве с потоками
  static void CountRepeatedNumbersWithThreads(int[] arr, int threadCount) {
    Thread[] threadArray = new Thread[threadCount];
    for (int i = 0; i < threadCount; i++) {
      threadArray[i] = new Thread(new ParameterizedThreadStart(threadFunc));
      threadArray[i].Start(i);
    }

    for (int i = 0; i < threadCount; i++) {
      threadArray[i].Join();
    }
  }
  
  static void Main(string[] args) {
    Console.WriteLine("Генерация массива...");
    arr = GenerateRandomArray(size);
    Console.WriteLine("Массив сгенерирован.");

    Console.WriteLine("\nПодсчет повторяющихся чисел без потоков...");
    DateTime sqStart = DateTime.Now;
    ConcurrentDictionary<int, int> dict = CountRepeatedNumbers(arr);
    DateTime sqEnd = DateTime.Now;
    Console.WriteLine("Подсчет завершен. Время выполнения: " + (sqEnd - sqStart));

    var maxRepeatedNumber = dict.Aggregate((l, r) => l.Value > r.Value ? l : r);
    Console.WriteLine("Максимум повторений: " + maxRepeatedNumber.Key + " с " + maxRepeatedNumber.Value + " повторениями.");

    Console.WriteLine("\nПодсчет повторяющихся чисел с потоками...");
    DateTime mtStart = DateTime.Now;
    CountRepeatedNumbersWithThreads(arr, threadCount);
    DateTime mtEnd = DateTime.Now;
    Console.WriteLine("Подсчет завершен. Время выполнения: " + (mtEnd - mtStart));

    ConcurrentDictionary<int, int> mergedDict = new ConcurrentDictionary<int, int>();
    foreach (var threadDict in threadsDict.Values) {
      foreach (var kvp in threadDict) {
        mergedDict.AddOrUpdate(kvp.Key, kvp.Value, (key, oldValue) => oldValue + kvp.Value);
      }
    }

    var maxRepeatedNumber2 = mergedDict.Aggregate((l, r) => l.Value > r.Value ? l : r);
    Console.WriteLine("Максимум повторений: " + maxRepeatedNumber2.Key + " с " + maxRepeatedNumber2.Value + " повторениями.");
  }
}
