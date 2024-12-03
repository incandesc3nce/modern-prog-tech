public class Main {
    public static void main(String[] args) {
        final int N = 4;
        final int M = 5;

        double[][] a = new double[N][M];
        Circle.arr2(a, N, M);

        for (int i = 0; i < N; ++i) {
            for (int j = 0; j < M; ++j) {
                System.out.print(a[i][j] + " ");
            }
            System.out.println();
        }
    }
}