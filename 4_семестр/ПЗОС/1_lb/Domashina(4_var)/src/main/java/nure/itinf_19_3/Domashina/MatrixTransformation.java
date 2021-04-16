package nure.itinf_19_3.Domashina;

import java.util.Random;

/*
* Ввести с консоли n-размерность матрицы a [n] [n].
* Задать значения элементов матрицы в интервале значений от -n до n с помощью датчика случайных чисел.
* Повернуть матрицу на 90 (180, 270) градусов против часовой стрелки.
 * */
public class MatrixTransformation {
    private int[][] matrix;
    private final int n;

    public MatrixTransformation(int n) {
        this.n = n;
        matrix = new int[n][n];
        var random = new Random();
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                matrix[i][j] = random.nextInt(n);
            }
        }
    }

    public int getN() {
        return n;
    }

    public int[][] getMatrix() {
        return matrix;
    }

    public static int[][] turnOn90Degrees(int[][] matrix, int matrixLength) {
        if (matrix == null) {
            return null;
        }

        int[][] result = new int[matrixLength][matrixLength];
        for (int i = 0; i < matrixLength; ++i) {
            for (int j = 0; j < matrixLength; ++j) {
                result[matrixLength - j - 1][i] = matrix[i][j];
            }
        }

        return result;
    }

    public void turnOn90Degrees() {
        matrix = MatrixTransformation.turnOn90Degrees(matrix, n);
    }

    public void turnOn180Degrees() {
        matrix = MatrixTransformation.turnOn90Degrees(matrix, n);
        matrix = MatrixTransformation.turnOn90Degrees(matrix, n);
    }

    public void turnOn270Degrees() {
        matrix = MatrixTransformation.turnOn90Degrees(matrix, n);
        matrix = MatrixTransformation.turnOn90Degrees(matrix, n);
        matrix = MatrixTransformation.turnOn90Degrees(matrix, n);
    }
}
