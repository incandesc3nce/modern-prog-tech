public class Main {
    public static void main(String[] args) {
        final int N = 5;
        final int M = 3;

        double a[] = new double[N];
        double b[] = new double[M];

        Circle.arr(a, N, b, M);

        for (int i = 0; i < N; i++) {
            System.out.print(a[i] + " ");
        }
        System.out.println();

        for (int i = 0; i < M; i++) {
            System.out.print(b[i] + " ");
        }
        System.out.println();

    }
}